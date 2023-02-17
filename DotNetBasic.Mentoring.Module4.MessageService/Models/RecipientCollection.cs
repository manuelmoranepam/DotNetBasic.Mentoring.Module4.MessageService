namespace DotNetBasic.Mentoring.Module4.MessageService.Models
{
	internal class RecipientCollection
	{
		private readonly IList<Recipient> _recipients;

		public RecipientCollection()
		{
			_recipients = new List<Recipient>();
		}

		public void CreateRecipient(string name, string email, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
			if (string.IsNullOrWhiteSpace(phoneNumber))
				throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or whitespace.", nameof(phoneNumber));

			var index = 0;

			if (_recipients.Any())
			{
				index = _recipients.Last().Id + 1;
			}

			var recipient = new Recipient(index, name, email, phoneNumber);

			_recipients.Add(recipient);
		}

		public IEnumerable<Recipient> GetRecipients()
		{
			return _recipients.AsEnumerable();
		}

		public void DeleteRecipient(int id)
		{
			var recipient = GetRecipient(id);

			_recipients.Remove(recipient);
		}

		private Recipient GetRecipient(int id)
		{
			var specifiedRecipient = _recipients
				.Where(recipient => recipient.Id == id)
				.FirstOrDefault();

			if (specifiedRecipient is null)
				throw new ArgumentNullException(nameof(_recipients), $"The '{nameof(_recipients)}' list does not contains a recipient of id '{id}'.");

			return specifiedRecipient;
		}
	}
}
