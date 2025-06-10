namespace SmartWatchWeb.Services
{
	public class userState
	{
		public bool IsAdmin { get; private set; } = false;

		public int userID { get; private set; } = -1;

        public void setID(int ID)
        {
            userID = ID;
        }

        public void SetAdmin(bool isAdmin)
		{
			IsAdmin = isAdmin;
		}
	}
}
