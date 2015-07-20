/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Model
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ItemsManager
    {
        private readonly ICollection<Item> _items;

        public ItemsManager()
        {
            _items = new List<Item>();
            _items.Add(new Item { Code = "1234"});
            _items.Add(new Item { Code = "3456" });
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {

        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public IEnumerable<Item> GetByCreated(string dateStr)
        {
            return _items.Where(i => i.Created.ToShortDateString().Equals(dateStr)).ToList();
        }
    }
}
