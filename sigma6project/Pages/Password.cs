using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sigma6project
{
    public partial class Password : Form
    {
   
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.getPassword(textBox1.Text);
        }

        private void Password_Load(object sender, EventArgs e)
        {

            
            
        }
    }
}
