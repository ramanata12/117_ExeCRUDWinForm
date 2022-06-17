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

namespace ExerciseCrud
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=Nilai;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetListPABD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            string nim = textBox1.Text, nama=textBox2.Text, kelas = comboBox2.Text, nilai = comboBox1.Text;
            con.Open();
            SqlCommand insert = new SqlCommand("exec InsertPABD '" + nim + "','" + nama + "','" + kelas + "','" + nilai + "'",con);
            insert.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Berhasil Ditambahkan....");
            GetListPABD();
        }

        void GetListPABD()
        {
            SqlCommand c = new SqlCommand("exec ListPABD", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            string nim = textBox1.Text, nama = textBox2.Text, kelas = comboBox2.Text, nilai = comboBox1.Text;
            con.Open();
            SqlCommand upt = new SqlCommand("exec UpdatePABD '" + nim + "','" + nama + "','" + kelas + "','" + nilai + "'",con);
            upt.ExecuteNonQuery();
            MessageBox.Show("Berhasil Di Edit....");
            con.Close();
            GetListPABD();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete
            string nim = textBox1.Text;
            con.Open();
            SqlCommand dlt = new SqlCommand("exec DeletePABD '" + nim + "'",con);
            dlt.ExecuteNonQuery();
            MessageBox.Show("Berhasil Di Edit....");
            GetListPABD();
        }
    }
}
