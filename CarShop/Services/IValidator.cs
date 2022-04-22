using System.Collections.Generic;
using CarShop.Models.Cars;
using CarShop.Models.Issues;
using CarShop.Models.Users;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateCar(AddCarFormModel model);

        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
