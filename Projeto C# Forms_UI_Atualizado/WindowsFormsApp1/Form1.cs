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
    public partial class Form1 : Form
    {
        List<Tarefa> listaTarefas = new List<Tarefa>();
        int counter = 1; //Counts the number of Tasks
        public Form1()
        {
            //Initializes the program, reads the file and updates the task list
            InitializeComponent();
            adicionarListaTarefas();
        }

        private void adicionarListaTarefas()
        {
            //Clears the list
            //Reads from the file adding the Header and The content to the task DataGridView
            listaTarefas.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"tarefas.txt");
            string[] columnnames = file.ReadLine().Split(' ');

            DataTable dt = new DataTable();

            //Adds the Header to the Table
            foreach (string c in columnnames)
            {
                dt.Columns.Add(c);
            }
            string newline;

            //Adds the lines to the Table and Uodates the Task List
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();
                string[] values = newline.Split(' ');
                string id= values[0];
                string descricao = values[1];
                string estado = values[2];

                //Adds the Task to the Task List
                Tarefa tarefa = new Tarefa (id, descricao, estado);
                listaTarefas.Add(tarefa);

                //Adds the new line to the Table
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i];

                    if (i == 2)
                    {
                        if (values[i] == "NãoConcluída")
                        {
                            dr[i] = "Not Complete";
                        }
                    }
                }
                dt.Rows.Add(dr);
                counter = counter + 1;
            }
            file.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Load Form2 into the panel
            Form2 form2 = new Form2(listaTarefas, counter);
            OpenFormInPanel(form2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load Form2 into the panel
            Form5 form5 = new Form5(listaTarefas);
            OpenFormInPanel(form5);
            //Button to Update the DataGridView

            adicionarListaTarefas(); //updates the tasks
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Load Form2 into the panel
            Form3 form3 = new Form3(listaTarefas);
            OpenFormInPanel(form3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getDate();
            timer1.Start();
            showNotCompleted();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Load Form2 into the panel
            Form4 form4 = new Form4(listaTarefas);
            OpenFormInPanel(form4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = Form1_textBox1.Text;
            text= text.Trim();

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

        //TIME AND DATE

        private void timer1_Tick(object sender, EventArgs e)
        {
            //gets the current Time 
            DateTime currentTime = DateTime.Now;

            //formats the Time and displays it
            string formattedTime = currentTime.ToString("HH:mm:ss");
            label2.Text = formattedTime;
        }

        private void getDate()
        {
            //gets the current Date
            DateTime currentDate = DateTime.Now;

            //formats the Date and displays it
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            label3.Text = formattedDate;
        }

        private void showNotCompleted()
        {
            string text="Incomplete Tasks\n";
            string newtext;
            bool ver=false;

            //Goes trough the tasks and verifies if the task is not Completed
            foreach (Tarefa tarefa in listaTarefas)
            {
                //If the Task is not completed adds to the MessageBox content. If any task is not completed ver is true
                if (tarefa.Estado == "NãoConcluída")
                {
                    newtext = tarefa.ToString()+"\n";
                    text = String.Concat(text, newtext);
                    ver = true;
                }
            }

            //Verifies if there is any task to be displayed, otherwise, the MessageBox doesn't need to be displayed
            if (ver)
            {
                MessageBox.Show(text);
            }

        }


        private void OpenFormInPanel(Form form)
        {
            // Clear existing controls from the panel
            panel3.Controls.Clear();

            // Set the form to be a child of the panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and display it
            panel3.Controls.Add(form);
            form.Show();
        }

        private void Form1_textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /*
        private void btnForm1_Click(object sender, EventArgs e)
        {
            // Load Form1 into the panel
            Form1 form1 = new Form1();
            OpenFormInPanel(form1);
        }
        */


    }
}
