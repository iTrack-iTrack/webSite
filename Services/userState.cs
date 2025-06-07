namespace SmartWatchWeb.Services
{
	public class userState
	{
		public bool IsAdmin { get; private set; } = false;

		public void SetAdmin(bool isAdmin)
		{
			IsAdmin = isAdmin;
		}
	}
}
