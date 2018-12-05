using System;
using System.Drawing;
using MindFusion.Diagramming;
using MindFusion.Drawing;
using MindFusion.Svg;

namespace ScoreWriter
{
    public class StaffNode : DiagramNode
    {
        public StaffNode()
        {
            var rect = Bounds;
            rect.Width = 200;
            SetBounds(rect, false, false);

            // disable vertical resize
            EnabledHandles =
                AdjustmentHandles.ResizeMiddleLeft |
                AdjustmentHandles.Move |
                AdjustmentHandles.ResizeMiddleRight;
        }

        public StaffNode(StaffNode prototype) : base(prototype)
        {
        }

        public override void DrawLocal(IGraphics graphics, RenderOptions options)
        {
            base.DrawLocal(graphics, options);

            for (int i = 0; i < 5; i++)
            {
                float y = i * Bounds.Height / 4;
                using (var pen = EffectivePen.CreateGdiPen())
                    graphics.DrawLine(pen, 0, y, Bounds.Width, y);
            }

            var rect = GetLocalBounds();
            rect.Inflate(0, 8);
            rect.X = 2;
            rect.Width = 14;
            gClef.Draw(graphics, rect);
        }

        public override void DrawShadowLocal(IGraphics graphics, RenderOptions options)
        {
        }

        public override RectangleF GetRepaintRect(bool includeConnected)
        {
            var rect = base.GetRepaintRect(includeConnected);
            rect.Inflate(0, 8);
            return rect;
        }

        public PointF Align(PointF point, out int position)
        {
            // align to pitch line/space

            float h = Bounds.Height / 8;
            float offset = point.Y - Bounds.Y;
            position = (int)Math.Round(offset / h);
            offset = (float)Math.Round(offset / h) * h;
            point.Y = Bounds.Y + offset;
            return point;
        }

        static SvgContent gClef;

        static StaffNode()
        {
            gClef = new SvgContent();
            gClef.Parse("GClef.svg");
        }
    }
}