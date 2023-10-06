using QMSDisplay.Interface.Manager;
using QMSKiosk.Models;

namespace QMSKiosk.Interface.Manager
{
    interface IOrganizationManager : IBaseManager<Organization>
    {
        Organization GetOrganization();

    }
}
