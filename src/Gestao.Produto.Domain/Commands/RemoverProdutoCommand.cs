using Gestao.Produto.Domain.Commands.Validation;

namespace Gestao.Produto.Domain.Commands
{
    public class RemoverProdutoCommand : ProdutoCommand
    {
        public RemoverProdutoCommand(int codigo) => Codigo = codigo;

        public override bool EhValido()
        {
            ValidationResult = new RemoverProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
