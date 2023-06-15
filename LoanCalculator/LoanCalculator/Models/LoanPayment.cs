using System;
namespace LoanCalculator.Models
{
	public class LoanPayment
	{

		public int Month { get; set; }

		//[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
		public decimal Payment { get; set; }

		public decimal MonthlyPrincipal { get; set; }

		public decimal MonthlyInterest { get; set; }

		public decimal TotalInterest { get; set; }

		public decimal Balance { get; set; }
	}
}

