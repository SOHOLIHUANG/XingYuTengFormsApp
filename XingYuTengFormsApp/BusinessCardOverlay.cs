using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingYuTengFormsApp
{
    class BusinessCardOverlay : AbstractOverlay
    {
        public BusinessCardOverlay()
        {
            this.businessCardRenderer.HeaderBackBrush = Brushes.DarkBlue;
            this.businessCardRenderer.BorderPen = new Pen(Color.DarkBlue, 2);
            this.Transparency = 225;
        }
        #region IOverlay Members

        public override void Draw(ObjectListView olv, Graphics g, Rectangle r)
        {
            if (olv.HotRowIndex < 0)
                return;

            if (olv.View == View.Tile)
                return;

            OLVListItem item = olv.GetItem(olv.HotRowIndex);
            if (item == null)
                return;

            Size cardSize = new Size(250, 120);
            Rectangle cardBounds = new Rectangle(
                r.Right - cardSize.Width - 8, r.Bottom - cardSize.Height - 8, cardSize.Width, cardSize.Height);
            this.businessCardRenderer.DrawBusinessCard(g, cardBounds, item.RowObject, olv, item);
        }

        #endregion

        private readonly BusinessCardRenderer businessCardRenderer = new BusinessCardRenderer();
    }
}
