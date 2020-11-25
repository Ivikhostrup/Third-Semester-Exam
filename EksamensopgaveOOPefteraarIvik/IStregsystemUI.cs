using EksamensopgaveOOPefteraarIvik.Products;
using EksamensopgaveOOPefteraarIvik.Users;

namespace EksamensopgaveOOPefteraarIvik
{
    public interface IStregsystemUI
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotfound(string product);
        void DisplayUserInfo(IUser user);
        void DisplayTooManyArguementsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void DisplayUserBuysProduct(ITransaction transaction);
        void Close();
        void DisplayInsufficientCash(IUser user, IProductBase product);
        void DisplayGeneralError(string errorString);
    }
}