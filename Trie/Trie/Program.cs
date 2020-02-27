using System;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Enter in a word");
                trie.Insert(Console.ReadLine());
            }

            trie.Contains("hell");
            trie.Contains("he");

            Console.ReadKey();
        }
    }
}
