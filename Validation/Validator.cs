using System;
using System.Text.RegularExpressions;

namespace PublishingHouse.Validation
{
    public static class Validator
    {
        public static void PasswordValidation(string password)
        {
            if (password == null) 
            {  
                throw new ArgumentNullException("Password is null"); 
            }

            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            bool isPasswordValid = hasSymbols.IsMatch(password) &&
                hasUpperChar.IsMatch(password) &&
                hasMinimum8Chars.IsMatch(password);

            if (!isPasswordValid) 
            {
                throw new Exception("Password must contain at least on special symbol, one uppercase letter and be at least 8 letters long");
            }
        }

        public static void LoginValidation(string login) 
        {
            if (login == null) 
            {
                throw new ArgumentNullException("Login is null");
            }

            if (login.Contains(' '))
            {
                throw new Exception("Login can't contain any whitespaces");
            }
        }

        public static void CreateBookDateValidation(DateTime date)
        {
            if (date > DateTime.Now) 
            {
                throw new Exception("Date cannot be set in the future");
            }
        }
    }
}
