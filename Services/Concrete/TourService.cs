using BetFor.Entities;
using BetFor.Repositories;

namespace BetFor.Services
{
    public class TourService : ITourService
    {
        private readonly IBaseRepository<Tour> tourRepository;
        private readonly IBaseRepository<Client> clientRepository;
        public TourService(IBaseRepository<Tour> tourRepository, IBaseRepository<Client> clientRepository)
        {
            this.tourRepository = tourRepository;
            this.clientRepository = clientRepository;
        }

        public async Task<bool> TryCreateTourAsync(Tour request)
        {
            return await tourRepository.TryInsertItemAsync(request);
        }

        public async Task<bool> TryUpdateTourAsync(Tour request)
        {
            return await tourRepository.TryUpdateItemAsync(request);
        }

        public async Task<Tour> GetLastFinishedTourAsync(Tour request)
        {
            return (await tourRepository.GetFilteredItemsAsync(x => x.TourStartTime < DateTime.Now)).OrderByDescending(x => x.TourEndTime).First();
        }
    }
}