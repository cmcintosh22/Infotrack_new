using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Infotrack.Controllers;
using Infotrack.Data;
using Infotrack.Models;

namespace Infotrack.Services
{
    public class Data : IData
    {

        
        public string GoogleURL()
        {
            string url = "https://www.google.co.uk/search?num=100&q=land+registry+search";
            
            return url;
            
        }

        public string GoogleURLInput(string input)
        {
            string url = "https://www.google.co.uk/search?num=100&q=land+registry+search/" + input;
            return url;

        }



        public string InfotrackURL()
        {
            string infotrack_url = "www.infotrack.co.uk/services/conveyancing/land-registry-searches/";
            return infotrack_url;
        }

        public string GoogleResultSplit()
        {
            string google_result_s = "h3 class";
            return google_result_s;

        }

        public string PaidAdSplit()
        {
            string paid_add_s = "aria-level=\"3\"";
            return paid_add_s;

        }

        public async Task getDataAsync()
        {
            {
                var data = await HttpClientFactory.Create().GetStringAsync(GoogleURL()); // http get request - html code in stored in data variable 
                var split_data = data.Split(GoogleResultSplit()); // split string and place into array - string represents google search result (normal formatting)
                var paid_ads = data.Split(PaidAdSplit()); // split string and place into array - string represents google search result (paid add formating)
                var googleP_counter = 0;
                var paid_ads_counter = 0;
                var total = 0;
                foreach (string s in split_data)
                {
                    try
                    {
                        googleP_counter += 1;
                        if (s.Contains(InfotrackURL())) //looking for a string match in the first 100 good search results
                        {
                            total = googleP_counter;
                            
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); //at a later date - map exception to a different view 
                    }
                }
                foreach (string p_ads in paid_ads)
                {

                    paid_ads_counter += 1;

                }

            }
           
        }

    }
}
