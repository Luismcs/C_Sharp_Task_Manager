using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form 
    {
        private List<Tarefa> listaTarefasForm2;
        public Form2(List<Tarefa> lista,int counter) //gets the task list
        {
            InitializeComponent();
            listaTarefasForm2 = lista; //gets the task list

            //Removes Top tight form buttons
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Adds the new task to the file without deleting the existing content
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"tarefas.txt",true);
            int counter = 0;
            foreach(Tarefa ta in listaTarefasForm2)
            {
                counter=int.Parse(ta.Id);
            }

            string text;

            //Trims the ComboBox Text so it doesn't have white spaces
            if (comboBox1.Text == "Não Concluída")
            {
                text = "NãoConcluída";
            }
            else
            {
                text = "Concluída";
            }

            string task = (counter+1).ToString()+" "+textBox1.Text+" "+text;
            file.WriteLine(task);
            file.Close(); 
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1 ();
            form.Show();
        }
    }
}
