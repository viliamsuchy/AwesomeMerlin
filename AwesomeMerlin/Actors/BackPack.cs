using AwesomeMerlin.Actors.Items;
using Merlin2d.Game.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class Backpack : IInventory
    {
        private int capacity;
        private IItem[] Item;

        public Backpack(int capacity)
        {
            Item = new IItem[capacity];
            this.capacity = capacity;
        }

        public void AddItem(IItem item)
        {
            for(int i=0; i <= capacity; i++)
            {
                Item[i] = item;
                if(i == capacity)
                {
                    throw new FullInventoryException("Inventory is full yet, do not try to add something more!");
                }
            }
            
        }

        public int GetCapacity()
        {
            return 5;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IItem GetItem()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int index)
        {
            Item[index] = null;
        }

        public void ShiftLeft()
        {
            throw new NotImplementedException();
        }

        public void ShiftRight()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
