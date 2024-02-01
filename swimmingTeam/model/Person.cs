using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.model
{
    public abstract class Person
    {
		private int _id;

		private string _name;

		private string _phone;

		public string Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}


		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

        public Person():this(-1, "","")
        {
        }

        public Person( int id, string phone, string name)
        {
            Phone = phone;
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return $"{{{nameof(Phone)}={Phone}, {nameof(Name)}={Name}, {nameof(Id)}={Id.ToString()}}}";
        }
    }
}
