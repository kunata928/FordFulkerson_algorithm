using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FordFulkerson_algorithm
{
    public partial class inputEdgeThroughput : Form
    {
        public inputEdgeThroughput()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public int val()
        {
            int v;
            if (Int32.TryParse(valBox.Text, out v))
                return v;
            else
                return 0;
        }

        private void valBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!(Char.IsDigit(number) || number.CompareTo('\b') == 0))
            {
                e.Handled = true;
            }
        }
    }
}
