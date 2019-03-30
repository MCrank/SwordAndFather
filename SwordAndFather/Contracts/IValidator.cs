namespace SwordAndFather.Contracts
{
    public interface IValidator<TToValidate>
    {
        bool Validate(TToValidate objectToValidate);
    }
}