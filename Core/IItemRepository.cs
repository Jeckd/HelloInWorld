using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloInWorld.Core
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        IEnumerable<Item> GetItems(int id);
        IEnumerable<Item> GetItems(int id, int count);
        int Count();
        bool IsItemExists(int id);
        void Remove(int id);
        Item Create();
    }
}