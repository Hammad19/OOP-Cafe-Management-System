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

        public void IsName(TextBox name, ErrorProvider error)
        {

            if (Regex.IsMatch(name.Text, "^[A-Z][a-zA-Z]*$"))
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
            if (Regex.IsMatch(number.Text, @"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$"))
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
            if (Regex.IsMatch(email.Text, @"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$"))
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
            if (Regex.IsMatch(city.Text, @"^[a-zA-Z]+$"))
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
            if (Regex.IsMatch(country.Text, @"^[a-zA-Z]+$"))
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
