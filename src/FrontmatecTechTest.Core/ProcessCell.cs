using System.ComponentModel.DataAnnotations.Schema;

namespace FrontmatecTechTest.Core;
public class ProcessCell(string title, string uuid, string status, bool isActive, string description, DateTime updatedAt) : EntityBase, IAggregateRoot
{
  public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
  public string Uuid { get; set; } = Guard.Against.NullOrEmpty(uuid, nameof(uuid));
  public string Status { get; set; } = Guard.Against.NullOrEmpty(status, nameof(status));
  public bool IsActive { get; set; } = Guard.Against.Null(isActive, nameof(isActive));
  public string Description { get; set; } = Guard.Against.NullOrEmpty(description, nameof(description));
  public DateTime UpdatedAt { get; set; } = Guard.Against.Null(updatedAt, nameof(updatedAt));
  public List<ProcessCellProperty> ProcessCellProperties { get; set; } = new();
}
