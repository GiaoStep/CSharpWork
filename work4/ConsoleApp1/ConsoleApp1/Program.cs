using System.Text;

//订单类
class Order
{
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetails> Details { get; set; }
    public double TotalAmount
    {
        get
        {
            return Details.Sum(d => d.Amount);
        }
    }

    public Order(string orderId, Customer customer)
    {
        OrderId = orderId;
        Customer = customer;
        Details = new List<OrderDetails>();
    }

    public override bool Equals(object obj)
    {
        Order order = obj as Order;
        return order != null && OrderId == order.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("订单号：{0}\n", OrderId);
        sb.AppendFormat("客户：{0}\n", Customer);
        sb.AppendLine("订单明细：");
        foreach (OrderDetails detail in Details)
        {
            sb.AppendLine(detail.ToString());
        }
        sb.AppendFormat("订单总金额：{0}\n", TotalAmount);
        return sb.ToString();
    }
}


//订单明细类
class OrderDetails
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public double Amount
    {
        get
        {
            return Price * Quantity;
        }
    }

    public OrderDetails(string productName, double price, int quantity)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }

    public override bool Equals(object obj)
    {
        OrderDetails details = obj as OrderDetails;
        return details != null && ProductName == details.ProductName;
    }

    public override int GetHashCode()
    {
        return ProductName.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("商品名称：{0}，单价：{1}，数量：{2}，金额：{3}", ProductName, Price, Quantity, Amount);
    }
}

//客户类
class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}


//订单服务类
class OrderService
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new ApplicationException($"添加订单错误：订单{order.OrderId}已经存在！");
        }
        orders.Add(order);
    }

    public void RemoveOrder(string orderId)
    {
        Order order = GetOrderById(orderId);
        if (order == null)
        {
            throw new ApplicationException($"删除订单错误：订单{orderId}不存在！");
        }
        orders.Remove(order);
    }

    public void UpdateOrder(Order newOrder)
    {
        Order oldOrder = GetOrderById(newOrder.OrderId);
        if (oldOrder == null)
        {
            throw new ApplicationException($"修改订单错误：订单{newOrder.OrderId}不存在！");
        }
        orders.Remove(oldOrder);
        orders.Add(newOrder);
    }

    public Order GetOrderById(string orderId)
    {
        return orders.FirstOrDefault(o => o.OrderId == orderId);
    }

    public List<Order> QueryOrdersByCustomer(string customerName)
    {
        return orders.Where(o => o.Customer.Name == customerName).OrderBy(o => o.TotalAmount).ToList();
    }

    public List<Order> QueryOrdersByProductName(string productName)
    {
        return orders.Where(o => o.Details.Any(d => d.ProductName == productName)).OrderBy(o => o.TotalAmount).ToList();
    }

    public List<Order> QueryOrdersByAmount(double amount)
    {
        return orders.Where(o => o.TotalAmount == amount).OrderBy(o => o.TotalAmount).ToList();
    }

    public void Sort(Comparison<Order> comparison)
    {
        orders.Sort(comparison);
    }

    public void Sort()
    {
        orders.Sort();
    }

    public List<Order> Orders
    {
        get
        {
            return orders;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("张三");
        Customer customer2 = new Customer("李四");
        Customer customer3 = new Customer("王五");

        OrderDetails details1 = new OrderDetails("商品1", 10, 100);
        OrderDetails details2 = new OrderDetails("商品2", 20, 200);
        OrderDetails details3 = new OrderDetails("商品3", 30, 300);
        OrderDetails details4 = new OrderDetails("商品4", 40, 400);
        OrderDetails details5 = new OrderDetails("商品5", 50, 500);

        Order order1 = new Order("001", customer1);
        order1.Details.Add(details1);
        order1.Details.Add(details2);
        Order order2 = new Order("002", customer2);
        order2.Details.Add(details3);
        order2.Details.Add(details4);
        Order order3 = new Order("003", customer3);
        order3.Details.Add(details5);

        OrderService service = new OrderService();
        service.AddOrder(order1);
        service.AddOrder(order2);
        service.AddOrder(order3);

        Console.WriteLine("查询所有订单：");
        List<Order> orders = service.Orders;
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("查询客户为张三的订单：");
        orders = service.QueryOrdersByCustomer("张三");
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("查询商品名称为商品1的订单：");
        orders = service.QueryOrdersByProductName("商品1");
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("查询订单金额为3000的订单：");
        orders = service.QueryOrdersByAmount(3000);
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("按照订单总金额排序：");
        service.Sort((o1, o2) => o1.TotalAmount.CompareTo(o2.TotalAmount));
        orders = service.Orders;
        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.ReadLine();
    }
}