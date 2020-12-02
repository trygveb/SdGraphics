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
        private static int DANCER_SIZE = 18;
        private static bool DRAW_BORDER = false;
        private static int HORIZONTAL_SPACE = 30;
        private static int LINE_HEIGHT = 30;
        private static int LINE_HEIGHT_FORMATION = 27;
        private static int LINE_LENGTH = 75;
        private static int MARGIN_BOTTOM = 50;
        private static int MARGIN_LEFT = 25;
        private static int MARGIN_TOP = 15;
        private static int NOSE_SIZE = 6;
        private static int PAGE_HEIGHT = 1100;
        private static int PAGE_WIDTH = 778;
        private static String SPACE_CHAR = "%";
        private List<Bitmap> bitmapList = new List<Bitmap>();
        //=210 * PAGE_HEIGHT / 297; // A4= 210 mm × 297 mm
        Brush brushForCalls = new SolidBrush(System.Drawing.Color.Black);

        Brush brushForDancers = new SolidBrush(System.Drawing.Color.Black);
        Brush brushForNoses = new SolidBrush(System.Drawing.Color.Red);
        Brush brushForSpace = new SolidBrush(System.Drawing.Color.Green);
        private String copyright;
        private int currentIndex = 0;
        // For display
        //private String fileName = @"e:\Downloads\sequence_C1.txt";
        private String fileName = @"c:\Sd\Tony_C3_Tip_01.txt";

        Font fontForCalls = new Font("Helvetica", 10, FontStyle.Bold);
        private Form graphicsForm;
        private int pageIndex = 0;
        private double PANEL_SCALE = 1;
        private PictureBox pictureBox1 = new PictureBox();
        // For printing
        private String sdId = "";
        private List<SdLine> sdLines = new List<SdLine>();
        // The id text from the Sd text file

        struct SdLine
        {
            #region Fields

            public String[] atoms;
            public int callNumber;
            public Dictionary<int, string> dancers;
            public int emptylinesBefore;
            public int noOfDancers;
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

        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        private void checkBufferAndWriteCall(ref Bitmap pageBitmap, List<string[]> buffer, ref int y, ref int callNumber,
                    ref bool skipNext, int i, SdLine sdLine, ref int pageNumber)
        {
            // The line contains a call 
            // Check if we have a buffer for the end formation from the last call.
            // If so we create the bitmap for that formation, and copies it to the page bitmap
            if (buffer.Count > 0) {
                int height = createAndCopyFormationBitmap(ref pageBitmap, buffer, y, this.currentXoffset);
                y += height;
            }
            if (matchSdId(sdLine.text)) {
                // Do nothing
            } else {
                // Add extra 5 pixelsfor safety (Needed due to some calculation miss)
                if (y + LINE_HEIGHT * (buffer.Count + 3) + MARGIN_TOP + 5 > PAGE_HEIGHT - MARGIN_BOTTOM) {
                    if (IsOdd(pageNumber)) {

                        this.writeText(String.Format("Copyright \u00a9 {0}", this.copyright), pageBitmap, PAGE_HEIGHT - LINE_HEIGHT, PAGE_WIDTH / 2 - 100);
                        this.currentXoffset = MARGIN_LEFT + PAGE_WIDTH / 2;
                        y = MARGIN_TOP + LINE_HEIGHT;

                        //y = writeText(String.Format("Sd file= {0}                  Page {1}", this.fileName, pageNumber),
                        //    pageBitmap, y, MARGIN_LEFT, false);
                    } else {
                        this.currentXoffset = MARGIN_LEFT;
                        this.bitmapList.Add(pageBitmap);
                        pageBitmap = new Bitmap(PAGE_WIDTH, PAGE_HEIGHT);
                        y = MARGIN_TOP;
                        writePageHeader(pageBitmap, y, 1 + pageNumber / 2);
                        y += LINE_HEIGHT;
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
                    y += LINE_HEIGHT / 2;
                    y = writeText(String.Format("{0}", sdLine.text), pageBitmap, y, this.currentXoffset);
                    y += LINE_HEIGHT / 2;
                } else if (sdLine.callNumber > 0) {
                    y += LINE_HEIGHT / 2;
                    y = writeText(String.Format("{0}) {1}", sdLine.callNumber, sdLine.text), pageBitmap, y, this.currentXoffset);
                    y += LINE_HEIGHT / 2;
                }
            }
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

        private int createAndCopyFormationBitmap(ref Bitmap bmp, List<string[]> buffer, int y, int xOffset = 0)
        {
            int height = 0;
            using (Bitmap bmp1 = this.drawFormation(buffer)) {
                Rectangle srcRegion = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                int destx0 = xOffset + 100 - bmp1.Width / 2;
                // Rectangle destRegion = new Rectangle(xOffset + MARGIN_LEFT, y, bmp1.Width, bmp1.Height);
                Rectangle destRegion = new Rectangle(destx0, y, bmp1.Width, bmp1.Height);
                copyRegionIntoImage(bmp1, srcRegion, ref bmp, destRegion);
                height = bmp1.Height;
            }
            buffer.Clear();
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
                this.graphicsForm = new GraphicsForm(ref pictureBox1);
                this.graphicsForm.FormClosing += fManage_FormOneClosing;
                this.graphicsForm.Show();
                //PictureBox pictureBox1 = this.graphicsForm.getPictureBox();
            }
            PANEL_SCALE = (double)numericUpDownScale.Value;
            pictureBox1.Height = (int)(PANEL_SCALE * PAGE_HEIGHT);
            pictureBox1.Width = (int)(PANEL_SCALE * PAGE_WIDTH);
            this.graphicsForm.Height = (int)(PANEL_SCALE * PAGE_HEIGHT) + 60;
            this.graphicsForm.Width = (int)(PANEL_SCALE * PAGE_WIDTH) + 35;
            DIAMOND_REDUCTION = (int)numericUpDownDiamondReduction.Value;
            DIAMOND_WIDTH = (int)numericUpDownDiamondWidth.Value;
            this.bitmapList.Clear();
            string[] lines = { };
            if (File.Exists(fileName)) {
                lines = File.ReadAllLines(fileName);
            } else {
                MessageBox.Show(String.Format("File {0} does not exist", fileName));
                this.Close();
            }

            this.sdId = this.createSdLines(lines);

            Bitmap pageBitmap = new Bitmap(PAGE_WIDTH, PAGE_HEIGHT);
            List<String[]> buffer = new List<string[]>();
            int y = MARGIN_TOP;

            Boolean skipNext = false;
            int pageNumber = 1;
            this.currentXoffset = MARGIN_LEFT;
            writePageHeader(pageBitmap, y, 1);
            y += LINE_HEIGHT;
            int callNumber = 0;
            String lastCall = "";
            for (int i = 0; i < sdLines.Count; i++) {
                if (skipNext) {
                    skipNext = false;
                    continue;
                }
                SdLine sdLine = sdLines[i];
                if (sdLine.noOfDancers == 0) {
                    if (lastCall != AT_HOME) {
                        checkBufferAndWriteCall(ref pageBitmap, buffer, ref y, ref callNumber, ref skipNext, i, sdLine, ref pageNumber);
                    }
                    lastCall = sdLine.text;
                } else if (lastCall != TWO_COUPLES_ONLY) {
                    buffer.Add(sdLine.atoms);
                }
            }
            this.writeText("Copyright \u00a9 Bronc Wise 2012", pageBitmap, PAGE_HEIGHT - LINE_HEIGHT, PAGE_WIDTH / 2 - 100);

            this.bitmapList.Add(pageBitmap);  // The last bitmap (Could be a duplicate?)
            this.viewBitmap(0);
        }

        private void drawBorder(Bitmap bmp, Brush brush)
        {
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawLine(new Pen(brush, 2), new Point(0, 0), new Point(0, bmp.Height));
                g.DrawLine(new Pen(brush, 2), new Point(0, 0), new Point(bmp.Width, 0));
                g.DrawLine(new Pen(brush, 2), new Point(0, bmp.Height), new Point(bmp.Width, bmp.Height));
                g.DrawLine(new Pen(brush, 2), new Point(bmp.Width, 0), new Point(bmp.Width, bmp.Height));
            }
        }

        private Bitmap drawFormation(List<String[]> buffer)
        {
            int y = 10 + DANCER_SIZE / 2;
            int maxNumberOfPositions = 0;
            foreach (String[] dancers in buffer) {
                if (dancers.Length > maxNumberOfPositions) {
                    maxNumberOfPositions = dancers.Length;
                }
            }
            int bitMapWidth = maxNumberOfPositions * DANCER_SIZE + (maxNumberOfPositions - 1) * (HORIZONTAL_SPACE - DANCER_SIZE) + (maxNumberOfPositions + 1) * NOSE_SIZE;
            int xc = bitMapWidth / 2;
            Bitmap bmp1 = new Bitmap(bitMapWidth, buffer.Count * LINE_HEIGHT + NOSE_SIZE);
            Dictionary<int, int[]> centers = new Dictionary<int, int[]>();
            int halfSpace = HORIZONTAL_SPACE / 2;

            centers.Add(1, new int[] { xc });
            centers.Add(2, new int[] { xc - halfSpace, xc + halfSpace });
            centers.Add(3, new int[] { xc - HORIZONTAL_SPACE, xc, xc + HORIZONTAL_SPACE });
            centers.Add(4, new int[] { xc - 3 * halfSpace, xc - halfSpace, xc + halfSpace, xc + 3 * halfSpace });
            centers.Add(5, new int[] { xc - 2 * HORIZONTAL_SPACE, xc - HORIZONTAL_SPACE, xc, xc + HORIZONTAL_SPACE, xc + 2 * HORIZONTAL_SPACE });
            centers.Add(6, new int[] { xc - 5 * halfSpace, xc - 3 * halfSpace, xc - halfSpace, xc + halfSpace, xc + 3 * halfSpace,
                                        xc + 3 * halfSpace });
            centers.Add(7, new int[] { xc - 3 * HORIZONTAL_SPACE, xc - 2 * HORIZONTAL_SPACE, xc - HORIZONTAL_SPACE, xc,
                                        xc + HORIZONTAL_SPACE, xc + 2 * HORIZONTAL_SPACE, xc + 3 * HORIZONTAL_SPACE });
            centers.Add(8, new int[] { xc - 7 * halfSpace, xc - 5 * halfSpace, xc - 3 * halfSpace, xc - halfSpace, xc + halfSpace,
                xc + 3 * halfSpace, xc + 3 * halfSpace, xc + 5 * halfSpace });
            int numberOfLinesInFormation = buffer.Count;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++) {
                //            foreach (String[] dancers in buffer) {
                String[] positions = buffer[lineNumberInFormation];

                for (int i = 0; i < positions.Length; i++) {
                    drawTheDancerOrSpace(ref bmp1, centers[positions.Length][i], y, positions[i]);
                }
                if (lineNumberInFormation < numberOfLinesInFormation - 1) {
                    int numberOfDancersInThisLine = this.getNumberOfDancers(positions);
                    int numberOfDancersInNextLine = this.getNumberOfDancers(buffer[lineNumberInFormation + 1]);
                    if ((IsOdd(numberOfDancersInThisLine) && !IsOdd(numberOfDancersInNextLine)) ||
                        (!IsOdd(numberOfDancersInThisLine) && IsOdd(numberOfDancersInNextLine))) {
                        y -= DIAMOND_REDUCTION;
                    }
                }
                y += LINE_HEIGHT_FORMATION;
            }
            //bmp1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (DRAW_BORDER) {
                drawBorder(bmp1, Brushes.Red);
            }
            return bmp1;
        }

        private void drawTheDancerOrSpace(ref Bitmap bmp, int xc, int yc, String dancer)
        {
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int x = xc - DANCER_SIZE / 2;
            int y = yc - DANCER_SIZE / 2;
            using (Graphics g = Graphics.FromImage(bmp)) {
                if (dancer == ".") {
                    g.FillEllipse(brushForDancers, xc - 2, yc - 2, 4, 4);
                } else if (dancer == SPACE_CHAR) {
                    String extraSpace = " ".PadLeft(DIAMOND_WIDTH);  // Does not work
                    g.DrawString(extraSpace, fontForCalls, brushForDancers, x, y);

                } else {
                    if (dancer[1] == 'B') {
                        g.DrawRectangle(pen, x, y, DANCER_SIZE, DANCER_SIZE);
                    } else {
                        g.DrawEllipse(pen, x, y, DANCER_SIZE, DANCER_SIZE);
                    }
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    g.DrawString(dancer[0].ToString(), fontForCalls, brushForDancers, x + 2, y + 2);

                    if (dancer[2] == '>') {
                        g.FillEllipse(brushForNoses, x + DANCER_SIZE, y + DANCER_SIZE / 2 - NOSE_SIZE / 2, NOSE_SIZE, NOSE_SIZE);
                    } else if (dancer[2] == '<') {
                        g.FillEllipse(brushForNoses, x - NOSE_SIZE, y + DANCER_SIZE / 2 - NOSE_SIZE / 2, NOSE_SIZE, NOSE_SIZE);
                    } else if (dancer[2] == '^') {
                        g.FillEllipse(brushForNoses, x + DANCER_SIZE / 2 - NOSE_SIZE / 2, y - NOSE_SIZE, NOSE_SIZE, NOSE_SIZE);
                    } else if (dancer[2] == 'V') {
                        g.FillEllipse(brushForNoses, x + DANCER_SIZE / 2 - NOSE_SIZE / 2, y + DANCER_SIZE, NOSE_SIZE, NOSE_SIZE);
                    }
                }
                //g.DrawString(String.Format("Line {0}", accCounter + 1), fy, br, leftMargin, y);
            }
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

        private Dictionary<int, string> findDancersOld(String[] atoms)
        {
            Dictionary<int, string> dancers = new Dictionary<int, string>();

            for (int i = 0; i < atoms.Length; i++) {
                Boolean add = false;
                char firstChar = atoms[i][0];
                if (atoms[i] == ".") {
                    add = true;
                } else if (Char.IsDigit(firstChar) && atoms[i].Length == 3) {
                    if (atoms[i][1] == 'B' || atoms[i][1] == 'G') {
                        add = true;
                    }
                }
                if (add) {
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
            this.copyright = textBoxCopyright.Text;
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

        private void printImage()
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

        private int writePageHeader(Bitmap pageBitmap, int y, int pageNumber)
        {
            return writeText(String.Format("Sd file={0}     Date={1}          Page {2}",
                Path.GetFileName(fileName), this.sdId, pageNumber), pageBitmap, y, 0, false);
        }

        private int writeText(string line, Bitmap bmp, int y, int xOffset, Boolean lineBreak = true)
        {
            int x = xOffset;
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                if (line.Length > LINE_LENGTH && lineBreak) {
                    String line1 = line.Substring(0, LINE_LENGTH);
                    String line2 = line.Substring(LINE_LENGTH, line.Length - LINE_LENGTH);
                    g.DrawString(line1, this.fontForCalls, brushForCalls, x, y);
                    y += LINE_HEIGHT;
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
            return numberOfLeadingSpaces;

        }
        #endregion  ------------------------------------- Methods

        #region ----------------------------------------  Event Handlers

        public void fManage_FormOneClosing(object sender, FormClosingEventArgs e)
        {
            this.graphicsForm = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (this.currentIndex > 0) {
                this.viewBitmap(this.currentIndex - 1);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (this.currentIndex < this.bitmapList.Count) {
                this.viewBitmap(this.currentIndex + 1);
            }
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
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxCopyright_TextChanged(object sender, EventArgs e)
        {
            this.copyright = textBoxCopyright.Text;
        }

        #endregion ------------------------------------- Event Handlers

    }
}
