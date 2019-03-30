using SwordAndFather.Models;

namespace SwordAndFather.Validators
{
    public class CreateUserRequestValidator
    {
        public bool Validate(CreateUserRequest requestToValidate)
        {
            return string.IsNullOrEmpty(requestToValidate.UserName)
                || string.IsNullOrEmpty(requestToValidate.Password);
        }
    }
}