using greenEnergy.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using greenEnergy.Classes;
using greenEnergy.Model;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Data.Entity.Spatial;
//using Google.Apis.Auth.OAuth2;
//using FirebaseAdmin;
//using FirebaseAdmin.Messaging;
using System.Web.Hosting;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace greenEnergy.Controllers
{
    public class appController : System.Web.Http.ApiController
    {
        //[BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<pageSectionVM> getURL([FromBody] getURLVM model)
        
        {
            pageSectionVM response = new pageSectionVM();
            try
            {
                model.url = model.url == null ? "" : model.url;

               
                using (Context dbcontext = new Context())
                {
                    language lng = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.lang);
                    var responseList = await dbcontext.sections.Include(x => x.SectionLayout).Include(x => x.Contents).Include(x => x.Metas).Include(x => x.Contents.Select(l => l.HTML)).Include(x => x.Contents.Select(y => y.Datas)).Include(x=>x.Contents.Select(y=>y.childContent)).Include(x => x.Contents.Select(y => y.childContent.Select(z=>z.Datas))).Where(x => x.url == model.url && x.languageID == lng.languageID).Select(x => new pageSectionVM {  Metas = x.Metas.Select(p => new MetaVM { Name = p.name, Content = p.content }).ToList(), date = x.date, title = x.title, image = x.image, url = x.url, sectionLayoutID = x.sectionLayoutID, Contents = x.Contents.OrderBy(l=>l.priority).Select(l => new pageContentVM { typeID = l.sectionTypeID,  priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToList() }).ToListAsync();
                    response = responseList.First();
                    var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == response.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.name, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.typeName, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { layoutDataID = m.layoutDataID, parentID = m.parentID == null ? null : m.parentID, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).OrderBy(m=>m.priority).ToList() }).ToList() }).ToListAsync();
                    response.layoutModel = list.First();
                    
                    foreach (var item in response.Contents)
                    {
                        if (item.typeID != new Guid("00000000-0000-0000-0000-000000000000") && item.typeID != null)
                        {
                            item.childList = await dbcontext.sections.Include(x => x.Category).Where(x => x.sectionTypeID == item.typeID).Select(x => new sectionVM { categoryName = x.Category.title, title = x.title, description = x.description, metaTitle = x.metatitle, image = x.image, writer = x.writer , date = x.date,url =  x.url}).ToListAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
           


           return response;
        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<getsectionLayoutVM> getPageLayout([FromBody] sectionLayoutVM model)
        {
            getsectionLayoutVM response = new getsectionLayoutVM();
            using (Context dbcontext = new Context())
            {

                var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x=>x.sectionLayoutID == model.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.title, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.title, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).ToList() }).ToList() }).ToListAsync();

                getsectionLayoutVM mymodel = list.First();
              
            }


            return response;
        }

        //verify
        [System.Web.Http.HttpPost]
        public JObject Verify([FromBody] doSignIn model)
        {
            responseModel output = new responseModel();
            using (Context dbcontext = new Context())
            {
                try
                {
                    user myuser = dbcontext.users.SingleOrDefault(x => x.phone == model.phone && x.code == model.code && x.userType == model.userType);
                    if (myuser != null)
                    {
                        output.status = 200;
                        output.message = TokenManager.GenerateToken(model.phone, myuser.userID.ToString());
                    }
                    else
                    {
                        output.message = "Invalid User.";
                        output.status = 400;
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

            }
            string outputstring = JsonConvert.SerializeObject(output);
            JObject jObject = JObject.Parse(outputstring); return jObject;

        }


        // dashboard

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<dashbaordVM> getDashboard([FromBody] doSignIn model)
        {

            dashbaordVM response = new dashbaordVM();
            using (Context dbcontext = new Context())
            {
                response.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
            }

            return response;
        }


        // lanuage
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<LanguagePageVM> getLanguageList([FromBody] doSignIn model)
        {
            LanguagePageVM response = new LanguagePageVM();

            using (Context dbcontext = new Context())
            {
                response.list = await dbcontext.languages.Select(x => new languagVM { title = x.title, languageID = x.languageID }).ToListAsync();
            }
            return response;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setLanguage([FromBody] languagVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.languageID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {

                    }
                    else
                    {
                        language exist = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.title);
                        if (exist == null)
                        {
                            language newlItem = new language()
                            {
                                languageID = Guid.NewGuid(),
                                title = model.title
                            };
                            dbcontext.languages.Add(newlItem);
                            response.status = 200;
                            response.message = "";
                        }
                        else
                        {
                            response.status = 400;
                            response.message = "Language already Exists";
                        }


                    }
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }
        // type

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<typePageVM> getTypeList([FromBody] doSignIn model)
        {
            typePageVM response = new typePageVM();

            using (Context dbcontext = new Context())
            {
                response.list = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
            }
            return response;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setType([FromBody] typeVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.typeID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {

                    }
                    else
                    {
                        sectionType exist = await dbcontext.sectionTypes.SingleOrDefaultAsync(x => x.title == model.title);
                        if (exist == null)
                        {
                            sectionType newlItem = new sectionType()
                            {
                                sectionTypeID = Guid.NewGuid(),
                                title = model.title
                            };
                            dbcontext.sectionTypes.Add(newlItem);
                            response.status = 200;
                            response.message = "";
                        }
                        else
                        {
                            response.status = 400;
                            response.message = "Language already Exists";
                        }


                    }
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        // category
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<categoryPageVM> getCategoryList([FromBody] doSignIn model)
        {
            categoryPageVM response = new categoryPageVM();

            using (Context dbcontext = new Context())
            {
                response.list = await dbcontext.categories.Include(x => x.sectionType).Select(x => new categoryVM { sectionTypeName = x.sectionType.title, title = x.title, categoryID = x.sectionTypeID }).ToListAsync();
                response.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
            }
            return response;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setCategory([FromBody] categoryVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.categoryID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {

                    }
                    else
                    {
                        category exist = await dbcontext.categories.SingleOrDefaultAsync(x => x.title == model.title);
                        if (exist == null)
                        {
                            category newlItem = new category()
                            {
                                categoryID = Guid.NewGuid(),
                                title = model.title,
                                sectionTypeID = model.sectionTypeID
                            };
                            dbcontext.categories.Add(newlItem);
                            response.status = 200;
                            response.message = "";
                        }
                        else
                        {
                            response.status = 400;
                            response.message = "Language already Exists";
                        }


                    }
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        // page 
        [System.Web.Http.HttpPost]
        public async Task<pageListVM> getPage([FromBody] typeVM model)
        {
            pageListVM output = new pageListVM();
            using (Context dbcontext = new Context())
            {
                output.categoryList = await dbcontext.categories.Where(x => x.sectionTypeID == model.typeID).Select(x => new categoryVM { categoryID = x.categoryID, title = x.title }).ToListAsync();
                output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title }).ToListAsync();
                output.sectionList = await dbcontext.sections.Select(x => new sectionVM { languateID = x.languageID, sectionLayoutID = x.sectionLayoutID, image = x.image, metaTitle = x.metatitle, title = x.title, url = x.url, sectinoID = x.sectionID, writer = x.writer }).ToListAsync();
                output.layoutList = await dbcontext.sectionLayouts.Select(x => new sectionLayoutVM { menuTitle = x.menuTitle, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
                sectionType sections = await dbcontext.sectionTypes.FirstOrDefaultAsync(x => x.sectionTypeID == model.typeID);

                output.selectedType = new typeVM()
                {
                    typeID = sections.sectionTypeID,
                    title = sections.title
                };
            }

            return output;

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setSection([FromBody] sectionVM model)
        {
            responseModel response = new responseModel();
            model.url = model.url == null ? "" : model.url;
            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.sectinoID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        section exist = await dbcontext.sections.SingleOrDefaultAsync(x => x.sectionID == model.sectinoID);
                        string lastmessag = exist.image;
                        exist.title = model.title;
                        exist.metatitle = model.metaTitle;
                        exist.url = model.url;
                        exist.image = model.image;
                        if (model.sectionLayoutID != new Guid("00000000-0000-0000-0000-000000000000"))
                            exist.sectionLayoutID = model.sectionLayoutID;
                        if (model.sectinoTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
                            exist.sectionTypeID = model.sectinoTypeID;
                        if (model.languateID != new Guid("00000000-0000-0000-0000-000000000000"))
                            exist.languageID = model.languateID;
                        response.message = lastmessag;
                        response.status = 200;
                        await dbcontext.SaveChangesAsync();
                    }
                    else
                    {
                        section exist = await dbcontext.sections.SingleOrDefaultAsync(x => x.url == model.url && x.languageID == model.languateID);
                        if (exist == null)
                        {
                            section newlItem = new section()
                            {
                                sectionID = Guid.NewGuid(),
                                title = model.title,
                                description = model.description,
                                metatitle = model.metaTitle,
                                image = model.image,
                                sectionTypeID = model.sectinoTypeID,
                                sectionLayoutID = model.sectionLayoutID,
                                languageID = model.languateID,

                                date = DateTime.Now,
                                url = model.url,
                                writer = "admin",



                            };
                            if (model.sectinoID != new Guid("00000000-0000-0000-0000-000000000000"))
                                newlItem.categoryID = model.categoryID;

                            //sectionLayoutID = new Guid()
                            dbcontext.sections.Add(newlItem);
                            response.status = 200;
                            response.message = "";
                        }
                        else
                        {
                            response.status = 400;
                            response.message = "Language already Exists";
                        }


                    }
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }


        // content 
        [System.Web.Http.HttpPost]
        public async Task<contentListVM> getContent([FromBody] sectionVM model)
        {
            contentListVM output = new contentListVM();
            using (Context dbcontext = new Context())
            {
                content content = await dbcontext.contents.Include(x=>x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentParent);
                Guid parentHTML = new Guid();
                if (content!= null){
                    parentHTML = content.HTML.htmlID;
                    model.sectinoID = content.sectionID;
                    output.parentSelected = new contentVM
                    {
                        title = content.title,
                         contentID = content.contentID
                    };
                } 
                section section = await dbcontext.sections.Include(x=>x.SectionLayout).FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);
                
                var querycontent=  dbcontext.contents.Include(x=> x.HTML).Include(x => x.sectionType).Include(x => x.HTML).AsQueryable();
                if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    querycontent = querycontent.Where(x => x.parentID == model.contentParent);
                }
                else
                {
                    querycontent = querycontent.Where(x => x.sectionID == model.sectinoID && x.parentID == null);
                }
                output.contentList = await querycontent.Select(x => new contentVM {  multilayer = x.HTML.multilayer, priority = x.priority, title = x.title, image = x.HTML.image, contentID = x.contentID, htmlName = x.title, typeName = x.sectionType != null ? x.sectionType.title : "" }).OrderBy(x => x.priority).ToListAsync();
                
                var htmlquery=  dbcontext.htmls.Where( x=> x.layout == section.SectionLayout.layoutID ).AsQueryable();
                if (parentHTML != new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    htmlquery = htmlquery.Where(x => x.parentID == parentHTML);
                }
                else
                {
                    htmlquery = htmlquery.Where(x => x.parentID == null);

                }
                output.htmlList = await htmlquery.Select(x => new HTMLVM { partialView = x.partialView, image = x.image, htmlName = x.title, htmlID = x.htmlID }).ToListAsync();



                output.typeList = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();


                output.selectedSection = new sectionVM()
                {
                    sectinoID = section.sectionID,
                    title = section.title
                };
            }

            return output;

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setContent([FromBody] setContentVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    content newlItem = new content()
                    {
                        contentID = Guid.NewGuid(),
                        htmlID = model.htmlID,
                        priority = model.priority,
                        
                        title = model.title,
                        sectionID = model.sectionID
                };

                    if (model.typeID != new Guid("00000000-0000-0000-0000-000000000000"))
                        newlItem.sectionTypeID = model.typeID;
                    if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
                        newlItem.parentID = model.contentParent;
                    


                    dbcontext.contents.Add(newlItem);
                    response.status = 200;
                    response.message = "";
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeContent([FromBody] setContentVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    content selectedContent = await dbcontext.contents.Include(x=>x.Datas).SingleOrDefaultAsync(x => x.contentID == model.contentID);
                    if (selectedContent != null)
                    {
                        if (selectedContent.Datas.Count > 0)
                        {
                            response.status = 400;
                            response.message = "Data Exist In This Content";

                        }
                        else
                        {
                           
                            dbcontext.contents.Remove(selectedContent);
                            response.status = 200;
                            response.message = "";
                            await dbcontext.SaveChangesAsync();
                        }
                    }

                    

                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }


        // meta 
        [System.Web.Http.HttpPost]
        public async Task<metaListVM> getMeta([FromBody] sectionVM model)
        {
            metaListVM output = new metaListVM();
            using (Context dbcontext = new Context())
            {
                output.metaList = await dbcontext.metas.Where(x => x.sectionID == model.sectinoID).Select(x => new MetaVM {  Name = x.name, Content = x.content,  metaID = x.metaID,  sectionID = x.sectionID}).ToListAsync();
                section section = await dbcontext.sections.FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);

                output.selectedSection = new sectionVM()
                {
                    sectinoID = section.sectionID,
                    title = section.title
                };
            }
            return output;

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setMeta([FromBody] MetaVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    meta newlItem = new meta()
                    {
                         metaID = Guid.NewGuid(),
                         name  = model.Name,
                         content = model.Content,
                         sectionID = model.sectionID,
                        


                    };
                   

                    dbcontext.metas.Add(newlItem);
                    response.status = 200;
                    response.message = "";
                    await dbcontext.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeMeta([FromBody] MetaVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    meta selectedContent = await dbcontext.metas.SingleOrDefaultAsync(x => x.metaID == model.metaID);
                    if (selectedContent != null)
                    {
                        dbcontext.metas.Remove(selectedContent);
                        response.status = 200;
                        response.message = "";
                        await dbcontext.SaveChangesAsync();
                    }



                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }



        // data
        [System.Web.Http.HttpPost]
        public async Task<dataListVM> getData([FromBody] contentVM model)
        {
            dataListVM output = new dataListVM();
            
            using (Context dbcontext = new Context())
            {
                content content = await dbcontext.contents.Include(x=>x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentID);
                
                output.dataList = await dbcontext.datas.Where(x => x.contentID == model.contentID).Select(x => new dataVM { priority = x.priority, URL = x.url, dataID = x.dataID, title = x.title, title2 = x.title2, description = x.description, description2 = x.description2, mediaURL = x.mediaURL, viedoIframe = x.viedoIframe }).ToListAsync();
                output.selectedContent = new contentVM()
                {
                    contentID = content.contentID,
                    title = content.title,
                    image = content.title,
                    fields = content.HTML.dataField
                };
            }

            return output;

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setData([FromBody] setDataVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.dataID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        data selectedData = await dbcontext.datas.SingleOrDefaultAsync(x => x.dataID == model.dataID);

                        string lastimage = "";
                        selectedData.title = model.title;
                        selectedData.title2 = model.title2;
                        selectedData.description = model.description;
                        selectedData.description2 = model.description2;
                        selectedData.viedoIframe = model.viedoIframe;
                        selectedData.priority = model.priority;
                        selectedData.url = model.url;
                        

                        if (!string.IsNullOrEmpty(model.mediaURL))
                        {
                            lastimage = selectedData.mediaURL;
                            selectedData.mediaURL = model.mediaURL;
                            
                        }
                       



                        response.status = 200;
                        response.message = lastimage;
                        await dbcontext.SaveChangesAsync();
                    }
                    else
                    {
                        data newlItem = new data()
                        {
                            dataID = Guid.NewGuid(),
                            title = model.title,
                            title2 = model.title2,
                            description = model.description,
                            description2 = model.description2,
                            mediaURL = model.mediaURL,
                            viedoIframe = model.viedoIframe,
                            contentID = model.contentID,
                             url = model.url,
                              priority = model.priority


                        };


                        dbcontext.datas.Add(newlItem);
                        response.status = 200;
                        response.message = "";
                        await dbcontext.SaveChangesAsync();

                    }
                    

                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeData([FromBody] setDataVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    data selectedData = await dbcontext.datas.SingleOrDefaultAsync(x => x.dataID == model.dataID);
                    if (selectedData != null)
                    {
                        dbcontext.datas.Remove(selectedData);
                        response.status = 200;
                        response.message = "";
                        await dbcontext.SaveChangesAsync();
                    }



                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        //layoutpart

        [System.Web.Http.HttpPost]
        public async Task<layoutPartPageVM> getLayoutPart()
        {
            layoutPartPageVM output = new layoutPartPageVM();
            using (Context dbcontext = new Context())
            {
                output.partlist = await dbcontext.layoutParts.Select(x => new layoutpartVM { layoutPartID = x.layoutPartID, title = x.title, typeName = x.typeName }).ToListAsync();
                output.langauageList = await dbcontext.languages.Select(x => new languagVM {   languageID = x.languageID,  title = x.title }).ToListAsync();
            }
            return output;

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setLayoutPart([FromBody] layoutPartSetVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    layoutPart lp = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.title == model.title && x.languageID == model.languageID);
                    if(lp == null)
                    {
                        layoutPart newlItem = new layoutPart()
                        {
                            layoutPartID  = Guid.NewGuid(),
                            title = model.title,
                            languageID = model.languageID,
                            typeName = model.typeName
                        };


                        dbcontext.layoutParts.Add(newlItem);
                        response.status = 200;
                        response.message = "";
                        await dbcontext.SaveChangesAsync();
                    }
                    else
                    {
                        response.status = 400;
                        response.message = "Item exists";

                    }

                   


                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeLayoutPart([FromBody] layoutPartSetVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    layoutPart selectedlayoutPart = await dbcontext.layoutParts.Include(x => x.SectionLayouts).SingleOrDefaultAsync(x => x.layoutPartID == model.layoutPartID);
                    if (selectedlayoutPart != null)
                    {
                        if (selectedlayoutPart.SectionLayouts.Count > 0)
                        {
                            response.status = 400;
                            response.message = "this model is uesed in layouts";

                        }
                        else
                        {

                            dbcontext.layoutParts.Remove(selectedlayoutPart);
                            response.status = 200;
                            response.message = "";
                            await dbcontext.SaveChangesAsync();
                        }
                    }



                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        //layoutpartData

        [System.Web.Http.HttpPost]
        public async Task<layoutPartDataPageVM> getLayoutPartData(layoutpartVM model)
        {
            layoutPartDataPageVM output = new layoutPartDataPageVM();
            using (Context dbcontext = new Context())
            {
                output.datalist = await dbcontext.layoutDatas.Where(x=>x.layoutPartID ==model.layoutPartID).Include(x=>x.sectionType).Include(x=>x.parentData).Select(x => new layoutpartDataVM { priority= x.priority, urlTitle = x.urlTitle, parentID = x.parentData.parentID, sectionTypeID = x.sectionType.sectionTypeID, parentName = x.parentData != null? x.parentData.title : "",   image = x.image,   title = x.title,   url = x.url, typeTitle = x.sectionType.title, typeCount = x.typeCount, layoutDataID = x.layoutDataID  }).OrderByDescending(x=>x.priority).ToListAsync();
                output.typelist = await dbcontext.sectionTypes.Select(x => new typeVM {  title = x.title, typeID = x.sectionTypeID  }).ToListAsync();
                var layoutpart = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == model.layoutPartID);

                output.layoutpart = new layoutpartVM()
                {
                    layoutPartID = layoutpart.layoutPartID,
                    title = layoutpart.title,
                };
            }
            return output;

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setLayoutPartData([FromBody] layoutpartDataVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                   
                    if (model.layoutDataID == new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        layoutData layoutdata = await dbcontext.layoutDatas.SingleOrDefaultAsync(x => x.title == model.title && x.layoutPartID == model.layoutPartID);
                        if (layoutdata == null)
                        {
                            layoutData newlItem = new layoutData()
                            {
                                layoutDataID = Guid.NewGuid(),
                                title = model.title,
                                image = model.image,
                                 priority= model.priority,
                                url = model.url,
                                typeCount = model.typeCount,
                                layoutPartID = model.layoutPartID,
                                 urlTitle = model.urlTitle,

                            };
                            if (model.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
                            {
                                newlItem.sectionTypeID = model.sectionTypeID;
                            }
                            if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
                            {
                                newlItem.parentID = model.parentID;
                            }

                            dbcontext.layoutDatas.Add(newlItem);
                            response.status = 200;
                            response.message = "";
                            await dbcontext.SaveChangesAsync();

                        }
                        else
                        {
                            response.status = 400;
                            response.message = "Item exists";
                        }
                            
                    }
                    else
                    {
                        layoutData layoutdata = await dbcontext.layoutDatas.SingleOrDefaultAsync(x => x.layoutDataID == model.layoutDataID);
                        string lastmessag = layoutdata.image;
                       
                        layoutdata.title = model.title;
                        layoutdata.urlTitle = model.urlTitle;
                        layoutdata.priority = model.priority;
                        layoutdata.image = model.image;
                        layoutdata.url = model.url;
                        layoutdata.typeCount = model.typeCount;
                        if (model.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            layoutdata.sectionTypeID = model.sectionTypeID;
                        }
                        if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            layoutdata.parentID = model.parentID;
                        }
                        response.message = lastmessag;
                        response.status = 200;
                        await dbcontext.SaveChangesAsync();

                    }




                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeLayoutPartData([FromBody] layoutpartDataVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    layoutData selectedlayoutPart = await dbcontext.layoutDatas.Include(x=>x.childs).SingleOrDefaultAsync(x => x.layoutDataID == model.layoutDataID);
                    if (selectedlayoutPart != null)
                    {
                        if (selectedlayoutPart.childs.Count > 0)
                        {
                            response.status = 400;
                            response.message = "this model is uesed in layouts";

                        }
                        else
                        {

                            dbcontext.layoutDatas.Remove(selectedlayoutPart);
                            response.status = 200;
                            response.message = "";
                            await dbcontext.SaveChangesAsync();
                        }
                    }



                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        //layout

        [System.Web.Http.HttpPost]
        public async Task<layoutPageVM> getLayout()
        {
            layoutPageVM output = new layoutPageVM();
            using (Context dbcontext = new Context())
            {
                output.langauageList = await dbcontext.languages.Select(x => new languagVM {  languageID = x.languageID, title = x.title, }).ToListAsync();
                output.layoutObjectLists = await dbcontext.sectionLayouts.Include(x=>x.Language).Include(x=>x.Layout).Include(x=>x.LayoutParts).Select(x => new layoutObjectVM { partnames = x.LayoutParts.Select(d=>d.title).ToList(),  menuTitle = x.menuTitle,   languageName = x.Language.title,  description = x.Layout.description, image = x.Layout.image, name = x.Layout.name, title = x.Layout.title, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
                output.layoutLists = await dbcontext.layouts.Select(x => new layoutVM { partName = x.partName, description = x.description, image = x.image, layoutID = x.layoutID, name = x.name, title = x.title }).ToListAsync();
               
                foreach(var item in output.layoutLists)
                {
                    //List<layoutPart> lst = dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).ToList();
                    item.partlist = await dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).Select(x=> new layoutpartVM {  languageID = x.languageID, title = x.title, typeName = x.typeName, layoutPartID = x.layoutPartID}).ToListAsync();
                }

            }
            return output;

        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setSectionLayout([FromBody] setSectionLayoutVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {

                    sectionLayout layoutdata = await dbcontext.sectionLayouts.SingleOrDefaultAsync( x => x.languageID == model.languageID && x.layoutID == model.layoutID && x.menuTitle == model.menuTitle);
                    if (layoutdata == null)
                    {
                        layout selectlayout = await dbcontext.layouts.SingleOrDefaultAsync(x => x.layoutID == model.layoutID);
                        Guid sectionlayoutID = Guid.NewGuid();
                        sectionLayout newlItem = new sectionLayout()
                        {
                            sectionLayoutID = sectionlayoutID,
                             languageID = model.languageID,
                              layoutID = model.layoutID,
                                menuTitle = model.menuTitle
                           

                        };

                        
                        foreach (var item in model.layoutPartID)
                        {
                            Guid idguid = new Guid(item);
                            layoutPart part = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == idguid);
                            if (part != null)
                            {
                                newlItem.LayoutParts.Add(part);
                            }
                        }
                        dbcontext.sectionLayouts.Add(newlItem);
                        response.status = 200;
                        response.message = "";
                        await dbcontext.SaveChangesAsync();

                    }
                    else
                    {
                        response.status = 400;
                        response.message = "Item exists";
                    }





                }
                catch (Exception e)
                {
                    response.status = 400;
                    response.message = "Error ! ";

                }


            }

            string result = JsonConvert.SerializeObject(response);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }
        

    }
}