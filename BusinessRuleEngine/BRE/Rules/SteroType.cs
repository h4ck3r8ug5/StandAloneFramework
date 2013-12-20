using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace BRE.Rules
{
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    //public class EmailAddressFormatValidator : Attribute, Base.IIDefaultMembers
    //{
    //    public string Code
    //    {
    //        get
    //        {
    //            return (IsValid) ? Base.MessageType.MessageTypes.Information.ToString() : Base.MessageType.MessageTypes.Error.ToString();
    //        }
    //    }
    //    public string Message
    //    {
    //        get { return (IsValid) ? "Email address format is correct" : "Email address format is incorrect"; }
    //        set { }
    //    }

    //    public bool IsValid { get; set; }
    //    public void Validate(dynamic args)
    //    {
    //        const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
    //                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
    //                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    //        IsValid = Regex.IsMatch(args.ToString(), strRegex);
    //    }
    //}

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAddressFormatValidator : Attribute //, Base.IIDefaultMembers
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate(dynamic args)
        {

        }

        public EmailAddressFormatValidator(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void WriteEachPropertyInClass(Type t)
        {
            Console.WriteLine("Methods for Class {0}", t.Name); // write class name to console
            var properties = t.GetProperties(); // Get all the methods from the class using reflection
            foreach (var mi in properties)
            {
                var attrs = mi.GetCustomAttributes(false); // Get collection of custom attributes from the method
                foreach (var theStereotype in attrs.OfType<EmailAddressFormatValidator>())
                {
                    Console.WriteLine(theStereotype.Name);
                    Console.WriteLine(theStereotype.Description);

                }
            }
            var theConstructors = t.GetConstructors(); // do the same for the constructors of our class
            for (var i = 0; i < theConstructors.GetLength(0); i++)
            {
                var mi = theConstructors[i];
                var attrs = mi.GetCustomAttributes(false);
                foreach (var theStereotype in attrs.OfType<StereoType>())
                {
                    Console.WriteLine("{0} - {1},{2}", mi.Name, theStereotype.TheStereotypeName, theStereotype.TheDescription);
                }
            }
        }
    }
}
