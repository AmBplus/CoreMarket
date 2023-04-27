using System.Text.Json;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controller;
[Route("[controller]/[action]")]
public class Test1 : ControllerBase
{
   // [BindProperty]
   // public DataTables.DataTablesRequest DataTablesRequest { get; set; }
    // GET
    [HttpPost]
    public async Task<IActionResult> Index([FromForm] RequestGetCustomers request)
        {
        try
        {
            var fomr = Request.Form;
            var draw = Request.Form["draw"].FirstOrDefault();
            var age = Request.Form["Age"].FirstOrDefault();
            var email = Request.Form["Email"].FirstOrDefault();
            var lastName = Request.Form["LastName"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() +
                                          "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var customerData = mockData.MockList.AsQueryable();
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                customerData = customerData.OrderBy(x=> sortColumn + " " + sortColumnDirection);
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m => m.FirstName.Contains(searchValue)
                                    || m.LastName.Contains(searchValue)
                                    || m.Contact.Contains(searchValue)
                                    || m.Email.Contains(searchValue));
            }

            if (request.order.FirstOrDefault() is Order order)
            {
                var result = request.columns[order.column];
                var pro=  typeof(Customer).GetProperty(result.name);
                customerData = customerData.OrderBy(x=> x.Age);
            }
            recordsTotal = customerData.Count();
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new DataTablesResponse<List<Customer>>()
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            };
            return Ok(jsonData);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
public static class mockData{

    public static List<Customer> GetList()
    {
        List<Customer> list = new List<Customer>();
        for (int i = 0; i < 100; i++)
        {
            list.Add(new Customer()
            {
                Contact = $"Contact_{i}",
                DateOfBirth = DateTime.Now,
                Email =  $"Email_{i}",
                FirstName = $"FirstName_{i}",
                LastName = $"LastName_{i}",
                Id = i,
                Age = new Random().Next(0,100),
                Checked = Convert.ToBoolean(i%10)
            });
        }

        return list;
    }

    public static List<Customer> MockList = new List<Customer>(GetList());
}
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool Checked { get; set; }
    public DateTime DateOfBirth { get; set; }
}
public class RequestGetCustomers : DataTablesRequest
{
    public string age { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
}
public class DataTablesRequest
{
    public int draw { get; set; }

    public List<Column> columns { get; set; }

    public List<Order> order { get; set; }

    public int start { get; set; }
    public int  skip { get => start; }

    public int length { get; set; }
    public int pageSize { get => length; }  

    public Search search { get; set; }
    
}
public class DataTablesResponse<T>
{
    public string draw { get; set; }

    public int recordsFiltered { get; set; }

    public int recordsTotal
    {
        get;
        set;
    }

    public T data { get; set; }
}


public class Column
{
    public string data { get; set; }

    public string name { get; set; }

    public bool searchable { get; set; }

    public bool orderable { get; set; }

    public Search search { get; set; }
}

public class Order
{
    public int column { get; set; }

    public string dir { get; set; }
}

public class Search
{
    public string value { get; set; }

    public bool isRegex { get; set; }
}