using System;
using System.IO;
using System.Drawing;
using Chizl.EmojiLive;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;

namespace Framework48FormsDemo
{
    public partial class Form1 : Form
    {
        private PropertyInfo[] _properties = null;
        private Emoji _emoji = Emoji.Empty;
        private string _fileName = "";
        private Type _strucType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetLabels();
        }

        private void btnDisplayFromFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                picFileDisp.Image = Image.FromFile(_fileName);
                lblFromFile.Text = $"'{_emoji.FullName}' found..";
                picFileDisp.Invalidate();
            }
            else
                lblFromFile.Text = $"'{_fileName}' not found.";
        }

        private void btnCreateFromLib_Click(object sender, EventArgs e)
        {
            if (_emoji.EmojiPngImage != null)
            {
                using (MemoryStream ms = new MemoryStream(_emoji.EmojiPngImage))
                {
                    if (!File.Exists(_fileName))
                        Image.FromStream(ms).Save(_fileName, ImageFormat.Png);
                    picLibDisp.Image = Image.FromStream(ms);
                }

                picLibDisp.Invalidate();
            }

            if (File.Exists(_fileName))
                btnDisplayFromFile.Enabled = true;
            else
                btnDisplayFromFile.Enabled = false;
        }

        private void ResetLabels()
        {
            lblFromLib.Text = "";
            lblFromLib.Left = 0;
            lblFromLib.Width = this.Width;
            lblFromFile.Text = "";
            lblFromFile.Left = 0;
            lblFromFile.Width = this.Width;
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selText = cbGroup.Items[cbGroup.SelectedIndex].ToString();
            switch(selText)
            {
                case "EmojiActivities":
                    _strucType = typeof(EmojiActivities);
                    break;
                case "EmojiAnimalsNature":
                    _strucType = typeof(EmojiAnimalsNature);
                    break;
                case "EmojiBasicLatin":
                    _strucType = typeof(EmojiBasicLatin);
                    break;
                case "EmojiFlags":
                    _strucType = typeof(EmojiFlags);
                    break;
                case "EmojiFoodDrink":
                    _strucType = typeof(EmojiFoodDrink);
                    break;
                case "EmojiObjects":
                    _strucType = typeof(EmojiObjects);
                    break;
            }

            LoadEmoji(_strucType);
        }

        private void cbEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selText = cbEmoji.Items[cbEmoji.SelectedIndex].ToString();
            foreach(var prop in _properties)
            {
                if(selText.Equals(prop.Name))
                {
                    _emoji = (Emoji)prop.GetValue(_strucType);
                    LoadEmoji(_emoji);
                    break;
                }
            }
        }

        private void LoadEmoji(Type struc)
        {
            cbEmoji.Items.Clear();
            _properties = struc.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var property in _properties)
                cbEmoji.Items.Add(property.Name);
        }

        private void LoadEmoji(Emoji emoji)
        {
            if (emoji.IsEmpty)
                return;

            _emoji = emoji;
            _fileName = $"./{_emoji.Name}.png";
            btnCreateFromLib.Enabled = true;
        }

    }
}
