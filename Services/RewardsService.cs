namespace DWOW.Services;
using DWOW.Models;
using DWOW.Repositories;

public class RewardsService : IRewardsService
{
    private List<Reward> rewards = new List<Reward>
        {
            new Reward { Id = 1, Category = "Electronics", Name = "Smartphone", Description = "Latest model", Points = 500, ImageUrl = "smartphone.jpg", Quantity = 10 },
            new Reward { Id = 2, Category = "Home", Name = "Blender", Description = "High-speed blender", Points = 200, ImageUrl = "blender.jpg", Quantity = 5 },
        };

    public List<Reward> GetRewards(string category, string searchTerm)
    {
        return rewards
            .Where(r => (string.IsNullOrEmpty(category) || r.Category == category) &&
                        (string.IsNullOrEmpty(searchTerm) || r.Name.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    public Reward GetRewardById(int id)
    {
        return rewards.FirstOrDefault(r => r.Id == id);
    }
}
