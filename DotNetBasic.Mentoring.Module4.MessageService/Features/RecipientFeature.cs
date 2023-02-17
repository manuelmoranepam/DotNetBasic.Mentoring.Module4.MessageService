using DotNetBasic.Mentoring.Module4.MessageService.Models;

namespace DotNetBasic.Mentoring.Module4.MessageService.Features
{
	internal class RecipientFeature
	{
		public void CreateRecipient(RecipientCollection recipientCollection)
		{
			if (recipientCollection is null)
				throw new ArgumentNullException(nameof(recipientCollection));

			var name = ReadName();
			var email = ReadEmail();
			var phoneNumber = ReadPhoneNumber();

			recipientCollection.CreateRecipient(name, email, phoneNumber);

			Console.WriteLine("Recipient created.\n");
		}

		private static string ReadName()
		{
			Console.WriteLine("Enter the name:");

			var name = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name), $"The '{name}' is not a valid name.");

			return name;
		}

		private static string ReadEmail()
		{
			Console.WriteLine("Enter the email:");

			var email = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentNullException(nameof(email), $"The '{email}' is not a valid email.");

			return email;
		}

		private static string ReadPhoneNumber()
		{
			Console.WriteLine("Enter the phone number:");

			var phoneNumber = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(phoneNumber))
				throw new ArgumentNullException(nameof(phoneNumber), $"The '{phoneNumber}' is not a valid phone number.");

			return phoneNumber;
		}

		public void ListRecipients(RecipientCollection recipientCollection)
		{
			if (recipientCollection is null)
				throw new ArgumentNullException(nameof(recipientCollection));

			var recipients = recipientCollection.GetRecipients();

			if (recipients.Any())
			{
				recipients.ToList()
					.ForEach(recipient =>
					{
						Console.WriteLine($"The recipient Id: {recipient.Id}.");
						Console.WriteLine($"The recipient Name: {recipient.Name}.");
						Console.WriteLine($"The recipient Email: {recipient.Email}.");
						Console.WriteLine($"The recipient Phone Number: {recipient.PhoneNumber}.");
						Console.WriteLine();
					});
			}
			else
			{
				Console.WriteLine("The list of recipients is empty.");
			}
		}

		public void DeleteRecipient(RecipientCollection recipientCollection, string command)
		{
			if (recipientCollection is null)
				throw new ArgumentNullException(nameof(recipientCollection));
			if (string.IsNullOrWhiteSpace(command))
				throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));

			var id = GetId(command);

			recipientCollection.DeleteRecipient(id);

			Console.WriteLine("Recipient deleted.\n");
		}

		private static int GetId(string command)
		{
			if (string.IsNullOrWhiteSpace(command))
				throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));

			var stringId = command.Split(" recipient --id:", StringSplitOptions.RemoveEmptyEntries)[1];

			var isId = int.TryParse(stringId, out int id);

			if (!isId)
				throw new InvalidCastException($"The '{stringId}' is not a valid Id.");

			return id;
		}
	}
}
