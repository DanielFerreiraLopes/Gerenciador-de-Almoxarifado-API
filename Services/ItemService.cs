using Almoxarifado.DTO;
using Almoxarifado.Entities;
using Almoxarifado.Interfaces.IRepository;
using Almoxarifado.Interfaces.IService;

namespace Almoxarifado.Services
{
    public class ItemService : IItemService
    {

        private readonly IItemRepository _repository;
        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }
        public void CreateItem(ItemDTO itemDTO)
        {
            try
            {
                Item itemExist = GetItem(itemDTO.Name);

                if (itemExist != null)
                {
                    throw new Exception("Já existe um Item com esse nome.");
                }

                if (itemDTO.Name == null || itemDTO.Name == "")
                {
                    throw new Exception("O nome do Item é obrigatório.");
                }

                if (itemDTO.Quantity < 0)
                {
                    throw new Exception("A quantidade de Itens deve ser maior que zero.");
                }   

                Item item = new Item();
                item.Name = itemDTO.Name;
                item.Description = itemDTO.Description;
                item.Quantity = itemDTO.Quantity;

                _repository.CreateItem(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddItem(AddItemDTO addItemDTO)
        {
            try
            {
                Item item = _repository.GetItem(addItemDTO.Name);

                if (addItemDTO.Quantity <= 0)
                {
                    throw new Exception("Não é possivel Adicionar esse Valor ao Estoque");
                }

                _repository.AddItem(addItemDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RemoveItem(RemoveItemDTO removeItemDTO)
        {
            try
            {
                Item item = _repository.GetItem(removeItemDTO.Name);

                if (removeItemDTO.Quantity > item.Quantity || removeItemDTO.Quantity < 0)
                {
                    throw new Exception("Não é possivel Retirar mais Itens doque á no Estoque");
                }

                _repository.RemoveItem(removeItemDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Item> GetAllItems()
        {
            try
            {
                List<Item> itens = _repository.GetAllItems();
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Item GetItem(string name)
        {
            if (name == null || name == "")
            {
                throw new Exception("Item não Encontrado");
            }

            Item item = _repository.GetItem(name);

            if (item == null)
            {
                return null;
            }

            return item;
        }
    }
}
