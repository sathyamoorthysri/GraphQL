using GraphQL_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace GraphQL_Demo.Service
{
    public class DataService
    {
        private readonly List<Author> authors = new List<Author>();
        private readonly List<Post> posts = new List<Post>();
        private readonly List<SocialNetwork> sns = new List<SocialNetwork>();

        private GraphQLEntity db = new GraphQLEntity();

        public DataService()
        {
            authors = db.AuthorRepository.Select(x => new Author()
            {
                Id = x.ID,
                Name = x.NAME,
                Bio = x.BIO,
                Imgurl = x.IMGURL,
                Profileurl = x.PROFURL
            }).ToList();

            posts = db.PostRepository.Select(x => new Post()
            {
                Id = x.ID,
                Title = x.TITLE,
                Description = x.DESCRIPTION,
                Date = x.DATE ?? DateTime.MinValue,
                Url = x.URL,

                Author = db.AuthorRepository.Where(y => y.ID == x.AUTHOR_ID).Select(z => new Author()
                {
                    Id = z.ID,
                    Name = z.NAME,
                    Bio = z.BIO,
                    Imgurl = z.IMGURL,
                    Profileurl = z.PROFURL
                }).FirstOrDefault(),

                Rating = db.RatingRepository.Where(y => y.ID == x.RATING_ID).Select(z => new Rating()
                {
                    Count = z.COUNT ?? default(int),
                    Percent = z.PERCENTAGE ?? default(int)
                }).FirstOrDefault(),

                Comments = db.CommentsRepository.Where(y => y.POST_ID == x.ID).Select(z => new Comment()
                {
                    Count = z.COUNT ?? default(int),
                    Description = z.DESCRIPTION,
                    Url = z.URL
                }).ToList(),

                Categories = x.CATEGORIES

            }).ToList();

            sns = db.SocialNetworkRepository.Select(x => new SocialNetwork()
            {
                Author = db.AuthorRepository.Where(y => y.ID == x.AUTHOR_ID).Select(z => new Author()
                {
                    Id = z.ID,
                    Name = z.NAME,
                    Bio = z.BIO,
                    Imgurl = z.IMGURL,
                    Profileurl = z.PROFURL
                }).FirstOrDefault(),

                NickName = x.NICKNAME,
                Type = (SNType) db.SocialNetworkTypeRepository.Where(y => y.ID == x.SOCIALNETWORK_ID).FirstOrDefault().ID,
                Url = x.URL

            }).ToList();           


        }

        public List<Author> GetAllAuthors()
        {
            return this.authors;
        }
        public Author GetAuthorById(int id)
        {
            return authors.Where(author => author.Id == id).FirstOrDefault<Author>();
        }
        public List<Post> GetPostsByAuthor(int id)
        {
            return posts.Where(post => post.Author.Id == id).ToList<Post>();
        }
        public List<SocialNetwork> GetSNsByAuthor(int id)
        {
            return sns.Where(sn => sn.Author.Id == id).ToList<SocialNetwork>();
        }
    }
}