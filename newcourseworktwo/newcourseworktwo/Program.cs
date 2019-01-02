using System;

namespace cw2_mk2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Candidate names and votes
            int NumberOfCandidates, highestvote;
            double dubEligibleVoters;
            string valid, winner;
            string HighestCandidate;
            double dubEligibleVoterspercent, dubTotalVotespercent, dubWinningPercent, HighestVotePercent;

            // Variable candidate amount used to prep the arrays
            Console.WriteLine("Please enter the number of candidates between 1-8: ");
            NumberOfCandidates = Convert.ToInt32(Console.ReadLine());

            string[] CandidateNames = new string[NumberOfCandidates];
            double[] CandidateVotes = new double[NumberOfCandidates];

            //eligible voters overall
            Console.WriteLine("How many eligible voters overall: ");
            dubEligibleVoters = Convert.ToDouble(Console.ReadLine());

            // inputing data to the arrays 
            double Total = 0;
            for (int i = 0; i < NumberOfCandidates; i++)
            {
                Console.WriteLine("Please enter the name of candidate: ");
                CandidateNames[i] = Console.ReadLine();
                Console.WriteLine("How many votes for candidate: ");
                CandidateVotes[i] = Convert.ToDouble(Console.ReadLine());
                Total = Total + CandidateVotes[i];
            }

            // doing the percentages for the if statements

            dubEligibleVoterspercent = (dubEligibleVoters / dubEligibleVoters) * 60; // determine 60% of eligible for valid/invalid
            dubTotalVotespercent = (Total / dubEligibleVoters) * 100;
            dubWinningPercent = (Total / Total) * 50; // total by total 50% of total votes to determine winner

            //if statement to figure out if election is valid 
            if (dubTotalVotespercent >= dubEligibleVoterspercent)
            {
                valid = "The election was valid";
                //find out the most vote percent
                highestvote = 0;
                HighestCandidate = "";
                for (int i = 0; i < NumberOfCandidates; i++)
                {
                    int currentvote = (int)CandidateVotes[i];
                    // this if statement compares the candidate vote with the highest vote and when it does sets the highest scoring candidate
                    if (CandidateVotes[i] > highestvote)
                    {
                        highestvote = currentvote;
                        HighestCandidate = CandidateNames[i];
                    }

                }
                // takes the highest vote percent against the winning percent and determines if enough people voted to win
                HighestVotePercent = (highestvote / Total) * 100;
                if (HighestVotePercent >= dubWinningPercent)
                {
                    winner = "Enough people voted for " + HighestCandidate + " to win" + " with " + highestvote + " votes";
                }
                else
                {
                    winner = "Not Enough people voted " + HighestCandidate + " to win";
                }
                Console.WriteLine(valid);
                Console.WriteLine("The total amount of votes was " + Total);
                Console.WriteLine(winner);
                Console.WriteLine("Candidate" + "\t" + "Votes");

                // for loop to output the arrays as a list
                for (int i = 0; i < NumberOfCandidates; i++)
                {
                    Console.WriteLine(CandidateNames[i] + "\t\t" + CandidateVotes[i]);
                }
                Console.ReadLine();
            }
            else
            {
                valid = "The election was invalid";
                winner = "there was no winner due to invalid election";
                Console.WriteLine("The total amount of votes was " + Total);
                Console.WriteLine(valid + "\n" + winner);
                Console.WriteLine("Candidate" + "\t" + "Votes");

                // for loop to output the arrays as a list
                for (int i = 0; i < NumberOfCandidates; i++)
                {
                    Console.WriteLine(CandidateNames[i] + "\t\t" + CandidateVotes[i]);
                }
                Console.ReadLine();
            }

        }

    }
}
