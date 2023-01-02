using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OOP_Project
{
    class Validations
    {

        public bool ValidateName(string name)
        {

            if (Regex.IsMatch(name, "^[A-Z][a-zA-Z]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateNumber(string number)
        {
            if (Regex.IsMatch(number, @"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, @"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateCity(string city)
        {
            if (Regex.IsMatch(city, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateCountry(string country)
        {
            if (Regex.IsMatch(country, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class ValidationsController
    {
        Validations validation = new Validations();
        public void IsName(TextBox name, ErrorProvider error)
        {

            if (validation.ValidateName(name.Text))
            {
                error.Clear();
            }
            else
            {
                name.Focus();
                error.SetError(name, "Please Enter Correct Name!");
            }
        }

        public void IsNumber(TextBox number, ErrorProvider error)
        {
            if (validation.ValidateNumber(number.Text))
            {
                error.Clear();
            }
            else
            {
                number.Focus();
                error.SetError(number, "Please Enter Correct Number!");
            }
        }
        public void IsEmail(TextBox email, ErrorProvider error)
        {
            if (validation.ValidateEmail(email.Text))
            {
                error.Clear();
            }
            else
            {
                email.Focus();
                error.SetError(email, "Please Enter Correct Email!");
            }
        }
        public void IsCity(TextBox city, ErrorProvider error)
        {
            if (validation.ValidateCity(city.Text))
            {
                error.Clear();
            }
            else
            {
                city.Focus();
                error.SetError(city, "City Name Should Contain Only Letters!");
            }
        }

        public void IsCountry(TextBox country, ErrorProvider error)
        {
            if (validation.ValidateCountry(country.Text))
            {
                error.Clear();
            }
            else
            {
                country.Focus();
                error.SetError(country, "Country Name Should Contain Only Letters!");
            }
        }
    }
}
