using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BasicFacebookFeatures.Logic
{
    public class BirthdayAdapter
    {
        private Birthday m_BirthDay;

        public BirthdayAdapter(string i_StrDate)
        {
            string format = "MM/dd/yyyy";

            try
            {
                DateTime.TryParseExact(i_StrDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
                m_BirthDay = new Birthday(result);
            }
            catch(Exception ex)
            {
                m_BirthDay = null;
                throw new Exception(ex.Message);
            }
        }

        public int? Age()
        {
            int? age = null;

            if(m_BirthDay != null)
            {
                age = m_BirthDay.Age();
            }

            return age;
        }

        public int? NextBirthdayInDays()
        {
            int? days = null;

            if(m_BirthDay != null)
            {
                days = m_BirthDay.NextBirthdayInDays();
            }

            return days;
        }

        public string GetZodiacSign()
        {
            string zodiacSign = string.Empty;

            if(m_BirthDay != null)
            {
                zodiacSign = m_BirthDay.GetZodiacSign();
            }

            return zodiacSign;
        }
    }
}
