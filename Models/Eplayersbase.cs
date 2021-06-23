using System.Collections.Generic;
using System.IO;

namespace ProjetoMVC.Models
{
    public class Eplayersbase
    {
        public void CriarPastadeArquivo(string _Caminho){
            
            string pasta = _Caminho.Split("/")[0];
            string arquivo = _Caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_Caminho))
            {
                File.Create(_Caminho).Close();
            }
        }

        public List<string> LerTodasLinhasCSV(string _Caminho){
            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(_Caminho))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void ReescreverCSV(string _Caminho, List<string> linhas) {
            using (StreamWriter output = new StreamWriter(_Caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}