using Microsoft.EntityFrameworkCore;

namespace DataRepository.Models.ELD.Prod
{
    public partial class ELD_PRODUCTIONContext : DbContext
    {
        public ELD_PRODUCTIONContext() { }

        public ELD_PRODUCTIONContext(DbContextOptions<ELD_PRODUCTIONContext> options) : base(options) { }

        public virtual DbSet<AcctMaster> AcctMaster { get; set; }

        public virtual DbSet<AcctTrans> AcctTrans { get; set; }

        public virtual DbSet<ArTrans> ArTrans { get; set; }

        public virtual DbSet<BrokerContact> BrokerContact { get; set; }

        public virtual DbSet<BrokerLicense> BrokerLicense { get; set; }

        public virtual DbSet<BrokerMaster> BrokerMaster { get; set; }

        public virtual DbSet<ClmMaster> ClmMaster { get; set; }

        public virtual DbSet<ClmTrans> ClmTrans { get; set; }

        public virtual DbSet<EldUsers> EldUsers { get; set; }

        public virtual DbSet<InsuredInfo> InsuredInfo { get; set; }

        public virtual DbSet<LkpSubmissionStatus> LkpSubmissionStatus { get; set; }

        public virtual DbSet<SsEldUserRole> SsEldUserRole { get; set; }

        public virtual DbSet<SsPermission> SsPermission { get; set; }

        public virtual DbSet<SsRole> SsRole { get; set; }

        public virtual DbSet<SsRolePermission> SsRolePermission { get; set; }

        public virtual DbSet<WebQuoteUsers> WebQuoteUsers { get; set; }

        public virtual DbSet<UndLkpCoverageType> UndLkpCoverageType { get; set; }

        public virtual DbSet<EldDepartment> EldDepartment { get; set; }

        public virtual DbSet<EldRefGroup> EldRefGroup { get; set; }

        public virtual DbSet<AdditionalEntity> AdditionalEntity { get; set; }

        public virtual DbSet<AdditionalEntityOwner> AdditionalEntityOwner { get; set; }

        public virtual DbSet<CorpOwner> CorpOwner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalEntity>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.Property(e => e.Dbaname)
                    .HasColumnName("DBAName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LegalName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdditionalEntityOwner>(entity =>
            {
                entity.HasKey(e => e.EntityOwnerId)
                    .HasName("PK_AdditionalEntityOwnerId");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkEntity)
                    .WithMany(p => p.AdditionalEntityOwner)
                    .HasForeignKey(d => d.FkEntityId)
                    .HasConstraintName("Fk_AdditionalEntityId");
            });

            modelBuilder.Entity<CorpOwner>(entity =>
            {
                entity.Property(e => e.CorpOwnerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EldDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("eld_Department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DepartmentAbbreviatedName)
                    .HasColumnName("Department_Abbreviated_Name")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentHeadId).HasColumnName("Department_Head_Id");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("Department_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentRowVersion)
                    .HasColumnName("Department_Row_Version")
                    .IsRowVersion();
            });

            modelBuilder.Entity<EldRefGroup>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.DepartmentId });

