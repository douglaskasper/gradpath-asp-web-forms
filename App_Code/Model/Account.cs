using GradPath.App_Code.Model.Support;

namespace GradPath.App_Code.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public string Role { get; set; }
    }
}