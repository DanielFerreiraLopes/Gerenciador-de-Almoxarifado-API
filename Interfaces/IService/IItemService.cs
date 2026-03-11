using Almoxarifado.DTO;
using Almoxarifado.Entities;

namespace Almoxarifado.Interfaces.IService
{
    public interface IItemService
    {
        public void CreateItem(ItemDTO itemDTO);
        public void AddItem(AddItemDTO addItemDTO);
        public void RemoveItem(RemoveItemDTO removeItemDTO);
        public List<Item> GetAllItems();
        public Item GetItem(string name);
    }
}
