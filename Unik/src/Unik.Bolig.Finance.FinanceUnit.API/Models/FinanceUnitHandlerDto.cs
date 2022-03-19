using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Bolig.Finance.FinanceUnit.API.Models
{
	//[FinanceUnitNameAndAliasMayNotBeTheSame]
	public abstract class FinanceUnitHandlerDto : IValidatableObject
	{
		[Required(ErrorMessage = "Name must have a value")]
		[MinLength(3)]
		public virtual string Name { get; set; }
		[Required(ErrorMessage = "Alias must have a value")]
		[MinLength(1)]
		public virtual string Alias { get; set; }

		// Find ud af om det giver mening
		IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
		{
			if (Name.Any(char.IsDigit))
			{
				yield return new ValidationResult("The provided name should not contain numbers", new[] { "FinanceUnitCreationDto" });
			}
		}
	}
}
