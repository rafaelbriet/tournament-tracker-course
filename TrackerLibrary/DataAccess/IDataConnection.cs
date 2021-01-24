using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public interface IDataConnection
    {
        PersonModel CreatePerson(PersonModel model);
        PrizeModel CreatePrize(PrizeModel model);
        TeamModel CreateTeam(TeamModel model);
        TournamentModel CreateTournament(TournamentModel model);
        List<TeamModel> GetTeam_All();
        List<PersonModel> GetPerson_All();
    }
}
