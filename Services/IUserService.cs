namespace EmployeeWebAPIforJWTtoken.Services
{
    public interface IUserService
    {
        object ClaimsType { get; }
        string GetuserId { get; }
    }
}