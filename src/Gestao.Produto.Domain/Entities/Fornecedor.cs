using System.Collections.Generic;

namespace Gestao.Produto.Domain.Entities
{
    public class Fornecedor : Entity
    {
        public Fornecedor(int codigo, string descricao, string cnpj)
        {
            Codigo = codigo;
            Descricao = descricao;
            Cnpj = cnpj;
        }

        //Construtor vazio para EF
        protected Fornecedor() { }

        public string Descricao { get; private set; }
        public string Cnpj { get; private set; }


        public IEnumerable<Produto> Produtos { get; set; }
    }
}
