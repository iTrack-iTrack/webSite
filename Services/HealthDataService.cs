using ChartJs.Blazor.Common.Time;

namespace SmartWatchWeb.Services
{
	public interface IHealthDataService
	{
		int CurrentBpm { get; }
		int Oxidation { get; set; }
		int Steps { get; }
		Queue<TimePoint> BpmHistory { get; }
		void AddBpmDataPoint(int bpm);
	}
	public class HealthDataService : IHealthDataService, IDisposable
	{
		private const int MaxDataPoints = 30;
		public Queue<TimePoint> BpmHistory { get; } = new();
		public int CurrentBpm { get; private set; }
		public int Oxidation { get; set; } = 77; // static placeholder
		public int Steps => 15000; //static placeholder

		public void AddBpmDataPoint(int bpm)
		{
			CurrentBpm = bpm;
			var point = new TimePoint(DateTime.Now, bpm);

			BpmHistory.Enqueue(point);
			if (BpmHistory.Count > MaxDataPoints) BpmHistory.Dequeue();
		}

		public void Dispose() => BpmHistory.Clear();
	}
}
