namespace UISearcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            searchtexbox = new TextBox();
            uploadDocument = new OpenFileDialog();
            searchButton = new Button();
            parsed = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(41, 552);
            button1.Name = "button1";
            button1.Size = new Size(273, 48);
            button1.TabIndex = 0;
            button1.Text = "UPLOAD DOCUMENT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // searchtexbox
            // 
            searchtexbox.Location = new Point(299, 147);
            searchtexbox.Name = "searchtexbox";
            searchtexbox.Size = new Size(301, 23);
            searchtexbox.TabIndex = 1;
            searchtexbox.TextChanged += searchtexbox_TextChanged;
            // 
            // uploadDocument
            // 
            uploadDocument.FileName = "uploadDocument";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(159, 134);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(106, 47);
            searchButton.TabIndex = 2;
            searchButton.Text = "SEARCH";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // parsed
            // 
            parsed.AllowDrop = true;
            parsed.Location = new Point(394, 347);
            parsed.Name = "parsed";
            parsed.Size = new Size(174, 88);
            parsed.TabIndex = 3;
            parsed.Text = "view parse document";
            parsed.UseVisualStyleBackColor = true;
            parsed.Click += parsed_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 653);
            Controls.Add(parsed);
            Controls.Add(searchButton);
            Controls.Add(searchtexbox);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox searchtexbox;
        private OpenFileDialog uploadDocument;
        private Button searchButton;
        private Button parsed;
    }
}