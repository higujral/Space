using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceDataModelClasses;
using System.Data.Entity;

namespace SpaceDataModel
{
    public class DataAccess
    {
        public void InsertStories(List<Story> newStories)
        {
            using (var context = new SpaceDBContext())
            {
                context.Stories.AddRange(newStories);
                context.SaveChanges();
            }
        }

        public void InsertTopics(List<Topic> newTopics)
        {
            using (var context = new SpaceDBContext())
            {
                context.Topics.AddRange(newTopics);
                context.SaveChanges();
            }
        }

       

        public void InsertStoryTypes(List<StoryType> newStoryTypes)
        {
            using (var context = new SpaceDBContext())
            {
                context.StoryTypes.AddRange(newStoryTypes);
                context.SaveChanges();
            }
        }

        public void InsertStoryType(StoryType newStoryType)
        {
            using (var context = new SpaceDBContext())
            {
                context.StoryTypes.Add(newStoryType);
                context.SaveChanges();
            }
        }

        public void InsertStoryFeedback(StoryFeedback feedback)
        {
            using (var context = new SpaceDBContext())
            {
                context.StoryFeedbacks.Add(feedback);
                context.SaveChanges();
            }
        }

        public List<StoryType> GetStoryTypes()
        {
            List<StoryType> storyTypes = null;
            using (var context = new SpaceDBContext())
            {
                storyTypes = context.StoryTypes.ToList();
            }
            return storyTypes;
        }

        public List<Story> GetStories()
        {
            List<Story> stories = null;
            using (var context = new SpaceDBContext())
            {
                stories = context.Stories.ToList();
            }
            return stories;
        }

        public List<Story> GetStoriesForType(StoryType storyType)
        {
            List<Story> stories = null;
            using (var context = new SpaceDBContext())
            {
                stories = context.Stories.Where(n => n.StoryType == storyType).ToList();
            }
            return stories;
        }

        public List<Topic> GetTopics()
        {
            List<Topic> topics = null;
            using (var context = new SpaceDBContext())
            {
                topics = context.Topics.ToList();
            }
            return topics;
        }

        public void UpdateStories(List<Story> updatedStories)
        {
            using (var context = new SpaceDBContext())
            {
                context.Entry(updatedStories).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateTopics(List<Topic> updatedTopics)
        {
            using (var context = new SpaceDBContext())
            {
                context.Entry(updatedTopics).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
