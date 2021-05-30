using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestDateTime.Models
{
    public class DTestMetadata
    {
        public int bookid { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> startdate { get; set; }


        [Display(Name = "Remarks")]
        public string remarks { get; set; }

    }
}