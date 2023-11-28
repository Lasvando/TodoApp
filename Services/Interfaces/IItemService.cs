using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface IItemService
    {
        public Task<List<Item>> GetAll();
        public Task<Item?> Get(int id);
        public Task<List<Item>?> Delete(int id);
        public Task<Item> Create(Item item);
        public Task<Item> Update(Item updatedItem);
        public Task<Item?> Check(int id);
    }
}