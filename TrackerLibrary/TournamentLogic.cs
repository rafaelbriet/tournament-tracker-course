using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static void UpdateTournamentResults(TournamentModel tournament)
        {
            List<MatchupModel> matchupsToUpdate = new List<MatchupModel>();

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                foreach (MatchupModel matchup in matchups)
                {
                    if (matchup.Winner == null && (matchup.Entries.Any(entry => entry.Score != 0) || matchup.Entries.Count == 1))
                    {
                        matchupsToUpdate.Add(matchup);
                    }
                }
            }

            MarkMatchupWinner(matchupsToUpdate);
            AdvanceWinnersToNextRound(matchupsToUpdate, tournament);

            matchupsToUpdate.ForEach(matchup => GlobalConfig.Connection.UpdateMatchup(matchup));
        }

        private static void AdvanceWinnersToNextRound(List<MatchupModel> matchupsToUpdate, TournamentModel tournament)
        {
            foreach (MatchupModel selectedMatchup in matchupsToUpdate)
            {
                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    foreach (MatchupModel matchup in matchups)
                    {
                        foreach (MatchupEntryModel entry in matchup.Entries)
                        {
                            if (entry.ParentMatchup != null && entry.ParentMatchup.Id == selectedMatchup.Id)
                            {
                                entry.TeamCompeting = selectedMatchup.Winner;
                                GlobalConfig.Connection.UpdateMatchup(matchup);
                            }
                        }
                    }
                } 
            }
        }

        private static void MarkMatchupWinner(List<MatchupModel> matchupsToUpdate)
        {
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel matchup in matchupsToUpdate)
            {
                if (matchup.Entries.Count == 1)
                {
                    matchup.Winner = matchup.Entries[0].TeamCompeting;
                    continue;
                }

                if (greaterWins == "1")
                {
                    if (matchup.Entries[0].Score > matchup.Entries[1].Score)
                    {
                        matchup.Winner = matchup.Entries[0].TeamCompeting;
                    }
                    else if (matchup.Entries[1].Score > matchup.Entries[0].Score)
                    {
                        matchup.Winner = matchup.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("This application does not handle ties");
                    }
                }
                else
                {
                    if (matchup.Entries[0].Score < matchup.Entries[1].Score)
                    {
                        matchup.Winner = matchup.Entries[0].TeamCompeting;
                    }
                    else if (matchup.Entries[1].Score < matchup.Entries[0].Score)
                    {
                        matchup.Winner = matchup.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("This application does not handle ties");
                    }
                }
            }
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
