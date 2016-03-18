using System.Collections.Generic;
using Fleck;

namespace MonitorService.WebSocket
{
    public interface IWebSocketConncetionPool
    {
        string ConnectionType { get; set; }


        List<IWebSocketConnection> WebSockets { get; }
    }
}
