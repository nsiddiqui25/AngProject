using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataRepository.Models
{
    public partial class ELD_PRODUCTION_DXGContext : DbContext
    {
        public virtual DbSet<BrMerge> BrMerge { get; set; }
        public virtual DbSet<BrokerAgent> BrokerAgent { get; set; }
        public virtual DbSet<BrokerContact> BrokerContact { get; set; }
        public virtual DbSet<BrokerLicense> BrokerLicense { get; set; }
        public virtual DbSet<BrokerMaster> BrokerMaster { get; set; }
        public virtual DbSet<EldUsers> EldUsers { get; set; }
        public virtual DbSet<LkpStateRegion> LkpStateRegion { get; set; }
        public virtual DbSet<SsEldUserRole> SsEldUserRole { get; set; }
        public virtual DbSet<SsPermission> SsPermission { get; set; }
        public virtual DbSet<SsRole> SsRole { get; set; }
        public virtual DbSet<SsRolePermission> SsRolePermission { get; set; }
        public virtual DbSet<WebQuoteUserPreference> WebQuoteUserPreference { get; set; }
        public virtual DbSet<WebQuoteUsers> WebQuoteUsers { get; set; }
        public virtual DbSet<IdentityValues> IdentityValues { get; set; }
        public virtual DbSet<NonIdentityValues> NonIdentityValues { get; set; }
        public virtual DbSet<Log4netErrorLog> Log4netErrorLog { get; set; }
        public virtual DbSet<BrokerCoordinate> BrokerCoordinate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public ELD_PRODUCTION_DXGContext(DbContextOptions<ELD_PRODUCTION_DXGContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrokerCoordinate>(entity =>
            {
                entity.ToTable("Broker_Coordinate");

                entity.Property(e => e.BrokerId).HasColumnName("Broker_Id");

                entity.Property(e => e.BrokerNo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LastChangedId).HasMaxLength(50);
            });

            modelBuilder.Entity<LkpStateRegion>(entity =>
            {
                entity.ToTable("lkp_State_Region");

                entity.Property(e => e.LkpStateRegionId).HasColumnName("Lkp_State_RegionId");

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.LkpStateTypeid).HasColumnName("lkpSTATE_TYPEID");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BrMerge>(entity =>
            {
                entity.HasKey(e => e.Bnodupe);

                entity.ToTable("BR_MERGE");

                entity.Property(e => e.Bnodupe)
                    .HasColumnName("BNODUPE")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bnouse)
                    .HasColumnName("BNOUSE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RequestBy)
                    .HasColumnName("REQUEST_BY")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("REQUEST_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.RunDate)
                    .HasColumnName("RUN_DATE")
                    .HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<IdentityValues>(entity =>
            {
                entity.HasKey(e => e.TableName);

                entity.ToTable("IDENTITY_VALUES");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<NonIdentityValues>(entity =>
            {
                entity.HasKey(e => e.Descrip);

                entity.ToTable("NON_IDENTITY_VALUES");

                entity.Property(e => e.Descrip)
                    .HasColumnName("DESCRIP")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUsedValue).HasColumnName("LAST_USED_VALUE");
            });

            modelBuilder.Entity<BrokerAgent>(entity =>
            {
                entity.ToTable("BROKER_AGENT");

                entity.Property(e => e.BrokerAgentId)
                    .HasColumnName("BROKER_AGENT_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrokerAddedDate)
                    .HasColumnName("BROKER_ADDED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerAgentAddress1)
                    .HasColumnName("BROKER_AGENT_ADDRESS1")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentAddress2)
                    .HasColumnName("BROKER_AGENT_ADDRESS2")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentCity)
                    .HasColumnName("BROKER_AGENT_CITY")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentCode)
                    .IsRequired()
                    .HasColumnName("BROKER_AGENT_CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentCompany)
                    .HasColumnName("BROKER_AGENT_COMPANY")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentFirstName)
                    .HasColumnName("BROKER_AGENT_FIRST_NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentLastName)
                    .HasColumnName("BROKER_AGENT_LAST_NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentState)
                    .HasColumnName("BROKER_AGENT_STATE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentTitle)
                    .HasColumnName("BROKER_AGENT_TITLE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentZip)
                    .HasColumnName("BROKER_AGENT_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgreeDate)
                    .HasColumnName("BROKER_AGREE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasColumnType("char(3)");
            });

            modelBuilder.Entity<BrokerContact>(entity =>
            {
                entity.ToTable("BROKER_CONTACT");

                entity.HasIndex(e => e.BrokerId)
                    .HasName("IX_BROKER_ID");

                entity.HasIndex(e => new { e.BrokerId, e.BrokerContactNo })
                    .HasName("idx_BR_ID_BCODE_BCONTACT");

                entity.Property(e => e.BrokerContactId)
                    .HasColumnName("BROKER_CONTACT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Bremoved)
                    .HasColumnName("BREMOVED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerContactNo)
                    .HasColumnName("BROKER_CONTACT_NO")
                    .HasColumnType("char(2)");

                entity.Property(e => e.BrokerContactType)
                    .HasColumnName("BROKER_CONTACT_TYPE")
                    .HasColumnType("char(1)");

                entity.Property(e => e.BrokerEmail)
                    .HasColumnName("BROKER_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerFax)
                    .HasColumnName("BROKER_FAX")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerFirstName)
                    .HasColumnName("BROKER_FIRST_NAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerId)
                    .HasColumnName("BROKER_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerLastName)
                    .HasColumnName("BROKER_LAST_NAME")
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerNo)
                    .HasColumnName("BROKER_NO")
                    .HasColumnType("char(5)");

                entity.Property(e => e.BrokerTel)
                    .HasColumnName("BROKER_TEL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerTitle)
                    .HasColumnName("BROKER_TITLE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SalesForceLinkId)
                    .HasColumnName("SalesForceLinkID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unsubscribe)
                    .HasColumnName("UNSUBSCRIBE")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.HasOne(d => d.Broker)
                    .WithMany(p => p.BrokerContact)
                    .HasForeignKey(d => d.BrokerId)
                    .HasConstraintName("FK_BROKER_CONTACT_BROKER_MASTER");
            });

            modelBuilder.Entity<BrokerLicense>(entity =>
            {
                entity.HasKey(e => e.LicenseId);

                entity.ToTable("BROKER_LICENSE");

                entity.Property(e => e.LicenseId)
                    .HasColumnName("LICENSE_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerAgentCode)
                    .HasColumnName("BROKER_AGENT_CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgentId)
                    .HasColumnName("BROKER_AGENT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerAgreeDate)
                    .HasColumnName("BROKER_AGREE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerAgreeReceived).HasColumnName("BROKER_AGREE_RECEIVED");

                entity.Property(e => e.BrokerAppointExpirationDate)
                    .HasColumnName("BROKER_APPOINT_EXPIRATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerId)
                    .HasColumnName("BROKER_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerLicense1).HasColumnName("BROKER_LICENSE");

                entity.Property(e => e.BrokerLicenseCode)
                    .HasColumnName("BROKER_LICENSE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerLicensePol)
                    .HasColumnName("BROKER_LICENSE_POL")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerLicenseReleaseDate)
                    .HasColumnName("BROKER_LICENSE_RELEASE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerLicenseSta)
                    .HasColumnName("BROKER_LICENSE_STA")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerNo)
                    .HasColumnName("BROKER_NO")
                    .HasColumnType("char(5)");

                entity.Property(e => e.LastAppointDate)
                    .HasColumnName("LAST_APPOINT_DATE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseStateExpirationDate)
                    .HasColumnName("LICENSE_STATE_EXPIRATION_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasColumnType("char(5)");

                entity.Property(e => e.LinkId)
                    .HasColumnName("LINK_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.SlLicNoSta)
                    .HasColumnName("SL_LIC_NO_STA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SurplusLinesExpirationDate)
                    .HasColumnName("SURPLUS_LINES_EXPIRATION_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BrokerMaster>(entity =>
            {
                entity.HasKey(e => e.BrokerId);

                entity.ToTable("BROKER_MASTER");

                entity.Property(e => e.BrokerId)
                    .HasColumnName("BROKER_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BillMethod)
                    .HasColumnName("BILL_METHOD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAddress)
                    .HasColumnName("BROKER_ADDRESS")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAddress2)
                    .HasColumnName("BROKER_ADDRESS2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerAgreementDate)
                    .HasColumnName("BROKER_AGREEMENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerAgreementReceived)
                    .IsRequired()
                    .HasColumnName("BROKER_AGREEMENT_RECEIVED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerAssignedDate)
                    .HasColumnName("BROKER_ASSIGNED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.BrokerCity)
                    .HasColumnName("BROKER_CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerMasterPhone)
                    .HasColumnName("BROKER_MASTER_PHONE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerName)
                    .HasColumnName("BROKER_NAME")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerNo)
                    .IsRequired()
                    .HasColumnName("BROKER_NO")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerRank)
                    .HasColumnName("BROKER_RANK")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerRegion)
                    .HasColumnName("BROKER_REGION")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerSta)
                    .HasColumnName("BROKER_STA")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerTaxId)
                    .HasColumnName("BROKER_TAX_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerType)
                    .HasColumnName("BROKER_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerZip)
                    .HasColumnName("BROKER_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionPct)
                    .HasColumnName("COMMISSION_PCT")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Hide)
                    .IsRequired()
                    .HasColumnName("HIDE")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.HouseId)
                    .HasColumnName("HOUSE_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.LastAppReceived)
                    .HasColumnName("LAST_APP_RECEIVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MarketingNotes)
                    .HasColumnName("Marketing_Notes")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Merged)
                    .IsRequired()
                    .HasColumnName("MERGED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PrmNo).HasColumnName("PRM_NO");

                entity.Property(e => e.RelationshipManager)
                    .HasColumnName("RELATIONSHIP_MANAGER")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.SalesForceLinkId)
                    .HasColumnName("SalesForceLinkID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SlLicNo)
                    .HasColumnName("SL_LIC_NO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SurplusApplied)
                    .HasColumnName("SURPLUS_APPLIED")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SurplusLicExpDate)
                    .HasColumnName("SURPLUS_LIC_EXP_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitedRegion)
                    .HasColumnName("VISITED_REGION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EldUsers>(entity =>
            {
                entity.HasKey(e => e.EldUserId);

                entity.ToTable("eld_Users");

                entity.Property(e => e.EldUserId).HasColumnName("ELD_UserID");

                entity.Property(e => e.AdGuid).HasColumnName("AD_Guid");

                entity.Property(e => e.CodesId)
                    .HasColumnName("CODES_ID")
                    .HasColumnType("char(6)");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_Of_Birth")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("Display_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Email).HasColumnType("nchar(50)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.Ihazard)
                    .HasColumnName("IHazard")
                    .HasColumnType("char(3)");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasColumnType("char(3)");

                entity.Property(e => e.LastChangedOn)
                    .HasColumnName("LAST_CHANGED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LoginName)
                    .HasColumnName("Login_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");

                entity.Property(e => e.OfficeLocationId).HasColumnName("Office_Location_Id");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PositionTitle)
                    .HasColumnName("Position_Title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TitleLevel).HasColumnName("TITLE_LEVEL");

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.UserGuid).HasColumnName("User_Guid");

                entity.Property(e => e.UsersRowVersion)
                    .HasColumnName("Users_Row_Version")
                    .IsRowVersion();
            });

            modelBuilder.Entity<SsEldUserRole>(entity =>
            {
                entity.HasKey(e => e.SsUserRoleId);

                entity.ToTable("SS_EldUser_Role");

                entity.Property(e => e.SsUserRoleId).HasColumnName("SS_User_RoleID");

                entity.Property(e => e.SsEldUserId).HasColumnName("SS_eld_UserID");

                entity.Property(e => e.SsRoleId).HasColumnName("SS_RoleID");

                entity.HasOne(d => d.SsEldUser)
                    .WithMany(p => p.SsEldUserRole)
                    .HasForeignKey(d => d.SsEldUserId)
                    .HasConstraintName("FK_SS_EldUser_Role_eld_Users");

                entity.HasOne(d => d.SsRole)
                    .WithMany(p => p.SsEldUserRole)
                    .HasForeignKey(d => d.SsRoleId)
                    .HasConstraintName("FK_SS_EldUser_Role_SS_Role");
            });

            modelBuilder.Entity<SsPermission>(entity =>
            {
                entity.ToTable("SS_Permission");

                entity.Property(e => e.SsPermissionId).HasColumnName("SS_PermissionID");

                entity.Property(e => e.AppName)
                    .HasColumnName("App_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionName)
                    .HasColumnName("Permission_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SsRole>(entity =>
            {
                entity.ToTable("SS_Role");

                entity.Property(e => e.SsRoleId).HasColumnName("SS_RoleID");

                entity.Property(e => e.AppName)
                    .HasColumnName("App_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasColumnName("Role_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SsRolePermission>(entity =>
            {
                entity.ToTable("SS_Role_Permission");

                entity.Property(e => e.SsRolePermissionId).HasColumnName("SS_Role_PermissionID");

                entity.Property(e => e.OtherDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SsPermissionId).HasColumnName("SS_PermissionID");

                entity.Property(e => e.SsRoleId).HasColumnName("SS_RoleID");

                entity.HasOne(d => d.SsPermission)
                    .WithMany(p => p.SsRolePermission)
                    .HasForeignKey(d => d.SsPermissionId)
                    .HasConstraintName("FK_SS_Role_Permission_SS_Permission");

                entity.HasOne(d => d.SsRole)
                    .WithMany(p => p.SsRolePermission)
                    .HasForeignKey(d => d.SsRoleId)
                    .HasConstraintName("FK_SS_Role_Permission_SS_Role");
            });

            modelBuilder.Entity<WebQuoteUserPreference>(entity =>
            {
                entity.Property(e => e.WebQuoteUserPreferenceId).HasColumnName("WebQuoteUserPreferenceID");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(50);

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.WebQuoteUserPreference)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("fk_LoginID");
            });

            modelBuilder.Entity<WebQuoteUsers>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(50);

                entity.Property(e => e.LoginPassword).IsRequired();

                entity.Property(e => e.UserLinkId).HasColumnName("UserLinkID");
            });

            modelBuilder.Entity<Log4netErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrorLogId);

                entity.ToTable("log4netERROR_LOG");

                entity.Property(e => e.ErrorLogId).HasColumnName("ERROR_LOG_ID");

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime)
                    .HasColumnName("DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MachineName)
                    .HasColumnName("MACHINE_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("MESSAGE")
                    .HasColumnType("text");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
