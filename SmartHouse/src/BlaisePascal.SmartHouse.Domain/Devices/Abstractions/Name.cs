using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstractions
{
    public class Name
    {
        public string value { get; set; }
        
        public Name(string name) 
        { 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            else if (name.Length < 3 )
            {                 
                throw new ArgumentException($"Name must be at least {3} characters long.", nameof(name));
            }
            else if (name.Length > 50)
            {
                throw new ArgumentException("Name cannot exceed 50 characters.", nameof(name));
            }
            else if (!string.IsNullOrEmpty(name) && char.IsLetter(name[0]) && char.IsUpper(name[0]))
            {
                value = name;
            }
            else
            {
                throw new ArgumentException("Name must start with an uppercase letter.", nameof(name));
            }

        }

        public static implicit operator string(Name v)
        {
            throw new NotImplementedException();
        }
    }
}
