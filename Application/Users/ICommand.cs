using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users
{
    public interface ICommand<T>
    {
        T Id { get; set; }
    }
}
