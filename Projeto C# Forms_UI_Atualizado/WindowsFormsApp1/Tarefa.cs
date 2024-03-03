using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Tarefa
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }

        public Tarefa(string id,string descricao,string estado) { 
            Id= id;
            Descricao = descricao;
            Estado = estado;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Description: " + Descricao + " State: " + Estado;
        }

    }
}
