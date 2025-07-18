using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Employee.Command.Update;

public class UpdateEmployeeHandler: IRequestHandler<UpdateEmployeeCommand.Request,UpdateEmployeeCommand.Response>
{
    private readonly IRepository<Trendo.Domain.Entities.Security.Employee> _repository;

    public UpdateEmployeeHandler(IRepository<Trendo.Domain.Entities.Security.Employee> repository)
    {
        _repository = repository;
    }
    public  async Task<UpdateEmployeeCommand.Response> Handle(UpdateEmployeeCommand.Request request, CancellationToken cancellationToken)
    {
      var employee = await _repository.Query()
          .FirstOrDefaultAsync(e => e.Id == request.Id );
      if (employee == null)
      {
          return new UpdateEmployeeCommand.Response
          {
              Success = false,
            Message = "No employee found with id {request.Id}"
          };
      }
      _repository.Update(employee);
      return new UpdateEmployeeCommand.Response
      {
          Success = true,
          Message = "Employee updated"
      };

    }
}