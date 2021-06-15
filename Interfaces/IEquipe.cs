using System.Collections.Generic;
using EplayersMVC.Models;

namespace EplayersMVC.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe e);

         List<Equipe> LerTodas();

         void Alterar(Equipe e);

         void Deleter(int Id);
    }
}