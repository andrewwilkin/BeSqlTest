namespace BeSql.Client.Models;

public sealed class CalculationResult
{
    public Guid OrganisationNodeId { get; set; }
    public Guid MeasureId { get; set; }
    public Guid MeasureMetricId { get; set; }
    public DateTime ReportMonth { get; set; }
    public double Value { get; set; }
}