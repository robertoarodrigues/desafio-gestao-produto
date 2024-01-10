using System;
using System.ComponentModel.DataAnnotations;

namespace Gestao.Produto.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha Descrição do Produto")]
        public string Descricao { get; set; }

        public bool SituacaoProduto { get; set; }

        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
    }
}
