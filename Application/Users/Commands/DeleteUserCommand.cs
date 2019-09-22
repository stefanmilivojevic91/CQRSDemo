using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Commands
{
    public class DeleteUserCommand : ICommand<string>
    {
        public string Id { get; set; }
    }
}
