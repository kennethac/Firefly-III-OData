using System.ComponentModel.DataAnnotations;

namespace firefly_iii_odata.Models.Formatted;

public class FormattedTransaction
{
    public uint? GroupId { get; set; }
    public string? GroupTitle { get; set; }

    [Key]
    public uint JournalId { get; set; }
    public required string JournalDescription { get; set; }

    public uint TransactionTypeId { get; set; }
    public required string TransactionType { get; set; }

    public DateTime JournalDate { get; set; }
    public uint SourceAccountId { get; set; }
    public string SourceAccountName { get; set; }
    public uint DestinationAccountId { get; set; }
    public string DestinationAccountName { get; set; }
    public decimal Amount { get; set; }
    public uint? BudgetId { get; set; }
    public string? BudgetName { get; set; }
}