namespace xmlEditor
{
    partial class Form1
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
            this.pathName = new System.Windows.Forms.TextBox();
            this.browseXML = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.parseXML = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.widgetCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathName
            // 
            this.pathName.Location = new System.Drawing.Point(12, 34);
            this.pathName.Name = "pathName";
            this.pathName.ReadOnly = true;
            this.pathName.Size = new System.Drawing.Size(470, 20);
            this.pathName.TabIndex = 1;
            // 
            // browseXML
            // 
            this.browseXML.Location = new System.Drawing.Point(399, 71);
            this.browseXML.Name = "browseXML";
            this.browseXML.Size = new System.Drawing.Size(83, 34);
            this.browseXML.TabIndex = 2;
            this.browseXML.Text = "browse and parse XML";
            this.browseXML.UseVisualStyleBackColor = true;
            this.browseXML.Click += new System.EventHandler(this.browseXML_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(399, 121);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(83, 23);
            this.edit.TabIndex = 3;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(399, 205);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(83, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(399, 163);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(83, 23);
            this.Add.TabIndex = 5;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // parseXML
            // 
            this.parseXML.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.dob,
            this.widgetCount});
            this.parseXML.GridLines = true;
            this.parseXML.Location = new System.Drawing.Point(12, 71);
            this.parseXML.Name = "parseXML";
            this.parseXML.Size = new System.Drawing.Size(340, 197);
            this.parseXML.TabIndex = 7;
            this.parseXML.UseCompatibleStateImageBehavior = false;
            this.parseXML.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 100;
            // 
            // dob
            // 
            this.dob.Text = "DoB";
            this.dob.Width = 120;
            // 
            // widgetCount
            // 
            this.widgetCount.Text = "Widget Count";
            this.widgetCount.Width = 115;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(399, 245);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(83, 23);
            this.delete.TabIndex = 8;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 281);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.parseXML);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.save);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.browseXML);
            this.Controls.Add(this.pathName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pathName;
        private System.Windows.Forms.Button browseXML;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ListView parseXML;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader dob;
        private System.Windows.Forms.ColumnHeader widgetCount;
        private System.Windows.Forms.Button delete;
    }
}

