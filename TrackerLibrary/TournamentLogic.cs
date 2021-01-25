using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel tournament)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamList(tournament.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = FindNunberOfByes(rounds, randomizedTeams.Count);

            tournament.Rounds.Add(CreateFirstRound(randomizedTeams, byes));
            CreateOtherRounds(tournament, rounds);
        }

        private static void CreateOtherRounds(TournamentModel tournament, int numberOfRounds)
        {
            int currentRoundNumber = 2;
            List<MatchupModel> previousRound = tournament.Rounds[0];
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMathchup = new MatchupModel();

            while (currentRoundNumber <= numberOfRounds)
            {
                foreach (MatchupModel matchup in previousRound)
                {
                    MatchupEntryModel matchupEntry = new MatchupEntryModel() { ParentMatchup = matchup };
                    currentMathchup.Entries.Add(matchupEntry);

                    if (currentMathchup.Entries.Count > 1)
                    {
                        currentMathchup.MatchupRound = currentRoundNumber;
                        currentRound.Add(currentMathchup);
                        currentMathchup = new MatchupModel();
                    }
                }

                tournament.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound = new List<MatchupModel>();
                currentRoundNumber++;
            }
        }

        private static List<MatchupModel> CreateFirstRound(List<TeamModel> teams, int numberOfByes)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel currentMathchup = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                MatchupEntryModel matchupEntry = new MatchupEntryModel() { TeamCompeting = team };
                currentMathchup.Entries.Add(matchupEntry);

                if (numberOfByes > 0 || currentMathchup.Entries.Count > 1)
                {
                    currentMathchup.MatchupRound = 1;
                    output.Add(currentMathchup);

                    currentMathchup = new MatchupModel();

                    if (numberOfByes > 0)
                    {
                        numberOfByes--;
                    }
                }
            }

            return output;
        }

        private static int FindNunberOfByes(int numberOfRounds, int numberOfTeams)
        {
            int totalTeams = 1;

            for (int i = 1; i <= numberOfRounds; i++)
            {
                totalTeams *= 2;
            }

            return totalTeams - numberOfTeams;
        }

        private static int FindNumberOfRounds(int numberOfTeams)
        {
            int output = 1;
            int val = 2;

            while (val < numberOfTeams)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomizeTeamList(List<TeamModel> teams)
        {
            // Randomize a List<T> - Stack Overflow
            // https://stackoverflow.com/questions/273313/randomize-a-listt

            List<TeamModel> output = new List<TeamModel>(teams);
            Random random = new Random();

            int count = output.Count;

            while (count > 1)
            {
                count--;

                int randomIndex = random.Next(count + 1);

                TeamModel temp = output[randomIndex];

                output[randomIndex] = output[count];
                output[count] = temp;
            }

            return output;
        }
    }
}
