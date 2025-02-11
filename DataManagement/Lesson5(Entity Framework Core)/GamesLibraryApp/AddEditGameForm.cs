using DomainClassLibrary.Models;

namespace GamesLibraryApp
{
    public partial class AddEditGameForm : Form
    {
        public Game Game { get; private set; }

        public AddEditGameForm(Game? game = null)
        {
            InitializeComponent();

            if (game == null)
            {
                Game = new Game();
                Text = "Add game";
            }
            else
            {
                Game = game;
                titleTextBox.Text = game.Title;
                studioTextBox.Text = game.Studio;
                genreTextBox.Text = game.Genre;
                releaseDatePicker.Value = game.ReleaseDate;
                Text = "Edit gGame";
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) ||
                string.IsNullOrWhiteSpace(studioTextBox.Text) ||
                string.IsNullOrWhiteSpace(genreTextBox.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Game.Title = titleTextBox.Text;
            Game.Studio = studioTextBox.Text;
            Game.Genre = genreTextBox.Text;
            Game.ReleaseDate = releaseDatePicker.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
