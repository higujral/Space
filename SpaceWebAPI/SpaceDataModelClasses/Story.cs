using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceDataModelClasses
{
    public class Story
    {
       
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateLastModified { get; set; }

        public StoryType StoryType { get; set; }

        public int StoryTypeID { get; set; }

        public List<Topic> Topics { get; set; }

        public List<StoryFeedback> StoryFeedbacks { get; set; }

    }
}
