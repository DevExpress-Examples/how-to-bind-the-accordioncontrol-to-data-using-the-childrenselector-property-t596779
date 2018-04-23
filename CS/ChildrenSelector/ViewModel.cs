using DevExpress.Xpf.Accordion;
using System.Collections;
using System.Collections.Generic;

namespace ChildrenSelector {

    public class ViewModel {
        public Data MyData { get; set; }
        public object SelectedItem { get; set; }
        public ViewModel() {
            MyData = new Data();
        }
    }
    public class Data {
        public List<Category> Categories { get; set; }
        public Data() {
            Categories = new List<Category>();
            List<Item> subitems = new List<Item>();
            subitems.Add(new Item() { ItemName = "Chair", Description = "A red chair." });
            subitems.Add(new Item() { ItemName = "Table", Description = "An old table." });
            Categories.Add(new Category() { CategoryName = "Furniture", Items = subitems });
            List<Item> books = new List<Item>();
            books.Add(new Item() { ItemName = "Dictionary", Description = "My old French-English Dictionary" });
            Categories.Add(new Category() { CategoryName = "Books", Items = books });
        }
    }
    public class Category {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Item {
        public string ItemName { get; set; }
        public string Description { get; set; }
    }

    public class MySelector : IChildrenSelector {
        public IEnumerable SelectChildren(object item) {
            if (item is Category) {
                return ((Category)item).Items;
            } else return null;
        }
    }
}
