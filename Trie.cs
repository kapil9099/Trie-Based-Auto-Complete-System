using System;
using System.Collections.Generic;
using System.Text;

namespace TrieAutoComplete
{
    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        public List<string> AutoComplete(string prefix)
        {
            var results = new List<string>();
            var node = _root;

            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return results; // No words with this prefix
                }
                node = node.Children[ch];
            }

            FindWords(node, prefix, results);
            return results;
        }

        private void FindWords(TrieNode node, string prefix, List<string> results)
        {
            if (node.IsEndOfWord)
            {
                results.Add(prefix);
            }

            foreach (var child in node.Children)
            {
                FindWords(child.Value, prefix + child.Key, results);
            }
        }
    }
}
