using System;
using System.IO;
using System.Drawing;
using Chizl.EmojiLive;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;
using System.Linq;

namespace Framework48FormsDemo
{
    public partial class Form1 : Form
    {
        private readonly Type[] _emojiGroupsTypes = new Type[] {
            typeof(EmojiActivities),
            typeof(EmojiAnimalsNature),
            typeof(EmojiSmileysEmotion),
            typeof(EmojiPeopleBody),
            typeof(EmojiFoodDrink),
            typeof(EmojiObjects) };

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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _emoji = null;
            picFileDisp.Image = null;
            picFileDisp.ImageLocation = null;
            picFileDisp.Dispose();
            picLibDisp.Image = null;
            picLibDisp.ImageLocation = null;
            picLibDisp.Dispose();

            if (_properties != null)
            {
                foreach (var p in _properties)
                {
                    //p.SetValue(this, null);
                }
            }

            var files = Directory.GetFiles(".\\", "*.png");
            if (files.Length > 0 && 
                MessageBox.Show($"There were '{files.Length}' png files created.\nDo you want to delete them?\n{(new string('-', 30))}\n- {string.Join("\n- ", files)}", 
                                "Delete", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var file in files)
                {
                    try { File.Delete(file); } 
                    catch { /* if fails, ignore */ }
                }
            }
        }
        private void btnDisplayFromFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                //done this way, because Image.FromFile(), holds the handle open and it can not be release or disposed.
                Image img = Image.FromStream(new MemoryStream(File.ReadAllBytes(_fileName)));
                picFileDisp.Image = img;
                
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
                    {
                        //var strImg = Image.FromStream(ms);
                        using (var strImg = Image.FromStream(ms))
                            strImg.Save(_fileName, ImageFormat.Png);
                    }

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

            cbGroup.Items.Clear();
            foreach (var t in _emojiGroupsTypes.OrderBy(o => o.Name))
                cbGroup.Items.Add(t.Name);
        }
        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selText = cbGroup.Items[cbGroup.SelectedIndex].ToString();
            _strucType = _emojiGroupsTypes.Where(w => w.Name == selText).FirstOrDefault();
            if (_strucType != null)
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

            foreach (var property in _properties.OrderBy(o => o.Name))
                cbEmoji.Items.Add(property.Name);
        }
        private void LoadEmoji(Emoji emoji)
        {
            if (emoji.IsEmpty)
                return;

            _emoji = emoji;
            lblEmoji.Text = _emoji.EmojiCharacter;
            _fileName = $"./{_emoji.Name}.png";
            btnCreateFromLib.Enabled = true;
        }

    }
}
