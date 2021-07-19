using System;

namespace Projeto2net
{
    class Program
	{
		static PokemonRepositorio repositorio = new PokemonRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarPokemons();
						break;
					case "2":
						InserirPokemon();
						break;
					case "3":
						AtualizarPokemon();
						break;
					case "4":
						ExcluirPokemon();
						break;
					case "5":
						VisualizarPokemon();
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

		
		private static void ExcluirPokemon()
		{
			ListarPokemons();
			Console.Write("Digite o id do Pokemon: ");
			int indicePokemon = int.Parse(Console.ReadLine());

			repositorio.Exclui(indicePokemon);
		}

		private static void VisualizarPokemon()
		{
			ListarPokemons();
			Console.Write("Digite o id do Pokemon: ");
			int indicePokemon = int.Parse(Console.ReadLine());

			var pokemon = repositorio.RetornaPorId(indicePokemon);

			Console.WriteLine(pokemon);
		}
		

		private static void AtualizarPokemon()
		{
			ListarPokemons();
			Console.Write("Digite o id do Pokemon: ");
			int indicePokemon = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Pokemon: ");
			string entradaNome = Console.ReadLine();


			Console.Write("Digite a Descrição do Pokemon: ");
			string entradaDescricao = Console.ReadLine();

			Pokemon atualizaPokemon = new Pokemon(id: indicePokemon,
										tipo: (Tipo)entradaTipo,
										nome: entradaNome,
										descricao: entradaDescricao);
			repositorio.Atualiza(indicePokemon, atualizaPokemon);
		}
		
		private static void InserirPokemon()
		{
			Console.WriteLine("Inserir novo pokemon");

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo entre as opções acima: ");
			int entradaTipo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Pokemon: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a Descrição do Pokemon: ");
			string entradaDescricao = Console.ReadLine();

			Pokemon novoPokemon = new Pokemon(id: repositorio.ProximoId(),
										tipo: (Tipo)entradaTipo,
										nome: entradaNome,
										descricao: entradaDescricao);

			repositorio.Insere(novoPokemon);
		}
		
		private static void ListarPokemons()
		{
			Console.WriteLine("Listar pokemons");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum pokemon cadastrado.");
				return;
			}

			foreach (var pokemon in lista)
			{
				var excluido = pokemon.retornaExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", pokemon.retornaId(), pokemon.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}


		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Pokemon!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar pokemons");
			Console.WriteLine("2- Inserir novo pokemon");
			Console.WriteLine("3- Atualizar pokemon");
			Console.WriteLine("4- Excluir pokemon");
			Console.WriteLine("5- Visualizar pokemon");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}

