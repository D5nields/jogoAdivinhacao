using System;
using JogoAdivinhacao.Models;

namespace JogoAdivinhacao.Services
{
    public class GameEngine
    {
        public Node Root { get; private set; }

        public GameEngine()
        {
            Node restBranch = new Node("Pombo");

            Node arachnidBranch = new Node("É um aracnídeo?");
            arachnidBranch.NoChild = restBranch;
            arachnidBranch.YesChild = new Node("Aranha");

            Node reptileBranch = new Node("É um réptil?");
            reptileBranch.NoChild = arachnidBranch;
            reptileBranch.YesChild = new Node("Jacaré");

            Node mammalBranch = new Node("O animal vive na água?");
            mammalBranch.NoChild = new Node("Cachorro");
            mammalBranch.YesChild = new Node("Baleia");

            Root = new Node("O animal que você pensou é um mamífero?");
            Root.NoChild = reptileBranch;
            Root.YesChild = mammalBranch;
        }

        public void StartGame()
        {
            Node current = Root;
            Node? parent = null;
            bool wasYesChild = false;

            while (!current.IsLeaf())
            {
                parent = current;
                if (AskQuestion(current.Text))
                {
                    current = current.YesChild ?? throw new InvalidOperationException("NoChild inválido: o nó 'YesChild' não pode ser nulo quando o nó não é folha.");
                    wasYesChild = true;
                }
                else
                {
                    current = current.NoChild ?? throw new InvalidOperationException("NoChild inválido: o nó 'NoChild' não pode ser nulo quando o nó não é folha.");
                    wasYesChild = false;
                }
            }

            if (AskQuestion($"O animal que você pensou é o(a) {current.Text}?"))
            {
                Console.WriteLine("\n Acertei!");
            }
            else
            {
                LearnNewAnimal(parent, current, wasYesChild);
            }
        }

        private bool AskQuestion(string message)
        {
            while (true)
            {
                Console.Write($"{message} (s/n): ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

                if (input == "s") return true;
                if (input == "n") return false;

                Console.WriteLine("Por favor, responda apenas com 's' ou 'n'.");
            }
        }

        private void LearnNewAnimal(Node? parent, Node guessedNode, bool wasYesChild)
        {
            string newAnimal = ReadNonEmptyLine("\nQual foi o animal que você pensou? ");
            string distinction = ReadNonEmptyLine($"O que um(a) {newAnimal} faz, tem ou é que um(a) {guessedNode.Text} não faz/tem/é?\n> ");

            string newQuestion = $"O animal que você pensou {distinction}?";

            Node questionNode = new Node(newQuestion);
            Node newAnimalNode = new Node(newAnimal);

            questionNode.YesChild = newAnimalNode;
            questionNode.NoChild = guessedNode;

            if (parent is null)
            {
                Root = questionNode;
            }
            else if (wasYesChild)
            {
                parent.YesChild = questionNode;
            }
            else
            {
                parent.NoChild = questionNode;
            }

            Console.WriteLine("Obrigado! Esse animal foi categorizado e memorizado com sucesso.\n");
        }

        private static string ReadNonEmptyLine(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }

                Console.WriteLine("Por favor, informe um valor não vazio.");
            }
        }
    }
}