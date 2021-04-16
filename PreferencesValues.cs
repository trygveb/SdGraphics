using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdGraphics
{
    public class PreferencesValues
    {
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
        private FocusDancerStruct focusDancer = new FocusDancerStruct(3, DancerId.Beau);
        private ViewEnum sdView = ViewEnum.Caller;
        private bool createZipFile = true;
        private bool drawBorder = false;
        private bool showPartner = false;

        public bool CreateZipFile {
            get { return createZipFile; }
            set { createZipFile= value; }
        }

        public bool DrawBorder {
            get { return drawBorder; }
            set { drawBorder = value; }
        }
        public bool ShowPartner {
            get { return showPartner; }
            set { showPartner = value; }
        }
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

        public FocusDancerStruct FocusDancer {
            get { return focusDancer; }
            set { focusDancer = value; }
        }

        public ViewEnum SdView {
            get { return sdView; }
            set { sdView = value; }
        }
        #endregion -------------------------------------------------- Properties
        public PreferencesValues()
        {

        }
    }
}
