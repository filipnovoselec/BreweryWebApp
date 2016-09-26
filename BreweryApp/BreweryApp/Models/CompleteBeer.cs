using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSWebApiEmpty.Models
{
    public class CompleteBeer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Time { get; set; }
        public int TotalTime { get; set; }
        public List<float> Temperature { get; set; }
        public List<DateTime> ReadTime { get; set; }
    }
}