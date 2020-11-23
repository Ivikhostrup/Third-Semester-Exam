using System;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Exceptions;

namespace EksamensopgaveOOPefteraarIvik.Users
{
    public class User : IUser, IComparable<IUser>
    {
        // could probably make interface
        // Static int to maintain which count the current ID has across all instances of class
        private static int IdCount = 0;
        public int MyId { get; private set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string UserName { get; }

        public string Email { get; }

        public decimal Balance { get; set; }
        
        // Interlocked.Increment safeguards against multiple concurrent updates to MyID
        public User(string firstName, string lastName, string userName, string email)
        {
            MyId = Interlocked.Increment(ref IdCount);
            FirstName = firstName ?? throw new UserInformationNullExceptions("Must have first name");
            LastName = lastName ?? throw new UserInformationNullExceptions("Must have last name");
            UserName = userName ?? throw new UserInformationNullExceptions("Must have a username");
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
                return (FirstName == user.FirstName && LastName == user.LastName &&
                        UserName == user.UserName && Email == user.Email);
            }
        }
        
        // TODO Hashcode will no longer deal with null - Update this
        public override int GetHashCode()
        {
            // Unchecked to suppress overflow-checking
            unchecked
            {
                // Select suitable prime numbers for hashing
                int hash = 13;
                // Nullity check; are two objects the same instance
                hash = (hash * 7) + (!ReferenceEquals(null, MyId) ? MyId.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, UserName) ? UserName.GetHashCode() : 0);
                hash = (hash * 7) + (!ReferenceEquals(null, Email) ? Email.GetHashCode() : 0);

                return hash;
            }
        }

        public override string ToString()
        {
            return FirstName + LastName + Email;
        }

        public int CompareTo(IUser other)
        {
            if (this.MyId < other.MyId)
            {
                return -1;
            }
            else if (this.MyId == other.MyId)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        
        // TODO Event for checking balancing - warn when below 50 kroner and for every subsequent purchase. Make delegate: UserBalanceNotification
    }
}