﻿
using Catalog_API.Products.CreateProduct;

namespace Catalog_API.Products.DeleteProduct
{

	//public record DeleteProductRequest();

	public record DeleteProductResponse(bool IsDeleted);
	public class DeleteProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapDelete("/products/{id}", async (Guid id, ISender sender) => {

				var result = await sender.Send(new DeleteProductCommand(id));
				var response = result.Adapt<DeleteProductResponse>();
				return Results.NoContent();
				
				
			}).WithName("DeleteProduct").
			Produces<CreateProductResponse>(StatusCodes.Status204NoContent).
			ProducesProblem(StatusCodes.Status400BadRequest).
			ProducesProblem(StatusCodes.Status404NotFound)
			.WithSummary("Delete Product")
			.WithDescription("Delete Product"); ;
		}
	}
}
