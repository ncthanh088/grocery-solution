using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Grocery.Application.Categories.Commands
{
    public class CreateCategoryCommand :  IRequest<bool>
    {
        
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}