using System.Collections.Generic;
using ProjetoMVC.Models;

namespace ProjetoMVC.interfaces
{
    public interface IJogador
    {
        void Criar(Jogador j);
        List<Jogador> LerTodos();
        void Alterar(Jogador j);
        void Delerar(int id);
    }
}