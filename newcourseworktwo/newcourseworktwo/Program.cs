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
                string strValid, strResult, strhighestCandidate;
                double dubeligibleVotersPercent, dubtotalVotesPercent, dubwinningPercent, dubhighestVotePercent;

                // Variable candidate amount used to prep the arrays
                Console.WriteLine("Please enter the number of candidates between 1-8: ");
                intnumberOfCandidates = Convert.ToInt32(Console.ReadLine());

                // eligible voters overall
                Console.WriteLine("How many eligible voters overall: ");
                inteligibleVoters = Convert.ToInt32(Console.ReadLine());

                //arrays
                string[] candidateNames = new string[intnumberOfCandidates];
                int[] candidateVotes = new int[intnumberOfCandidates];
                double[] candidatePercent = new double[intnumberOfCandidates];

                // inputing data to the arrays 

                int Total = 0;
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    Console.WriteLine("Please enter the name of candidate: ");
                    candidateNames[i] = Console.ReadLine();
                    Console.WriteLine("How many votes for candidate: ");
                    candidateVotes[i] = Convert.ToInt32(Console.ReadLine());
                    Total = Total + candidateVotes[i];
                }

                // doing the percentages for the if statements have to cast the ints as doubles
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    candidatePercent[i] = (double)candidateVotes[i] / Total * 100;
                }
                dubeligibleVotersPercent = inteligibleVoters / inteligibleVoters * 60; // determine 60% of eligible for valid/invalid
                dubtotalVotesPercent = (double)Total / inteligibleVoters * 100;
                dubwinningPercent = Total / Total * 50; // total by total 50% of total votes to determine winner

                // if statement to figure out if election is valid 
                if (dubtotalVotesPercent >= dubeligibleVotersPercent)
                {
                    strValid = "The election was valid due to having " + Math.Round(dubeligibleVotersPercent, 1) + "%";
                    // find out the most vote percent
                    inthighestVote = 0;
                    strhighestCandidate = "";
                    for (int i = 0; i < intnumberOfCandidates; i++)
                    {
                        int currentvote = (int)candidateVotes[i];
                        // this if statement compares the candidate vote with the highest vote and when it does sets the highest scoring candidate
                        if (candidateVotes[i] > inthighestVote)
                        {
                            inthighestVote = currentvote;
                            strhighestCandidate = candidateNames[i];
                        }
                    }
                    // takes the highest vote percent against the winning percent and determines if enough people voted to win
                    dubhighestVotePercent = (double)inthighestVote / Total * 100;
                    if (dubhighestVotePercent >= dubwinningPercent)
                    {
                        strResult = "Enough people voted for " + strhighestCandidate + " to win" + " with " + inthighestVote + " votes";
                    }
                    else
                    {
                        strResult = "Not enough people voted for a candidate to win";
                    }
                }
                else
                {
                    strValid = "The election was invalid due to having " + Math.Round(dubeligibleVotersPercent, 1) + "%";
                    strResult = "there was no winner due to invalid election";
                }
                // outputs everything that was set above,for loop to print the results regardless of outcome
                Console.WriteLine("The total amount of votes was " + Total + " with " + inteligibleVoters + " eligible voters");
                Console.WriteLine(strValid);
                Console.WriteLine(strResult);
                Console.WriteLine("Candidate" + "\t" + "Votes" + "\t" + " percentage");
                // for loop for the results stored in arrays
                for (int i = 0; i < intnumberOfCandidates; i++)
                {
                    Console.WriteLine(candidateNames[i] + "\t\t" + candidateVotes [i] + "\t\t" + Math.Round(candidatePercent[i], 1) + "%");
                }
                Console.ReadLine();
            }
            catch (FormatException ex) // catch outputting a format error
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Program will now close, press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
