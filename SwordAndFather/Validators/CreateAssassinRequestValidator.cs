using SwordAndFather.Contracts;
using SwordAndFather.Models;

namespace SwordAndFather.Validators
{
    public class CreateAssassinRequestValidator : IValidator<CreateAssassinRequest>
    {
        public bool Validate(CreateAssassinRequest request)
        {
            return !(string.IsNullOrEmpty(request.CatchPhrase) ||
                    string.IsNullOrEmpty(request.CodeName) ||
                    string.IsNullOrEmpty(request.PreferredWeapon));
        }
    }
}