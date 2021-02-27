using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;

namespace SdGraphics
{

    public partial class Form1 : Form
    {
        #region ----------------------------------------- Attributes

        // Form feed character are found i Sd files when the "End this sequence" command has been used
        public static Char FF = '\f';

        //SettingsStruct MySettings= new SettingsStruct();
        // The formation from this Sd Command is currently ignored
        public static String TWO_COUPLES_ONLY = "Two couples only";

        // currentXoffset should be zero for the left column and typically pageSize.Width/2 for the right column
        public int currentXoffset = 0;

        public MyUserSettings mus = new MyUserSettings();

        // This line i one of several criteria to detect end of a sequence
        private static String AT_HOME = "at home";

        private List<Bitmap> bitmapList = new List<Bitmap>();
        private int currentIndex = -1;
        private Boolean dancerView = false;
        // Index in bitmapList
        private String fileName;

        private Font fontForCalls = new Font("Helvetica", 10, FontStyle.Bold);
        // Current Sd file
        private Form graphicsForm;

        private int marginLeftFormations = 30;
        // The window with the graphics
        private int marginLeftText = 40;

        // Each bitmap in this list corresponds to a (A4) page
        private int pageIndex = 0;

        // Size of the each page in pixels. Corresponds to 94 pixels/inch for an A4 page (210 mm × 297 mm)
        private Size pageSize = new Size(778, 1100);

        private double PANEL_SCALE = 1;
        private PictureBox pictureBox1 = new PictureBox();
        private List<SdLine> sdLines = new List<SdLine>();
        // For printing
        private String sdPrintingId = "";

        private int SPACE_BETWEEN_CALL_AND_FORMATION = 15;
        private String ViewTypeName = "Caller view";
        // Used by the printing function
        #region ----------------------------------------- Brushes
        private Brush brushForCallerNose = new SolidBrush(System.Drawing.Color.DarkGreen);
        private Brush brushForCalls = new SolidBrush(System.Drawing.Color.Black);
        private Brush brushForDancers = new SolidBrush(System.Drawing.Color.Black);
        private Brush brushForNoses = new SolidBrush(System.Drawing.Color.Red);
        #endregion  ------------------------------------- Brushes
        #region ----------------------------------------- Pens
        private Pen penForBorder = new Pen(Color.Red, 2);
        private Pen penForCaller = new Pen(Color.DarkGreen, 1);
        private Pen penForFocusDancer = new Pen(Color.Red, 2);
        private Pen penForPartner = new Pen(Color.Black, 1);
        private Pen penForPhantom = new Pen(Color.Blue, 1);
        #endregion  ------------------------------------- Pens
        // The id text from the Sd text file

        struct SdLine
        {
            #region Fields

            public String[] atoms;
            public int callNumber;
            public Dictionary<int, string> dancers;
            public int emptylinesBefore;
            public int noOfDancers;
            public List<int> noOfLeadingSpaces;
            public String text;
            public Boolean warning;
            #endregion Fields
        }
        #endregion  ------------------------------------- Attributes

        #region  ---------------------------------------- Methods
        public Form1()
        {
            InitializeComponent();
            this.init();
        }

        public void firstPage()
        {
            if (this.currentIndex > 0)
            {
                this.viewBitmap(0);
            }
        }
        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public void lastPage()
        {
            if (this.currentIndex > 0)
            {
                this.viewBitmap(this.bitmapList.Count - 1);
            }
        }

        public void nextPage()
        {
            if (this.currentIndex < this.bitmapList.Count)
            {
                this.viewBitmap(this.currentIndex + 1);
            }
        }

        public void previousPage()
        {
            if (this.currentIndex > 0)
            {
                this.viewBitmap(this.currentIndex - 1);
            }
        }

        public void printImage()
        {

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += docPrintPage;
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Height = 1200;
            previewDialog.Width = 800;
            previewDialog.Document = printDocument;
            pageIndex = 0;
            previewDialog.ShowDialog();
            // don't forget to detach the event handler when you are done
            printDocument.PrintPage -= docPrintPage;
        }

