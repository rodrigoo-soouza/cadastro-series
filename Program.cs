using System;

namespace Cadastro_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpperInvariant() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Código Inválido");
                        break;
                        
                        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
        
            foreach(var serie in lista) 
            { 
            
                Console.WriteLine($"#ID {serie.RetornaId()}: - {serie.RetornaTitulo()}");

            }
        }

            private static void InserirSerie() 
        {
            
            Console.WriteLine("Inserir nova série: ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}. {Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
        
            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,                          
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);
            
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie() 
        {

            Console.Write("Digite o Id da Série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {

                Console.WriteLine($"{i}.{Enum.GetName(typeof(Genero), i)}");
                
            }
            Console.Write("Digite o gênero entre as opções escolhidas: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine() ;

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }   

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VizualizarSerie() 
        {

            Console.Write("Digite o Id da Série: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        
        } 

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("Serviço de Gerenciamento de Séries");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpperInvariant();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}