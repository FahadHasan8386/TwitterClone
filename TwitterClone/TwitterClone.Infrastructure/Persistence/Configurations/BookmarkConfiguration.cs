using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.TweetId)
                .IsRequired();

            // A user can have many bookmarks.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // A tweet can be bookmarked by many users.
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(b => b.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            // A user can bookmark a particular tweet only once.
            builder.HasIndex(b => new { b.UserId, b.TweetId })
                .IsUnique();
        }
    }
}
