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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.UserId)
                .IsRequired();

            builder.Property(l => l.TweetId)
                .IsRequired();

            // A user can like many tweets.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // A tweet can receive many likes.
            builder.HasOne<Tweet>()
                .WithMany()
                .HasForeignKey(l => l.TweetId)
                .OnDelete(DeleteBehavior.Cascade);

            // A user can like a particular tweet only once.
            builder.HasIndex(l => new { l.UserId, l.TweetId })
                .IsUnique();
        }
    }
}
