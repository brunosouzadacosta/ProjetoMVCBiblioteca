using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVCBiblioteca.Models
{
    public class Livros
    {
        public List<Livro> Acervo { get; set; } = new List<Livro>();

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(int isbn)
        {
            return Acervo.FirstOrDefault(l => l.Isbn == isbn);
        }
    }

}
