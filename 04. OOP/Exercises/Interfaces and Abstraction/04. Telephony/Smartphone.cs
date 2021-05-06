using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class Smartphone:ICall,IBrowse
    {
        private string number;
        private string site;

        
        public string Number
        {
            get => this.number;
            set
            {
                if (value.Any(c => char.IsLetter(c)))
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.number = value;
            }
        }
        public string Site
        {
            get => this.site;
            set
            {
                if (value.Any(c => char.IsDigit(c)))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.site = value;
            }
        }

        public string Call()
        {
            return $"Calling... {this.Number}";
        }

        public string Browse()
        {
            return $"Browsing: {this.Site}!";
        }
    }
}
