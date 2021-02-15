using Infotrack.Data;
using Infotrack.Models;
using Infotrack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Infotrack.Controllers
{
    public class ScraperController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IData _Idata;
        ScraperModel model = new ScraperModel();
        ScraperModelsController model_c = new ScraperModelsController(null);
        private readonly ScraperContext _context;

        public ScraperController(IData data, ScraperContext context)
        {
            
            _Idata = data;
            _context = context;
        }



        [HttpGet]
        public IActionResult Calc()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Calc(string BREF, ScraperModel scraper)
        {
            {
                var data = await HttpClientFactory.Create().GetStringAsync(_Idata.GoogleURL()); // http get request - html code in stored in data variable 
                var split_data = data.Split(_Idata.GoogleResultSplit()); // split string and place into array - string represents google search result (normal formatting)
                var paid_ads = data.Split(_Idata.PaidAdSplit()); // split string and place into array - string represents google search result (paid add formating)
                var googleP_counter = 0;
                var paid_ads_counter = 0;
                var total = 0;
                foreach (string s in split_data)
                {
                    try
                    {
                        googleP_counter += 1;
                        if (s.Contains(_Idata.InfotrackURL())) //looking for a string match in the first 100 good search results
                        {
                            total = googleP_counter;
                            ViewBag.google = total;
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

                               
                ViewBag.ads = paid_ads_counter;
                ViewBag.total = total - paid_ads_counter;

                var new_model = new ScraperModel { input = "infotrack", position = total, paid_ads = paid_ads_counter, date = DateTime.Now };
                _context.Add(new_model);
                
                await _context.SaveChangesAsync();
                
            }
         return View();
        }

        public async Task<IActionResult> stringUpdate(string searchString)
        {
            if (searchString != null)
            {
                ViewBag.test = searchString;
                var url = "https://www.google.co.uk/search?q=" + searchString + "&num=100&filter=0&biw=1536&bih=698";
                url = url.Replace(" ", "+");
                ViewBag.newurl = url;
                var data = await HttpClientFactory.Create().GetStringAsync(url); // http get request - html code in stored in data variable 
                var split_data = data.Split(_Idata.GoogleResultSplit()); // split string and place into array - string represents google search result (normal formatting)
                var paid_ads = data.Split(_Idata.PaidAdSplit()); // split string and place into array - string represents google search result (paid add formating)
                var googleP_counter_ns = 0;
                var total_ns = 0;
                var error_ns = 0;

                foreach (string s in split_data)
                {
                    try
                    {
                        googleP_counter_ns += 1;
                        if (s.Contains("www.infotrack.co.uk")) //looking for a string match in the first 100 good search results
                        {
                            if (total_ns != 0)
                            {
                                break;
                            }
                            else
                            {
                                total_ns = googleP_counter_ns;
                                ViewBag.google_ns = googleP_counter_ns;
                            }
                        }
                        else if (googleP_counter_ns == 101)
                        {
                            error_ns = googleP_counter_ns;
                            ViewBag.google_error = error_ns;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); //at a later date - map exception to a different view 
                    }
                }

                var new_model = new ScraperModel { input = searchString, position = total_ns, paid_ads = 0, date = DateTime.Now  };
                _context.Add(new_model);
                await _context.SaveChangesAsync();


            }
            return View("Calc");
        }

        public async Task<IActionResult> urlUpdate(string urlString)
        {
            if (urlString != null)
            {
                ViewBag.test_url = urlString;
                var url = urlString;
                ViewBag.newurl = url;
                var data = await HttpClientFactory.Create().GetStringAsync(url); // http get request - html code in stored in data variable 

                var split_data = data.Split(_Idata.GoogleResultSplit()); // split string and place into array - string represents google search result (normal formatting)
                var paid_ads = data.Split(_Idata.PaidAdSplit()); // split string and place into array - string represents google search result (paid add formating)

                var googleP_counter_url = 0;
                var total_url = 0;
                var error_url = 0;

                foreach (string s in split_data)
                {
                    try
                    {
                        googleP_counter_url += 1;
                        if (s.Contains("www.infotrack.co.uk")) //looking for a string match in the first 100 good search results
                        {
                            if (total_url != 0)
                            {
                                break;
                            }
                            else
                            {
                                total_url = googleP_counter_url;
                                ViewBag.google_url = googleP_counter_url;
                            }
                        }
                        else if (googleP_counter_url > 98)
                        {
                            error_url = googleP_counter_url;
                            ViewBag.google_error_url = error_url;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); //at a later date - map exception to a different view 
                    }
                }

                var new_model = new ScraperModel { input = urlString, position = total_url, paid_ads = 0, date = DateTime.Now };
                _context.Add(new_model);
                await _context.SaveChangesAsync();

            }
            return View("Calc");
        }


    }

}
