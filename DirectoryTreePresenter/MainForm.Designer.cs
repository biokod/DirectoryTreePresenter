namespace DirectoryTreePresenter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.treeView = new System.Windows.Forms.TreeView();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.tfPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCreated = new System.Windows.Forms.TextBox();
            this.tbModified = new System.Windows.Forms.TextBox();
            this.tbAccessed = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.tbAttributes = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 216);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(239, 334);
            this.treeView.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBrowse.Location = new System.Drawing.Point(469, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(108, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Open directory";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Enabled = false;
            this.textBox.Location = new System.Drawing.Point(257, 49);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(515, 501);
            this.textBox.TabIndex = 3;
            this.textBox.Text = "";
            // 
            // tfPath
            // 
            this.tfPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tfPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tfPath.Location = new System.Drawing.Point(13, 10);
            this.tfPath.Name = "tfPath";
            this.tfPath.ReadOnly = true;
            this.tfPath.Size = new System.Drawing.Size(432, 22);
            this.tfPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Created:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modified:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Accessed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Owner:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Attributes:";
            // 
            // tbCreated
            // 
            this.tbCreated.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCreated.Location = new System.Drawing.Point(86, 49);
            this.tbCreated.Name = "tbCreated";
            this.tbCreated.ReadOnly = true;
            this.tbCreated.Size = new System.Drawing.Size(165, 22);
            this.tbCreated.TabIndex = 4;
            // 
            // tbModified
            // 
            this.tbModified.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbModified.Location = new System.Drawing.Point(86, 77);
            this.tbModified.Name = "tbModified";
            this.tbModified.ReadOnly = true;
            this.tbModified.Size = new System.Drawing.Size(165, 22);
            this.tbModified.TabIndex = 4;
            // 
            // tbAccessed
            // 
            this.tbAccessed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbAccessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAccessed.Location = new System.Drawing.Point(86, 105);
            this.tbAccessed.Name = "tbAccessed";
            this.tbAccessed.ReadOnly = true;
            this.tbAccessed.Size = new System.Drawing.Size(165, 22);
            this.tbAccessed.TabIndex = 4;
            // 
            // tbSize
            // 
            this.tbSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSize.Location = new System.Drawing.Point(86, 133);
            this.tbSize.Name = "tbSize";
            this.tbSize.ReadOnly = true;
            this.tbSize.Size = new System.Drawing.Size(165, 22);
            this.tbSize.TabIndex = 4;
            // 
            // tbOwner
            // 
            this.tbOwner.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOwner.Location = new System.Drawing.Point(86, 160);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.ReadOnly = true;
            this.tbOwner.Size = new System.Drawing.Size(165, 22);
            this.tbOwner.TabIndex = 4;
            // 
            // tbAttributes
            // 
            this.tbAttributes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAttributes.Location = new System.Drawing.Point(86, 188);
            this.tbAttributes.Name = "tbAttributes";
            this.tbAttributes.ReadOnly = true;
            this.tbAttributes.Size = new System.Drawing.Size(165, 22);
            this.tbAttributes.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAttributes);
            this.Controls.Add(this.tbOwner);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbAccessed);
            this.Controls.Add(this.tbModified);
            this.Controls.Add(this.tbCreated);
            this.Controls.Add(this.tfPath);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.treeView);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Directory Tree Presenter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.TextBox tfPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCreated;
        private System.Windows.Forms.TextBox tbModified;
        private System.Windows.Forms.TextBox tbAccessed;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbOwner;
        private System.Windows.Forms.TextBox tbAttributes;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

