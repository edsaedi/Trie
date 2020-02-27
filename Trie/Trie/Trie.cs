using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{
    internal class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool IsWord { get; set; }

        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            Clear();
        }

        public void Clear()
        {
            root = new TrieNode('$');
        }

        public void Insert(string word)
        {
            if (Contains(word))
            {
                return;
            }
            var children = root.Children;
            for (int i = 0; i < word.Length; i++)
            {
                var letter = word[i];
                TrieNode tempTrieNode;

                if (children.ContainsKey(letter))
                {
                    tempTrieNode = children[letter];
                }
                else
                {
                    tempTrieNode = new TrieNode(letter);
                    children.Add(letter, tempTrieNode);
                }

                children = tempTrieNode.Children;

                if (i == word.Length - 1)
                {
                    tempTrieNode.IsWord = true;
                }
            }
            //Make sure to do isword
        }

        public bool Contains(string word)
        {
            var children = root.Children;
            for (int i = 0; i < word.Length; i++)
            {
                var letter = word[i];
                TrieNode tempTrieNode;
                if (children.ContainsKey(letter))
                {
                    tempTrieNode = children[letter];
                }
                else
                {
                    return false;
                }
                if (i == word.Length - 1 && tempTrieNode.IsWord)
                {
                    return true;
                }
            }
            return false;
        }

        private TrieNode SearchNode(string word)
        {
            return null;
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            return null;
        }

        public bool Remove(string prefix)
        {
            return false;
        }
    }
}
