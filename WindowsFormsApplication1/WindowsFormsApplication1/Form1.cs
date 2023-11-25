using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int Rm, Gm, Bm;
        int Rmc, Gmc, Bmc, L = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=inf324;pwd=123456;database=texturas";
            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from tchompas";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.DataBind();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "Archivos JPG|*.JPG|Archivos BMP|*.bmp";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != string.Empty)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            Rm = c.R;
            Gm = c.G;
            Bm = c.B;
            Rmc = 0; Gmc = 0; Bmc = 0;

            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = Rm.ToString();
                textBox2.Text = Gm.ToString();
                textBox3.Text = Bm.ToString();
            }
            else if (textBox4.Text.Length == 0)
            {
                textBox4.Text = Rm.ToString();
                textBox5.Text = Gm.ToString();
                textBox6.Text = Bm.ToString();
            }

            else if (textBox7.Text.Length == 0)
            {            
                textBox7.Text = Rm.ToString();
                textBox8.Text = Gm.ToString();
                textBox9.Text = Bm.ToString();
            }
            //if (textBox1.Text.Length == 0)
            //{
            //    for (int i = e.X - 5; i < e.X + 5; i++)
            //        for (int j = e.Y - 5; j < e.Y + 5; j++)
            //        {
            //            c = bmp.GetPixel(i, j);
            //            Rmc = Rmc + c.R; Gmc = Gmc + c.G; Bmc = Bmc + c.B;
            //        }
            //    Rmc = (int)Rmc / (L * L);
            //    Gmc = (int)Gmc / (L * L);
            //    Bmc = (int)Bmc / (L * L);

            //    textBox1.Text = Rmc.ToString();
            //    textBox2.Text = Gmc.ToString();
            //    textBox3.Text = Bmc.ToString();
            //}
            //else if (textBox4.Text.Length == 0)
            //{
            //    for (int i = e.X - 5; i < e.X + 5; i++)
            //        for (int j = e.Y - 5; j < e.Y + 5; j++)
            //        {
            //            c = bmp.GetPixel(i, j);
            //            Rmc = Rmc + c.R; Gmc = Gmc + c.G; Bmc = Bmc + c.B;
            //        }
            //    Rmc = (int)Rmc / (L * L);
            //    Gmc = (int)Gmc / (L * L);
            //    Bmc = (int)Bmc / (L * L);

            //    textBox4.Text = Rmc.ToString();
            //    textBox5.Text = Gmc.ToString();
            //    textBox6.Text = Bmc.ToString();
            //}

            //else if (textBox7.Text.Length == 0)
            //{
            //    for (int i = e.X - 5; i < e.X + 5; i++)
            //        for (int j = e.Y - 5; j < e.Y + 5; j++)
            //        {
            //            c = bmp.GetPixel(i, j);
            //            Rmc = Rmc + c.R; Gmc = Gmc + c.G; Bmc = Bmc + c.B;
            //        }
            //    Rmc = (int)Rmc / (L * L);
            //    Gmc = (int)Gmc / (L * L);
            //    Bmc = (int)Bmc / (L * L);

            //    textBox7.Text = Rmc.ToString();
            //    textBox8.Text = Gmc.ToString();
            //    textBox9.Text = Bmc.ToString();
            //}

            //for(int i=e.X-5;i<e.X+5;i++)
            //    for (int j = e.Y - 5; j < e.Y + 5; j++)
            //    {
            //        c = bmp.GetPixel(i, j);
            //        Rmc = Rmc + c.R; Gmc = Gmc + c.G; Bmc = Bmc + c.B;
            //    }
            //Rmc = (int)Rmc / (L * L);
            //Gmc = (int)Gmc / (L * L);
            //Bmc = (int)Bmc / (L * L);

            //textBox1.Text = textBox1.Text + " " + Rmc.ToString();
            //textBox2.Text = textBox2.Text + " " + Gmc.ToString();
            //textBox3.Text = textBox3.Text + " " + Bmc.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=inf324;pwd=123456;database=texturas";
            SqlCommand cmd = new SqlCommand();
            string sql = string.Empty;
            sql = sql + "insert into tchompas(ro1,gr1,bl1,ro2,gr2,bl2,ro3,gr3,bl3) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            cmd.CommandText = sql;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter ada = new SqlDataAdapter();
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "select * from tchompas";
            ada.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            int ro1 = Convert.ToInt32(textBox1.Text);
            int gr1 = Convert.ToInt32(textBox2.Text);
            int bl1 = Convert.ToInt32(textBox3.Text);

            int ro2 = Convert.ToInt32(textBox4.Text);
            int gr2 = Convert.ToInt32(textBox5.Text);
            int bl2 = Convert.ToInt32(textBox6.Text);

            int ro3 = Convert.ToInt32(textBox7.Text);
            int gr3 = Convert.ToInt32(textBox8.Text);
            int bl3 = Convert.ToInt32(textBox9.Text);   

            int mR = 0, mG = 0, mB = 0;
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {
                    mR = 0;
                    mG = 0;
                    mB = 0;

                    for (int ki = i; ki < i + 10; ki++)
                        for (int kj = j; kj < j + 10; kj++)
                        {
                            c = bmp.GetPixel(ki, kj);
                            mR = mR + c.R;
                            mG = mG + c.G;
                            mB = mB + c.B;
                        }
                    mR = mR / 100;
                    mG = mG / 100;
                    mB = mB / 100;

                    c = bmp.GetPixel(i, j);
                    if (((ro1 - 20 < mR) && (mR < ro1 + 20)) && ((gr1 - 20 < mG) && (mG < gr1 + 20)) && ((bl1 - 20 < mB) && (mB < bl1 + 20)) || (((ro2 - 20 < mR) && (mR < ro2 + 20)) && ((gr2 - 20 < mG) && (mG < gr2 + 20)) && ((bl2 - 20 < mB) && (mB < bl2 + 20))) || (((ro3 - 20 < mR) && (mR < ro3 + 20)) && ((gr3 - 20 < mG) && (mG < gr3 + 20)) && ((bl3 - 20 < mB) && (mB < bl3 + 20))))
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                                bmpR.SetPixel(ki, kj, Color.Fuchsia);
                    }
                    else
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                            {
                                c = bmp.GetPixel(ki, kj);
                                bmpR.SetPixel(ki, kj, Color.FromArgb(c.R, c.G, c.B));
                            }

                    }
                }
            pictureBox1.Image = bmpR;    
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[indice].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[indice].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[indice].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[indice].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[indice].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[indice].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[indice].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[indice].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.Rows[indice].Cells[9].Value.ToString();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
