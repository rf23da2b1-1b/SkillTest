using swimmingTeam.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.services
{
    public class TeamRepository
    {
        // instans felter 

        // aggregering
        private List<Team> _teams;

        public TeamRepository()
        {
            _teams = new List<Team>();
        }

        /*
         * metoder fra DCD
         */

        public List<Team> GetAllTeams()
        {
            return new List<Team>(_teams);
        }

        public Team GetTeamById(int id)
        {
            Team? team = _teams.Find(x => x.Id == id);
            if (team is null)
            {
                throw new KeyNotFoundException($"No team with id={id}");
            }
            return team;
        }
        public Team GetTeamByIdLoop(int id)
        {
            foreach (Team team in _teams)
            {
                if (team.Id == id) // fundet :-)
                {
                    return team;
                }
            }

            throw new KeyNotFoundException($"No team with id={id}");
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public void AddTeamWithCheck(Team team)
        {
            /*
             * tjek
             */
            bool sameDayAndTime = false;
            foreach (Team t in _teams)
            {
                if (t.Day == team.Day && t.Time == team.Time)
                {
                    sameDayAndTime = true;
                }
            }

            if (sameDayAndTime)
            {
                throw new ArgumentException($"Team on {team.Day} at {team.Time} already exists");
            }

            /*
             * tjek ended
             */

            AddTeam(team);
        }

        public Team DeleteTeam(int id)
        {
            Team team = GetTeamById(id); // will throw keyNotFoundException
                                         // if no team with given id 

            _teams.Remove(team);
            return team;
        }


        public List<Team> GetAllFullTeams()
        {
            List<Team> fullteams = new List<Team>();
            foreach (Team t in _teams)
            {
                if (t.IsFull())
                {
                    fullteams.Add(t);
                }
            }

            return fullteams;
        }

        public override string ToString()
        {
            string teamstr = "";
            foreach (Team t in _teams)
            {
                teamstr = teamstr + ", " + t.ToString();
            }

            return $"{{ Teams: [ {teamstr} ]}}";
        }
    }
}
