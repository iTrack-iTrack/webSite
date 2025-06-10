using Microsoft.JSInterop;

namespace SmartWatchWeb.Services
{
	public interface IBpmStreamService
	{
		Task StartAsync(DotNetObjectReference<object> dotNetRef, int userID, string token);
		Task StopAsync();
	}
	public class BpmStreamService : IBpmStreamService
	{
		private readonly IJSRuntime _jsRuntime;

		public BpmStreamService(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public Task StartAsync(DotNetObjectReference<object> dotNetRef, int userID, string token)
			=> _jsRuntime.InvokeVoidAsync("sseInterop.startBpmStream", dotNetRef, userID, token).AsTask();

		public Task StopAsync()
			=> _jsRuntime.InvokeVoidAsync("sseInterop.stopBpmStream").AsTask();
	}
}
