
namespace DiscordVocalSender
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TokenBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChannelBox = new System.Windows.Forms.TextBox();
            this.LengthBox = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelAudio = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.formBtn = new System.Windows.Forms.Button();
            this.formIntensity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.seeToken = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Salmon;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TokenBox
            // 
            this.TokenBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TokenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TokenBox.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TokenBox, "TokenBox");
            this.TokenBox.Name = "TokenBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Name = "label2";
            // 
            // ChannelBox
            // 
            this.ChannelBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ChannelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChannelBox.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.ChannelBox, "ChannelBox");
            this.ChannelBox.Name = "ChannelBox";
            // 
            // LengthBox
            // 
            this.LengthBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.LengthBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LengthBox.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.LengthBox, "LengthBox");
            this.LengthBox.Name = "LengthBox";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Name = "label4";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelAudio
            // 
            resources.ApplyResources(this.LabelAudio, "LabelAudio");
            this.LabelAudio.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LabelAudio.Name = "LabelAudio";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.SendButton, "SendButton");
            this.SendButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SendButton.Name = "SendButton";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_ClickAsync);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Name = "label5";
            // 
            // formBtn
            // 
            this.formBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.formBtn, "formBtn");
            this.formBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.formBtn.Name = "formBtn";
            this.formBtn.UseVisualStyleBackColor = false;
            this.formBtn.Click += new System.EventHandler(this.formBtn_Click);
            // 
            // formIntensity
            // 
            this.formIntensity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.formIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formIntensity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.formIntensity.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.formIntensity, "formIntensity");
            this.formIntensity.Name = "formIntensity";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Name = "label6";
            // 
            // seeToken
            // 
            resources.ApplyResources(this.seeToken, "seeToken");
            this.seeToken.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seeToken.Name = "seeToken";
            this.seeToken.UseVisualStyleBackColor = true;
            this.seeToken.CheckedChanged += new System.EventHandler(this.seeToken_CheckedChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.seeToken);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.formIntensity);
            this.Controls.Add(this.formBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.LabelAudio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LengthBox);
            this.Controls.Add(this.ChannelBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TokenBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TokenBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChannelBox;
        private System.Windows.Forms.TextBox LengthBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelAudio;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button formBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox formIntensity;
        private System.Windows.Forms.CheckBox seeToken;
    }
}

