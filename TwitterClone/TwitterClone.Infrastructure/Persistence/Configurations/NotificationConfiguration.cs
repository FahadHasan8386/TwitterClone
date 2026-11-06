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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.Property(n => n.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(n => n.IsRead)
                .IsRequired()
                .HasDefaultValue(false);

            // The message is protected, so configure its backing field.
            builder.Property<string>("_message")
                .HasField("_message")
                .HasColumnName("Message")
                .HasMaxLength(2000)
                .IsRequired();

            // A user can have many notifications.
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Supports filtering notifications by user and read status.
            builder.HasIndex(n => new { n.UserId, n.IsRead });
        }
    }
}
