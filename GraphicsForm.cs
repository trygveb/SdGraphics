using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SdGraphics
{
    public partial class GraphicsForm : Form
    {
        public GraphicsForm(ref PictureBox myPictureBox)
        {
            InitializeComponent();
            myPictureBox = this.pictureBox1;
        }
        public PictureBox getPictureBox()
        {
            return this.pictureBox1;
        }

        private void GraphicsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
