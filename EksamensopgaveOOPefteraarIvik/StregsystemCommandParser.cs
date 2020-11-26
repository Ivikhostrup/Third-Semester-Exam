using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.SystemUserInterface;

namespace EksamensopgaveOOPefteraarIvik
{
    public class StregsystemCommandParser
    {

        private IStregsystem Stregsystem;
        private IStregsystemUI Ui;

        public StregsystemCommandParser(IStregsystem stregsystem, IStregsystemUI ui)
        {
            Stregsystem = stregsystem;
            Ui = ui;
        }
        
        

    }
}