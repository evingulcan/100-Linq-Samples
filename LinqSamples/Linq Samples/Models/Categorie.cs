using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Samples.Models
{
    class Categorie
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
