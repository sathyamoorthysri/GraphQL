namespace GraphQL_Demo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GraphQLEntity : DbContext
    {
        public GraphQLEntity() : base("name=GraphQLEntities")
        {
        }

        public virtual DbSet<Tbl_Author> AuthorRepository { get; set; }
        public virtual DbSet<Tbl_Comment> CommentsRepository { get; set; }
        public virtual DbSet<Tbl_Post> PostRepository { get; set; }
        public virtual DbSet<Tbl_Rating> RatingRepository { get; set; }
        public virtual DbSet<Tbl_SocialNetwork> SocialNetworkRepository { get; set; }
        public virtual DbSet<Tbl_SocialNetworkType> SocialNetworkTypeRepository { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
