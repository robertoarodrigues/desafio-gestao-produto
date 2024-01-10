using Gestao.Produto.Core.Messages;
using System;

namespace Gestao.Produto.Domain.Commands
{
    public abstract class ProdutoCommand : Command
    {
        public int Codigo { get; protected set; }
        public string Descricao { get; protected set; }
        public bool SituacaoProduto { get; protected set; }
        public DateTime DataFabricacao { get; protected set; }
        public DateTime DataValidade { get; protected set; }

        public int CodigoFornecedor { get; protected set; }
    }
}
