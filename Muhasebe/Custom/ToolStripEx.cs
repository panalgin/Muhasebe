using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Muhasebe.Custom
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ToolStrip))]
    public class ToolStripEx : ToolStrip
    {
        public ToolStripEx()
        {
            this.Renderer = new ToolStripExProfessionalRenderer();
        }
    }

    public class ToolStripExSystemRenderer : ToolStripSystemRenderer
    {
        public ToolStripExSystemRenderer() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }
    }

    class ToolStripExProfessionalRenderer : ToolStripProfessionalRenderer
    {
        public ToolStripExProfessionalRenderer()
            : base(new ExProfessionalColorTable())
        {

        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Don't draw a border
        }
    }

    class ExProfessionalColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin
        {
            get { return SystemColors.Control; }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return SystemColors.Control; }
        }

        public override Color ToolStripGradientEnd
        {
            get { return SystemColors.Control; }
        }
    }
}
