using DWOW.Models;
using SQLite;
using System.Linq.Expressions;

namespace AppManager.Maui.Utility;

public class SqliteDB
{
    private SQLiteAsyncConnection db { get; set; }
    public async Task Init(string dbPath)
    {
        try
        {
            db = new SQLiteAsyncConnection(dbPath);
            await InitTables();
            await SeedTestData();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task InitTables()
    {
        await db.DropTableAsync<Reward>();
        await db.CreateTableAsync<Reward>();
        //await db.CreateTableAsync<SQliteClassParent>();
    }

    async Task SeedTestData()
    {
        await SeedTestRewardData(10);
    }

    async Task SeedTestRewardData(int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            Reward candy = new()
            {
                Name = $"Food {i + 1}",
                Category = "Food",
                Description = "Nom nom",
                Points = 10 * i,
                Quantity = 1 * i,
                ImageUrl = "https://img.freepik.com/premium-vector/cute-burger-cartoon-icon-illustration-food-icon-concept-isolated-flat-cartoon-style_138676-1437.jpg"
            };
            Reward rew = await GetByConditionAsync<Reward>(x => x.Name == candy.Name);
            if(rew is null) await db.InsertAsync(candy);
        }
    }

    public Task<int> DropTable<T>() where T : class, new()
    {
        return db.DropTableAsync<T>();
    }
    public Task<CreateTableResult> CreateTable<T>() where T : class, new()
    {
        return db.CreateTableAsync<T>();
    }
    public Task<List<T>> GetAllAsync<T>() where T : class, new()
    {
        return db.Table<T>().ToListAsync();
    }
    //public Task<T> GetByIdAsync<T>(int id) where T : class, new()
    //{
    //    return db.Table<T>().FirstOrDefaultAsync(x => (int)typeof(T).GetProperty("Id").GetValue(x) == id);
    //}
    public Task<List<T>> GetByConditionAsyncList<T>(Expression<Func<T, bool>> condition) where T : class, new()
    {
        return db.Table<T>().Where(condition).ToListAsync();
    }
    public Task<T> GetByConditionAsync<T>(Expression<Func<T, bool>> condition) where T : class, new()
    {
        return db.Table<T>().Where(condition).FirstOrDefaultAsync();
    }
    public async Task<int> InsertAsync<T>(T item) where T : class, new()
    {
        var result = 0;
        await db.RunInTransactionAsync((x) => result = x.Insert(item));
        return result;
    }
    public async Task<int> InsertAllAsync<T>(IEnumerable<T> item) where T : class, new()
    {
        var result = 0;
        await db.RunInTransactionAsync((x) => result = x.InsertAll(item));
        return result;
    }
    public async Task<int> UpdateAllAsync<T>(IEnumerable<T> item)
    {
        var result = 0;
        await db.RunInTransactionAsync((x) => result = x.UpdateAll(item));
        return result;
    }
    public async Task<int> UpdateAsync<T>(T item)
    {
        var result = 0;
        await db.RunInTransactionAsync((x) => result = x.Update(item));
        return result;
    }
    public Task<int> DeleteAsync<T>(T item)
    {
        return db.DeleteAsync(item);
    }
    public Task<int> DeleteAllAsync<T>()
    {
        return db.DeleteAllAsync<T>();
    }
    public Task<int> UpsertAsync<T>(T item)
    {
        if (typeof(T).GetProperty("Id")?.GetValue(item) is int id && id != 0)
        {
            return db.UpdateAsync(item);
        }
        else
        {
            return db.InsertAsync(item);
        }
    }
}
