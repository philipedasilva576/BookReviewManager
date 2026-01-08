namespace BookReviewManager.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string email, string name):base()
        {
            SetEmail(email);
            SetName(name);
        }

        public string Email { get; private set; }
        public string Name { get; private set; }
        private readonly List<Review> _reviews = new();
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

        private void SetEmail(string email)
        {
            Email = email.Trim().ToLower();
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
