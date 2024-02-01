using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.model
{
    public class Team
    {
		private int _id;
		private string _day;
		private int _time;
		private int _limit;


		// associeringer
		private Trainer _trainer;
		private List<Aid> _aidList;
        private List<Member> _membersList;


        // properties
		public int Limit
		{
			get { return _limit; }
			set { _limit = value; }
		}


		public int Time
		{
			get { return _time; }
			set { _time = value; }
		}


		public string Day
		{
			get { return _day; }
			set { _day = value; }
		}


		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}


		/*
		 * til associering
		 */
        public Trainer Trainer
        {
            get { return _trainer; }
            set { _trainer = value; }
        }



		public void AddAid(Aid aid)
		{
			_aidList.Add(aid);
		}
        public void RemoveAid(int id)
        {
            Aid aid = _aidList.Find(t => t.Id == id);

            if (aid != null)
            {
                _aidList.Remove(aid);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public List<Aid> GetAllAid()
        {
            return new List<Aid>(_aidList);
        }



        public void EnrollMember(Member member)
        {
            if (member is null)
            {
                throw new ArgumentNullException();
            }

            int antal = _membersList.Count;
            if (antal < Limit)
            {
                _membersList.Add(member);
                member.AddTeam(this);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Dit fjols der er kun plads til 2");
            }
        }
        public void RemoveMember(int id)
        {
            Member member = _membersList.Find(m => m.Id == id);

            if (member != null)
            {
                _membersList.Remove(member);
                member.RemoveTeam(Id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        public List<Member> GetAllMembers()
        {
            return new List<Member>(_membersList);
        }



        /*
         * help 
         */
        public bool IsFull()
        {
            return Limit == _membersList.Count;
        }



        public Team() : this(-1, 0, 0, "") 
		{ }
        

        public Team(int id, int limit, int time, string day)
        {
            Limit = limit;
            Time = time;
            Day = day;
            Id = id;

			_trainer = null;
            _aidList = new List<Aid>();
            _membersList = new List<Member>();
        }

        public Team(int id, int limit, int time, string day, Trainer trainer)
        {
            Limit = limit;
            Time = time;
            Day = day;
            Id = id;

            _trainer = trainer;
            _aidList = new List<Aid>();
            _membersList = new List<Member>();
        }

        public override string ToString()
        {
            string memberStr = "";
            foreach (Member member in _membersList)
            {
                memberStr = memberStr + ", " + member.ToString();
            }

            string memberStr2 = string.Join(", ", _membersList);
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Limit)}={Limit.ToString()}, {nameof(Time)}={Time.ToString()}, {nameof(Day)}={Day}, {nameof(Id)}={Id.ToString()}, Member=[{memberStr2}]}}";
        }
    }
}
