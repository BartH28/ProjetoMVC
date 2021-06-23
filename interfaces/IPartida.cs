using System.Collections.Generic;
using ProjetoMVC.Models;

namespace ProjetoMVC.interfaces
{
    public interface IPartida
    {
        void Criar(Partida e);
        List<Partida> LerTodas();
        void Alterar(Partida e);
        void Deletar(int id);
    }
}