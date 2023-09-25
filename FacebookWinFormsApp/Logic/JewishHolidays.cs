using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;

namespace BasicFacebookFeatures.Logic
{
    public class JewishHolidays : IEnumerable<KeyValuePair<string, DateTime>>
    {
        private Dictionary<string, DateTime> m_Holidays;

        public JewishHolidays()
        {
            m_Holidays = new Dictionary<string, DateTime>();
        }

        public IEnumerator<KeyValuePair<string, DateTime>> GetEnumerator()
        {
            return m_Holidays.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public async Task GetJewishHolidaysAsync()
        {
            using(HttpClient client = new HttpClient())
            {
                string apiEndpoint = "https://www.hebcal.com/hebcal";
                string parameters = "?cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on";

                HttpResponseMessage response = await client.GetAsync(apiEndpoint + parameters);

                if(response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonString);

                    parseImportantEvents(jsonObject);
                }
            }
        }

        private void parseImportantEvents(JObject i_JsonObject)
        {
            foreach(var item in i_JsonObject["items"])
            {
                string title = item.Value<string>("title");
                DateTime date = item.Value<DateTime>("date");

                if(isImportantEvent(title))
                {
                    m_Holidays[title] = date;
                }
            }
        }

        private bool isImportantEvent(string i_Title)
        {
            string[] importantTitles = new string[]
            {
            "Erev Yom Kippur",
            "Erev Rosh Hashana",
            "Sukkot I",
            "Chanukah: 1 Candle",
            "Tu BiShvat",
            "Purim",
            "Pesach I",
            "Pesach II",
            "Yom HaShoah",
            "Yom HaZikaron",
            "Yom HaAtzma'ut",
            "Lag BaOmer",
            "Yom Yerushalayim",
            "Erev Shavuot",
            "Tish'a B'Av",
            "Tu B'Av"
            };

            return Array.Exists(importantTitles, importantTitle => importantTitle == i_Title);
        }
    }
}
