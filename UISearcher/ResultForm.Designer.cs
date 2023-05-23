namespace UISearcher
{
    partial class ResultForm
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
            label1 = new Label();
            resultListbox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Lucida Sans", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(56, 43);
            label1.Name = "label1";
            label1.Size = new Size(529, 40);
            label1.TabIndex = 0;
            label1.Text = "RESULTS";
            // 
            // resultListbox
            // 
            resultListbox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            resultListbox.FormattingEnabled = true;
            resultListbox.ItemHeight = 25;
            resultListbox.Location = new Point(12, 124);
            resultListbox.Name = "resultListbox";
            resultListbox.Size = new Size(1376, 554);
            resultListbox.TabIndex = 1;
            resultListbox.SelectedIndexChanged += resultListbox_SelectedIndexChanged;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1408, 745);
            Controls.Add(resultListbox);
            Controls.Add(label1);
            Name = "ResultForm";
            Text = "ResultForm";
            Load += ResultForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ListBox resultListbox;
    }
}