using System.Collections.Generic;
using ProjetoMVC.Models;

namespace ProjetoMVC.interfaces
{
    public interface INoticia
    {
        void Criar(Noticia n);
        List<Noticia> LerTodas();
        void Alterar(Noticia n);
        void Deletar(int id);
    }
}