using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace watchWall
{
    public partial class frm_wallpaper : Form
    {
        public frm_wallpaper()
        {
            InitializeComponent();
        }

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }

        string wallpaperPath = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop").GetValue("WallPaper").ToString();
        string cacheWallpaperPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\CachedFiles");
        private void frm_wallpaper_Load(object sender, EventArgs e)
        {  
            if (!File.Exists(wallpaperPath))
            {
                wallpaperPath = Directory.GetFiles(cacheWallpaperPath, "*.jpg").Single(item => item.Contains("1920"));
            }

            try
            {
                File.Copy(wallpaperPath, Path.Combine(cacheWallpaperPath, "..", "origin.jpg"), true);
            }
            catch { }

            pbx_wallpaper.ImageLocation = wallpaperPath;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            tmr_wallpaper.Start();
            tmr_wallpaper_Tick(null, null);
        }

        string tempXML = null;
        private void tmr_wallpaper_Tick(object sender, EventArgs e)
        {
            var xml = new XmlDocument();
            using (var wc = new WebClient())
            {
                xml.LoadXml(wc.DownloadString("http://api.tavcan.com/xml/doviz.xml"));
            }

            if (tempXML != xml.OuterXml)
            {
                tempXML = xml.OuterXml;

                XmlNodeList nodes = xml.SelectNodes("piyasa/*");

                string output = null;
                foreach (XmlNode node in nodes)
                {
                    if(node.Name == "tarih")
                    {
                        output += String.Format("{0}: {1}\n", node.Name, node.InnerText);
                        continue;
                    }

                    output += String.Format("{0}: {1}\n", node.Name, node.ChildNodes[1].InnerText);
                }

                Bitmap bitmap = (Bitmap)Image.FromFile(wallpaperPath);

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Arial", 15))
                    {
                        graphics.DrawString(output, arialFont, Brushes.White, new Point(Screen.PrimaryScreen.Bounds.Width + 100, 0));
                    }
                }

                string savedPath = Path.Combine(cacheWallpaperPath, "desktop.jpg");

                bitmap.Save(savedPath, ImageFormat.Jpeg);

                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, savedPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }

        private void frm_wallpaper_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, Path.Combine(cacheWallpaperPath, "..", "origin.jpg"), SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        }
    }
}
