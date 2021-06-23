using System.Collections.Generic;
using ProjetoMVC.Models;

namespace ProjetoMVC.interfaces
{
    public interface IEquipe
    {
        void Criar(Equipe e);
        List<Equipe> LerTodas();
        void Alterar(Equipe e);
        void Deletar(int id);
    }
}