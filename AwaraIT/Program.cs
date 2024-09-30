using AwaraIT.Repositories.Implementations;
using AwaraIT.Services.Implementations;
using AwaraIT;

var productRepository = new ProductRepository();
var stockRepository = new StockRepository();
var orderHistoryRepository = new OrderHistoryRepository();

var productService = new ProductService(productRepository);
var stockService = new StockService(stockRepository);
var cartService = new CartService();

productRepository.LoadProductsFromFile("products.json");
stockRepository.LoadStocksFromFile("stock.json");
orderHistoryRepository.LoadOrderHistoryFromFile("orderHistory.json");

Console.WriteLine("Выберите режим работы: 1 - Клиент, 2 - Админ");
var mode = Console.ReadLine();

if (mode == "1")
{
    var clientMenu = new ClientMenu(productService, cartService, stockService, orderHistoryRepository);
    clientMenu.DisplayMenu();
}
else if (mode == "2")
{
    var adminPanel = new AdminPanel(productService, stockService);
    adminPanel.DisplayAdminMenu();
}
else
{
    Console.WriteLine("Неверный ввод. Программа завершена.");
}