        Size calculateBitMapSize(List<SdLine> sdLineList, int maxWidth)
        {
            // Make reservation for one nose in each end in both directions
            int bitMapWidth = maxWidth + mus.NoseSize;

            int h = Math.Max(mus.NoseSize * 2 + mus.DancerSize, mus.NoseSize * 2 + mus.LineHeight);
            int numberOfLinesInFormation = sdLineList.Count;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++)
            {
                if (lineNumberInFormation > 0)
                {
                    int emptylinesBefore = Math.Max(1, (sdLineList[lineNumberInFormation].emptylinesBefore));
                    h += mus.LineHeight * emptylinesBefore;
                }
            }

            if (this.dancerView)
            {
                // Add space for casller
                h += mus.LineHeight;
            }
            Size bitMapSize = new Size(bitMapWidth, h);
            return bitMapSize;
        }

        private int checkBufferAndWriteCall(ref Bitmap pageBitmap, List<SdLine> sdLineList, int y, SdLine sdLine, ref int pageNumber,
             int marginTop, int maxTextLineLength, Boolean lineBreak, int noOfColumns,
            bool showCaller)
        {
            // The line contains a call 
            // Check if we have a buffer for the end formation from the last call.
            // If so we create the bitmap for that formation, and copies it to the page bitmap
            if (sdLineList.Count > 0)
            {
                int height1 = calculateBitMapSize(sdLineList, 0).Height;
                int h2 = y + height1;
                y += SPACE_BETWEEN_CALL_AND_FORMATION;
                int height = createAndCopyFormationBitmap(ref pageBitmap, checkBoxBorder.Checked, sdLineList, y, this.currentXoffset);
                y += height;
            }
            if (matchSdId(sdLine.text))
            {
                sdLineList.Clear();
            }
            else
            {
                // Add extra 5 pixelsfor safety (Needed due to some calculation miss)
                //int height = lineHeight * (buffer1.Count + 3) + MARGIN_TOP + 5;
                int height = calculateBitMapSize(sdLineList,  0).Height;
                sdLineList.Clear();
                if (y + height + mus.LineHeight * 2 > pageSize.Height - mus.MarginBottom)
                {
                    if (noOfColumns == 2 && IsOdd(pageNumber))
                    {

                        this.currentXoffset = pageSize.Width / 2;
                        y = marginTop + mus.LineHeight;

                    }
                    else
                    {
                        this.currentXoffset = 0;
                        this.bitmapList.Add(pageBitmap);
                        pageBitmap = new Bitmap(pageSize.Width, pageSize.Height);
                        y = marginTop;
                        writeCopyright(pageBitmap, mus.LineHeight);
                        int x = pageNumber;
                        if (noOfColumns == 2)
                        {
                            x = pageNumber / 2;
                        }
                        writePageHeader(pageBitmap, y, 1 + x, mus.LineHeight);
                        y += mus.LineHeight;
                    }
                    pageNumber++;
                }

                if (sdLine.callNumber == 0)
                {
                    y += mus.LineHeight / 2;
                    y = writeText(String.Format("{0}", sdLine.text), pageBitmap, y, this.currentXoffset,  lineBreak);
                    y += mus.LineHeight / 2;
                }
                else if (sdLine.callNumber > 0)
                {
                    y += mus.LineHeight;
                    y = writeText(String.Format("{0}) {1}", sdLine.callNumber, sdLine.text),  pageBitmap, y, this.currentXoffset, lineBreak);
                    y += mus.LineHeight / 2;
                }

            }
            return y;
        }


        private String cleanUp(string line)
        {
            String line1 = Regex.Replace(line, @"\{.*\}", ""); //Remove text within curly brackets
            //string pattern = @"([<>^V])       (\d)";
            //string replacement = "$1 " + SPACE_CHAR +" $2";
            //string line2 = Regex.Replace(line1, pattern, replacement);
            String line2 = line1.TrimEnd();
            //String line3 = Regex.Replace(line2, @"\s+", " ").Trim();//Remove extra whitespace

            return line2;
        }

        private void copyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        private int createAndCopyFormationBitmap(ref Bitmap bmp, Boolean drawBorder, List<SdLine> sdLineList, int y, int xOffset = 0)
        {
            int height = 0;
           
            //int lineHeight = (int)numericUpDownLineHeight.Value;
            using (Bitmap bmp1 = this.drawFormation(sdLineList, drawBorder,  checkBoxShowPartner.Checked, (int)numericUpDownNoseUp.Value))
            {
                Rectangle srcRegion = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                int destx0 = xOffset + pageSize.Width / 4 - bmp1.Width / 2 - marginLeftFormations;
                // Rectangle destRegion = new Rectangle(xOffset + MARGIN_LEFT, y, bmp1.Width, bmp1.Height);
                Rectangle destRegion = new Rectangle(destx0, y, bmp1.Width, bmp1.Height);
                copyRegionIntoImage(bmp1, srcRegion, ref bmp, destRegion);
                height = bmp1.Height;
            }

            return height;
        }

