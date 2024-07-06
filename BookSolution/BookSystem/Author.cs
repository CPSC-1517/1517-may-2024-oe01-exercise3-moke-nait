using System.Text.RegularExpressions;


namespace BookSystem
{
    public class Author
    {
        #region Data Members
        private string _FirstName;
        private string _LastName;
        private string _ResidentCity;
        private string _ResidentCountry;
        private string _ContactUrl;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname is required");
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
                    throw new ArgumentException("Lastname is required");
                }
                _LastName = value.Trim();
            }
        }

        public string ResidentCity
        {
            get { return _ResidentCity; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Resident city is required");
                }
                _ResidentCity = value.Trim();
            }
        }

        public string ResidentCountry
        {
            get { return _ResidentCountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Resident country is required");
                }
                _ResidentCountry = value.Trim();
            }
        }

        public string ContactUrl
        {
            get { return _ContactUrl; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Contact URL is required");
                }

                string pattern = @"^(https?://)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}(\/\S*)?$";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Contact URL does not have an acceptable url pattern");
                }
                _ContactUrl = value.Trim();
            }
        }

        public string AuthorName
        {
            get
            { return $"{LastName}, {FirstName}"; }
        }
        #endregion

        #region Constructors
        public Author (string firstname, string lastname, string contacturl, string city, string country)
        {
            FirstName = firstname;
            LastName = lastname;
            ContactUrl = contacturl;
            ResidentCity = city;
            ResidentCountry = country;
        }
        #endregion

        #region Methods
        public override string ToString() => $"{FirstName},{LastName},{ContactUrl},{ResidentCity},{ResidentCountry}";
        #endregion
    }
}
