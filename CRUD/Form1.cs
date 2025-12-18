using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;integrated security=true";
            string instr = $"update UserData set fname='{textBox1.Text}', lname='{textBox3.Text}' , pass='{textBox2.Text}' where username='{textBox4.Text}' ";
            string viewstr = $"select *from UserData ";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand cmd = new SqlCommand(instr, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(viewstr, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("database updated!!! ");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;Integrated Security=true";
            string instr = $"insert into UserData values('{textBox4.Text}','{textBox1.Text}','{textBox3.Text}','{textBox2.Text}')";
            string viewstr = $"select *from UserData ";
            try
            {
                SqlConnection con = new SqlConnection(constr);
                
                con.Open();

                SqlCommand cmd = new SqlCommand(instr,con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(viewstr, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data inserted to database!!! ");
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;Integrated Security=true";
            string delstr = $"delete from UserData where username='{textBox4.Text}'";
            string viewstr = $"select *from UserData ";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand cmd = new SqlCommand(delstr, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(viewstr, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("user has been deleted!!! ");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;integrated security=true";
            string viewstr = $"select *from UserData ";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                //SqlCommand cmd = new SqlCommand(viewstr, con);
                SqlDataAdapter da = new SqlDataAdapter(viewstr, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;Integrated Security=true";
            string crtdrstr = $"create table UserData (username varchar(23) primary key, fname varchar(23) , lname varchar(23), pass varchar(23));";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand cmd = new SqlCommand(crtdrstr, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("table has been deleted!!! ");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = "server=localhost\\SQLEXPRESS;database=mydb;integrated security=true";
            string viewstr = $"select *from UserData ";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                //SqlCommand cmd = new SqlCommand(viewstr, con);
                SqlDataAdapter da = new SqlDataAdapter(viewstr, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string constr = "server=localhost\\SQLEXPRESS;database=mydb;Integrated Security=true";
            string search = $"select *from UserData where fname='{textBox1.Text}'";
            try
            {
                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand cmd = new SqlCommand(search, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(search, con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                //MessageBox.Show("table has been deleted!!! ");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("could not connect: \n" + ex.Message);
            }
        }
    }
}
