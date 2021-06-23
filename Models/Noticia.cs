using System;
using System.Collections.Generic;
using System.IO;
using ProjetoMVC.interfaces;

namespace ProjetoMVC.Models
{
    public class Noticia : Eplayersbase, INoticia
    {
        public int Idnoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string CAMINHO = "Database/euipe.csv";

        public Noticia()
        {
            CriarPastadeArquivo(CAMINHO);
        }

        private string Preparar(Noticia n)
        {
            return $"{n.Idnoticia};{n.Titulo};{n.Texto};{n.Imagem};";
        }

        public void Alterar(Noticia n)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == n.Idnoticia.ToString());
            linhas.Add(Preparar(n));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Noticia n)
        {
            string[] linha = { Preparar(n) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Noticia> LerTodas()
        {
            List<Noticia> not = new List<Noticia>();

            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia N = new Noticia();

                N.Idnoticia = Int32.Parse(linha[0]);
                N.Titulo = linha[1];
                N.Texto = linha[2];
                N.Imagem = linha[3];

                not.Add(N);

            }
            return not;

        }
    }
}