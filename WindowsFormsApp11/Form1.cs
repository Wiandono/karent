using MaterialSkin;
using MaterialSkin.Controls;
using System;
using MySql.Data.MySqlClient;
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
    public partial class Form1 : MaterialForm
    {
        public static int idUser;
        int panelCount = 0;

        public static string username;
        static string connectionInfo = "datasource=localhost; port=3306; username=root; password=; database=karent;";
        string query;
        string thumbnailDirectory = @"C:\Users\Theta\Documents\Visual Studio 2017\WindowsFormsApp11\WindowsFormsApp11\img";

        MySqlConnection connect = new MySqlConnection(connectionInfo);
        MySqlCommand SQLCommand = new MySqlCommand();
        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Amber200, TextShade.WHITE);

            SQLCommand.Connection = connect;
        }
        
        private PictureBox createThumbnail(String load, String category, int i)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(thumbnailDirectory + @"\" + category + @"\" + load);
            //pictureBox.Load(load);
            pictureBox.Location = new System.Drawing.Point(15, 15);
            pictureBox.Margin = new System.Windows.Forms.Padding(15);
            pictureBox.Name = "pictureBox" + category + i;
            pictureBox.Size = new System.Drawing.Size(140, 70);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;

            return pictureBox;
        }

        private MaterialLabel createLabelNama(String text, String category, int i)
        {
            MaterialLabel label = new MaterialLabel();
            label.AutoSize = true;
            label.Depth = 0;
            label.Font = new System.Drawing.Font("Roboto", 11F);
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label.Location = new System.Drawing.Point(174, 15);
            label.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label.MouseState = MaterialSkin.MouseState.HOVER;
            label.Name = "labelNama" + category + i;
            label.Size = new System.Drawing.Size(104, 19);
            label.TabIndex = 1;
            label.Text = text;

            return label;
        }

        private MaterialLabel createLabelHarga(String harga, String category, int i)
        {
            MaterialLabel label = new MaterialLabel();
            label.AutoSize = true;
            label.Depth = 0;
            label.Font = new System.Drawing.Font("Roboto", 11F);
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label.Location = new System.Drawing.Point(175, 71);
            label.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            label.MouseState = MaterialSkin.MouseState.HOVER;
            label.Name = "labelHarga" + category + i;
            label.Size = new System.Drawing.Size(105, 19);
            label.TabIndex = 3;
            label.Text = "Rp. " + harga + ",-";

            return label;
        }

        private MaterialLabel createLabelSeats(String seats, String category, int i)
        {
            MaterialLabel label = new MaterialLabel();
            label.AutoSize = true;
            label.Depth = 0;
            label.Font = new System.Drawing.Font("Roboto", 11F);
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            label.Location = new System.Drawing.Point(175, 52);
            label.Margin = new System.Windows.Forms.Padding(3, 0, 0, 5);
            label.MouseState = MaterialSkin.MouseState.HOVER;
            label.Name = "labelSeats" + category + i;
            label.Size = new System.Drawing.Size(59, 19);
            label.TabIndex = 4;
            label.Text = seats + " Seats";

            return label;
        }

        private Label createLabelTransmission(String transmission, String category, int i)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(240, 56);
            label.Name = "labelTransmission" + category + i;
            label.Size = new System.Drawing.Size(111, 13);
            label.TabIndex = 5;
            label.Text = "| " + transmission;

            return label;
        }

        private Label createLabelStock(String stock, String category, int i)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(375, 20);
            label.Name = "labelStock" + category + i;
            label.Size = new System.Drawing.Size(111, 13);
            label.TabIndex = 6;
            label.Text = "Stock : " + stock;

            return label;
        }

        private Label createLabelSisaHari(String text, String category, int i)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(176, 44);
            label.Name = "labelSisaHari" + category + i;
            label.Size = new System.Drawing.Size(89, 13);
            label.TabIndex = 3;
            label.Text = text;

            return label;
        }

        private Label createLabelDipinjam(String pick, String category, int i)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(175, 54);
            label.Name = "labelDipinjam" + category + i;
            label.Size = new System.Drawing.Size(53, 13);
            label.TabIndex = 3;
            label.Text = "Dipinjam : " + pick;

            return label;
        }

        private Label createLabelDikembalikan(String drop, String category, int i)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(175, 72);
            label.Name = "labelDikembalikan" + category + i;
            label.Size = new System.Drawing.Size(77, 13);
            label.TabIndex = 4;
            label.Text = "Dikembalikan : " + drop;

            return label;
        }

        private MaterialRaisedButton createButtonPesan(String stock, String category, int i)
        {
            MaterialRaisedButton button = new MaterialRaisedButton();
            button.Depth = 0;
            button.Location = new System.Drawing.Point(357, 49);
            button.Margin = new System.Windows.Forms.Padding(15);
            button.MouseState = MaterialSkin.MouseState.HOVER;
            button.Name = "buttonPesan" + category + i;
            button.Primary = true;
            button.Size = new System.Drawing.Size(73, 36);
            button.Text = "Pesan";
            button.TabIndex = 2;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler((sender, e) => pesan(sender, e, i));

            if (stock.Equals("0"))
            {
                button.Enabled = false;
            }

            return button;
        }

        private MaterialRaisedButton createButtonKembalikan(String category, int i)
        {
            MaterialRaisedButton button = new MaterialRaisedButton();
            button.Depth = 0;
            button.Location = new System.Drawing.Point(350, 49);
            button.MouseState = MaterialSkin.MouseState.HOVER;
            button.Name = "buttonKembalikan" + category + i;
            button.Primary = true;
            button.Size = new System.Drawing.Size(95, 36);
            button.TabIndex = 2;
            button.Text = "Kembalikan";
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler((sender, e) => kembalikan(sender, e, i));

            return button;
        }

        private Panel createPanel(String load, String text, String harga, String seats, String transmission, String stock, String category, int i)
        {
            Panel panel = new Panel();
            panel.Controls.Add(createThumbnail(load, category, i));
            panel.Controls.Add(createLabelNama(text, category, i));
            panel.Controls.Add(createLabelStock(stock, category, i));
            panel.Controls.Add(createLabelHarga(harga, category, i));
            panel.Controls.Add(createLabelSeats(seats, category, i));
            panel.Controls.Add(createLabelTransmission(transmission, category, i));
            panel.Controls.Add(createButtonPesan(stock, category, i));
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Name = "panelMobil" + panelCount;
            panel.Size = new System.Drawing.Size(450, 100);
            panel.TabIndex = 0;

            panelCount++;
            return panel;
        }

        private Panel createPanelBookingBerlangsung(String load, String text, String textHari, String category, int i)
        {
            Panel panel = new Panel();
            panel.Controls.Add(createThumbnail(load, category, i));
            panel.Controls.Add(createLabelNama(text, category, i));
            panel.Controls.Add(createLabelSisaHari(textHari, category, i));
            panel.Controls.Add(createButtonKembalikan(category, i));
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Name = "panelBooking" + panelCount;
            panel.Size = new System.Drawing.Size(450, 100);
            panel.TabIndex = 0;

            panelCount++;
            return panel;
        }

        private Panel createPanelBookingSelesai(String load, String text, String pick, String drop, String category, int i)
        {
            Panel panel = new Panel();
            panel.Controls.Add(createThumbnail(load, category, i));
            panel.Controls.Add(createLabelNama(text, category, i));
            panel.Controls.Add(createLabelDipinjam(pick, category, i));
            panel.Controls.Add(createLabelDikembalikan(drop, category, i));
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Name = "panelBooking" + panelCount;
            panel.Size = new System.Drawing.Size(450, 100);
            panel.TabIndex = 0;

            panelCount++;
            return panel;
        }

        private void createList(String load, String text, String harga, String seats, String transmission, String stock, String category, int i)
        {
            if (category.Equals("Kecil"))
            {
                flowLayoutPanel1.Controls.Add(createPanel(load, text, harga, seats, transmission, stock, category, i));
            } else if (category.Equals("Sedang"))
            {
                flowLayoutPanel2.Controls.Add(createPanel(load, text, harga, seats, transmission, stock, category, i));
            } else
            {
                flowLayoutPanel3.Controls.Add(createPanel(load, text, harga, seats, transmission, stock, category, i));
            }
        }

        private void createListBooking(String load, String text, String textHari, String pick, String drop, String category, string kembali, int i)
        {
            if (kembali.Equals("0"))
            {
                flowLayoutPanel4.Controls.Add(createPanelBookingBerlangsung(load, text, textHari, category, i));
            } else
            {
                flowLayoutPanel5.Controls.Add(createPanelBookingSelesai(load, text, pick, drop, category, i));
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();

                query = "SELECT * FROM cars";
                int today = DateTime.Now.Day;

                if (dateTimePicker1.Value.Day < today)
                {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                } else if (dateTimePicker2.Value.Day < today)
                {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                } else if (dateTimePicker1.Value.Day == dateTimePicker2.Value.Day)
                {
                    MessageBox.Show("Minimal peminjaman adalah 1 hari!");
                } else if (dateTimePicker1.Value.Day > dateTimePicker2.Value.Day) {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                } else
                {
                    int multiplier = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;

                    connect.Open();
                    SQLCommand.CommandText = query;
                    reader = SQLCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int harga = int.Parse(reader["price"].ToString()) * multiplier;
                        createList(reader["image"].ToString(), reader["name"].ToString(), harga.ToString(), reader["capacity"].ToString(), reader["transmission"].ToString(), reader["stock"].ToString(), reader["category"].ToString(), int.Parse(reader["cars_id"].ToString()));
                    }

                    connect.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshSearch()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();

                query = "SELECT * FROM cars";
                int today = DateTime.Now.Day;

                if (dateTimePicker1.Value.Day < today)
                {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                }
                else if (dateTimePicker2.Value.Day < today)
                {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                }
                else if (dateTimePicker1.Value.Day == dateTimePicker2.Value.Day)
                {
                    MessageBox.Show("Minimal peminjaman adalah 1 hari!");
                }
                else if (dateTimePicker1.Value.Day > dateTimePicker2.Value.Day)
                {
                    MessageBox.Show("Tanggal yang kamu pilih salah!");
                }
                else
                {
                    int multiplier = dateTimePicker2.Value.Day - dateTimePicker1.Value.Day;

                    connect.Open();
                    SQLCommand.CommandText = query;
                    reader = SQLCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int harga = int.Parse(reader["price"].ToString()) * multiplier;
                        createList(reader["image"].ToString(), reader["name"].ToString(), harga.ToString(), reader["capacity"].ToString(), reader["transmission"].ToString(), reader["stock"].ToString(), reader["category"].ToString(), int.Parse(reader["cars_id"].ToString()));
                    }

                    connect.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;

            try
            {
                flowLayoutPanel4.Controls.Clear();
                flowLayoutPanel5.Controls.Clear();

                query = "SELECT * FROM booking INNER JOIN cars ON booking.id_cars = cars.cars_id WHERE id_user =" + idUser;
                string today = DateTime.Now.ToShortDateString();
                string textHari;

                connect.Open();
                SQLCommand.CommandText = query;
                reader = SQLCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["drop_date"].ToString().Equals(today))
                    {
                        textHari = "Masa peminjaman sudah habis";
                    }
                    else
                    {
                        int sekarang = int.Parse(today.Substring(3, 2));
                        int pinjam = int.Parse(reader["drop_date"].ToString().Substring(3, 2));

                        if (sekarang < pinjam)
                        {
                            textHari = "Tersisa " + (pinjam - sekarang) + " hari";
                        }
                        else
                        {
                            textHari = "Masa peminjaman sudah habis";
                        }
                    }
                    createListBooking(reader["image"].ToString(), reader["name"].ToString(), textHari, reader["pick_date"].ToString(), reader["drop_date"].ToString(), reader["category"].ToString(), reader["return"].ToString(), int.Parse(reader["booking_id"].ToString()));
                }

                connect.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshBooking()
        {
            try
            {
                flowLayoutPanel4.Controls.Clear();
                flowLayoutPanel5.Controls.Clear();

                query = "SELECT * FROM booking INNER JOIN cars ON booking.id_cars = cars.cars_id WHERE id_user = " + idUser;
                string today = DateTime.Now.ToShortDateString();
                string textHari;

                connect.Open();
                SQLCommand.CommandText = query;
                reader = SQLCommand.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["drop_date"].ToString().Equals(today))
                    {
                        textHari = "Masa peminjaman sudah habis";
                    }
                    else
                    {
                        int sekarang = int.Parse(today.Substring(3, 2));
                        int pinjam = int.Parse(reader["drop_date"].ToString().Substring(3, 2));

                        if (sekarang < pinjam)
                        {
                            textHari = "Tersisa " + (pinjam - sekarang) + " hari";
                        }
                        else
                        {
                            textHari = "Masa peminjaman sudah habis";
                        }
                    }
                    createListBooking(reader["image"].ToString(), reader["name"].ToString(), textHari, reader["pick_date"].ToString(), reader["drop_date"].ToString(), reader["category"].ToString(), reader["return"].ToString(), int.Parse(reader["booking_id"].ToString()));
                }

                connect.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            refreshSearch();
            panel4.Visible = false;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 signin = new Form2();
            signin.Closed += (s, args) => this.Close();
            signin.Show();
        }

        private void pesan(object sender, EventArgs e, int idMobil)
        {
            int stock;

            connect.Open();
            query = "INSERT INTO booking (id_cars, id_user, pick_date, drop_date, location, `return`) VALUES (" + idMobil + ", " + idUser + ", '" + dateTimePicker1.Value.ToShortDateString() + "', '" + dateTimePicker2.Value.ToShortDateString() + "', '" + comboBox1.GetItemText(comboBox1.SelectedItem) + "', 0)";
            SQLCommand.CommandText = query;
            SQLCommand.ExecuteNonQuery();

            connect.Close();

            connect.Open();
            query = "SELECT * FROM cars WHERE cars_id =" + idMobil;
            SQLCommand.CommandText = query;
            reader = SQLCommand.ExecuteReader();
            reader.Read();

            stock = int.Parse(reader["stock"].ToString());
            stock--;
            MessageBox.Show("Terimakasih " + username + ", Peminjaman " + reader["name"] + " kamu sudah masuk ke dalam database kami");

            connect.Close();

            connect.Open();
            query = "UPDATE cars SET stock=" + stock + " WHERE cars_id =" + idMobil;
            SQLCommand.CommandText = query;
            SQLCommand.ExecuteNonQuery();
            connect.Close();

            refreshSearch();
        }

        private void kembalikan(object sender, EventArgs e, int idBooking)
        {
            int stock;
            int idMobil;

            connect.Open();
            query = "SELECT * FROM booking INNER JOIN cars ON booking.id_cars = cars.cars_id WHERE booking_id=" + idBooking;
            SQLCommand.CommandText = query;
            reader = SQLCommand.ExecuteReader();
            reader.Read();

            stock = int.Parse(reader["stock"].ToString());
            stock++;
            idMobil = int.Parse(reader["cars_id"].ToString());

            connect.Close();

            connect.Open();
            query = "UPDATE booking SET `return`=1 WHERE booking_id =" + idBooking;
            SQLCommand.CommandText = query;
            SQLCommand.ExecuteNonQuery();
            connect.Close();

            refreshBooking();

            connect.Open();
            query = "UPDATE cars SET stock=" + stock + " WHERE cars_id=" + idMobil;
            SQLCommand.CommandText = query;
            SQLCommand.ExecuteNonQuery();
            connect.Close();

            MessageBox.Show("Terimakasih " + username + ", Permintaan pengembalian akan segera direview oleh staff kami");
        }
    }
}
