using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Poco;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSBEF.Module.UserActionLog
{
    public class ModulePocoBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.Entity<ActionLog>(entity =>
            {
                entity.ToTable("UserActionLog_ActionLog");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ActionTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(256);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}