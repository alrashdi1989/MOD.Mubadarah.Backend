using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Saas.Tenants;

namespace MOD.Pms.Permissions
{
    public class UserOrganizationUnitPermission : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid OrganizationUnitId { get; set; }
        public OrganizationUnit? OrganizationUnit { get; set; }


    }
}
