using QMSDisplay.Manager;
using QMSKiosk.Enum;
using QMSKiosk.Interface.Manager;
using QMSKiosk.Models;
using QMSKiosk.Repository;

namespace QMSKiosk.Manager
{
    public class UserServiceDeskManager : BaseManager<UserServicesDesk>, IUserServiceDeskManager
    {
        public UserServiceDeskManager(QmsDbContext db) : base(new BaseRepository<UserServicesDesk>(db))
        {
        }

       
    }
}
