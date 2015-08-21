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
        private readonly DataContext _dataContext;
        private readonly DbSet<Item> _items;

        public ItemsManager()
        {
            _dataContext = new DataContext();
            _items = _dataContext.Items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            _dataContext.SaveChanges();
        }

        public void ImportCode(string code, int recNo)
        {
            if (!_items.Any(i => i.Code.Equals(code)))
                _items.Add(new Item { Code = code, RecNo = recNo});
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
            //_dataContext.Entry<Item>(item).State = EntityState.Modified;
            if (_dataContext.ChangeTracker.HasChanges())
            _dataContext.SaveChanges();
        }

        public void UpdateAll()
        {
            if (_dataContext.ChangeTracker.HasChanges())
                _dataContext.SaveChanges();
        }

        public void DeleteItem(Item item)
        {
            _items.Remove(item);
            _dataContext.SaveChanges();
        }

        public void DeletePrinted()
        {
            var itemsPrinted = _items.Where(i => i.Printed).AsEnumerable();
            _items.RemoveRange(itemsPrinted);
            _dataContext.SaveChanges();
            _dataContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "VACUUM;");
        }

        public void DeleteAllItems()
        {
            _items.RemoveRange(_items.AsEnumerable());
            _dataContext.SaveChanges();
            _dataContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "VACUUM;");
        }

        public IEnumerable<Item> GetAll()
        {
            return _items.ToList();
        }

        public IEnumerable<Item> GetByCreated(DateTime date)
        {
            return _items.Where(i => i.Created.Day == date.Day &&
            i.Created.Month == date.Month &&
            i.Created.Year == date.Year).ToList();
        }

        public IQueryable<Item> Get()
        {
            return _items;
        }
    }
}
