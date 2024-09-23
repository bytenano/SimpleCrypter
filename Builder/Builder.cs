using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleCrypter
{
    public partial class Builder : Form
    {
        public Builder()
        {
            InitializeComponent();

            //Screen Position
            StartPosition = FormStartPosition.CenterScreen;

            //Drag&Drop file path
            filepathbox.AllowDrop = true;
            filepathbox.DragEnter += filepathbox_DragEnter;
            filepathbox.DragDrop += filepathbox_DragDrop;
        }

        #region About  
        private void aboutbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About aboutwindow = new About();
            aboutwindow.Show();
        }

        #endregion

        #region FilePath
        private void fileselect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepathbox.Text = openFileDialog.FileName;
            }
        }

        private void filepathbox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                filepathbox.Text = files[0];
            }
        }

        private void filepathbox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        #region SelectInjection

        private void dotnetinjection_MouseDown(object sender, MouseEventArgs e)
        {
            dotnetinjection.Checked = true;
            nativeinjection.Checked = false;
        }

        private void nativeinjection_MouseDown(object sender, MouseEventArgs e)
        {
            dotnetinjection.Checked = false;
            nativeinjection.Checked = true;
        }


        #endregion

        #region Builder
        private void buildbtn_Click(object sender, EventArgs e)
        {
            if (filepathbox.Text == null)
            {
                MessageBox.Show("The path to the file was not specified", "SimpleCrypter");
            }
            else
            {
                bool isnet = false;
                if (dotnetinjection.Checked)
                {
                    isnet = true;
                }
                else
                {
                    isnet = false;
                }
                Build.BuildStub(filepathbox.Text, isnet, antivmbox.Checked, antivmbox.Checked, meltingbox.Checked, adminbox.Checked, startupbox.Checked, reactorbox.Checked);
            }
        }
        #endregion

        #region IconChanger

        public static string iconpath = null;
        private void iconselect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Icon Files (*.ico)|*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                iconpath = openFileDialog.FileName;
                iconpreview.Image = Icon.ExtractAssociatedIcon(iconpath).ToBitmap();
                clsbtn.Visible = true;
            }
        }

        private void clsbtn_Click(object sender, EventArgs e)
        {
            clsbtn.Visible = false;
            iconpath = null;
            iconpreview.Image = null;
        }

        #endregion
    }
}
