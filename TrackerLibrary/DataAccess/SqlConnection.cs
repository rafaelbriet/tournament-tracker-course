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
        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("TournamentTracker")))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@firstName", model.FirstName);
                parameters.Add("@lastName", model.LastName);
                parameters.Add("@emailAddress", model.EmailAddress);
                parameters.Add("@cellphoneNumber", model.CellphoneNunber);
                parameters.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", parameters, commandType: CommandType.StoredProcedure);

                model.Id = parameters.Get<int>("@id");

                return model;
            }
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("TournamentTracker")))
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
    }
}
