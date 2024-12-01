using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem
{
    internal class Poll
    {

        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public Dictionary<string, int> Votes { get; set; }

        public Poll(string question)
        {
            Question = question;
            Choices = new List<string>();
            Votes = new Dictionary<string, int>();
        }

        public void AddChoice(string choice)
        {
            if (!Choices.Contains(choice))
            {
                Choices.Add(choice);
                Votes[choice] = 0;
            }
        }

        public void Vote(string choice)
        {
            if (Votes.ContainsKey(choice))
            {
                Votes[choice]++;
            }
        }

        public void ResetVotes()
        {
            foreach (var choice in Choices)
            {
                Votes[choice] = 0;  // Reset all votes to 0
            }
        }

        public string GetResults()
        {
            string results = "Results:\n";
            foreach (var vote in Votes)
            {
                results += $"{vote.Key}: {vote.Value} votes\n";
            }
            return results;
        }
    }
}