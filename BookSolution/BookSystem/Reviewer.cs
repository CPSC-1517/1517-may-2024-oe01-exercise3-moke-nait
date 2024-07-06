using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Reviewer
    {
        #region Data Members
        private string _FirstName;
        private string _LastName;
        private string _Organization;
        private string _Email;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name is required");
                }
                _FirstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name is required");
                }
                _LastName = value.Trim();
            }
        }

        public string Organization
        {
            get { return _Organization; }
            set
            {                
                _Organization = value?.Trim();
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required");
                }

                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                Regex regex = new Regex(emailPattern);

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Email is not an acceptable email address pattern");
                }
                _Email = value.Trim();
            }
        }

        public string ReviewerName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        #endregion

        #region Constructors
        public Reviewer (string firstname, string lastname, string email, string organization = null)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Organization = organization;
        }
        #endregion

        #region Methods
        public override string ToString() => $"{FirstName},{LastName},{Email},{Organization}";        
        #endregion
    }
    }
