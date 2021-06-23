using System;
using System.Collections.Generic;
using System.IO;
using ProjetoMVC.interfaces;

namespace ProjetoMVC.Models
{
    public class Jogador : Eplayersbase , IJogador 
    {
        public int Idjogador { get; set; }
        public string Nome { get; set; }
        public int idequipe { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }

        private const string CAMINHO = "Database/jogador.csv";
        
        public Jogador(){
            CriarPastadeArquivo(CAMINHO);
        }

        private string Preparar(Jogador j){
            return $"{j.Idjogador};{j.Nome};{j.idequipe};{j.Email};{j.Senha};";
        }
        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.Idjogador.ToString());
            linhas.Add(Preparar(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Jogador j)
        {
            string[] linha = {Preparar(j)};
            File.AppendAllLines(CAMINHO, linha);
        }


        public List<Jogador> LerTodos()
        {
            List<Jogador> players = new List<Jogador>();

            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jojo = new Jogador();

                jojo.Idjogador = Int32.Parse(linha[0]);
                jojo.Nome = linha[1];
                jojo.idequipe = Int32.Parse(linha[2]);
                jojo.Email = linha[3];
                jojo.Senha = linha[4];

                players.Add(jojo);
                
            }
            return players;
        }

        public void Delerar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }
    }

    
    
}