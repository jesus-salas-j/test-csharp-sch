namespace testcsharpschmvc.Models
{
    public class AppViewModel
    {
        public string Username { get; set; }

        public AppViewModel(string username)
        {
            Username = username;
        }
    }
}
