
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
/**
* @author Trygve Botnen

* Copyright 2021 Trygve Botnen

* This file is part of SdGraphics.

    SdGraphics is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    SdGraphics is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SdGraphics.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace SdGraphics
{
    /// <summary>
    /// https://app.creately.com/diagram/start/dashboard
    /// </summary>

    public partial class Form1 : Form
    {
        #region ----------------------------------------- Attributes
        #region ----------------------------------------- Simple Attributes

        // Form feed character are found i Sd files when the "End this sequence" command has been used
        public static Char FF = '\f';

        // The formation from this Sd Command is currently ignored
        public static String TWO_COUPLES_ONLY = "Two couples only";
        // currentXoffset should be zero for the left column and typically mus.PageSize.Width/2 for the right column
        public int currentXoffset = 0;
        private static String AT_HOME = "at home";
        private int currentPage = -1;
        private Boolean dancerView = false;
        private String fileName;
        private int formationNumber = 0;
        private int marginLeftFormations = 30;
        private int marginLeftText = 40;
        private int pageIndex = 0;
        private double panelScale = 1;
        private int SPACE_BETWEEN_CALL_AND_FORMATION = 15;
        private String ViewTypeName = "Caller view";
        private String zipFileName;
       

        #endregion ----------------------------------------- Simple Attributes
        #region ----------------------------------------- Other Attributes
        public UserSettings mus;// = new UserSettings();

        public Preferences preferences;

        /// <summary>Each bitmap in this list corresponds to a (A4) page </summary>
        private List<Bitmap> bitmapList = new List<Bitmap>();

        private Font fontForCalls = new Font("Helvetica", 10, FontStyle.Bold);
        private Form graphicsForm;
        private System.Drawing.Imaging.Encoder myEncoder;
        private EncoderParameters myEncoderParameters;
        //private Pen penForBorder = new Pen(Color.Red, 2);
        private Pen penForFocusDancer = new Pen(Color.Red, 2);
        private Pen penForPartner = new Pen(Color.Black, 1);
        private PictureBox pictureBox1 = new PictureBox();
        private Regex regexAtHome = new Regex(@".+\(at home\)");
        private Regex regexDigitsOnly = new Regex(@"^\s*\d+$");
        private Regex regexPromenade = new Regex(@"\(.*promenade\)");
        private Regex regexSdId = new Regex(@".*Sd\d\d\.\d\d:");
        private List<SdLine> sdLines = new List<SdLine>();
        private ZipArchive zipArchive;
        private MemoryStream zipMemoryStream = new MemoryStream();
        #endregion ----------------------------------------- Other Attributes

        #endregion  ------------------------------------- Attributes
        struct SdLine
        {
            /// <summary>Sd dancer symbols in this line,  e.g. 3BV  3G^</summary>
            public String[] atoms;

            /// <summary>
            /// Sequental call number in the tip.
            /// Also used to identify home postions (=0) and warnings (=-1) (bad practice TODO: Fix)
            /// </summary>
            public int callNumber;

            /// <summary>Used to position the line correctly in the bitmap</summary>
            public int emptylinesBefore;

            /// <summary>The number of dancers in thus line</summary>
            public int noOfDancers;

            /// <summary>Used to position the line correctly in the bitmap</summary>
            public List<int> noOfLeadingSpaces;

            /// <summary>The call (or warning)</summary>
            public String text;

            /// <summary>True if the line is a warning</summary>
            public Boolean warning;
        }

        #region  ---------------------------------------- Methods
        public Form1()
        {
            InitializeComponent();
            this.init();
        }

        public void firstPage()
        {
            if (this.currentPage > 0) {
                this.viewBitmap(0);
            }
        }
        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public void lastPage()
        {
            if (this.currentPage > 0) {
                this.viewBitmap(this.bitmapList.Count - 1);
            }
        }

        public void nextPage()
        {
            if (this.currentPage < this.bitmapList.Count) {
                this.viewBitmap(this.currentPage + 1);
            }
        }

        public void previousPage()
        {
            if (this.currentPage > 0) {
                this.viewBitmap(this.currentPage - 1);
            }
        }

        public void printImage()
        {

            PrintDocument printDocument = new PrintDocument();
            int w = printDocument.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            //printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", w, 1169);
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

        /// <summary>
        /// Check if we should begin a new page
        /// </summary>
        /// <param name="curentY"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Boolean breakPage(int curentY, int height)
        {
            Boolean doBreak = (curentY + height + mus.LineHeight * 2 > mus.PageSize.Height - mus.MarginBottom);
            return doBreak;
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j) {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        Size calculateBitMapSize(List<SdLine> sdLineList, int maxWidth)
        {
            int bitmapMargin = 2 * mus.NoseSize;
            // Make reservation for noses and (bitmap)margin
            int bitMapWidth = maxWidth + 2 * mus.NoseSize + bitmapMargin;

            int h = Math.Max(mus.NoseSize * 2 + mus.DancerSize, mus.NoseSize * 2 + mus.LineHeight);
            int numberOfLinesInFormation = sdLineList.Count;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++) {
                if (lineNumberInFormation > 0) {
                    int emptylinesBefore = Math.Max(1, (sdLineList[lineNumberInFormation].emptylinesBefore));
                    h += mus.LineHeight * emptylinesBefore;
                }
            }

            if (this.dancerView) {
                // Add space for casller
                h += mus.LineHeight;
            }
            Size bitMapSize = new Size(bitMapWidth, h);
            return bitMapSize;
        }

        private List<int> calculateNumberOfLeadingSpaces(String line, ref List<String> atoms, ref String trimmedLine)
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
            if (atoms.Count > 0 && numberOfLeadingSpaces.Count <= atoms.Count) {
                return numberOfLeadingSpaces;
            } else {
                return numberOfLeadingSpaces;
            }

        }

        /// <summary>
        /// This function is called when a SdLine contains a call.
        /// Check if sdLineList has rows describing the end formation from the last call.
        /// If so we create the bitmap for that formation, and copies it to the page bitmap
        /// </summary>
        /// <param name="pageBitmap"></param>
        /// <param name="sdLineList"></param>
        /// <param name="y"></param>
        /// <param name="sdLine"></param>
        /// <param name="pageNumber"></param>
        /// <param name="marginTop"></param>
        /// <param name="maxTextLineLength"></param>
        /// <param name="lineBreak"></param>
        /// <param name="noOfColumns"></param>
        /// <param name="showCaller"></param>
        /// <returns></returns>
        private void checkSdLineListAndWriteCall(ref Bitmap pageBitmap, List<SdLine> sdLineList, ref int y, SdLine sdLine,
                    ref int pageNumber, int marginTop, int maxTextLineLength, Boolean lineBreak, int noOfColumns,
            bool showCaller)
        {
            if (sdLineList.Count > 0) {
                int height1 = calculateBitMapSize(sdLineList, 0).Height;
                int h2 = y + height1;
                y += SPACE_BETWEEN_CALL_AND_FORMATION;
                y += createAndCopyFormationBitmap(ref pageBitmap, preferences.DrawBorder, sdLineList, y, sdLine, this.currentXoffset); ;
            }
            
            int bitmapHeight = calculateBitMapSize(sdLineList, 0).Height;
            sdLineList.Clear();
            if (breakPage(y,bitmapHeight)) {
                if (noOfColumns == 2 && IsOdd(pageNumber)) {

                    this.currentXoffset = mus.PageSize.Width / 2;
                    y = marginTop + mus.LineHeight;

                } else {
                    this.currentXoffset = 0;
                    this.bitmapList.Add(pageBitmap);
                    pageBitmap = new Bitmap(mus.PageSize.Width, mus.PageSize.Height);
                    y = 0;
                    writeCopyright(pageBitmap, mus.LineHeight);
                    int x = pageNumber;
                    if (noOfColumns == 2) {
                        x = pageNumber / 2;
                    }
                    if (mus.PageHeaders) {
                        y += marginTop;
                        writePageHeader(pageBitmap, y, 1 + x, mus.LineHeight);
                        y += mus.LineHeight;
                    }
                }
                pageNumber++;
            }

            if (sdLine.callNumber == 0) {
                y += mus.LineHeight / 2;
                y = writeText(String.Format("{0}", sdLine.text), pageBitmap, y, this.currentXoffset, lineBreak);
                y += mus.LineHeight / 2;
            } else if (sdLine.callNumber > 0) {
                y += mus.LineHeight;
                y = writeText(String.Format("{0}) {1}", sdLine.callNumber, sdLine.text), pageBitmap, y, this.currentXoffset, lineBreak);
                y += mus.LineHeight / 2;
            }

            //}
            //return y;
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

        private int createAndCopyFormationBitmap(ref Bitmap bmp, Boolean drawBorder, List<SdLine> sdLineList, int y, SdLine sdLine, int xOffset = 0)
        {
            int height = 0;

            //int lineHeight = (int)numericUpDownLineHeight.Value;
            using (Bitmap bmp1 = this.drawFormation(sdLineList, drawBorder, preferences.ShowPartner, (int)numericUpDownNoseUp.Value)) {
                Rectangle srcRegion = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                int destx0 = xOffset + mus.PageSize.Width / 4 - bmp1.Width / 2 - marginLeftFormations;
                // Rectangle destRegion = new Rectangle(xOffset + MARGIN_LEFT, y, bmp1.Width, bmp1.Height);
                Rectangle destRegion = new Rectangle(destx0, y, bmp1.Width, bmp1.Height);
                copyRegionIntoImage(bmp1, srcRegion, ref bmp, destRegion);
                height = bmp1.Height;

                if (preferences.CreateZipFile) {
                    String pictureFileName = String.Format("frm_{0:D3}", this.formationNumber);
                    this.formationNumber++;
                    //MemoryStream stream = new MemoryStream();
                    ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                    myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    String tempFileName = String.Format(@"{0}{1}.jpg",
                        Path.GetTempPath(), pictureFileName);

                    bmp1.Save(tempFileName, myImageCodecInfo, myEncoderParameters);
                    CompactExifLib.ExifData exifData = new CompactExifLib.ExifData(tempFileName);
                    exifData.SetTagValue(CompactExifLib.ExifTag.UserComment, sdLine.text, CompactExifLib.StrCoding.Utf8);
                    exifData.SetTagValue(CompactExifLib.ExifTag.Copyright,
                            String.Format("{0} {1}", mus.CopyrightName, mus.CopyrightYear), CompactExifLib.StrCoding.Utf8);
                    exifData.Save();

                    using (var zipArchive = ZipFile.Open(this.zipFileName, ZipArchiveMode.Update)) {
                        var fileInfo = new FileInfo(tempFileName);
                        zipArchive.CreateEntryFromFile(fileInfo.FullName, fileInfo.Name);
                    }
                    File.Delete(tempFileName);
                }
            }
            return height;
        }

        private void createNewForm()
        {
            this.graphicsForm = new GraphicsForm(ref pictureBox1, this);
            this.graphicsForm.FormClosing += fManage_FormOneClosing;
            this.graphicsForm.Show();
        }

        private void createSdLines(string[] lines)
        {
            this.sdLines.Clear();
            List<SdLine> sdLinesTmp = new List<SdLine>();
            int numberOfEmptyLines = 0;
            for (int i1 = 0; i1 < lines.Length; i1++) {
                //Fill the temporary SdLine list with SdLine objects
                createTempSdLine(lines[i1], sdLinesTmp, ref numberOfEmptyLines, i1);
            }
            int callNumber = 0;
            for (int i2 = 0; i2 < sdLinesTmp.Count; i2++) {
                modifyAndCopySdLine(sdLinesTmp, ref callNumber, i2);
            }
        }
        /// <summary>
        /// Parses a line in the Sd output file
        /// Skips unnecessary lines
        /// Fills the temporary SdLine list with SdLine objects
        /// These object ar modified in a later loop
        /// </summary>
        /// <param name="line"></param>
        /// <param name="sdLinesTmp"></param>
        /// <param name="numberOfEmptyLines">See SdLine struct</param>
        /// <param name="i1"></param>
        /// <returns></returns>
        private void createTempSdLine(string line, List<SdLine> sdLinesTmp, ref int numberOfEmptyLines, int i1)
        {

            Boolean emptyLine = false;
            //String line0 = lines[i1];
            Boolean warning = false;
            //CHeck if the line should be skipped
            if (this.skip(ref line, ref warning, ref emptyLine)) {
                if (emptyLine) numberOfEmptyLines++;
                return;
            }
            String line1 = cleanUp(line);
            List<String> atoms = new List<String>();
            String trimmedLine = "";
            List<int> numberOfLeadingSpaces = calculateNumberOfLeadingSpaces(line1, ref atoms, ref trimmedLine);
            Dictionary<int, string> dancers = findDancers(trimmedLine);
            SdLine sdLine = new SdLine();
            sdLine.noOfDancers = dancers.Count;
            sdLine.text = trimmedLine;
            // sdLine.dancers = dancers;
            sdLine.atoms = atoms.ToArray();
            sdLine.warning = warning;
            sdLine.emptylinesBefore = numberOfEmptyLines;
            sdLine.noOfLeadingSpaces = numberOfLeadingSpaces;
            //this.sdLines.Add(sdLine);
            sdLinesTmp.Add(sdLine);
            numberOfEmptyLines = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void createTip()
        {
            this.formationNumber = 0;
            if (this.graphicsForm == null) {
                createNewForm();
            }
            formatGraphicsForm();
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

            this.createSdLines(lines);
            int lineHeight = mus.LineHeight;
            Bitmap pageBitmap = new Bitmap(mus.PageSize.Width, mus.PageSize.Height);
            List<SdLine> sdLineList = new List<SdLine>();
            int y = mus.MarginTop;

            int pageNumber = 1;
            this.currentXoffset = 0;// will be increased in 2:nd column
            this.writePageHeader(pageBitmap, y, 1, lineHeight);
            this.writeCopyright(pageBitmap, lineHeight);
            y += lineHeight;
            //int callNumber = 0;
            String lastCall = "";
            for (int sdLineNo = 0; sdLineNo < sdLines.Count; sdLineNo++) {
                WriteCallOrAddLineToList(sdLines[sdLineNo], ref pageBitmap, sdLineList, ref y, ref pageNumber, ref lastCall, sdLineNo);
            }
            // this.writeText("Copyright \u00a9 Bronc Wise 2012", lineHeight, pageBitmap, mus.PageSize.Height - lineHeight, mus.PageSize.Width / 2 - 100);

            this.bitmapList.Add(pageBitmap);  // The last bitmap (Could be a duplicate?)
            this.viewBitmap(0);

        }
        private void drawBorder(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.DrawRectangle(mus.penForBorder, 0, 0, bmp.Width, bmp.Height);
            }
        }

        private void drawCaller(ref Bitmap bmp)
        {
            Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int xc = bmp.Width / 2;
            int y = bmp.Height - mus.DancerSize - 2;
            int x = Math.Max(0, xc - mus.DancerSize / 2);
            using (Graphics g = Graphics.FromImage(bmp)) {

                g.DrawEllipse(mus.penForCaller, x + 2, y + 2, (float)0.8 * mus.DancerSize, (float)0.8 * mus.DancerSize);
                g.DrawRectangle(mus.penForCaller, x, y, mus.DancerSize, mus.DancerSize);
                g.FillEllipse(mus.BrushForCallerNose, x + mus.DancerSize / 2 - mus.NoseSize / 2, y - mus.NoseSize, mus.NoseSize, mus.NoseSize);
            }

        }

        private int drawDancerOrSpace(ref Bitmap bmp, int xc, int yc, String dancer, bool showPartner, ref RotateFlipType rft)
        {
            // Pen pen = new Pen(System.Drawing.Color.Black, 1);
            int x = Math.Max(0, xc - mus.DancerSize / 2);
            int y = yc - mus.DancerSize / 2;
            using (Graphics g = Graphics.FromImage(bmp)) {
                bool isFocusDancer = false;

                if (dancer == ".") {
                    // the point is only 1 char, so we have to add an extra spcace before
                    g.DrawEllipse(mus.penForPhantom, x - mus.BlankSpace, yc - mus.DancerSize / 2, mus.DancerSize, mus.DancerSize);
                    xc -= 2 * mus.BlankSpace;  // Subtle
                } else {
                    if (dancer[1] == 'B') {
                        g.DrawRectangle(mus.penForDancer, x, y, mus.DancerSize, mus.DancerSize);
                    } else {
                        g.DrawEllipse(mus.penForDancer, x, y, mus.DancerSize, mus.DancerSize);
                    }
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    if (this.dancerView) {
                        if (dancer[0] == numericUpDownNoseUp.Value.ToString()[0]) {
                            int symbolSize = mus.DancerSize / 3;
                            if (radioButtonBeau.Checked && dancer[1] == 'B') {
                                isFocusDancer = true;
                                g.DrawRectangle(penForFocusDancer, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            } else if (radioButtonBelle.Checked && dancer[1] == 'G') {
                                isFocusDancer = true;
                                g.DrawEllipse(penForFocusDancer, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            } else if (radioButtonBeau.Checked && dancer[1] == 'G' && showPartner) {
                                g.DrawEllipse(penForPartner, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            } else if (radioButtonBelle.Checked && dancer[1] == 'B' && showPartner) {
                                g.DrawRectangle(penForPartner, x + mus.DancerSize / 2 - symbolSize / 2, y + mus.DancerSize / 2 - symbolSize / 2, symbolSize, symbolSize);
                            }
                        }
                    } else {
                        g.DrawString(dancer[0].ToString(), fontForCalls, mus.BrushForDancerText, x + 2, y + 2);
                    }


                    if (dancer[2] == '>') {
                        if (isFocusDancer) {
                            rft = RotateFlipType.Rotate270FlipNone;
                        }
                        g.FillEllipse(mus.BrushForDancerNoses, x + mus.DancerSize, y + mus.DancerSize / 2 - mus.NoseSize / 2, mus.NoseSize, mus.NoseSize);
                    } else if (dancer[2] == '<') {
                        if (isFocusDancer) {
                            rft = RotateFlipType.Rotate90FlipNone;
                        }
                        g.FillEllipse(mus.BrushForDancerNoses, x - mus.NoseSize, y + mus.DancerSize / 2 - mus.NoseSize / 2, mus.NoseSize, mus.NoseSize);
                    } else if (dancer[2] == '^') {
                        g.FillEllipse(mus.BrushForDancerNoses, x + mus.DancerSize / 2 - mus.NoseSize / 2, y - mus.NoseSize, mus.NoseSize, mus.NoseSize);
                    } else if (dancer[2] == 'V') {
                        if (isFocusDancer) {
                            rft = RotateFlipType.Rotate180FlipNone;
                        }
                        g.FillEllipse(mus.BrushForDancerNoses, x + mus.DancerSize / 2 - mus.NoseSize / 2, y + mus.DancerSize, mus.NoseSize, mus.NoseSize);
                    }
                }
            }

            return xc + mus.DancerSize;
        }

        private Bitmap drawFormation(List<SdLine> sdLineList, Boolean drawBorder, bool showPartner, int noseUpDancer)
        {
            int y = 2 * mus.NoseSize + mus.DancerSize / 2;
            int maxNumberOfPositions = 0;
            //foreach (String[] dancers in buffer) {
            //    if (dancers.Length > maxNumberOfPositions) {
            //        maxNumberOfPositions = dancers.Length;
            //    }
            //}

            //int maxNumberOfPositions1 = 0;
            //int numberOfSpaces = 0;
            int maxWidth = 0;  // pixels
            foreach (SdLine sdLine in sdLineList) {
                if (sdLine.noOfDancers > maxNumberOfPositions) {
                    maxNumberOfPositions = sdLine.noOfDancers;
                }
                int width = sdLine.noOfDancers * mus.DancerSize; //pixels
                foreach (int n in sdLine.noOfLeadingSpaces) {
                    width += n * mus.BlankSpace;
                }
                if (width > maxWidth) {
                    maxWidth = width;
                }
            }


            Size bitMapSize = calculateBitMapSize(sdLineList, maxWidth);

            Bitmap bmp1 = new Bitmap(bitMapSize.Width, bitMapSize.Height);

            using (Graphics g = Graphics.FromImage(bmp1)) {
                SolidBrush whiteBrush = new SolidBrush(Color.White);

                // Create rectangle.
                Rectangle rect = new Rectangle(0, 0, bitMapSize.Width, bitMapSize.Height);

                // Fill rectangle to screen.
                g.FillRectangle(whiteBrush, rect);
            }

            int numberOfLinesInFormation = sdLineList.Count;
            RotateFlipType rft = RotateFlipType.RotateNoneFlipNone;
            for (int lineNumberInFormation = 0; lineNumberInFormation < numberOfLinesInFormation; lineNumberInFormation++) {
                //            foreach (String[] dancers in buffer) {
                String[] positions = sdLineList[lineNumberInFormation].atoms;
                List<int> noOfLeadingSpaces = sdLineList[lineNumberInFormation].noOfLeadingSpaces;
                int xCenter = mus.DancerSize / 2 + mus.NoseSize;
                if (lineNumberInFormation > 0) {

                    int emptylinesBefore = Math.Max(1, (sdLineList[lineNumberInFormation].emptylinesBefore));
                    y += mus.LineHeight * emptylinesBefore;


                }

                for (int i = 0; i < positions.Length; i++) {
                    xCenter = drawDancerOrSpace(ref bmp1, xCenter + noOfLeadingSpaces[i] * mus.BlankSpace, y, positions[i],
                        showPartner, ref rft);
                }
                if (this.dancerView) {
                    this.drawCaller(ref bmp1);
                }

            }
            if (drawBorder) {
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
            for (int i = 0; i < atoms.Length; i++) {

                Match match = regex.Match(atoms[i]);

                if (match.Success || atoms[i] == ".") {
                    dancers.Add(i, atoms[i]);
                }
            }
            return dancers;
        }

        private void formatGraphicsForm()
        {
            this.panelScale = (double)numericUpDownScale.Value;
            pictureBox1.Height = (int)(panelScale * mus.PageSize.Height);
            pictureBox1.Width = (int)(panelScale * mus.PageSize.Width);
            int heightOfTitleBar = 40;
            this.graphicsForm.Height = (int)(panelScale * mus.PageSize.Height) + pictureBox1.Location.Y + heightOfTitleBar;
            this.graphicsForm.Width = (int)(panelScale * mus.PageSize.Width) + 35;
        }

        private void init()
        {
            this.mus = new UserSettings();
            this.mus.Reload();
            preferences = new Preferences();
            preferences.Reload();
            radioButtonCallerView.Checked = preferences.SdView == PreferencesValues.ViewEnum.Caller;
            radioButtonDancerView.Checked = preferences.SdView == PreferencesValues.ViewEnum.Dancer;
            numericUpDownNoseUp.Value = preferences.FocusDancer.CoupleNumber;
            radioButtonBelle.Checked = preferences.FocusDancer.DancerId == PreferencesValues.DancerId.Belle;
            radioButtonBeau.Checked = preferences.FocusDancer.DancerId == PreferencesValues.DancerId.Beau;
            checkBoxCreateHTML.Checked = preferences.CreateZipFile;
            checkBoxBorder.Checked = preferences.DrawBorder;
            checkBoxShowPartner.Checked = preferences.ShowPartner;
        }

        private void modifyAndCopySdLine(List<SdLine> sdLinesTmp, ref int callNumber, int i2)
        {
            Boolean addSequenceEnd = false;
            SdLine sdLine = sdLinesTmp[i2];

            if (sdLine.warning) {
                sdLine.callNumber = -1;  //TODO Remove this bad practice
            } else if (sdLine.text == AT_HOME) {
                sdLine.text = "------------ " + sdLine.text + " -------------";
                sdLine.callNumber = 0; //TODO Remove this bad practice also
            } else if (this.regexPromenade.Match(sdLine.text).Success || this.regexAtHome.Match(sdLine.text).Success) {
                addSequenceEnd = true;

            } else if (sdLine.text == TWO_COUPLES_ONLY) {
                // TODO create a test valid for both 2-couples and 4-couples
                sdLine.callNumber = -1;
            } else if (sdLine.text.Length < 1) {
                // This test should not be necessary, but it is!
                sdLine.callNumber = -1;
            } else if (sdLine.noOfDancers == 0) {
                if (i2 > 0 && sdLinesTmp[i2 - 1].noOfDancers == 0) {
                    callNumber++;
                    sdLine.callNumber = callNumber;
                } else if (i2 < sdLinesTmp.Count - 1 && sdLinesTmp[i2 + 1].noOfDancers == 0) {
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
                //sequenceEnd.dancers = new Dictionary<int, string>();
                sequenceEnd.atoms = null;
                sequenceEnd.warning = false;
                this.sdLines.Add(sequenceEnd);
            }
        }

        /// <summary>
        /// if sdLine contains zero dancers, call checkSdLineListAndWriteCall, else add the line to sdLineList
        /// </summary>
        /// <param name="sdLine">A sdLine stucture, created from th Sd file</param>
        /// <param name="pageBitmap">Bitmap of current page</param>
        /// <param name="sdLineList"></param>
        /// <param name="y"></param>
        /// <param name="pageNumber"></param>
        /// <param name="lastCall"></param>
        /// <param name="sdLineNo"></param>
        private void WriteCallOrAddLineToList(SdLine sdLine, ref Bitmap pageBitmap, List<SdLine> sdLineList, ref int y, ref int pageNumber, ref string lastCall, int sdLineNo)
        {
            //SdLine sdLine = sdLines[sdLineNo];
            if (sdLine.noOfDancers == 0) {
                checkSdLineListAndWriteCall(ref pageBitmap, sdLineList, ref y, sdLine,
                     ref pageNumber,
                     mus.MarginTop, mus.MaxLineLength, mus.BreakLines,
                     (int)numericUpDownColumns.Value, preferences.ShowPartner);
                lastCall = sdLine.text;
            } else {
                sdLineList.Add(sdLine);
            }
        }
        private void openSdFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    this.fileName = openFileDialog.FileName;
                    textBoxFile.Text = this.fileName;
                    buttonReadFile.Enabled = true;
                    printToolStripMenuItem.Enabled = true;

                    this.zipArchive = new ZipArchive(zipMemoryStream, ZipArchiveMode.Create, true);
                    this.zipFileName = Path.ChangeExtension(this.fileName, "zip");

                    using (var fileStream = new FileStream(this.zipFileName, FileMode.Create)) {
                        this.zipMemoryStream.Seek(0, SeekOrigin.Begin);
                        this.zipMemoryStream.CopyTo(fileStream);
                    }
                    zipMemoryStream.Close();
                    numericUpDownScale.Enabled = true;
                }
            }
        }
        private void setFocusDancer()
        {
            int coupleNumber = (int)numericUpDownNoseUp.Value;
            if (radioButtonBelle.Checked) {
                preferences.FocusDancer = new PreferencesValues.FocusDancerStruct(
                   coupleNumber, PreferencesValues.DancerId.Belle);
            } else {
                preferences.FocusDancer = new PreferencesValues.FocusDancerStruct(
                   coupleNumber, PreferencesValues.DancerId.Beau);
            }

        }

        private void setViewTypeName()
        {
            if (radioButtonDancerView.Checked) {
                if (radioButtonBeau.Checked) {
                    this.ViewTypeName = String.Format("Dancer View Couple nr {0}, Beau", numericUpDownNoseUp.Value);
                } else {
                    this.ViewTypeName = String.Format("Dancer View Couple nr {0}, Belle", numericUpDownNoseUp.Value);
                }
            } else {
                this.ViewTypeName = String.Format("Caller View");
            }
        }

        /// <summary>
        /// Check if a line should be skipped. The line is skipped in the following cases:
        ///   * The line contains the Sd id 
        ///   * The line contains digits only
        ///   * The line contains the FF char only
        ///   * The line contains less than 2 characters (this sets the emptyLine flag)
        ///   Also checks if the line contains a Sd warning message 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="warning"></param>
        /// <param name="emptyLine">Used in order to count the numerb of empty lines</param>
        /// <returns></returns>
        private Boolean skip(ref String line, ref Boolean warning, ref Boolean emptyLine)
        {
            Boolean skip = false;
            warning = false;


            if (this.regexDigitsOnly.Match(line).Success) {
                skip = true;
            } else if (this.regexSdId.Match(line).Success) {
                skip = true;
            } else if (line.Length == 1) {
                if (line[0] == FF) {
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


        private void viewBitmap(int page = 0)
        {
            if (this.bitmapList.Count > page) {
                Bitmap original = this.bitmapList[page];
                Bitmap scaled = new Bitmap(original, new Size((int)(panelScale * (double)original.Width), (int)(panelScale * (double)original.Height)));

                pictureBox1.Image = scaled;
                // pictureBox1.Image = this.bitmapList[index];
                pictureBox1.Refresh();
                this.currentPage = page;
            }
        }

        private void writeCopyright(Bitmap pageBitmap, int lineHeight)
        {
            this.writeText(String.Format("Copyright \u00a9 {0} {1}", mus.CopyrightName, mus.CopyrightYear),
                pageBitmap, mus.PageSize.Height - lineHeight, mus.PageSize.Width / 2 - 150, false);
        }

        private int writePageHeader(Bitmap pageBitmap, int y, int pageNumber, int lineHeight)
        {
            return writeText(String.Format("Sd file={0}     View={1}          Page {2}",
                Path.GetFileName(fileName), this.ViewTypeName, pageNumber),
                pageBitmap, y, 0, false);
        }

        private int writeText(string line, Bitmap bmp, int y, int xOffset, Boolean lineBreak)
        {
            int x = xOffset + marginLeftText;
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                int breakIndex = line.LastIndexOf(' ', Math.Min(line.Length - 1, mus.MaxLineLength));

                if (breakIndex > 0 && line.Length > mus.MaxLineLength && lineBreak) {
                    String line1 = line.Substring(0, breakIndex);
                    String line2 = "  " + line.Substring(breakIndex, line.Length - breakIndex);
                    g.DrawString(line1, this.fontForCalls, mus.BrushForCallText, x, y);
                    y += mus.LineHeight;
                    g.DrawString(line2, this.fontForCalls, mus.BrushForCallText, x, y);
                } else {
                    g.DrawString(line, this.fontForCalls, mus.BrushForCallText, x, y);
                }
            }
            return y;
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

        //private void buttonForward_Click(object sender, EventArgs e)
        //{
        //    this.nextPage();
        //}


        //private void buttonForward_Click_1(object sender, EventArgs e)
        //{
        //    this.nextPage();
        //}

        //private void buttonOpenFile_Click(object sender, EventArgs e)
        //{
        //    this.openSdFile();
        //    this.createTip();
        //}


        //private void buttonPrint_Click(object sender, EventArgs e)
        //{
        //    this.printImage();
        //}

        private void buttonReadFile_Click(object sender, EventArgs e)
        {
            this.createTip();
        }

        private void checkBoxBorder_CheckedChanged(object sender, EventArgs e)
        {
            preferences.DrawBorder = checkBoxBorder.Checked;
        }

        private void checkBoxCreateHTML_CheckedChanged(object sender, EventArgs e)
        {
            preferences.CreateZipFile = checkBoxCreateHTML.Checked;
        }

        private void checkBoxShowPartner_CheckedChanged(object sender, EventArgs e)
        {
            preferences.ShowPartner = checkBoxShowPartner.Checked;
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            preferences.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownNoseUp_ValueChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();
            this.setFocusDancer();
        }

        private void numericUpDownScale_ValueChanged(object sender, EventArgs e)
        {
            this.createTip();
        }
        private void openSdFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openSdFile();
            this.createTip();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printImage();
        }

        private void radioButtonBeau_CheckedChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();

        }

        private void radioButtonBelle_CheckedChanged(object sender, EventArgs e)
        {
            this.setFocusDancer();
        }

        private void radioButtonDancerView_CheckedChanged(object sender, EventArgs e)
        {
            this.setViewTypeName();
            if (radioButtonDancerView.Checked) {
                groupBoxFocusDancer.Enabled = true;
                this.dancerView = true;
                preferences.SdView = PreferencesValues.ViewEnum.Dancer;
            } else {
                groupBoxFocusDancer.Enabled = false;
                this.dancerView = false;
                preferences.SdView = PreferencesValues.ViewEnum.Caller;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file:Help\\SdGraphics.chm");
        }

        private void groupBoxFocusDancer_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            Util.DrawGroupBox(box, e.Graphics, Color.Black, Color.Blue);
        }

        private void groupBoxView_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            Util.DrawGroupBox(box, e.Graphics, Color.Black, Color.Blue);
        }

        private void showWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string myFile = Path.Combine(applicationDirectory, @"Web\ZipViewer.html");

            System.Diagnostics.Process.Start(myFile);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        #endregion ------------------------------------- Event Handlers

        private void demoToolStripMenuItem_Click(object sender, EventArgs e)
        {
 

            //
        }
    }

}
