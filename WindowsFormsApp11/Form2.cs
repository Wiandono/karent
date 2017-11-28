using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form2 : MaterialForm
    {
        static string connectionInfo = "datasource=localhost; port=3306; username=root; password=; database=karent;";
        MySqlConnection connect = new MySqlConnection(connectionInfo);
        MySqlDataReader reader;
        MySqlCommand SQLCommand = new MySqlCommand();

        Form1 home = new Form1();

        public Form2()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Amber200, TextShade.WHITE);

            SQLCommand.Connection = connect;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text.Equals("") && materialSingleLineTextField3.Text.Equals("")) {
                MessageBox.Show("Harap isi field username dan password terlebih dahulu");   
            } else if (materialSingleLineTextField4.Text.Equals(""))
            {
                MessageBox.Show("Harap isi field username terlebih dahulu");
            } else if (materialSingleLineTextField3.Text.Equals(""))
            {
                MessageBox.Show("Harap isi field password terlebih dahulu");
            } else
            {
                connect.Close();

                string query = "SELECT COUNT(*) AS Jumlah FROM user WHERE username = '" + materialSingleLineTextField4.Text + "'";
                
                connect.Open();
                SQLCommand.CommandText = query;
                reader = SQLCommand.ExecuteReader();
                reader.Read();

                if (reader["Jumlah"].ToString().Equals("0"))
                {
                    connect.Close();

                    connect.Open();
                    query = "INSERT INTO user (username, password) VALUES ('" + materialSingleLineTextField4.Text + "', '" + materialSingleLineTextField3.Text + "')";
                    SQLCommand.CommandText = query;
                    SQLCommand.ExecuteNonQuery();
                    MessageBox.Show("Akun berhasil dibuat, silahkan login");
                    panel2.Visible = false;
                    materialSingleLineTextField1.Text = materialSingleLineTextField4.Text;
                    materialSingleLineTextField4.Clear();

                    connect.Close();
                }
                else
                {
                    connect.Close();

                    MessageBox.Show("Username sudah terdaftar!");
                    materialSingleLineTextField4.Clear();
                }
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text.Equals("") && materialSingleLineTextField2.Text.Equals(""))
            {
                MessageBox.Show("Harap isi field username dan password terlebih dahulu");
            }
            else if (materialSingleLineTextField1.Text.Equals(""))
            {
                MessageBox.Show("Harap isi field username terlebih dahulu");
            }
            else if (materialSingleLineTextField2.Text.Equals(""))
            {
                MessageBox.Show("Harap isi field password terlebih dahulu");
            }
            else
            {
                connect.Close();

                string query = "SELECT COUNT(*) AS Jumlah FROM user WHERE username = '" + materialSingleLineTextField1.Text + "'";
                
                connect.Open();
                SQLCommand.CommandText = query;
                reader = SQLCommand.ExecuteReader();
                reader.Read();

                if (reader["Jumlah"].ToString().Equals("1"))
                {
                    connect.Close();

                    connect.Open();
                    query = "SELECT COUNT(*) AS Jumlah FROM user WHERE username = '" + materialSingleLineTextField1.Text + "' AND password = '" + materialSingleLineTextField2.Text + "'";
                    SQLCommand.CommandText = query;
                    reader = SQLCommand.ExecuteReader();
                    reader.Read();

                    if (reader["Jumlah"].ToString().Equals("0"))
                    {
                        MessageBox.Show("Password yang kamu masukkan salah!");
                        materialSingleLineTextField2.Clear();

                        connect.Close();
                    }
                    else
                    {
                        connect.Close();

                        connect.Open();
                        query = "SELECT user_id FROM user WHERE username = '" + materialSingleLineTextField1.Text + "' AND password = '" + materialSingleLineTextField2.Text + "'";
                        SQLCommand.CommandText = query;
                        reader = SQLCommand.ExecuteReader();
                        reader.Read();
                        Form1.idUser = int.Parse(reader["user_id"].ToString());
                        Form1.username = materialSingleLineTextField1.Text;

                        connect.Close();

                        this.Hide();
                        home.Closed += (s, args) => this.Close();
                        home.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Username belum terdaftar");
                    materialSingleLineTextField4.Clear();
                }
            }
        }
    }
}
