using Almoxarifado.Data.Contexts;
using Almoxarifado.DTO;
using Almoxarifado.Entities;
using Almoxarifado.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almoxarifado.Repository
{
    public class ItemRepository : IItemRepository
    {

        //private static List<Item> _itens = new List<Item>();

        public readonly Context _database;
        public ItemRepository(Context database)
        {
            _database = database;
        }

        public void CreateItem(Item item)
        {
            _database.Add(item);
            _database.SaveChanges();
            //_itens.Add(item);
        }

        public void AddItem(AddItemDTO addItemDTO)
        {
            Item item = GetItem(addItemDTO.Name);

            item.Quantity += addItemDTO.Quantity;
            _database.Update(item);
            _database.SaveChanges();
        }
        public void RemoveItem(RemoveItemDTO removeItemDTO)
        {
            Item item = GetItem(removeItemDTO.Name);

            item.Quantity -= removeItemDTO.Quantity;
            _database.Update(item);
            _database.SaveChanges();
        }
        public List<Item> GetAllItems()
        {
            List<Item> itens = _database.Itens
                .Select(item => item)
                .ToList();

            return itens;
            //return _itens;
        }
        public Item GetItem(string name)
        {
            return _database.Itens.FirstOrDefault(i => i.Name.Contains(name));
            //return _itens.FirstOrDefault(i => i.Name.Contains(name));
        }
    }
}
