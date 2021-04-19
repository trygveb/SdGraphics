using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdGraphics
{
    public class PreferencesValues
    {
        public PreferencesValues()
        {

        }

        public enum DancerId
        {
            Beau,
            Belle
        }
        public enum ViewEnum
        {
            Caller,
            Dancer
        }

        #region -------------------------------------------------- Private attributes
        private int columns;
        private bool createZipFile = true;
        private bool drawBorder = false;
        private FocusDancerStruct focusDancer = new FocusDancerStruct(3, DancerId.Beau);
        private string initialDirectory = @"C:\Sd";
        private ViewEnum sdView = ViewEnum.Caller;
        private bool showPartner = false;
        private decimal zoom;
        #endregion ----------------------------------------------- Private attributes

        #region -------------------------------------------------- Structs
        public struct FocusDancerStruct
        {
            public int CoupleNumber;
            public DancerId DancerId;
            public FocusDancerStruct(int coupleNumber, DancerId dancerId)
            {
                CoupleNumber = coupleNumber;
                DancerId = dancerId;
            }
        }
        #endregion -------------------------------------------------- Structs

        #region -------------------------------------------------- Properties

        /// <summary>
        /// The number of columns in the PDF document. Two columns is OK for 2-couples sequences,
        /// but might be a problem in 4 couples
        /// </summary>
        public int Columns {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>If and only if this is true, a zip file with formation (jpeg) images is created/// </summary>
        public bool CreateZipFile {
            get { return createZipFile; }
            set { createZipFile = value; }
        }

        /// <summary>If true, a border is drawn around each formation</summary>
        public bool DrawBorder {
            get { return drawBorder; }
            set { drawBorder = value; }
        }

        public FocusDancerStruct FocusDancer {
            get { return focusDancer; }
            set { focusDancer = value; }
        }
        public string InitialDirectory {
            get { return initialDirectory; }
            set { initialDirectory = value; }
        }


        /// <summary>Caller or Dancer</summary>
        /// In Caller view the formation is shown with a fixed caller position (at the top of the formation picture).
        /// The caller is not drawn.
        /// In Dancer view a Focus dancer is selected, and the formation pictures are rotated so the nose of that
        /// dancer is always up.T he caller is drawn.
        /// This view might be handy if you are a single dancer.
        /// 
        public ViewEnum SdView {
            get { return sdView; }
            set { sdView = value; }
        }
        /// <summary>If true, the focus dancer partner is marked. Only applicable In dancer view.</summary>
        public bool ShowPartner {
            get { return showPartner; }
            set { showPartner = value; }
        }

        /// <summary>Increase to display a larger PDF picture.</summary>
        public decimal Zoom {
            get { return zoom; }
            set { zoom = value; }
        }
        #endregion -------------------------------------------------- Properties
    }
}
