namespace SmartWatchWeb.Services
{
	public class UserSessionService
	{
		public string LoggedInUserId { get; private set; }

		public void SetLoggedInUserId(string username)
		{
			LoggedInUserId = username;
		}
		public void ClearUserId()
		{
			LoggedInUserId = null;
		}


		public void Clear()
		{
			LoggedInUserId= null;
		}
	}

}
