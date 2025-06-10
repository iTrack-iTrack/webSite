namespace SmartWatchWeb.Services
{
	public class userState
	{
		public bool IsAdmin { get; private set; } = false;

        public int userID { get; set; } = -1;

		public string token { get; private set; } = string.Empty;

        public void setID(int ID)
        {
            userID = ID;
        }

        public int getID()
        {
            return userID;
        }

        public void SetAdmin(bool isAdmin)
		{
			IsAdmin = isAdmin;
		}

        public void SetToken(string newToken)
        {
            token = newToken;
        }
    }
}
