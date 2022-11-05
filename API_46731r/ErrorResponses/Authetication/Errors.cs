namespace API_46731r.ErrorResponses.Authetication
{
    public class Errors
    {
        public List<string> Password { get; set; }

        public List<string> Email { get; set; }

        public void AddEmailError(string error)
        {
            if(Email is null)
            {
                Email = new List<string>();
            }

            Email.Add(error);

        }

        public void AddPasswordError(string error)
        {
            if (Password is null)
            {
                Password = new List<string>();
            }

            Password.Add(error);

        }
    }
}
