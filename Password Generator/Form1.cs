using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Password_Generator
{

    public partial class Form1 : Form
    {
        Thread GG;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            GG = new Thread(Open);
            GG.SetApartmentState(ApartmentState.STA);
            GG.Start();
        }
        private void Open()
        {
            Application.Run(new Generate());
        }

    }
}
