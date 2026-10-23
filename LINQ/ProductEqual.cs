using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	public class ProductEqual : IEqualityComparer<Product>
	{
		public bool Equals(Product? x, Product? y)
		{
			return x.ProductID == y.ProductID && x.ProductName == y.ProductName && x.Category == y.Category && x.UnitPrice == y.UnitPrice && x.UnitsInStock == y.UnitsInStock;
		}

		public int GetHashCode([DisallowNull] Product obj)
		{
			return HashCode.Combine(obj.ProductID, obj.ProductName, obj.Category, obj.UnitPrice, obj.UnitsInStock);
		}
	}
}
