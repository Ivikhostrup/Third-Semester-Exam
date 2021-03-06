﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using EksamensopgaveOOPefteraarIvik.Exceptions;

namespace EksamensopgaveOOPefteraarIvik.Users
{
    public delegate void BalanceChangedWatcher(decimal balance);
    
    public class User : IUser, IComparable<IUser>
    {
        // Static int to maintain which count the current ID has across all instances of class
        private const decimal threshold = 50;
        public uint MyId { get; private set; }

        public string FirstName { get; }

        public string LastName { get; }

        public string UserName { get; }

        public string Email { get; }

        private decimal balance;
        public decimal Balance
        {
            get => balance;
            set
            {
                balance = value;
                
                if (balance < threshold)
                {
                    BalanceLow?.Invoke(balance);
                }
            }
        }

        public List<ITransaction> Log { get; set; }

        public event BalanceChangedWatcher BalanceLow;

        public User(char separator, string csvLine)
        {
            string[] fields = csvLine.Split(separator);

            MyId = uint.Parse(fields[0]);
            FirstName = fields[1];
            LastName = fields[2];
            UserName = fields[3];
            Balance = decimal.Parse(fields[4]);
            Email = fields[5];
        }
        public User(uint myId, string firstName, string lastName, string userName, decimal balance, string email)
        {
            MyId = myId;
            FirstName = firstName ?? throw new UserInformationNullExceptions("Must have first name");
            LastName = lastName ?? throw new UserInformationNullExceptions("Must have last name");
            UserName = userName ?? throw new UserInformationNullExceptions("Must have a username");
            Email = IsValidEmail(email) ? email : throw new UserInformationNullExceptions("Invalid email address");
            Balance = balance;
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
                User user = (User)obj;
                return (FirstName == user.FirstName && LastName == user.LastName &&
                        UserName == user.UserName && Email == user.Email);
            }
        }
        
        public override int GetHashCode()
        {
            // Unchecked to suppress overflow-checking
            unchecked
            {
                // Select suitable prime numbers for hashing
                int hash = 13;
                
                hash = (hash * 7) + MyId.GetHashCode();
                hash = (hash * 7) + UserName.GetHashCode();
                hash = (hash * 7) + Email.GetHashCode();

                return hash;
            }
        }

        public override string ToString()
        {
            return $"Your first name: {FirstName}, your last name: {LastName}, and your email: {Email} and your balance: {balance}";
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
        
        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }        
    }
}