using System;
using JogoAdivinhacao.Services;

namespace JogoAdivinhacao
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine game = new GameEngine();
            bool keepPlaying = true;

            Console.WriteLine("=============================================");
            Console.WriteLine("      🌟 JOGO DA ADIVINHAÇÃO (ÁRVORE) 🌟     ");
            Console.WriteLine("=============================================");
            Console.WriteLine("Pense em um animal e responda às perguntas.\n");

            while (keepPlaying)
            {
                game.StartGame();

                Console.WriteLine("\n---------------------------------------------");
                Console.Write("Deseja jogar novamente? (s/n): ");
                string response = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                keepPlaying = (response == "s");
                Console.WriteLine();
            }

            Console.WriteLine("Obrigado por jogar!");
        }
    }
}