using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.model
{
    public  class Member: Person
    {
		private int _enrollmentYear;

        // associering
        private List<Team> _teams;

		public int EnrollmentYear
		{
			get { return _enrollmentYear; }
			set { _enrollmentYear = value; }
		}

        public Member() : this(0,"","",0)
        {
            
        }

        public Member(int id, string phone, string name, int year) : base(id, phone, name)
        {
            EnrollmentYear = year;
            _teams = new List<Team>();
        }


        /*
         * metoder til team membership
         */
        public void AddTeam(Team t)
        {
            _teams.Add(t);
        }

        public void RemoveTeam(int id)
        {
            Team t = _teams.Find(t => t.Id == id);

            if (t != null)
            {
                _teams.Remove(t);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public override string ToString()
        {
            return $"{{{base.ToString()}, {nameof(EnrollmentYear)}={EnrollmentYear.ToString()}}}";
        }
    }
}
