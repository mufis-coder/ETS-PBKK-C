using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS_PointofSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double Cost_of_Items()
        {
            Double sum = 0;
            int i = 0;

            for(i = 0; i< (dataGridView1.Rows.Count); i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void Addcost()
        {
            Double tax, q;
            tax = 0.1;
            if(dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format("{0:c2}", ((Cost_of_Items() * tax)));
                lblSubtotal.Text = String.Format("{0:c2}", (Cost_of_Items()));
                q = ((Cost_of_Items() * tax));
                lblTotal.Text = String.Format("{0:c2}", ((Cost_of_Items() + q)));
                lblBarCode.Text = Convert.ToString(q + Cost_of_Items());
            }
        }

        private void Change()
        {
            Double tax, q, c;
            tax = 0.1;
            if (dataGridView1.Rows.Count > 0)
            {
                q = (Cost_of_Items() * tax) + Cost_of_Items();
                c = Convert.ToInt32(lblCost.Text);
                lblChange.Text = String.Format("{0:c2}", c - q);
            }
        }
        Bitmap bitmap;
        private void button40_Click(object sender, EventArgs e) //PRINT BUTTON
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button39_Click(object sender, EventArgs e) //RESET BUTTON
        {
            try
            {
                lblBarCode.Text = "";
                lblChange.Text = "";
                lblCost.Text = "0";
                lblSubtotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboPayment.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Visa Card");
            cboPayment.Items.Add("Master Card");
        }

        private void NumbersOnly(object sender, EventArgs e) 
        {
            Button b = (Button)sender;

            if (lblCost.Text == "0")
            {
                lblCost.Text = "";
                lblCost.Text = b.Text;
            }
            else if (b.Text == ".")
            {
                if (!lblCost.Text.Contains("."))
                {
                    lblCost.Text = lblCost.Text + b.Text;
                }
            }
            else
                lblCost.Text = lblCost.Text + b.Text;
        }

        private void button7_Click(object sender, EventArgs e) //C BUTTON
        {
            lblCost.Text = "0";
        }

        private void button37_Click(object sender, EventArgs e)// PAY BUTTON
        {
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCost.Text = "0"; 
            }
        }

        private void button38_Click(object sender, EventArgs e) //REMOVE BUTTON
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            Addcost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCost.Text = "0";
            }
        }

        private void capucino_Click(object sender, EventArgs e)
        {
            Double costofitem = 12000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value = "Cappuccino"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Cappuccino", "1", costofitem);
            Addcost();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Double costofitem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Kopi"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Kopi", "1", costofitem);
            Addcost();
        }

        private void boba_Click(object sender, EventArgs e)
        {
            Double costofitem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Boba"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Boba", "1", costofitem);
            Addcost();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double costofitem = 5000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Es Jeruk"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Es Jeruk", "1", costofitem);
            Addcost();
        }

        private void jeruknipis_Click(object sender, EventArgs e)
        {
            Double costofitem = 3000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Es Jeruk Nipis"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Es Jeruk Nipis", "1", costofitem);
            Addcost();
        }

        private void teh_Click(object sender, EventArgs e)
        {
            Double costofitem = 3000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Es Teh"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Es Teh", "1", costofitem);
            Addcost();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Double costofitem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Es Buah"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Es Buah", "1", costofitem);
            Addcost();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Double costofitem = 5000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Es Kelapa"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Es Kelapa", "1", costofitem);
            Addcost();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Double costofitem = 3000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Air Mineral"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Air Mineral", "1", costofitem);
            Addcost();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Double costofitem = 7000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Soda Gembira"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Soda Gembira", "1", costofitem);
            Addcost();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Double costofitem = 7500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Soft Drink"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Soft Drink", "1", costofitem);
            Addcost();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Double costofitem = 5000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Susu"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Susu", "1", costofitem);
            Addcost();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Double costofitem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Roti Goreng"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Roti Goreng", "1", costofitem);
            Addcost();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Double costofitem = 15000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Kebab"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Kebab", "1", costofitem);
            Addcost();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Double costofitem = 8000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Kentang Goreng"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Kentang Goreng", "1", costofitem);
            Addcost();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Double costofitem = 12500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mi Goreng"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Mi Goreng", "1", costofitem);
            Addcost();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Double costofitem = 12500;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Nasi Goreng"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Nasi Goreng", "1", costofitem);
            Addcost();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Double costofitem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Martabak"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Martabak", "1", costofitem);
            Addcost();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Double costofitem = 13000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Fried Chicken"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Fried Chicken", "1", costofitem);
            Addcost();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Double costofitem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Burger"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Burger", "1", costofitem);
            Addcost();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Double costofitem = 10000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Spageti"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Spageti", "1", costofitem);
            Addcost();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Double costofitem = 11000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Bakso"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Bakso", "1", costofitem);
            Addcost();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Double costofitem = 4000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Tahu"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Tahu", "1", costofitem);
            Addcost();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Double costofitem = 4000;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Tempe"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + costofitem;
                }
            }
            dataGridView1.Rows.Add("Tempe", "1", costofitem);
            Addcost();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCost_Click(object sender, EventArgs e)
        {

        }

        private void lblChange_Click(object sender, EventArgs e)
        {

        }
    }
 }

