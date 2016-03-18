using System.ServiceProcess;
using MonitorService.WebSocket;

namespace MonitorService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            WebSocketContext context = new WebSocketContext();
            context.WorkStart();
        }


        protected override void OnStop()
        {
        }
    }
}
