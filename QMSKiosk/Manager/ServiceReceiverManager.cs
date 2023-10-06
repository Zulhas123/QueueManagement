using QMSDisplay.Interface.Manager;
using QMSDisplay.Manager;
using QMSKiosk.Enum;
using QMSKiosk.Interface.Manager;
using QMSKiosk.Models;
using QMSKiosk.Repository;

namespace QMSKiosk.Manager
{
    public class ServiceReceiverManager : BaseManager<ServiceReceiver>, IServiceReceiverManager
    {
        public ServiceReceiverManager(QmsDbContext db) : base(new BaseRepository<ServiceReceiver>(db))
        {
        }

        //public ServiceReceiver GetNextServiceReceiver(List<int> serviceIds)
        //{
        //    var serviceReceiver = Get(c => c.TokenCreationDate.Date == DateTime.Today && c.Status == (int)ServiceReceiverStatus.Waiting && serviceIds.Contains(c.ServiceInfoId), c => c.ServiceInfo).MinBy(c => c.SerialNo);
        //    return serviceReceiver;
        //}

        //public ServiceReceiver GetById(int id)
        //{
        //    return GetFirstOrDefault(c => c.Id == id,c=>c.ServiceInfo);
        //}

        //public ICollection<ServiceReceiver> GetAllSkipServiceReceiver(List<int> serviceIds)
        //{
        //    return Get(c => c.TokenCreationDate.Date == DateTime.Today && c.Status == (int)ServiceReceiverStatus.Skip && serviceIds.Contains(c.ServiceInfoId), c => c.ServiceInfo);
        //}
        public ServiceReceiver GetLastReceiver(int serviceId)
        {
           var data= Get(c => c.ServiceInfoId == serviceId && c.TokenCreationDate.Date == DateTime.Today).MaxBy(x => x.SerialNo);
           return data;
        }

        //public ICollection<ServiceReceiver> GetServiceReceivers()
        //{
        //    return Get(c =>
        //        (c.Status == (int)ServiceReceiverStatus.Next || c.Status == (int)ServiceReceiverStatus.Waiting ||
        //         c.Status == (int)ServiceReceiverStatus.Ongoing) && c.TokenCreationDate.Date == DateTime.Today);
        //}
    }
}
