using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }

    }
}
