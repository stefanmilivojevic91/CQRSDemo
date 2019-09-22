using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Commands
{
    public class UpdateUserCommand : ICommand<string>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
