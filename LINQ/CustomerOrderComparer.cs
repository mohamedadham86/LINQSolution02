using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
	public class CustomerOrderComparer : IComparer<Order[]>
	{
		public int Compare(Order[]? x, Order[]? y)
		{
			return x.Length.CompareTo(y.Length);
		}
	}
}
