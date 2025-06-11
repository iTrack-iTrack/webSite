using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SmartWatchWeb.Services
{
    public class userState
    {
        private readonly IJSRuntime _js;

        public bool IsAdmin { get; private set; } = false;

        public int userID { get; private set; } = -1;

        public string token { get; private set; } = string.Empty;

        public userState(IJSRuntime js)
        {
            _js = js;
        }

        public void SetAdmin(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
        public void ResetUserID()
        {
            userID = 0;
        }


        public void SetToken(string newToken)
        {
            token = newToken;
        }

        public void setID(int ID)
        {
            userID = ID;
        }

        public int getID()
        {
            return userID;
        }

        // Save token and userID to localStorage
        public async Task SaveToStorageAsync()
        {
            if (_js is not null)
            {
                await _js.InvokeVoidAsync("localStorage.setItem", "token", token);
                await _js.InvokeVoidAsync("localStorage.setItem", "userID", userID.ToString());
            }
        }

        // Load token and userID from localStorage
        public async Task LoadFromStorageAsync()
        {
            if (_js is not null)
            {
                token = await _js.InvokeAsync<string>("localStorage.getItem", "token") ?? string.Empty;

                var userIdString = await _js.InvokeAsync<string>("localStorage.getItem", "userID");
                if (int.TryParse(userIdString, out var id))
                    userID = id;
                else
                    userID = -1;
            }
        }

        // Clear localStorage and reset state
        public async Task ClearStorageAsync()
        {
            if (_js is not null)
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", "token");
                await _js.InvokeVoidAsync("localStorage.removeItem", "userID");
            }
            token = string.Empty;
            userID = -1;
            IsAdmin = false;
        }
    }
}
