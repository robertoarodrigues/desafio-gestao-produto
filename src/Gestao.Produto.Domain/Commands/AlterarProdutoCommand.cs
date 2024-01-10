using Gestao.Produto.Domain.Commands.Validation;
using System;

namespace Gestao.Produto.Domain.Commands
{
    public class AlterarProdutoCommand : ProdutoCommand
    {
        public AlterarProdutoCommand(
            int codigo,
            string descricao,
            bool situacaoProduto,
            DateTime dataFabricacao,
            DateTime dataValidade,
            int codigoFornecedor
        )
        {
            Codigo = codigo;
            Descricao = descricao;
            SituacaoProduto = situacaoProduto;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
        }

        public override bool EhValido()
        {
            ValidationResult = new AlterarProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
