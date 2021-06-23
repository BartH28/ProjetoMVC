using System;
using System.Collections.Generic;
using System.IO;
using ProjetoMVC.interfaces;

namespace ProjetoMVC.Models
{
    public class Partida : Eplayersbase, IPartida
    {
        public int idpartida { get; set; }
        public int idjogador1 { get; set; }
        public int idjogador2 { get; set; }
        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioTermino { get; set; }

        private const string CAMINHO = "Database/partida.csv";


        public Partida()
        {
            CriarPastadeArquivo(CAMINHO);
        }

        private string Preparar(Partida p)
        {
            return $"{p.idpartida};{p.idjogador1};{p.idjogador2};{p.HorarioInicio};{p.HorarioTermino};";
        }

        public void Alterar(Partida p)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == p.idpartida.ToString());
            linhas.Add(Preparar(p));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Partida p)
        {
            string[] linha = { Preparar(p) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Partida> LerTodas()
        {
            List<Partida> Part = new List<Partida>();

            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Partida pa = new Partida();

                pa.idpartida = Int32.Parse(linha[0]);
                pa.idjogador1 = Int32.Parse(linha[1]);
                pa.idjogador2 = Int32.Parse(linha[2]);
                

                Part.Add(pa);
            
            }
            return Part;
        }
    }
}