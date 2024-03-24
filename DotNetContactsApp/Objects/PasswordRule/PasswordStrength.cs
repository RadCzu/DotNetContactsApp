namespace DotNetContactsApp.Objects.PasswordRule
{
    public struct PasswordStrength
    {
        public readonly string PlainTextPassword { get; }
        public bool Strong { get; set; }

        public string Message { get; set; }

        public PasswordStrength(string password)
        {
            PlainTextPassword = password;
            Strong = false;
            Message = "";
        }
    }
}


// This struct was supposed to be used to verify password strength
