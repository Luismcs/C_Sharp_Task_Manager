using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private List<Tarefa> listaTarefasForm4;
        public Form4(List<Tarefa> lista) //gets the task list
        {
            InitializeComponent();
            listaTarefasForm4 = lista; //gets the task list
            ShowTaskList();

            //Removes Top right form buttons
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Searches for the Id in the Task List
            foreach(Tarefa tarefa in listaTarefasForm4)
            {
                //If there is a rask with the same Id then Removes the Task from the Task List
                if(Form4_txtbox1.Text==tarefa.Id)
                {
                    listaTarefasForm4.Remove(tarefa);
                    break;
                }
            }
            CopiaListaParaFicheiro();
            Form1 form = new Form1();
            form.Show();
        }

        private void CopiaListaParaFicheiro()
        {
            //Copies the List to the File

            StreamWriter file = new StreamWriter(@"tarefas.txt");
            file.WriteLine("ID Descricao Estado");
            foreach (Tarefa tarefa in listaTarefasForm4)
            {
                string task = tarefa.Id + " " + tarefa.Descricao + " " + tarefa.Estado;
                file.WriteLine(task);
            }
            file.Close();
            this.Close();
        }

        private void ShowTaskList()
        {
            //Clears the list
            //Reads from the file adding the Header and The content to the task DataGridView
            listaTarefasForm4.Clear();
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
                listaTarefasForm4.Add(tarefa);

                //Adds the new line to the Table
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();

            // Set AllowUserToAddRows property to false
            Form4_dataGridView1.AllowUserToAddRows = false;

            // Assign the DataTable as the DataSource of the DataGridView
            Form4_dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
