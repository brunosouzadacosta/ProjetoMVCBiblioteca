using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVCBiblioteca.Models
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return Exemplares.Count(exemplar => exemplar.Disponivel());
        }

        public int QtdeEmprestimos()
        {
            return Exemplares.Sum(exemplar => exemplar.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            int totalExemplares = QtdeExemplares();
            if (totalExemplares == 0) return 0;
            return (double)QtdeDisponiveis() / totalExemplares * 100;
        }
    }

}
