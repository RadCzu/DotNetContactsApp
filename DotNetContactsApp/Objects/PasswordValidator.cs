using DotNetContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetContactsApp.Objects
{
    // This piece of code is useless and unused in the project. But I made it at the beggining, being not aware of how the Identity will work.
    // I started the project by writing all my code in C# classes
    // But then I discovered taht none of this is required with the Identity library
    // This code not used for the project

    public class PasswordValidator
    {
        private DbContext _dbContext;
        private IHashStrategy _hasher;

        public PasswordValidator(DbContext dbContext, IHashStrategy hashStrategy)
        {
            _dbContext = dbContext;
            _hasher = hashStrategy;
        }

        public async Task<bool> VerifyPasswordAsync(int userId, string password)
        {
            var hash = _hasher.run(password);

            // Use a raw SQL query to retrieve the hashed password from the database since im using SQLite and it does not have custom Functions
            // Im also using a Password object for it, which I am aware is weird. Im using the password hash field as a transport for the response.
            // Visual studio told me that it is protected against SQL injection.
            /*
            var result = await _dbContext.Set<Password>()
                .FromSql($"SELECT CASE WHEN PasswordHash = {hash} THEN '1' ELSE '0' END AS PasswordHash FROM Password WHERE UserId = {userId}")
                .FirstOrDefaultAsync();

            // Compare the provided password with the stored hash as validation result
            return result.PasswordHash == "1";
            */
            return true;
        }
    }
}

    // I started the project by writing all my code in C# classes
    // But then I discovered taht none of this is required with the Identity library
    // This code not used for the project