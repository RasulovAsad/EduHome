using DAL.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Body { get; set; }
        public string ImageUrl { get; set; }
    }
}
