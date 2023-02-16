using DotNetBasic.Mentoring.Module4.MessageService.Enums;
using DotNetBasic.Mentoring.Module4.MessageService.Models;

namespace DotNetBasic.Mentoring.Module4.MessageService.Features
{
	internal class MessageFeature
	{
		public void CreateMessage(MessageCollection messageCollection)
		{
			if (messageCollection is null)
				throw new ArgumentNullException(nameof(messageCollection));

			var title = ReadTitle();
			var body = ReadBody();
			var importance = ReadImportance();

			messageCollection.CreateMessage(title, body, importance);

			Console.WriteLine("Message created.\n");
		}

		private static string ReadTitle()
		{
			Console.WriteLine("Enter the title:");

			var title = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentNullException(nameof(title), $"The '{title}' is not a valid title.");

			return title;
		}

		private static string ReadBody()
		{
			Console.WriteLine("Enter the body:");

			var body = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(body))
				throw new ArgumentNullException(nameof(body), $"The '{body}' is not a valid body.");

			return body;
		}

		private static Importance ReadImportance()
		{
			Console.WriteLine("Select an importance level [Low | 0] [Medium | 1] [High | 2]:");

			var importanceString = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(importanceString))
				throw new ArgumentNullException(nameof(importanceString), $"The '{importanceString}' is not a valid importance level.");

			var isImportance = Enum.TryParse(importanceString, out Importance importance);

			if (!isImportance)
				throw new InvalidCastException($"The '{importanceString}' is not a valid importance.");

			return importance;
		}

		public void ListMessages(MessageCollection messageCollection)
		{
			if (messageCollection is null)
				throw new ArgumentNullException(nameof(messageCollection));

			var messages = messageCollection.GetMessages();

			if (messages.Any())
			{
				messages.ToList()
					.ForEach(message =>
					{
						Console.WriteLine($"The message Id: {message.Id}.");
						Console.WriteLine($"The message Title: {message.Title}.");
						Console.WriteLine($"The message Body: {message.Body}.");
						Console.WriteLine($"The message Importance: {message.Importance}.");
						Console.WriteLine();
					});
			}
			else
			{
				Console.WriteLine("The list of messages is empty.");
			}
		}

		public void DeleteMessage(MessageCollection messageCollection, string command)
		{
			if (messageCollection is null)
				throw new ArgumentNullException(nameof(messageCollection));
			if (string.IsNullOrWhiteSpace(command))
				throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));

			var id = GetId(command);

			messageCollection.DeleteMessage(id);

			Console.WriteLine("Message deleted.\n");
		}

		private static int GetId(string command)
		{
			if (string.IsNullOrWhiteSpace(command))
				throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));

			var stringId = command.Split(" message --id:", StringSplitOptions.RemoveEmptyEntries)[1];

			var isId = int.TryParse(stringId, out int id);

			if (!isId)
				throw new InvalidCastException($"The '{stringId}' is not a valid Id.");

			return id;
		}
	}
}
