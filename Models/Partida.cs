using System;

namespace EplayersMVC.Models
{
    public class Partida
    {
        public int IdParitda { get; set; }
        public int IdJogador1 { get; set; }
        public int IdJogador2 { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
    }
}