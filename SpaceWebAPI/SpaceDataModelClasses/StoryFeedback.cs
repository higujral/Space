using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceDataModelClasses
{
    public class StoryFeedback
    {
        public int ID { get; set; }

        public int StoryID { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateLastModified { get; set; }

    }
}
