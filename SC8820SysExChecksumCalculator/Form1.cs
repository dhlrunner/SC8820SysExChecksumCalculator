using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC8820SysExChecksumCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                try
                {
                    string[] hexarray = textBox1.Text.Split(' ');
                    int sum = 0;
                    int remainder = 0;
                    foreach (string a in hexarray)
                    {
                        sum = sum + int.Parse(a, NumberStyles.HexNumber);
                    }
                    remainder = sum % 128;
                    label3.Text = (128 - remainder).ToString("X2");
                    linkLabel1.Enabled = true;
                }
                catch
                {
                    label3.Text = "??";
                    linkLabel1.Enabled = false;
                }
            }
            else
            {
                label3.Text = "--";
                linkLabel1.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText("F0 41 10 42 12 "+textBox1.Text + " "+label3.Text + " F7");
        }
    }
}
