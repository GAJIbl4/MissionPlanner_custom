using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFmpeg.AutoGen;

namespace MissionPlanner.Controls
{
    public partial class RTSPStreamer : Form
    {
        private Thread _videoThread;
        private volatile bool _running;

        public RTSPStreamer()
        {
            InitializeComponent();

            this.Text = "RTSP Видеопоток";
            this.Size = new Size(640, 480);

            var btnDiscover = new Button
            {
                Text = "Найти ONVIF камеры",
                Dock = DockStyle.Top,
                Height = 40
            };
            btnDiscover.Click += (s, e) =>
            {
                var list = OnvifDiscovery.Discover();
                if (list.Count == 0)
                {
                    MessageBox.Show("Камеры не найдены");
                }
                else
                {
                    MessageBox.Show("Найдено:\n" + string.Join("\n", list));
                }
            };
            this.Controls.Add(btnDiscover);

            var pictureBox = new PictureBox
            {
                Name = "pictureBox",
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Black
            };
            this.Controls.Add(pictureBox);

            _running = true;
            _videoThread = new Thread(() => RunVideoThread(pictureBox));
            _videoThread.IsBackground = true;
            _videoThread.Start();
        }

        

        private void RunVideoThread(PictureBox pictureBox)
        {
            // ВРЕМЕННО: просто затычка, чтобы видеть, что поток работает
            // Позже сюда пойдёт FFmpeg-декодированный поток
            while (_running)
            {
                using (var bmp = new Bitmap(640, 480))
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Black);
                    g.DrawString(DateTime.Now.ToString("HH:mm:ss.fff"), SystemFonts.DefaultFont, Brushes.White, new PointF(10, 10));
                    pictureBox.Invoke(new Action(() => pictureBox.Image = (Bitmap)bmp.Clone()));
                }
                Thread.Sleep(100);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this._running = false;
            base.OnFormClosing(e);
        }
    }
}
