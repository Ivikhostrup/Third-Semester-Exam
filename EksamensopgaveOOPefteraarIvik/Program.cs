using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.SystemUserInterface;

namespace EksamensopgaveOOPefteraarIvik
{
    class Program
    {
        static void Main(string[] args)
        {
            IStregsystem stregsystem = new Stregsystem.Stregsystem();
            IStregsystemUI ui = new StregsystemCli(stregsystem);
            
            ui.Start();
        }
    }
}