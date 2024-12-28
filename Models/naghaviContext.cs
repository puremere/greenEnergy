using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Data.Entity.Spatial;

namespace greenEnergy.Model.naghavi // اینجا عوض شه
{

    class Context : DbContext
    {

        public Context() : base("naghavi") // NfcDb green2
        {
            // اینجا عوض شه
            //Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<Context, greenEnergy.Migrations.Configuration>());
            //Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }



        public DbSet<roleNavURL> roleNavURLs { get; set; }
        public DbSet<roleStartPage> roleStartPages { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<language> languages { get; set; }
        public DbSet<content> contents { get; set; }
        public DbSet<section> sections { get; set; }
        public DbSet<sectionLayout> sectionLayouts { get; set; }
        public DbSet<sectionType> sectionTypes { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<secTag> SecTags { get; set; }
        public DbSet<html> htmls { get; set; }
        public DbSet<meta> metas { get; set; }
        public DbSet<data> datas { get; set; }
        public DbSet<pose> poses { get; set; }
        public DbSet<layout> layouts { get; set; }
        public DbSet<layoutData> layoutDatas { get; set; }
        public DbSet<layoutPart> layoutParts { get; set; }

        //public DbSet<user> users { get; set; }

        public DbSet<city> cities { get; set; }
        public DbSet<datalog> datalogs { get; set; }
        public DbSet<orderResponse> orderResponses { get; set; }
        public DbSet<Comment> comments { get; set; }

        public DbSet<process> processes { get; set; }

        public DbSet<coding> codings { get; set; }
        public DbSet<sanad> sanads { get; set; }
        public DbSet<article> articles { get; set; }
        public DbSet<sanadSource> sanadSources { get; set; }
        public DbSet<formula> formulas { get; set; }
        public DbSet<namad> namads { get; set; }

        public DbSet<processFormula> processFormulas { get; set; }

        public DbSet<userWorkingStatus> userWorkingStatuses { get; set; }
        public DbSet<verifyStatus> verifyStatuses { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<productType> productTypes { get; set; }
        public DbSet<orderOption> orderOptions { get; set; }

        public DbSet<formItemType> formItemTypes { get; set; }
        public DbSet<formItemDesign> formItemDesigns { get; set; }
        public DbSet<form> forms { get; set; }
        public DbSet<formType> formType { get; set; }

        public DbSet<formItem> formItems { get; set; }
        public DbSet<newOrderType> newOrderTypes { get; set; }

        public DbSet<newOrderFields> newOrderFields { get; set; }
        public DbSet<newOrder> NewOrders { get; set; }
        public DbSet<newOrderFlow> newOrderFlows { get; set; }
        public DbSet<newOrderStatus> newOrderStatuses { get; set; }
        public DbSet<flowCoding> flowCodings { get; set; }
        public DbSet<flowProduct> flowProducts { get; set; }
        public DbSet<relationType> relationTypes { get; set; }
        public DbSet<userRelation> userRelations { get; set; }
        public DbSet<sectionRelation> sectionRelations { get; set; }
        public DbSet<urlData> urlDatas { get; set; }
        public DbSet<flowRelation> flowRelations { get; set; }
        public DbSet<flowStatus> flowStatuses { get; set; }
        public DbSet<flowLog> FlowLogs { get; set; }
        public DbSet<media> medias { get; set; }
        public DbSet<paymentRecord> paymentRecords { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<data>().HasOptional(s => s.Content).WithMany(x => x.Datas).HasForeignKey(x => x.contentID).WillCascadeOnDelete(true);
            modelBuilder.Entity<newOrderFields>().HasRequired(s => s.NewOrderFlow).WithMany(x => x.NewOrderFields).HasForeignKey(x => x.newOrderFlowID).WillCascadeOnDelete(true);
            modelBuilder.Entity<content>().HasOptional(s => s.sectionType).WithMany(x => x.contents).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false);
            modelBuilder.Entity<content>().HasOptional(s => s.HTML).WithMany(x => x.Contents).HasForeignKey(x => x.htmlID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutPart>().HasRequired(s => s.Language).WithMany(l => l.LayoutParts).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutPart>().HasOptional(s => s.SectionLayout).WithMany(l => l.LayoutParts).HasForeignKey(x => x.sectionLayoutID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasRequired(s => s.LayoutPart).WithMany(l => l.LayoutDatas).HasForeignKey(x => x.layoutPartID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasOptional(s => s.sectionType).WithMany(l => l.LayoutDatas).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasOptional(s => s.parentData).WithMany(l => l.childs).HasForeignKey(x => x.parentID).WillCascadeOnDelete(false);
            modelBuilder.Entity<html>().HasOptional(s => s.htlmparent).WithMany(l => l.childHtmls).HasForeignKey(x => x.parentID).WillCascadeOnDelete(false);
            modelBuilder.Entity<content>().HasOptional(s => s.form).WithMany().HasForeignKey(x => x.formID).WillCascadeOnDelete(false);



            modelBuilder.Entity<sectionLayout>().HasRequired(s => s.Language).WithMany(l => l.SectionLayouts).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false);
            modelBuilder.Entity<section>().HasRequired(s => s.sectionType).WithMany(x => x.sections).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false); ;
            modelBuilder.Entity<section>().HasOptional(s => s.SectionLayout).WithMany(x => x.sections).HasForeignKey(x => x.sectionLayoutID).WillCascadeOnDelete(false);
            modelBuilder.Entity<section>().HasOptional(s => s.Category).WithMany(x => x.sections).HasForeignKey(x => x.categoryID).WillCascadeOnDelete(false);
            modelBuilder.Entity<section>().HasRequired(s => s.Language).WithMany(x => x.Sections).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false);
            modelBuilder.Entity<category>().HasRequired(s => s.sectionType).WithMany(x => x.Categories).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false);
            modelBuilder.Entity<secTag>().HasRequired(s => s.sectionType).WithMany(x => x.SecTags).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false);


            modelBuilder.Entity<flowRelation>().HasRequired(s => s.childFlow).WithMany(x => x.childFlows).HasForeignKey(x => x.childID).WillCascadeOnDelete(true);
            modelBuilder.Entity<flowRelation>().HasRequired(s => s.parentFlow).WithMany(x => x.parentFlows).HasForeignKey(x => x.parentID).WillCascadeOnDelete(false);




            // قسمت مرتبط با تیلور

            modelBuilder.Entity<user>().HasOptional(s => s.workingStatus).WithMany().HasForeignKey(x => x.workingStatusID);

            modelBuilder.Entity<user>().HasOptional(s => s.verifyStatus).WithMany().HasForeignKey(x => x.verifyStatusID);
            modelBuilder.Entity<namad>().HasRequired(s => s.user).WithMany().HasForeignKey(x => x.userID).WillCascadeOnDelete(false);
            modelBuilder.Entity<newOrderFlow>().HasOptional(m => m.newOrderProcess).WithMany().HasForeignKey(m => m.processID).WillCascadeOnDelete(false);
            //modelBuilder.Entity<newOrderFlow>().HasOptional(m => m.NewOrder).WithMany().HasForeignKey(m => m.orderID).WillCascadeOnDelete(false);
            //modelBuilder.Entity<newOrderFlow>().HasRequired(m => m.newOrderFlowServent).WithMany().HasForeignKey(m => m.userID).WillCascadeOnDelete(false);
            modelBuilder.Entity<orderOption>().HasRequired(m => m.optionParent).WithMany(t => t.childList).HasForeignKey(m => m.parentID).WillCascadeOnDelete(false);
            modelBuilder.Entity<formula>().HasOptional(m => m.FormItem).WithMany(t => t.Formulas).HasForeignKey(m => m.formItemID).WillCascadeOnDelete(false);
            modelBuilder.Entity<roleNavURL>().HasRequired(m => m.RoleStartPage).WithMany(t => t.RoleNavURLs).HasForeignKey(m => m.roleStartPageID).WillCascadeOnDelete(false);

            modelBuilder.Entity<userRelation>().HasRequired(m => m.user).WithMany(t => t.userRelationList).HasForeignKey(m => m.userID).WillCascadeOnDelete(false);
            modelBuilder.Entity<userRelation>().HasRequired(m => m.partner).WithMany(t => t.partnerList).HasForeignKey(m => m.partnerID).WillCascadeOnDelete(false);
            modelBuilder.Entity<flowLog>().HasOptional(m => m.baseFlow).WithMany(t => t.FlowLogs).HasForeignKey(m => m.baseFlowID).WillCascadeOnDelete(false);
            modelBuilder.Entity<flowLog>().HasRequired(m => m.actorFlow).WithMany().HasForeignKey(m => m.actorFlowID).WillCascadeOnDelete(false);
            modelBuilder.Entity<flowLog>().HasRequired(m => m.actionFlow).WithMany().HasForeignKey(m => m.actionFlowID).WillCascadeOnDelete(false);



            //modelBuilder.Entity<user>().HasIndex(u => u.phone).IsUnique();

        }

    }

