using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Models
{
    public class ScraperModel
    {
        public int ID { get; set; }
        [Display(Name = "Search Phrase/String")]
        [StringLength(100)]
        public string input { get; set; }
        [Display(Name = "Google Position")]
        [Range(1, 100, ErrorMessage = "You need to enter a value with 1-100")]
        public int position { get; set; }
        [Display(Name = "Paid Advertisements")]
        [Range(1, 100, ErrorMessage = "You need to enter a value with 1-100")]
        public int paid_ads { get; set; }

        [Display(Name = "Date")]
        public DateTime date { get; set; }

    }
}
