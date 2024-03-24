namespace DotNetContactsApp.Objects.PasswordRule
{
    public class PasswordStrengthVerificationRule
    {
        virtual public PasswordStrength evaluatePasswordStrength(PasswordStrength pass)
        {
            return pass;
        }

    }
}

// Decorator core class
