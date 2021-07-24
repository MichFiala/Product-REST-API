using System;
using API.Extensions;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseApiController : ControllerBase
	{
		/// <summary>
		/// Handles any response from controllers based on result
		/// </summary>
		/// <typeparam name="T">Type that result holds</typeparam>
		/// <param name="result">Result object</param>
		/// <returns>ActionResult</returns>
		protected ActionResult HandleResult<T>(Result<T> result)
		{
			if (result == null) return NotFound();

			if (result.IsSuccess && result.Value != null) return Ok(result.Value);

			if (result.IsSuccess && result.Value == null) return NotFound();

			return BadRequest(result.Error);
		}
		/// <summary>
		/// Handles any response from controllers based on pagedList
		/// </summary>
		/// <typeparam name="T">Type of paged list</typeparam>
		/// <param name="result">Result object</param>
		/// <returns>ActionResult</returns>
		protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
		{
			if (result == null) return NotFound();

			if (result.IsSuccess && result.Value != null)
			{
				Response?.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize, 
				result.Value.TotalCount, result.Value.TotalPages);

				return Ok(result.Value);
			}

			if (result.IsSuccess && result.Value == null) return NotFound();

			return BadRequest(result.Error);
		}
	}
}