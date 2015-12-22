using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDataModelClasses
{
    public class SubTopic
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Topic Topic { get; set; }

        public int TopicID { get; set; }
    }
}
