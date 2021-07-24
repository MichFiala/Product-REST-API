using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
	public static class HttpExtensions
	{
		/// <summary>
		/// Handles pagination to add to response on demand
		/// </summary>
		/// <param name="response">HttpResponse</param>
		/// <param name="currentPage">Current page</param>
		/// <param name="itemsPerPage">Items per page</param>
		/// <param name="totalItems">Total Items</param>
		/// <param name="totalPages">Total pages</param>
		public static void AddPaginationHeader(this HttpResponse response, int currentPage,
		    int itemsPerPage, int totalItems, int totalPages)
		{
			var paginationHeader = new
			{
				currentPage,
				itemsPerPage,
				totalItems,
				totalPages
			};

			response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader));
			response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
		}
	}
}