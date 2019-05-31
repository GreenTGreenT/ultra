using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ultrasonic.Models
{
    public class Value
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string distance { get; set; }
    }

    public class ListValue
    {
        public int number { get; set; }
        public List<Value> values = new List<Value>();

    }
}