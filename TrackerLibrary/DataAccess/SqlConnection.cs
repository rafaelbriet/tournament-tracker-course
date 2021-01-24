using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnection : IDataConnection
    {
        private const string db = "TournamentTracker";

        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@firstName", model.FirstName);
                parameters.Add("@lastName", model.LastName);
                parameters.Add("@emailAddress", model.EmailAddress);
                parameters.Add("@cellphoneNumber", model.CellphoneNumber);
                parameters.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");

                return model;
            }
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@placeNumber", model.PlaceNumber);
                parameters.Add("@placeName", model.PlaceName);
                parameters.Add("@prizeAmount", model.PrizeAmount);
                parameters.Add("@prizePercentage", model.PrizePercentage);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");

                return model;
            }
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@teamName", model.TeamName);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");

                foreach (PersonModel person in model.TeamMembers)
                {
                    parameters = new DynamicParameters();

                    parameters.Add("@teamId", model.Id);
                    parameters.Add("@personId", person.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", parameters, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                SaveTournament(connection, model);
                SaveTournamentPrize(connection, model);
                SaveTournamentEntris(connection, model);

                return model;
            }
        }

        private void SaveTournament(IDbConnection connection, TournamentModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@tournamntName", model.TournamentName);
            parameters.Add("@entryFee", model.EntryFee);
            parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", parameters, commandType: CommandType.StoredProcedure);

            model.Id = parameters.Get<int>("@id");
        }

        private void SaveTournamentPrize(IDbConnection connection, TournamentModel model)
        {
            foreach (PrizeModel prize in model.Prizes)
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@tournamentId", model.Id);
                parameters.Add("@prizeId", prize.Id);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentEntris(IDbConnection connection, TournamentModel model)
        {
            foreach (TeamModel team in model.EnteredTeams)
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@tournamentId", model.Id);
                parameters.Add("@teamId", team.Id);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentEntries_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }
            
            return output;
        }

        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output)
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@teamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return output;
        }
    }
}
