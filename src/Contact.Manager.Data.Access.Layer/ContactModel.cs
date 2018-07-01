using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Manager.Data.Access.Layer
{
	public class ContactModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please provide firstname.")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please provide lastname.")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please provide email Id.")]
		[StringLength(50)]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please provide phone number.")]
		[Column(TypeName = "numeric")]
		[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
		public decimal PhoneNumber { get; set; }

		public bool Status { get; set; }
	}
}
