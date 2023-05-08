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
            matricLabel = new Label();
            matrictextbox = new TextBox();
            LoadStudentButton = new Button();
            Namelabel = new Label();
            facultylabel = new Label();
            cgpaLabel = new Label();
            departmentLabel = new Label();
            SuspendLayout();
            // 
            // matricLabel
            // 
            matricLabel.Location = new Point(146, 343);
            matricLabel.Name = "matricLabel";
            matricLabel.Size = new Size(139, 31);
            matricLabel.TabIndex = 0;
            matricLabel.Text = "enter matic number";
            // 
            // matrictextbox
            // 
            matrictextbox.Location = new Point(342, 340);
            matrictextbox.Name = "matrictextbox";
            matrictextbox.Size = new Size(291, 23);
            matrictextbox.TabIndex = 1;
            // 
            // LoadStudentButton
            // 
            LoadStudentButton.Location = new Point(276, 416);
            LoadStudentButton.Name = "LoadStudentButton";
            LoadStudentButton.Size = new Size(166, 50);
            LoadStudentButton.TabIndex = 2;
            LoadStudentButton.Text = "load student";
            LoadStudentButton.UseVisualStyleBackColor = true;
            LoadStudentButton.Click += button1_Click;
            // 
            // Namelabel
            // 
            Namelabel.AutoSize = true;
            Namelabel.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Namelabel.Location = new Point(151, 39);
            Namelabel.Name = "Namelabel";
            Namelabel.Size = new Size(71, 25);
            Namelabel.TabIndex = 3;
            Namelabel.Text = "NAME";
            // 
            // facultylabel
            // 
            facultylabel.AutoSize = true;
            facultylabel.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            facultylabel.Location = new Point(151, 84);
            facultylabel.Name = "facultylabel";
            facultylabel.Size = new Size(106, 25);
            facultylabel.TabIndex = 5;
            facultylabel.Text = "FACULTY";
            // 
            // cgpaLabel
            // 
            cgpaLabel.AutoSize = true;
            cgpaLabel.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            cgpaLabel.Location = new Point(151, 177);
            cgpaLabel.Name = "cgpaLabel";
            cgpaLabel.Size = new Size(67, 25);
            cgpaLabel.TabIndex = 6;
            cgpaLabel.Text = "CGPA";
            // 
            // departmentLabel
            // 
            departmentLabel.AutoSize = true;
            departmentLabel.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            departmentLabel.Location = new Point(151, 131);
            departmentLabel.Name = "departmentLabel";
            departmentLabel.Size = new Size(155, 25);
            departmentLabel.TabIndex = 7;
            departmentLabel.Text = "DEPARTMENT";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 583);
            Controls.Add(departmentLabel);
            Controls.Add(cgpaLabel);
            Controls.Add(facultylabel);
            Controls.Add(Namelabel);
            Controls.Add(LoadStudentButton);
            Controls.Add(matrictextbox);
            Controls.Add(matricLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label matricLabel;
        private TextBox matrictextbox;
        private Button LoadStudentButton;
        private Label Namelabel;
        private Label facultylabel;
        private Label cgpaLabel;
        private Label departmentLabel;
    }
}