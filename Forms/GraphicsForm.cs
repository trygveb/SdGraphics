using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SdGraphics
{

    /// <summary>
    /// GraphicsForm is a Form window containing a PictureBox.
    ///  The PictureBox is filled with a Bitmap, there is one bitmap for each page
    ///  Each bitmap contains a header, a sequence of calls and formations, and a footer.
    /// </summary>
    public partial class GraphicsForm : Form

    {
        private Form1 myParentForm;
        public GraphicsForm(ref PictureBox myPictureBox, Form1 parent)
        {
            InitializeComponent();
            myPictureBox = this.pictureBox1;
            myParentForm = parent;
        }

        private void GraphicsForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myParentForm.printImage();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            myParentForm.nextPage();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            myParentForm.previousPage();
        }

        private void buttonBeginning_Click(object sender, EventArgs e)
        {
            myParentForm.firstPage();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            myParentForm.lastPage();
        }
        //EncoderParameters myEncoderParameters;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented");
            //System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            //ImageCodecInfo  myImageCodecInfo = GetEncoderInfo("image/jpeg");
            //EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            //myEncoderParameters = new EncoderParameters(1);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //this.pictureBox1.Image.Save(@"D:\Mina dokument\Sqd\SD\Test.jpg", myImageCodecInfo, myEncoderParameters);

            //this.pictureBox1.Image.Save(@"D:\Mina dokument\Sqd\SD\Test.bmp", 
            //    System.Drawing.Imaging.ImageFormat.Bmp);
        }
        //private static ImageCodecInfo GetEncoderInfo(String mimeType)
        //{
        //    int j;
        //    ImageCodecInfo[] encoders;
        //    encoders = ImageCodecInfo.GetImageEncoders();
        //    for (j = 0; j < encoders.Length; ++j) {
        //        if (encoders[j].MimeType == mimeType)
        //            return encoders[j];
        //    }
        //    return null;
        //}

    }
}
