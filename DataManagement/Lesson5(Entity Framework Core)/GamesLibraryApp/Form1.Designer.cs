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
            editBtn = new Button();
            addGameBtn = new Button();
            deleteBtn = new Button();
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
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // gamesLibraryTab
            // 
            gamesLibraryTab.Controls.Add(editBtn);
            gamesLibraryTab.Controls.Add(addGameBtn);
            gamesLibraryTab.Controls.Add(deleteBtn);
            gamesLibraryTab.Controls.Add(gamesListDataGridView);
            gamesLibraryTab.Location = new Point(4, 24);
            gamesLibraryTab.Name = "gamesLibraryTab";
            gamesLibraryTab.Padding = new Padding(3);
            gamesLibraryTab.Size = new Size(768, 398);
            gamesLibraryTab.TabIndex = 0;
            gamesLibraryTab.Text = "Games library";
            gamesLibraryTab.UseVisualStyleBackColor = true;
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
            // gamesListDataGridView
            // 
            gamesListDataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gamesListDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gamesListDataGridView.Location = new Point(6, 35);
            gamesListDataGridView.Name = "gamesListDataGridView";
            gamesListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesListDataGridView.Size = new Size(756, 357);
            gamesListDataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Test";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            gamesLibraryTab.ResumeLayout(false);
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
    }
}
