public class UserSessionService
{
    public string LoggedInUsername { get; private set; }

    public void SetLoggedInUsername(string username)
    {
        LoggedInUsername = username;
    }
    public void ClearUsername()
    {
        LoggedInUsername = null;
    }


    public void Clear()
    {
        LoggedInUsername = null;
    }
}
