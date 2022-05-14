function BuscarConta() {
    $("#overlay").fadeIn();
    var seqAbreMesa = $("#seqAbreMesa").val();

    $.ajax({
        url: "/Caixa/ObterContaPendente",
        type: 'Get',
        data: { seqAbreMesa: seqAbreMesa },
        cache: false,
        async: true,
    }).done(function (data) {
        if (data != undefined) {
            var todayDataAbertura = new Date(data['dataAbertura']);
            var todayDataFechamento = new Date(data['dataFechamento']);
            $("#CupomFiscal").html("");
            $('#seqAbreMesa').val(data['seqAbreMesa']);
            var total = data['total'];
            totalFormatado = formatarValorReal(total);
            $('#total').val(totalFormatado);
            $('#totalReal').val(data['total']);
            $('#numeroMesa').text("Mesa Número: " + data['numeroMesa']);
            $('#DataAbertura').text("Data Hora abertura mesa: " + todayDataAbertura.toLocaleString());
            $('#DataFehamento').text("Data Hora Fechamento mesa: " + todayDataFechamento.toLocaleString());
            $('#CupomFiscal').append(
                '<button onclick="ObterCupomFiscalNovaGuia(' + data['seqAbreMesa'] + ')" type = "button" class= "btn btn-dark" > Cupom Não fiscal</button>'
            );
            $('#RealizarBaixa').append(
                '<button onclick="RealizarBaixa(' + data['codigo'] + ')" type = "button" class="btn btn-primary" >RealizarBaixa</button>'  );

        } else {
            $("#ModalGenric").modal();
            $("#ModalGenric .modal-body").text("Pedido: " + seqAbreMesa + " não encontrado.");
            $("#ModalGenric").on('hide.bs.modal', function () {
                window.location = '/Caixa/ContaAReceber';
            });
        }
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;
    
}

function ObterCupomFiscalNovaGuia(seqAbreMesa) {
    window.open('/Caixa/CupomNaoFiscal?seqAbreMesa=' + seqAbreMesa, '_blank');
}

function RealizarBaixa(codigoConta) {
    $("#overlay").fadeIn();
    var formaPagamentoValor = $('#SelectFormaPagamento option:selected').val();

    var formaPagamentoText = $('#SelectFormaPagamento option:selected').text();

    if (formaPagamentoText == "Selecione...") {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text("Selecione a forma de Pagamento");
        return;
    }

    if (formaPagamentoText == "Dinheiro") {
        if ($("#valorEntrada").val() == "") {
            $("#ModalGenric").modal();
            $("#ModalGenric .modal-body").text("Método de pagamento selecionado Dinheiro, informe o valor de entrada.");
            return;
        }
    }


    $.ajax({
        url: "/Caixa/RealizaBaixaConta",
        type: 'Post',
        data: { valorEntrada: $("#valorEntrada").val(), formaPgto: formaPagamentoValor, codigoConta: codigoConta },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#ModalGenric").on('hide.bs.modal', function () {
            window.location = '/Caixa/ContaAReceber';
        });
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#overlay").fadeOut();
    });;
    
}

function formatarValorReal(valor) {

    const formattedValue = valor.toLocaleString(
        'pt-BR',
        { style: 'currency', currency: 'BRL' }
    );
    return formattedValue;
}



$("#SelectFormaPagamento").change(function () {
    var formaPagamento =  $('#SelectFormaPagamento option:selected').text();

    if (formaPagamento == "Dinheiro") {
        $("#valorEntrada").prop('disabled', false);
    } else {
        $("#valorEntrada").prop('disabled', true);
    }
});

$("#valorEntrada").keyup(function () {

    if ($("#valorEntrada").val() != "" && $("#totalReal").val() != "") {

        $.ajax({
            url: "/Caixa/CalcularTroco",
            type: 'Get',
            data: { valorEntrada: $("#valorEntrada").val().replace(",", "."), ValorTotal: $("#totalReal").val() },
            cache: false,
            async: true,
        }).done(function (data) {
            $('#totalTroco').val(formatarValorReal(data));
        }).fail(function (data) {
            $('#totalTroco').val("");
        });;

    } else {
        $('#totalTroco').val("");
    }

});




