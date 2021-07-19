using System;

namespace Projeto2net
{
    public class Pokemon : EntidadeBase
    {
        // Atributos
		private Tipo Tipo { get; set; }
		private string Nome { get; set; }
		private string Descricao { get; set; }

        private bool Excluido {get; set;}

        // Métodos
		public Pokemon(int id, Tipo tipo, string nome, string descricao)
		{
			this.Id = id;
			this.Tipo = tipo;
			this.Nome = nome;
			this.Descricao = descricao;
            this.Excluido = false;
		}

        public override string ToString()
		{
		
            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}


        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}