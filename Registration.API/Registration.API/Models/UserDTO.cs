namespace Registration.API.Models
{
    internal record UserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDTO(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
