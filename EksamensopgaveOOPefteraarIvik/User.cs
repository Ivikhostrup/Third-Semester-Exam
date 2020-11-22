using System;

namespace EksamensopgaveOOPefteraarIvik
{
    public class User : IComparable
    {
        // could probably make interface
        private int Id { get; }

        private string FirstName { get; }

        private string LastName { get; }

        private string UserName { get; }

        private string Email { get; }

        public decimal Balance { get; set; }

        public User(int id, string firstName, string lastName, string userName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            // If user object type is equal to the passed in object type, it should give false to move into else statement
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                // If they are the same type: Can safely typecast and do check
                // Note to self: May need to just check on ID since these should be unique
                User user = (User)obj;
                return (Id == user.Id && FirstName == user.FirstName && LastName == user.LastName &&
                        UserName == user.UserName && Email == user.Email);
            }
        }
        
        
        // Note to self - ReferenceEquals has trouble with value type
        public override int GetHashCode()
        {
            unchecked
            {
                // Select suitable prime numbers for hashing
                int hash = 13;
                // Nullity check; are two objects the same instance
                hash = (hash * 7) + (!ReferenceEquals(null, Id) ? Id.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, FirstName) ? FirstName.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, LastName) ? LastName.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, UserName) ? UserName.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, Email) ? Email.GetHashCode() : 0);

                return hash;
            }
        }

        public override string ToString()
        {
            return FirstName + LastName + Email;
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}