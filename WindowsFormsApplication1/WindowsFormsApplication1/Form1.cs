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

        int ro1, gr1, bl1, ro2, gr2, bl2, ro3, gr3, bl3;
        int turno = 1;

        Bitmap original;

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
                original = new Bitmap(openFileDialog1.FileName);
                original = bmp;
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

            if (turno == 1)
            {
                textBox1.Text = Rm.ToString() + " ";
                textBox2.Text = Gm.ToString() + " ";
                textBox3.Text = Bm.ToString() + " ";

                ro1 = Rm;
                gr1 = Gm;
                bl1 = Bm;

                turno++;
            }
            else if (turno == 2)
            {
                textBox1.Text += Rm.ToString() + " ";
                textBox2.Text += Gm.ToString() + " ";
                textBox3.Text += Bm.ToString() + " ";

                ro2 = Rm;
                gr2 = Gm;
                bl2 = Bm;

                turno++;
            }

            else if (turno == 3)
            {
                textBox1.Text += Rm.ToString() + " ";
                textBox2.Text += Gm.ToString() + " ";
                textBox3.Text += Bm.ToString() + " ";

                ro3 = Rm;
                gr3 = Gm;
                bl3 = Bm;

                turno = 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);user=inf324;pwd=123456;database=texturas";
            SqlCommand cmd = new SqlCommand();
            string sql = string.Empty;
            sql = sql + "insert into tchompas(ro1,gr1,bl1,ro2,gr2,bl2,ro3,gr3,bl3) values ('" + ro1 + "','" + gr1 + "','" + bl1 + "','" + ro2 + "','" + gr2 + "','" + bl2 + "','" + ro3 + "','" + gr3 + "','" + bl3 + "')";
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

            limpiar(1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

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
            limpiar(0);
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            ro1 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[1].Value);
            gr1 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value);
            bl1 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[3].Value);

            ro2 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[4].Value);
            gr2 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[5].Value);
            bl2 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[6].Value);

            ro3 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[7].Value);
            gr3 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[8].Value);
            bl3 = Convert.ToInt32(dataGridView1.Rows[indice].Cells[9].Value);

            textBox1.Text = ro1 + " " + ro2 + " " + ro3;
            textBox2.Text = gr1 + " " + gr2 + " " + gr3;
            textBox3.Text = bl1 + " " + bl2 + " " + bl3;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiar(1);
        }

        public void limpiar(int a)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            turno = 1;

            if(a == 1)
                pictureBox1.Image = original;
        }

        private void Automatico_Click(object sender, EventArgs e)
        {
            int tope = Convert.ToInt32(dataGridView1.RowCount);

            for (int ind = 0; ind < tope - 1; ind++)
            {
                ro1 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[1].Value);
                gr1 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[2].Value);
                bl1 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[3].Value);

                ro2 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[4].Value);
                gr2 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[5].Value);
                bl2 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[6].Value);

                ro3 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[7].Value);
                gr3 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[8].Value);
                bl3 = Convert.ToInt32(dataGridView1.Rows[ind].Cells[9].Value);

                Bitmap bmp = new Bitmap(pictureBox1.Image);

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
                            //ind = tope;

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
                //limpiar(0);

                /*textBox1.Text = ro1 + " " + ro2 + " " + ro3;
                textBox2.Text = gr1 + " " + gr2 + " " + gr3;
                textBox3.Text = bl1 + " " + bl2 + " " + bl3;*/
            }
        }

    }
}
