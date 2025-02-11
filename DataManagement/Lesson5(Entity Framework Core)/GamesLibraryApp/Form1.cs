using DataClassLibrary.Data;

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
        }

        private void LoadGames()
        {
            gamesListDataGridView.DataSource = _context.Games.ToList();
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
            var game = _context.Games.Find(gameId);

            if (game == null)
            {
                MessageBox.Show("Game not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete \"{game.Title}\"?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                LoadGames();
            }
        }
    }
}
