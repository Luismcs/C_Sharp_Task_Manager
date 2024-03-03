using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private List<Tarefa> listaTarefasForm5;
        public Form5(List<Tarefa> lista)
        {
            InitializeComponent();
            listaTarefasForm5 = lista;
            ShowTaskList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = Form1_textBox1.Text;
            text = text.Trim();

            if (string.IsNullOrEmpty(Form1_textBox1.Text))
            {
                // Display a messagebox to notify the user
                MessageBox.Show("Textbox cannot be empty!", "Empty Textbox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Reads from the file adding the Header and The content to the task DataGridView
            System.IO.StreamReader file = new System.IO.StreamReader(@"tarefas.txt");
            string[] columnnames = file.ReadLine().Split(' ');

            DataTable dt = new DataTable();

            //Adds the Header to the Table
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;

            //Adds the lines to the Table if the text matches some task data (id,description or state)

            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                string id = values[0];
                string description = values[1];
                string state = values[2];

                //Creates a new task object
                Tarefa tarefa = new Tarefa(id, description, state);

                //if the text matches some task data adds the task to the CataGridView
                if (id == text || description == text || state == text)
                {
                    //Adds the new line to the Table
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            file.Close();
            dataGridView1.DataSource = dt;
        }

        private void ShowTaskList()
        {
            //Clears the list
            //Reads from the file adding the Header and The content to the task DataGridView
            listaTarefasForm5.Clear();
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
                listaTarefasForm5.Add(tarefa);

                //Adds the new line to the Table
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            file.Close();

            // Set AllowUserToAddRows property to false
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;


            // Assign the DataTable as the DataSource of the DataGridView
            dataGridView1.DataSource = dt;
        }

        private void getDate()
        {
            //gets the current Date
            DateTime currentDate = DateTime.Now;

            //formats the Date and displays it
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            label3.Text = formattedDate;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            getDate();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //gets the current Time 
            DateTime currentTime = DateTime.Now;

            //formats the Time and displays it
            string formattedTime = currentTime.ToString("HH:mm:ss");
            label2.Text = formattedTime;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
