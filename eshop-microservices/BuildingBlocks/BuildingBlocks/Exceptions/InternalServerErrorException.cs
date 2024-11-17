﻿namespace BuildingBlocks.Exceptions
{
	public class InternalServerErrorException:Exception
	{
		public string? Details { get; }

		public InternalServerErrorException(string message ):base(message) { }

		public InternalServerErrorException(string message, string details) : base(message) {
			this.Details = details;
		}
	}
}
