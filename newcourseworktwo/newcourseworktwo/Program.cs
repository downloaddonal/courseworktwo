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
                int intnumberOfCandidates, inthighestVote, inteligibleVoters;
                string strValid, strWinner, strhighestCandidate;
                double dubeligibleVotersPercent, dubtotalVotesPercent, dubwinningPercent, highestVotePercent;

                // Variable candidate amount used to prep the arrays
                Console.WriteLine("Please enter the number of candidates between 1-8: ");
                intnumberOfCandidates = Convert.ToInt32(Console.ReadLine());

                // eligible voters overall
                Console.WriteLine("How many eligible voters overall: ");
                inteligibleVoters = Convert.ToInt32(Console.ReadLine());

                //arrays
                string[] CandidateNames = new string[intnumberOfCandidates];
                int[] CandidateVotes = new int[intnumberOfCandidates];
                double[] candidatePercent = new double[intnumberOfCandidates];

                // inputing data to the arrays 

                int Total = 0;
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    Console.WriteLine("Please enter the name of candidate: ");
                    CandidateNames[i] = Console.ReadLine();
                    Console.WriteLine("How many votes for candidate: ");
                    CandidateVotes[i] = Convert.ToInt32(Console.ReadLine());
                    Total = Total + CandidateVotes[i];
                }

                // doing the percentages for the if statements have to cast the ints as doubles
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    candidatePercent[i] = ((double)CandidateVotes[i] / Total) * 100;
                }
                dubeligibleVotersPercent = (inteligibleVoters / inteligibleVoters) * 60; // determine 60% of eligible for valid/invalid
                dubtotalVotesPercent = ((double)Total / inteligibleVoters) * 100;
                dubwinningPercent = ((double)Total / (double)Total) * 50; // total by total 50% of total votes to determine winner

                // if statement to figure out if election is valid 
                if (dubtotalVotesPercent >= dubeligibleVotersPercent)
                {
                    strValid = "The election was valid";
                    // find out the most vote percent
                    inthighestVote = 0;
                    strhighestCandidate = "";
                    for (int i = 0; i < intnumberOfCandidates; i++)
                    {
                        int currentvote = (int)CandidateVotes[i];
                        // this if statement compares the candidate vote with the highest vote and when it does sets the highest scoring candidate
                        if (CandidateVotes[i] > inthighestVote)
                        {
                            inthighestVote = currentvote;
                            strhighestCandidate = CandidateNames[i];
                        }
                    }
                    // takes the highest vote percent against the winning percent and determines if enough people voted to win
                    highestVotePercent = ((double)inthighestVote / Total) * 100;
                    if (highestVotePercent >= dubwinningPercent)
                    {
                        strWinner = "Enough people voted for " + strhighestCandidate + " to win" + " with " + inthighestVote + " votes";
                    }
                    else
                    {
                        strWinner = "Not enough people voted for a candidate to win";
                    }
                }
                else
                {
                    strValid = "The election was invalid";
                    strWinner = "there was no winner due to invalid election";
                }
                // outputs everything that was set above,for loop to print the results regardless of outcome
                Console.WriteLine("The total amount of votes was " + Total);
                Console.WriteLine(strWinner);
                Console.WriteLine("Candidate" + "\t" + "Votes" + "\t" + " percentage");
                // for loop for the results stored in arrays
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    Console.WriteLine(CandidateNames[i] + "\t\t" + CandidateVotes[i] + "\t\t" + Math.Round(candidatePercent[i], 1) + "%");
                }
                Console.ReadLine();
            }
            catch (FormatException ex) // catch outputting a format error
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Program will now close, press any key to exit");
                Console.ReadKey();
                return;
            }
        }
    }
}
