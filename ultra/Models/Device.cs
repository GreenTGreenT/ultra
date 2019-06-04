using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace device.Models
{
    public class Device
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string room { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class ListDevice
    {
        //public int number { get; set; }
        public List<Device> devices = new List<Device>();

    }
}