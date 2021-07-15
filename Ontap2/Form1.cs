using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ontap2
{
    public partial class Form1 : Form
    {
        //private int index = 0;
        private int select=0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txtmanv_Validated(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Mã nhân viên đang để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
            }
            foreach (ListViewItem item in listnv.Items)
            {
                if (txtmanv.Text == item.Text)
                {
                    MessageBox.Show("mã trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmanv.SelectAll();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string manv = txtmanv.Text;
            string tennv = txttennv.Text;
            string ngaytd = dateTuyendung.Text;
            string chucvu = cbchucvu.Text;
            double luongcoban = Convert.ToDouble(txtluongcoban.Text);
            double luong =luongcoban+ 1000;
            if (cbchucvu.SelectedIndex == 0)
            {
                luong = luongcoban+ 3000;
            }
            if (cbchucvu.SelectedIndex == 1 || cbchucvu.SelectedIndex == 2)
            {
                luong = luongcoban+2000;
            }
            ListViewItem item = new ListViewItem(new string[] { manv, tennv, ngaytd, Convert.ToString(luong),chucvu });
            this.listnv.Items.AddRange(new ListViewItem[]
            {
                item
            });
            //listnv.Items.Add(manv);
            //listnv.Items[index].SubItems.Add(tennv);
            //listnv.Items[index].SubItems.Add(ngaytd);
            //listnv.Items[index].SubItems.Add(Convert.ToString(luong));
            //listnv.Items[index].SubItems.Add(chucvu);
            //index++;
            //dateTuyendung.Text =Convert.ToString( DateTime.Now.Date);

        }

        private void txttennv_Validated(object sender, EventArgs e)
        {

            if (txttennv.Text == "")
            {
                MessageBox.Show("Tên nhân viên đang để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttennv.Focus();
            }
           
        }

        private void dateTuyendung_Validated(object sender, EventArgs e)
        {
            if ((DateTime.Now.Year-dateTuyendung.Value.Year) < 18)
            {
                MessageBox.Show("Tuổi nhỏ hơn 18", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTuyendung.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listnv.Items)
            {
                if (item.Text == txtmanv.Text)
                {
                    item.Remove();
                    MessageBox.Show("Xoá thành công", "thông báo");
                }
            }
        }
        private void listnv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            select = e.Item.Index;
            var it = e.Item;
            txtmanv.Text = it.Text;
            txttennv.Text = it.SubItems[1].Text;
            dateTuyendung.Text = it.SubItems[2].Text;
            txtluongcoban.Text = it.SubItems[3].Text;
            cbchucvu.Text = it.SubItems[4].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Tag = this.listnv.Items[select];
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtmanv.Clear();
            txttennv.Clear();
            cbchucvu.Text="";
            txtluongcoban.Clear();
            dateTuyendung.Value = DateTime.Now;
        }
    }
}
