using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services
{
    class Repository
    {
        public static List<GraphData> GraphContent(string _type, string _username)
        {
            List<GraphData> graphs = new List<GraphData>()
            {
                new GraphData()
                {
                    Month = "1",
                    Value = 30000
                },
                new GraphData()
                {
                    Month = "2",
                    Value = 50000
                },
                new GraphData()
                {
                    Month = "3",
                    Value = 80000
                },
                new GraphData()
                {
                    Month = "4",
                    Value = 20000
                },
                new GraphData()
                {
                    Month = "5",
                    Value = 30000
                },
                new GraphData()
                {
                    Month = "6",
                    Value = 50000
                }
            };
            
            return graphs;
        }

    }
}