                entity.ToTable("eld_refGroup");

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.GroupAbbreviatedName)
                    .HasColumnName("Group_Abbreviated_Name")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.GroupHeadId).HasColumnName("Group_Head_Id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("Group_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupRowVersion)
                    .HasColumnName("Group_Row_Version")
                    .IsRowVersion();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EldRefGroup)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eld_refGroup_eld_Department");
            });

            modelBuilder.Entity<UndLkpCoverageType>(entity =>
            {
                entity.HasKey(e => e.CoverageTypeId);

                entity.ToTable("und_lkpCoverageType");

                entity.Property(e => e.CoverageTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CoverageTypeDecription)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AcctMaster>(entity =>
            {
                entity.HasKey(e => e.AcctId);

                entity.ToTable("ACCT_MASTER");

                entity.HasIndex(e => e.PolNo)
                    .HasName("idxPOLNO");

                entity.HasIndex(e => new { e.AppNo, e.AppReceivedDate })
                    .HasName("idx_ano_adate_acct_master")
                    .IsUnique();

                entity.HasIndex(e => new { e.AcctId, e.PolNo, e.PolEffectiveDate, e.AppNo, e.AppReceivedDate, e.Location, e.MailId })
                    .HasName("idxACCT_MASTER_MAILID");

                entity.Property(e => e.AcctId)
                    .HasColumnName("ACCT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Acbr)
                    .HasColumnName("ACBR")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AcctCycle)
                    .HasColumnName("ACCT_CYCLE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AcctNo)
                    .HasColumnName("ACCT_NO")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AnnualizedPremium)
                    .HasColumnName("ANNUALIZED_PREMIUM")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AppAssignDate)
                    .HasColumnName("APP_ASSIGN_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.AppForm)
                    .HasColumnName("APP_FORM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.AppNo)
                    .HasColumnName("APP_NO")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AppReceivedDate)
                    .HasColumnName("APP_RECEIVED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.AutHist)
                    .HasColumnName("AUT_HIST")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BinderExpDate)
                    .HasColumnName("BINDER_EXP_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.BnkrDate)
                    .HasColumnName("BNKR_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Cleared).HasColumnName("CLEARED");

                entity.Property(e => e.CompanyPaper)
                    .IsRequired()
                    .HasColumnName("COMPANY_PAPER")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.CompanyRank)
                    .HasColumnName("COMPANY_RANK")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CurrCvgExpDate)
                    .HasColumnName("CURR_CVG_EXP_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ExecutiveDirector)
                    .HasColumnName("EXECUTIVE_DIRECTOR")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiringYrmo)
                    .HasColumnName("EXPIRING_YRMO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.FwStat)
                    .HasColumnName("FW_STAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InFrom)
                    .HasColumnName("IN_FROM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IndicationDate)
                    .HasColumnName("INDICATION_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.InitialSubmissionDate)
                    .HasColumnName("INITIAL_SUBMISSION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsurAgreement)
                    .HasColumnName("INSUR_AGREEMENT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredRanksId)
                    .HasColumnName("INSURED_RANKS_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MailId)
                    .HasColumnName("MAIL_ID")
                    .HasColumnType("ELD_BIGINT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.MaxLimit).HasColumnName("MAX_LIMIT");

                entity.Property(e => e.MaxTerm).HasColumnName("MAX_TERM");

                entity.Property(e => e.PfcCodeId)
                    .HasColumnName("PFC_CODE_ID")
                    .HasDefaultValueSql("create default [PFC_CODE] as 1");

                entity.Property(e => e.PolEffectiveDate)
                    .HasColumnName("POL_EFFECTIVE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PolForm)
                    .HasColumnName("POL_FORM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.PolFormId)
                    .HasColumnName("POL_FORM_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PolNo)
                    .HasColumnName("POL_NO")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PolNoteByClm).HasColumnName("POL_NOTE_by_CLM");

                entity.Property(e => e.PplDate)
                    .HasColumnName("PPL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PpldateDescription)
                    .HasColumnName("PPLDateDescription")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumFinanceCompany)
                    .HasColumnName("PREMIUM_FINANCE_COMPANY")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PremiumOverRide).HasColumnName("PREMIUM_OVER_RIDE");

                entity.Property(e => e.Product)
                    .HasColumnName("PRODUCT")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.QuoteDate)
                    .HasColumnName("QUOTE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.QuoteExpDate)
                    .HasColumnName("QUOTE_EXP_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.QuoteNeedbyDate)
                    .HasColumnName("QUOTE_NEEDBY_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.RenewedStatus)
                    .IsRequired()
                    .HasColumnName("RENEWED_STATUS")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.SenderId)
                    .HasColumnName("SENDER_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Transfer).HasColumnName("TRANSFER");

                entity.Property(e => e.TrnMethod)
                    .HasColumnName("TRN_METHOD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UnderwritingManagerId)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AcctTrans>(entity =>
            {
                entity.ToTable("ACCT_TRANS");

                entity.HasIndex(e => e.AcctId)
                    .HasName("idxACCT_TRANS_ACCT_ID");

                entity.HasIndex(e => e.BrokerId)
                    .HasName("IX_BROKER_ID");

                entity.HasIndex(e => e.InsuredInfoId)
                    .HasName("IX_INSURED_INFO_ID");

                entity.HasIndex(e => e.PolEffectiveDate)
                    .HasName("idx_ACCT_TRANS_PEDATE");

                entity.HasIndex(e => e.PolNo)
                    .HasName("idxACCT_TRANS_POL_NO");

                entity.HasIndex(e => new { e.AcctId, e.PolLimit, e.AcctStage })
                    .HasName("idx_ACCT_STAGE");

                entity.Property(e => e.AcctTransId)
                    .HasColumnName("ACCT_TRANS_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AcctCycle)
                    .HasColumnName("ACCT_CYCLE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AcctId).HasColumnName("ACCT_ID");

                entity.Property(e => e.AcctNo)
                    .HasColumnName("ACCT_NO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AcctStage)
                    .HasColumnName("ACCT_STAGE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AcctSubStage)
                    .IsRequired()
                    .HasColumnName("ACCT_SUB_STAGE")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.AcctTransNotes).HasColumnName("ACCT_TRANS_NOTES");

                entity.Property(e => e.AppNo)
                    .HasColumnName("APP_NO")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AppReceivedDate)
                    .HasColumnName("APP_RECEIVED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Billingaccountnumber)
                    .HasColumnName("BILLINGACCOUNTNUMBER")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Billingtypeid).HasColumnName("BILLINGTYPEID");

                entity.Property(e => e.BrokerCommisPct)
                    .HasColumnName("BROKER_COMMIS_PCT")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerContactId).HasColumnName("BROKER_CONTACT_ID");

                entity.Property(e => e.BrokerId).HasColumnName("BROKER_ID");

                entity.Property(e => e.BrokerProgram)
                    .IsRequired()
                    .HasColumnName("BROKER_PROGRAM")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.CboLimit)
                    .HasColumnName("CBO_LIMIT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ClmNotes).HasColumnName("CLM_NOTES");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyRateUsed).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.GeneralProduct)
                    .IsRequired()
                    .HasColumnName("GENERAL_PRODUCT")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.InFrom)
                    .HasColumnName("IN_FROM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IndustryCode)
                    .IsRequired()
                    .HasColumnName("INDUSTRY_CODE")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.InsuredInfoId).HasColumnName("INSURED_INFO_ID");

                entity.Property(e => e.IssuedDate)
                    .HasColumnName("ISSUED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MasterSheetId).HasColumnName("MASTER_SHEET_ID");

                entity.Property(e => e.NaicsIndustryCode)
                    .HasColumnName("NAICS_INDUSTRY_CODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Paymentplanid).HasColumnName("PAYMENTPLANID");

                entity.Property(e => e.PolEffectiveDate)
                    .HasColumnName("POL_EFFECTIVE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PolExcessLimit)
                    .HasColumnName("POL_EXCESS_LIMIT")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PolExpirationDate)
                    .HasColumnName("POL_EXPIRATION_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PolLimit)
                    .HasColumnName("POL_LIMIT")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PolNo)
                    .HasColumnName("POL_NO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PolRetention)
                    .HasColumnName("POL_RETENTION")
                    .HasMaxLength(29)
                    .IsUnicode(false);

                entity.Property(e => e.Ptranid)
                    .HasColumnName("PTRANID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Ptrans)
                    .HasColumnName("PTRANS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RetSetId).HasColumnName("RET_SET_ID");

                entity.Property(e => e.RmCycle)
                    .HasColumnName("RM_CYCLE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.TaxLocator)
                    .HasColumnName("TAX_LOCATOR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransEffectiveDate)
                    .HasColumnName("TRANS_EFFECTIVE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UnderwriterId)
                    .IsRequired()
                    .HasColumnName("UNDERWRITER_ID")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.HasOne(d => d.Acct)
                    .WithMany(p => p.AcctTrans)
                    .HasForeignKey(d => d.AcctId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCT_TRANS_ACCT_MASTER");

                entity.HasOne(d => d.Broker)
                    .WithMany(p => p.AcctTrans)
                    .HasForeignKey(d => d.BrokerId)
                    .HasConstraintName("FK_ACCT_TRANS_BROKER_MASTER");

                entity.HasOne(d => d.InsuredInfo)
                    .WithMany(p => p.AcctTrans)
                    .HasForeignKey(d => d.InsuredInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCT_TRANS_INSURED_INFO");
            });

            modelBuilder.Entity<ArTrans>(entity =>
            {
                entity.HasKey(e => e.ArId);

                entity.ToTable("AR_TRANS");

                entity.HasIndex(e => e.AcctId)
                    .HasName("IX_ACCT_ID");

                entity.HasIndex(e => e.AcctTransId)
                    .HasName("IX_ACCT_TRANS_ID");

                entity.HasIndex(e => e.InvoiceNo)
                    .HasName("idxAR_TRANS_INVOICE_NO");

                entity.HasIndex(e => new { e.AcctId, e.ArTransYrmo, e.ArTransType, e.GrossPremium, e.ProfitCtrId })
                    .HasName("idx_PROF_CTR_ID");

                entity.HasIndex(e => new { e.ArId, e.AcctId, e.ArTransYrmo, e.ProfitCtrId, e.ArTransType })
                    .HasName("idx_AR_TRANS_TYPE");

                entity.Property(e => e.ArId)
                    .HasColumnName("AR_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AcctId)
                    .HasColumnName("ACCT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AcctTransId)
                    .HasColumnName("ACCT_TRANS_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.AppNo)
                    .HasColumnName("APP_NO")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AppReceivedDate)
                    .HasColumnName("APP_RECEIVED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ArTransDate)
                    .HasColumnName("AR_TRANS_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ArTransType)
                    .IsRequired()
                    .HasColumnName("AR_TRANS_TYPE")
                    .HasColumnType("ELD_CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql(@"

create default [SPACE] as ' '
");

                entity.Property(e => e.ArTransYrmo)
                    .HasColumnName("AR_TRANS_YRMO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BillBrokerId).HasColumnName("BILL_BROKER_ID");

                entity.Property(e => e.CheckDisbursementDate)
                    .HasColumnName("CHECK_DISBURSEMENT_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CheckId)
                    .HasColumnName("CHECK_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CheckNo)
                    .HasColumnName("CHECK_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate)
                    .HasColumnName("DUE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.GrossPremium)
                    .HasColumnName("GROSS_PREMIUM")
                    .HasColumnType("ELD_NUMERIC")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.InFrom)
                    .HasColumnName("IN_FROM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentNo)
                    .HasColumnName("INSTALLMENT_NO")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("INVOICE_NO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NetPremium)
                    .HasColumnName("NET_PREMIUM")
                    .HasColumnType("ELD_NUMERIC")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ProfitCtrId).HasColumnName("PROFIT_CTR_ID");

                entity.Property(e => e.ReinsPremium)
                    .HasColumnName("REINS_PREMIUM")
                    .HasColumnType("ELD_NUMERIC")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.SelectRec)
                    .IsRequired()
                    .HasColumnName("SELECT_REC")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.HasOne(d => d.Acct)
                    .WithMany(p => p.ArTrans)
                    .HasForeignKey(d => d.AcctId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AR_TRANS_ACCT_MASTER");

                entity.HasOne(d => d.AcctTrans)
                    .WithMany(p => p.ArTrans)
                    .HasForeignKey(d => d.AcctTransId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AR_TRANS_ACCT_TRANS");

                entity.HasOne(d => d.BillBroker)
                    .WithMany(p => p.ArTrans)
                    .HasForeignKey(d => d.BillBrokerId)
                    .HasConstraintName("FK_AR_TRANS_BROKER_MASTER1");
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
                    .IsRequired()
                    .HasColumnName("BREMOVED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.BrokerContactNo)
                    .HasColumnName("BROKER_CONTACT_NO")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BrokerContactType)
                    .HasColumnName("BROKER_CONTACT_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

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
                    .HasMaxLength(5)
                    .IsUnicode(false);

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
                    .IsRequired()
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
                    .HasMaxLength(5)
                    .IsUnicode(false);

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
                    .HasMaxLength(5)
                    .IsUnicode(false);

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

                entity.Property(e => e.EntryMethod)
                    .HasColumnName("ENTRY_METHOD")
                    .HasMaxLength(3)
                    .IsUnicode(false);

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

            modelBuilder.Entity<ClmMaster>(entity =>
            {
                entity.ToTable("CLM_MASTER");

                entity.HasIndex(e => e.AcctId)
                    .HasName("IX_ACCT_ID");

                entity.Property(e => e.ClmMasterId)
                    .HasColumnName("CLM_MASTER_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ASideCvg).HasColumnName("A_SIDE_CVG");

                entity.Property(e => e.AcctCycle)
                    .HasColumnName("ACCT_CYCLE")
                    .HasMaxLength(2);

                entity.Property(e => e.AcctId).HasColumnName("ACCT_ID");

                entity.Property(e => e.AcctNo)
                    .HasColumnName("ACCT_NO")
                    .HasMaxLength(12);

                entity.Property(e => e.Attorney)
                    .HasColumnName("ATTORNEY")
                    .HasMaxLength(3);

                entity.Property(e => e.BasisForDenial1)
                    .HasColumnName("BASIS_FOR_DENIAL_1")
                    .HasMaxLength(2);

                entity.Property(e => e.BasisForDenial2)
                    .HasColumnName("BASIS_FOR_DENIAL_2")
                    .HasMaxLength(2);

                entity.Property(e => e.BasisForDenial3)
                    .HasColumnName("BASIS_FOR_DENIAL_3")
                    .HasMaxLength(2);

                entity.Property(e => e.BodilyInjury)
                    .HasColumnName("BODILY_INJURY")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Capped)
                    .HasColumnName("CAPPED")
                    .HasMaxLength(1);

                entity.Property(e => e.CaseSummary)
                    .HasColumnName("CASE_SUMMARY")
                    .IsUnicode(false);

                entity.Property(e => e.Cause1)
                    .HasColumnName("CAUSE1")
                    .HasMaxLength(3);

                entity.Property(e => e.Cause2)
                    .HasColumnName("CAUSE2")
                    .HasMaxLength(3);

                entity.Property(e => e.Cause3)
                    .HasColumnName("CAUSE3")
                    .HasMaxLength(3);

                entity.Property(e => e.CedLaePaid)
                    .HasColumnName("CED_LAE_PAID")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CedLaeRes)
                    .HasColumnName("CED_LAE_RES")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CedLossPaid)
                    .HasColumnName("CED_LOSS_PAID")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CedLossRes)
                    .HasColumnName("CED_LOSS_RES")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ClaimStatus)
                    .HasColumnName("CLAIM_STATUS")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Claimant)
                    .HasColumnName("CLAIMANT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ClassAction)
                    .HasColumnName("CLASS_ACTION")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ClmCreatedDate)
                    .HasColumnName("CLM_CREATED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ClmMadeDate)
                    .HasColumnName("CLM_MADE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ClmNo)
                    .IsRequired()
                    .HasColumnName("CLM_NO")
                    .HasMaxLength(11);

                entity.Property(e => e.ClmRelatedType)
                    .HasColumnName("CLM_RELATED_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ClmRet)
                    .HasColumnName("CLM_RET")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ClmReviewDate)
                    .HasColumnName("CLM_REVIEW_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ClmStatus)
                    .HasColumnName("CLM_STATUS")
                    .HasMaxLength(3);

                entity.Property(e => e.ClmType)
                    .HasColumnName("CLM_TYPE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ClosedDate)
                    .HasColumnName("CLOSED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ContactInfo)
                    .HasColumnName("CONTACT_INFO")
                    .IsUnicode(false);

                entity.Property(e => e.CoverageCounsel)
                    .HasColumnName("COVERAGE_COUNSEL")
                    .HasMaxLength(3);

                entity.Property(e => e.CoverageDefense)
                    .HasColumnName("COVERAGE_DEFENSE")
                    .HasMaxLength(21);

                entity.Property(e => e.CoverageDefenseEst)
                    .HasColumnName("COVERAGE_DEFENSE_EST")
                    .HasMaxLength(2);

                entity.Property(e => e.CoverageDenied)
                    .HasColumnName("COVERAGE_DENIED")
                    .HasMaxLength(3);

                entity.Property(e => e.CoverageType)
                    .HasColumnName("COVERAGE_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CvgContactId)
                    .HasColumnName("CVG_CONTACT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CvgLegalId)
                    .HasColumnName("CVG_LEGAL_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.CvgUpdateStatus)
                    .HasColumnName("CVG_UPDATE_STATUS")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DamageDevPotEst)
                    .HasColumnName("DAMAGE_DEV_POT_EST")
                    .HasMaxLength(2);

                entity.Property(e => e.Defendant1)
                    .HasColumnName("DEFENDANT1")
                    .HasMaxLength(2);

                entity.Property(e => e.Defendant2)
                    .HasColumnName("DEFENDANT2")
                    .HasMaxLength(50);

                entity.Property(e => e.Defendant3)
                    .HasColumnName("DEFENDANT3")
                    .HasMaxLength(50);

                entity.Property(e => e.DefenseContactId)
                    .HasColumnName("DEFENSE_CONTACT_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.DefenseFirmCode)
                    .HasColumnName("DEFENSE_FIRM_CODE")
                    .HasMaxLength(4);

                entity.Property(e => e.DefenseLegalId)
                    .HasColumnName("DEFENSE_LEGAL_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.DerivativeSuit)
                    .HasColumnName("DERIVATIVE_SUIT")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.DiscoveryDate)
                    .HasColumnName("DISCOVERY_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Imaged)
                    .HasColumnName("IMAGED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.IndustryHealth)
                    .HasColumnName("INDUSTRY_HEALTH")
                    .HasMaxLength(3);

                entity.Property(e => e.Journal)
                    .HasColumnName("JOURNAL")
                    .IsUnicode(false);

                entity.Property(e => e.JurisCourt)
                    .HasColumnName("JURIS_COURT")
                    .HasMaxLength(1);

                entity.Property(e => e.JurisState)
                    .HasColumnName("JURIS_STATE")
                    .HasMaxLength(2);

                entity.Property(e => e.LaePaidAuthority)
                    .HasColumnName("LAE_PAID_AUTHORITY")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.LastAdjustDate)
                    .HasColumnName("LAST_ADJUST_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3);

                entity.Property(e => e.LastTransDate)
                    .HasColumnName("LAST_TRANS_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LitigationDate)
                    .HasColumnName("LITIGATION_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LongFormChecked)
                    .IsRequired()
                    .HasColumnName("LONG_FORM_CHECKED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.LossPaidAuthority)
                    .HasColumnName("LOSS_PAID_AUTHORITY")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.MemberCode)
                    .HasColumnName("MEMBER_CODE")
                    .HasMaxLength(7);

                entity.Property(e => e.NextUpdateDate)
                    .HasColumnName("NEXT_UPDATE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.NoticeDate)
                    .HasColumnName("NOTICE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.NoticeType)
                    .HasColumnName("NOTICE_TYPE")
                    .HasMaxLength(2);

                entity.Property(e => e.PaidA)
                    .HasColumnName("PAID_A")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidB)
                    .HasColumnName("PAID_B")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidB2)
                    .HasColumnName("PAID_B2")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidB3)
                    .HasColumnName("PAID_B3")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidC)
                    .HasColumnName("PAID_C")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PlaintiffFirmCode)
                    .HasColumnName("PLAINTIFF_FIRM_CODE")
                    .HasMaxLength(4);

                entity.Property(e => e.PlaintiffType)
                    .HasColumnName("PLAINTIFF_TYPE")
                    .HasMaxLength(2);

                entity.Property(e => e.PotentialOverincurred)
                    .HasColumnName("POTENTIAL_OVERINCURRED")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PotentialSeverityEst)
                    .HasColumnName("POTENTIAL_SEVERITY_EST")
                    .HasMaxLength(2);

                entity.Property(e => e.RenewalComments)
                    .HasColumnName("RENEWAL_COMMENTS")
                    .IsUnicode(false);

                entity.Property(e => e.RenewalCommentsDate)
                    .HasColumnName("RENEWAL_COMMENTS_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ReopenDate)
                    .HasColumnName("REOPEN_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ReopenReason)
                    .HasColumnName("REOPEN_REASON")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReserveA)
                    .HasColumnName("RESERVE_A")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB)
                    .HasColumnName("RESERVE_B")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB2)
                    .HasColumnName("RESERVE_B2")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB3)
                    .HasColumnName("RESERVE_B3")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB31)
                    .HasColumnName("RESERVE_B31")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveC)
                    .HasColumnName("RESERVE_C")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveConfidenceEst)
                    .HasColumnName("RESERVE_CONFIDENCE_EST")
                    .HasMaxLength(2);

                entity.Property(e => e.StatusRequestDate)
                    .HasColumnName("STATUS_REQUEST_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SuitDate)
                    .HasColumnName("SUIT_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.SuitFiled)
                    .IsRequired()
                    .HasColumnName("SUIT_FILED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.SummaryJudgeDate)
                    .HasColumnName("SUMMARY_JUDGE_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.TotalDamages)
                    .HasColumnName("TOTAL_DAMAGES")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.TrialDate)
                    .HasColumnName("TRIAL_DATE")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.Acct)
                    .WithMany(p => p.ClmMaster)
                    .HasForeignKey(d => d.AcctId)
                    .HasConstraintName("FK_CLM_MASTER_ACCT_MASTER1");
            });

            modelBuilder.Entity<ClmTrans>(entity =>
            {
                entity.ToTable("CLM_TRANS");

                entity.HasIndex(e => new { e.ClmTransNo, e.ClmMasterId, e.ClmTransYearMonth })
                    .HasName("idx_CLM_TRANS_YEAR_MONTH");

                entity.HasIndex(e => new { e.ClmNo, e.ClmTransNo, e.ClmMasterId, e.ClmTrans1 })
                    .HasName("idx_CLM_TRANS");

                entity.HasIndex(e => new { e.ReserveAAdjust, e.ReserveBAdjust, e.ReserveCAdjust, e.ClmTransYearMonth, e.PaidAAdjust, e.PaidBAdjust, e.PaidCAdjust, e.TransCedLossRes, e.TransCedLossPaid, e.TransCedLaeRes, e.TransCedLaePaid, e.ClmNo })
                    .HasName("idx_CLMTRANS_CLMNO");

                entity.Property(e => e.ClmTransId)
                    .HasColumnName("CLM_TRANS_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcctId).HasColumnName("ACCT_ID");

                entity.Property(e => e.CheckDate)
                    .HasColumnName("CHECK_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.CheckNo)
                    .HasColumnName("CHECK_NO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClmMasterId).HasColumnName("CLM_MASTER_ID");

                entity.Property(e => e.ClmNo)
                    .HasColumnName("CLM_NO")
                    .HasMaxLength(11);

                entity.Property(e => e.ClmProcessDate)
                    .HasColumnName("CLM_PROCESS_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.ClmTrans1)
                    .HasColumnName("CLM_TRANS")
                    .HasMaxLength(3);

                entity.Property(e => e.ClmTransNo).HasColumnName("CLM_TRANS_NO");

                entity.Property(e => e.ClmTransYearMonth)
                    .HasColumnName("CLM_TRANS_YEAR_MONTH")
                    .HasMaxLength(6);

                entity.Property(e => e.DeductiblePaid)
                    .HasColumnName("DEDUCTIBLE_PAID")
                    .HasMaxLength(1);

                entity.Property(e => e.InvoiceAmount).HasColumnName("INVOICE_AMOUNT");

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PaidAAdjust)
                    .HasColumnName("PAID_A_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidB2Adjust)
                    .HasColumnName("PAID_B2_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidB3Adjust)
                    .HasColumnName("PAID_B3_ADJUST")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidBAdjust)
                    .HasColumnName("PAID_B_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PaidCAdjust)
                    .HasColumnName("PAID_C_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.PayeeName)
                    .HasColumnName("PAYEE_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReserveAAdjust)
                    .HasColumnName("RESERVE_A_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB2Adjust)
                    .HasColumnName("RESERVE_B2_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveB3Adjust)
                    .HasColumnName("RESERVE_B3_ADJUST")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveBAdjust)
                    .HasColumnName("RESERVE_B_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReserveCAdjust)
                    .HasColumnName("RESERVE_C_ADJUST")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.ReservesPaidComments)
                    .HasColumnName("RESERVES_PAID_COMMENTS")
                    .IsUnicode(false);

                entity.Property(e => e.TimeToCloseEstAdjust)
                    .HasColumnName("TIME_TO_CLOSE_EST_ADJUST")
                    .HasMaxLength(2);

                entity.Property(e => e.TotalDamagesEstAdjust)
                    .HasColumnName("TOTAL_DAMAGES_EST_ADJUST")
                    .HasMaxLength(9);

                entity.Property(e => e.TotalDamagesTodateAdjust)
                    .HasColumnName("TOTAL_DAMAGES_TODATE_ADJUST")
                    .HasMaxLength(9);

                entity.Property(e => e.TotalDefenseEstAdjust)
                    .HasColumnName("TOTAL_DEFENSE_EST_ADJUST")
                    .HasMaxLength(9);

                entity.Property(e => e.TotalDefenseTodateAdjust)
                    .HasColumnName("TOTAL_DEFENSE_TODATE_ADJUST")
                    .HasMaxLength(9);

                entity.Property(e => e.TransCedLaePaid)
                    .HasColumnName("TRANS_CED_LAE_PAID")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.TransCedLaeRes)
                    .HasColumnName("TRANS_CED_LAE_RES")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.TransCedLossPaid)
                    .HasColumnName("TRANS_CED_LOSS_PAID")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.TransCedLossRes)
                    .HasColumnName("TRANS_CED_LOSS_RES")
                    .HasColumnType("ELD_FLOAT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Transferred)
                    .IsRequired()
                    .HasColumnName("TRANSFERRED")
                    .HasColumnType("ELD_BIT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.WillPayConfedenceAdjust).HasColumnName("WILL_PAY_CONFEDENCE_ADJUST");

                entity.Property(e => e.WillPayConfedenceReasonAdjust)
                    .HasColumnName("WILL_PAY_CONFEDENCE_REASON_ADJUST")
                    .HasMaxLength(100);

                entity.Property(e => e.WillPayoutAdjust)
                    .HasColumnName("WILL_PAYOUT_ADJUST")
                    .HasMaxLength(3);

                entity.HasOne(d => d.Acct)
                    .WithMany(p => p.ClmTrans)
                    .HasForeignKey(d => d.AcctId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLM_TRANS_ACCT_MASTER");

                entity.HasOne(d => d.ClmMaster)
                    .WithMany(p => p.ClmTrans)
                    .HasForeignKey(d => d.ClmMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLM_TRANS_CLM_MASTER1");
            });

            //modelBuilder.Entity<CorpOwner>(entity =>
            //{
            //    entity.ToTable("CorpOwner");

            //    entity.Property(e => e.LastChangedDate).HasColumnType("smalldatetime");

            //    entity.Property(e => e.LastChangedId)
            //        .HasMaxLength(6)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OwnerName)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<EldUsers>(entity =>
            {
                entity.HasKey(e => e.EldUserId);

                entity.ToTable("eld_Users");

                entity.Property(e => e.EldUserId).HasColumnName("ELD_UserID");

                entity.Property(e => e.AdGuid).HasColumnName("AD_Guid");

                entity.Property(e => e.CodesId)
                    .HasColumnName("CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_Of_Birth")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("Display_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.Ihazard)
                    .HasColumnName("IHazard")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

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
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UserGuid).HasColumnName("User_Guid");

                entity.Property(e => e.UsersRowVersion)
                    .HasColumnName("Users_Row_Version")
                    .IsRowVersion();
            });

            modelBuilder.Entity<InsuredInfo>(entity =>
            {
                entity.ToTable("INSURED_INFO");

                entity.Property(e => e.InsuredInfoId)
                    .HasColumnName("INSURED_INFO_ID")
                    .HasColumnType("ELD_INT")
                    .HasDefaultValueSql(@"

create default [ZERO] as 0
");

                entity.Property(e => e.Ein).HasColumnName("EIN");

                entity.Property(e => e.EinVerified).HasColumnName("EIN_Verified");

                entity.Property(e => e.InsuredAddress)
                    .HasColumnName("INSURED_ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredAddresschk)
                    .HasColumnName("INSURED_ADDRESSCHK")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredCity)
                    .HasColumnName("INSURED_CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredCounty)
                    .HasColumnName("INSURED_COUNTY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredDbaName)
                    .HasColumnName("INSURED_DBA_NAME")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredName)
                    .HasColumnName("INSURED_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredNamechk)
                    .HasColumnName("INSURED_NAMECHK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredNamechkFull)
                    .HasColumnName("INSURED_NAMECHK_FULL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredNotes)
                    .HasColumnName("INSURED_NOTES")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredSta)
                    .IsRequired()
                    .HasColumnName("INSURED_STA")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredZip)
                    .HasColumnName("INSURED_ZIP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate)
                    .HasColumnName("LAST_CHANGED_DATE")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.LastChangedId)
                    .HasColumnName("LAST_CHANGED_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MasterInsuredId).HasColumnName("MASTER_INSURED_ID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.Ticker)
                    .HasColumnName("TICKER")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LkpSubmissionStatus>(entity =>
            {
                entity.HasKey(e => e.CodesId);

                entity.ToTable("lkpSUBMISSION_STATUS");

                entity.Property(e => e.CodesId)
                    .HasColumnName("CODES_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrip)
                    .HasColumnName("DESCRIP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GenStat)
                    .HasColumnName("GEN_STAT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GenWord)
                    .HasColumnName("GEN_WORD")
                    .HasColumnType("text");

                entity.Property(e => e.HideWeb).HasColumnName("HIDE_WEB");

                entity.Property(e => e.LetterWording)
                    .HasColumnName("Letter_Wording")
                    .HasColumnType("text");

                entity.Property(e => e.LongWord)
                    .HasColumnName("LONG_WORD")
                    .HasColumnType("text");

                entity.Property(e => e.OpenStat)
                    .HasColumnName("OPEN_STAT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Subcode)
                    .HasColumnName("SUBCODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);
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
                    .HasMaxLength(150)
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
        }
    }
}
