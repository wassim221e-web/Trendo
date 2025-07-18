using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Employee.Command.Delete;

public class DeleteEmployeeHandler:IRequestHandler<DeleteEmployeeCommand.Request, DeleteEmployeeCommand.Response>
{
    private readonly IRepository<Trendo.Domain.Entities.Security.Employee> _repository;

    public DeleteEmployeeHandler(IRepository<Trendo.Domain.Entities.Security.Employee> repository)
    {
        _repository = repository;
    }
    public async Task<DeleteEmployeeCommand.Response> Handle(DeleteEmployeeCommand.Request request, CancellationToken cancellationToken)
    {
        var employee =await  _repository.Query()
            .FirstOrDefaultAsync(e => e.Id == request.Id);
        if (employee == null)
        {
            
            return new DeleteEmployeeCommand.Response
            {
                Success = false,
                Message = "الموظف غير موجود"
            };
        }
        _repository.Delete(employee);
        return new DeleteEmployeeCommand.Response
        {

            Success = true,
            Message = "تم حذفه بنجاح "
        };


    }
}