namespace testcsharpschmvc.Models
{
    public class SigninViewModel
    {
        public bool IsUserLogged { get; set; }
        public string Username { get; set; }

        public SigninViewModel()
        {
            IsUserLogged = false;
        }

        public SigninViewModel(string username)
        {
            IsUserLogged = true;
            Username = username;
        }
    }
}
