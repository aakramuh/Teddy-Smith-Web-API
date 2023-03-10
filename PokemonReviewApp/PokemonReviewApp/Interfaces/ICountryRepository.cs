using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountries();
        public Country GetCountry(int countryId);
        public Country GetCountryByOwner(int ownerId);
        public ICollection<Owner> GetOwnersFromACountry(int countryId);

        public bool CountryExists(int countryId);

        public bool CreateCountry(Country country);
        public bool Save();

    }
}
