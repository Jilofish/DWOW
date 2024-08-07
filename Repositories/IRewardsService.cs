using DWOW.Models;

namespace DWOW.Repositories;

public interface IRewardsService
{
    Reward GetRewardById(int id);
    List<Reward> GetRewards(string category, string searchTerm);
}