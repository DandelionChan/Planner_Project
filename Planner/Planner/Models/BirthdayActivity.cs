using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Models
{
    public class BirthdayActivity : Activity
    {
        public string BirthdayPerson { get; set; }

        protected BirthdayActivity() { }
        public BirthdayActivity(
            string name,
            int userId,
            string birthdayPerson,
            DateOnly date,
            string description,
            string color,
            RecurrenceType recurrence = RecurrenceType.Yearly)
            : base(name, userId, date, description, color, recurrence)
        {
            BirthdayPerson = birthdayPerson;
        }

        public override string GetActivityType()
        {
            return "Birthday";
        }
    }
}
