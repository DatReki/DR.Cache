using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRN_Testing
{
    internal class Data
    {
        internal static readonly User s_user = new()
        {
            FirstName = "John",
            LastName = "Rogers",
            DateOfBirth = 1993
        };

        internal static readonly Data.User s_updatedUser = new Data.User()
        {
            FirstName = "David",
            LastName = Data.s_user.LastName,
            DateOfBirth = Data.s_user.DateOfBirth
        };

        internal partial class User
        {
            internal string FirstName { get; set; } = string.Empty;
            internal string LastName { get; set; } = string.Empty;
            internal string FullName { get; private set; }
            internal int DateOfBirth { get; set; }
            internal int Age { get; private set; }

            internal User()
            {
                FullName = $"{FirstName} {LastName}";
                Age = DateTime.UtcNow.Year - DateOfBirth;
            }
        }
    }
}
