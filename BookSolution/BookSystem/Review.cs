using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Review
    {
        #region Data Members
        private string _Author;
        private string _Comment;
        private string _ISBN;
        private string _Reviewer;
        private string _Title;
        #endregion

        #region Properties
        public string Author
        {
            get { return _Author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author is required");
                }
                _Author = value;
            }
        }
        public string Comment
        {
            get { return _Comment; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Comment is required");
                }
                _Comment = value;
            }
        }

        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN is required");
                }
                _ISBN = value;
            }
        }

        public RatingType Rating
        {
            get; set;
        }

        public string Reviewer
        {
            get { return _Reviewer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Reviewer is required");
                }
                _Reviewer = value;
            }
        }
        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title is required");
                }
                _Title = value;
            }
        }
        #endregion

        #region Constructors
        public Review(string isbn, string title, string author, string reviewer, RatingType rating, string comment)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }
        #endregion

        #region Methods
        public override string ToString() => $"{ISBN},{Title},{Author},{Reviewer},{Rating},{Comment}";

        public static Review Parse(string text)
        {
            string[] parts = text.Split(',');

            if (parts.Length != 6)
            {
                throw new FormatException($"String not in the expected format. Missing or excessive value(s): {text}");
            }
            if (!Enum.TryParse(parts[4], out RatingType rating))
            {
                throw new FormatException($"Invalid rating type: {parts[4]}");
                //parts = new string[5];
            }
            return new Review(parts[0], parts[1], parts[2], parts[3], rating, parts[5]);
        }

        #endregion
    }
}
