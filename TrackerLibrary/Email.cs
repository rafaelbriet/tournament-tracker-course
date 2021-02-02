using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class Email
    {
        public static void Send(string toAddress, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["senderEmail"], ConfigurationManager.AppSettings["senderEmailDisplayName"]);

            MailMessage mail = new MailMessage();

            mail.From = fromAddress;
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Send(mail);
        }

        public static void AlertNewRound(this TournamentModel tournament)
        {
            int currentRound = tournament.GetCurrentRoundNumber();
            List<MatchupModel> currentRoundMatchups = tournament.Rounds.First(matchups => matchups.First().MatchupRound == currentRound);

            foreach (MatchupModel matchup in currentRoundMatchups)
            {
                foreach (MatchupEntryModel entry in matchup.Entries)
                {
                    foreach (PersonModel person in entry.TeamCompeting.TeamMembers)
                    {
                        AlertPersonNewRound(person, entry.TeamCompeting.TeamName, matchup.Entries.FirstOrDefault(x => x.TeamCompeting != entry.TeamCompeting));
                    }
                }
            }
        }

        private static void AlertPersonNewRound(PersonModel person, string teamName, MatchupEntryModel competitor)
        {
            if (person.EmailAddress.Length == 0)
            {
                return;
            }

            string subject = "";
            StringBuilder body = new StringBuilder();

            if (competitor != null)
            {
                subject = $"{teamName} have a new matchup with {competitor.TeamCompeting.TeamName}";

                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Have a greate time!");
                body.AppendLine("Tournament Tracker");
            }
            else
            {
                subject = $"{teamName} have a bye round!";

                body.AppendLine("Enjoy your round off");
                body.AppendLine("Tournament Tracker");
            }

            Send(person.EmailAddress, subject, body.ToString());
        }
    }
}
