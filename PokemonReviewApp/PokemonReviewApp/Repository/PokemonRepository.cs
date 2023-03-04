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

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();

            var categoryEntity = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = categoryEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);
            return Save();
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

        public bool Save()
        {
            var saveStatus = _context.SaveChanges();
            return saveStatus > 0 ? true : false;
        }
    }
}
