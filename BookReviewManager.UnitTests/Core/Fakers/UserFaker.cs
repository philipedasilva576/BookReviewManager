using Bogus;
using BookReviewManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.UnitTests.Core.Fakers
{
    public static class UserFaker
    {
        public static Faker<User> Create()
        {
            return new Faker<User>()
                .CustomInstantiator(f =>
                {
                    var password = f.Internet.Password(8, false);
                    var passwordHash = GenerateFakeHash(password);

                    return new User(
                        email: f.Internet.Email(),
                        name: f.Name.FullName(),
                        password: passwordHash,
                        role: f.PickRandom("Admin", "User")
                    );
                });
        }

        private static string GenerateFakeHash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
