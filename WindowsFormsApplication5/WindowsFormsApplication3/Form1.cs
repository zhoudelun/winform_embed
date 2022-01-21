using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitListBox();
        }

        public class ListBoxViewItem
        {
            public string Title { set; get; }
            public Image Image { set; get; }

            public string LastMessage { set; get; }

            public int MessageCount { set; get; }
        }

        //private void InitListBox()
        //{
        //    List<ListBoxViewItem> viewItems = new List<ListBoxViewItem>();

        //    var newImage = new Bitmap(Resources.touxiang, 50, 50);
        //    viewItems.Add(new ListBoxViewItem() { Title = "像风一样自由的人妖", Image = newImage, LastMessage = "好吧，再说吧", MessageCount = 12 });
        //    viewItems.Add(new ListBoxViewItem() { Title = "xxxxxx", Image = newImage, LastMessage = "好吧，再说吧" });
        //    viewItems.Add(new ListBoxViewItem() { Title = "像风一样自由的人妖", Image = newImage, LastMessage = "enen", MessageCount = 999 });
        //    viewItems.Add(new ListBoxViewItem() { Title = "像风一样自由的人妖", Image = newImage, LastMessage = "haoba" });
        //    viewItems.Add(new ListBoxViewItem() { Title = "像风一样自由的人妖", Image = newImage, LastMessage = "好吧，再说吧", MessageCount = 12 });

        //    listBox1.DataSource = viewItems;
        //    listBox1.ItemHeight = 70;
        //    listBox1.DrawMode = DrawMode.OwnerDrawVariable;
        //    listBox1.DrawItem += (s, v) =>
        //    {
        //        if (v.Index < 0) return;

        //        var graphics = v.Graphics;
        //        if ((v.State & DrawItemState.Selected) == DrawItemState.Selected)
        //        {
        //            v.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#eee")), v.Bounds);
        //        }
        //        else
        //        {
        //            v.Graphics.FillRectangle(new SolidBrush(listBox1.BackColor), v.Bounds);
        //        }
        //        var item = viewItems[v.Index];
        //        var offsety = (v.Bounds.Height - item.Image.Height) / 2;
        //        v.Graphics.DrawImage(item.Image, v.Bounds.X + 5, v.Bounds.Y + offsety);
        //        var titleOffsetx = item.Image.Width + 5 + 30;
        //        var titleFont = new Font(this.Font, FontStyle.Bold);
        //        v.Graphics.DrawString(item.Title, titleFont, new SolidBrush(Color.Black), titleOffsetx + v.Bounds.X, v.Bounds.Y + offsety + 10);
        //        v.Graphics.DrawString(item.LastMessage, Font, new SolidBrush(ColorTranslator.FromHtml("#666")), titleOffsetx + v.Bounds.X, v.Bounds.Y + offsety + 10 + 20);

        //        if (item.MessageCount <= 0) return;
        //        var showData = item.MessageCount.ToString();
        //        var size = graphics.MeasureString(showData, Font);
        //        size = size.Height > size.Width ? new SizeF(size.Height, size.Height) : size;
        //        var maxWidth = Math.Max((int)size.Height, (int)size.Width);
        //        var rect = new Rectangle(v.Bounds.X + v.Bounds.Width - (int)size.Width - 20, v.Bounds.Y + 20, (int)size.Width, (int)size.Height);
        //        rect.Inflate(2, 2);
        //        rect.Offset(-3, 10);

        //        var raduis = Math.Min(rect.Height, rect.Width);
        //        var graphicsPath = new GraphicsPath();
        //        graphicsPath.AddArc(new Rectangle(rect.X, rect.Y, raduis, raduis), -180, 90);
        //        graphicsPath.AddArc(new Rectangle(rect.X + rect.Width - raduis, rect.Y, raduis, raduis), -90, 90);
        //        graphicsPath.AddArc(new Rectangle(rect.X + rect.Width - raduis, rect.Y + rect.Height - raduis, raduis, raduis), 0, 90);
        //        graphicsPath.AddArc(new Rectangle(rect.X, rect.Y + rect.Height - raduis, raduis, raduis), 90, 90);
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        using (var brush = new SolidBrush(Color.Red))
        //        {
        //            graphics.FillPath(brush, graphicsPath);
        //        }
        //        using (var brush = new SolidBrush(Color.White))
        //        {
        //            graphics.DrawString(
        //               showData, Font,
        //                brush, rect,
        //                new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        //        }
        //    };
        //}
    }
}
