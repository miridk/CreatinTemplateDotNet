
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.API.Models;

namespace Template.API.ValidationAttributes
{
	internal class FinanceUnitNameAndAliasMayNotBeTheSame : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var financeUnit = (FinanceUnitHandlerDto)validationContext.ObjectInstance;

			if(financeUnit.Name == financeUnit.Alias)
			{
				return new ValidationResult("The name and alias may not be the same", new[] { nameof(FinanceUnitHandlerDto) });
			}
			return ValidationResult.Success;
		}
	}
}
