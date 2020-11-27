using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik.SystemUserInterface
{
    public interface IStregsystemUI
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotfound(string product);
        void DisplayUserInfo(IUser user);
        void DisplayTooManyArguementsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(IUser user, IProductBase product, int count);
        void DisplayUserBuysProduct(IUser user, IProductBase product);
        void Close();
        void DisplayInsufficientCash(IUser user, IProductBase product);
        void DisplayGeneralError(string errorString);
        void Start();
        
        event UserCommandWatcher CommandEntered;
        
    }
}