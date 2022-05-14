function buscaCardapioPrincipal(codMesa) {
    $.ajax({
        url: "/Cardapio/ObterCardapioPrincipal",
        type: 'get',
        cache: false,
        async: true,
    }).done(function (data) {
        var IdCardapio = data["idCardapio"];
        var tituloCardapio = data["titulo"];
        buscaListaCardapioCardapioPrincipal(IdCardapio, codMesa);
        $("#Menu").html(ListaMenuHtml);
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;

}

function buscaListaCardapioCardapioPrincipal(idcardapio, codMesa) {
    $("#wait").css("display", "block");
    $.ajax({
        url: "/Cardapio/BuscarMenuListaCardapio",
        type: 'get',
        data: { idCardapio: idcardapio },
        cache: false,
        async: true,
    }).done(function (data) {
        var ListaMenuHtml = ObjetoHtmlListMenuCardapioPrincipal(data, codMesa);
        $("#Menu").html(ListaMenuHtml);
        $("#MenuCadapio").text("Cardápio Selecionado : " + TituloGlobalSalvar);
        $("#wait").css("display", "none");
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;

}

function ObjetoHtmlListMenuCardapioPrincipal(cardapio, codMesa) {
    var listProdud = '';
    var html = '';

    for (var i = 0; i < cardapio['listMenu'].length; i++) {
        for (var j = 0; j < cardapio['listMenu'][i]['listProduto'].length; j++) {
            listProdud += '<a class="dropdown-item" onclick="AdicionarConsumo(' + codMesa + ',' + cardapio['listMenu'][i]['listProduto'][j].codigo + ')"  href="#">' + cardapio['listMenu'][i]['listProduto'][j].nome + '- <font COLOR="#rrggbb">Adicionar na mesa</font> </a>';
        }


        html +=
            '<div class="card col-6 col-md-4 offset-md-1">' +
            '<h5 id="TituloMenu" class="card-header" style="background-color:#ff6a00;">' +
            cardapio['listMenu'][i].titulo +
            '</h5>' +
            '<div class="card-body">' +
            '<p class="card-text">' + cardapio['listMenu'][i].descricao + '</p>' +
            '<div class="row">' +
            '<div class="col">' +
            '<div class="dropdown show">' +
            '<a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' +
            'Produtos' +
            '</a>' +
            '<div class="dropdown-menu" aria-labelledby="dropdownMenuLink">' +
            listProdud +
            '</div>' +
            '</div>' +
            '</div>' +
            '<div class="col-md-2">' +
            '</div>' +
            '<div class="col col-lg-2">' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';

        listProdud = '';

    }



    return html;
}

function AdicionarConsumo(codMesa, codProduto) {

    var formaPagamento = $('#SelectFormaPagamento option:selected').text();

    $.ajax({
        url: "/Mesa/AdicionarConsumoMesa",
        type: 'Post',
        data: { codMesa: codMesa, codProduto: codProduto, },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#ModalGenric").on('hide.bs.modal', function () {
            window.location.reload();
        });
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;
}

function AbrirMesa(numeroMesa, codMesa) {
    $("#overlay").fadeIn();　
   
    $.ajax({
        url: "/Mesa/AbrirMesa",
        type: 'Post',
        data: { codMesa: codMesa, numeroMesa: numeroMesa, },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#ModalGenric").on('hide.bs.modal', function () {
                 window.location.href = 'GerenciaMesa';
        });
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;
  
}



function FechamentoMesa(codMesa, seqAbreMesa, numeroMesa,totalFechamento) {
    $("#ModalConfirm").modal();
    $("#ModalConfirm .modal-body").text("Atenção, deseja realizar fechamento da Mesa " + numeroMesa + " ?");

    $("#ButtonConfirm").text('Confirmar');
    let btn = document.querySelector('.alert-confirm')
    
    if (!!btn) {
        btn.addEventListener('click', function (evt) {
            //Bloqueando bottão aguardando finalização
            $("#ButtonConfirm").prop("disabled", true);
            $("#ModalConfirm .modal-body").text("Aguarde... Realizando fechamento na Mesa " + numeroMesa + "...");

            $.ajax({
                url: "/Mesa/FechamentoMesa",
                type: 'Post',
                data: { codMesa: codMesa, seqAbreMesa: seqAbreMesa, totalFechamento: totalFechamento },
                cache: false,
                async: true,
            }).done(function (data) {

                //Processo de gerar cupom não fiscal apos finalização com sucesso do fechamento
                $("#ModalConfirm .modal-body").text(data['description']);
                $("#ButtonConfirm").text('Gerar CUPOM NÃO FISCAL');
                $("#ButtonConfirm").css('background-color', 'black');
                $("#ButtonConfirm").prop("disabled", false);

                btn.addEventListener('click', function (evt) {
                    window.location = '/Caixa/CupomNaoFiscal?seqAbreMesa='+seqAbreMesa;
                });
                    

            }).fail(function (data) {
                $("#ModalGenric").modal();
                $("#ModalGenric .modal-body").text(data['responseText']);
            });;
        });

    }
}

function DeleteProdutoConsumoMesa(codigoItemConsumo, codMesa) {

    $.ajax({
        url: "/Mesa/DeleteProdutoConsumoMesa",
        type: 'Post',
        data: { codigoItemConsumo: codigoItemConsumo, codMesa: codMesa },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#ModalGenric").on('hide.bs.modal', function () {
            window.location.reload();
        });

    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;
}
