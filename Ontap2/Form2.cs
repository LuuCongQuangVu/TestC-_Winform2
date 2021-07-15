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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ListViewItem it = (ListViewItem)this.Tag;
            txtmanv.Text = it.Text;
            txttennv.Text = it.SubItems[1].Text;
            dateTuyendung.Text = it.SubItems[2].Text;
            txtluongcoban.Text = it.SubItems[3].Text;
            cbchucvu.Text = it.SubItems[4].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
