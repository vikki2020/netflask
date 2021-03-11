using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Decorator;

namespace NetFlask.Models
{
    [AtLeastOneProperty("Phone", "Mobile", ErrorMessage = "You must supply at least one value")]
    public class UserModel
    {
        int _idUser;
        string _firstName, _lastName, _login, _password, _confirmPassword;
        string _webSite, _twitter, _instagram, _facebook, _email, _phone, _mobile, _country, _city, _picture;
        public int IdUser
        {
            get
            {
                return _idUser;
            }

            set
            {
                _idUser = value;
            }
        }
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        [Required]
        [MaxLength(50)]
        public string Password
        {
            get 
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        [Required]
        [MaxLength(50)]
        [Compare("Password",ErrorMessage ="No Matching Password")]
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
            }
        }
        [DataType(DataType.Url)]
        [Url]
        public string WebSite
        {
            get
            {
                return _webSite;
            }

            set
            {
                _webSite = value;
            }
        }
        [DataType(DataType.Url)]
        [Url]
        public string Twitter
        {
            get
            {
                return _twitter;
            }

            set
            {
                _twitter = value;
            }
        }
        [DataType(DataType.Url)]
        [Url]
        public string Instagram
        {
            get
            {
                return _instagram;
            }

            set
            {
                _instagram = value;
            }
        }
        [DataType(DataType.Url)]
        [Url]
        public string Facebook
        {
            get
            {
                return _facebook;
            }

            set
            {
                _facebook = value;
            }
        }
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
        
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public string Mobile
        {
            get
            {
                return _mobile;
            }

            set
            {
                _mobile = value;
            }
        }
        [Required]
        
        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }
        [Required]
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }
        
        public string Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }
    }
}
