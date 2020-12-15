using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SdGraphics
{
    public partial class Form1 : Form
    {
        #region ----------------------------------------- Attributes
        public static Char FF = '\f';
        public static String TWO_COUPLES_ONLY = "Two couples only";
        public int currentXoffset = 0;
        public int DIAMOND_REDUCTION = 7;
        public int DIAMOND_WIDTH = 3;
        private static String AT_HOME = "at home";
        //private int DANCER_SIZE = 18;
        //private static bool DRAW_BORDER = false;
        //private static int HORIZONTAL_SPACE = 30;
        //private static int BLANK_SPACE = 6;
        private static int LEFT_SHIFT = 30;
        private static int LINE_HEIGHT = 20;
        //private static int LINE_HEIGHT_FORMATION = 27;
        private static int LINE_LENGTH = 75;
        private static int MARGIN_BOTTOM = 50;
        private static int MARGIN_LEFT = 40; // For text only
        private static int MARGIN_TOP = 15;
        //private static int NOSE_SIZE = 6;
        private static int PAGE_HEIGHT = 1100;
        private static int PAGE_WIDTH = 778;
        //private static int MIDDLE = 150;
        private static String SPACE_CHAR = "%";
        private List<Bitmap> bitmapList = new List<Bitmap>();
        //=210 * PAGE_HEIGHT / 297; // A4= 210 mm × 297 mm
        Brush brushForCalls = new SolidBrush(System.Drawing.Color.Black);

        Brush brushForDancers = new SolidBrush(System.Drawing.Color.Black);
        Brush brushForNoses = new SolidBrush(System.Drawing.Color.Red);
        Brush brushForSpace = new SolidBrush(System.Drawing.Color.Blue);
        private String copyright;
        private int currentIndex = -1;
        // For display
        //private String fileName = @"e:\Downloads\sequence_C1.txt";
        private String fileName;

        Font fontForCalls = new Font("Helvetica", 10, FontStyle.Bold);
        private Form graphicsForm;
        private int pageIndex = 0;
        private double PANEL_SCALE = 1;
        Pen penForBorder = new Pen(Color.Red, 2);
        Pen penForPhantom = new Pen(Color.Blue, 1);
        private PictureBox pictureBox1 = new PictureBox();
        // For printing
        private String sdId = "";

        private List<SdLine> sdLines = new List<SdLine>();
        private int SPACE_BETWEEN_CALL_AND_FORMATION = 15;
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
            if (this.currentIndex > 0) {
                this.viewBitmap(0);
            }
        }
        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public void lastPage()
        {
            if (this.currentIndex > 0) {
                this.viewBitmap(this.bitmapList.Count - 1);
            }
        }

        public void nextPage()
        {
            if (this.currentIndex < this.bitmapList.Count) {
                this.viewBitmap(this.currentIndex + 1);
            }
        }

        public void previousPage()
        {
            if (this.currentIndex > 0) {
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

        Size calculateBitMapSize(List<SdLine> buffer1, int lineHeight, int maxWidth, int dancerSize, int noseSize)
        {
            // Make reservation for one nose in each end in both directions
            int bitMapWidth = maxWidth + noseSize;
            
            //int h = Math.Max(NOSE_SIZE*2 + dancerSize, NOSE_SIZE*2+lineHeight);
            int h = Math.Max(noseSize*2 + dancerSize, noseSize*2 + lineHeight);
            int numberOfLinesInFormation = buffer1.Count;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++) {
                if (lineNumberInFormation > 0) {
                    int emptylinesBefore= Math.Max(1,(buffer1[lineNumberInFormation].emptylinesBefore));
                    h += lineHeight * emptylinesBefore;
                }
                //if (lineNumberInFormation < numberOfLinesInFormation - 1) {
                //    int numberOfDancersInThisLine = this.getNumberOfDancers(positions);
                //    int numberOfDancersInNextLine = this.getNumberOfDancers(buffer1[lineNumberInFormation + 1].atoms);
                //    if ((IsOdd(numberOfDancersInThisLine) && !IsOdd(numberOfDancersInNextLine)) ||
                //        (!IsOdd(numberOfDancersInThisLine) && IsOdd(numberOfDancersInNextLine))) {
                //        y -= DIAMOND_REDUCTION;
                //    }
                //}
            }



           // int bitMapHeight = buffer1.Count * 2 * lineHeight;
            // + NOSE_SIZE;
            Size bitMapSize = new Size(bitMapWidth, h);
            return bitMapSize;
        }

        private int checkBufferAndWriteCall(ref Bitmap pageBitmap,  List<SdLine> buffer1, int y,  SdLine sdLine, ref int pageNumber,
            int lineHeight, int noseSize)
        {
            // The line contains a call 
            // Check if we have a buffer for the end formation from the last call.
            // If so we create the bitmap for that formation, and copies it to the page bitmap
            if (buffer1.Count > 0) {
                int height1 = calculateBitMapSize(buffer1, lineHeight, 0, (int)numericUpDownDancersSize.Value, noseSize).Height;
                int h2 = y + height1;
                y += SPACE_BETWEEN_CALL_AND_FORMATION;
                int height = createAndCopyFormationBitmap(ref pageBitmap, checkBoxBorder.Checked, buffer1, y, this.currentXoffset);
                y += height;
            }
            if (matchSdId(sdLine.text)) {
                buffer1.Clear();
            } else {
                // Add extra 5 pixelsfor safety (Needed due to some calculation miss)
                //int height = lineHeight * (buffer1.Count + 3) + MARGIN_TOP + 5;
                int height= calculateBitMapSize(buffer1, lineHeight, 0, (int) numericUpDownDancersSize.Value, noseSize).Height;
                buffer1.Clear();
                if (y + height +LINE_HEIGHT*2 > PAGE_HEIGHT - MARGIN_BOTTOM) {
                    if (IsOdd(pageNumber)) {

                        this.currentXoffset = PAGE_WIDTH / 2; //+MARGIN_LEFT
                        y = MARGIN_TOP + lineHeight;

                        //y = writeText(String.Format("Sd file= {0}                  Page {1}", this.fileName, pageNumber),
                        //    pageBitmap, y, MARGIN_LEFT, false);
                    } else {
                        this.currentXoffset = 0;//MARGIN_LEFT
                        this.bitmapList.Add(pageBitmap);
                        pageBitmap = new Bitmap(PAGE_WIDTH, PAGE_HEIGHT);
                        y = MARGIN_TOP;
                        writeCopyright(pageBitmap, lineHeight);
                        writePageHeader(pageBitmap, y, 1 + pageNumber / 2, lineHeight);
                        y += lineHeight;
                    }
                    pageNumber++;


                    //y += LINE_HEIGHT;

                }
                // Check if Sd has written the call on two lines
                //if (i < sdLines.Count - 1) {
                //    // If the next line does not contains the Sd id, we shall join it with the current line
                //    if (!matchSdId(sdLines[i + 1].text)) {
                //        if (sdLines[i + 1].noOfDancers == 0) {
                //            sdLine.text += sdLines[i + 1].text;
                //            skipNext = true;
                //        }
                //    }
                //}


                if (sdLine.callNumber == 0) {
                    y += lineHeight / 2;
                    y = writeText(String.Format("{0}", sdLine.text), lineHeight, pageBitmap, y, this.currentXoffset);
                    y += lineHeight / 2;
                } else if (sdLine.callNumber > 0) {
                    y += lineHeight;
                    y = writeText(String.Format("{0}) {1}", sdLine.callNumber, sdLine.text), lineHeight, pageBitmap, y, this.currentXoffset);
                    y += lineHeight / 2;
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
            using (Graphics grD = Graphics.FromImage(destBitmap)) {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        private int createAndCopyFormationBitmap(ref Bitmap bmp, Boolean drawBorder, List<SdLine>buffer1, int y, int xOffset = 0)
        {
            int height = 0;
            int dancerSize = (int) numericUpDownDancersSize.Value;
            int lineHeight = (int)numericUpDownLineHeight.Value;
            using (Bitmap bmp1 = this.drawFormation(buffer1, drawBorder, dancerSize, lineHeight, 
                (int) numericUpDownBlankSpace.Value, (int) numericUpDownNoseSize.Value)) {
                Rectangle srcRegion = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                int destx0 = xOffset+PAGE_WIDTH/4 - bmp1.Width/2 -LEFT_SHIFT ;
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
            for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++) {
                Boolean emptyLine = false;
                String line0 = lines[lineIndex];
                Boolean warning = false;
                if (this.skip(ref line0, ref sdId, ref warning, ref emptyLine)) {
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
            for (int i = 0; i < sdLinesTmp.Count; i++) {
                Boolean addSequenceEnd = false;
                SdLine sdLine = sdLinesTmp[i];

                if (sdLine.warning) {
                    sdLine.callNumber = -1;
                } else if (sdLine.text == AT_HOME) {
                    sdLine.text = "---------------------- " + sdLine.text + " -----------------------";
                    sdLine.callNumber = 0;
                } else if (regex1.Match(sdLine.text).Success || regex2.Match(sdLine.text).Success) {
                    addSequenceEnd = true;

                } else if (sdLine.text == TWO_COUPLES_ONLY) {
                    sdLine.callNumber = -1;
                } else if (sdLine.text.Length < 1) {
                    // This test should not be necessary, but it is!
                    sdLine.callNumber = -1;
                } else if (sdLine.noOfDancers == 0) {
                    if (i > 0 && sdLinesTmp[i - 1].noOfDancers == 0) {
                        //sdLine.callNumber = -1;
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    } else if (i < sdLinesTmp.Count - 1 && sdLinesTmp[i + 1].noOfDancers == 0) {
                        // sdLine.text += sdLinesTmp[i + 1].text;
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    } else {
                        callNumber++;
                        sdLine.callNumber = callNumber;
                    }
                }
                this.sdLines.Add(sdLine);
                if (addSequenceEnd) {
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

            if (this.graphicsForm == null) {
                this.graphicsForm = new GraphicsForm(ref pictureBox1, this);
                this.graphicsForm.FormClosing += fManage_FormOneClosing;
                this.graphicsForm.Show();
                //PictureBox pictureBox1 = this.graphicsForm.getPictureBox();
            }
            PANEL_SCALE = (double)numericUpDownScale.Value;
            pictureBox1.Height = (int)(PANEL_SCALE * PAGE_HEIGHT);
            pictureBox1.Width = (int)(PANEL_SCALE * PAGE_WIDTH);
            int heightOfTitleBar = 40;
            this.graphicsForm.Height = (int)(PANEL_SCALE * PAGE_HEIGHT) + pictureBox1.Location.Y+ heightOfTitleBar;
            this.graphicsForm.Width = (int)(PANEL_SCALE * PAGE_WIDTH) + 35;
            //DIAMOND_REDUCTION = (int)numericUpDownDiamondReduction.Value;
            //DIAMOND_WIDTH = (int)numericUpDownLineHeight.Value;
            this.bitmapList.Clear();
            string[] lines = { };
            if (File.Exists(fileName)) {
                lines = File.ReadAllLines(fileName);
            } else {
                MessageBox.Show(String.Format("File {0} does not exist", fileName));
                this.Close();
            }

            this.sdId = this.createSdLines(lines);
            int lineHeight = (int)numericUpDownLineHeight.Value;
            Bitmap pageBitmap = new Bitmap(PAGE_WIDTH, PAGE_HEIGHT);
            //List<String[]> buffer = new List<string[]>();
            List<SdLine> buffer1 = new List<SdLine>();
            int y = MARGIN_TOP;

            Boolean skipNext = false;
            int pageNumber = 1;
            this.currentXoffset = 0;// MARGIN_LEFT;
            this.writePageHeader(pageBitmap, y, 1, lineHeight);
            this.writeCopyright(pageBitmap, lineHeight);
            y += lineHeight;
            //int callNumber = 0;
            String lastCall = "";
            for (int i = 0; i < sdLines.Count; i++) {
                if (skipNext) {
                    skipNext = false;
                    continue;
                }
                SdLine sdLine = sdLines[i];
                if (sdLine.noOfDancers == 0) {
                    if (lastCall != AT_HOME) {
                       y= checkBufferAndWriteCall(ref pageBitmap, buffer1, y, sdLine,
                            ref pageNumber, lineHeight, (int) numericUpDownNoseSize.Value);
                    }
                    lastCall = sdLine.text;
                } else if (lastCall != TWO_COUPLES_ONLY) {
                    buffer1.Add(sdLine);
                }
            }
           // this.writeText("Copyright \u00a9 Bronc Wise 2012", lineHeight, pageBitmap, PAGE_HEIGHT - lineHeight, PAGE_WIDTH / 2 - 100);

            this.bitmapList.Add(pageBitmap);  // The last bitmap (Could be a duplicate?)
            this.viewBitmap(0);
        }

        private void drawBorder(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawRectangle(penForBorder, 0, 0, bmp.Width, bmp.Height);
            }
        }

        private int drawDancerOrSpace(ref Bitmap bmp, int xc, int yc, String dancer, int dancerSize, int blankSpace, int noseSize)
        {
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int x = Math.Max(0, xc - dancerSize / 2);
            int y = yc - dancerSize / 2;
            using (Graphics g = Graphics.FromImage(bmp)) {
                if (dancer == ".") {
                    // the point is only 1 char, so we have to add an extra spcace before
                    g.DrawEllipse(penForPhantom, x - blankSpace, yc - dancerSize / 2, dancerSize, dancerSize);
                    xc -= 2 * blankSpace;  // Subtle


                } else if (dancer == SPACE_CHAR) {
                    String extraSpace = " ".PadLeft(DIAMOND_WIDTH);  // Does not work
                    g.DrawString(extraSpace, fontForCalls, brushForDancers, x, y);

                } else {
                    if (dancer[1] == 'B') {
                        g.DrawRectangle(pen, x, y, dancerSize, dancerSize);
                    } else {
                        g.DrawEllipse(pen, x, y, dancerSize, dancerSize);
                    }
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    g.DrawString(dancer[0].ToString(), fontForCalls, brushForDancers, x + 2, y + 2);

                    if (dancer[2] == '>') {
                        g.FillEllipse(brushForNoses, x + dancerSize, y + dancerSize / 2 - noseSize / 2, noseSize, noseSize);
                    } else if (dancer[2] == '<') {
                        g.FillEllipse(brushForNoses, x - noseSize, y + dancerSize / 2 - noseSize / 2, noseSize, noseSize);
                    } else if (dancer[2] == '^') {
                        g.FillEllipse(brushForNoses, x + dancerSize / 2 - noseSize / 2, y - noseSize, noseSize, noseSize);
                    } else if (dancer[2] == 'V') {
                        g.FillEllipse(brushForNoses, x + dancerSize / 2 - noseSize / 2, y + dancerSize, noseSize, noseSize);
                    }
                }
                //g.DrawString(String.Format("Line {0}", accCounter + 1), fy, br, leftMargin, y);
            }
            return xc + dancerSize;
        }

        private Bitmap drawFormation(List<SdLine> buffer1, Boolean drawBorder, int dancerSize, int lineHeight,
                    int blankSpace, int noseSize)
        {
            int y = noseSize + dancerSize / 2;
            int maxNumberOfPositions = 0;
            //foreach (String[] dancers in buffer) {
            //    if (dancers.Length > maxNumberOfPositions) {
            //        maxNumberOfPositions = dancers.Length;
            //    }
            //}

            //int maxNumberOfPositions1 = 0;
            //int numberOfSpaces = 0;
            int maxWidth = 0;  // pixels
            foreach (SdLine sdLine in buffer1) {
                if (sdLine.noOfDancers > maxNumberOfPositions) {
                    maxNumberOfPositions = sdLine.noOfDancers;
                }
                int width = sdLine.noOfDancers * dancerSize; //pixels
                foreach (int n in sdLine.noOfLeadingSpaces) {
                    width += n * blankSpace;
                }
                if (width > maxWidth) {
                    maxWidth = width;
                }
            }

            
            Size bitMapSize=  calculateBitMapSize(buffer1, lineHeight, maxWidth, dancerSize, noseSize);

            Bitmap bmp1 = new Bitmap(bitMapSize.Width, bitMapSize.Height);
            int numberOfLinesInFormation = buffer1.Count;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++) {
                //            foreach (String[] dancers in buffer) {
                String[] positions = buffer1[lineNumberInFormation].atoms;
                List<int> noOfLeadingSpaces = buffer1[lineNumberInFormation].noOfLeadingSpaces;
                int xCenter = dancerSize / 2; //+NOSE_SIZE
                if (lineNumberInFormation > 0) {

                    int emptylinesBefore = Math.Max(1, (buffer1[lineNumberInFormation].emptylinesBefore));
                    y += lineHeight * emptylinesBefore;


                }
                for (int i = 0; i < positions.Length; i++) {
                    xCenter = drawDancerOrSpace(ref bmp1, xCenter + noOfLeadingSpaces[i] * blankSpace, y, positions[i],
                        dancerSize, blankSpace, noseSize);
                }
                //if (lineNumberInFormation < numberOfLinesInFormation - 1) {
                //    int numberOfDancersInThisLine = this.getNumberOfDancers(positions);
                //    int numberOfDancersInNextLine = this.getNumberOfDancers(buffer1[lineNumberInFormation + 1].atoms);
                //    if ((IsOdd(numberOfDancersInThisLine) && !IsOdd(numberOfDancersInNextLine)) ||
                //        (!IsOdd(numberOfDancersInThisLine) && IsOdd(numberOfDancersInNextLine))) {
                //        y -= DIAMOND_REDUCTION;
                //    }
                //}
            }
            //bmp1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (drawBorder) {
                this.drawBorder(bmp1);
            }
            return bmp1;

        }
        private Dictionary<int, string> findDancers(String line)
        {
            String[] atoms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, string> dancers = new Dictionary<int, string>();
            Regex regex = new Regex(@"\d[BG][\^V<>]");
            for (int i = 0; i < atoms.Length; i++) {

                Match match = regex.Match(atoms[i]);

                if (match.Success || atoms[i] == "." || atoms[i] == SPACE_CHAR) {
                    dancers.Add(i, atoms[i]);
                }
            }
            return dancers;
        }

        private int getNumberOfDancers(String[] line)
        {
            int length = line.Length;
            foreach (String postion in line) {
                if (postion == SPACE_CHAR) {
                    length--;
                }
            }
            return length;
        }

        private void init()
        {
            //numericUpDownScale.Value = (decimal) 0.7;
            this.numericUpDownScale.ValueChanged += new System.EventHandler(this.numericUpDownScale_ValueChanged);
        }

        private Boolean matchSdId(String line)
        {
            Boolean retVal = false;
            //Sd38.45:db38.45
            Regex regex = new Regex(@".*Sd\d\d\.\d\d:");

            Match match = regex.Match(line);

            if (match.Success) {
                retVal = true;
            }
            return retVal;
        }
        private Boolean skip(ref String line, ref String sdId, ref Boolean warning, ref Boolean emptyLine)
        {
            Boolean skip = false;
            warning = false;

            Regex digitsOnlyRegex = new Regex(@"^\s*\d+$");

            if (matchSdId(line)) {
                sdId = line;
                skip = true;
            } else if (digitsOnlyRegex.Match(line).Success) {
                skip = true;  // Digits only
            } else if (line.Length == 1) {
                if (line[0] == FF) {
                    //line = AT_HOME;
                    skip = true;
                } else {
                    emptyLine = true;
                    skip = true;
                }
            } else if (line.Length < 2) {
                skip = true;
                emptyLine = true;
            } else if (line.Contains("Warning")) {
                //skip = true;
                warning = true;
            }
            return skip;
        }

        private void viewBitmap(int index = 0)
        {
            if (this.bitmapList.Count > index) {
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
            this.writeText(String.Format("Copyright \u00a9 {0} {1}", textBoxCopyrightName.Text, numericUpDownCopyrightYear.Value),
                lineHeight, pageBitmap, PAGE_HEIGHT - lineHeight, PAGE_WIDTH / 2 - 150);
        }

        private int writePageHeader(Bitmap pageBitmap, int y, int pageNumber, int lineHeight)
        {
            return writeText(String.Format("Sd file={0}     Date={1}          Page {2}",
                Path.GetFileName(fileName), this.sdId, pageNumber), lineHeight, pageBitmap, y, 0, false);
        }

        private int writeText(string line, int lineHeight, Bitmap bmp, int y, int xOffset, Boolean lineBreak = true)
        {
            int x = xOffset+MARGIN_LEFT;
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                if (line.Length > LINE_LENGTH && lineBreak) {
                    String line1 = line.Substring(0, LINE_LENGTH);
                    String line2 = line.Substring(LINE_LENGTH, line.Length - LINE_LENGTH);
                    g.DrawString(line1, this.fontForCalls, brushForCalls, x, y);
                    y += lineHeight;
                    g.DrawString(line2, this.fontForCalls, brushForCalls, x, y);
                } else {
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
            if (dancers.Count > 0) {
                atoms = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                int j = 0;
                numberOfLeadingSpaces.Add(0);
                Boolean lastCharWasSpace = false;
                for (int i = 0; i < line.Length; i++) {
                    char c = line[i];
                    if (c == ' ') {
                        numberOfLeadingSpaces[j]++;
                        lastCharWasSpace = true;
                    } else {
                        if (lastCharWasSpace) {
                            numberOfLeadingSpaces.Add(0);
                            j++;
                        }
                        lastCharWasSpace = false;
                    }
                }
            }
            if (atoms.Count >0 && numberOfLeadingSpaces.Count <= atoms.Count) {
                return numberOfLeadingSpaces;
            } else {
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = @"e:\Mina dokument\Sqd\SD";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    this.fileName = openFileDialog.FileName;
                    buttonReadFile.Enabled = true;
                    buttonPrint.Enabled = true;
                    this.createTip();
                    numericUpDownScale.Enabled = true;
                }
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printImage();
        }

        private void buttonReadFile_Click(object sender, EventArgs e)
        {
            this.createTip();
        }

        private void docPrintPage(object sender, PrintPageEventArgs e)
        {
            if (pageIndex >= this.bitmapList.Count) {
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

        private void numericUpDownScale_ValueChanged(object sender, EventArgs e)
        {
            this.createTip();
        }

        private void textBoxCopyright_TextChanged(object sender, EventArgs e)
        {
            this.copyright = textBoxCopyrightName.Text;
        }
        #endregion ------------------------------------- Event Handlers
    }
}
