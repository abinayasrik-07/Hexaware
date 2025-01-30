using System;
using TechShop.Exceptions;

namespace TechShop.Repository
{
    internal interface ISecurityRepository
    {
        public void AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new AuthenticationException("Invalid credentials.");

            Console.WriteLine("User authenticated successfully.");
        }

        public void AuthorizeAccess(bool hasAccess)
        {
            if (!hasAccess)
                throw new AuthorizationException("You do not have the required permissions.");
        }
    }
}
