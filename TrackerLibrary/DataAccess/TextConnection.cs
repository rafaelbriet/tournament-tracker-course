using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess.TextProcessing;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnection : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamsFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(person => person.Id).First().Id + 1;
            }

            model.Id = currentId;

            people.Add(model);
            people.SavePeopleToFile(PeopleFile);

            return model;
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(prize => prize.Id).First().Id + 1;
            }

            model.Id = currentId;

            prizes.Add(model);
            prizes.SavePrizesToFile(PrizesFile);

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);

            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(prize => prize.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);
            teams.SaveTeamsToFile(TeamsFile);

            return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel(TeamsFile, PeopleFile, PrizesFile);

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(prize => prize.Id).First().Id + 1;
            }

            model.Id = currentId;

            tournaments.Add(model);
            tournaments.SaveTournamentsToFile(TournamentFile);

            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamsFile.FullFilePath().LoadFile().ConvertToTeamModel(PeopleFile);
        }
    }
}
