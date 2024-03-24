
// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion

namespace DotNetContactsApp.Objects.PasswordRule
{
    public class PasswordLengthRule: PasswordStrengthVerificationRule
    {
        public PasswordStrengthVerificationRule lowerRule { get; set; }
        public int MinimumLength { get; set; }
        public PasswordLengthRule(int minimumLength, PasswordStrengthVerificationRule lowerRule) 
        {
            this.MinimumLength = minimumLength;
            this.lowerRule = lowerRule;
        }

        override
        public PasswordStrength evaluatePasswordStrength(PasswordStrength pass)
        {
            if(pass.PlainTextPassword.Length <  MinimumLength)
            {
                pass.Strong = false;
                return pass;
            } else
            {
                return lowerRule.evaluatePasswordStrength(pass);
            }
        }
    }
}


// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion
