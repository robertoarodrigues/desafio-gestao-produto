
using System;

namespace Gestao.Produto.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(
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

        //Construtor vazio para EF
        public Produto() { }

        public string Descricao { get; private set; }
        public bool SituacaoProduto { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }

        public int CodigoFornecedor { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        public void Ativar() => SituacaoProduto = true;
        public void Desativar() => SituacaoProduto = false;

    }
}
