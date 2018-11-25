namespace xmlEditor
{
    partial class addItems
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.birthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.widgetTextBox = new System.Windows.Forms.TextBox();
            this.saveChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 22);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(126, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DoB";
            // 
            // birthTextBox
            // 
            this.birthTextBox.Location = new System.Drawing.Point(12, 48);
            this.birthTextBox.Name = "birthTextBox";
            this.birthTextBox.Size = new System.Drawing.Size(126, 20);
            this.birthTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "widget";
            // 
            // widgetTextBox
            // 
            this.widgetTextBox.Location = new System.Drawing.Point(12, 74);
            this.widgetTextBox.Name = "widgetTextBox";
            this.widgetTextBox.Size = new System.Drawing.Size(126, 20);
            this.widgetTextBox.TabIndex = 7;
            // 
            // saveChange
            // 
            this.saveChange.Location = new System.Drawing.Point(26, 100);
            this.saveChange.Name = "saveChange";
            this.saveChange.Size = new System.Drawing.Size(100, 23);
            this.saveChange.TabIndex = 10;
            this.saveChange.Text = "Save Changes";
            this.saveChange.UseVisualStyleBackColor = true;
            this.saveChange.Click += new System.EventHandler(this.saveChange_Click);
            // 
            // addItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 145);
            this.Controls.Add(this.saveChange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widgetTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.birthTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "addItems";
            this.Text = "Changes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addItems_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox birthTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox widgetTextBox;
        private System.Windows.Forms.Button saveChange;
    }
}