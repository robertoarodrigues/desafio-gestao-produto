namespace Gestao.Produto.Domain.Commands.Validation
{
    public class RemoverProdutoCommandValidation : ProdutoCommandValidation<RemoverProdutoCommand>
    {
        public RemoverProdutoCommandValidation()
        {
            ValidarCodigo();
        }
    }
}
