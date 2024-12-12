using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem
{
    internal class Poll
    {
        // Add PollID property to represent the unique identifier for the poll
        public int PollID { get; set; }  // This will hold the PollID assigned by the database
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public Dictionary<string, int> Votes { get; set; }

        // Constructor
        public Poll(string question)
        {
            Question = question;
            Choices = new List<string>();
            Votes = new Dictionary<string, int>();
        }

        // Add a choice to the poll and initialize the vote count for that choice
        public void AddChoice(string choice)
        {
            if (!Choices.Contains(choice))
            {
                Choices.Add(choice);
                Votes[choice] = 0;  // Initialize the vote count for the new choice
            }
        }

        // Register a vote for a specific choice
        public void Vote(string choice)
        {
            if (Votes.ContainsKey(choice))
            {
                Votes[choice]++;
            }
        }

        // Reset all votes for this poll
        public void ResetVotes()
        {
            foreach (var choice in Choices)
            {
                Votes[choice] = 0;  // Reset all votes to 0
            }
        }

        // Get the current results for this poll
        public string GetResults()
        {
            string results = "Results:\n";
            foreach (var vote in Votes)
            {
                results += $"{vote.Key}: {vote.Value} votes\n";
            }
            return results;
        }

        // Optionally, you can add other helper methods, such as getting the winner
        public string GetWinner()
        {
            var maxVotes = Votes.Values.Max();
            var winner = Votes.FirstOrDefault(x => x.Value == maxVotes).Key;
            return winner ?? "No votes yet";
        }
    }
}