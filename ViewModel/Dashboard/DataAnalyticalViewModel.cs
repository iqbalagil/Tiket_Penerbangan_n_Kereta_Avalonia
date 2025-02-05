using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive.Linq;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Tiket_Penerbangan_n_Kereta.ViewModel.Dashboard;

public class DataAnalyticalViewModel
{
    public ObservableCollection<ISeries> Series { get; set; }
    public ObservableCollection<Axis> YAxes { get; set; }
    public DrawMarginFrame DrawMarginFrame { get; set; }

    public DataAnalyticalViewModel()
    {
        Series = new ObservableCollection<ISeries>
        {
            new ColumnSeries<ObservableValue>
            {
                Values = new ObservableCollection<ObservableValue>
                {
                    new ObservableValue(10),
                    new ObservableValue(20),
                    new ObservableValue(30),
                    new ObservableValue(40)
                },
                Name = "Pemesanan"
            }
        };

        YAxes = new ObservableCollection<Axis>
        {
            new Axis
            {
                Name = "Jumlah Pemesanan",
                LabelsRotation = 15,
                UnitWidth = 1,
                MinStep = 1
            }
        };

        DrawMarginFrame = new DrawMarginFrame()
        {
            Fill = new SolidColorPaint(new SKColor(255, 255, 255, 50)),
            Stroke = new SolidColorPaint(new SKColor(220, 220, 220), 2)
        };

        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            using var client = new HttpClient();
            var data = await client.GetFromJsonAsync<List<int>>("api/Penumpang/GetPenumpang");

            if (data != null)
            {
                var values = new ObservableCollection<ObservableValue>();
                foreach (var value in data)
                {
                    values.Add(new ObservableValue(value));
                }

                Series.Add(new ColumnSeries<ObservableValue>
                {
                    Values = values,
                    Name = "Pemesanan"
                });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error fetching data: {e.Message}");
        }

    }
}