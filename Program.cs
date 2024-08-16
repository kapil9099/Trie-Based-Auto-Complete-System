using System;

namespace TrieAutoComplete
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();

            // Insert words into the Trie
            string[] words = { "apple", "app", "apricot", "banana", "bat", "battle", "cat", "cater", "dog", "dove" };
            foreach (var word in words)
            {
                trie.Insert(word);
            }

            while (true)
            {
                Console.Write("Enter a prefix to autocomplete (or type 'exit' to quit): ");
                string prefix = Console.ReadLine();

                if (prefix.ToLower() == "exit")
                {
                    break;
                }

                var completions = trie.AutoComplete(prefix);

                if (completions.Count > 0)
                {
                    Console.WriteLine("Auto-complete suggestions:");
                    foreach (var completion in completions)
                    {
                        Console.WriteLine(completion);
                    }
                }
                else
                {
                    Console.WriteLine("No suggestions found.");
                }
            }
        }
    }
}
