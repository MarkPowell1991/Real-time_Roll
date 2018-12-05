using System.Drawing;
using System.Drawing.Drawing2D;
using MindFusion.Diagramming;
using MindFusion.Drawing;

namespace ScoreWriter
{
    class NoteNode : DiagramNode
    {
        public NoteNode()
        {
            Bounds = new RectangleF(0, 0, 6, 6);
            Duration = Duration.Whole;
        }

        public NoteNode(Duration duration)
        {
            Bounds = new RectangleF(0, 0, 6, 6);
            Duration = duration;
        }

        public NoteNode(NoteNode prototype) : base(prototype)
        {
            Duration = prototype.Duration;
        }

        protected override void SaveTo(System.IO.BinaryWriter writer, PersistContext context)
        {
            base.SaveTo(writer, context);
            context.Writer.Write((int)Duration);
        }

        protected override void LoadFrom(System.IO.BinaryReader reader, PersistContext context)
        {
            base.LoadFrom(reader, context);
            Duration = (Duration)context.Reader.ReadInt32();
        }

        public override void DrawLocal(IGraphics graphics, RenderOptions options)
        {
            base.DrawLocal(graphics, options);

            var cx = Bounds.Width / 2;
            var cy = Bounds.Height / 2;

            var gs = graphics.Save();
            graphics.TranslateTransform(cx, cy);
            graphics.RotateTransform(-10);
            graphics.TranslateTransform(-cx, -cy);

            var bounds = GetLocalBounds();
            bounds.Inflate(0, -bounds.Width / 10);
            var path = new GraphicsPath();
            path.AddEllipse(bounds);

            if (Duration == Duration.Whole || Duration == Duration.Half)
            {
                bounds.Inflate(-bounds.Width / 8, -bounds.Width / 6);
                path.AddEllipse(bounds);
            }
            graphics.FillPath(Brushes.Black, path);

            graphics.Restore(gs);

            if (position < -1 || position > 8)
            {
                // draw ledger lines if above or below staff
                var pen = EffectivePen.CreateGdiPen();
                var staff = (StaffNode)MasterGroup.MainItem;
                var yoff = staff.Bounds.Y - Bounds.Y;
                int i1 = position < -1 ? position : 9;
                int i2 = position < -1 ? -2 : position;
                for (int i = i1; i <= i2; i++)
                {
                    if (i % 2 != 0)
                        continue;
                    var y = yoff + i * staff.Bounds.Height / 8;
                    graphics.DrawLine(pen, -2, y, Bounds.Width + 2, y);
                }
                pen.Dispose();
            }

            if (Duration != Duration.Whole)
            {
                // draw stem
                float x = Bounds.Width;
                float y = Bounds.Height / 2;
                var pen = new System.Drawing.Pen(Color.Black, 0.5f);
                graphics.DrawLine(pen,
                                  x - pen.Width / 2, y,
                                  x - pen.Width / 2, y - Bounds.Height * 2);
                pen.Dispose();
            }

            if (Duration == Duration.Eighth || Duration == Duration.Sixteenth)
            {
                DrawFlag(graphics,
                         bounds.Width,
                         bounds.Height / 2 - bounds.Height * 2,
                         bounds.Width + 1,
                         bounds.Height);
            }

            if (Duration == Duration.Sixteenth)
            {
                DrawFlag(graphics,
                         bounds.Width,
                         bounds.Height - bounds.Height * 2,
                         bounds.Width + 1,
                         bounds.Height);
            }
        }

        void DrawFlag(IGraphics graphics, float x, float y, float w, float h)
        {
            float sh = h / 2;
            float sw = w / 3;

            var pen = new System.Drawing.Pen(Color.Black, 0.5f);
            x -= pen.Width / 2;
            graphics.DrawBezier(pen,
                                x, y,
                                x, y + sh,
                                x + sw * 1.2f, y + 2 * sh,
                                x + sw, y + 3 * sh);
            pen.Dispose();
        }

        public override void DrawShadowLocal(IGraphics graphics, RenderOptions options)
        {
        }

        public override RectangleF GetRepaintRect(bool includeConnected)
        {
            var r = Bounds;
            r.Y -= r.Height * 2;
            r.Height *= 3;
            r.Width *= 2;
            return r;
        }

        public StaffNode AlignToStaff()
        {
            position = 0;

            var staff = Parent.NearestStaff(GetCenter());
            if (staff == null)
                return null;

            var alignedPoint = staff.Align(GetCenter(), out position);
            alignedPoint.X -= Bounds.Width / 2;
            alignedPoint.Y -= Bounds.Height / 2;
            Move(alignedPoint.X, alignedPoint.Y);

            return staff;
        }

        protected override void CompleteModify(PointF end, InteractionState ist)
        {
            base.CompleteModify(end, ist);

            var staff = AlignToStaff();
            if (staff != null)
                AttachTo(staff, AttachToNode.TopLeft);
            else
            {
                Detach();
            }
        }

        public Duration Duration { get; set; }

        int position = 0;
    }

    enum Duration
    {
        Whole,
        Half,
        Quarter,
        Eighth,
        Sixteenth
    }
}