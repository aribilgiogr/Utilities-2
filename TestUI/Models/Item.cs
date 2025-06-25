namespace TestUI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Item> GetDemoData()
        {
            var items = new List<Item>();

            for (int i = 1; i <= 20; i++)
            {
                items.Add(new Item { Id = i, Name = $"Item {i}" });
            }

            return items;
        }
    }
}
