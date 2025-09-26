using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using FrontmatecTechTest.Core;
using FrontmatecTechTest.UseCases.Contributors.Create;

namespace FrontmatecTechTest.Web.Contributors;

/// <summary>
/// Create a new Contributor
/// </summary>
/// <remarks>
/// Creates a new Contributor given a name.
/// </remarks>
public class CreateProcessCellEndpoint()
  : Endpoint<CreateProcessCellRequest, CreateProcessCellResponse>
{
  public override void Configure()
  {
    Post(CreateProcessCellRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    CreateProcessCellRequest request,
    CancellationToken cancellationToken)
  {
    Console.WriteLine(Guid.NewGuid());
    //var result= await _mediator.Send(new CreateProcessCellCommand(request.Title, request.Uuid, request.Status, request.IsActive, request.Description, request.ProcessCellProperties), cancellationToken);

    var result2 = await new CreateProcessCellCommand2(request.Title,request.Uuid,request.Status,request.IsActive,request.Description,null)//request.ProcessCellProperties)
      .ExecuteAsync(cancellationToken);
    
    if (result2.IsSuccess)
    {
      Response = new CreateProcessCellResponse(result2.Value, "foo");
      return;
    }
    // TODO: Handle other cases as necessary
  }
}


public class CreateProcessCellRequest
{
  public const string Route = "/ProcessCell";

  [Required]
  public required string Type { get; set; }
  [Required]
  public required string Title { get; set; }
  [Required]
  public required string Uuid { get; set; }
  [Required]
  public required bool IsActive{ get; set; }
  [Required]
  public required string Status { get; set; }
  [Required]
  public required string Description { get; set; }
  public List<ProcessCellProperty>? ProcessCellProperties{ get; set; }

}

public class CreateProcessCellResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
