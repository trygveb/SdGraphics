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
        private Form1 myParentForm;
        public GraphicsForm(ref PictureBox myPictureBox, Form1 parent)
        {
            InitializeComponent();
            myPictureBox = this.pictureBox1;
            myParentForm = parent;
        }
        public PictureBox getPictureBox()
        {
            return this.pictureBox1;
        }

        private void GraphicsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            myParentForm.previousPage();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            myParentForm.nextPage();

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            myParentForm.printImage();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myParentForm.printImage();
        }

        private void buttonForward_Click_1(object sender, EventArgs e)
        {
            myParentForm.nextPage();
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            myParentForm.previousPage();
        }

        private void buttonBeginnin_Click(object sender, EventArgs e)
        {
            myParentForm.firstPage();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            myParentForm.lastPage();
        }
    }
}
