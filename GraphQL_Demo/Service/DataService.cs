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
        private GraphQLEntity dbContext = new GraphQLEntity();
        public Author GetAuthorById(int id)
        {
            return dbContext.AuthorRepository.Where(author => author.ID == id).Select(x => new Author()
            {
                Id = x.ID,
                Name = x.NAME,
                Bio = x.BIO,
                Imgurl = x.IMGURL,
                Profileurl = x.PROFURL
            }).FirstOrDefault();
        }
        public Rating GetRatingById(int id)
        {
            return dbContext.RatingRepository.Where(y => y.ID == id).Select(z => new Rating()
            {
                Count = z.COUNT ?? default(int),
                Percent = z.PERCENTAGE ?? default(int)
            }).FirstOrDefault();
        }
        public List<Comment> GetCommentsById(int id)
        {
            return dbContext.CommentsRepository.Where(y => y.POST_ID == id).Select(z => new Comment()
            {
                Count = z.COUNT ?? default(int),
                Description = z.DESCRIPTION,
                Url = z.URL
            }).ToList();
        }
        public List<Author> GetAllAuthors()
        {
            return dbContext.AuthorRepository
                .Select(x => new Author()
                {
                    Id = x.ID,
                    Name = x.NAME,
                    Bio = x.BIO,
                    Imgurl = x.IMGURL,
                    Profileurl = x.PROFURL
                }).ToList();
        }
        public List<Post> GetPostsByAuthor(int id)
        {
            return dbContext.PostRepository
                .Where(post => post.AUTHOR_ID == id)
                .Select(x => new Post()
                {
                    Id = x.ID,
                    Title = x.TITLE,
                    Description = x.DESCRIPTION,
                    Date = x.DATE ?? DateTime.MinValue,
                    Url = x.URL,
                    Author = this.GetAuthorById(x.AUTHOR_ID ?? 0),
                    Rating = this.GetRatingById(x.RATING_ID ?? 0),
                    Comments = this.GetCommentsById(x.ID),
                    Categories = x.CATEGORIES

                }).ToList();
        }
        public List<SocialNetwork> GetSNsByAuthor(int id)
        {
            return dbContext.SocialNetworkRepository
                .Where(sn => sn.AUTHOR_ID == id)
                .Select(x => new SocialNetwork()
                {
                    Author = this.GetAuthorById(x.AUTHOR_ID ?? 0),
                    NickName = x.NICKNAME,
                    Type = (SNType)dbContext.SocialNetworkTypeRepository.Where(y => y.ID == x.SOCIALNETWORK_ID).FirstOrDefault().ID,
                    Url = x.URL
                }).ToList();
        }
    }
}