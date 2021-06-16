using System.Collections.Generic;
using EplayersMVC.Models;

namespace EPlayersMVC.Interfaces
{
    public interface IJogador
    {
         void Criar(Jogador j);

         List<Jogador> LerTodos();

         void Alterar(Jogador j);

         void Deletar(int Id);
    }
}