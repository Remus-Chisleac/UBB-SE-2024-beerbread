using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.MVVM.ViewModel
{
    public interface ICreateArtistAccountViewModel
    {
        bool IsNameValid(string name);
        bool IsUsernameValid(string username);
        bool IsCountryValid(string country);
        bool IsBirthDateValid(string birthDate);
        bool IsEmailValid(string email);
        bool IsPasswordValid(string password);
    }
    public class CreateArtistAccountViewModel : ICreateArtistAccountViewModel
    {
        public bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }

        public bool IsUsernameValid(string username)
        {
            if (username.Length < 6)
                return false;
            return true;
        }

        public bool IsCountryValid(string country)
        {
            return !string.IsNullOrEmpty(country) && country.All(char.IsLetter);
        }

        public bool IsBirthDateValid(string dateOfBirth)
        {
            // Split the input date by "/"
            string[] dateParts = dateOfBirth.Split('/');

            // Check if there are exactly three parts (day, month, year)
            if (dateParts.Length != 3)
            {
                // Invalid date format
                return false;
            }

            // Validate day
            if (!int.TryParse(dateParts[0], out int day) || day < 1 || day > 31)
            {
                // Invalid day
                return false;
            }

            // Validate month
            if (!int.TryParse(dateParts[1], out int month) || month < 1 || month > 12)
            {
                // Invalid month
                return false;
            }

            // Validate year
            if (!int.TryParse(dateParts[2], out int year) || year < 1990 || year > 2023)
            {
                // Invalid year
                return false;
            }

            // Date format is valid
            return true;
        }

        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && (email.EndsWith("@gmail.com") || email.EndsWith("@yahoo.com"));
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
                return false;
            return true;
        }
    }
}
