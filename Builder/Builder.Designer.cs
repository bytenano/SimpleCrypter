namespace SimpleCrypter
{
    partial class Builder
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.softtitle = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.filepathtitle = new System.Windows.Forms.Label();
            this.filepathbox = new System.Windows.Forms.TextBox();
            this.fileselect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dotnetinj = new System.Windows.Forms.Label();
            this.dotnetinjection = new System.Windows.Forms.RadioButton();
            this.nativeinjection = new System.Windows.Forms.RadioButton();
            this.nativeinj = new System.Windows.Forms.Label();
            this.antivmbox = new System.Windows.Forms.CheckBox();
            this.startupbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.antidebug = new System.Windows.Forms.CheckBox();
            this.adminbox = new System.Windows.Forms.CheckBox();
            this.meltingbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reactorbox = new System.Windows.Forms.CheckBox();
            this.buildbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.iconselect = new System.Windows.Forms.Button();
            this.clsbtn = new System.Windows.Forms.Button();
            this.iconpreview = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aboutbtn = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconpreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // softtitle
            // 
            this.softtitle.AutoSize = true;
            this.softtitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.softtitle.ForeColor = System.Drawing.Color.White;
            this.softtitle.Location = new System.Drawing.Point(79, 28);
            this.softtitle.Name = "softtitle";
            this.softtitle.Size = new System.Drawing.Size(133, 25);
            this.softtitle.TabIndex = 1;
            this.softtitle.Text = "SimpleCrypter";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.ForeColor = System.Drawing.Color.Gray;
            this.description.Location = new System.Drawing.Point(82, 56);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(245, 13);
            this.description.TabIndex = 2;
            this.description.Text = "A simple executable file crypter with injections";
            // 
            // filepathtitle
            // 
            this.filepathtitle.AutoSize = true;
            this.filepathtitle.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepathtitle.ForeColor = System.Drawing.Color.White;
            this.filepathtitle.Location = new System.Drawing.Point(12, 97);
            this.filepathtitle.Name = "filepathtitle";
            this.filepathtitle.Size = new System.Drawing.Size(56, 15);
            this.filepathtitle.TabIndex = 3;
            this.filepathtitle.Text = "File path:";
            // 
            // filepathbox
            // 
            this.filepathbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.filepathbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filepathbox.ForeColor = System.Drawing.Color.White;
            this.filepathbox.Location = new System.Drawing.Point(15, 124);
            this.filepathbox.Name = "filepathbox";
            this.filepathbox.Size = new System.Drawing.Size(290, 20);
            this.filepathbox.TabIndex = 4;
            this.filepathbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.filepathbox_DragDrop);
            this.filepathbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.filepathbox_DragEnter);
            // 
            // fileselect
            // 
            this.fileselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileselect.ForeColor = System.Drawing.Color.White;
            this.fileselect.Location = new System.Drawing.Point(311, 123);
            this.fileselect.Name = "fileselect";
            this.fileselect.Size = new System.Drawing.Size(58, 22);
            this.fileselect.TabIndex = 5;
            this.fileselect.Text = "Select";
            this.fileselect.UseVisualStyleBackColor = true;
            this.fileselect.Click += new System.EventHandler(this.fileselect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Injection type:";
            // 
            // dotnetinj
            // 
            this.dotnetinj.AutoSize = true;
            this.dotnetinj.Font = new System.Drawing.Font("Malgun Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotnetinj.ForeColor = System.Drawing.Color.White;
            this.dotnetinj.Location = new System.Drawing.Point(13, 187);
            this.dotnetinj.Name = "dotnetinj";
            this.dotnetinj.Size = new System.Drawing.Size(69, 12);
            this.dotnetinj.TabIndex = 7;
            this.dotnetinj.Text = ".NET Injection:";
            // 
            // dotnetinjection
            // 
            this.dotnetinjection.AutoSize = true;
            this.dotnetinjection.Checked = true;
            this.dotnetinjection.Location = new System.Drawing.Point(84, 186);
            this.dotnetinjection.Name = "dotnetinjection";
            this.dotnetinjection.Size = new System.Drawing.Size(14, 13);
            this.dotnetinjection.TabIndex = 8;
            this.dotnetinjection.TabStop = true;
            this.dotnetinjection.UseVisualStyleBackColor = true;
            this.dotnetinjection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dotnetinjection_MouseDown);
            // 
            // nativeinjection
            // 
            this.nativeinjection.AutoSize = true;
            this.nativeinjection.Location = new System.Drawing.Point(194, 186);
            this.nativeinjection.Name = "nativeinjection";
            this.nativeinjection.Size = new System.Drawing.Size(14, 13);
            this.nativeinjection.TabIndex = 10;
            this.nativeinjection.UseVisualStyleBackColor = true;
            this.nativeinjection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nativeinjection_MouseDown);
            // 
            // nativeinj
            // 
            this.nativeinj.AutoSize = true;
            this.nativeinj.Font = new System.Drawing.Font("Malgun Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nativeinj.ForeColor = System.Drawing.Color.White;
            this.nativeinj.Location = new System.Drawing.Point(115, 187);
            this.nativeinj.Name = "nativeinj";
            this.nativeinj.Size = new System.Drawing.Size(77, 12);
            this.nativeinj.TabIndex = 9;
            this.nativeinj.Text = "Native Injection:";
            // 
            // antivmbox
            // 
            this.antivmbox.AutoSize = true;
            this.antivmbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.antivmbox.ForeColor = System.Drawing.Color.White;
            this.antivmbox.Location = new System.Drawing.Point(11, 45);
            this.antivmbox.Name = "antivmbox";
            this.antivmbox.Size = new System.Drawing.Size(60, 17);
            this.antivmbox.TabIndex = 12;
            this.antivmbox.Text = "AntiVM";
            this.antivmbox.UseVisualStyleBackColor = true;
            // 
            // startupbox
            // 
            this.startupbox.AutoSize = true;
            this.startupbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startupbox.ForeColor = System.Drawing.Color.White;
            this.startupbox.Location = new System.Drawing.Point(9, 22);
            this.startupbox.Name = "startupbox";
            this.startupbox.Size = new System.Drawing.Size(62, 17);
            this.startupbox.TabIndex = 13;
            this.startupbox.Text = "StartUp";
            this.startupbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.antidebug);
            this.groupBox1.Controls.Add(this.adminbox);
            this.groupBox1.Controls.Add(this.meltingbox);
            this.groupBox1.Controls.Add(this.antivmbox);
            this.groupBox1.Controls.Add(this.startupbox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 95);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features";
            // 
            // antidebug
            // 
            this.antidebug.AutoSize = true;
            this.antidebug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.antidebug.ForeColor = System.Drawing.Color.White;
            this.antidebug.Location = new System.Drawing.Point(99, 22);
            this.antidebug.Name = "antidebug";
            this.antidebug.Size = new System.Drawing.Size(79, 17);
            this.antidebug.TabIndex = 17;
            this.antidebug.Text = "Anti-Debug";
            this.antidebug.UseVisualStyleBackColor = true;
            // 
            // adminbox
            // 
            this.adminbox.AutoSize = true;
            this.adminbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminbox.ForeColor = System.Drawing.Color.White;
            this.adminbox.Location = new System.Drawing.Point(99, 45);
            this.adminbox.Name = "adminbox";
            this.adminbox.Size = new System.Drawing.Size(91, 17);
            this.adminbox.TabIndex = 16;
            this.adminbox.Text = "Run as admin";
            this.adminbox.UseVisualStyleBackColor = true;
            // 
            // meltingbox
            // 
            this.meltingbox.AutoSize = true;
            this.meltingbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.meltingbox.ForeColor = System.Drawing.Color.White;
            this.meltingbox.Location = new System.Drawing.Point(11, 68);
            this.meltingbox.Name = "meltingbox";
            this.meltingbox.Size = new System.Drawing.Size(60, 17);
            this.meltingbox.TabIndex = 14;
            this.meltingbox.Text = "Melting";
            this.meltingbox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Code Obfuscation:";
            // 
            // reactorbox
            // 
            this.reactorbox.AutoSize = true;
            this.reactorbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reactorbox.Checked = true;
            this.reactorbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reactorbox.ForeColor = System.Drawing.Color.White;
            this.reactorbox.Location = new System.Drawing.Point(12, 351);
            this.reactorbox.Name = "reactorbox";
            this.reactorbox.Size = new System.Drawing.Size(119, 17);
            this.reactorbox.TabIndex = 17;
            this.reactorbox.Text = "Eziriz .NET Reactor";
            this.reactorbox.UseVisualStyleBackColor = true;
            // 
            // buildbtn
            // 
            this.buildbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildbtn.ForeColor = System.Drawing.Color.White;
            this.buildbtn.Location = new System.Drawing.Point(146, 406);
            this.buildbtn.Name = "buildbtn";
            this.buildbtn.Size = new System.Drawing.Size(90, 23);
            this.buildbtn.TabIndex = 18;
            this.buildbtn.Text = "Build";
            this.buildbtn.UseVisualStyleBackColor = true;
            this.buildbtn.Click += new System.EventHandler(this.buildbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(250, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Icon Path:";
            // 
            // iconselect
            // 
            this.iconselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconselect.ForeColor = System.Drawing.Color.White;
            this.iconselect.Location = new System.Drawing.Point(313, 327);
            this.iconselect.Name = "iconselect";
            this.iconselect.Size = new System.Drawing.Size(54, 24);
            this.iconselect.TabIndex = 20;
            this.iconselect.Text = "Select";
            this.iconselect.UseVisualStyleBackColor = true;
            this.iconselect.Click += new System.EventHandler(this.iconselect_Click);
            // 
            // clsbtn
            // 
            this.clsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clsbtn.ForeColor = System.Drawing.Color.White;
            this.clsbtn.Location = new System.Drawing.Point(259, 370);
            this.clsbtn.Name = "clsbtn";
            this.clsbtn.Size = new System.Drawing.Size(54, 22);
            this.clsbtn.TabIndex = 22;
            this.clsbtn.Text = "Clear";
            this.clsbtn.UseVisualStyleBackColor = true;
            this.clsbtn.Visible = false;
            this.clsbtn.Click += new System.EventHandler(this.clsbtn_Click);
            // 
            // iconpreview
            // 
            this.iconpreview.Location = new System.Drawing.Point(326, 363);
            this.iconpreview.Name = "iconpreview";
            this.iconpreview.Size = new System.Drawing.Size(36, 33);
            this.iconpreview.TabIndex = 21;
            this.iconpreview.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleCrypter.Properties.Resources.simplecriptlogo_white_mini;
            this.pictureBox1.Location = new System.Drawing.Point(15, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 56);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // aboutbtn
            // 
            this.aboutbtn.ActiveLinkColor = System.Drawing.Color.White;
            this.aboutbtn.AutoSize = true;
            this.aboutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutbtn.LinkColor = System.Drawing.Color.White;
            this.aboutbtn.Location = new System.Drawing.Point(329, 20);
            this.aboutbtn.Name = "aboutbtn";
            this.aboutbtn.Size = new System.Drawing.Size(38, 15);
            this.aboutbtn.TabIndex = 23;
            this.aboutbtn.TabStop = true;
            this.aboutbtn.Text = "About";
            this.aboutbtn.VisitedLinkColor = System.Drawing.Color.White;
            this.aboutbtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutbtn_LinkClicked);
            // 
            // Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(380, 447);
            this.Controls.Add(this.aboutbtn);
            this.Controls.Add(this.clsbtn);
            this.Controls.Add(this.iconpreview);
            this.Controls.Add(this.iconselect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buildbtn);
            this.Controls.Add(this.reactorbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nativeinjection);
            this.Controls.Add(this.nativeinj);
            this.Controls.Add(this.dotnetinjection);
            this.Controls.Add(this.dotnetinj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileselect);
            this.Controls.Add(this.filepathbox);
            this.Controls.Add(this.filepathtitle);
            this.Controls.Add(this.description);
            this.Controls.Add(this.softtitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Builder";
            this.Text = "SimpleCrypter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconpreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label softtitle;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label filepathtitle;
        private System.Windows.Forms.TextBox filepathbox;
        private System.Windows.Forms.Button fileselect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dotnetinj;
        private System.Windows.Forms.RadioButton dotnetinjection;
        private System.Windows.Forms.RadioButton nativeinjection;
        private System.Windows.Forms.Label nativeinj;
        private System.Windows.Forms.CheckBox antivmbox;
        private System.Windows.Forms.CheckBox startupbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox meltingbox;
        private System.Windows.Forms.CheckBox adminbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox reactorbox;
        private System.Windows.Forms.Button buildbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button iconselect;
        private System.Windows.Forms.PictureBox iconpreview;
        private System.Windows.Forms.Button clsbtn;
        private System.Windows.Forms.LinkLabel aboutbtn;
        private System.Windows.Forms.CheckBox antidebug;
    }
}

