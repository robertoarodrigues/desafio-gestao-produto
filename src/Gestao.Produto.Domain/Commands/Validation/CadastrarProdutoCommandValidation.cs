namespace Gestao.Produto.Domain.Commands.Validation
{
    public class CadastrarProdutoCommandValidation : ProdutoCommandValidation<CadastrarProdutoCommand>
    {
        public CadastrarProdutoCommandValidation()
        {
            ValidarDescricao();
            ValidarDataFabricacao();
        }
    }
}
