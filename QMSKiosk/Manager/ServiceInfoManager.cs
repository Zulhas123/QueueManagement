using QMSDisplay.Manager;
using QMSKiosk.Interface.Manager;
using QMSKiosk.Models;
using QMSKiosk.Repository;

namespace QMSKiosk.Manager
{
    public class ServiceInfoManager : BaseManager<ServiceInfo>, IServiceInfoManager
    {
        public ServiceInfoManager(QmsDbContext db) : base(new BaseRepository<ServiceInfo>(db))
        {
        }

        public ServiceInfo GetById(int id)
        {
            return GetFirstOrDefault(c => c.Id == id);
        }

        public ICollection<ServiceInfo> GetByParentId(int? parentId)
        {
            return Get(c => c.IsActive && c.ParentId == parentId);
        }
    }
}
