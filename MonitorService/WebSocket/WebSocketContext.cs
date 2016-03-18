using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fleck;
using Newtonsoft.Json;
using ServiceStack;

namespace MonitorService.WebSocket
{
    public class WebSocketContext
    {
        private readonly string _webSocketServerPath = ConfigurationManager.AppSettings["WebSocketServer"];

        public WebSocketContext()
        {
            CreateWebSocketServer();
        }

        private List<IWebSocketConncetionPool> _webSocketGroup;

        public List<IWebSocketConncetionPool> WebSocketGroup
        {
            get
            {
                if (_webSocketGroup == null)
                {
                    _webSocketGroup = new List<IWebSocketConncetionPool>();
                }
                return _webSocketGroup;
            }
        }

        private void CreateWebSocketServer()
        {
            var server = new WebSocketServer(_webSocketServerPath)
            {
                SupportedSubProtocols = new[] { "superchart", "chart" }
            };

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    ChangeFor(socket);
                };
                socket.OnClose = () =>
                {
                    Remove(socket);
                };
                socket.OnMessage = message =>
                {

                };
            });
        }

        public void WorkStart()
        {
            var group1 = AddSocketGroup(ConnectionType.ONLINE);
            var group2 = AddSocketGroup(ConnectionType.SUBJECT);

            //线程方式
            //ThreadPool.QueueUserWorkItem(WebSocketTask.OnlineWrok, group1.WebSockets);
            //ThreadPool.QueueUserWorkItem(WebSocketTask.SubjectWrok, group2.WebSockets);

            //异步方式
            var t1 = WebSocketTask.OnlineWrokAsync(group1.WebSockets);
            var t2 = WebSocketTask.SubjectWrokAsync(group2.WebSockets);
        }

        private IWebSocketConncetionPool AddSocketGroup(string connectionType)
        {
            var wscp = new WebSocketConncetionPool { ConnectionType = connectionType };
            WebSocketGroup.Add(wscp);
            return wscp;
        }

        private List<IWebSocketConnection> Get(string connectionType)
        {
            return WebSocketGroup.Single(w => w.ConnectionType == connectionType).WebSockets;
        }

        private void ChangeFor(IWebSocketConnection socket)
        {
            switch (socket.ConnectionInfo.Path.Replace("/", ""))
            {
                case ConnectionType.ONLINE:
                case ConnectionType.SUBJECT:
                    Add(socket);
                    break;
                case ConnectionType.REGISTER:
                    WebSocketTask.RegisteredWrok(socket);
                    break;
                case ConnectionType.INVEST:
                    WebSocketTask.InvestWrok(socket);
                    break;
                case ConnectionType.TOTAL:
                    WebSocketTask.TotalWrok(socket);
                    break;
            }
        }

        private void Add(IWebSocketConnection socket)
        {
            string target = socket.ConnectionInfo.Path.Replace("/", "");
            var allSockets = Get(target);
            if (!allSockets.Contains(socket))
            {
                allSockets.Add(socket);
            }
        }

        private void Remove(IWebSocketConnection socket)
        {
            var target = socket.ConnectionInfo.Path.Replace("/", "");

            if (target == ConnectionType.ONLINE || target == ConnectionType.SUBJECT)
            {
                var allSockets = Get(target);
                if (allSockets.Contains(socket))
                {
                    allSockets.Remove(socket);
                }
            }
        }
    }
}