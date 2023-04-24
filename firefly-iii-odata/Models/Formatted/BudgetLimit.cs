namespace firefly_iii_odata.Models.Formatted;

public class FormattedBudgetLimit
{
    public uint Id { get; set; }
    public uint BudgetId { get; set; }
    public required string BudgetName { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool? RollsOver { get; set; }
    public string? Period { get; set; }
    public decimal? PeriodAmount { get; set; }
    public decimal CurrentPeriodAmount { get; set; }
    public decimal CurrentPeriodSpent { get; set; }
}