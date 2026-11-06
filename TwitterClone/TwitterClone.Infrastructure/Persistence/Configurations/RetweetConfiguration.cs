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
    public class RetweetConfiguration : IEntityTypeConfiguration<Retweet>
    {
        public void Configure(EntityTypeBuilder<Retweet> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                .IsRequired();

            builder.Property(r => r.TweetId)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(200)
                .IsRequired();

            // The user who retweeted.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // The original tweet being retweeted.
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(r => r.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Prevent duplicate retweets by the same user.
            builder.HasIndex(r => new { r.UserId, r.TweetId })
                .IsUnique();
        }
    }
}
