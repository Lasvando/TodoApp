using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services
{
    public class ItemService : IItemService
    {
        public readonly DataContext _context;
        public ItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<Item> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<List<Item>?> Delete(int id)
        {
            Item? item = await _context.Items.FindAsync(id);
            if (item == null) return null;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> Get(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> Update(Item updatedItem)
        {
            _context.Items.Update(updatedItem);
            await _context.SaveChangesAsync();

            return updatedItem;
        }

        public async Task<Item?> Check(int id)
        {
            var item =  await _context.Items.FindAsync(id);
            if (item == null) return null;

            item.IsActive = !item.IsActive;
            await _context.SaveChangesAsync();

            return item;
        }
    }
}