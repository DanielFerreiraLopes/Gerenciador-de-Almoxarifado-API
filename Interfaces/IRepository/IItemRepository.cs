using Almoxarifado.DTO;
using Almoxarifado.Entities;

namespace Almoxarifado.Interfaces.IRepository
{
    public interface IItemRepository
    {
        public void CreateItem(Item item);
        public void AddItem(AddItemDTO addItemDTO);
        public void RemoveItem(RemoveItemDTO removeItemDTO);
        public List<Item> GetAllItems();
        public Item GetItem(string name);
    }
}
