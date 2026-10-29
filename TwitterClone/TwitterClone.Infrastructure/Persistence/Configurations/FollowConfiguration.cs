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
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.FollowerId)
                .IsRequired();

            builder.Property(f => f.FollowingId)
                .IsRequired();

            // The follower is a user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            // The user being followed.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.FollowingId)
                .OnDelete(DeleteBehavior.Cascade);

            // A user can follow another user only once.
            builder.HasIndex(f => new { f.FollowerId, f.FollowingId })
                .IsUnique();

            // Prevent a user from following themselves.
            builder.ToTable(t =>
                t.HasCheckConstraint(
                    "CK_Follows_NoSelfFollow",
                    "\"FollowerId\" <> \"FollowingId\""));
        }
    }
}
