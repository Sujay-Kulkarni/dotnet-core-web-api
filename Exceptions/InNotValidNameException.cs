using System;

namespace my_books.Exceptions
{
    [Serializable]
    public class InNotValidNameException : Exception
    {
        public string Name { get; set; }

        public InNotValidNameException() { }

        public InNotValidNameException(string message) : base(message) { }

        public InNotValidNameException(string message, Exception inner) : base(message, inner) { }

        public InNotValidNameException(string message, string name) : this(message)
        {
            Name = name;
        }
    }
}
