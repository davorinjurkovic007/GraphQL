﻿using System.Collections.Generic;
using System.Linq;

namespace Web.GraphQL
{
    public class DataSource
    {
        public IList<Item> Items { get; set; }

        public DataSource()
        {
            Items = new List<Item>()
            {
                new Item() { Tag = "cyberpunk_2077", Title = "Cyberpunk 2077", Price = 59.99M },
                new Item { Tag= "disco_elysium", Title="Disco Elysium", Price= 39.99M },
                new Item { Tag= "diablo", Title="Diablo + Hellfire", Price= 9.99M }
            };
        }

        public Item GetItemByTag(string tag)
        {
            return Items.First(i => i.Tag.Equals(tag));
        }
    }
}
