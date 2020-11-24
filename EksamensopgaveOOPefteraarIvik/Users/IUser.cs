namespace EksamensopgaveOOPefteraarIvik.Users
{
    public interface IUser
    {
        uint MyId { get; }
        string FirstName { get; }
        string LastName { get; }
        string UserName { get; }
        string Email { get; }
        decimal Balance { get; set; }
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
        
    }
}