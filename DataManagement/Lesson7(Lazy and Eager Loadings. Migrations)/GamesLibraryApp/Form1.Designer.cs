namespace GamesLibraryApp
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
            tabControl1 = new TabControl();
            gamesLibraryTab = new TabPage();
            multiplayerCheckBox = new CheckBox();
            editBtn = new Button();
            addGameBtn = new Button();
            deleteBtn = new Button();
            filterBtn = new Button();
            cbStudio = new ComboBox();
            releaseYearLabel = new Label();
            releaseYearFilterTextBox = new TextBox();
            label5 = new Label();
            genresFilterTextBox = new TextBox();
            studioLabel = new Label();
            label2 = new Label();
            label1 = new Label();
            gameNameFilterTextBox = new TextBox();
            gamesListDataGridView = new DataGridView();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            gamesLibraryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gamesListDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(gamesLibraryTab);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1019, 499);
            tabControl1.TabIndex = 0;
            // 
            // gamesLibraryTab
            // 
            gamesLibraryTab.Controls.Add(multiplayerCheckBox);
            gamesLibraryTab.Controls.Add(editBtn);
            gamesLibraryTab.Controls.Add(addGameBtn);
            gamesLibraryTab.Controls.Add(deleteBtn);
            gamesLibraryTab.Controls.Add(filterBtn);
            gamesLibraryTab.Controls.Add(cbStudio);
            gamesLibraryTab.Controls.Add(releaseYearLabel);
            gamesLibraryTab.Controls.Add(releaseYearFilterTextBox);
            gamesLibraryTab.Controls.Add(label5);
            gamesLibraryTab.Controls.Add(genresFilterTextBox);
            gamesLibraryTab.Controls.Add(studioLabel);
            gamesLibraryTab.Controls.Add(label2);
            gamesLibraryTab.Controls.Add(label1);
            gamesLibraryTab.Controls.Add(gameNameFilterTextBox);
            gamesLibraryTab.Controls.Add(gamesListDataGridView);
            gamesLibraryTab.Location = new Point(4, 24);
            gamesLibraryTab.Name = "gamesLibraryTab";
            gamesLibraryTab.Padding = new Padding(3);
            gamesLibraryTab.Size = new Size(1011, 471);
            gamesLibraryTab.TabIndex = 0;
            gamesLibraryTab.Text = "Games library";
            gamesLibraryTab.UseVisualStyleBackColor = true;
            // 
            // multiplayerCheckBox
            // 
            multiplayerCheckBox.AutoSize = true;
            multiplayerCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            multiplayerCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            multiplayerCheckBox.Location = new Point(854, 344);
            multiplayerCheckBox.Name = "multiplayerCheckBox";
            multiplayerCheckBox.Size = new Size(111, 25);
            multiplayerCheckBox.TabIndex = 15;
            multiplayerCheckBox.Text = "Multiplayer:";
            multiplayerCheckBox.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(87, 6);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.TabIndex = 3;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editGameBtn_Click;
            // 
            // addGameBtn
            // 
            addGameBtn.Location = new Point(6, 6);
            addGameBtn.Name = "addGameBtn";
            addGameBtn.Size = new Size(75, 23);
            addGameBtn.TabIndex = 2;
            addGameBtn.Text = "Add";
            addGameBtn.UseVisualStyleBackColor = true;
            addGameBtn.Click += addGameBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(168, 6);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 23);
            deleteBtn.TabIndex = 1;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteGameBtn_Click;
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(881, 376);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(75, 23);
            filterBtn.TabIndex = 14;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += filterBtn_Click;
            // 
            // cbStudio
            // 
            cbStudio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbStudio.FormattingEnabled = true;
            cbStudio.Location = new Point(854, 169);
            cbStudio.Name = "cbStudio";
            cbStudio.Size = new Size(126, 29);
            cbStudio.TabIndex = 13;
            // 
            // releaseYearLabel
            // 
            releaseYearLabel.AutoSize = true;
            releaseYearLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            releaseYearLabel.Location = new Point(854, 281);
            releaseYearLabel.Name = "releaseYearLabel";
            releaseYearLabel.Size = new Size(120, 25);
            releaseYearLabel.TabIndex = 12;
            releaseYearLabel.Text = "Release year:";
            // 
            // releaseYearFilterTextBox
            // 
            releaseYearFilterTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            releaseYearFilterTextBox.Location = new Point(854, 309);
            releaseYearFilterTextBox.Name = "releaseYearFilterTextBox";
            releaseYearFilterTextBox.Size = new Size(126, 29);
            releaseYearFilterTextBox.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(854, 211);
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 10;
            label5.Text = "Genre:";
            // 
            // genresFilterTextBox
            // 
            genresFilterTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            genresFilterTextBox.Location = new Point(854, 239);
            genresFilterTextBox.Name = "genresFilterTextBox";
            genresFilterTextBox.Size = new Size(126, 29);
            genresFilterTextBox.TabIndex = 9;
            // 
            // studioLabel
            // 
            studioLabel.AutoSize = true;
            studioLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            studioLabel.Location = new Point(854, 141);
            studioLabel.Name = "studioLabel";
            studioLabel.Size = new Size(69, 25);
            studioLabel.TabIndex = 8;
            studioLabel.Text = "Studio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(854, 35);
            label2.Name = "label2";
            label2.Size = new Size(91, 30);
            label2.TabIndex = 6;
            label2.Text = "Filter by:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(854, 71);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 5;
            label1.Text = "Game name:";
            // 
            // gameNameFilterTextBox
            // 
            gameNameFilterTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            gameNameFilterTextBox.Location = new Point(854, 99);
            gameNameFilterTextBox.Name = "gameNameFilterTextBox";
            gameNameFilterTextBox.Size = new Size(126, 29);
            gameNameFilterTextBox.TabIndex = 4;
            // 
            // gamesListDataGridView
            // 
            gamesListDataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gamesListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gamesListDataGridView.Location = new Point(6, 35);
            gamesListDataGridView.MultiSelect = false;
            gamesListDataGridView.Name = "gamesListDataGridView";
            gamesListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesListDataGridView.Size = new Size(819, 430);
            gamesListDataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1011, 471);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Test";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 523);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            gamesLibraryTab.ResumeLayout(false);
            gamesLibraryTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gamesListDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage gamesLibraryTab;
        private TabPage tabPage2;
        private DataGridView gamesListDataGridView;
        private Button addGameBtn;
        private Button deleteBtn;
        private Button editBtn;
        private Label label1;
        private TextBox gameNameFilterTextBox;
        private Label label2;
        private Label studioLabel;
        private Label releaseYearLabel;
        private TextBox releaseYearFilterTextBox;
        private Label label5;
        private TextBox genresFilterTextBox;
        private ComboBox cbStudio;
        private Button filterBtn;
        private CheckBox multiplayerCheckBox;
    }
}
