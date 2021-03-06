﻿using System;
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
        }

        public bool Contains(string word)
        {
            var temp = SearchNode(word);
            if (temp != null && temp.IsWord)
            {
                return true;
            }
            return false;
        }

        private TrieNode SearchNode(string word)
        {
            var children = root.Children;
            for (int i = 0; i < word.Length; i++)
            {
                TrieNode tempTrieNode;
                var letter = word[i];
                if (children.ContainsKey(letter))
                {
                    tempTrieNode = children[letter];
                }
                else
                {
                    return null;
                }
                children = tempTrieNode.Children;
                if (i == word.Length - 1)
                {
                    return tempTrieNode;
                }
            }
            return null;
        }

        private void Words(TrieNode node, List<string> list, string prefix)
        {
            if (node == null)
            {
                return;
            }

            foreach ((char letter, TrieNode trieNode) in node.Children)
            {
                Words(trieNode, list, prefix + trieNode.Letter);
            }

            if (node.IsWord)
            {
                list.Add(prefix);
            }
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            List<string> list = new List<string>();

            var temp = SearchNode(prefix);

            Words(temp, list, prefix);

            return list;
        }

        public List<string> GetAllMatchingPrefixesStack(string prefix)
        {
            string initialPrefix = prefix;
            List<string> list = new List<string>();

            Stack<Tuple<TrieNode, string>> stack = new Stack<Tuple<TrieNode, string>>();

            var node = SearchNode(prefix);
            Tuple<TrieNode, string> varTuple = new Tuple<TrieNode, string>(node, initialPrefix);
            stack.Push(varTuple);

            while (stack.Count > 0)
            {
                foreach ((char letter, TrieNode TrieNode) in node.Children)
                {
                    varTuple = new Tuple<TrieNode, string>(TrieNode, (initialPrefix + letter));
                    stack.Push(varTuple);
                }

                var tuple = stack.Pop();
                node = tuple.Item1;
                var pre = tuple.Item2;
                initialPrefix = pre;


                if (node.IsWord)
                {
                    list.Add(tuple.Item2);
                }
            }

            return list;
        }


        public bool Remove(string prefix)
        {
            var temp = SearchNode(prefix);
            if (temp == null)
            {
                return false;
            }

            temp.IsWord = false;

            return true;
        }
    }
}
