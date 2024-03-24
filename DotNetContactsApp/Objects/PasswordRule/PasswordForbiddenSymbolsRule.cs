// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion

namespace DotNetContactsApp.Objects.PasswordRule
{
    public class PasswordForbiddenSymbolsRule: PasswordStrengthVerificationRule
    {
        public PasswordStrengthVerificationRule LowerRule { get; set; }
        public string[] CannotBeIncluded { get; set; }
        public string StringType { get; set; }
    public PasswordForbiddenSymbolsRule(string[] strings, string stringTypeName, PasswordStrengthVerificationRule lowerRule)
        {
            this.CannotBeIncluded = strings;
            this.LowerRule = lowerRule;
            this.StringType = stringTypeName;
        }

        override
        public PasswordStrength evaluatePasswordStrength(PasswordStrength pass)
        {

            // Check if any forbidden string is included in the password
            foreach (string c in CannotBeIncluded)
            {
                if (pass.PlainTextPassword.Contains(c))
                {
                    pass.Strong = false;
                    pass.Message = $"password cannot contain {StringType}";
                    return pass;
                }

            }

            return LowerRule.evaluatePasswordStrength(pass);
        }
    }
}

// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion
