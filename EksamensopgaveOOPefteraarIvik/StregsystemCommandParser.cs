using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EksamensopgaveOOPefteraarIvik.Stregsystem;
using EksamensopgaveOOPefteraarIvik.SystemUserInterface;

namespace EksamensopgaveOOPefteraarIvik
{
    public class StregsystemCommandParser
    {
        
        // TODO Currently not parsing in inactive products - needs fix
        
        private IStregsystem Stregsystem;
        private IStregsystemUI Ui;
        
        public StregsystemCommandParser(IStregsystem stregsystem, IStregsystemUI ui)
        {
            Stregsystem = stregsystem;
            Ui = ui;
        }


        public void addCommands()
        {
            // This dictionary is administration commands
            // https://stackoverflow.com/questions/22599425/how-to-map-strings-to-methods-with-a-dictionary
            Dictionary<string, Action> adminCommands = new Dictionary<string, Action>()
            {
                { ":quit", () => Ui.Close() },
                { ":q", () => Ui.Close() }
                
            };


        }
        
        
        


        public void Quit()
        {
            Ui.Close();
        }
        
        
    }
}