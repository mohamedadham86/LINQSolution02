using LINQ.DataSources;
using LINQ.Models;
using System.Net.Http.Headers;
using static LINQ.DataSources.Source;
namespace LINQ
{
	internal class Program
	{
		
		static void Main()
		{
			var Products = Source.ProductList;
			var Customers = Source.CustomerList;

			// 1. 
			Console.WriteLine("Question 1:");
			var result1 = Products
				.OrderByDescending(p => p.UnitPrice)
				.Take(3);

			foreach (var p in result1)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");


			// 2. 
			Console.WriteLine("\nQuestion 2:");
			var result2 = Products
				.Skip(5)
				.Take(5);

			foreach (var p in result2)
				Console.WriteLine(p.ProductName);


			// 3. 
			Console.WriteLine("\nQuestion 3:");
			var result3 = Products
				.OrderBy(p => p.UnitPrice)
				.TakeWhile(p => p.UnitPrice < 25);

			foreach (var p in result3)
				Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");


			// 4. 
			Console.WriteLine("\nQuestion 4:");
			bool result4 = Products
				.Where(p => p.Category == "Seafood")
				.All(p => p.UnitsInStock > 0);

			Console.WriteLine(result4);


			// 5. 
			Console.WriteLine("\nQuestion 5:");
			int[] ids = { 3, 9, 13, 18 };

			bool result5 = ids.Contains(9);
			Console.WriteLine(result5);


			// 6. 
			Console.WriteLine("\nQuestion 6:");
			var result6 = Products.GroupBy(p => p.Category);

			foreach (var group in result6)
				Console.WriteLine($"{group.Key}: {group.Count()} products");


			// 7. 
			Console.WriteLine("\nQuestion 7:");
			var result7 = Products
				.GroupBy(p => p.Category)
				.Select(g => new
				{
					Category = g.Key,
					ProductNames = g.Select(p => p.ProductName)
				});

			foreach (var group in result7)
			{
				Console.WriteLine(group.Category);

				foreach (var name in group.ProductNames)
					Console.WriteLine(name);
			}


			// 8. 
			Console.WriteLine("\nQuestion 8:");
			var result8 = Products
				.GroupBy(p => p.Category)
				.Where(g => g.Count() > 3)
				.Select(g => g.Key);

			foreach (var category in result8)
				Console.WriteLine(category);


			// 9. 
			Console.WriteLine("\nQuestion 9:");
			var result9 =
				from c in Customers
				group c by c.Country into countryGroup
				select new
				{
					Country = countryGroup.Key,
					Count = countryGroup.Count(),
					TotalOrderValue = countryGroup
						.SelectMany(c => c.Orders)
						.Sum(o => o.Total)
				};

			foreach (var item in result9)
				Console.WriteLine(
					$"{item.Country} - {item.Count} - {item.TotalOrderValue}");


			// 10. 
			Console.WriteLine("\nQuestion 10:");
			int result10 = Products.Sum(p => p.UnitsInStock);
			Console.WriteLine(result10);


			// 11. 
			Console.WriteLine("\nQuestion 11:");
			var cheapest = Products.Min(p => p.UnitPrice);
			var expensive = Products.Max(p => p.UnitPrice);

			Console.WriteLine($"Cheapest Price: {cheapest}");
			Console.WriteLine($"Most Expensive Price: {expensive}");


			// 12.
			Console.WriteLine("\nQuestion 12:");
			var result12 = Products
				.Select(p => p.Category)
				.Distinct();

			foreach (var category in result12)
				Console.WriteLine(category);


			// 13. 
			Console.WriteLine("\nQuestion 13:");
			int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
			int[] setB = { 3, 6, 9, 12, 15, 13 };

			var result13 = setA.Except(setB);

			foreach (var id in result13)
				Console.WriteLine(id);


			// 14. 
			Console.WriteLine("\nQuestion 14:");
			string[] list1 = { "Germany", "France", "UK", "Spain" };
			string[] list2 = { "france", "SPAIN", "Italy" };

			var result14 = list1.Except(
				list2,
				StringComparer.OrdinalIgnoreCase);

			foreach (var country in result14)
				Console.WriteLine(country);


			// 15. 
			
			Console.WriteLine("\nQuestion 15:");
			Dictionary<int, Product> result15 =
				Products.ToDictionary(p => p.ProductID);

			if (result15.TryGetValue(18, out Product product))
				Console.WriteLine(product.ProductName);
			else
				Console.WriteLine("Product not found");


			// 16. 
			Console.WriteLine("\nQuestion 16:");
			var result16 = Products.First(p => p.UnitPrice > 50);

			Console.WriteLine($"{result16.ProductName} - {result16.UnitPrice}");


			// 17. 
			Console.WriteLine("\nQuestion 17:");
			var result17 = Products.FirstOrDefault(p => p.UnitPrice > 500);

			if (result17 != null)
				Console.WriteLine(result17.ProductName);
			else
				Console.WriteLine("No product found");


			// 18. 
			Console.WriteLine("\nQuestion 18:");
			var result18 = Enumerable.Range(1, 10)
				.Select(n => $"7 x {n} = {7 * n}");

			foreach (var item in result18)
				Console.WriteLine(item);


			// 19. 
			Console.WriteLine("\nQuestion 19:");
			var result19 = Enumerable.Range(1, 30)
				.Where(n => n % 2 == 0);

			foreach (var number in result19)
				Console.WriteLine(number);


			// 20. 
			Console.WriteLine("\nQuestion 20:");
			var result20 = Products
				.Take(3)
				.Select(p => p.ProductName)
				.Concat(
					Customers
						.Take(3)
						.Select(c => c.CustomerName)); 

			foreach (var name in result20)
				Console.WriteLine(name);


			// 21. 
			Console.WriteLine("\nQuestion 21:");
			var result21 = Products.Zip(
				Customers,
				(p, c) => $"{p.ProductName} sold to {c.CustomerName}"); 
			foreach (var item in result21)
				Console.WriteLine(item);




		}
	}
}
