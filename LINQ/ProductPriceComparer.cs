using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	public class ProductPriceComparer : IComparer<Product>
	{
		public int Compare(Product? x, Product? y)
		{
			return x.UnitPrice.CompareTo(y.UnitPrice);
		}
	}
}
