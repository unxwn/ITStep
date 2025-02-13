using DataClassLibrary.Data;
using DomainClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryApp
{
    public partial class Form1 : Form
    {
        private GamesLibraryContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new GamesLibraryContext();
            LoadGames();
            LoadStudios();
        }

        private void LoadGames()
        {
            gamesListDataGridView.DataSource = _context.Games
                .Include(g => g.Studio)
                .Select(g => new
                {
                    g.Id,
                    g.Name,
                    Studio = g.Studio != null ? g.Studio.Name : "Unknown",
                    Genres = string.Join(", ", g.Genre),
                    g.ReleaseYear,
                    Multiplayer = g.Multiplayer ? "Yes" : "No"
                })
                .ToList();
        }

        private async void LoadStudios()
        {
            await _context.Studios.LoadAsync();
            var studios = _context.Studios.Local.ToList();
            studios.Insert(0, new Studio { Id = 0, Name = "All" });
            cbStudio.DataSource = studios;
            cbStudio.DisplayMember = nameof(Studio.Name);
            cbStudio.ValueMember = nameof(Studio.Id);
        }

        private void addGameBtn_Click(object sender, EventArgs e)
        {
            AddEditGameForm addEditForm = new AddEditGameForm();
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                _context.Games.Add(addEditForm.Game);
                _context.SaveChanges();
                LoadGames();
            }
        }

        private void editGameBtn_Click(object sender, EventArgs e)
        {
            if (gamesListDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a game to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gameId = Convert.ToInt32(gamesListDataGridView.SelectedRows[0].Cells["Id"].Value);
            var game = _context.Games.Find(gameId);

            if (game == null)
            {
                MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddEditGameForm addEditForm = new AddEditGameForm(game);
            if (addEditForm.ShowDialog() == DialogResult.OK)
            {
                _context.SaveChanges();
                LoadGames();
            }
        }

        private void deleteGameBtn_Click(object sender, EventArgs e)
        {
            if (gamesListDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a game to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gameId = Convert.ToInt32(gamesListDataGridView.SelectedRows[0].Cells["Id"].Value);
            Game? game = _context.Games.Find(gameId);

            if (game == null)
            {
                MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete \"{game.Name}\"?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                LoadGames();
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            var gamesQuery = _context.Games.Include(g => g.Studio).AsQueryable();

            if (!string.IsNullOrEmpty(gameNameFilterTextBox.Text))
                gamesQuery = gamesQuery.Where(g => g.Name.Contains(gameNameFilterTextBox.Text));

            if (cbStudio.SelectedIndex > 0 && cbStudio.SelectedValue is int selectedStudioId)
                gamesQuery = gamesQuery.Where(g => g.StudioId == selectedStudioId);

            if (!string.IsNullOrEmpty(genresFilterTextBox.Text))
                gamesQuery = gamesQuery.Where(g => g.Genre.Contains(genresFilterTextBox.Text));

            if (int.TryParse(releaseYearFilterTextBox.Text, out int year))
                gamesQuery = gamesQuery.Where(g => g.ReleaseYear == year);

            if (multiplayerCheckBox.Checked)
                gamesQuery = gamesQuery.Where(g => g.Multiplayer);

            gamesListDataGridView.DataSource = gamesQuery
                .Select(g => new
                {
                    g.Id,
                    g.Name,
                    Studio = g.Studio != null ? g.Studio.Name : "Unknown",
                    Genres = string.Join(", ", g.Genre),
                    g.ReleaseYear,
                    Multiplayer = g.Multiplayer ? "Yes" : "No"
                })
                .ToList();
        }
    }
}
