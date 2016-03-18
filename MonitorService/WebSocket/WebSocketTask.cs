using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Fleck;
using Newtonsoft.Json;

namespace MonitorService.WebSocket
{
    public class WebSocketTask
    {
        public static async Task OnlineWrokAsync(List<IWebSocketConnection> sockets)
        {
            int i = 122;
            while (true)
            {
                for (int j = 0; j < sockets.Count; j++)
                {
                    var socket = sockets[j];
                    var reportData = new { num = 1000 + i };
                    var reportJson = JsonConvert.SerializeObject(reportData);
                    await socket.Send(reportJson);
                }

                await Task.Delay(1000);
                i++;
            }
        }

        public static void RegisteredWrok(IWebSocketConnection socket)
        {
            string sql = "select * from RegisterCollect";

            var ds = SqlHelper.GetTableText(sql);
            var dt = ds[0];
            int length = dt.Rows.Count;

            string[] xAxis = new string[length];
            int[] seriesData = new int[length];

            for (int j = 0; j < length; j++)
            {
                xAxis[j] = dt.Rows[j].Field<string>(0);
                seriesData[j] = dt.Rows[j].Field<int>(1);
            }

            var reportJson = JsonConvert.SerializeObject(new { xAxis, seriesData });
            socket.Send(reportJson);
        }

        public static void InvestWrok(IWebSocketConnection socket)
        {
            string sql = "select * from InvestCollect";

            var ds = SqlHelper.GetTableText(sql);
            var dt = ds[0];
            int length = dt.Rows.Count;
            decimal[] seriesData = new decimal[length];

            for (int j = 0; j < length; j++)
            {
                seriesData[j] = dt.Rows[j].Field<decimal>(1);
            }
            int[] xAxis = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


            var reportJson = JsonConvert.SerializeObject(new { xAxis, seriesData });
            socket.Send(reportJson);
        }

        public static void TotalWrok(IWebSocketConnection socket)
        {
            var ds = SqlHelper.GetTableText("select * from MonthlyChart");
            var dt = ds[0];
            int length = dt.Rows.Count;

            int[] investCount = new int[length];
            int[] registerCount = new int[length];

            for (int j = 0; j < investCount.Length; j++)
            {
                investCount[j] = dt.Rows[j].Field<int>(2);
                registerCount[j] = dt.Rows[j].Field<int>(3);
            }

            var reportJson = JsonConvert.SerializeObject(new { invest = investCount, register = registerCount });
            socket.Send(reportJson);
        }


        public static async Task SubjectWrokAsync(List<IWebSocketConnection> sockets)
        {
            while (true)
            {
                for (int k = sockets.Count - 1; k >= 0; k--)
                {
                    var socket = sockets[k];
                    var ds = SqlHelper.GetTableText("select * from SubjectCollect");
                    var dt = ds[0];
                    var count = dt.Rows.Count;

                    var data = new dynamic[5];

                    for (int j = 0; j < count; j++)
                    {
                        data[j] = new { name = dt.Rows[j].Field<string>(1), value = dt.Rows[j].Field<decimal>(2) };
                    }

                    for (int y = 0; y < data.Length - count; y++)
                    {
                        data[count + y] = new { name = "--", value = 0 };
                    }

                    var reportJson = JsonConvert.SerializeObject(data);

                    await socket.Send(reportJson);
                }

                await Task.Delay(2000);
            }
        }
    }
}
