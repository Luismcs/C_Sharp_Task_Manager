using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private List<Tarefa> listaTarefasForm2;

        public Form3(List<Tarefa> lista) //receives the task list
        {
            InitializeComponent();
            listaTarefasForm2 = lista;
            ShowTaskList();

            //Removes Top right form buttons
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = Form3lbl1.Text;

            //Searchs in the list for the task with the same number that the user inserted
            foreach(Tarefa tarefa in listaTarefasForm2)
            {
                //if the Id is found changes the Task State on the list
                if (tarefa.Id == id)
                {
                    tarefa.Estado = "Concluida";
                    break;
                }
            }
            //updates the .txt file
            atualizaFicheiro(); //updates the file
            Form1 form = new Form1();
            form.Show();
        }

        private void atualizaFicheiro()
        {
            //Creates a new StreamWriter
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"tarefas.txt");
            file.WriteLine("ID Descricao Estado");

            //copies the list to the file
            foreach(Tarefa ta in listaTarefasForm2)
            {
                string message = ta.Id + " " + ta.Descricao + " " + ta.Estado;
                file.WriteLine(message);
            }

            //closes the file and the form
            file.Close();
            this.Close();
        }

        private void ShowTaskList()
        {
            //Clears the list
            //Reads from the file adding the Header and The content to the task DataGridView
            listaTarefasForm2.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"tarefas.txt");
            string[] columnnames = file.ReadLine().Split(' ');

            DataTable dt = new DataTable();

            //Adds the Header to the Table
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;


            //Adds the lines to the Table and Updates the Task List
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                string id = values[0];
                string descricao = values[1];
                string estado = values[2];

                //Adds the Task to the Task List
                Tarefa tarefa = new Tarefa(id, descricao, estado);
                listaTarefasForm2.Add(tarefa);

                //Adds the new line to the Table
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();

            // Set AllowUserToAddRows property to false
            Form3_dataGridView1.AllowUserToAddRows = false;

            // Assign the DataTable as the DataSource of the DataGridView
            Form3_dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
