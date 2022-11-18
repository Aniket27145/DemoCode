namespace Filterdemo1.Models
{
    public class Users
    {
        public string Username { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public IEnumerable<Users>GetUsers()
        {
            return new List<Users>()
            {
                new Users {Username="cybage", Password="cybage@123"},
                new Users {Username="Mrunal" ,Password ="Mrunal@123"}
            };
        }
    }
}
