﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Value_Objects
{
	public class Payment
	{
		public string CardName { get; init; } = default!;
		public string CardNumber { get; init; } = default!;
		public string Expiration { get; init; } = default!;
		public string CVV { get; init; } = default!;
		public int PaymentMethod { get; init; } = default!;

		protected Payment()
		{

		}
		private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod) { 

		    CardName = cardName;
			CardNumber = cardNumber;
			Expiration = expiration;
			CVV = cvv;
			PaymentMethod = paymentMethod;
		}

		public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
		{
			ArgumentException.ThrowIfNullOrEmpty(cardName);
			ArgumentException.ThrowIfNullOrEmpty(cardNumber);
			ArgumentException.ThrowIfNullOrEmpty(cvv);
			ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, 3);

			return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
		}
	}
}
