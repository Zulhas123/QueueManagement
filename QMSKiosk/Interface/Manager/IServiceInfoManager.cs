using QMSDisplay.Interface.Manager;
using QMSKiosk.Models;

namespace QMSKiosk.Interface.Manager
{
    interface IServiceInfoManager : IBaseManager<ServiceInfo>
    {
        ServiceInfo GetById(int id);
        ICollection<ServiceInfo> GetByParentId(int? parentId);
       
    }
}