    public class paymentRecord
    {
        [Key]
        public Guid paymentRecordID { get; set; }
        public int relationID { get; set; }
        public int peigiry { get; set; }
        public double price { get; set; }
        public int status { get; set; }
        public double timestamp { get; set; }
        public Guid userID { get; set; }
        public int moneyFormID { get; set; } // ینی چه فرمی داره پرداخت میشه
        public string planID { get; set; }
    }
    public class datalog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int datalogID { get; set; }
        public string data { get; set; }
        public string form { get; set; }
        public string slug { get; set; }
        public string response { get; set; }
        public string where { get; set; }
        public string userID { get; set; }
    }
    public class media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int mediaID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    public class flowLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int flowLogID { get; set; }
        public string actorUserType { get; set; }
        public int formID { get; set; }
        public Guid userID { get; set; }
        public int? baseFlowID { get; set; }
        [ForeignKey("baseFlowID")]
        public virtual newOrderFlow baseFlow { get; set; }


        public int actionFlowID { get; set; }
        [ForeignKey("actionFlowID")]
        public virtual newOrderFlow actionFlow { get; set; }


        public int actorFlowID { get; set; }
        [ForeignKey("actorFlowID")]
        public virtual newOrderFlow actorFlow { get; set; }

        public DateTime creationDate { get; set; }
        public string actionTitle { get; set; }
    }
    public class urlData
    {
        [Key]
        public Guid urlDataID { get; set; }
        public Guid sectionID { get; set; }
        [ForeignKey("sectionID")]
        public virtual section section { get; set; }
        public string name { get; set; }
        public string formFields { get; set; }
        public string flowFields { get; set; }
        public string formIDString { get; set; }
        public string userFields { get; set; }
        public string statusFields { get; set; }
        public string logFields { get; set; }

        public int isCycle { get; set; }
        public int isCustom { get; set; }
        public int thirdIDIsNeeded { get; set; }
        public int formOwner { get; set; }
        public int isOrderByDate { get; set; }
        public int isForCurrentDay { get; set; }

        public int? formTypeID { get; set; }
        public int? formID { get; set; }
        [ForeignKey("formID")]
        public virtual form form { get; set; }



        public int userInfo { get; set; }
        public int? formItemID { get; set; }
        [ForeignKey("formItemID")]
        public virtual formItem formItem { get; set; }

        public int? formItemType { get; set; }



        public int isLinkToMain { get; set; }
        public string conditionStatus { get; set; }
        public string relationStatus { get; set; }
        public string conditionRelationStatus { get; set; }
        public int conditionStatusOperator { get; set; }
        public string operat { get; set; }
        public string extraRelation { get; set; }

    }
    public class relationType
    {
        public relationType()
        {
            this.Processes = new HashSet<process>();
        }
        [Key]
        public Guid relationTypeID { get; set; }
        public string title { get; set; }
        public int relationCode { get; set; }
        public virtual ICollection<process> Processes { get; set; }
    }

    public class userRelation
    {
        [Key]
        public Guid userRelationID { get; set; }
        public int relationCode { get; set; }
        public int status { get; set; }

        //public Guid? newOrderID { get; set; }
        //[ForeignKey("newOrderID")]
        //public virtual newOrder NewOrder { get; set; }

        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }


        public Guid? partnerID { get; set; }
        [ForeignKey("partnerID")]
        public virtual user partner { get; set; }
    }
    public class sectionRelation
    {
        [Key]
        public Guid sectionRelationID { get; set; }
        public string url { get; set; }
        public string relationCode { get; set; }
    }
    public class roleNavURL
    {
        [Key]
        public Guid orleNavURLID { get; set; }

        public Guid roleStartPageID { get; set; }
        [ForeignKey("roleStartPageID")]
        public virtual roleStartPage RoleStartPage { get; set; }

        public string startPageURL { get; set; }
        public string roleName { get; set; }
        public string startPagetitle { get; set; }
        public string startPageIcon { get; set; }
        public int priority { get; set; }
    }
    public class roleStartPage
    {
        [Key]
        public Guid roleStartPageID { get; set; }
        public string userType { get; set; }
        public int isNav { get; set; }
        public string startPage { get; set; }
        public virtual ICollection<roleNavURL> RoleNavURLs { get; set; }
    }
    public class meta
    {
        [Key]
        public Guid metaID { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public Guid sectionID { get; set; }
        [ForeignKey("sectionID")]
        public virtual section Section { get; set; }

    }



    public class section
    {

        public section()
        {
            this.SecTags = new HashSet<secTag>();
        }
        [Key]
        public Guid sectionID { get; set; }

        public string url { get; set; }
        public string buttonText { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string metatitle { get; set; }
        public string image { get; set; }
        public string writer { get; set; }






        public Guid? categoryID { get; set; }
        [ForeignKey("categoryID")]
        public virtual category Category { get; set; }

        public Guid languageID { get; set; }
        [ForeignKey("languageID")]
        public virtual language Language { get; set; }

        public Guid? sectionLayoutID { get; set; }
        [ForeignKey("sectionLayoutID")]
        public virtual sectionLayout SectionLayout { get; set; }


        public Guid? sectionTypeID { get; set; }
        [ForeignKey("sectionTypeID")]
        public virtual sectionType sectionType { get; set; }


        public virtual ICollection<content> Contents { get; set; }
        public virtual ICollection<meta> Metas { get; set; }
        public virtual ICollection<secTag> SecTags { get; set; }

    }

    public class layoutData
    {
        [Key]
        public Guid layoutDataID { get; set; }
        public string title { get; set; }
        public string urlTitle { get; set; }
        public Guid layoutPartID { get; set; }
        [ForeignKey("layoutPartID")]
        public virtual layoutPart LayoutPart { get; set; }

        public Guid? sectionTypeID { get; set; }
        [ForeignKey("sectiontypeID")]
        public virtual sectionType sectionType { get; set; }

        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual layoutData parentData { get; set; }

        public string dataType { get; set; }
        public string url { get; set; }
        public int priority { get; set; }
        public string image { get; set; }
        public int typeCount { get; set; }

        public virtual ICollection<layoutData> childs { get; set; }
    }


    public class html
    {
        [Key]
        public Guid htmlID { get; set; }
        public string title { get; set; }
        public string appMeta { get; set; }
        public string poseMeta { get; set; }
        public string appType { get; set; }
        public string image { get; set; }
        public string formLink { get; set; }
        public string partialView { get; set; }
        public string ispublic { get; set; }
        public int multilayer { get; set; }
        public string dataField { get; set; }
        public string poseField { get; set; }
        public int childCapable { get; set; }

        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual html htlmparent { get; set; }



        public Guid? layout { get; set; }
        [ForeignKey("layout")]
        public virtual layout Layout { get; set; }
        public virtual ICollection<content> Contents { get; set; }
        public virtual ICollection<html> childHtmls { get; set; }
    }



    //public class JAStackView : JAView
    //{
    //    public int orientation { get; set; }
    //    public string backColor { get; set; }
    //    public int cornerRadius { get; set; }


    //}

    //public class JAPerTextView : JAView
    //{
    //    public string keyText { get; set; }
    //    public string valueText { get; set; }
    //    public string keyColor { get; set; }
    //    public string valueColor { get; set; }


    //}
    //public class JALable : JAView
    //{
    //    public int orientation { get; set; }
    //    public string backColor { get; set; }
    //    public int cornerRadius { get; set; }


    //}

    //public class JATextInput : JAView
    //{
    //    public string ID { get; set; } // formKey
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //    public string backColor { get; set; }
    //}




    public class content  // JAView for app
    {

        [Key]
        public Guid contentID { get; set; }
        public Guid? sectionTypeID { get; set; }
        [ForeignKey("sectionTypeID")]
        public virtual sectionType sectionType { get; set; }

        public int priority { get; set; }
        public int useParentSection { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public string cycleFields { get; set; }
        public string cycleFormItem { get; set; }
        public string stackWeight { get; set; }





        public int? formID { get; set; }
        [ForeignKey("formID")]
        public virtual form form { get; set; }

        public Guid? htmlID { get; set; }
        [ForeignKey("htmlID")]
        public virtual html HTML { get; set; }

        public Guid? sectionID { get; set; }
        [ForeignKey("sectionID")]
        public virtual section Section { get; set; }

        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual content paretn { get; set; }
        public virtual ICollection<data> Datas { get; set; }
        public virtual ICollection<pose> Poses { get; set; }
        public virtual ICollection<content> childContent { get; set; }
    }


    public class pose
    {
        [Key]
        public Guid poseID { get; set; }

        public string title { get; set; }
        public string title2 { get; set; }

        public Guid? contentID { get; set; }
        [ForeignKey("contentID")]
        public virtual content Content { get; set; }
    }
    public class data
    {
        [Key]
        public Guid dataID { get; set; }
        public string title { get; set; }
        public DateTime Date { get; set; }
        public string writer { get; set; }
        public string title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
        public string url { get; set; }
        public int priority { get; set; }
        public string mediaURL { get; set; }
        public string viedoIframe { get; set; }
        public Guid? contentID { get; set; }
        [ForeignKey("contentID")]
        public virtual content Content { get; set; }
    }


    public class layout
    {
        [Key]
        public Guid layoutID { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string partName { get; set; }
        public string partDetailName { get; set; }
        public virtual ICollection<sectionLayout> SectionLayouts { get; set; }
    }

    public class layoutPart
    {


        [Key]
        public Guid layoutPartID { get; set; }
        public string title { get; set; }
        public string typeName { get; set; }
        public Guid languageID { get; set; }
        [ForeignKey("languageID")]
        public virtual language Language { get; set; }

        public Guid? sectionLayoutID { get; set; }
        [ForeignKey("sectionLayoutID")]
        public virtual sectionLayout SectionLayout { get; set; }

        public virtual ICollection<layoutData> LayoutDatas { get; set; }
    }
    public class sectionLayout
    {

        [Key]
        public Guid sectionLayoutID { get; set; }
        public string menuTitle { get; set; }
        public Guid? layoutID { get; set; }
        [ForeignKey("layoutID")]
        public virtual layout Layout { get; set; }

        public Guid languageID { get; set; }
        [ForeignKey("languageID")]
        public virtual language Language { get; set; }

        public virtual ICollection<layoutPart> LayoutParts { get; set; }
        public virtual ICollection<section> sections { get; set; }

    }
    public class sectionType
    {
        [Key]
        public Guid sectionTypeID { get; set; }
        public string title { get; set; }

        public virtual ICollection<content> contents { get; set; }
        public virtual ICollection<section> sections { get; set; }
        public virtual ICollection<category> Categories { get; set; }
        public virtual ICollection<secTag> SecTags { get; set; }
        public virtual ICollection<layoutData> LayoutDatas { get; set; }

    }

    public class secTag
    {
        public secTag()
        {
            this.sections = new HashSet<section>();
        }
        [Key]
        public Guid secTagID { get; set; }
        public string title { get; set; }
        public Guid sectionTypeID { get; set; }
        [ForeignKey("sectiontypeID")]
        public virtual sectionType sectionType { get; set; }
        public virtual ICollection<section> sections { get; set; }
    }
    public class category
    {
        [Key]
        public Guid categoryID { get; set; }
        public string title { get; set; }
        public Guid sectionTypeID { get; set; }
        [ForeignKey("sectiontypeID")]
        public virtual sectionType sectionType { get; set; }
        public virtual ICollection<section> sections { get; set; }
    }
    public class language
    {
        [Key]
        public Guid languageID { get; set; }
        public string title { get; set; }

        public virtual ICollection<section> Sections { get; set; }
        public virtual ICollection<layoutPart> LayoutParts { get; set; }
        public virtual ICollection<sectionLayout> SectionLayouts { get; set; }
    }
    //public class user
    //{

    //    [Key]
    //    public Guid userID { get; set; }
    //    public string username { get; set; }
    //    public string phone { get; set; }
    //    public string code { get; set; }
    //    public string userType { get; set; }

    //}



    // بخش مرتبط با تیلور






























    public class orderOption
    {


        [Key]
        public Guid orderOptionID { get; set; }
        public string title { get; set; }
        public int priority { get; set; }
        public string Value { get; set; }
        public string image { get; set; }
        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }
        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual orderOption optionParent { get; set; }
        public virtual ICollection<orderOption> childList { get; set; }


    }

    public class product
    {

        public product()
        {
            this.Tags = new HashSet<tag>();
        }
        [Key]
        public Guid productID { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public string barcode { get; set; }
        public string address { get; set; }

        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }



        public virtual ICollection<productType> productTypes { get; set; }
        public virtual ICollection<tag> Tags { get; set; }
        public virtual ICollection<flowProduct> FlowProducts { get; set; }



    }

    public class productType
    {
        public productType()
        {
            this.Products = new HashSet<product>();
        }

        [Key]
        public Guid productTypeID { get; set; }
        public string title { get; set; }


        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }

        public Guid parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual productType ProductType { get; set; }

        public virtual ICollection<productType> childItems { get; set; }
        public virtual ICollection<product> Products { get; set; }
    }

    public class tag
    {
        public tag()
        {
            this.Products = new HashSet<product>();
        }
        [Key]
        public Guid tagID { get; set; }
        public string title { get; set; }
        public virtual ICollection<product> Products { get; set; }

        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }



    }

    public class coding
    {
        [Key]
        public Guid codingID { get; set; }
        public Guid parentID { get; set; }

        public int codingType { get; set; }
        public int codeHesab { get; set; }
        public string title { get; set; }
        public string inList { get; set; }

        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }
        public virtual ICollection<processFormula> ProcessFormulas { get; set; }


    }
    public class sanad
    {
        [Key]
        public Guid sanadID { get; set; }
        public int number { get; set; }
        public int atf { get; set; }
        public int status { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }

    }
    public class article
    {
        [Key]
        public Guid articleID { get; set; }

        public Guid sanadID { get; set; }
        public int tarafHesab { get; set; }
        public int status { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int koll { get; set; }
        public int grooh { get; set; }
        public int moin { get; set; }
        public int tafsil1 { get; set; }
        public int tafsil2 { get; set; }
        public int tafsil3 { get; set; }
        public int tafsil4 { get; set; }
        public int tafsil5 { get; set; }
        public int type { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }
    }
    public class sanadSource
    {
        [Key]
        public Guid sanadSourceID { get; set; }
        public string title { get; set; }
        public Guid codingID { get; set; }
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual user user { get; set; }
    }



    public class namad   // این آیتم مقداریه که به عنوان بیس در نظر گرفته میشه مثل ارزش کل بار 
    {
        [Key]
        public Guid namadID { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public Guid userID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("userID")]
        public virtual user user { get; set; }
        public virtual ICollection<formula> Formulas { get; set; }

    }


    public class formula
    {
        [Key]
        public Guid formulaID { get; set; }
        public int col { get; set; }
        public int leftID { get; set; }
        public int rightID { get; set; }


        public Guid? processID { get; set; }
        [ForeignKey("processID")]
        public virtual process process { get; set; }


        public int? formItemID { get; set; }
        [ForeignKey("formItemID")]
        public virtual formItem FormItem { get; set; }




        public Guid namadID { get; set; }
        [ForeignKey("namadID")]
        public virtual namad namad { get; set; }

        public Guid userID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("userID")]
        public virtual user user { get; set; }

        public decimal number { get; set; }

        public string name { get; set; }
        public string result { get; set; }

        public virtual ICollection<processFormula> ProcessFormulas { get; set; }
    }

    public class formItemDesign
    {
        [Key]
        public Guid formItemDesignID { get; set; }
        public string title { get; set; }
        public int number { get; set; }
    }
    public class formItemType
    {
        [Key]
        public Guid formItemTypeID { get; set; }
        public string title { get; set; }
        public string formItemTypeCode { get; set; }
        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user User { get; set; }



    }

    public class formItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int formItemID { get; set; }
        public string itemName { get; set; }
        public string continueWithError { get; set; }
        public string groupNumber { get; set; }
        public string itemDesc { get; set; }
        public string itemx { get; set; }
        public string itemy { get; set; }
        public string itemLenght { get; set; }
        public string itemHeight { get; set; }
        public int pageNumber { get; set; }
        public int priority { get; set; }
        public int formpage { get; set; }
        public int itempage { get; set; }
        public string itemPlaceholder { get; set; }
        public string itemtImage { get; set; }
        public string catchUrl { get; set; }
        public string isMultiple { get; set; }
        public string isValidate { get; set; }
        public string regx { get; set; }
        public string isRequired { get; set; }
        public string validationType { get; set; }
        public string otherFieldName { get; set; }
        public string referTo { get; set; }

        public double minNumber { get; set; }
        public double maxNumber { get; set; }
        public string mediaType { get; set; }
        public string collectionName { get; set; }
        public string operat { get; set; }
        public int isHidden { get; set; }

        public Guid? OptionID { get; set; }
        [ForeignKey("OptionID")]
        public virtual orderOption op { get; set; }

        public Guid? formItemDesingID { get; set; }
        [ForeignKey("formItemDesingID")]
        public virtual formItemDesign FormItemDesign { get; set; }


        public Guid formItemTypeID { get; set; }
        [ForeignKey("formItemTypeID")]
        public virtual formItemType FormItemType { get; set; }

        public int? relatedForemItemID { get; set; }
        [ForeignKey("relatedForemItemID")]
        public virtual formItem relatedFormItem { get; set; }


        public int formID { get; set; }
        [ForeignKey("formID")]
        public virtual form form { get; set; }


        public virtual ICollection<formula> Formulas { get; set; }
        public virtual ICollection<formItem> FormItems { get; set; }
    }

    public class formType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int formTypeID { get; set; }
        public string title { get; set; }

        public virtual ICollection<form> Forms { get; set; }
    }
    public class form
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int formID { get; set; }
        public string title { get; set; }
        public string zaribWidth { get; set; }
        public string zaribHeight { get; set; }
        public string pdfBase { get; set; }
        public string pdf { get; set; }
        public string image { get; set; }
        public string imageWidth { get; set; }
        public string imageHeight { get; set; }
        public int priority { get; set; }
        public Guid? userID { get; set; }
        [ForeignKey("userID")]
        public virtual user User { get; set; }

        public int? formTypeID { get; set; }
        [ForeignKey("formTypeID")]
        public virtual formType FormType { get; set; }


        public virtual ICollection<formItem> FormItems { get; set; }

        public Guid? processID { get; set; }
        [ForeignKey("processID")]
        public virtual process process { get; set; }

    }

    public class processform
    {
        public int formID { get; set; }
        [ForeignKey("formID")]
        public virtual form form { get; set; }
        public Guid processID { get; set; }
        [ForeignKey("processID")]
        public virtual process Process { get; set; }
    }

    public class newOrderFields
    {
        [Key]
        public Guid newOrderFieldsID { get; set; }
        public int? valueInt { get; set; }
        public bool? valueBool { get; set; }
        public double? valueDuoble { get; set; }
        public DateTime? valueDateTime { get; set; }
        public Guid? valueGuid { get; set; }
        public string? valueString { get; set; }
        public string name { get; set; }
        public string usedFeild { get; set; }

        public int formItemID { get; set; }
        [ForeignKey("formItemID")]
        public virtual formItem FormItem { get; set; }

        public int newOrderFlowID { get; set; }
        [ForeignKey("newOrderFlowID")]
        public virtual newOrderFlow NewOrderFlow { get; set; }
    }


    public class newOrderStatus
    {
        [Key]
        public Guid newOrderStatusID { get; set; }
        public string title { get; set; }
        public string statusCode { get; set; }

    }

    public class newOrderType
    {
        [Key]
        public Guid newOrderTypeID { get; set; }
        public string title { get; set; }
        public int orderTypeCode { get; set; }
        //public virtual ICollection<newOrder> NewOrders { get; set; }
    }
    public class newOrder
    {
        [Key]
        public Guid newOrderID { get; set; }
        public string orderName { get; set; }


        public Guid? thirdPartyID { get; set; }
        [ForeignKey("thirdPartyID")]
        public virtual user user { get; set; }

        public Guid? newOrderTypeID { get; set; }
        [ForeignKey("newOrderTypeID")]
        public virtual newOrderType NewOrderType { get; set; }

        public Guid newOrderStatusID { get; set; }
        [ForeignKey("newOrderStatusID")]
        public virtual newOrderStatus newOrderStatus { get; set; }



        public DateTime creationDate { get; set; }
        public DateTime terminationDate { get; set; }

        public virtual ICollection<newOrderFlow> orderFlowList { get; set; }


    }


    public class flowRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int flowRelationID { get; set; }
        public int? status { get; set; }
        public DateTime? childStartDate { get; set; }
        public DateTime? childEndDate { get; set; }

        public int? formID { get; set; }
        public int actorFlowID { get; set; }
        public int parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual newOrderFlow parentFlow { get; set; }

        public int childID { get; set; }
        [ForeignKey("childID")]
        public virtual newOrderFlow childFlow { get; set; }

    }

    public class flowStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int flowStatusID { get; set; }
        public string title { get; set; }
        public string color { get; set; }
    }
    public class newOrderFlow
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int newOrderFlowID { get; set; }

        public string meta { get; set; }

        //public Guid newOrder_newOrderID { get; set; }
        public Guid? newOrderID { get; set; }
        //[ForeignKey("orderID")]
        //public virtual newOrder NewOrder { get; set; }


        //public Guid OrderID { get; set; }
        //public string serventPhone2 { get; set; }

        public string serventPhone { get; set; }

        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual user newOrderFlowServent { get; set; }

        public Guid? processID { get; set; }
        [ForeignKey("processID")]
        public virtual process newOrderProcess { get; set; }

        public int? formType { get; set; }

        public int? formID { get; set; }
        [ForeignKey("formID")]
        public virtual form form { get; set; }

        public int? flowStatusID { get; set; }
        [ForeignKey("flowStatusID")]
        public virtual flowStatus FlowStatus { get; set; }




        public string isFinished { get; set; }
        public string isAccepted { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime actionDate { get; set; }
        public DateTime terminationDate { get; set; }
        public DateTime changeStatusDate { get; set; }

        public virtual ICollection<newOrderFields> NewOrderFields { get; set; }
        public virtual ICollection<flowRelation> childFlows { get; set; }
        public virtual ICollection<flowRelation> parentFlows { get; set; }
        public virtual ICollection<flowCoding> flowCodings { get; set; }
        public virtual ICollection<flowProduct> flowProducts { get; set; }
        public virtual ICollection<flowLog> FlowLogs { get; set; }
    }
    public class flowProduct
    {
        [Key]
        public Guid flowCodingID { get; set; }
        public Guid productID { get; set; }
        [ForeignKey("productID")]
        public virtual product product { get; set; }
        public int flowID { get; set; }
        [ForeignKey("flowID")]
        public virtual newOrderFlow orderflow { get; set; }
        public double amount { get; set; }
        public DateTime date { get; set; }

    }

    public class flowCoding
    {
        [Key]
        public Guid flowCodingID { get; set; }
        public Guid CodingID { get; set; }
        [ForeignKey("CodingID")]
        public virtual coding coding { get; set; }
        public int flowID { get; set; }
        [ForeignKey("flowID")]
        public virtual newOrderFlow orderflow { get; set; }
        public double amount { get; set; }
        public DateTime date { get; set; }

    }

    public class process// پروسه ای که بابری برای خدش توولید میکنه و اردرهاشو تطبیق میده
    {
        [Key]
        public Guid processID { get; set; }
        public process()
        {
            this.formList = new HashSet<form>();
            this.RelationTypes = new HashSet<relationType>();
        }
        public string isDefault { get; set; }
        public string title { get; set; }
        public string color { get; set; }
        public Guid? userID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("userID")]
        public virtual user user { get; set; }

        public Guid? orderTypeID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("orderTypeID")]
        public virtual newOrderType NewOrderType { get; set; }

        public virtual ICollection<processFormula> ProcessFormulas { get; set; }
        //public virtual ICollection<newOrder> orderHistoryList { get; set; }
        public virtual ICollection<form> formList { get; set; }
        public virtual ICollection<relationType> RelationTypes { get; set; }

    }
    public class processFormula// میگه چه فرمولهایی برای چه پروسه هایی هست که روی یک کدینگ اثر میزاره یا بدهکار یا بستانکار
    {
        [Key]
        public Guid processFormulaID { get; set; }
        public Guid proccessID { get; set; }
        [ForeignKey("proccessID")]
        public virtual process Process { get; set; }

        public Guid FormulaID { get; set; }
        [ForeignKey("FormulaID")]
        public virtual formula Formula { get; set; }


        public Guid codingID { get; set; }
        [ForeignKey("codingID")]
        public virtual coding Coding { get; set; }

        public string transactionType { get; set; } // بدهکاری یا بستانکاری عدد حاصل از فرمول را رووی کدینگ اعمال میکند
    }



    public class Comment
    {
        [Key]
        public Guid CommentID { get; set; }
        public Guid orderID { get; set; }
        public Guid userID { get; set; }
        public Guid clientID { get; set; }
        public string clientMark { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }


    }


    // باربری خودش روش های مختلف باربری رو مشخص میکنه  الصاق میکنه به یک سفارش که سند های ثابت با فرمول بخوره



    public class orderResponse
    {
        [Key]
        public Guid orderresponseID { get; set; }
        public Guid orderID { get; set; }
        public Guid driverID { get; set; }
        public double price { get; set; }

    }

    public class user
    {
        public user()
        {
            Namads = new List<namad>();
        }


        [Key]
        public Guid userID { get; set; }
        public string firebaseToken { get; set; }
        public string deviceToken { get; set; }
        [Column(TypeName = "VARCHAR")]
        public string userType { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string profileImage { get; set; }
        public string coName { get; set; }


        public string phone { get; set; }
        public string code { get; set; }
        public string codeMelli { get; set; }
        public string shenaseSherkat { get; set; }
        public string cityID { get; set; }
        public string address { get; set; }
        public string emPhone { get; set; }
        public string typeID { get; set; }
        public string postalCode { get; set; }
        public int badge { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public DbGeography point { get; set; }


        public Guid? workingStatusID { get; set; }
        [ForeignKey("workingStatusID")]
        public virtual userWorkingStatus workingStatus { get; set; }


        public Guid? verifyStatusID { get; set; }
        [ForeignKey("verifyStatusID")]
        public virtual verifyStatus verifyStatus { get; set; }



        public Guid? barbariID { get; set; }
        [ForeignKey("barbariID")]
        public virtual user barbari { get; set; }



        public virtual ICollection<userRelation> userRelationList { get; set; } // کیا عضو تو هستن
        public virtual ICollection<userRelation> partnerList { get; set; } // کیا عضو تو هستن

        public virtual ICollection<user> CoDrivers { get; set; }
        public virtual ICollection<coding> Codings { get; set; }
        public virtual ICollection<sanad> Sanads { get; set; }
        public virtual ICollection<article> Articles { get; set; }
        public virtual ICollection<sanadSource> SanadSources { get; set; }

        public virtual ICollection<formula> Formulas { get; set; }
        public virtual ICollection<process> processes { get; set; }
        public virtual ICollection<product> products { get; set; }

        public virtual ICollection<namad> Namads { get; set; }



    }


    public class userWorkingStatus
    {
        [Key]
        public Guid workingStatusID { get; set; }
        public string title { get; set; }
        public Guid? userID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("userID")]
        public virtual user user { get; set; }

        public virtual ICollection<user> Users { get; set; }
    }





    public class verifyStatus
    {
        [Key]
        public Guid verifyStatusID { get; set; }
        public string title { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
        public Guid? userID { get; set; } // مرتبط با کدوم باربریه
        [ForeignKey("userID")]
        public virtual user user { get; set; }

        public virtual ICollection<user> Users { get; set; }
    }
    public class city
    {
        [Key]

        public Guid userID { get; set; }

        public string title { get; set; }

        public string lat { get; set; }
        public string lon { get; set; }
        public string code { get; set; }

        public string District { get; set; }
        public string country { get; set; }
        public string cty { get; set; }
        public string town { get; set; }
        public DbGeography citypoint { get; set; }

        public Guid parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual city parentcity { get; set; }
    }





}
