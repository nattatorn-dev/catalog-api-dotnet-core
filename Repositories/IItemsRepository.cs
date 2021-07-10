using System;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
  public interface IItemsRepository
  {
    Item GetItem(Guid id);
    Item GetItemByName(string name);
    IEnumerable<Item> GetItems();
  }
}