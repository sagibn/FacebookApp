using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    public class Birthday
    {
        private DateTime m_Birthday;

        public Birthday(DateTime i_DateTime)
        {
            m_Birthday = i_DateTime;
        }

        public int Age()
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - m_Birthday.Year;

            if (currentDate.Month < m_Birthday.Month || (currentDate.Month == m_Birthday.Month && currentDate.Day < m_Birthday.Day))
            {
                age--;
            }

            return age;
        }

        public int NextBirthdayInDays()
        {
            DateTime currentDate = DateTime.Now;
            DateTime nextBirthday = new DateTime(currentDate.Year, m_Birthday.Month, m_Birthday.Day);

            if(currentDate > nextBirthday)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            TimeSpan timeUntilNextBirthday = nextBirthday - currentDate;
            int daysUntilNextBirthday = (int)timeUntilNextBirthday.TotalDays;

            return daysUntilNextBirthday;
        }

        public string GetZodiacSign()
        {
            int month = m_Birthday.Month;
            int day = m_Birthday.Day;
            string zodiacSign;

            if((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                zodiacSign = "Aries";
            }
            else if((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                zodiacSign = "Taurus";
            }
            else if((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                zodiacSign = "Gemini";
            }
            else if((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                zodiacSign = "Cancer";
            }
            else if((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                zodiacSign = "Leo";
            }
            else if((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                zodiacSign = "Virgo";
            }
            else if((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                zodiacSign = "Libra";
            }
            else if((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                zodiacSign = "Scorpio";
            }
            else if((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                zodiacSign = "Sagittarius";
            }
            else if((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                zodiacSign = "Capricorn";
            }
            else
            {
                zodiacSign = "Aquarius";
            }

            return zodiacSign;
        }
    }
}
