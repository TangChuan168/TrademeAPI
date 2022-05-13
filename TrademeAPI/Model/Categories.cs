using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeAPI.Model
{
    public class Categories
    {
        [Key]
        public Guid Guid { get; set; }
        public string parentId { get; set; }
        public string tagName { get; set; }
        public string Url { get; set; }
        public string namePassToChild { get; set; }
    }
}
