

using System;
using Volo.Saas.Host.Dtos;

namespace MOD.Pms.IdentityUsers
{
    public class IdentityUserDto
    {
        public Guid Id { get; set; }
        public virtual Guid? TenantId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string ServiceNumber { get; set; }
        public virtual int RankOrder { get; set; }
        public virtual string Rank { get; set; }
        public virtual string Name { get; set; }
        public virtual string Position { get; set; }
        public virtual string MainUnit { get; set; }
        public virtual string MainUnitEnglish { get; set; }
        public virtual string Tenant { get; set; }
        public virtual int TenantOrder { get; set; }
        public virtual string FullName { get; set; }
        public virtual string RankNamePosition { get; set; }
    }
}
