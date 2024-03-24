// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator and factory in my humble opinion

namespace DotNetContactsApp.Objects.PasswordRule
{
    public class BasicPasswordComplexityRequirementFactory : PasswordRulesetFactory
    {
        public override PasswordStrengthVerificationRule create()
        {
            var baseRule = new PasswordStrengthVerificationRule();
            PasswordStrengthVerificationRule passwordLengthRule = new PasswordLengthRule(8, baseRule);

            char[] specialCharacters = "!@#$%^&*+=".ToCharArray();
            PasswordStrengthVerificationRule passwordSpecialCharRule = new PasswordComplexityRule(specialCharacters, "special characters", 1, passwordLengthRule);

            char[] upperCaseChars = "ABCDEFGHIJKLMNOPRSTUVWXYZ".ToCharArray();
            PasswordStrengthVerificationRule passwordUppercaseCharRule = new PasswordComplexityRule(upperCaseChars, "uppercase letters", 1, passwordSpecialCharRule);

            string[] whitespaces = [" ", "_", "-"];
            PasswordStrengthVerificationRule passwordForbiddenWhitespaces = new PasswordForbiddenSymbolsRule(whitespaces, "whitespaces", passwordUppercaseCharRule);

            string[] weakWords = ["password", "123"];
            PasswordStrengthVerificationRule passwordForbiddenWords = new PasswordForbiddenSymbolsRule(weakWords, "weak words", passwordForbiddenWhitespaces);

            return passwordForbiddenWords;
        }
    }
}

// I started the project by writing all my code in C# classes
// But then I discovered taht none of this is required with the Identity library
// This code not used for the project
// This is a very clever verification decorator and factory in my humble opinion
