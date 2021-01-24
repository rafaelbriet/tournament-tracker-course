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

                string[] prizesId = collumns[4].Split('|');

                foreach (string id in prizesId)
                {
                    model.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // TODO: Rounds information

                output.Add(model);
            }

            return output;
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
                lines.Add($@"{model.Id},
                    {model.TournamentName},
                    {model.EntryFee},
                    {ConvertTeamListToString(model.EnteredTeams)},
                    {ConvertPrizeListToString(model.Prizes)},
                    {ConvertRoundListToString(model.Rounds)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
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
