namespace Gestao.Produto.Domain.Entities
{
    public abstract class Entity
    {
        public virtual int Codigo { get; set; }

        protected Entity()
        {
            Codigo = 0;
        }
    }
}
