//Preenche um dropDown no evento change do objeto de origem
//
//Exemplos de utilização:
//      $('#ddlOrigem').preencherDropDownCascata('@Url.Action("NomeDaAction")', $('#ddlDestino'), 'ValorSelecionado', "NomeDoParametro", "Id", "Descricao", "Selecione...");
//      $('#concursoID').preencherDropDownCascata('@Url.Action("BuscarAreas")', $('#areaID'), '@Model.areaID', "ConcursoId", "Id", "nome", "Selecione uma Área");
//
//Parâmetros:
//  url: Url de Destino retornando um Json
//  ddlDestino: Dropdown a ser preenchido 
//  valorSelecionado: Valor que deve ser selecionado ao preencher o ddlDestino
//  nomeParametro: Nome do variável que será enviada via post com o valor selecionado do objeto de origem
//  campoValor: Campo a ser atribuído no value do ddlDestino
//  campoTexto: Campo a ser atribuído no text do ddlDestino
//  conteudoPadrao: Texto do primeiro item do ddlDestino
//
$.fn.preencherDropDownCascata = function (url, ddlDestino, valorSelecionado, nomeParametro, campoValor, campoTexto, conteudoPadrao) {

    $(this).change(function () { dropdownOnChange($(this), url, ddlDestino, valorSelecionado, nomeParametro, campoValor, campoTexto, conteudoPadrao); })
           .change();
}

function dropdownOnChange(ddl, url, ddlDestino, valorSelecionado, nomeParametro, campoValor, campoTexto, conteudoPadrao) {
    var parametro = {};
    parametro[nomeParametro] = ddl.val();

    campoValor = campoValor || 'Id';
    campoTexto = campoTexto || 'Descricao';
    conteudoPadrao = conteudoPadrao || 'Selecione...';

    if (ddl.val()) {
        preencherDropDownJson(url, parametro, ddlDestino, valorSelecionado, campoValor, campoTexto, conteudoPadrao)
    }
    else {
        limparDropdown(ddlDestino, conteudoPadrao);
    }
}

function preencherDropDownJson(url, parametros, ddlDestino, valorSelecionado, campoValor, campoTexto, conteudoPadrao) {

    limparDropdown(ddlDestino, conteudoPadrao);
    parametros && $.get(url, parametros)
                      .done(function (dados) {
                          preencherDropdown(dados, ddlDestino, campoValor, campoTexto);

                          ddlDestino.children('option[value="' + valorSelecionado + '"]').prop("selected", true);
                      });
}

function limparDropdown(dropDown, conteudoPadrao) {

    dropDown.empty()
            .append('<option value="">' + conteudoPadrao + '</option>')
            .prop('disabled', true);
}

function preencherDropdown(dados, ddlDestino, campoValor, campoTexto) {

    ddlDestino.prop('disabled', !dados.length);

    dados.forEach(function (item) {
        ddlDestino.append('<option value="' + item[campoValor] + '">' + item[campoTexto] + '</option>');
    });
}
