using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        public ICollection<Owner> GetOwners();
        public Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnersOfAPokemon(int pokeId);

        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}
