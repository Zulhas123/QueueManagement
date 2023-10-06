using QMSDisplay.Interface.Manager;
using QMSKiosk.Models;

namespace QMSKiosk.Interface.Manager
{
    interface IServiceReceiverManager : IBaseManager<ServiceReceiver>
    {

        //ServiceReceiver GetNextServiceReceiver(List<int> serviceIds);
        ServiceReceiver GetLastReceiver(int serviceId);
        //ICollection<ServiceReceiver> GetServiceReceivers();

    }
}
