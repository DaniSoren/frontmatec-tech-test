using System.Diagnostics;
using System.Reflection;
using FrontmatecTechTest.Core.ContributorAggregate;
using FastEndpoints;
using MediatR;
using Microsoft.Extensions.Logging;
using FrontmatecTechTest.Core;

namespace FrontmatecTechTest.UseCases.Contributors.Create;

//public record CreateProcessCellCommand(string? Title, Guid? Uuid, string? Status, bool? IsActive, string? Description, Dictionary<string, string>? ProcessCellProperties) : Ardalis.SharedKernel.ICommand<Result<int>>;

public record CreateProcessCellCommand2(string Title, string Uuid, string Status, bool IsActive, string Description, Dictionary<string, string>? ProcessCellProperties) : FastEndpoints.ICommand<Result<int>>;

public class CreateProcessCellHandler2 : CommandHandler<CreateProcessCellCommand2, Result<int>>
{
  private readonly IRepository<ProcessCell> _repository;
  public CreateProcessCellHandler2(IRepository<ProcessCell> repository)
  {
    _repository = repository;
  }
  public override async Task<Result<int>> ExecuteAsync(CreateProcessCellCommand2 request, CancellationToken cancellationToken)
  {
    var newProcessCell = new ProcessCell(request.Title, request.Uuid, request.Status, request.IsActive, request.Description, DateTime.UtcNow);
    if (request.ProcessCellProperties != null)
    {
      foreach (var (key, value) in request.ProcessCellProperties)
      {
        var processCellProperty = new ProcessCellProperty(key, value);
        newProcessCell.ProcessCellProperties.Add(processCellProperty);
      }
    }
    var createdItem = await _repository.AddAsync(newProcessCell, cancellationToken);

    return createdItem.Id;
  }
}
