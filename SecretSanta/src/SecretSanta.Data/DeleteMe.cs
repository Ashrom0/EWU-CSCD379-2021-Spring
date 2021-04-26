using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class DeleteMe
    {
        public static List<User> Users { get; } = new()
        {
            new User() { Id = 1, FirstName = "Keith", LastName = "Emerson" },
            new User() { Id = 2, FirstName = "Ray", LastName = "Manzarek" },
            new User() { Id = 3, FirstName = "Rick", LastName = "Wakeman" }
        };
    }
}