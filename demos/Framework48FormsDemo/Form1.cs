using System;
using System.IO;
using System.Drawing;
using Chizl.EmojiLive;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Framework48FormsDemo
{
    public partial class Form1 : Form
    {
        byte[] imageBytes = new byte[] { };
        string imgName = "";
        Emoji Emoji;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Emoji = EmojiActivities.FlowerPlayingCards;
            imageBytes = Emoji.EmojiPngImage;
            imgName = $"./{Emoji.Name}.png";
        }
        private void btnDisplayFromFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(imgName))
            {
                picFileDisp.Image = Image.FromFile(imgName);
                label1.Text = $"'{imgName}' found..";
                picFileDisp.Invalidate();
            }
            else
                label1.Text = $"'{imgName}' not found.";
        }
        private void btnCreateFromLib_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                if (!File.Exists(imgName))
                    Image.FromStream(ms).Save(imgName, ImageFormat.Png);
                picLibDisp.Image = Image.FromStream(ms);
            }

            picLibDisp.Invalidate();
        }
    }
}
