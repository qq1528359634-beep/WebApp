
namespace WebApp.Models.Repositories
{
    public static class ShirtsRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{ShirtId=1,Brand="MyBand",Color="Blue",Gender="Men",Price=30,Size=10},
            new Shirt{ShirtId=2,Brand="MyBand",Color="Yellow",Gender="Men",Price=25,Size=11},
            new Shirt{ShirtId=3,Brand="YourBand",Color="White",Gender="Women",Price=35,Size=6},
            new Shirt{ShirtId=4,Brand="YourBand",Color="Black",Gender="Women",Price=25,Size=9},
        };
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }
        public static Shirt GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {   //通过各属性匹配衬衫是否已经存在 若存在则返回衬衫
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&//传入brand是否匹配到相等的，衬衫集合中的brand
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
             !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue && x.Size.HasValue && size.Value.Equals(x.Size));
        }
        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);//获取当前衬衫的最大id
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);

        }
        public static void UpdateShirt(Shirt shirt)
        {  //这里取的updateShirt是指向list中对象的引用地址
            var updateShirt = shirts.First(x => x.ShirtId == shirt.ShirtId);
            updateShirt.Price = shirt.Price;
            updateShirt.Brand = shirt.Brand;
            updateShirt.Gender = shirt.Gender;
            updateShirt.Color = shirt.Color;
            updateShirt.Size = shirt.Size;
        }
        public static void DeleteShirt(int shirtId)
        {   
           var shirt=GetShirtById(shirtId);
            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
           
        }
    }
}
