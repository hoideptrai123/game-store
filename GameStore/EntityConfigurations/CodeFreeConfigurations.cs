﻿using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class CodeFreeConfigurations : IEntityTypeConfiguration<CodeFree>
    {
        public void Configure(EntityTypeBuilder<CodeFree> builder)
        {
            //builder
            //   .HasOne(a => a.Game)
            //   .WithMany(c => c.FreeCodes)
            //   .HasForeignKey(o => o.GameId)
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
