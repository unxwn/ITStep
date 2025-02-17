using DataClassLibrary.Data;
using DomainClassLibrary.Models;

namespace GamesLibraryApp
{
    public partial class AddEditGameForm : Form
    {
        public Game Game { get; private set; }

        public AddEditGameForm(Game? game = null)
        {
            InitializeComponent();
            LoadStudios();

            if (game == null)
            {
                Game = new Game();
                Text = "Add game";
            }
            else
            {
                Game = game;
                titleTextBox.Text = game.Name;
                studioComboBox.SelectedValue = game.StudioId;
                genreTextBox.Text = string.Join(", ", game.Genre);
                releaseYearTextBox.Text = game.ReleaseYear.ToString();
                multiplayerCheckBox.Checked = game.Multiplayer;
                Text = "Edit game";
            }
        }

        private void LoadStudios()
        {
            using (GamesLibraryContext context = new GamesLibraryContext())
            {
                var studios = context.Studios.ToList();
                studios.Insert(0, new Studio { Id = 0, Name = "Select studio" });
                studioComboBox.DataSource = studios;
                studioComboBox.DisplayMember = nameof(Studio.Name);
                studioComboBox.ValueMember = nameof(Studio.Id);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) ||
                studioComboBox.SelectedValue == null ||
                studioComboBox.SelectedIndex == 0 ||
                string.IsNullOrWhiteSpace(genreTextBox.Text) ||
                string.IsNullOrWhiteSpace(releaseYearTextBox.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Game.Name = titleTextBox.Text;
            Game.StudioId = (int)studioComboBox.SelectedValue;
            Game.Genre = genreTextBox.Text.Split(',').Select(g => g.Trim()).ToArray();
            Game.Multiplayer = multiplayerCheckBox.Checked;

            if (int.TryParse(releaseYearTextBox.Text, out int releaseYear))
            {
                Game.ReleaseYear = releaseYear;
            }
            else
            {
                MessageBox.Show("Invalid release year format.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
