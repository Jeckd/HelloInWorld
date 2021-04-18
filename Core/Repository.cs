using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloInWorld.Core
{
    public class Repository:IItemRepository
    {
        private List<Item> itemList =  new List<Item>();

        public Repository()
        {
            itemList.Add(
                new Item()
                {
                    id = 10001,
                    Header = "SB Audigy Fx sometimes has no sound when the computer starts up",
                    Content = "Hello everyone! My SB Audigy Fx sometimes has no sound when the computer starts up, although the card is recognized correctly. At this point, the settings have been changed from Analog Spatial 4.1 + Analog Stereo Input to Analog Stereo Duplex. After I change them and restart the computer, everything starts working normally. What are your tips? Thanks in advance!"

                }
            ); 

            itemList.Add(
                new Item()
                {
                    id = 10002,
                    Header = "SB Audigy Fx sometimes has no sound when the computer starts up",
                    Content = "Hello everyone! My SB Audigy Fx sometimes has no sound when the computer starts up, although the card is recognized correctly. At this point, the settings have been changed from Analog Spatial 4.1 + Analog Stereo Input to Analog Stereo Duplex. After I change them and restart the computer, everything starts working normally. What are your tips? Thanks in advance!"

                }
            ); 

            itemList.Add(
                new Item()
                {
                    id = 10003,
                    Header = "SB Audigy Fx sometimes has no sound when the computer starts up",
                    Content = "Hello everyone! My SB Audigy Fx sometimes has no sound when the computer starts up, although the card is recognized correctly. At this point, the settings have been changed from Analog Spatial 4.1 + Analog Stereo Input to Analog Stereo Duplex. After I change them and restart the computer, everything starts working normally. What are your tips? Thanks in advance!"

                }
            ); 

            itemList.Add(
                new Item()
                {
                    id = 10004,
                    Header = "SB Audigy Fx sometimes has no sound when the computer starts up",
                    Content = "Hello everyone! My SB Audigy Fx sometimes has no sound when the computer starts up, although the card is recognized correctly. At this point, the settings have been changed from Analog Spatial 4.1 + Analog Stereo Input to Analog Stereo Duplex. After I change them and restart the computer, everything starts working normally. What are your tips? Thanks in advance!"

                }
            ); 
        }

        public IEnumerable<Item> GetItems() => itemList;

        public IEnumerable<Item> GetItems(int id) => itemList.FindAll((item)=>item.id==id);
        
        public IEnumerable<Item> GetItems(int id, int count) => throw new NotImplementedException();
        public int Count()=>itemList.Count;
        public Item Create()
        {
            var item = new Item();
            item.id = GetNewId();
            itemList.Add(item);
            return item;
        }
        public void Remove(int id)=>itemList.Remove(itemList.Find((item)=>item.id==id));
        public bool IsItemExists(int id) => itemList.Exists((item)=>item.id==id);

        private int GetMaxId()=>itemList.Max<Item>((item)=>item.id);

        private int GetDefaultId()=>10001;
        private int GetNewId() =>itemList.Count>0?GetMaxId()+1:GetDefaultId();

    }
}