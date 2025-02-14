namespace UserMicroservice.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? LoginTime { get; set; }

        // En bruger kan have mange lokationer
        public ICollection<Location> Locations { get; set; } = new List<Location>();

        // Constructor til at oprette en ny bruger
        public User(string username, string password, string firstname, string lastname, string email)
        {
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        // Parameterløs constructor til EF Core (ORM)
        public User() { }
    }
}