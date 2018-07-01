using Contact.Manager.Api.Controllers;
using Contact.Manager.Data.Access.Layer;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Contact.Manager.Api.Tests
{
	public class ContactsControllerTests
	{
		//[Fact]
		//public async Task Get_All_Contacts()
		//{
		//	// Arrange & Act
		//	var mockRepo = new Mock<FakeContactDbContext>();
		//	var controller = new ContactsController(mockRepo.Object);
		//	mockRepo.Setup(repo => repo.Contacts)
		//						.Returns(new Mock<FakeContactDbContext>().Object.Contacts);

		//	// Act
		//	var result = controller.GetContacts();

		//	// Assert
		//	Assert.NotNull(result);
		//}
	}
}
