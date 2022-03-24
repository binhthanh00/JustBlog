using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Core
{
    public class DatabaseInitialize : CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);

            if (context.Tags.Any() && context.Posts.Any() && context.Categories.Any())
                return;

            var category = new Category()
            {
                Name = "Công nghệ",
                UrlSlug = "cong-nghe",
                Description = "Tin tức về công nghệ",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Title = "post 1",
                        ShortDescription = "Description1",
                        PostContent = "Content1",
                        UrlSlug = "tin-tuc",
                        Published = true,
                        ViewCount = 100,
                        RateCount = 10,
                        TotalRate = 40,
                    },
                    new Post()
                    {
                        Title = "post 2",
                        ShortDescription = "Description2",
                        PostContent = "Content2",
                        UrlSlug = "doi-song",
                        Published = true,
                        ViewCount = 100,
                        RateCount = 20,
                        TotalRate = 50,
                    },
                    new Post()
                    {
                        Title = "post 3",
                        ShortDescription = "Description3",
                        PostContent = "Content3",
                        UrlSlug = "cong-nghe",
                        Published = true,
                        ViewCount = 150,
                        RateCount = 10,
                        TotalRate = 48,
                    },
                }
            };

            var tag = new Tag()
            {
                Name = "tag 1",
                UrlSlug = "suc-khoe",
                Description = "Tin tức sức khỏe",
                Count = 1,
            };

            context.Categories.Add(category);

            context.Tags.Add(tag);

            context.SaveChanges();
        }
    }
}
