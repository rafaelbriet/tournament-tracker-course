using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextProcessing
{
    public static class TextConnectionProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (File.Exists(file) == false)
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                PrizeModel model = new PrizeModel();

                model.Id = int.Parse(collumns[0]);
                model.PlaceNumber = int.Parse(collumns[1]);
                model.PlaceName = collumns[2];
                model.PrizeAmount = decimal.Parse(collumns[3]);
                model.PrizePercentage = double.Parse(collumns[4]);

                output.Add(model);
            }

            return output;
        }

        public static List<PersonModel> ConvertToPersonModel(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                PersonModel model = new PersonModel();

                model.Id = int.Parse(collumns[0]);
                model.FirstName = collumns[1];
                model.LastName = collumns[2];
                model.EmailAddress = collumns[3];
                model.CellphoneNumber = collumns[4];

                output.Add(model);
            }

            return output;
        }

        public static List<TeamModel> ConvertToTeamModel(this List<string> lines, string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModel();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                TeamModel model = new TeamModel();

                model.Id = int.Parse(collumns[0]);
                model.TeamName = collumns[1];

                string[] membersId = collumns[2].Split('|');

                foreach (string id in membersId)
                {
                    model.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }

                output.Add(model);
            }

            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModel(this List<string> lines, string teamsFileName, string peopleFileName, string prizesFileName)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamsFileName.FullFilePath().LoadFile().ConvertToTeamModel(peopleFileName);
            List<PrizeModel> prizes = prizesFileName.FullFilePath().LoadFile().ConvertToPrizeModel();

            // id,tournamentName,entryFee,(Teams: id|id|id),(Prizes: id|id|id),(Rounds: id^id^id|id^id^id|id^id^id)
            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                TournamentModel model = new TournamentModel();

                model.Id = int.Parse(collumns[0]);
                model.TournamentName = collumns[1];
                model.EntryFee = decimal.Parse(collumns[2]);

                string[] teamsId = collumns[3].Split('|');

                foreach (string id in teamsId)
                {
                    model.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                if (collumns[4].Length > 0)
                {
                    string[] prizesId = collumns[4].Split('|');

                    foreach (string id in prizesId)
                    {
                        model.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    }
                }

                // TODO: Rounds information
                string[] rounds = collumns[5].Split('|');

                foreach (string round in rounds)
                {
                    string[] matchupIds = round.Split('^');
                    List<MatchupModel> currentMatchups = new List<MatchupModel>();

                    foreach (string matchupId in matchupIds)
                    {
                        currentMatchups.Add(GetMatchupById(int.Parse(matchupId)));
                    }

                    model.Rounds.Add(currentMatchups);
                }

                output.Add(model);
            }

            return output;
        }

        public static List<MatchupModel> ConvertToMatchupModel(this List<string> lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                MatchupModel model = new MatchupModel();

                model.Id = int.Parse(collumns[0]);
                model.Entries = ConvertStringToMatchupEntryModel(collumns[1]);

                if (int.TryParse(collumns[2], out int teamId))
                {
                    model.Winner = GetTeamById(teamId);
                }
                else
                {
                    model.Winner = null;
                }

               
                model.MatchupRound = int.Parse(collumns[3]);

                output.Add(model);
            }

            return output;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModel(this List<string> lines)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string line in lines)
            {
                string[] collumns = line.Split(',');

                MatchupEntryModel model = new MatchupEntryModel();

                model.Id = int.Parse(collumns[0]);

                if (int.TryParse(collumns[1], out int teamId))
                {
                    model.TeamCompeting = GetTeamById(teamId);
                }
                else
                {
                    model.TeamCompeting = null;
                }

                model.Score = int.Parse(collumns[2]);

                if (int.TryParse(collumns[3], out int parentId))
                {
                    model.ParentMatchup = GetMatchupById(parentId);
                }
                else
                {
                    model.ParentMatchup = null;
                }

                output.Add(model);
            }

            return output;
        }

        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModel(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
            List<string> matchingEtries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] collumns = entry.Split(',');

                    if (collumns[0] == id)
                    {
                        matchingEtries.Add(entry);
                    }
                }
            }

            output = matchingEtries.ConvertToMatchupEntryModel();

            return output;
        }

        private static TeamModel GetTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamsFile.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
                string[] collumns = team.Split(',');

                if (collumns[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModel(GlobalConfig.PeopleFile).First();
                }
            }

            return null;
        }

        private static MatchupModel GetMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();
            
            foreach (string matchup in matchups)
            {
                string[] collumns = matchup.Split(',');

                if (collumns[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchupModel().First();
                }
            }

            return null;
        }

        public static void SavePrizesToFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel prize in models)
            {
                lines.Add($"{prize.Id},{prize.PlaceNumber},{prize.PlaceName},{prize.PrizeAmount},{prize.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SavePeopleToFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel model in models)
            {
                lines.Add($"{model.Id},{model.FirstName},{model.LastName},{model.EmailAddress},{model.CellphoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveTeamsToFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel model in models)
            {
                lines.Add($"{model.Id},{model.TeamName},{ConvertPeopleListToString(model.TeamMembers)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveTournamentsToFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            // id,tournamentName,entryFee,(Teams: id|id|id),(Prizes: id|id|id),(Rounds: id^id^id|id^id^id|id^id^id)
            foreach (TournamentModel model in models)
            {
                lines.Add($"{model.Id},{model.TournamentName},{model.EntryFee},{ConvertTeamListToString(model.EnteredTeams)},{ConvertPrizeListToString(model.Prizes)},{ConvertRoundListToString(model.Rounds)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
                }
            }
        }

        public static void SaveMatchupToFile(this MatchupModel model, string matchupFile, string matchupEntryFile)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(matchup => matchup.Id).First().Id + 1;
            }

            model.Id = currentId;
            matchups.Add(model);

            foreach (MatchupEntryModel entry in model.Entries)
            {
                entry.SaveMatchupEntryToFile(matchupEntryFile);
            }

            List<string> lines = new List<string>();

            foreach (MatchupModel matchup in matchups)
            {
                string winnerId = "";

                if (matchup.Winner != null)
                {
                    winnerId = matchup.Winner.Id.ToString();
                }

                lines.Add($"{matchup.Id},{ConvertMatchupEntryListToString(matchup.Entries)},{winnerId},{matchup.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void SaveMatchupEntryToFile(this MatchupEntryModel model, string matchupEntryFile)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();

            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(entry => entry.Id).First().Id + 1;
            }

            model.Id = currentId;
            entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel entry in entries)
            {
                string parentId = "";

                if (entry.ParentMatchup != null)
                {
                    parentId = entry.ParentMatchup.Id.ToString();
                }

                string teamId = "";

                if (entry.TeamCompeting != null)
                {
                    teamId = entry.TeamCompeting.Id.ToString();
                }

                lines.Add($"{entry.Id},{teamId},{entry.Score},{parentId}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }

        public static void UpdateMatchupFile(this MatchupModel model)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();
            MatchupModel savedMatchup = matchups.First(matchup => matchup.Id == model.Id);

            matchups.Remove(savedMatchup);
            matchups.Add(model);

            foreach (MatchupEntryModel entry in model.Entries)
            {
                entry.UpdateMatchupEntryFile();
            }

            List<string> lines = new List<string>();

            foreach (MatchupModel matchup in matchups)
            {
                string winnerId = "";

                if (matchup.Winner != null)
                {
                    winnerId = matchup.Winner.Id.ToString();
                }

                lines.Add($"{matchup.Id},{ConvertMatchupEntryListToString(matchup.Entries)},{winnerId},{matchup.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void UpdateMatchupEntryFile(this MatchupEntryModel model)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            MatchupEntryModel savedMatchup = entries.First(entry => entry.Id == model.Id);

            entries.Remove(savedMatchup);
            entries.Add(model);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel entry in entries)
            {
                string parentId = "";

                if (entry.ParentMatchup != null)
                {
                    parentId = entry.ParentMatchup.Id.ToString();
                }

                string teamId = "";

                if (entry.TeamCompeting != null)
                {
                    teamId = entry.TeamCompeting.Id.ToString();
                }

                lines.Add($"{entry.Id},{teamId},{entry.Score},{parentId}");
            }

            File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
        }

        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            if (rounds.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (List<MatchupModel> round in rounds)
            {
                output += $"{ConvertMatchupListToString(round)}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
        {
            if (matchups.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (MatchupModel matchup in matchups)
            {
                output += $"{matchup.Id}^";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            if (entries.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (MatchupEntryModel entry in entries)
            {
                output += $"{entry.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            if (prizes.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (PrizeModel prize in prizes)
            {
                output += $"{prize.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertTeamListToString(List<TeamModel> teams)
        {
            if (teams.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (TeamModel team in teams)
            {
                output += $"{team.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            if (people.Count == 0)
            {
                return "";
            }

            string output = "";

            foreach (PersonModel person in people)
            {
                output += $"{person.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
    }
}
