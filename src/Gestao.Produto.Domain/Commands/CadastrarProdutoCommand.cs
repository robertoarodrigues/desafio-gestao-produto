using Gestao.Produto.Domain.Commands.Validation;
using System;

namespace Gestao.Produto.Domain.Commands
{
    public class CadastrarProdutoCommand : ProdutoCommand
    {
        public CadastrarProdutoCommand(
            string descricao,
            bool situacaoProduto,
            DateTime dataFabricacao,
            DateTime dataValidade,
            int codigoFornecedor
        )
        {
            Descricao = descricao;
            SituacaoProduto = situacaoProduto;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
