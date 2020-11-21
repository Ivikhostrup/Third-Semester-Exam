namespace EksamensopgaveOOPefteraarIvik
{
    public class User
    {
        // could probably make interface
        private int Id { get; set; }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        private string UserName { get; set; }

        private string Email { get; set; }

        public decimal Balance { get; set; }

        public User(int id, string firstName, string lastName, string userName, string email)
        {
            Id += id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return FirstName + LastName + Email;
        }
    }
}