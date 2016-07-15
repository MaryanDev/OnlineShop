using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.WebUI.Areas.User.Models
{
    public class SearchProductInfo
    {
        public int CurrentPage { get; set; }

        public string SearchedCategory { get; set; }
        
        public int MinChoiceCost { get; set; }

        public int MaxChoiceCost { get; set; }

    }
}