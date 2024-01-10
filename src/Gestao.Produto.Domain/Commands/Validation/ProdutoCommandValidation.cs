using FluentValidation;

namespace Gestao.Produto.Domain.Commands.Validation
{
    public abstract class ProdutoCommandValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidarCodigo()
        {
            RuleFor(c => c.Codigo)
                .NotEqual(0)
                .WithMessage("Preencha o Código do Produto");
        }

        protected void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("Preencha o Descrição do Produto");
        }

        protected void ValidarDataFabricacao()
        {
            RuleFor(x => x.DataFabricacao)
                .LessThan(x => x.DataValidade)
                .WithMessage("A Data de Fabricação deve ser anterior à Data de Validade.");
        }
    }
}
