using BeSql.Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeSql.Client.Data.Configuration;

public class CalculationResultConfiguration : IEntityTypeConfiguration<CalculationResult>
{
    public void Configure(EntityTypeBuilder<CalculationResult> builder)
    {
       //builder.HasKey(x => new { x.OrganisationNodeId, x.MeasureId, x.MeasureMetricId, x.ReportMonth });
       builder.HasKey(x => new { x.OrganisationNodeId });
    }
}