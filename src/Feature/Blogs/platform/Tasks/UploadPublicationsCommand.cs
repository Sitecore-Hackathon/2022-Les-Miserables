using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvp.Foundation.Search.Services;
using Sitecore.Data.Items;

namespace Mvp.Feature.Blog.Platform.Tasks
{
    public class UploadPublicationsCommand
    {
        public void Execute(Item[] items, Sitecore.Tasks.CommandItem command, Sitecore.Tasks.ScheduleItem schedule)
        {
            Sitecore.Diagnostics.Log.Info("Publications upload task started.", this);
            var database = Sitecore.Configuration.Factory.GetDatabase("web");
            var people = database.GetItem(ItemIDs.PeopleRootItemID)?.Axes.GetDescendants()?
                .Where(x => x.TemplateID == ItemIDs.PeopleTemplateID);
            Sitecore.Diagnostics.Log.Info("Blog Post Found : " + people?.Count(), this);
            var storageService = new StorageService();
            foreach (Item person in people)
            {
                var urls = this.GetPublicationUrls(person);
                foreach (var url in urls)
                {
                    if (!string.IsNullOrEmpty(url))
                    {
                        try
                        {
                            storageService.UploadPublication(url);
                        }
                        catch (Exception e)
                        {
                            Sitecore.Diagnostics.Log.Warn($"faild to push URL {url}. Message : {e.Message}", this);
                        }
                        
                    }
                }
                
            }
        }

        private string[] GetPublicationUrls(Item item)
        {
            var blogList = new List<string>();
            var blogListsField = item.Fields[ItemIDs.BlogPostFieldID]?.Value;
            if (string.IsNullOrEmpty(blogListsField))
            {
                return blogList.ToArray();
            }

            var mvpBlogs = HttpUtility.ParseQueryString(blogListsField);
            blogList.AddRange(mvpBlogs.AllKeys.Select(x=>mvpBlogs[x]));

            return blogList.ToArray();
        }
    }
}
