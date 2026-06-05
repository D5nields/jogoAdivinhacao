using System;

namespace JogoAdivinhacao.Models
{
    public class Node
    {
        public string Text { get; set; }
        public Node? NoChild { get; set; }
        public Node? YesChild { get; set; }

        public Node(string text)
        {
            Text = text;
            NoChild = null;
            YesChild = null;
        }

        public bool IsLeaf()
        {
            return NoChild == null && YesChild == null;
        }
    }
}