using Microsoft.EntityFrameworkCore;
using MOD.Pms.Documents;
using MOD.Pms.Enums;
using MOD.Pms.Lookups;
using MOD.Pms.MubaadaraApprovals;
using MOD.Pms.MubaadaraAttachments;
using MOD.Pms.MubaadaraChangeRequests;
using MOD.Pms.MubaadaraDetails;
using MOD.Pms.MubaadaraHEComments;
using MOD.Pms.MubaadaraHistories;
using MOD.Pms.Mubaadaras;
using MOD.Pms.MubaadarasMembers;
using MOD.Pms.MubaadaraUpdates;
using MOD.Pms.MubaadaraWorkflows;
using MOD.Pms.Permissions;
using System;
using System.Linq;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Gdpr;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Tenants;

namespace MOD.Pms.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ReplaceDbContext(typeof(ISaasDbContext))]
[ConnectionStringName("Default")]
public class PmsDbContext :
    AbpDbContext<PmsDbContext>,
    IIdentityProDbContext,
    ISaasDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; }

    // SaaS
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Lookup> Lookups { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<MubaadaraAttachmentDocument> MubaadaraAttachmentDocument { get; set; }
    public DbSet<UserOrganizationUnitPermission> UserOrganizationUnitPermission { get; set; }


    // mubaadars System
    public DbSet<Mubaadara> Mubaadaras { get; set; }
    public DbSet<MubaadaraDetails.MubaadaraDetail> MubaadaraDetails { get; set; }
    public DbSet<MubaadarasWorkflow> MubaadaraWorkflow { get; set; }
    public DbSet<MubaadaraAttachment> MubaadaraAttachment { get; set; }
    public DbSet<MubaadaraMember> MubaadaraMember { get; set; }
    public DbSet<MubaadaraApproval> MubaadaraApproval { get; set; }
    public DbSet<MubaadaraChangeRequest> MubaadaraChangeRequest { get; set; }
    public DbSet<MubaadaraUpdate> MubaadaraUpdate { get; set; }
    public DbSet<MubaadaraHEComment> MubaadaraHEComment  { get; set; }


    public PmsDbContext(DbContextOptions<PmsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureFeatureManagement();
        builder.ConfigureLanguageManagement();
        builder.ConfigureSaas();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureBlobStoring();
        builder.ConfigureGdpr();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(PmsConsts.DbTablePrefix + "YourEntities", PmsConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        #region DB Functions



        builder.HasDbFunction(typeof(PmsDbContext)
                .GetMethod(nameof(GetLookupHierarchyAsQueryable), new[] { typeof(Guid) }))
            .HasName("GetLookupHierarchyAsTable");

        builder.HasDbFunction(typeof(PmsDbContext)
           .GetMethod(nameof(GetDateDifferentDay), new[] { typeof(DateTime), typeof(DateTime) }))
           .HasName("GetDateDiffDay");

        builder.HasDbFunction(typeof(PmsDbContext)
         .GetMethod(nameof(GetUnitHierarchyPathAr), new[] { typeof(Guid) }))
         .HasName("GetUnitHierarchyAr");

        #endregion

        //Lookup Table
        builder.Entity<Lookup>(b =>
        {
            b.ToTable(PmsConsts.DbTablePmsPrefix + "Lookups", PmsConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(c => c.ArabicName).HasMaxLength(256);
            b.Property(c => c.EnglishName).HasMaxLength(256);
            b.HasOne(c => c.Type).WithMany(c => c.Types).HasForeignKey(c => c.LookupId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Document>(b =>
        {
            b.ToTable(PmsConsts.DbTablePmsPrefix + "Documents", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasDiscriminator().HasValue<MubaadaraAttachmentDocument>("MubaadaraAttachment");
        });

        builder.Entity<MubaadaraAttachmentDocument>(w =>
        {
            w.HasOne<MubaadaraAttachment>(d => d.MubaadaraAttachment)
            .WithMany(c => c.Documents)
            .HasForeignKey(d => d.MubaadaraAttachmentId)
            .IsRequired(true).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<UserOrganizationUnitPermission>(b =>
        {
            b.ToTable(PmsConsts.DbTablePmsPrefix + "UserOrganizationUnitPermission", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasIndex(c => new { c.UserId, c.OrganizationUnitId }).IsUnique();
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(c => c.UserId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(c => c.OrganizationUnit).WithMany().HasForeignKey(c => c.OrganizationUnitId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        });


        // Mubaadara  System

        builder.Entity<Mubaadara>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "Mubaadaras", PmsConsts.DbSchema);
            b.HasOne<Lookup>().WithMany().HasForeignKey(b => b.StatusId).OnDelete(DeleteBehavior.NoAction);
            b.HasOne<Lookup>().WithMany().HasForeignKey(b => b.TypeId).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<MubaadaraDetail>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraDetails", PmsConsts.DbSchema);
            b.HasOne<Mubaadara>().WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<MubaadarasWorkflow>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadarasWorkflow", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(c => c.Mubaadara).WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(c => c.UserIdFrom).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(c => c.UserIdTo).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            b.HasOne<MubaadaraApproval>().WithMany().HasForeignKey(c => c.MubaadaraApprovalId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<MubaadaraHEComment>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraHEComment", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(c => c.Mubaadara).WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        });


        builder.Entity<MubaadaraMember>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraMember", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(c => c.Mubaadara).WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired(true).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<MubaadaraChangeRequest>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraChangeRequest", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Mubaadara>().WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<MubaadaraApproval>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraApproval", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<MubaadaraChangeRequest>().WithMany().HasForeignKey(c => c.ReffrenceId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired(true).OnDelete(DeleteBehavior.NoAction);
        });

        builder.Entity<MubaadaraUpdate>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraUpdate", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Mubaadara>().WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<MubaadaraAttachment>(b =>
        {
            b.ToTable(PmsConsts.DbTableMubaadaraPrefix + "MubaadaraAttachment", PmsConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(c => c.Mubaadara).WithMany().HasForeignKey(c => c.MubaadaraId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        });


    }

    public IQueryable<Lookup> GetLookupHierarchyAsQueryable(Guid lookupId) => FromExpression(() => GetLookupHierarchyAsQueryable(lookupId));
    public static int GetDateDifferentDay(DateTime startdate, DateTime enddate) => throw new NotSupportedException();
    public static string GetUnitHierarchyPathAr(Guid id) => throw new NotSupportedException();


}

