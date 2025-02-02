﻿
namespace Catalog_API.Products.UpdateProduct
{

	public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price):ICommand<UpdateProductResult>;
	public record UpdateProductResult(bool IsSuccess);
	public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
	{
		public UpdateProductCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is Required");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
		}
	}
	internal class UpdateProductHandler(IDocumentSession _session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
	{
		public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
		{
			var product = await _session.LoadAsync<Product>(command.Id);
			if (product is null) {
				throw new ProductNotFoundException(command.Id);
			}
			product.ImageFile = command.ImageFile;
			product.Price = command.Price;
			product.Category = command.Category;
			product.Description = command.Description;
			product.Name = command.Name;
			_session.Update<Product>(product);
		
			

			await _session.SaveChangesAsync(cancellationToken);
			return new UpdateProductResult(true);
		}
	}
}
