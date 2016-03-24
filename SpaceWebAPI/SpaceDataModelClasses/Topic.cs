using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpaceDataModelClasses
{
    public class Topic
    {
        public int ID { get; set; }

        [MaxLength(450)]
        public string Name { get; set; }

        public List<SubTopic> SubTopics { get; set; }

        public List<Story> Stories { get; set; }
    }
}
