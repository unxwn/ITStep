using FilmLibrary.Models;
using FilmLibrary.Services.Abstraction;

namespace FilmLibrary.Services.Implementation
{
    public class FilmRepository : IFilmRepository
    {
        private static List<Film> _films = new List<Film>
        {
            new Film
            {
                Title = "Забійні Канікули",
                Director = "Елі Крейг",
                Genre = "Комедія, хоррор",
                Description = "Комедійний фільм в жанрі хоррор-пародії."
            },
            new Film
            {
                Title = "Острів проклятих",
                Director = "Мартін Скорсезе",
                Genre = "Трилер",
                Description = "Психологічний трилер про детектива Тедді Деніела, який разом з партнером вирушає на ізольований острів, де знаходиться психіатрична лікарня для злочинців."
            }
        };

        public IEnumerable<Film> GetAll()
        {
            return _films;
        }

        public void Add(Film film)
        {
            _films.Add(film);
        }
    }
}
