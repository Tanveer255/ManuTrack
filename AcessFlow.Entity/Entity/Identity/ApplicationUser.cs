namespace AcessFlow.Entity.Entity.Identity;

    public class ApplicationUser : IdentityUser
    {
    public ApplicationUser()
    {
        Id = Guid.NewGuid().ToString(); // Use Guid instead of string
    }

    public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; } = new byte[0];

    }

