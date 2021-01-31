using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        public int Id { get; set; }
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        public int WinnerId { get; set; }
        public TeamModel Winner { get; set; }
        public int MatchupRound { get; set; }
        public string DisplayName
        {
            get
            {
                string output = "";

                foreach (MatchupEntryModel entry in Entries)
                {
                    if (output.Length == 0)
                    {
                        if (entry.TeamCompeting == null)
                        {
                            output = "Not yet detemined";
                        }
                        else
                        {
                            output = entry.TeamCompeting.TeamName;
                        }
                    }
                    else
                    {
                        if (entry.TeamCompeting == null)
                        {
                            output += " vs Not yet detemined";
                        }
                        else
                        {
                            output += " vs " + entry.TeamCompeting.TeamName;
                        }
                    }
                }

                return output;
            }
        }
    }
}
