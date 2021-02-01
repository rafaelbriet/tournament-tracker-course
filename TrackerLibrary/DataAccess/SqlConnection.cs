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

        public void CreatePerson(PersonModel model)
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
            }
        }

        public void CreatePrize(PrizeModel model)
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
            }
        }

        public void CreateTeam(TeamModel model)
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
            }
        }

        public void CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                SaveTournament(connection, model);
                SaveTournamentPrize(connection, model);
                SaveTournamentEntris(connection, model);
                SaveTournamentRounds(connection, model);
            }
        }

        private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("@tournamentId", model.Id);
                    parameters.Add("@matchupRound", matchup.MatchupRound);
                    parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spMatchups_Insert", parameters, commandType: CommandType.StoredProcedure);

                    matchup.Id = parameters.Get<int>("@id");

                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                        parameters = new DynamicParameters();

                        parameters.Add("@matchupId", matchup.Id);

                        if (entry.ParentMatchup == null)
                        {
                            parameters.Add("@parentMatchupId", null);
                        }
                        else
                        {
                            parameters.Add("@parentMatchupId", entry.ParentMatchup.Id);
                        }

                        if (entry.TeamCompeting == null)
                        {
                            parameters.Add("@teamCompetingId", null);
                        }
                        else
                        {
                            parameters.Add("@teamCompetingId", entry.TeamCompeting.Id);
                        }

                        parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spMatchupEntries_Insert", parameters, commandType: CommandType.StoredProcedure);

                        entry.Id = parameters.Get<int>("@id");
                    }
                }
            }
        }

        private void SaveTournament(IDbConnection connection, TournamentModel model)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@tournamentName", model.TournamentName);
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

        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db))) 
            {
                output = connection.Query<TournamentModel>("dbo.spTournament_GetAll").ToList();

                foreach (TournamentModel tournament in output)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@tournamentId", tournament.Id);

                    tournament.Prizes = connection.Query<PrizeModel>("dbo.spPrizes_GetByTournament", parameters, commandType: CommandType.StoredProcedure).ToList();
                    tournament.EnteredTeams = connection.Query<TeamModel>("dbo.spTeam_GetByTournament", parameters, commandType: CommandType.StoredProcedure).ToList();

                    foreach (TeamModel team in tournament.EnteredTeams)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("@teamId", team.Id);

                        team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam", parameters, commandType: CommandType.StoredProcedure).ToList();
                    }

                    parameters = new DynamicParameters();
                    parameters.Add("@tournamentId", tournament.Id);

                    List<MatchupModel> matchups = connection.Query<MatchupModel>("dbo.spMatchups_GetByTournament", parameters, commandType: CommandType.StoredProcedure).ToList();
                    List<TeamModel> teams = GetTeam_All();

                    foreach (MatchupModel matchup in matchups)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("@matchupId", matchup.Id);

                        matchup.Entries = connection.Query<MatchupEntryModel>("dbo.spMatchupsEntries_GetByMatchup", parameters, commandType: CommandType.StoredProcedure).ToList();

                        if (matchup.WinnerId > 0)
                        {
                            matchup.Winner = teams.First(team => team.Id == matchup.WinnerId);
                        }

                        foreach (MatchupEntryModel matchupEntry in matchup.Entries)
                        {
                            if (matchupEntry.TeamCompetingId > 0)
                            {
                                matchupEntry.TeamCompeting = teams.First(team => team.Id == matchupEntry.TeamCompetingId);
                            }

                            if (matchupEntry.ParentMatchupId > 0)
                            {
                                matchupEntry.ParentMatchup = matchups.First(m => m.Id == matchupEntry.ParentMatchupId);
                            }
                        }
                    }

                    List<MatchupModel> currentRoundMatchups = new List<MatchupModel>();
                    int currentRound = 1;

                    foreach (MatchupModel matchup in matchups)
                    {
                        if (matchup.MatchupRound > currentRound)
                        {
                            tournament.Rounds.Add(currentRoundMatchups);

                            currentRoundMatchups = new List<MatchupModel>();

                            currentRound++;
                        }

                        currentRoundMatchups.Add(matchup);
                    }

                    tournament.Rounds.Add(currentRoundMatchups);
                }
            }

            return output;
        }

        public void UpdateMatchup(MatchupModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                DynamicParameters parameters = new DynamicParameters();

                if (model.Winner != null)
                {
                    parameters.Add("@id", model.Id);
                    parameters.Add("@winnerId", model.Winner.Id);

                    connection.Execute("dbo.spMatchups_Update", parameters, commandType: CommandType.StoredProcedure); 
                }

                foreach (MatchupEntryModel entry in model.Entries)
                {
                    if (entry.TeamCompeting != null)
                    {
                        parameters = new DynamicParameters();

                        parameters.Add("@id", entry.Id);
                        parameters.Add("@teamCompetingId", entry.TeamCompeting.Id);
                        parameters.Add("@score", entry.Score);

                        connection.Execute("dbo.spMatchupEntries_Update", parameters, commandType: CommandType.StoredProcedure); 
                    }
                }
            }
        }
    }
}
