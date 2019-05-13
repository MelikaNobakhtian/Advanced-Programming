using System.Collections.Generic;

namespace digikala
{
    public class ItemInventory
    {
        public List<Item> Items = new List<Item>();
       
       public List<Item> Filter(List<IFilter> filters)
        {
            bool filteritem = true;
            List<Item> result = new List<Item>();
            foreach(Item item in Items)
            {
                foreach(var f in filters)
                    if (!f.Filter(item))
                    {
                        filteritem = false;
                        break;
                    }
                if (filteritem == true)
                    result.Add(item);
                filteritem = true;
            }

            return result;
        }
        public Item GetItemById(int id)
        {
            foreach (Item item in Items)
                if (item.Id == id)
                    return item;
            return null;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            
        }

        public bool RemoveItem(Item item)
        {
            return Items.Remove(item);
        }
      
    }
}