        private String createSdLines(string[] lines)
        {
            this.sdLines.Clear();
            String sdId = "";
            int lastNumberOfDancers = 0; ;
            List<SdLine> sdLinesTmp = new List<SdLine>();
            int numberOfEmptyLines = 0;
            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                Boolean emptyLine = false;
                String line0 = lines[lineIndex];
                Boolean warning = false;
                if (this.skip(ref line0, ref sdId, ref warning, ref emptyLine))
                {
                    if (emptyLine) numberOfEmptyLines++;
                    continue;
                }
                String line1 = cleanUp(line0);
                List<String> atoms = new List<String>();
                String trimmedLine = "";
                List<int> numberOfLeadingSpaces = xx(line1, ref atoms, ref trimmedLine);
                //int startIndex = 0;
                //int lastIndex = 0;
                //for (int atomsIndex=0; atomsIndex < atoms.Length; atomsIndex++) {
                //    String atom = atoms[atomsIndex];
                //    int index0=line1.IndexOf(atom, startIndex);
                //    int numberOfLeadingBlanks = index0;
                //    if (atomsIndex > 0) {
                //        numberOfLeadingBlanks -= (atoms[atomsIndex - 1].Length + lastIndex);
                //    }
                //    numberOfLeadingSpaces.Add(numberOfLeadingBlanks);
                //    lastIndex = index0;
                //    startIndex = numberOfLeadingBlanks+1;
                //}
                //String trimmedLine= Regex.Replace(line1, @"\s+", " ").Trim();//Remove extra whitespace
                Dictionary<int, string> dancers = findDancers(trimmedLine);
                SdLine sdLine = new SdLine();
                sdLine.noOfDancers = dancers.Count;
                sdLine.text = trimmedLine;
                sdLine.dancers = dancers;
                sdLine.atoms = atoms.ToArray();
                sdLine.warning = warning;
                sdLine.emptylinesBefore = numberOfEmptyLines;
                sdLine.noOfLeadingSpaces = numberOfLeadingSpaces;
                //this.sdLines.Add(sdLine);
                sdLinesTmp.Add(sdLine);
                numberOfEmptyLines = 0;
                lastNumberOfDancers = dancers.Count;
            }
            int callNumber = 0;
            Regex regex1 = new Regex(@"\(.*promenade\)");
            Regex regex2 = new Regex(@".+\(at home\)");
            for (int i = 0; i < sdLinesTmp.Count; i++)
            {
                Boolean addSequenceEnd = false;
                SdLine sdLine = sdLinesTmp[i];

                if (sdLine.warning)
                {
                    sdLine.callNumber = -1;
                }
                else if (sdLine.text == AT_HOME)
                {
                    sdLine.text = "------------ " + sdLine.text + " -------------";
                    sdLine.callNumber = 0;
                }
                else if (regex1.Match(sdLine.text).Success || regex2.Match(sdLine.text).Success)
                {
                    addSequenceEnd = true;

                }
                else if (sdLine.text == TWO_COUPLES_ONLY)
                {
                    sdLine.callNumber = -1;
                }
                else if (sdLine.text.Length < 1)
                {
                    // This test should not be necessary, but it is!
                    sdLine.callNumber = -1;
                }
                else if (sdLine.noOfDancers == 0)
                {
                    if (i > 0 && sdLinesTmp[i - 1].noOfDancers == 0)
                    {
                        //sdLine.callNumber = -1;
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    }
                    else if (i < sdLinesTmp.Count - 1 && sdLinesTmp[i + 1].noOfDancers == 0)
                    {
                        // sdLine.text += sdLinesTmp[i + 1].text;
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    }
                    else
                    {
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    }
                }
                this.sdLines.Add(sdLine);
                if (addSequenceEnd)
                {
                    SdLine sequenceEnd = new SdLine();
                    sequenceEnd.noOfDancers = 0;
                    sequenceEnd.text = sdLine.text = "---------------------- at home -----------------------";
                    sequenceEnd.dancers = new Dictionary<int, string>();
                    sequenceEnd.atoms = null;
                    sequenceEnd.warning = false;
                    this.sdLines.Add(sequenceEnd);
                }
            }
            return sdId;
        }

        private void createTip()
        {

            if (this.graphicsForm == null)
            {
                this.graphicsForm = new GraphicsForm(ref pictureBox1, this);
                this.graphicsForm.FormClosing += fManage_FormOneClosing;
                this.graphicsForm.Show();
                //PictureBox pictureBox1 = this.graphicsForm.getPictureBox();
            }
            PANEL_SCALE = (double)numericUpDownScale.Value;
            pictureBox1.Height = (int)(PANEL_SCALE * pageSize.Height);
            pictureBox1.Width = (int)(PANEL_SCALE * pageSize.Width);
            int heightOfTitleBar = 40;
            this.graphicsForm.Height = (int)(PANEL_SCALE * pageSize.Height) + pictureBox1.Location.Y + heightOfTitleBar;
            this.graphicsForm.Width = (int)(PANEL_SCALE * pageSize.Width) + 35;
            //DIAMOND_REDUCTION = (int)numericUpDownDiamondReduction.Value;
            //DIAMOND_WIDTH = (int)numericUpDownLineHeight.Value;
            this.bitmapList.Clear();
            string[] lines = { };
            if (File.Exists(fileName))
            {
                lines = File.ReadAllLines(fileName);
            }
            else
            {
                MessageBox.Show(String.Format("File {0} does not exist", fileName));
                this.Close();
            }

            this.sdPrintingId = this.createSdLines(lines);
            int lineHeight = mus.LineHeight;
            Bitmap pageBitmap = new Bitmap(pageSize.Width, pageSize.Height);
            //List<String[]> buffer = new List<string[]>();
            List<SdLine> sdLineList = new List<SdLine>();
            int y = mus.Margintop;

            Boolean skipNext = false;
            int pageNumber = 1;
            this.currentXoffset = 0;// MARGIN_LEFT;
            this.writePageHeader(pageBitmap, y, 1, lineHeight);
            this.writeCopyright(pageBitmap, lineHeight);
            y += lineHeight;
            //int callNumber = 0;
            String lastCall = "";
            for (int i = 0; i < sdLines.Count; i++)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }
                SdLine sdLine = sdLines[i];
                if (sdLine.noOfDancers == 0)
                {
                    if (lastCall != AT_HOME)
                    {
                        y = checkBufferAndWriteCall(ref pageBitmap, sdLineList, y, sdLine,
                             ref pageNumber,
                             mus.Margintop, mus.MaxLineLenght, mus.Breaklines,
                             (int)numericUpDownColumns.Value, checkBoxShowPartner.Checked);
                    }
                    lastCall = sdLine.text;
                }
                else if (lastCall != TWO_COUPLES_ONLY)
                {
                    sdLineList.Add(sdLine);
                }
            }
            // this.writeText("Copyright \u00a9 Bronc Wise 2012", lineHeight, pageBitmap, pageSize.Height - lineHeight, pageSize.Width / 2 - 100);

            this.bitmapList.Add(pageBitmap);  // The last bitmap (Could be a duplicate?)
            this.viewBitmap(0);
        }

        private void drawBorder(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawRectangle(penForBorder, 0, 0, bmp.Width, bmp.Height);
            }
        }

        private void drawCaller(ref Bitmap bmp)
        {
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int xc = bmp.Width / 2;
            int y = bmp.Height - mus.DancerSize - 2;
            int x = Math.Max(0, xc - mus.DancerSize / 2);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                g.DrawEllipse(penForCaller, x+2, y+2, (float) 0.8* mus.DancerSize, (float) 0.8* mus.DancerSize);
                g.DrawRectangle(penForCaller, x, y, mus.DancerSize, mus.DancerSize);
                g.FillEllipse(brushForCallerNose, x + mus.DancerSize / 2 - mus.NoseSize / 2, y - mus.NoseSize, mus.NoseSize, mus.NoseSize);
            }

        }

        private int drawDancerOrSpace(ref Bitmap bmp, int xc, int yc, String dancer,   bool showPartner, ref RotateFlipType rft)
        {
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int x = Math.Max(0, xc - mus.DancerSize / 2);
            int y = yc - mus.DancerSize / 2;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                bool isFocusDancer = false;

                if (dancer == ".")
                {
                    // the point is only 1 char, so we have to add an extra spcace before
                    g.DrawEllipse(penForPhantom, x - mus.BlankSpace, yc - mus.DancerSize / 2, mus.DancerSize, mus.DancerSize);
                    xc -= 2 * mus.BlankSpace;  // Subtle
                }
                else
                {
                    if (dancer[1] == 'B')
                    {
                        g.DrawRectangle(pen, x, y, mus.DancerSize, mus.DancerSize);
                    }
                    else
                    {
                        g.DrawEllipse(pen, x, y, mus.DancerSize, mus.DancerSize);
                    }
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    if (this.dancerView)
                    {
                        if (dancer[0] == numericUpDownNoseUp.Value.ToString()[0])
                        {
                            int symbolSize = mus.DancerSize / 3;
                            if (radioButtonBeau.Checked && dancer[1] == 'B')
                            {
                                isFocusDancer = true;
                                g.DrawRectangle(penForFocusDancer, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            }
                            else if (radioButtonBelle.Checked && dancer[1] == 'G')
                            {
                                isFocusDancer = true;
                                g.DrawEllipse(penForFocusDancer, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            }
                            else if (radioButtonBeau.Checked && dancer[1] == 'G' && showPartner)
                            {
                                g.DrawEllipse(penForPartner, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            }
                            else if (radioButtonBelle.Checked && dancer[1] == 'B' && showPartner)
                            {
                                g.DrawRectangle(penForPartner, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            }
                        }
                    }
                    else
                    {
                        g.DrawString(dancer[0].ToString(), fontForCalls, brushForDancers, x + 2, y + 2);
                    }


                    if (dancer[2] == '>')
                    {
                        if (isFocusDancer)
                        {
                            rft= RotateFlipType.Rotate270FlipNone;
                        }
                        g.FillEllipse(brushForNoses, x + mus.DancerSize, y + mus.DancerSize / 2 - mus.NoseSize / 2, mus.NoseSize, mus.NoseSize);
                    }
                    else if (dancer[2] == '<')
                    {
                        if (isFocusDancer)
                        {
                            rft = RotateFlipType.Rotate90FlipNone;
                        }
                        g.FillEllipse(brushForNoses, x - mus.NoseSize, y + mus.DancerSize / 2 - mus.NoseSize / 2, mus.NoseSize, mus.NoseSize);
                    }
                    else if (dancer[2] == '^')
                    {
                        g.FillEllipse(brushForNoses, x + mus.DancerSize / 2 - mus.NoseSize / 2, y - mus.NoseSize, mus.NoseSize, mus.NoseSize);
                    }
                    else if (dancer[2] == 'V')
                    {
                        if (isFocusDancer)
                        {
                            rft = RotateFlipType.Rotate180FlipNone;
                        }
                        g.FillEllipse(brushForNoses, x + mus.DancerSize / 2 - mus.NoseSize / 2, y + mus.DancerSize, mus.NoseSize, mus.NoseSize);
                    }
                }
            }

            return xc + mus.DancerSize;
        }

        private Bitmap drawFormation(List<SdLine> sdLineList, Boolean drawBorder,  bool showPartner, int noseUpDancer)
        {
            int y = mus.NoseSize + mus.DancerSize / 2;
            int maxNumberOfPositions = 0;
            //foreach (String[] dancers in buffer) {
            //    if (dancers.Length > maxNumberOfPositions) {
            //        maxNumberOfPositions = dancers.Length;
            //    }
            //}

            //int maxNumberOfPositions1 = 0;
            //int numberOfSpaces = 0;
            int maxWidth = 0;  // pixels
            foreach (SdLine sdLine in sdLineList)
            {
                if (sdLine.noOfDancers > maxNumberOfPositions)
                {
                    maxNumberOfPositions = sdLine.noOfDancers;
                }
                int width = sdLine.noOfDancers * mus.DancerSize; //pixels
                foreach (int n in sdLine.noOfLeadingSpaces)
                {
                    width += n * mus.BlankSpace;
                }
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }


            Size bitMapSize = calculateBitMapSize(sdLineList, maxWidth);

            Bitmap bmp1 = new Bitmap(bitMapSize.Width, bitMapSize.Height);
            int numberOfLinesInFormation = sdLineList.Count;
            RotateFlipType rft = RotateFlipType.RotateNoneFlipNone;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++)
            {
                //            foreach (String[] dancers in buffer) {
                String[] positions = sdLineList[lineNumberInFormation].atoms;
                List<int> noOfLeadingSpaces = sdLineList[lineNumberInFormation].noOfLeadingSpaces;
                int xCenter = mus.DancerSize / 2; //+NOSE_SIZE
                if (lineNumberInFormation > 0)
                {

                    int emptylinesBefore = Math.Max(1, (sdLineList[lineNumberInFormation].emptylinesBefore));
                    y += mus.LineHeight * emptylinesBefore;


                }
              
                for (int i = 0; i < positions.Length; i++)
                {
                    xCenter = drawDancerOrSpace(ref bmp1, xCenter + noOfLeadingSpaces[i] * mus.BlankSpace, y, positions[i],
                        showPartner,ref rft);
                }
                if (this.dancerView)
                {
                    this.drawCaller(ref bmp1);
                }

            }
            if (drawBorder)
            {
                this.drawBorder(bmp1);
            }
            bmp1.RotateFlip(rft);
            return bmp1;

        }
        private Dictionary<int, string> findDancers(String line)
        {
            String[] atoms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, string> dancers = new Dictionary<int, string>();
            Regex regex = new Regex(@"\d[BG][\^V<>]");
            for (int i = 0; i < atoms.Length; i++)
            {

                Match match = regex.Match(atoms[i]);

                if (match.Success || atoms[i] == ".")
                {
                    dancers.Add(i, atoms[i]);
                }
            }
            return dancers;
        }

        private int getNumberOfDancers(String[] line)
        {
            int length = line.Length;
            return length;
        }

        private void init()
        {
            //numericUpDownScale.Value = (decimal) 0.7;
            this.numericUpDownScale.ValueChanged += new System.EventHandler(this.numericUpDownScale_ValueChanged);

            this.mus = new MyUserSettings();
            this.mus.Reload();
            //mus.Save();

        }

        private Boolean matchSdId(String line)
        {
            Boolean retVal = false;
            //Sd38.45:db38.45
            Regex regex = new Regex(@".*Sd\d\d\.\d\d:");

            Match match = regex.Match(line);

            if (match.Success)
            {
                retVal = true;
            }
            return retVal;
        }

        private void openSdFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"e:\Mina dokument\Sqd\SD";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.fileName = openFileDialog.FileName;
                    textBoxFile.Text = this.fileName;
                    buttonReadFile.Enabled = true;
                    printToolStripMenuItem.Enabled = true;
                    this.createTip();
                    numericUpDownScale.Enabled = true;
                }
            }
        }

        private void setViewTypeName()
        {
            if (radioButtonDancerView.Checked) {
                if (radioButtonBeau.Checked) {
                    this.ViewTypeName = String.Format("Dancer View Couple nr {0}, Beau", numericUpDownNoseUp.Value);
                }
                else {
                    this.ViewTypeName = String.Format("Dancer View Couple nr {0}, Belle", numericUpDownNoseUp.Value);
                }
            }
            else {
                this.ViewTypeName = String.Format("Caller View");
            }
        }

        private Boolean skip(ref String line, ref String sdId, ref Boolean warning, ref Boolean emptyLine)
        {
            Boolean skip = false;
            warning = false;

            Regex digitsOnlyRegex = new Regex(@"^\s*\d+$");

            if (matchSdId(line))
            {
                sdId = line;
                skip = true;
            }
            else if (digitsOnlyRegex.Match(line).Success)
            {
                skip = true;  // Digits only
            }
            else if (line.Length == 1)
            {
                if (line[0] == FF)
                {
                    //line = AT_HOME;
                    skip = true;
                }
                else
                {
                    emptyLine = true;
                    skip = true;
                }
            }
            else if (line.Length < 2)
            {
                skip = true;
                emptyLine = true;
            }
            else if (line.Contains("Warning"))
            {
                //skip = true;
                warning = true;
            }
            return skip;
        }

        private void viewBitmap(int index = 0)
        {
            if (this.bitmapList.Count > index)
            {
                Bitmap original = this.bitmapList[index];
                Bitmap scaled = new Bitmap(original, new Size((int)(PANEL_SCALE * (double)original.Width), (int)(PANEL_SCALE * (double)original.Height)));

                pictureBox1.Image = scaled;
                // pictureBox1.Image = this.bitmapList[index];
                pictureBox1.Refresh();
                this.currentIndex = index;
            }
        }

        private void writeCopyright(Bitmap pageBitmap, int lineHeight)
        {
            this.writeText(String.Format("Copyright \u00a9 {0} {1}", mus.Copyrightname, mus.Copyrightyear),
                pageBitmap, pageSize.Height - lineHeight, pageSize.Width / 2 - 150,  false);
        }

        private int writePageHeader(Bitmap pageBitmap, int y, int pageNumber, int lineHeight)
        {
            
            return writeText(String.Format("Sd file={0}     View={1}          Page {2}",
                Path.GetFileName(fileName),this.ViewTypeName, pageNumber),
                pageBitmap, y, 0, false);
        }

        private int writeText(string line, Bitmap bmp, int y, int xOffset,  Boolean lineBreak)
        {
            int x = xOffset + marginLeftText;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                int breakIndex = line.LastIndexOf(' ', Math.Min(line.Length - 1,mus.MaxLineLenght));

                if (breakIndex > 0 && line.Length >mus.MaxLineLenght && lineBreak)
                {
                    String line1 = line.Substring(0, breakIndex);
                    String line2 = "  " + line.Substring(breakIndex, line.Length - breakIndex);
                    g.DrawString(line1, this.fontForCalls, brushForCalls, x, y);
                    y += mus.LineHeight;
                    g.DrawString(line2, this.fontForCalls, brushForCalls, x, y);
                }
                else
                {
                    g.DrawString(line, this.fontForCalls, brushForCalls, x, y);
                }
            }
            return y;
        }

        private List<int> xx(String line, ref List<String> atoms, ref String trimmedLine)
        {
            List<int> numberOfLeadingSpaces = new List<int>();
            trimmedLine = Regex.Replace(line, @"\s+", " ").Trim();//Remove extra whitespace
            Dictionary<int, string> dancers = findDancers(trimmedLine);
            if (dancers.Count > 0)
            {
                atoms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                int j = 0;
                numberOfLeadingSpaces.Add(0);
                Boolean lastCharWasSpace = false;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (c == ' ')
                    {
                        numberOfLeadingSpaces[j]++;
                        lastCharWasSpace = true;
                    }
                    else
                    {
                        if (lastCharWasSpace)
                        {
                            numberOfLeadingSpaces.Add(0);
                            j++;
                        }
                        lastCharWasSpace = false;
                    }
                }
            }
            if (atoms.Count > 0 && numberOfLeadingSpaces.Count <= atoms.Count)
            {
                return numberOfLeadingSpaces;
            }
            else
            {
                return numberOfLeadingSpaces;
            }

        }
        #endregion  ------------------------------------- Methods

        #region ----------------------------------------  Event Handlers

        public void fManage_FormOneClosing(object sender, FormClosingEventArgs e)
        {
            this.graphicsForm = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.previousPage();
        }


        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            this.previousPage();
        }

        private void buttonBeginnin_Click(object sender, EventArgs e)
        {
            this.firstPage();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.lastPage();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            this.nextPage();
        }


        private void buttonForward_Click_1(object sender, EventArgs e)
        {
            this.nextPage();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            this.openSdFile();

        }


        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.printImage();
        }

        private void buttonReadFile_Click(object sender, EventArgs e)
        {
            this.createTip();
        }

        private void docPrintPage(object sender, PrintPageEventArgs e)
        {
            if (pageIndex >= this.bitmapList.Count)
            {
                pageIndex = 0;
            }
            //// Draw the image for the current page index
            e.Graphics.DrawImageUnscaled(bitmapList[pageIndex],
                                         e.PageBounds.X,
                                         e.PageBounds.Y);
            // increment page index
            pageIndex++;
            // indicate whether there are more pages or not
            e.HasMorePages = (pageIndex < this.bitmapList.Count);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownNoseUp_ValueChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();
        }

        private void numericUpDownScale_ValueChanged(object sender, EventArgs e)
        {
            this.createTip();
        }
        private void openSdFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openSdFile();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printImage();
        }

        private void radioButtonBeau_CheckedChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();

        }

        private void radioButtonDancerView_CheckedChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();
            if (radioButtonDancerView.Checked)
            {
                groupBoxFocusDancer.Enabled = true;
                this.dancerView = true;
            }
            else
            {
                groupBoxFocusDancer.Enabled = false;
                this.dancerView = false;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }
    }

    #endregion ------------------------------------- Event Handlers


}
