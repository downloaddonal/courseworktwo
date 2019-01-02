using System;

namespace cw2_mk2
{
    class Program
    {
        static void Main(string[] args)
        {
            try // try catch around the entire program to save having multiples at every point
            {
                // Candidate names and votes
                int numberOfCandidates, highestVote;
                double dubeligibleVoters;
                string Valid, Winner, highestCandidate;
                double dubeligibleVotersPercent, dubtotalVotesPercent, dubwinningPercent, highestVotePercent;

                // Variable candidate amount used to prep the arrays
                Console.WriteLine("Please enter the number of candidates between 1-8: ");
                numberOfCandidates = Convert.ToInt32(Console.ReadLine());

                string[] CandidateNames = new string[numberOfCandidates];
                int[] CandidateVotes = new int[numberOfCandidates];
                double[] candidatePercent = new double[numberOfCandidates];

                // eligible voters overall
                Console.WriteLine("How many eligible voters overall: ");
                dubeligibleVoters = Convert.ToDouble(Console.ReadLine());

                // inputing data to the arrays 

                int Total = 0;
                for (int i = 0; i < numberOfCandidates; i++)
                {
                    Console.WriteLine("Please enter the name of candidate: ");
                    CandidateNames[i] = Console.ReadLine();
                    Console.WriteLine("How many votes for candidate: ");
                    CandidateVotes[i] = Convert.ToInt32(Console.ReadLine());
                    Total = Total + CandidateVotes[i];
                }


                // doing the percentages for the if statements
                for (int i = 0; i < numberOfCandidates; i++)
                {
                    candidatePercent[i] = (CandidateVotes[i] / Total) * 100;
                }
                dubeligibleVotersPercent = (dubeligibleVoters / dubeligibleVoters) * 60; // determine 60% of eligible for valid/invalid
                dubtotalVotesPercent = (Total / dubeligibleVoters) * 100;
                dubwinningPercent = (Total / Total) * 50; // total by total 50% of total votes to determine winner

                // if statement to figure out if election is valid 
                if (dubtotalVotesPercent >= dubeligibleVotersPercent)
                {
                    Valid = "The election was valid";
                    // find out the most vote percent
                    highestVote = 0;
                    highestCandidate = "";
                    for (int i = 0; i < numberOfCandidates; i++)
                    {
                        int currentvote = (int)CandidateVotes[i];
                        // this if statement compares the candidate vote with the highest vote and when it does sets the highest scoring candidate
                        if (CandidateVotes[i] > highestVote)
                        {
                            highestVote = currentvote;
                            highestCandidate = CandidateNames[i];
                        }

                    }
                    // takes the highest vote percent against the winning percent and determines if enough people voted to win
                    highestVotePercent = (highestVote / Total) * 100;
                    if (highestVotePercent >= dubwinningPercent)
                    {
                        Winner = "Enough people voted for " + highestCandidate + " to win" + " with " + highestVote + " votes";
                    }
                    else
                    {
                        Winner = "Not Enough people voted " + highestCandidate + " to win";
                    }
                    Console.WriteLine(Valid);
                    Console.WriteLine("The total amount of votes was " + Total);
                    Console.WriteLine(Winner);
                    Console.WriteLine("Candidate" + "\t" + "Votes" + "\t" + " percentage");

                    // for loop to output the arrays as a list
                    for (int i = 0; i < numberOfCandidates; i++)
                    {
                        Console.WriteLine(CandidateNames[i] + "\t\t" + CandidateVotes[i] +"\t\t" + Math.Round(candidatePercent[i], 0) + "%");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Valid = "The election was invalid";
                    Winner = "there was no winner due to invalid election";
                    Console.WriteLine("The total amount of votes was " + Total);
                    Console.WriteLine(Valid + "\n" + Winner);
                    Console.WriteLine("Candidate" + "\t" + "Votes" + "\t" + " percentage");

                    // for loop to output the arrays as a list
                    for (int i = 0; i < numberOfCandidates; i++)
                    {
                        Console.WriteLine(CandidateNames[i] + "\t\t" + CandidateVotes[i] +"\t\t" + Math.Round(candidatePercent[i], 0) + "%");
                    }
                    Console.ReadLine();
                }
            }
            catch (FormatException ex) // catch outputting a format error
            {
                Console.WriteLine(ex.Message + " Please enter a number");
                Console.WriteLine("Program will now close, press any key to exit");
                Console.ReadKey();
                return;
            }
        }
    }
}
