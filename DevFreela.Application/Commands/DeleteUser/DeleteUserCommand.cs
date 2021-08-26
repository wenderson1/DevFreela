using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
