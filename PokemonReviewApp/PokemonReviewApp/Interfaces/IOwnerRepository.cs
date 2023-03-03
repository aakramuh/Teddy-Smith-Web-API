using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        public ICollection<Owner> GetOwners();
        public Owner GetOwner(int ownerId);
        public ICollection<Owner> GetOwnersOfAPokemon(int pokeId);

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        public bool OwnerExists(int ownerId);

        public bool CreateOwner(Owner owner);
        public bool Save();
    }
}
