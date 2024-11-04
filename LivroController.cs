using ProjetoMVCBiblioteca.Models;

public class LivroController
{
    private readonly Livros _livros = new Livros();

    public void AdicionarLivro()
    {
        Console.WriteLine("Informe o ISBN do livro:");
        int isbn = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o título do livro:");
        string titulo = Console.ReadLine();

        Console.WriteLine("Informe o autor do livro:");
        string autor = Console.ReadLine();

        Console.WriteLine("Informe a editora do livro:");
        string editora = Console.ReadLine();

        Livro livro = new Livro { Isbn = isbn, Titulo = titulo, Autor = autor, Editora = editora };
        _livros.Adicionar(livro);

        Console.WriteLine("Livro adicionado com sucesso!");
    }

    public void PesquisarLivroSintetico()
    {
        Console.WriteLine("Informe o ISBN do livro:");
        int isbn = int.Parse(Console.ReadLine());

        var livro = _livros.Pesquisar(isbn);
        if (livro != null)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
            Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}, Disponibilidade: {livro.PercDisponibilidade():F2}%");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    public void PesquisarLivroAnalitico()
    {
        Console.WriteLine("Informe o ISBN do livro:");
        int isbn = int.Parse(Console.ReadLine());

        var livro = _livros.Pesquisar(isbn);
        if (livro != null)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
            Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}, Disponibilidade: {livro.PercDisponibilidade():F2}%");

            Console.WriteLine("\nDetalhes dos Exemplares:");
            foreach (var exemplar in livro.Exemplares)
            {
                Console.WriteLine($"Tombo: {exemplar.Tombo}, Disponível: {exemplar.Disponivel()}");

                if (exemplar.Emprestimos.Count > 0)
                {
                    Console.WriteLine("Histórico de Empréstimos:");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        string dataDevolucao = emprestimo.DtDevolucao == DateTime.MinValue ? "Em aberto" : emprestimo.DtDevolucao.ToString();
                        Console.WriteLine($"Data de Empréstimo: {emprestimo.DtEmprestimo}, Data de Devolução: {dataDevolucao}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum empréstimo registrado.");
                }
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    public void AdicionarExemplar()
    {
        Console.WriteLine("Informe o ISBN do livro para adicionar um exemplar:");
        int isbn = int.Parse(Console.ReadLine());

        var livro = _livros.Pesquisar(isbn);
        if (livro != null)
        {
            Console.WriteLine("Informe o tombo do exemplar:");
            int tombo = int.Parse(Console.ReadLine());

            Exemplar exemplar = new Exemplar { Tombo = tombo };
            livro.AdicionarExemplar(exemplar);

            Console.WriteLine("Exemplar adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    public void RegistrarEmprestimo()
    {
        Console.WriteLine("Informe o ISBN do livro para empréstimo:");
        int isbn = int.Parse(Console.ReadLine());

        var livro = _livros.Pesquisar(isbn);
        if (livro != null)
        {
            Console.WriteLine("Informe o tombo do exemplar para empréstimo:");
            int tombo = int.Parse(Console.ReadLine());

            var exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
            if (exemplar != null)
            {
                if (exemplar.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não está disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Exemplar não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    public void RegistrarDevolucao()
    {
        Console.WriteLine("Informe o ISBN do livro para devolução:");
        int isbn = int.Parse(Console.ReadLine());

        var livro = _livros.Pesquisar(isbn);
        if (livro != null)
        {
            Console.WriteLine("Informe o tombo do exemplar para devolução:");
            int tombo = int.Parse(Console.ReadLine());

            var exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);
            if (exemplar != null)
            {
                if (exemplar.Devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exemplar não está emprestado.");
                }
            }
            else
            {
                Console.WriteLine("Exemplar não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
}
