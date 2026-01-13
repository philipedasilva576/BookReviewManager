namespace BookReviewManager.Infrastructure.Auth
{
    public interface IAuthService
    {
        string ComputeHash(string password);
        string GenereteToken(string email, string role);
    }
}
