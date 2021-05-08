using System;
using System.IO;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario) 
                {
                    case "1":

                        Console.Clear();
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
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException(); 
                }

                opcaoUsuario = ObterOpcaoUsuario();
                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        //Inserir Serie
        private static void InserirSerie()
        {
            string separador3 = "----------------------------------------------------------------------------------";

            Console.WriteLine("Inserir Nova Série");
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.SetCursorPosition((Console.WindowWidth - separador3.Length) / 2, Console.CursorTop);
            Console.WriteLine(separador3);
            


            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("[{0}]-[{1}]", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine(separador3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Título da Série");
            Console.ForegroundColor = ConsoleColor.Green;
            string entradaTitulo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Ano de Início da Série: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int entradaAno = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite a Descrição da Série");
            Console.ForegroundColor = ConsoleColor.Green;
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                                    genero: (Genero)entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }


        //Listar Serie
        private static void ListarSeries()
        {
            string titulo = "Listar Séries";
            string separador3 = "----------------------------------------------------------------------------------";

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((Console.WindowWidth - titulo.Length) / 2, Console.CursorTop);
            Console.WriteLine(titulo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth - separador3.Length) / 2, Console.CursorTop);
            Console.WriteLine(separador3);


            var lista = repositorio.Lista();
            string msg1 = ">> Nenhuma série foi cadastrada ainda !!! <<";
            

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((Console.WindowWidth - msg1.Length) / 2, Console.CursorTop);
                Console.WriteLine(msg1);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition((Console.WindowWidth - separador3.Length) / 2, Console.CursorTop);
                Console.WriteLine(separador3);
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                string msg3 = "#ID {0}: - {1} - {2}";
                string msg4 = "*Excluido*";  
               
                Console.SetCursorPosition((Console.WindowWidth - msg3.Length) / 2, Console.CursorTop);
                //Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg3, serie.retornaId(), serie.retornaTitulo(), (excluido ? msg4 : ""));
        
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition((Console.WindowWidth - separador3.Length) / 2, Console.CursorTop);
                Console.WriteLine(separador3);
            }

            Console.ResetColor();
        }



        //Visualizar Serie
        private static void VisualizarSerie()
		{
            string separador3 = "----------------------------";
            string separador4 = "============================";

            Console.WriteLine(separador3);
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(separador4);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(serie);
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(separador4);  

		}



         //Atualizar Serie
        private static void AtualizarSerie()
		{
            string separador3 = "----------------------------";

            Console.WriteLine(separador3);
			Console.Write("Digite o ID da série: ");
            

			int indiceSerie = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(separador3);

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
                Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("[{0}]-[{1}]", i, Enum.GetName(typeof(Genero), i));
			}

			Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(separador3);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Gênero entre as opções acima: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Título da Série");
            Console.ForegroundColor = ConsoleColor.Green;
            string entradaTitulo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Ano de Início da Série: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int entradaAno = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite a Descrição da Série");
            Console.ForegroundColor = ConsoleColor.Green;
            string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.ResetColor();
		}


        //Excluir Serie
        private static void ExcluirSerie()
		{
            string separador3 = "----------------------------";
            Console.WriteLine(separador3);
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Você realmente pretende excluir essa SÉRIE?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pressione [S] para sim e [N] para não.");

            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if(key.Key == ConsoleKey.S){
               repositorio.Exclui(indiceSerie); 
            }
            else if(key.Key == ConsoleKey.N)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Ufa! Pensei que iria excluir.");
                
            }
            else if(key.Key != ConsoleKey.S || key.Key != ConsoleKey.N)
            {
                Console.WriteLine("Pressione [S] para sim e [N] para não.");
            }

            return;
			
		}
        

        //Opção escolhida pelo usuário
         private static string ObterOpcaoUsuario()
		{
            Console.WriteLine();

			string titulo1 = "TON-Séries à sua disposição!!!";
			string titulo2 = "Por favor, informe a opção desejada:";
            string menu1 = "[1]-Listar Séries [2]-Inserir Nova Série [3]-Atualizar Série [4]-Excluir Série";
            string menu2 = "[5]-Visualizar Série [C]-Limpar Tela [X]-Sair";
            string separador1 = "===================================================================";
            string separador2 = "===================================================================";
            string separador3 = "----------------------------------------------------------------------------------";

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition((Console.WindowWidth - separador1.Length) / 2, Console.CursorTop);
            Console.WriteLine(separador1);

            Console.SetCursorPosition((Console.WindowWidth - titulo1.Length) / 2, Console.CursorTop);
            Console.WriteLine(titulo1);

            Console.SetCursorPosition((Console.WindowWidth - titulo2.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(titulo2);

            Console.SetCursorPosition((Console.WindowWidth - separador2.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(separador2);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth - menu1.Length) / 2, Console.CursorTop);
            Console.WriteLine(menu1);
            Console.SetCursorPosition((Console.WindowWidth - separador3.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(separador3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth - menu2.Length) / 2, Console.CursorTop);
            Console.WriteLine(menu2);

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
