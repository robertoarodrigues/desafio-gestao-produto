namespace Gestao.Produto.Domain.Commands.Validation
{
    public class AlterarProdutoCommandValidation : ProdutoCommandValidation<AlterarProdutoCommand>
    {
        public AlterarProdutoCommandValidation()
        {
            ValidarCodigo();
            ValidarDescricao();
            ValidarDataFabricacao();
        }
    }
}
