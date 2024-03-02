﻿using AAA.ERP.Models.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AAA.ERP.DBConfiguration.Config.BaseConfig;

public class BaseEntityDbConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: BaseEntity
{
    protected int columnNumber = 0;
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        _ = builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>().HasColumnOrder(columnNumber++);
        _ = ApplyConfiguration(builder);
        _ = builder.Property(e => e.Notes).HasMaxLength(300).HasColumnOrder(columnNumber++);
    }

    virtual protected EntityTypeBuilder<TEntity> ApplyConfiguration(EntityTypeBuilder<TEntity> builder)
    => builder;
}
