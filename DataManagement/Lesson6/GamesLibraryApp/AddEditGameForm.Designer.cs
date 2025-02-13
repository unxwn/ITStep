namespace GamesLibraryApp
{
    partial class AddEditGameForm
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
            titleTextBox = new TextBox();
            titleLabel = new Label();
            studioLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            genreTextBox = new TextBox();
            saveBtn = new Button();
            cancelBtn = new Button();
            releaseYearTextBox = new TextBox();
            studioComboBox = new ComboBox();
            label1 = new Label();
            multiplayerCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleTextBox.Location = new Point(12, 44);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(334, 29);
            titleTextBox.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(12, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(52, 25);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Title:";
            // 
            // studioLabel
            // 
            studioLabel.AutoSize = true;
            studioLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            studioLabel.Location = new Point(12, 93);
            studioLabel.Name = "studioLabel";
            studioLabel.Size = new Size(122, 25);
            studioLabel.TabIndex = 4;
            studioLabel.Text = "Game studio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(13, 253);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 8;
            label2.Text = "Release year:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 174);
            label3.Name = "label3";
            label3.Size = new Size(67, 25);
            label3.TabIndex = 6;
            label3.Text = "Genre:";
            // 
            // genreTextBox
            // 
            genreTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            genreTextBox.Location = new Point(12, 202);
            genreTextBox.Name = "genreTextBox";
            genreTextBox.Size = new Size(334, 29);
            genreTextBox.TabIndex = 5;
            // 
            // saveBtn
            // 
            saveBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            saveBtn.Location = new Point(75, 389);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(93, 36);
            saveBtn.TabIndex = 10;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cancelBtn.Location = new Point(200, 389);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(93, 36);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // releaseYearTextBox
            // 
            releaseYearTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            releaseYearTextBox.Location = new Point(12, 281);
            releaseYearTextBox.Name = "releaseYearTextBox";
            releaseYearTextBox.Size = new Size(334, 29);
            releaseYearTextBox.TabIndex = 13;
            // 
            // studioComboBox
            // 
            studioComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            studioComboBox.Location = new Point(13, 121);
            studioComboBox.Name = "studioComboBox";
            studioComboBox.Size = new Size(333, 29);
            studioComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(14, 340);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 14;
            label1.Text = "Multiplayer:";
            // 
            // multiplayerCheckBox
            // 
            multiplayerCheckBox.AutoSize = true;
            multiplayerCheckBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            multiplayerCheckBox.Location = new Point(125, 348);
            multiplayerCheckBox.Name = "multiplayerCheckBox";
            multiplayerCheckBox.Size = new Size(15, 14);
            multiplayerCheckBox.TabIndex = 15;
            multiplayerCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddEditGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 448);
            Controls.Add(multiplayerCheckBox);
            Controls.Add(label1);
            Controls.Add(studioComboBox);
            Controls.Add(releaseYearTextBox);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(studioLabel);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(genreTextBox);
            Name = "AddEditGameForm";
            Text = "AddEditGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private Label titleLabel;
        private Label studioLabel;
        private Label label2;
        private Label label3;
        private TextBox genreTextBox;
        private Button saveBtn;
        private Button cancelBtn;
        private TextBox releaseYearTextBox;
        private ComboBox studioComboBox;
        private Label label1;
        private CheckBox multiplayerCheckBox;
    }
}