using System;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine("Enter in a word");
            //    trie.Insert(Console.ReadLine());
            //}

            trie.Insert("baby");
            trie.Insert("babe");
            trie.Insert("he");
            trie.Insert("hey");
            trie.Insert("hell");
            trie.Insert("hello");
            trie.Insert("heaven");
            trie.Insert("havana");


            foreach (var word in trie.GetAllMatchingPrefix("h"))
            {
                Console.WriteLine(word);
            }


            //Console.WriteLine(trie.Contains("hell"));
            //Console.WriteLine(trie.Contains("has"));

            //Console.WriteLine(trie.Remove("hell"));
            //Console.WriteLine(trie.Remove("has"));

            Console.ReadKey();
        }
    }
}
