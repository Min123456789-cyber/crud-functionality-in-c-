using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudreal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=USER;Initial Catalog=\"crud operations\";Integrated Security=True");
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string query = "INSERT INTO User_tbl(ID, Name, Age) VALUES(@ID, @Name, @Age)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox2.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully inserted!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=USER;Initial Catalog=\"crud operations\";Integrated Security=True");
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "Update User_tbl set Name=@Name, Age=@Age  where ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully Updated");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=USER;Initial Catalog=\"crud operations\";Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string query = "Delete User_tbl where ID= @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Deleted!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=USER;Initial Catalog=\"crud operations\";Integrated Security=True");
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string query = "Select * from User_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
