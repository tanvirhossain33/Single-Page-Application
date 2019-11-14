using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Model
{
    public class Document : Entity
    {
        public string Syllabus { get; set; }
        public string DevelopmentOfficer { get; set; }
        public string Manager { get; set; }

        public DateTime ActiveDate { get; set; }


        public string SyllabusFileName { get; set; }

        public string TradeId { get; set; }

        public string LevelId { get; set; }




    }
}
