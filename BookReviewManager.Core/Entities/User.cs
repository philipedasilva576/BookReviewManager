namespace BookReviewManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string email, string name, string password, string role):base()
        {
            SetEmail(email);
            SetName(name);
            SetRole(role);
            SetPassword(password);
        }

        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        private readonly List<Review> _reviews = new();
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

        private void SetEmail(string email)
        {
            Email = email.Trim().ToLower();
        }
        private void SetPassword(string password)
        {
            Password = password;
        }
        private void SetRole(string role)
        {
            Role = role;
        }
        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
        private void SetName(string name)
        {
            Name = name.Trim();
        }
    }
}
