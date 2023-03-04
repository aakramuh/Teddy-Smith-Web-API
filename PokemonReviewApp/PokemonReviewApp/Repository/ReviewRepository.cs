using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool CreateReview(int pokemonId, int ReviewerId, Review review)
        {
            var pokemon = _context.Pokemon.Where(p => p.Id ==  pokemonId).FirstOrDefault();
            var reviewer = _context.Reviewers.Where(r => r.Id == ReviewerId).FirstOrDefault();

            review.Pokemon = pokemon;
            review.Reviewer = reviewer;

            _context.Add(review);

            return Save();
        }

        public bool Save()
        {
            var saveStatus = _context.SaveChanges();
            return saveStatus > 0 ? true : false;
        }
    }
}
