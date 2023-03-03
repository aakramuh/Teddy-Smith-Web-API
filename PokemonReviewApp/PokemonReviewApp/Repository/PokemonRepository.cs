using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context) 
        {
            _context = context;
        }
        public Pokemon GetPokemon(int id)
        {
            if (PokemonExists(id))

                return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
            else
                return null;
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p  => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var reviewCollection = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if(reviewCollection.Count() <=0)
            {
                return 0;
            }

            return (decimal)reviewCollection.Sum(r => r.Rating)/reviewCollection.Count();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }
    }
}
