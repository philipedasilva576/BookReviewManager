namespace BookReviewManager.Application.Models
{
    public class LoginVM
    {
        public LoginVM(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
   
}
