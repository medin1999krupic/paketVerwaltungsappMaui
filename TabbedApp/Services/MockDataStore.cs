using SQLite;
using System.Text.Json;
using TabbedApp.Models;

namespace TabbedApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        private SQLiteAsyncConnection _dbConnection;
        public MockDataStore()
        {
            string itemsText = File.ReadAllText(FileSystem.Current.AppDataDirectory + "//Date.json");
            items = JsonSerializer.Deserialize<List<Item>>(itemsText);

            //DateTime baseDate = DateTime.Today;
            //this.items = new List<Item>()
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Titel = "First item", Description="This is an item description.", StartTime = baseDate.AddHours(1), EndTime = baseDate.AddHours(2), Value=17.098 },
            //    new Item { Id = Guid.NewGuid().ToString(), Titel = "Second item", Description="This is an item description.", StartTime = baseDate.AddHours(2), EndTime = baseDate.AddHours(4), Value=9.985 },
            //};

            string ergebniss = JsonSerializer.Serialize(items);
            File.WriteAllText(FileSystem.Current.AppDataDirectory + "//Date.json", ergebniss);

            
        }
        

        //private async void SetUpDb()
        //{
        //    if (_dbConnection == null)
        //    {
        //        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3");
        //        _dbConnection = new SQLiteAsyncConnection(dbPath);
        //        await _dbConnection.CreateTableAsync<Item>();
        //    }
            
        //}

        public async Task<bool> AddItemAsync(Item item)
        {
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            this.items.Remove(oldItem);
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            this.items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(this.items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(this.items);
        }
    }
}