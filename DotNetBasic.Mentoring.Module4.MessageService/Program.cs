using DotNetBasic.Mentoring.Module4.MessageService.Features;
using DotNetBasic.Mentoring.Module4.MessageService.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		var command = string.Empty;
		var messageCollection = new MessageCollection();
		var messageFeature = new MessageFeature();

		while (command is not "exit")
		{
			try
			{
				Console.Write("> ");

				command = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(command))
					throw new ArgumentNullException(nameof(command), $"The '{command}' is not a valid command.");


				if (command is "create message")
				{
					messageFeature.CreateMessage(messageCollection);
				}
				else if (command is "list message --all")
				{
					messageFeature.ListMessages(messageCollection);
				}
				else if (command.StartsWith("delete message --id:"))
				{
					messageFeature.DeleteMessage(messageCollection, command);
				}
				else if (command is "clear")
				{
					Console.Clear();
				}
				if(command is "exit")
				{
					Console.WriteLine("Press any key to continue.");

					Console.Read();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}