var TituloGlobalSalvar = '';

function CreateListCardapio(idcardapio, tituloCardapio) {
    $("#overlay").fadeIn();
    TituloGlobalSalvar = '';
    var idCaradpio = idcardapio;
    var tituloCardapio = tituloCardapio;
    TituloGlobalSalvar = tituloCardapio;

    $.ajax({
        url: "/Cardapio/MenuListCardapio",
        type: 'get',
        cache: false,
        async: true,
    }).done(function (data) {
        $("#modal-body").html(data);
        $("#custId").val(idCaradpio);
        buscaListaCardapio(idcardapio, tituloCardapio);
        $("#overlay").fadeOut();
    }).fail(function () {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;
}


function SalveMenuListCardapio() {
    $("#overlay").fadeIn();
    $("#SalvaMenuLista").attr("disabled", true);
    $("#wait").css("display", "block");
    var idcardapio = $("#custId").val();
    var titulo = $('#tituloMenu').val();
    var descricao = $('#descricao').val();
    var SelectProdutos = $('#SelectProduto').val();

    $.ajax({
        url: "/Cardapio/MenuListCardapio",
        type: 'post',
        data: { idCardapio: idcardapio, titulo: titulo, descricao: descricao, produtos: SelectProdutos },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        buscaListaCardapio(idcardapio, "");
        $("#wait").css("display", "none");
        $("#SalvaMenuLista").attr("disabled", false);
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;
}



function buscaListaCardapio(idcardapio, tituloCardapio) {
    $("#overlay").fadeIn();
        $("#wait").css("display", "block");
    $.ajax({
        url: "/Cardapio/BuscarMenuListaCardapio",
        type: 'get',
        data: { idCardapio: idcardapio },
        cache: false,
        async: true,
    }).done(function (data) {
        var ListaMenuHtml = ObjetoHtmlMenuList(data);
        $("#Menu").html(ListaMenuHtml);
        $("#MenuCadapio").text("Cardápio Selecionado : " + TituloGlobalSalvar);
        $("#wait").css("display", "none");
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;

}


function ExcluirMenuLista(codMenuSeq) {
    $("#overlay").fadeIn();
    var idcardapio = $("#custId").val();
    $.ajax({
        url: "/Cardapio/DeleteMenuListaCardapio",
        type: 'delete',
        data: { codMenuSeq: codMenuSeq },
        cache: false,
        async: true,
    }).done(function (data) {
        buscaListaCardapio(idcardapio, "");
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#wait").css("display", "none");
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;

}

function AlterarMenuListaCardapio() {
    $("#overlay").fadeIn();
    $("#wait").css("display", "block");
    var idcardapio = $("#custId").val();
    var titulo = $('#tituloMenu').val();
    var descricao = $('#descricao').val();
    var SelectProdutos = $('#SelectProduto').val();

    $.ajax({
        url: "/Cardapio/AlterarMenuListaCardapio",
        type: 'Post',
        data: { idCardapio: idcardapio, titulo: titulo, descricao: descricao, produtos: SelectProdutos, codMenuSeq: $('#codMenuSeq').val()},
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        buscaListaCardapio(idcardapio, "");
        $("#wait").css("display", "none");
        $("#SalvaMenuLista").attr("disabled", false);
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#overlay").fadeOut();
    });;

}

function PreencherDadosFormularioAlteracao(codMenu) {
    $("#SalvaMenuLista").css("display", "none");
    $("#AlterarMenuLista").css("display", "block");

    var idcardapio = $("#custId").val();
    var ArrayIdProdutos = [];

    $.ajax({
        url: "/Cardapio/BuscarMenuListaCardapio",
        type: 'get',
        data: { idCardapio: idcardapio },
        cache: false,
        async: true,
    }).done(function (data) {

        for (var i = 0; i < data['listMenu'].length; i++) {

            if (data['listMenu'][i].codMenuSeq == codMenu) {

                $('#tituloMenu').val(data['listMenu'][i].titulo);
                $('#descricao').val(data['listMenu'][i].descricao);
                $('#codMenuSeq').val(data['listMenu'][i].codMenuSeq);
                for (var j = 0; j < data['listMenu'][i]['listProduto'].length; j++) {
                    ArrayIdProdutos[j] = data['listMenu'][i]['listProduto'][j].codigo;
                }

            }
           
        }
        $('#SelectProduto').val(ArrayIdProdutos);
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;


}


function ObjetoHtmlMenuList(cardapio) {
    var listProdud = '';
    var html = '';

    for (var i = 0; i < cardapio['listMenu'].length; i++) {
        for (var j = 0; j < cardapio['listMenu'][i]['listProduto'].length; j++) {
            listProdud += '<a class="dropdown-item" href="#">' + cardapio['listMenu'][i]['listProduto'][j].nome + '</a>';
        }


        html +=
            '<div class="card">' +
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
        '<button type="button" onclick="PreencherDadosFormularioAlteracao('+cardapio['listMenu'][i].codMenuSeq +')"class="btn btn-primary">Alterar</button>' +
            '</div>' +
            '<div class="col col-lg-2">' +
            '<button type="button" onclick="ExcluirMenuLista('+cardapio['listMenu'][i].codMenuSeq+')" class="btn btn-danger">Excluir</button>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';

        listProdud = '';

    }



    return html;
}




function ExcluirCardapio(codCardapio, nomeCardapio) {

    $("#ModalConfirm").modal();
    $("#ModalConfirm .modal-body").text("Atenção, deseja realizar a exclusão do cardápio "+nomeCardapio+" ? Todos os menus desse cardápio será excluído. Confirmar a exclusão ?");

    let btn = document.querySelector('.alert-confirm')

  
    if (!!btn) {
        btn.addEventListener('click', function (evt) {
            $("#ButtonConfirm").css("display", "none");
            $.ajax({
                url: "/Cardapio/DeleteCardapio",
                type: 'delete',
                data: { id: codCardapio },
                cache: false,
                async: true,
            }).done(function (data) {
                $("#ModalConfirm .modal-body").text(data['description']);
                $("#ModalConfirm").on('hide.bs.modal', function () {
                    window.location.href = 'create';
                });

            }).fail(function (data) {
                $("#ModalConfirm .modal-body").text(data['responseText']);
                $("#ModalConfirm").on('hide.bs.modal', function () {
                    window.location.href = 'create';
                });

            });;

        }, false)
    }
   
}

function AtualizarCardapio() {

    var titulo = $('#titulo').val();
    var idCardapio = $('#idCardapio').val();

            $.ajax({
                url: "/Cardapio/AtualizaCardapio",
                type: 'Put',
                data: { id: idCardapio, titulo: titulo },
                cache: false,
                async: true,
            }).done(function (data) {
                $("#ModalGenric").modal();
                $("#ModalGenric .modal-body").text(data['description']);
                $("#ModalGenric").on('hide.bs.modal', function () {
                    window.location.href = 'create';
                });
                $("#wait").css("display", "none");
            }).fail(function (data) {
                $("#ModalGenric").modal();
                $("#ModalGenric .modal-body").text(data['responseText']);
                $("#ModalGenric").on('hide.bs.modal', function () {
                    window.location.href = 'create';
                });
            });;

}

function BuscarCardapio(idCardapio) {

    $.ajax({
        url: "/Cardapio/ObterCardapio",
        type: 'Get',
        data: { id: idCardapio},
        cache: false,
        async: true,
    }).done(function (data) {
        var idCardapio = $('#idCardapio').val(data['idCardapio']);
        var titulo = $('#titulo').val(data['titulo']);

        $("#Salvar").css("display", "none");
        $("#IdAtualizarCardapio").css("display", "block");

        $("#wait").css("display", "none");
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
    });;

}

//Definindo cardapio principal
$("#cadapioPrincipal").on('change', "input[name=cardprincipal]", function () {

    var codCardapio = $('input[name=cardprincipal]:checked', '#cadapioPrincipal').val();
    DefinirCardapioPrincipal(codCardapio);
});

$("#cadapioNaoChecado").on('change', "input[name=cardNaoChecado]", function () {

    var codCardapio = $('input[name=cardNaoChecado]:checked', '#cadapioNaoChecado').val();
    DefinirCardapioPrincipal(codCardapio);
});

function DefinirCardapioPrincipal(codCardapio) {

    $("#overlay").fadeIn();
   
    $.ajax({
        url: "/Cardapio/DefinirCardapioPrincipal",
        type: 'Put',
        data: { codCardapio: codCardapio },
        cache: false,
        async: true,
    }).done(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['description']);
        $("#ModalGenric").on('hide.bs.modal', function () {
            window.location.href = 'create';
        });
        $("#wait").css("display", "none");
        $("#overlay").fadeOut();
    }).fail(function (data) {
        $("#ModalGenric").modal();
        $("#ModalGenric .modal-body").text(data['responseText']);
        $("#ModalGenric").on('hide.bs.modal', function () {
            window.location.href = 'create';
        });
        $("#overlay").fadeOut();
    });;

}
