using System.Collections.Generic;
using Fleck;

namespace MonitorService.WebSocket
{
    public class WebSocketConncetionPool : IWebSocketConncetionPool
    {
        private List<IWebSocketConnection> _webSockets;

        public List<IWebSocketConnection> WebSockets
        {
            get
            {
                if (_webSockets == null)
                {
                    _webSockets = new List<IWebSocketConnection>();
                }
                return _webSockets;
            }
        }

        public string ConnectionType { get; set; }

    }
}
