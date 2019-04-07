using System.Linq;
using A3;

namespace A3Tests
{
    public class TestData
    {
        public static Product idea = new Product("IntelliJ IDEA Ultimate", (float)199.0);
        public static Product reSharper = new Product("ReSharper", (float)149.0);
        public static Product dotTrace = new Product("DotTrace", (float)159.0);
        public static Product dotMemory = new Product("DotMemory", (float)129.0);
        public static Product dotCover = new Product("DotCover", (float)99.0);
        public static Product appCode = new Product("AppCode", (float)99.0);
        public static Product phpStorm = new Product("PhpStorm", (float)99.0);
        public static Product pyCharm = new Product("PyCharm", (float)99.0);
        public static Product rubyMine = new Product("RubyMine", (float)99.0);
        public static Product webStorm = new Product("WebStorm", (float)49.0);
        public static Product teamCity = new Product("TeamCity", (float)299.0);
        public static Product youTrack = new Product("YouTrack", (float)500.0);

        //customers
        public static string lucas = "Lucas";
        public static string cooper = "Cooper";
        public static string nathan = "Nathan";
        public static string reka = "Reka";
        public static string bajram = "Bajram";
        public static string asuka = "Asuka";
        public static string riku = "Riku";

        //cities
        public static City Canberra = new City("Canberra");
        public static City Vancouver = new City("Vancouver");
        public static City Budapest = new City("Budapest");
        public static City Ankara = new City("Ankara");
        public static City Tokyo = new City("Tokyo");

        public static Order[] testOrders = new Order[] {
            new Order((new Product[] { reSharper }).ToList(), true),
            new Order((new Product[] { reSharper, dotMemory, dotTrace }).ToList(), true),
            new Order((new Product[] { rubyMine, webStorm }).ToList(), true),
            new Order((new Product[] { idea }).ToList(), false),
            new Order((new Product[] { idea }).ToList(), false),
            new Order((new Product[] { idea }).ToList(), true),
            new Order((new Product[] { reSharper }).ToList(), true),
            new Order((new Product[] { idea }).ToList(), true),
            new Order((new Product[] { phpStorm, phpStorm }).ToList(), true),
            new Order((new Product[] { phpStorm }).ToList(), true)
        };

        public static Customer[] testCustomers = new Customer[]
        {
            new Customer(lucas, Canberra, (new Order[] {testOrders[0], testOrders[1]}).ToList()),
            new Customer(cooper, Canberra, (new Order[] {}).ToList()),
            new Customer(nathan, Vancouver, (new Order[] {testOrders[2]}).ToList()),
            new Customer(reka, Budapest, (new Order[] {testOrders[3], testOrders[4], testOrders[5]}).ToList()),
            new Customer(bajram, Ankara, (new Order[] {testOrders[6]}).ToList()),
            new Customer(asuka, Tokyo, (new Order[] {testOrders[7]}).ToList()),
            new Customer(riku, Tokyo, (new Order[] {testOrders[8], testOrders[9]}).ToList())

        };

        public static Shop testShop = new Shop("test-shop", testCustomers.ToList());
    }
}
