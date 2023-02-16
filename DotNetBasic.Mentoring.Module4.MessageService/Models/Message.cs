using DotNetBasic.Mentoring.Module4.MessageService.Enums;

namespace DotNetBasic.Mentoring.Module4.MessageService.Models
{
	internal class Message
	{
		public int Id { get; }
		public string Title { get; }
		public string Body { get; }
		public Importance Importance { get; }

		public Message(int id, string title, string body, Importance importance)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
			if (string.IsNullOrWhiteSpace(body))
				throw new ArgumentException($"'{nameof(body)}' cannot be null or whitespace.", nameof(body));

			Id = id;
			Title = title;
			Body = body;
			Importance = importance;
		}
	}
}
