// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion

namespace DotNetContactsApp.Objects.PasswordRule
{
    public class PasswordComplexityRule: PasswordStrengthVerificationRule
    {
        public PasswordStrengthVerificationRule LowerRule { get; set; }
        public char[] MustBeIncluded { get; set; }
        public int AmountRequired { get; set; }

        public string CharTypeName {  get; set; }
        public PasswordComplexityRule(char[] chars, string charTypeName ,int amountRequired,  PasswordStrengthVerificationRule lowerRule)
        {
            this.MustBeIncluded = chars;
            this.LowerRule = lowerRule;
            this.AmountRequired = amountRequired;
            this.CharTypeName = charTypeName;
        }

        override
        public PasswordStrength evaluatePasswordStrength(PasswordStrength pass)
        {
            int includedCount = 0;

            // Count required characters present in the password
            foreach (char letter in pass.PlainTextPassword)
            {
                if (MustBeIncluded.Contains(letter))
                {
                    includedCount++;
                }
            }

            // Check if the number of included characters meets the requirement
            if (includedCount < AmountRequired)
            {
                pass.Message = $"password needs to contain at least {AmountRequired} {CharTypeName}";
                pass.Strong = false;
                return pass;
            } else
            {
                return LowerRule.evaluatePasswordStrength(pass);
            }
        }
    }
}

// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator in my humble opinion