/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Model
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ItemsManager
    {
        //private readonly ICollection<Item> _items;
        private readonly DataContext _dataContext;
        private readonly DbSet<Item> _items;

        public ItemsManager()
        {
            //_items = new List<Item>();
            _dataContext = new DataContext();
            _items = _dataContext.Items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            _dataContext.SaveChanges();
        }

        public void AddItemCodes(params string[] codes)
        {
            Item item = null;

            foreach (var code in codes)
            {
                item = new Item { Code = code };
                _items.Add(item);
            }

            _dataContext.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _dataContext.Entry<Item>(item).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public IEnumerable<Item> GetByCreated(DateTime date)
        {
            return _items.Where(i => i.Created.Day == date.Day &&
            i.Created.Month == date.Month &&
            i.Created.Year == date.Year).ToList();
        }
    }
}
