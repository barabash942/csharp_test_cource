using System;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactDetails;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
        }

        public ContactData(string allContactDetails)
        {
            AllContactDetails = allContactDetails;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones 
        { get { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set {
                allPhones = value;
            } 
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (MakeEmailToConcat(Email) + MakeEmailToConcat(Email2) + MakeEmailToConcat(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllContactDetails
        {
            get
            {
                if (allContactDetails != null || allContactDetails != "")
                {
                    return allContactDetails;
                }
                else
                {
                    allContactDetails = "";
                    if (FirstName == null || FirstName == "")
                    {
                        allContactDetails += FirstName + " ";
                    }

                    if (LastName == null || LastName == "")
                    {
                        allContactDetails += LastName + "\r\n";
                    }

                    if (Address == null || Address == "")
                    {
                        allContactDetails += Address + "\r\n\r\n";
                    }

                    if (HomePhone == null || HomePhone == "")
                    {
                        allContactDetails += "H: " + HomePhone + "\r\n";
                    }

                    if (MobilePhone == null || MobilePhone == "")
                    {
                        allContactDetails += "M: " + MobilePhone + "\r\n";
                    }

                    if (WorkPhone == null || WorkPhone == "")
                    {
                        allContactDetails += "W: " + WorkPhone + "\r\n";
                    }

                    if (Email == null || Email == "")
                    {
                        allContactDetails += Email + "\r\n";
                    }

                    if (Email2 == null || Email2 == "")
                    {
                        allContactDetails += Email2 + "\r\n";
                    }

                    if (Email3 == null || Email3 == "")
                    {
                        allContactDetails += Email3;
                    }

                    return allContactDetails.Trim();
                }
            }
            set
            {
                allContactDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        private string MakeEmailToConcat(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        private string DisplayName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return
                LastName.CompareTo(other.LastName) != 0
                    ? LastName.CompareTo(other.LastName)
                    : FirstName.CompareTo(other.FirstName);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return LastName == other.LastName && FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            return DisplayName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName = " + FirstName + "\nLastName= " + LastName;
        }
    }
}
