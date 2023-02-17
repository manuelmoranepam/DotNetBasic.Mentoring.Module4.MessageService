using DotNetBasic.Mentoring.Module4.MessageService.Enums;

namespace DotNetBasic.Mentoring.Module4.MessageService.Models
{
	internal class MessageCollection
	{
		private readonly IList<Message> _messages;

		public MessageCollection()
		{
			_messages = new List<Message>();
		}

		public void CreateMessage(string title, string body, Importance importance)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
			if (string.IsNullOrWhiteSpace(body))
				throw new ArgumentException($"'{nameof(body)}' cannot be null or whitespace.", nameof(body));

			var index = 0;

			if (_messages.Any())
			{
				index = _messages.Last().Id + 1;
			}

			var message = new Message(index, title, body, importance);

			_messages.Add(message);
		}

		public IEnumerable<Message> GetMessages()
		{
			return _messages.AsEnumerable();
		}

		public void DeleteMessage(int id)
		{
			var message = GetMessage(id);

			_messages.Remove(message);
		}

		private Message GetMessage(int id)
		{
			var specifiedMessage = _messages
				.Where(message => message.Id == id)
				.FirstOrDefault();

			if (specifiedMessage is null)
				throw new ArgumentNullException(nameof(_messages), $"The '{nameof(_messages)}' list does not contains a message of id '{id}'.");

			return specifiedMessage;
		}
	}
}
