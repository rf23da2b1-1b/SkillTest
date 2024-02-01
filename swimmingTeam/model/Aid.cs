using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.model
{
    public class Aid
    {
		private int _id;
        private string _description;
        private int _amount;

        public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public int Amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

        public Aid():this(15,"generic", 5)
        {
        }

        public Aid(int id, string description, int amount)
        {
            Id = id;
            Description = description;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Description)}={Description}, {nameof(Amount)}={Amount.ToString()}}}";
        }
    }
}
