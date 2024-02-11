
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;


var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


string connString = config.GetConnectionString("DefaultConnection");


IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

var departments = departmentRepo.GetAllDepartments();

foreach(var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}

var productRepository = new DapperProductRepository(conn);

var ProductToUpdate = productRepository.GetProduct(987);
ProductToUpdate.ProductID = 125;
ProductToUpdate.Name = "UPDATED";
ProductToUpdate.Price = 12.99;
ProductToUpdate.CategoryID = 111;
ProductToUpdate.OnSale = false;
ProductToUpdate.StockLevel = 1000;

productRepository.UpdateProduct(ProductToUpdate);

var products = productRepository.GetAllProducts();

foreach(var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}
 
