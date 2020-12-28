using App.Models;
using App.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microcharts;
using App.Database;

namespace App.ViewModels
{
    public class GraphViewModel : BaseViewModel
    {
        private Chart _barChart;//Chart _barChart;
        public Chart BarChart//Chart BarChart
        {
            get { return _barChart; }
            set { SetProperty(ref _barChart, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public List<GraphData> Graphs { get; set; }

        public GraphViewModel(string _page, string _username)
        {
            Task.Run(async () =>
            {
                await UpdateVisitAsync(_username);
            });
            Initialize(_page, _username);
            Title = _page;
            //if(_barChart!=null)
            //  _barChart = new LineChart();
        }
        private static async Task UpdateVisitAsync(string user)
        {
            Services.Database.InsertVisits(await Json.GetData(user), user);
        }
        private void Initialize(string _type, string _username)
        {
            _barChart = new LineChart();
            var graphs = GraphContent(_type, _username);
            if (graphs.Count > 0)
            {
                _barChart.Entries = graphs.Select(
                                (v, index) => new Entry(v.Value)
                                {
                                    ValueLabel = v.Value.ToString(),
                                    Label = v.Month
                                });
            }
        }

        private static List<GraphData> GraphContent(string _type, string _username)
        {
            List<GraphData> graphs = new List<GraphData>();
            List<Visit> visits;
            try
            {
                visits = Services.Database.GetVisits(_username);
                if (visits.Count == 0)
                {

                }
                else
                {
                    if (visits.Count() < 7)
                    {
                        foreach (var visit in visits)
                        {
                            GraphData graph = new GraphData()
                            {
                                Month = Constants.Month(visit.Visit_Date),
                                Value = float.Parse(Constants.Value(visit, _type).ToString())
                            };
                            graphs.Add(graph);
                        }
                    }
                    else
                    {
                        int start_number = visits.Count() - 5;
                        int last_number = visits.Count + 1;
                        for (int i = start_number; i < last_number; i++)
                        {
                            GraphData graph = new GraphData()
                            {
                                Month = Constants.Month(visits.ElementAt(i).Visit_Date),
                                Value = float.Parse(Constants.Value(visits.ElementAt(i), _type).ToString())
                            };
                            graphs.Add(graph);
                        }
                    }
                }
            }

            catch
            {

            }
            return graphs;
        }
    }
}
