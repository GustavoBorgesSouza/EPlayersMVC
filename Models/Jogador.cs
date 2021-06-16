using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Interfaces;

namespace EplayersMVC.Models
{
    public class Jogador : EPlayersBase , IJogador
    {
        public int IdJogador { get; set; }
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        
        private const string CAMINHO = "Database/jogador.csv";

        public Jogador(){
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Jogador j){
            return $"{j.IdJogador};{j.IdEquipe};{j.Nome}";
        }
        public void Criar(Jogador j)
        {
            string[] linha = {Preparar(j)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador = new Jogador();

                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.IdEquipe = Int32.Parse(linha[1]);
                jogador.Nome = linha[2];

                jogadores.Add(jogador);
            }

            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(Preparar(j));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Deletar(int Id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == Id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }
    }
}