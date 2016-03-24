using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaceDataModel;
using SpaceDataModelClasses;

namespace SpaceWebAPI.Controllers
{
    public class SpaceController : ApiController
    {
        private readonly DataAccess _repo= new DataAccess();

        //GET Stories
        public List<Story> GetStories()
        {
            return _repo.GetStories();
        }

        //GET StoryTypes
        public List<StoryType> GetStoryTypes()
        {
            return _repo.GetStoryTypes();
        }

        //Get Topics
        public List<Topic> GetTopics()
        {
            return _repo.GetTopics();
        }


        //GET Stories for input story type
        public List<Story> GetStoriesForType(StoryType storyType)
        {
            return _repo.GetStoriesForType(storyType);
        }

        //GET Stories for input topics
        public List<Story> GetStoriesForTopics(List<Topic> topics)
        {
            return _repo.GetStoriesForTopics(topics);
        }

        // Test GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST Stories
        public void PostStories([FromBody] List<Story> stories)
        {
            _repo.InsertStories(stories);
        }

        // POST Stories
        public void PostStoryTypes([FromBody] List<StoryType> storyTypes)
        {
            _repo.InsertStoryTypes(storyTypes);
        }

        // POST Stories
        public void PostTopics([FromBody] List<Topic> topics)
        {
            _repo.InsertTopics(topics);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
