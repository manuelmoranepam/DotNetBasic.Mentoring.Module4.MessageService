using DotNetBasic.Mentoring.Module4.MessageService.Features;
using DotNetBasic.Mentoring.Module4.MessageService.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		var command = string.Empty;
		var messageCollection = new MessageCollection();
		var messageFeature = new MessageFeature();
		var recipientCollection = new RecipientCollection();
		var recipientFeature = new RecipientFeature();

		while (command is not "exit")
		{
			try
			{
				Console.Write("> ");

				command = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(command))
					throw new ArgumentNullException(nameof(command), $"The '{command}' is not a valid command.");

				var isValidCommand = ValidateMessageCommand(command, messageFeature, messageCollection);

				if (!isValidCommand)
				{
					isValidCommand = ValidateRecipientCommand(command, recipientFeature, recipientCollection);
				}
				if (!isValidCommand)
				{
					isValidCommand = ValidateApplicationCommand(command);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	private static bool ValidateMessageCommand(string command, MessageFeature messageFeature, MessageCollection messageCollection)
	{
		if (string.IsNullOrWhiteSpace(command))
			throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));
		if (messageFeature is null)
			throw new ArgumentNullException(nameof(messageFeature));
		if (messageCollection is null)
			throw new ArgumentNullException(nameof(messageCollection));

		var isValid = false;

		if (command is "create message")
		{
			isValid = true;

			messageFeature.CreateMessage(messageCollection);
		}
		else if (command is "list message --all")
		{
			isValid = true;

			messageFeature.ListMessages(messageCollection);
		}
		else if (command.StartsWith("delete message --id:"))
		{
			isValid = true;

			messageFeature.DeleteMessage(messageCollection, command);
		}

		return isValid;
	}

	private static bool ValidateRecipientCommand(string command, RecipientFeature recipientFeature, RecipientCollection recipientCollection)
	{
		if (string.IsNullOrWhiteSpace(command))
			throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));
		if (recipientFeature is null)
			throw new ArgumentNullException(nameof(recipientFeature));
		if (recipientCollection is null)
			throw new ArgumentNullException(nameof(recipientCollection));

		var isValid = false;

		if (command is "create recipient")
		{
			isValid = true;

			recipientFeature.CreateRecipient(recipientCollection);
		}
		else if (command is "list recipient --all")
		{
			isValid = true;

			recipientFeature.ListRecipients(recipientCollection);
		}
		else if (command.StartsWith("delete recipient --id:"))
		{
			isValid = true;

			recipientFeature.DeleteRecipient(recipientCollection, command);
		}

		return isValid;
	}

	private static bool ValidateApplicationCommand(string command)
	{
		if (string.IsNullOrWhiteSpace(command))
			throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));

		var isValid = false;

		if (command is "clear")
		{
			isValid = true;

			Console.Clear();
		}
		if (command is "exit")
		{
			isValid = true;

			Console.WriteLine("Press any key to continue.");

			Console.Read();
		}
		else
		{
			isValid = false;

			Console.WriteLine("Invalid command.");
		}

		return isValid;
	}
}