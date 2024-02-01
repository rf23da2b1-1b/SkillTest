using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace swimmingTeam.model
{
    public class Trainer:Person
    {
		private string  _skill;

		public string Skill
		{
			get { return _skill; }
			set { _skill = value; }
		}

        public Trainer():this (-1,"","","")
        {
        }

        public Trainer(int id, string phone, string name, string skill) : base(id, phone, name)
        {
            Skill = skill;
        }

        public override string ToString()
        {
            return $"{{{base.ToString()}, {nameof(Skill)}={Skill}}}";
        }
    }
}
