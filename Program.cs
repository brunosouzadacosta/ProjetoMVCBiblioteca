public class Program
{
    static void Main(string[] args)
    {
        LivroController controller = new LivroController();
        int opcao;

        do
        {
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    controller.AdicionarLivro();
                    break;
                case 2:
                    controller.PesquisarLivroSintetico();
                    break;
                case 3:
                    controller.PesquisarLivroAnalitico();
                    break;
                case 4:
                    controller.AdicionarExemplar();
                    break;
                case 5:
                    controller.RegistrarEmprestimo();
                    break;
                case 6:
                    controller.RegistrarDevolucao();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 0);
    }
}

