using Doctorly.EventManager.Api.DTOs.Event;
using Doctorly.EventManager.Api.Validators.Event;

namespace Doctorly.EventManager.Tests.Validator
{
    public class ValidatorTests
    {
        [Test]
        public async Task IfRequiredFieldsNotThere_ItShouldFailValidation()
        {
            //Setup
            var createEventRequestValidator = new UpsertEventRequestValidator();

            var createEventRequest = new CreateEventRequest();
            createEventRequest.Title = null;
            createEventRequest.Description = "Test Discription";
            createEventRequest.StartTime = DateTime.Now;
            createEventRequest.EndTime = DateTime.Now;

            //Action
            var result = await createEventRequestValidator.ValidateAsync(createEventRequest);
            var test = result.ToString();

            //Assert
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.ToString() == "'Title' must not be empty.\r\nThe event title is required and connot be empty or null.");
        }

        [Test]
        public async Task IfFieldLengthExceedsMax_ItShouldFailValidation()
        {
            //Setup
            var createEventRequestValidator = new UpsertEventRequestValidator();

            var createEventRequest = new CreateEventRequest();
            createEventRequest.Title = "ddddddddddddddssssssssssssssssttttttttttttttttttttttttttssssssssssssssssssssddddddddddddddddddddddvbvvvvvvvvvvvvvvvvvvvvssssssssssssssssssss";
            createEventRequest.Description = "Test Discription";
            createEventRequest.StartTime = DateTime.Now;
            createEventRequest.EndTime = DateTime.Now;

            //Action
            var result = await createEventRequestValidator.ValidateAsync(createEventRequest);

            //Assert
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.ToString() == "The event title cannot exceed more than 50 characters.");
        }
    }
}
