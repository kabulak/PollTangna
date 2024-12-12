using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingSystem
{
    internal class PollManager
    {
        // In-memory list to store polls
        public static List<Poll> Polls = new List<Poll>();

        // Static connection string to access the database
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Justine\Source\Repos\PollTangna\PollingDatabase.mdf;Integrated Security=True";

        // Method to save a poll to the database
        public static void SavePollToDatabase(Poll poll)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Insert the poll question into the Polls table
                string insertPollQuery = "INSERT INTO Polls (PollQuestion) VALUES (@PollQuestion)";
                SqlCommand command = new SqlCommand(insertPollQuery, connection);
                command.Parameters.AddWithValue("@PollQuestion", poll.Question);
                connection.Open();
                command.ExecuteNonQuery();

                // Get the PollID of the newly inserted poll
                string getPollIDQuery = "SELECT IDENT_CURRENT('Polls')";
                SqlCommand getPollIDCommand = new SqlCommand(getPollIDQuery, connection);
                int pollID = Convert.ToInt32(getPollIDCommand.ExecuteScalar());

                // Save the choices to the Choices table
                foreach (var choice in poll.Choices)
                {
                    string insertChoiceQuery = "INSERT INTO Choices (PollID, ChoiceText) VALUES (@PollID, @ChoiceText)";
                    SqlCommand choiceCommand = new SqlCommand(insertChoiceQuery, connection);
                    choiceCommand.Parameters.AddWithValue("@PollID", pollID);
                    choiceCommand.Parameters.AddWithValue("@ChoiceText", choice);
                    choiceCommand.ExecuteNonQuery();
                }
            }
        }

        // Method to load all polls from the database
        public static void LoadPollsFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Load all polls from the Polls table
                string loadPollsQuery = "SELECT PollID, PollQuestion FROM Polls";
                SqlCommand command = new SqlCommand(loadPollsQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string question = reader["PollQuestion"].ToString();
                    int pollID = (int)reader["PollID"];
                    Poll poll = new Poll(question)
                    {
                        PollID = pollID
                    };

                    // Load the choices for each poll from the Choices table
                    string loadChoicesQuery = "SELECT ChoiceText FROM Choices WHERE PollID = @PollID";
                    SqlCommand choiceCommand = new SqlCommand(loadChoicesQuery, connection);
                    choiceCommand.Parameters.AddWithValue("@PollID", pollID);
                    SqlDataReader choiceReader = choiceCommand.ExecuteReader();

                    while (choiceReader.Read())
                    {
                        poll.AddChoice(choiceReader["ChoiceText"].ToString());
                    }

                    // Add the poll to the in-memory list
                    Polls.Add(poll);
                }
            }
        }
    }
}