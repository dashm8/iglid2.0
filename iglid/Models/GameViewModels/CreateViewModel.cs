using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace iglid.Models.GameViewModels
{
    public class CreateViewModel
    {
        public Team t1 { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }        
        public int bestof { get; set; }
        public string mode { get; set; }
    }
}
