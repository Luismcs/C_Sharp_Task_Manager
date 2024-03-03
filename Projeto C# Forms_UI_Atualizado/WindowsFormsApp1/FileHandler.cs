using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class FileHandler
    {
        public static void adicionarListaTarefas()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"tarefas.txt");
            
            file.Close();
        }
    }
}
