using QMSDisplay.Manager;
using QMSKiosk.Interface.Manager;
using QMSKiosk.Models;
using QMSKiosk.Repository;

namespace QMSKiosk.Manager
{
    public class OrganizationManager : BaseManager<Organization>, IOrganizationManager
    {
        public OrganizationManager(QmsDbContext db) : base(new BaseRepository<Organization>(db))
        {
        }


        public Organization GetOrganization()
        {
            return GetFirstOrDefault(v => true);

        }
    }
}
