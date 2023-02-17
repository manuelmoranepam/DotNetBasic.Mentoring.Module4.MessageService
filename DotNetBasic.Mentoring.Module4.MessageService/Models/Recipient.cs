namespace DotNetBasic.Mentoring.Module4.MessageService.Models
{
	internal class Recipient
	{
		public int Id { get; }
		public string Name { get; }
		public string Email { get; }
		public string PhoneNumber { get; }

		public Recipient(int id, string name, string email, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
			if (string.IsNullOrWhiteSpace(phoneNumber))
				throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or whitespace.", nameof(phoneNumber));

			Id = id;
			Name = name;
			Email = email;
			PhoneNumber = phoneNumber;
		}
	}
}
