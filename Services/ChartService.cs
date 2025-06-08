using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Time;
using ChartJs.Blazor.LineChart;

namespace SmartWatchWeb.Services
{
	public static class ChartService
	{
		public static LineConfig CreateBpmLineConfig()
		{
			return new LineConfig
			{
				Options = new LineOptions
				{
					Responsive = true,
					Title = new OptionsTitle
					{
						Display = true,
						Text = "User BPM Over Time"
					},
					Scales = new Scales
					{
						XAxes = new List<CartesianAxis>
				{
					new TimeAxis
					{
						Time = new TimeOptions
						{
							Unit = TimeMeasurement.Minute,
						},
						ScaleLabel = new ScaleLabel
						{
							Display = true,
							LabelString = "Time"
						}
					}
				},
						YAxes = new List<CartesianAxis>
				{
					new LinearCartesianAxis
					{
						Ticks = new LinearCartesianTicks
						{
							BeginAtZero = true
						},
						ScaleLabel = new ScaleLabel
						{
							Display = true,
							LabelString = "BPM"
						}
					}
				}
					}
				}
			};
		}

		public static BarConfig CreateStepsBarConfig()
		{
			return new BarConfig {
				Options = new BarOptions
				{
					Responsive = true,
					Title = new OptionsTitle
					{
						Display = true,
						Text = "Steps by Day"
					},
					Scales = new BarScales
					{
						XAxes = new List<CartesianAxis>
					{
						new TimeAxis
						{
							Time = new TimeOptions
							{
								Unit = TimeMeasurement.Day,
							},
							ScaleLabel = new ScaleLabel
							{
								Display = true,
								LabelString = "Time"
							}
						}
					},
						YAxes = new List<CartesianAxis>
					{
						new LinearCartesianAxis
						{
							Ticks = new LinearCartesianTicks
							{
								BeginAtZero = true
							},
							ScaleLabel = new ScaleLabel
							{
								Display = true,
								LabelString = "Steps"
							}
						}
					}
					}
				}
			};
		}
	}
}
