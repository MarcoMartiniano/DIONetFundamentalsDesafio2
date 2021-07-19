using System.Collections.Generic;


namespace Projeto2net
{
	public class PokemonRepositorio : IRepositorio<Pokemon>
	{
        private List<Pokemon> listaPokemon = new List<Pokemon>();
		public void Atualiza(int id, Pokemon objeto)
		{
			listaPokemon[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaPokemon[id].Excluir();
		}

		public void Insere(Pokemon objeto)
		{
			listaPokemon.Add(objeto);
		}

		public List<Pokemon> Lista()
		{
			return listaPokemon;
		}

		public int ProximoId()
		{
			return listaPokemon.Count;
		}

		public Pokemon RetornaPorId(int id)
		{
			return listaPokemon[id];
		}
	}
}