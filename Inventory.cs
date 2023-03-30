using System.Collections.Generic;

namespace TestTask
{
    public class Inventory 
    {
        public int ItemsCount => _listItems.Count;

        private List<IItem> _listItems;

        public Inventory()
        {
            _listItems = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            _listItems.Add(item);
        }
        public void RemoveItem(IItem item)
        {
            _listItems.Remove(item);
        }

        public void RemoveItem(int index)
        {
            _listItems.RemoveAt(index);
        }

        public IItem TakeItem(int index)
        {
            return _listItems[index];
        }

    }

}
