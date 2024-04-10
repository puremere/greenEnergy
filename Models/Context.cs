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

namespace greenEnergy.Model
{

    class Context : DbContext
    {

        public Context() : base("green")
        {
            Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<Context, greenEnergy.Migrations.Configuration>());
           // Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }



        public DbSet<user> users { get; set; }
        public DbSet<language> languages { get; set; }
        public DbSet<content> contents { get; set; }
        public DbSet<section> sections { get; set; }
        public DbSet<sectionLayout> sectionLayouts { get; set; }
        public DbSet<sectionType> sectionTypes { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<html> htmls { get; set; }
        public DbSet<meta> metas { get; set; }
        public DbSet<data> datas { get; set; }
        public DbSet<layout> layouts { get; set; }
        public DbSet<layoutData> layoutDatas { get; set; }
        public DbSet<layoutPart> layoutParts { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<data>().HasOptional(s => s.Content).WithMany(x=>x.Datas).HasForeignKey(x => x.contentID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<content>().HasOptional(s=>s.sectionType).WithMany(x=>x.contents).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false) ;
            modelBuilder.Entity<content>().HasOptional(s=>s.HTML).WithMany(x=>x.Contents).HasForeignKey(x => x.htmlID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<layoutPart>().HasRequired(s=>s.Language).WithMany(l=>l.LayoutParts).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasRequired(s=>s.LayoutPart).WithMany(l=>l.LayoutDatas).HasForeignKey(x => x.layoutPartID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasOptional(s=>s.sectionType).WithMany(l=>l.LayoutDatas).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false);
            modelBuilder.Entity<layoutData>().HasOptional(s=>s.parentData).WithMany(l=>l.childs).HasForeignKey(x => x.parentID).WillCascadeOnDelete(false);
            


            modelBuilder.Entity<sectionLayout>().HasRequired(s=>s.Language).WithMany(l=>l.SectionLayouts).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<section>().HasRequired(s=>s.sectionType).WithMany(x=>x.sections).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false); ;
            modelBuilder.Entity<section>().HasOptional(s=>s.SectionLayout).WithMany(x=>x.sections).HasForeignKey(x => x.sectionLayoutID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<section>().HasOptional(s=>s.Category).WithMany(x=>x.sections).HasForeignKey(x => x.categoryID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<section>().HasRequired(s=>s.Language).WithMany(x=>x.Sections).HasForeignKey(x => x.languageID).WillCascadeOnDelete(false); 
            modelBuilder.Entity<category>().HasRequired(s=>s.sectionType).WithMany(x=>x.Categories).HasForeignKey(x => x.sectionTypeID).WillCascadeOnDelete(false); 
            
        }

    }



    public class meta
    {
        [Key]
        public Guid metaID { get; set; }
        public string  name { get; set; }
        public string content { get; set; }
        public Guid? sectionID { get; set; }
        [ForeignKey("sectionID")]
        public virtual section Section { get; set; }

    }
    public class section
    {
        
        [Key]
        public Guid sectionID { get; set; }
        public string url { get; set; }
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


        public string url { get; set; }
        public int priority     { get; set; }
        public string image { get; set; }
        public int typeCount { get; set; }

        public virtual ICollection<layoutData> childs { get; set; }
    }
    public class html
    {
        [Key]
        public Guid htmlID { get; set; }
        public string  title { get; set; }
        public string  image { get; set; }
        public string  partialView { get; set; }
        public Guid? layout { get; set; }
        [ForeignKey("layout")]
        public virtual layout Layout { get; set; }
        public virtual ICollection<content> Contents { get; set; }
    }
    public class content
    {
        
        [Key]
        public Guid contentID { get; set; }
        public Guid? sectionTypeID { get; set; }
        [ForeignKey("sectionTypeID")]
        public virtual sectionType sectionType { get; set; }

        public int priority { get; set; }
        public string title { get; set; }

        public Guid? htmlID { get; set; }
        [ForeignKey("htmlID")]
        public virtual html HTML { get; set; }

        public Guid sectionID { get; set; }
        [ForeignKey("sectionID")]
        public virtual section Section { get; set; }

        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual content paretn { get; set; }
        public virtual ICollection<data> Datas { get; set; }
        public virtual ICollection<content> childContent { get; set; }
    }


    
    public class data
    {
        [Key]
        public Guid dataID { get; set; }
        public string title { get; set; }
        public string title2 { get; set; }
        public string description { get; set; }
        public string description2 { get; set; }
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
        public virtual ICollection<sectionLayout> SectionLayouts { get; set; }
    }
    
    public class layoutPart
    {

        public layoutPart()
        {
            this.SectionLayouts = new HashSet<sectionLayout>();
        }
        [Key]
        public Guid layoutPartID { get; set; }
        public string title { get; set; }
        public string typeName { get; set; }
        public Guid languageID { get; set; }
        [ForeignKey("languageID")]
        public virtual language Language { get; set; }

        public virtual ICollection<sectionLayout> SectionLayouts { get; set; }
        public virtual ICollection<layoutData> LayoutDatas { get; set; }
    }
    public class sectionLayout  
    {
        public sectionLayout()
        {
            this.LayoutParts = new HashSet<layoutPart>();
        }
        [Key]
        public Guid sectionLayoutID { get; set; }
        public string  menuTitle { get; set; }
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
        public virtual ICollection<layoutData> LayoutDatas { get; set; }
        
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
        public string  title { get; set; }

        public virtual ICollection<section> Sections { get; set; }
        public virtual ICollection<layoutPart> LayoutParts { get; set; }
        public virtual ICollection<sectionLayout> SectionLayouts { get; set; }
    }
    public class user
    {
        
        [Key]
        public Guid userID { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string code { get; set; }
        public string userType { get; set; }

    }



}
