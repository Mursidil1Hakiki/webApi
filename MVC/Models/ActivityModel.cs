using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ActivityModel
    {
        public int No { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public Nullable<bool> complete { get; set; }
    }
}