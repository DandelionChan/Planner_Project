using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Models
{
    public class AppointmentActivity : Activity
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        protected AppointmentActivity() { }
        public AppointmentActivity(
            string name,
            int userId,
            DateOnly date,
            string description,
            string color,
            RecurrenceType recurrence,
            TimeOnly startTime,
            TimeOnly endTime)
            : base(name, userId, date, description, color, recurrence)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public void ValidateTime()
        {
            if (EndTime < StartTime)
            {
                throw new InvalidOperationException("End time cannot be earlier than start time.");
            }
        }
        public override string GetActivityType()
        {
            return "Appointment";
        }
    }
}
