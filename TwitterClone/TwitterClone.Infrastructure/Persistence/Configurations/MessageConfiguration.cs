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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.SenderId)
                .IsRequired();

            builder.Property(m => m.ReceiverId)
                .IsRequired();

            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(m => m.SentAt)
                .IsRequired();

            builder.Property(m => m.IsRead)
                .IsRequired()
                .HasDefaultValue(false);

            // The sender is a user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // The receiver is a user.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Supports retrieving conversations by sender and receiver.
            builder.HasIndex(m => new
            {
                m.SenderId,
                m.ReceiverId,
                m.SentAt
            });
        }
    }
}
