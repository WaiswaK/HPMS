using App.Models;
using App.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microcharts;

namespace App.ViewModels
{
    class GraphViewModel : BaseViewModel
    {
        private Chart _barChart;
        public Chart BarChart
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
        private async Task InitializeAsync(string _type, string _username)
        {
            //var graphs = await Json.GraphContent(_type, _username);
            var graphs = Repository.GraphContent(_type, _username);

            _barChart.Entries = graphs.Select(
                (v, index) => new Entry(v.Value)
                {
                    ValueLabel = v.Value.ToString("N2"),
                    Label = v.Month
                });
        }
        public GraphViewModel(string _page, string _username)
        {
            Title = _page;
            InitializeAsync(_page, _username);
        }
    }
}
