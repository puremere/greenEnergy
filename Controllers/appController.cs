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
using greenEnergy.ViewModel;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System.Drawing;




//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using System.Data.Entity;
//using jbar.Classes;
//using jbar.Model;
//using Newtonsoft.Json;
//using System.Net;
//using System.IO;
//using System.Data.Entity.Spatial;
//using Google.Apis.Auth.OAuth2;
//using FirebaseAdmin;
//using FirebaseAdmin.Messaging;
//using System.Web.Hosting;
//using System.Text;
//using System.Net.Http;
//using Spire.Pdf;
//using Spire.Pdf.Texts;
//using System.Drawing;
//using Spire.OCR;

namespace greenEnergy.Controllers
{
    public class appController : System.Web.Http.ApiController
    {


        public async Task<string> getChartData( viewVM? datamodel)
        {
            string srt = "";
            var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "chartData");

            managerChartmain mymodel = (managerChartmain)formDataSection.items.First();
            srt = JsonConvert.SerializeObject(mymodel);

            return srt;

        }
        public async Task<string> getFormData(Guid? formID, viewVM? datamodel)
        {
            string srt = "";
            listOfFormVM response = new listOfFormVM();
            List<formItemList> formList = new List<formItemList>();
            using (Context dbcontext = new Context())
            {
                form form = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == formID);
                Guid typeid = new Guid("bdbf1018-bad4-43c5-9181-f8ea3fb1d994");// متنی تصویر دار
                formItemList fil = new formItemList();
                fil.formID = form.formID;
                fil.formTitle = form.title;
                fil.formImage = form.image;
                fil.formHieght = form.imageHeight;
                fil.formWidth = form.imageWidth;
                fil.zaribWidth = form.zaribWidth;
                fil.zaribHeight = form.zaribHeight;

                fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { formItemTypeCode = x.FormItemType.formItemTypeCode, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemx = x.itemx, itemy = x.itemy, itemHeight = x.itemHeight, itemlength = x.itemLenght, pageNumber = x.pageNumber, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
                if (datamodel.chunkList != null)
                {
                    var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "formData");


                    if (formDataSection != null)
                    {

                        foreach (var oplist in formDataSection.items)
                        {
                            var selecteditem = fil.formItemDetailList.SingleOrDefault(x => x.itemName == oplist.name);
                            if (selecteditem != null)
                            {
                                formOptionObject mymodel = (formOptionObject)oplist;
                                selecteditem.orderOptions = mymodel.lst;
                            }
                        }
                    }

                }


                List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { itemHeight = l.itemHeight, itemlength = l.itemLenght, itemx = l.itemx, itemy = l.itemy, pageNumber = l.pageNumber, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();
                int index = 0;
                foreach (var item in lst)
                {
                    formFullDetailItemVM extraDetail = new formFullDetailItemVM();
                    extraDetail.stringImageCollection = item;
                    extraDetail.formItemTypeCode = "2";


                    fil.formItemDetailList.Insert(index, extraDetail);
                    index += 1;
                }


                formList.Add(fil);
            }
            response.allForm = formList;
            srt = JsonConvert.SerializeObject(response);
            return srt;

        }
        public async Task<getChildContentVM> getChildContent(Guid? sectinoID, pageContentVM? content, viewVM? datamodel, Dictionary<string, string> HtmlItems)
        {
            List<pageContentVM> response = new List<pageContentVM>();
            getChildContentVM modelResponce = new getChildContentVM();
            using (Context dbcontext = new Context())
            {
                string finalStackPose = "";

                string finalPose = "";
                string finalHtml = "";
                string finalCycleFields = "";
                if (sectinoID != null)
                {
                    response = await dbcontext.contents.Where(x => x.sectionID == sectinoID && x.parentID == null).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM { htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();

                    foreach (var item in response)
                    {

                        if (string.IsNullOrEmpty(item.cycleFields))
                        {
                            if (!string.IsNullOrEmpty(item.cycleFields))
                            {
                                List<string> fieldslist = item.cycleFields.Trim(',').Split(',').ToList();
                                foreach (var field in fieldslist)
                                {
                                    recycleDataMapVM mdl = new recycleDataMapVM()
                                    {
                                        viewID = item.title,
                                        dataProperty = item.title + "_" + field,
                                        viewProperty = item.title
                                    };
                                    finalCycleFields += JsonConvert.SerializeObject(mdl);
                                }
                            }

                        }
                        List<string> values = item.htmlFields.Split(',').Select(s => s.ToString()).ToList();
                        foreach(var htmlfield in values)
                        {
                            dataVM sdata = item.dataList.SingleOrDefault(x => x.title == htmlfield && !string.IsNullOrEmpty(x.title2));
                            if (sdata != null)
                            {
                                item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
                            }
                            else
                            {
                                item.appMeta = await methods.removenull(item.appMeta, htmlfield);
                            }
                        }
                     
                        if (!string.IsNullOrEmpty(item.stackWeight))
                        {
                            stackPoseVM sp = new stackPoseVM()
                            {
                                viewID = item.title,
                                weight = double.Parse(item.stackWeight)
                            };
                            finalStackPose += JsonConvert.SerializeObject(sp) + ",";
                        }
                        if (item.formID != null)
                        {
                            finalHtml += item.appMeta + ",";

                            string myresult = await getFormData(item.formID, datamodel);
                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
                            item.appMeta = item.appMeta.Replace("childMetaString", myresult);

                        }
                        else
                        {


                            if (!HtmlItems.ContainsKey(item.title))
                            {
                                HtmlItems["childMetaString"] += item.appMeta + ",";
                            }
                            else
                            {
                                HtmlItems[item.title] += item.appMeta + ",";
                            }
                            //finalHtml += item.appMeta + ",";
                            Dictionary<string, string> hitems = new Dictionary<string, string>();
                            hitems.Add("childMetaString", "");
                            if (item.appType == "page")
                            {
                                hitems.Add("leadsrt", "");
                                hitems.Add("trailsrt", "");
                            }
                            getChildContentVM myresult = await getChildContent(null, item, datamodel, hitems);
                            item.contentChild = myresult.list;
                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
                            foreach (var nm in myresult.newMeta)
                            {
                                string replacestring = nm.Value;
                                if (string.IsNullOrEmpty(replacestring) && nm.Key != "childMetaString")
                                {
                                    replacestring = "null";
                                }
                                item.appMeta = item.appMeta.Replace(nm.Key, replacestring.Trim(',')).Trim(',');
                            }

                            item.poseMeta = item.appMeta.Replace("childPoseString", myresult.newPose.Trim(','));
                            if (item.appType == "cycleView")
                            {
                                item.appMeta = item.appMeta.Replace("dataMapString", myresult.cycleMeta.Trim(','));
                            }


                        }


                    }
                    //{"nav": null,"view": {"type": "stackView","orientation": 0,"backColor": "#222222","cornerRadius": 10,"content": [childMetaString] }}
                    //{"type": "pairTextView","viewID": "secondLabel","id": "priceID","keyText": "Name","valueText": "title","keyColor": "#ffffff","valueColor": "#ececec"}
                    //{"type": "button","viewID" :"viewMetaIDsrt","text":"textsrt","color":"colorsrt","backColor":"backColorsrt","borderColor":"borderColorsrt","cornerRadius":cornerRadiussrt,"alignment":"alignmentsrt","font":"fontsrt","size":sizesrt,"width":widthsrt,"height":heightsrt,"margin":marginsrt, "actions":[childMetaString] }
                    //{"type":"typesrt","to":"tosrt","orientation":orientationsrt,"varName":"varNamesrt", "value":"valuesrt"}
                }
                else
                {
                    response = await dbcontext.contents.Where(x => x.parentID == content.conentID).Include(x => x.Poses).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM {  htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, poseMeta = l.HTML.poseMeta, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, poseList = l.Poses.Select(x => new poseVM { poseID = x.poseID, title = x.title, title2 = x.title2 }).ToList(), dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();

                    foreach (var item in response)
                    {
                        if (!string.IsNullOrEmpty(item.cycleFields))
                        {
                            List<string> fieldslist = item.cycleFields.Trim(',').Split(',').ToList();
                            foreach (var field in fieldslist)
                            {
                                recycleDataMapVM mdl = new recycleDataMapVM()
                                {
                                    viewID = item.title,
                                    viewProperty = field.Replace("srt",""),
                                    dataProperty = item.title + "_" + field,



                                };
                                finalCycleFields += JsonConvert.SerializeObject(mdl) + ",";
                            }
                        }
                        List<string> values = item.htmlFields.Split(',').Select(s => s.ToString()).ToList();
                        foreach (var htmlfield in values)
                        {
                            dataVM sdata = item.dataList.SingleOrDefault(x => x.title == htmlfield && !string.IsNullOrEmpty(x.title2));
                            if (sdata != null)
                            {
                                if (datamodel.chunkList != null)
                                {
                                    itemParent dlst = datamodel.chunkList.SingleOrDefault(x => x.name == "main");
                                    if (dlst != null)
                                    {
                                        string itemnamee = item.title + "_" + sdata.title.Replace("srt", "");
                                        if (dlst.items != null)
                                        {
                                            if (dlst.items[0].GetType().GetProperty(itemnamee) != null)
                                            {
                                                string newsrt = dlst.items[0].GetType().GetProperty(itemnamee).GetValue(dlst.items[0], null) + "";
                                                item.appMeta = item.appMeta.Replace(sdata.title, newsrt);
                                            }
                                            else
                                            {
                                                item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
                                            }
                                        }

                                        else
                                        {
                                            item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
                                        }


                                    }
                                    else
                                    {
                                        item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
                                    }
                                }
                                else
                                {
                                    item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
                                }
                            }
                            else
                            {
                                item.appMeta = await methods.removenull(item.appMeta, htmlfield);
                            }
                        }
                        
                        if (!string.IsNullOrEmpty(item.stackWeight))
                        {
                            stackPoseVM sp = new stackPoseVM()
                            {
                                viewID = item.title,
                                weight = double.Parse(item.stackWeight)
                            };
                            finalStackPose += JsonConvert.SerializeObject(sp) + ",";
                        }
                        if (item.formID != null)
                        {
                            //finalHtml += item.appMeta + ",";
                            string myresult = await getFormData(item.formID,datamodel);
                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
                            item.appMeta = item.appMeta.Replace("childMetaString", myresult);

                            if (!HtmlItems.ContainsKey(item.title))
                            {
                                HtmlItems["childMetaString"] += item.appMeta + ",";
                            }
                            else
                            {
                                HtmlItems[item.title] += item.appMeta + ",";
                            }
                            //finalHtml += item.appMeta + ",";
                            finalPose += item.poseMeta + ",";

                        }
                        else
                        {
                            if (item.appType == "chartView")
                            {
                                string myresult = await getChartData(datamodel);
                                item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
                                item.appMeta = item.appMeta.Replace("childMetaString", myresult);

                                if (!HtmlItems.ContainsKey(item.title))
                                {
                                    HtmlItems["childMetaString"] += item.appMeta + ",";
                                }
                                else
                                {
                                    HtmlItems[item.title] += item.appMeta + ",";
                                }
                                //finalHtml += item.appMeta + ",";
                                finalPose += item.poseMeta + ",";
                            }
                            else
                            {
                                Dictionary<string, string> hitems = new Dictionary<string, string>();
                                hitems.Add("childMetaString", "");
                                if (item.appType == "page")
                                {
                                    hitems.Add("leadsrt", "");
                                    hitems.Add("trailsrt", "");
                                }
                                getChildContentVM myresult = await getChildContent(null, item, datamodel, hitems);
                                item.appMeta = item.appMeta.Replace("childPoseString", myresult.newPose.Trim(','));
                                item.appMeta = item.appMeta.Replace("stackPose", myresult.stackPose.Trim(','));
                                item.contentChild = myresult.list;
                                finalCycleFields += myresult.cycleMeta;
                                int counter = 0;
                                foreach (var poseItem in item.poseList)
                                {
                                    if (string.IsNullOrEmpty(poseItem.title2))
                                    {
                                        item.poseMeta = await methods.removenull(item.poseMeta, poseItem.title);
                                    }
                                    else
                                    {
                                        item.poseMeta = item.poseMeta.Replace(poseItem.title, poseItem.title2);
                                        counter += 1;
                                    }



                                }
                                if (counter != 0)
                                {
                                    string newposemeta = item.poseMeta.Replace("ViewIDsrt", item.title);
                                    item.poseMeta = newposemeta;
                                    finalPose += item.poseMeta + ",";
                                }
                                item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
                                foreach (var nm in myresult.newMeta)
                                {
                                    string replacestring = nm.Value;
                                    if (string.IsNullOrEmpty(replacestring) && nm.Key != "childMetaString")
                                    {
                                        replacestring = "null";
                                    }
                                    item.appMeta = item.appMeta.Replace(nm.Key, replacestring.Trim(',')).Trim(',');
                                }



                                if (item.appType == "cycleView")
                                {
                                    if (datamodel.chunkList != null)
                                    {
                                        itemParent dlst = datamodel.chunkList.SingleOrDefault(x => x.name == item.title);

                                        List<recycleDataMapVM> mylist = JsonConvert.DeserializeObject<List<recycleDataMapVM>>("[" + myresult.cycleMeta + "]");
                                        List<Dictionary<string, object>> finaldatalist = new List<Dictionary<string, object>>();


                                        if (dlst != null)
                                        {
                                            for (int i = 0; i < dlst.items.Count(); i++)
                                            {
                                                Dictionary<string, object> iii = new Dictionary<string, object>();
                                                iii.Add("patternId", "patternId1");
                                                if (dlst.items[i].GetType().GetProperty("actions") != null)
                                                {
                                                    iii.Add("onClick", dlst.items[i].GetType().GetProperty("actions").GetValue(dlst.items[i], null));
                                                }
                                                foreach (var cycleM in mylist)
                                                {
                                                    var dd = dlst.items[i];
                                                    iii.Add(cycleM.dataProperty, dd.GetType().GetProperty(cycleM.dataProperty).GetValue(dd, null).ToString());

                                                }
                                                finaldatalist.Add(iii);




                                            }
                                        }

                                        item.appMeta = item.appMeta.Replace("dataitemsstring", JsonConvert.SerializeObject(finaldatalist).Trim(','));
                                        item.appMeta = item.appMeta.Replace("dataMapString", myresult.cycleMeta.Trim(','));
                                    }
                                    else
                                    {
                                        item.appMeta = item.appMeta.Replace("dataitemsstring", "[]");
                                        item.appMeta = item.appMeta.Replace("dataMapString", "");

                                    }


                                }
                                if (!HtmlItems.ContainsKey(item.title))
                                {
                                    HtmlItems["childMetaString"] += item.appMeta.Trim(',') + ",";
                                }
                                else
                                {
                                    HtmlItems[item.title] += item.appMeta.Trim(',');
                                }
                            }
                            
                            //finalHtml += item.appMeta + ",";

                        }

                    }

                }


                modelResponce.newMeta = HtmlItems;
                modelResponce.newPose = finalPose;
                modelResponce.list = response;
                modelResponce.cycleMeta = finalCycleFields;
                modelResponce.stackPose = finalStackPose;
            }





            return modelResponce;
        }

        [System.Web.Http.HttpPost]
        public async Task<appPageSectionVM> getAppURL([FromBody] getURLVM model)

        {
            viewVM data = await getData(model);

            Dictionary<string, string> initdata = new Dictionary<string, string>();
            initdata.Add("itemid", "132");


            appPageSectionVM finalResult = new appPageSectionVM();
            pageSectionVM response = new pageSectionVM();
            try
            {



                model.slug = model.slug == null ? "" : model.slug;
                using (Context dbcontext = new Context())
                {
                    model.lang = string.IsNullOrEmpty(model.lang) ? "En" : model.lang;
                    language lng = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.lang);
                    //Include(x => x.Contents.Select(l => l.HTML)).Include(x => x.Contents.Select(y => y.Datas)).Include(x => x.Contents.Select(y => y.childContent)).Include(x => x.Contents.Select(y => y.childContent.Select(z => z.Datas)))

                    var responseList = await dbcontext.sections.Include(x => x.SectionLayout).Include(x => x.Metas).Where(x => x.url == model.slug && x.languageID == lng.languageID).Select(x => new pageSectionVM { sectionID = x.sectionID, Metas = x.Metas.Select(p => new MetaVM { Name = p.name, Content = p.content }).ToList(), date = x.date, title = x.title, image = x.image, url = x.url, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
                    response = responseList.First();
                    var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == response.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.name, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.typeName, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { layoutDataID = m.layoutDataID, parentID = m.parentID == null ? null : m.parentID, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).OrderBy(m => m.priority).ToList() }).ToList() }).ToListAsync();
                    response.layoutModel = list.First();
                    Dictionary<string, string> hitems = new Dictionary<string, string>();
                    hitems.Add("childMetaString", "");
                    getChildContentVM myresult = await getChildContent(response.sectionID, null, data, hitems);
                    response.Contents = myresult.list;
                    JAResult rslt = new JAResult()
                    {
                        page = response.Contents.First().appMeta,
                        initData = initdata,
                    };

                    finalResult.code = 0;
                    finalResult.result = rslt;
                    //foreach (var item in response.Contents)
                    //{
                    //    if (item.typeID != new Guid("00000000-0000-0000-0000-000000000000") && item.typeID != null)
                    //    {
                    //        item.childList = await dbcontext.sections.Include(x => x.Category).Where(x => x.sectionTypeID == item.typeID).Select(x => new sectionVM { buttonText = x.buttonText, categoryName = x.Category.title, title = x.title, description = x.description, metaTitle = x.metatitle, image = x.image, writer = x.writer, date = x.date, url = x.url }).ToListAsync();
                    //    }
                    //}
                }
            }
            catch (Exception e)
            {
                throw;
            }



            return finalResult;
        }
        private async Task<viewVM> getData([FromBody] getURLVM model)
        {

            viewVM rsp = new viewVM();
            List<parent> parentlist = new List<parent>();
            itemParent cycle0 = new itemParent() // برای همه
            {
                name = "main",
            };
            List<itemParent> lst0 = new List<itemParent>();
            using (Context dbcontext = new Context())

            {
                switch (model.slug)
                {
                    case "app/getOrderFlowManager":

                        string Guidstring = model.data["orderID"];
                        Guid selectedOrderID = new Guid(Guidstring);
                        List<managerFlowList_orderFlowCycle> flowlist = await dbcontext.newOrderFlows.Where(x=>x.newOrderID == selectedOrderID).Select(x => new managerFlowList_orderFlowCycle {  orderName_valueTextsrt = x.NewOrder.orderName, processName_valueTextsrt = x.newOrderProcess.title, serventName_valueTextsrt = x.newOrderFlowServent != null? x.newOrderFlowServent.phone : "", FlowID = x.newOrderFlowID.ToString() }).ToListAsync();
                        
                        
                        parentlist = new List<parent>();
                        foreach (var item in flowlist)
                        {
                            List<actionResonse> actionList = new List<actionResonse>();
                            actionResonse action1 = new actionResonse()
                            {
                                 type = "a.putVar",
                                  varName = "flowID",
                                   value = item.FlowID
                            };
                            actionList.Add(action1);
                            

                            actionResonse action2 = new actionResonse()
                            {
                                type = "a.go",
                                to = "app/showForm",
                                value = item.FlowID
                            };
                            actionList.Add(action2);
                            item.actions = actionList;
                            parentlist.Add(item);
                        }
                        itemParent flowCycle = new itemParent()
                        {
                            name = "orderFlowCycle",
                            items = parentlist
                        };

                        List<itemParent> flowParentlst = new List<itemParent>();
                        flowParentlst.Add(flowCycle);
                        rsp.chunkList = flowParentlst;
                        break;

                    case ("app/getOrderListManager"):
                        string toDate = "";
                        string fromDate = "";
                        string search = "";
                        if (model.data != null)
                        {
                            foreach (var item in model.data)
                            {
                                if (item.Key == "toDate")
                                {
                                    toDate = item.Value;
                                }
                                if (item.Key == "fromDate")
                                {
                                    fromDate = item.Value;
                                }
                                if (item.Key == "search")
                                {
                                    search = item.Value;
                                }
                            }
                        }

                        List<cycleStackView_orderListManagerVM> cyclelist = await dbcontext.NewOrders.Select(x => new cycleStackView_orderListManagerVM {  projectName_orderListManager_valueTextsrt = x.orderName, orderDate_orderListManager_valueTextsrtdate = x.creationDate,  historyButton_orderListManager_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\""+x.newOrderID+ "\"},{\"type\":\"a.go\",\"to\":\"app/getOrderFlowManager\"}]" }).ToListAsync();
                        parentlist = new List<parent>();
                        foreach (var item in cyclelist)
                        {
                            item.orderDate_orderListManager_valueTextsrt = item.orderDate_orderListManager_valueTextsrtdate.ToShortDateString();
                            parentlist.Add(item);
                        }
                        itemParent cycle = new itemParent()
                        {
                            name = "orderListCycle_orderListManager",
                            items = parentlist
                        };

                        List<itemParent> lst = new List<itemParent>();
                        lst.Add(cycle);
                        rsp.chunkList = lst;

                        break;

                    case ("app/managerChart"):

                        ManagerChartSearch inputModel = new ManagerChartSearch();

                        string sd = "";
                        string ed = "";
                        if (model.data != null)
                        {
                            foreach (var item in model.data)
                            {
                                if (item.Key == "startDate")
                                {
                                    sd = item.Value;
                                }
                                if (item.Key == "endDate")
                                {
                                    ed = item.Value;
                                }
                            }
                        }

                        inputModel.startDate = sd;
                        inputModel.endDate = ed;
                        List<serventChartVM> lllsssttt = await GetDataForManagerChart(inputModel);
                        managerChartmain datttamodel = new managerChartmain()
                        {
                            name = "",
                            list = lllsssttt
                        };
                        parentlist.Add(datttamodel);
                        cycle0.items = parentlist;
                        cycle0.name = "chartData";
                        lst0.Add(cycle0);
                        rsp.chunkList = lst0;

                        break;
                    case ("app/productDetail"):


                        string orderID = model.data["orderID"];
                        Guid orderIDguid = new Guid(orderID);
                        newOrderFlow flowitem = await dbcontext.newOrderFlows.OrderBy(x => x.actionDate).FirstOrDefaultAsync(x => x.newOrderID == orderIDguid);
                        Guid flowID = flowitem.newOrderFlowID;
                        Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");

                        List<newOrderFields> fields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flowID).ToListAsync();

                        productDetailApp datamodel = new productDetailApp()
                        {
                            pertTextDescription_valueText = fields.SingleOrDefault(x => x.name == "description").valueString,
                            pertTextTitle_valueText = fields.SingleOrDefault(x => x.name == "productTitle").valueString,
                        };
                        parentlist.Add(datamodel);
                        cycle0.items = parentlist;


                        lst0.Add(cycle0);
                        rsp.chunkList = lst0;

                        break;
                    case ("app/getList"):

                        break;
                    case "app/createNewProduct":

                        break;
                    case "app/managerOrderList":

                        

                        break;
                     // iggtailordynamic

                   
                    case ("app/searchChartManager"):
                        // یک لیست از مدل بیس می سازیم
                        parentlist = new List<parent>();
                        // ابجکت مخصوص استفاده از فرم را ایجاد میکنیم
                        // این فرم برای پر کردن یکی از آیتم های فرم جستجوی چارت استفاده می شود
                        List<orderOptionVM> tailorlst =await dbcontext.users.Where(x => x.barbariID != null).Select(x => new orderOptionVM { title = x.phone, orderOptionID = x.userID }).ToListAsync();
                        formOptionObject mymodel = new formOptionObject()
                        {
                            name = "tailorList",
                            lst = tailorlst
                        };
                        parentlist.Add(mymodel);
                        cycle0.items = parentlist;
                        cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
                        lst0.Add(cycle0);
                        rsp.chunkList = lst0;


                        break;

                    case ("app/clientOrderListPending"):
                        // تو این اکشن دو تا آبجکت ایجاد میشه 
                        // یکی مین برای دکمه های بالا
                        // یکی لیست برای سایکل این صفحه
                        // برای آبحکت های صفه از cycle0 استفاده میکنیم
                        // که برای انتقال داده های اصلی به کار میره
                        // برای سایکل خودمون یه لیست ابجکت اضافه میکنیم /
                        // و به لیست اضافه میکنیم
                        parentlist = new List<parent>();
                        List<clientorderListPending> CYCLElIST = new List<clientorderListPending>();
                        // اینجا ما باید آیتم های مورد استفاده درسایکل رو فراخوانی کنیم
                        foreach(var item in CYCLElIST)
                        {
                            parentlist.Add(item);
                        }
                        itemParent clientcycle = new itemParent() // برای همه
                        {
                            name = "cycleStackView",
                            items = parentlist
                        };
                        lst0.Add(clientcycle);

                        List<parent> mainObjectList = new List<parent>();
                        clientOrderListButton mainobj = new clientOrderListButton();
                        // اینجا ما باشد با توجه به متغیر های ارسال شده رنگ های 
                        // مرتبط با دکمه ها را تغییر دهیم
                        mainobj.pendingTabBotton_colorsrt = "cGreen";
                        mainobj.acceptedTabBotton_colorsrt = "cGrayLight";
                        mainObjectList.Add(mainobj);
                        cycle0.items = mainObjectList;
                        lst0.Add(cycle0);




                        break;
                    case ("app/setFlowForm"):
                        
                        parentlist = new List<parent>();
                        newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                        List<orderOptionVM> orderList = await dbcontext.NewOrders.Where(x => x.newOrderStatusID == orderstatus.newOrderStatusID).Select(x => new orderOptionVM { title = x.orderName, orderOptionID = x.newOrderID }).ToListAsync();
                        formOptionObject orderOBJ = new formOptionObject()
                        {
                            name = "orderList",
                            lst = orderList
                        };
                        parentlist.Add(orderOBJ);
                        List<orderOptionVM> processList = await dbcontext.processes.Select(x => new orderOptionVM { title = x.title, orderOptionID = x.processID }).ToListAsync();
                        orderOBJ = new formOptionObject()
                        {
                            name = "processList",
                            lst = processList
                        };
                        parentlist.Add(orderOBJ);


                        cycle0.items = parentlist;
                        cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
                        lst0.Add(cycle0);
                        rsp.chunkList = lst0;
                        break;




                }

            }


            return rsp;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<appResponse> setFormData([FromBody] getURLVM model)
        {
            appResponse response = new appResponse();
            resultResponse result = new resultResponse();
            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            
            if (someObject != null || model.slug == "app/verify" || model.slug == "app/setCode")
            {

                switch (model.slug)
                {
                    case "app/getOrderListManager":
                        
                        List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();
                       
                        if (model.form != null)
                        {
                            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
                            var toDate = lstform.SingleOrDefault(x => x.key == "toDate");
                            var fromDate = lstform.SingleOrDefault(x => x.key == "fromDate");
                            var search = lstform.SingleOrDefault(x => x.key == "search");
                            if (toDate != null)
                            {
                                if (!string.IsNullOrEmpty(toDate.value))
                                {
                                    actionResonse todate = new actionResonse()
                                    {
                                        type = "a.putVar",
                                        varName = "toDate",
                                        value = toDate.value

                                    };
                                    getOrderListManagerActionlist.Add(todate);
                                }
                            }
                            if (fromDate != null)
                            {
                                if (!string.IsNullOrEmpty(fromDate.value))
                                {
                                    actionResonse fromdate = new actionResonse()
                                    {
                                        type = "a.putVar",
                                        varName = "fromDate",
                                        value = fromDate.value

                                    };
                                    getOrderListManagerActionlist.Add(fromdate);
                                }
                            }
                            if (search != null)
                            {
                                if (!string.IsNullOrEmpty(search.value))
                                {
                                    actionResonse searchVar = new actionResonse()
                                    {
                                        type = "a.putVar",
                                        varName = "search",
                                        value = search.value

                                    };
                                    getOrderListManagerActionlist.Add(searchVar);
                                }

                            }


                            
                            break;
                        }
                        actionResonse ago = new actionResonse()
                        {
                            type = "a.go",
                            to = "app/getOrderListManager",


                        };
                        getOrderListManagerActionlist.Add(ago);
                        result.actions = getOrderListManagerActionlist;
                        response.result = result;
                        response.code = 0;
                        break;
                    case "app/setTailorForm":
                        Guid userID = new Guid(someObject.ToString());

                        await setTailorForm(model, userID);
                        //getListResponceVM modeldata = await getData(model);
                        List<actionResonse> actionlist = new List<actionResonse>();
                        actionResonse action1 = new actionResonse()
                        {
                            type = "a.back",
                            depth = "1",
                            startDelay = 2000
                        };


                        actionlist.Add(action1);
                        action1 = new actionResonse()
                        {
                            type = "a.message",
                            text = "فعلت بنجاح",
                        };
                        actionlist.Add(action1);

                        result.actions = actionlist;
                        response.result = result;
                        response.code = 0;
                        break;
                    //   زمانی که فرم ثبت نام سابمیت میشه
                    case "app/verify":

                        string phoneSended = await handleRegistration(model);
                        actionlist = new List<actionResonse>();
                        action1 = new actionResonse()
                        {
                            type = "a.putVar",
                            varName = "phone",
                            value = phoneSended,
                        };


                        actionlist.Add(action1);
                        action1 = new actionResonse()
                        {
                            type = "a.go",
                            to = "app/verifyPage",
                        };
                        actionlist.Add(action1);

                        result.actions = actionlist;
                        response.result = result;
                        response.code = 0;
                        break;

                    // زمانی که فرم ثبت کد سابمیت میشه
                    case "app/setCode":

                        responseModel tokenModel = await handleSetCode(model);
                        if (tokenModel.status == 200)
                        {
                            actionlist = new List<actionResonse>();
                            action1 = new actionResonse()
                            {
                                type = "a.login",
                                value = tokenModel.message,
                                text = model.data["phone"]
                            };


                            actionlist.Add(action1);
                            action1 = new actionResonse()
                            {
                                type = "a.restart",
                            };
                            actionlist.Add(action1);
                            result.actions = actionlist;
                        }

                        else
                        {
                            actionlist = new List<actionResonse>();
                            action1 = new actionResonse()
                            {
                                type = "a.message",
                                text = "کد اشتباه است",
                            };
                            actionlist.Add(action1);
                            result.actions = actionlist;
                        }


                        response.result = result;
                        response.code = 0;
                        break;
                }
            }
            else
            {
                List<actionResonse>  actionlist = new List<actionResonse>();
                actionResonse action1 = new actionResonse()
                {
                    type = "a.go",
                    to = "app/login",
                };
                actionlist.Add(action1);
                result.actions = actionlist;
                response.result = result;
            }

            
            return response;
        }

        private async Task<string> handleRegistration(getURLVM model)
        {
            string phone = "";
            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
            if (lstform != null)
            {
                if (lstform.Count() > 0)
                {
                    phone = lstform.First().value;
                }
            }
            responseModel output = new responseModel();
            string outputstring = "";
            Random rnd = new Random();
            int num = rnd.Next(1111, 9999);


            using (Context dbcontext = new Context())
            {


                //Guid Userguid = new Guid("5417296b-b07e-404a-bc71-f04dc8baac2f");

                //user user = dbcontext.users.SingleOrDefault(x => x.userID == Userguid);
                //dbcontext.users.Remove(user);
                //dbcontext.SaveChanges();
                user myuser = dbcontext.users.SingleOrDefault(x => x.phone == phone);
                if (myuser != null)
                {
                    myuser.code = "9999"; // num.ToString(),
                }
                else
                {
                    string status = "0";
                    Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
                    Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;

                    user newuser = new user()
                    {
                        userID = Guid.NewGuid(),
                        phone = phone,
                        name = "",
                        code = "9999", // num.ToString(),
                        userType = "0",
                        verifyStatusID = statusID,
                        workingStatusID = workingID
                    };
                    dbcontext.users.Add(newuser);
                }

                dbcontext.SaveChanges();
            }
            return phone;
        }

        private async Task<responseModel> handleSetCode(getURLVM model)
        {
            string phone = model.data["phone"];
            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
            string code = lstform.First().value;
            string token = "";
            responseModel output = new responseModel();
            using (Context dbcontext = new Context())
            {
                try
                {
                    user myuser = dbcontext.users.SingleOrDefault(x => x.phone == phone && x.code == code);
                    if (myuser != null)
                    {
                        output.message = TokenManager.GenerateToken(phone, myuser.userID.ToString());
                        output.status = 200;

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
            return output;
        }

        [spalshAuthentication]
        private async Task<initDataVM> setTailorForm(getURLVM model, Guid userID)
        {
            initDataVM initdatamodel = new initDataVM();
            Dictionary<string, string> finaldic = new Dictionary<string, string>();
            if (model.initdata != null)
            {
                foreach (var item in model.initdata)
                {
                    finaldic.Add(item.Key, item.Value);
                }
            }
            if (model.data != null)
            {
                foreach (var item in model.data)
                {
                    finaldic.Add(item.Key, item.Value);
                }
            }

            try
            {
                using (Context dbcontext = new Context())
                {
                    Guid orderID = finaldic.ContainsKey("orderID") ? new Guid(finaldic["orderID"]) : Guid.NewGuid();
                    Guid processID = finaldic.ContainsKey("processID") ? new Guid(finaldic["processID"]) : Guid.NewGuid();
                    Guid flowID = finaldic.ContainsKey("flowID") ? new Guid(finaldic["flowID"]) : Guid.NewGuid();
                    //Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");
                    if (!finaldic.ContainsKey("orderID"))
                    {
                        // یک نیو اردر ایجاد میکنیم

                        newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                        //Guid thirdPartyGUID = Guid.NewGuid();
                        //thirdParty thirdParty = new thirdParty()
                        //{
                        //    fullname = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyName").value,
                        //    address = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyAddress").value,
                        //    phone = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyPhone").value,
                        //    ThirdPartyID = thirdPartyGUID,
                        //};
                        //dbcontext.thirdParties.Add(thirdParty);



                        newOrder neworder = new newOrder()
                        {
                            creationDate = DateTime.Now,
                            terminationDate = DateTime.Now,
                            newOrderID = orderID,
                            newOrderStatusID = neworderstatus.newOrderStatusID,
                            orderName = "اردر جدید"

                            //thirdPartyID = thirdPartyGUID,
                        };
                        dbcontext.NewOrders.Add(neworder);
                        //newOrder checkorder = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.orderName == model.name);
                        //if (checkorder == null)
                        //{

                        //}
                        await dbcontext.SaveChangesAsync();
                    }// 



                    newOrder orderSelected = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
                    newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                    orderSelected.newOrderStatusID = stat.newOrderStatusID;

                    if (!finaldic.ContainsKey("processID")) //
                    {
                        process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
                        processID = pr.processID;
                    }


                    if (finaldic.ContainsKey("flowID"))
                    {
                        newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == flowID);
                        selectedflow.isFinished = "1";


                    }
                    else
                    {
                        newOrderFlow newOrderFlow = new newOrderFlow()
                        {
                            creationDate = DateTime.Now,
                            actionDate = DateTime.Now,
                            processID = processID,
                            isFinished = "1",
                            newOrderID = orderID,
                            newOrderFlowID = flowID,
                            ServentID = userID,
                            terminationDate = DateTime.Now,
                        };
                        dbcontext.newOrderFlows.Add(newOrderFlow);
                    }

                    await dbcontext.SaveChangesAsync();
                    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
                    foreach (var item in lstform)
                    {
                        string fieldToGo = "";
                        switch (item.formItemTypeCode)
                        {
                            case ("6"): // انتخابی
                                fieldToGo = "valueBool";

                                break;
                            case ("8"): // موقعیت 
                                fieldToGo = "valueString";
                                break;
                            case ("7"):// آپلود
                                fieldToGo = "valueString";
                                break;
                            case ("1"):// چند گزینه ای
                                fieldToGo = "valueGuid";
                                break;
                            case ("5"): // تاریخ
                                fieldToGo = "valueDateTime";
                                break;
                            case ("4"): // عددی
                                fieldToGo = "valueDuoble";
                                break;
                            case ("3"): // متنی
                                fieldToGo = "valueString";
                                break;
                            case ("2"): //  متنی عکس دار
                                fieldToGo = "valueString";
                                break;
                        }
                        newOrderFields fieldItem = new newOrderFields();
                        fieldItem.formItemID = item.formItemID;
                        fieldItem.name = item.key;
                        fieldItem.newOrderFieldsID = Guid.NewGuid();
                        fieldItem.newOrderFlowID = flowID;
                        fieldItem.usedFeild = fieldToGo;
                        fieldItem.valueInt = 0;
                        fieldItem.valueDuoble = 0;
                        fieldItem.valueDateTime = DateTime.Now;
                        fieldItem.valueBool = false;
                        fieldItem.valueGuid = new Guid();

                        if (fieldToGo == "valueBool")
                            fieldItem.valueBool = Boolean.Parse(item.value);
                        if (fieldToGo == "valueString")
                            fieldItem.valueString = item.value;
                        if (fieldToGo == "valueDateTime")
                            fieldItem.valueDateTime = DateTime.Parse(item.value);
                        if (fieldToGo == "valueGuid")
                            fieldItem.valueGuid = new Guid(item.value);
                        if (fieldToGo == "valueDuoble")
                            fieldItem.valueDuoble = double.Parse(item.value);


                        dbcontext.newOrderFields.Add(fieldItem);

                    }

                    await dbcontext.SaveChangesAsync();


                }
            }
            catch
            {

            }
            return initdatamodel;
        }



        [spalshAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<splash> getSplash()
        {

            object someObject;
            processActionVM responseModel = new processActionVM();

            Request.Properties.TryGetValue("Splash", out someObject);
            try
            {

                splash sp = JsonConvert.DeserializeObject<splash>(someObject.ToString());
                return sp;
            }
            catch (Exception e)
            {
                splash sp = new splash();
                return sp;
            }


        }

        //[BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> updateFormItemPostion([FromBody] form model)
        {
            //methods.ScanTextFromImageWithCoordinates("");
            responseModel mymodel = new responseModel();
            string json;
            string messagestring = "";
            try
            {
                using (Context dbcontext = new Context())
                {
                    form form = await dbcontext.forms.Include(x => x.FormItems).SingleOrDefaultAsync(x => x.formID == model.formID);
                    var testFile = "";


                    testFile = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "PDF\\" + form.pdfBase);

                    // doIMG(testFile,form);
                    Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
                    doc.LoadFromFile(testFile);




                    foreach (var item in form.FormItems)
                    {
                        string xposition = "";
                        string yposition = "0";

                        if (!string.IsNullOrEmpty(item.itemName))
                        {

                            foreach (PdfPageBase page in doc.Pages)
                            {

                                PdfTextFinder finder = new PdfTextFinder(page);
                                PdfTextFindOptions options = new PdfTextFindOptions();
                                options.Parameter = TextFindParameter.IgnoreCase;
                                finder.Options = options;
                                List<PdfTextFragment> fragments = finder.Find(item.itemName); //
                                PointF found1 = new PointF();
                                PointF found2 = new PointF();
                                if (fragments.Count > 0)
                                {
                                    found1 = fragments[0].Positions[0];
                                    item.itemx = found1.X + "," + found1.Y;
                                    item.pageNumber = doc.Pages.IndexOf(page);
                                }
                                if (fragments.Count > 1)
                                {
                                    found2 = fragments[1].Positions[0];
                                    item.itemy = found2.X + "," + found2.Y;
                                    item.pageNumber = doc.Pages.IndexOf(page);

                                    item.itemLenght = (found1.X - found2.X).ToString();
                                    item.itemHeight = (found1.Y - found2.Y).ToString();

                                }


                            }






                        }
                        string json2;


                    }
                    messagestring += "1-";
                    await dbcontext.SaveChangesAsync();
                    // تولید عکس از روی پی دی اف
                    // string pt = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
                    // string path = System.IO.Path.Combine(pt,  "Upload");// HttpRuntime.AppDomainAppPath; // System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
                    string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");// Server.MapPath("~/Upload/");// HostingEnvironment.MapPath("~/Uploads/");// ;
                    string pdfFilePath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "PDF\\" + form.pdf);
                    messagestring += folderPath;
                    messagestring += "-"+ folderPath;
                    PdfDocument pdf = new PdfDocument();
                    pdf.LoadFromFile(pdfFilePath);
                    List<Image> images = new List<Image>();
                    string finalImag = "";
                    string finalwidth = "";
                    string finalhieght = "";
                    string zaribWidth = "";
                    string zaribHeight = "";
                    foreach (PdfPageBase page in pdf.Pages)
                    {
                        string filename = form.pdf.Replace(".pdf", "") + pdf.Pages.IndexOf(page) + ".png";
                        //finalImag += filename + ",";
                        string imagename = System.IO.Path.Combine(folderPath, filename);
                        messagestring += imagename;
                        foreach (Image image in page.ExtractImages())
                        {
                            image.Save(imagename, System.Drawing.Imaging.ImageFormat.Png);
                            finalwidth += image.Width + ",";
                            finalhieght += image.Height + ",";
                            finalImag += System.Configuration.ConfigurationManager.AppSettings["domain"] + "/Uploads/" + filename + ",";
                            zaribWidth += (image.Width / page.ActualSize.Width).ToString() + ",";
                            zaribHeight += (image.Height / page.ActualSize.Height).ToString() + ",";
                        }
                    }


                    form.imageWidth = finalwidth.Trim(',');
                    form.imageHeight = finalhieght.Trim(',');
                    form.image = finalImag.Trim(',');
                    form.zaribWidth = zaribWidth;
                    form.zaribHeight = zaribHeight;


                    await dbcontext.SaveChangesAsync();
                    // پایان

                    mymodel.status = 200;
                    await dbcontext.SaveChangesAsync();
                    string result = JsonConvert.SerializeObject(mymodel);
                    JObject jObject = JObject.Parse(result);
                    return jObject;
                }
            }
            catch (Exception e)
            {
                mymodel.status = 400;
                mymodel.message = messagestring;
                string result = JsonConvert.SerializeObject(mymodel);
                JObject jObject = JObject.Parse(result);
                return jObject;

            }

            //deviceID = "6";
            //using (var client = new WebClient())
            //{
            //    json = client.DownloadString("http://supectco.com/webs/GDP/Admin/getListOfFeatures.php?CatID=" + deviceID);
            //}

            //FeatureModel log = JsonConvert.DeserializeObject<FeatureModel>(json);


        }

        //[BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<pageSectionVM> getURL([FromBody] getURLVM model)
        {




            pageSectionVM response = new pageSectionVM();
            try
            {
                model.slug = model.slug == null ? "" : model.slug;
                using (Context dbcontext = new Context())
                {
                    language lng = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.lang);
                    //Include(x => x.Contents.Select(l => l.HTML)).Include(x => x.Contents.Select(y => y.Datas)).Include(x => x.Contents.Select(y => y.childContent)).Include(x => x.Contents.Select(y => y.childContent.Select(z => z.Datas)))

                    var responseList = await dbcontext.sections.Include(x => x.SectionLayout).Include(x => x.Metas).Where(x => x.url == model.slug && x.languageID == lng.languageID).Select(x => new pageSectionVM { sectionID = x.sectionID, Metas = x.Metas.Select(p => new MetaVM { Name = p.name, Content = p.content }).ToList(), date = x.date, title = x.title, image = x.image, url = x.url, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
                    response = responseList.First();
                    var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == response.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.name, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.typeName, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { layoutDataID = m.layoutDataID, parentID = m.parentID == null ? null : m.parentID, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).OrderBy(m => m.priority).ToList() }).ToList() }).ToListAsync();
                    response.layoutModel = list.First();

                    Dictionary<string, string> hitems = new Dictionary<string, string>();
                    hitems.Add("childMetaString", "");
                    getChildContentVM myresult = await getChildContent(response.sectionID, null, null, hitems);
                    response.Contents = myresult.list;
                    //foreach (var item in response.Contents)
                    //{
                    //    if (item.typeID != new Guid("00000000-0000-0000-0000-000000000000") && item.typeID != null)
                    //    {
                    //        item.childList = await dbcontext.sections.Include(x => x.Category).Where(x => x.sectionTypeID == item.typeID).Select(x => new sectionVM { buttonText = x.buttonText, categoryName = x.Category.title, title = x.title, description = x.description, metaTitle = x.metatitle, image = x.image, writer = x.writer, date = x.date, url = x.url }).ToListAsync();
                    //    }
                    //}
                }
            }
            catch (Exception e)
            {
                throw;
            }



            return response;
        }
        //private async task<appmainVM> appmain()
        //{

        //}


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<getsectionLayoutVM> getPageLayout([FromBody] sectionLayoutVM model)
        {
            getsectionLayoutVM response = new getsectionLayoutVM();
            using (Context dbcontext = new Context())
            {

                var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == model.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.title, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.title, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).ToList() }).ToList() }).ToListAsync();

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
                output.sectionList = await dbcontext.sections.Where(x => x.sectionTypeID == model.typeID).Select(x => new sectionVM { categoryID = x.categoryID, buttonText = x.buttonText, languateID = x.languageID, sectionLayoutID = x.sectionLayoutID, image = x.image, metaTitle = x.metatitle, title = x.title, url = x.url, sectinoID = x.sectionID, writer = x.writer }).ToListAsync();
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
                    if (model.sectinoID != new Guid("00000000-0000-0000-0000-000000000000") && model.sectinoID != null)
                    {
                        section exist = await dbcontext.sections.SingleOrDefaultAsync(x => x.sectionID == model.sectinoID);
                        string lastmessag = exist.image;
                        exist.title = model.title;
                        exist.metatitle = model.metaTitle;
                        exist.buttonText = model.buttonText;
                        exist.url = model.url;
                        if (!string.IsNullOrEmpty(model.image))
                        {
                            exist.image = model.image;
                        }

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
                                buttonText = model.buttonText,

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
                try
                {
                    content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentParent);
                    output.allContents = await dbcontext.contents.Include(x => x.HTML).Select(x => new contentVM { title = x.title, contentID = x.contentID }).ToListAsync();
                    Guid parentHTML = new Guid();
                    if (content != null)
                    {
                        parentHTML = content.HTML.htmlID;
                        model.sectinoID = content.sectionID;
                        output.parentSelected = new contentVM
                        {
                            title = content.title,
                            contentID = content.contentID
                        };
                    }
                    section section = await dbcontext.sections.Include(x => x.SectionLayout).FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);

                    var querycontent = dbcontext.contents.Include(x => x.HTML).Include(x => x.sectionType).Include(x => x.HTML).AsQueryable();
                    if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        querycontent = querycontent.Where(x => x.parentID == model.contentParent);
                    }
                    else
                    {
                        querycontent = querycontent.Where(x => x.sectionID == model.sectinoID && x.parentID == null);
                    }
                    output.contentList = await querycontent.Select(x => new contentVM { stackWeight = x.stackWeight, cycleFields = x.cycleFields, htmlFeilds = x.HTML.dataField, formID = x.formID, htmlFormLink = x.HTML.formLink, description = x.description, multilayer = x.HTML.multilayer, priority = x.priority, title = x.title, image = x.HTML.image, contentID = x.contentID, htmlName = x.title, typeName = x.sectionType != null ? x.sectionType.title : "" }).OrderBy(x => x.priority).ToListAsync();

                    var htmlquery = dbcontext.htmls.Where(x => x.layout == section.SectionLayout.layoutID).AsQueryable();
                    if (parentHTML != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        htmlquery = htmlquery.Where(x => x.parentID == parentHTML || x.ispublic == "1");
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
                    output.formList = await dbcontext.forms.Select(x => new formVM { formID = x.formID, title = x.title }).ToListAsync();
                }
                catch (Exception e)
                {


                }

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
                    if (model.contentID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        content cnt = await dbcontext.contents.SingleOrDefaultAsync(x => x.contentID == model.contentID);
                        if (model.contentID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            if (!string.IsNullOrEmpty(model.stackWeight))
                            {
                                cnt.stackWeight = model.stackWeight;

                            }
                            else if (model.formID != new Guid("00000000-0000-0000-0000-000000000000"))
                            {
                                cnt.formID = model.formID;
                            }
                            else if (!string.IsNullOrEmpty(model.title))
                            {
                                cnt.title = model.title;
                            }
                            else
                            {
                                cnt.priority = model.priority;
                                if (model.chosenForCycle != null)
                                {
                                    if (model.chosenForCycle.Count() > 0)
                                    {
                                        cnt.cycleFields = string.Join(",", model.chosenForCycle);
                                    }
                                }

                            }

                        }

                    }
                    else
                    {

                        if (model.mirrorID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            copyWholeContent(model.sectionID, model.priority, model.title, model.mirrorID, model.contentParent, dbcontext);
                            dbcontext.SaveChanges();
                            response.status = 200;
                            response.message = "";
                            string rs = JsonConvert.SerializeObject(response);

                            JObject ob = JObject.Parse(rs);
                            return ob;
                        }

                        html selectedHtml = await dbcontext.htmls.SingleOrDefaultAsync(x => x.htmlID == model.htmlID);
                        Guid contentID = Guid.NewGuid();
                        content newlItem = new content()
                        {
                            contentID = contentID,
                            htmlID = model.htmlID,
                            priority = model.priority,
                            description = model.description,
                            title = model.title,
                            sectionID = model.sectionID,
                            stackWeight = model.stackWeight,
                            
                        };

                       
                        
                        if (model.typeID != new Guid("00000000-0000-0000-0000-000000000000"))
                            newlItem.sectionTypeID = model.typeID;
                        if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
                            newlItem.parentID = model.contentParent;
                        if (model.formID != new Guid("00000000-0000-0000-0000-000000000000"))
                            newlItem.formID = model.formID;
                        dbcontext.contents.Add(newlItem);

                        string fielditem = selectedHtml.dataField;
                        if (!string.IsNullOrEmpty(fielditem))
                        {
                            List<string> itemlist = fielditem.Trim(',').Split(',').ToList();
                            foreach (var item in itemlist)
                            {
                                int index = itemlist.IndexOf(item) + 1;
                                data newData = new data()
                                {
                                    dataID = Guid.NewGuid(),
                                    title = item,
                                    title2 = "",
                                    description = "",
                                    description2 = "",
                                    mediaURL = "",
                                    viedoIframe = "",
                                    contentID = contentID,
                                    writer = "admin",
                                    Date = DateTime.Now,
                                    url = "",
                                    priority = index
                                };
                                dbcontext.datas.Add(newData);
                            }
                        }


                    }
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


        private void copyWholeContent(Guid? sectionID, int priority, string title, Guid mirrorID, Guid? parentID, Context dbcontext)
        {
            responseModel response = new responseModel();
            try
            {

                parentID = parentID != new Guid("00000000-0000-0000-0000-000000000000") ? parentID : null;

                content mirror = dbcontext.contents.Include(x => x.Datas).Include(x => x.Poses).Include(x => x.childContent).SingleOrDefault(x => x.contentID == mirrorID);
                Guid contentID = Guid.NewGuid();
                content newContent = new content
                {
                    contentID = contentID,
                    htmlID = mirror.htmlID,
                    priority = priority,
                    description = mirror.description,
                    title = mirror.title + "_" + title,
                    sectionID = sectionID,
                    stackWeight = mirror.stackWeight,


                };

                if (mirror.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
                    newContent.sectionTypeID = mirror.sectionTypeID;
                if (mirror.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
                    newContent.parentID = parentID;
                if (mirror.formID != new Guid("00000000-0000-0000-0000-000000000000"))
                    newContent.formID = mirror.formID;
                dbcontext.contents.Add(newContent);
                dbcontext.SaveChanges();

                if (mirror.Datas != null)
                {
                    foreach (var dataM in mirror.Datas)
                    {
                        data data = new data
                        {
                            dataID = Guid.NewGuid(),
                            title = dataM.title,
                            title2 = dataM.title2,
                            description = dataM.description,
                            description2 = dataM.description2,
                            mediaURL = dataM.mediaURL,
                            viedoIframe = dataM.viedoIframe,
                            contentID = contentID,
                            writer = "admin",
                            Date = DateTime.Now,
                            url = dataM.url,
                            priority = dataM.priority
                        };
                        dbcontext.datas.Add(data);
                    }

                }

                if (mirror.Poses != null)
                {
                    foreach (var item in mirror.Poses)
                    {
                        pose newpose = new pose()
                        {
                            poseID = Guid.NewGuid(),
                            title = item.title,
                            title2 = item.title2,
                            contentID = contentID,
                        };
                        dbcontext.poses.Add(newpose);
                    }
                }
                dbcontext.SaveChanges();

                if (mirror.childContent != null)
                {
                    foreach (var chitem in mirror.childContent)
                    {
                        copyWholeContent(chitem.sectionID, chitem.priority, title, chitem.contentID, contentID, dbcontext);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }



        }

        private async Task<responseModel> setNewData(data model, string title)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    data newlItem = new data()
                    {



                    };


                    dbcontext.datas.Add(newlItem);
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
            return response;
        }


        private void removeItem(setContentVM model, Context dbcontext)
        {
            try
            {
                content selectedContent = dbcontext.contents.Include(x => x.Datas).SingleOrDefault(x => x.contentID == model.contentID);
                if (selectedContent != null)
                {
                    selectedContent.Datas.ToList().ForEach(p => dbcontext.datas.Remove(p));
                    selectedContent.Poses.ToList().ForEach(p => dbcontext.poses.Remove(p));
                    dbcontext.SaveChanges();
                    if (selectedContent.childContent != null)
                    {
                        List<Guid> GUidlist = selectedContent.childContent.Select(x => x.contentID).ToList();
                        foreach (var child in GUidlist)
                        {
                            setContentVM viewmodel = new setContentVM()
                            {
                                contentID = child,
                            };
                            removeItem(viewmodel, dbcontext);
                        }

                    }
                }

                dbcontext.Entry(selectedContent).State = EntityState.Deleted;
                dbcontext.SaveChanges();

            }
            catch (Exception e)
            {

                throw;
            }

        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeContent([FromBody] setContentVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                removeItem(model, dbcontext);
                await dbcontext.SaveChangesAsync();
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
                output.metaList = await dbcontext.metas.Where(x => x.sectionID == model.sectinoID).Select(x => new MetaVM { Name = x.name, Content = x.content, metaID = x.metaID, sectionID = x.sectionID }).ToListAsync();
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
                        name = model.Name,
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
                content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentID);

                string fields = "";
                if (string.IsNullOrEmpty(model.fields))
                {
                    fields = content.HTML.dataField.ToString();
                }


                output.dataList = await dbcontext.datas.Where(x => x.contentID == model.contentID).OrderBy(x => x.priority).Select(x => new dataVM { date = x.Date, writer = x.writer, priority = x.priority, URL = x.url, dataID = x.dataID, title = x.title, title2 = x.title2, description = x.description, description2 = x.description2, mediaURL = x.mediaURL, viedoIframe = x.viedoIframe }).ToListAsync();
                bool refreshList = false;
                if (!string.IsNullOrEmpty(fields))
                {
                    List<string> newItems = fields.Trim(',').Split(',').ToList();
                    if (output.dataList.Count() != newItems.Count())
                    {
                        foreach (var item in newItems.ToList())
                        {
                            if (!output.dataList.Any(l => item.ToString().Contains(l.title)))
                            {
                                data newlItem = new data()
                                {
                                    dataID = Guid.NewGuid(),
                                    title = item,
                                    title2 = "",

                                    contentID = model.contentID,
                                    writer = "admin",
                                    Date = DateTime.Now,
                                    priority = model.priority


                                };
                                dbcontext.datas.Add(newlItem);
                                refreshList = true;
                            }

                        }
                    }
                }
                if (refreshList)
                {
                    await dbcontext.SaveChangesAsync();
                    output.dataList = await dbcontext.datas.Where(x => x.contentID == model.contentID).OrderBy(x => x.priority).Select(x => new dataVM { date = x.Date, writer = x.writer, priority = x.priority, URL = x.url, dataID = x.dataID, title = x.title, title2 = x.title2, description = x.description, description2 = x.description2, mediaURL = x.mediaURL, viedoIframe = x.viedoIframe }).ToListAsync();
                }


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

            string valueSended = "";
            if (model.title == "marginsrt")
            {
                marginVM marginModel = new marginVM();
                marginModel.lead = model.title2.Count() > 0 ? Int32.Parse(model.title2[0]) : 0;
                marginModel.trail = model.title2.Count() > 1 ? Int32.Parse(model.title2[1]) : 0;
                marginModel.top = model.title2.Count() > 2 ? Int32.Parse(model.title2[2]) : 0;
                marginModel.bottom = model.title2.Count() > 3 ? Int32.Parse(model.title2[3]) : 0;
                valueSended = JsonConvert.SerializeObject(marginModel);
            }
            else
            {
                valueSended = model.title2.Count() > 0 ? model.title2[0] : "";
            }
            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.dataID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        data selectedData = await dbcontext.datas.SingleOrDefaultAsync(x => x.dataID == model.dataID);

                        string lastimage = "";
                        selectedData.title2 = valueSended;
                        selectedData.description = model.description;
                        selectedData.Date = DateTime.Now;
                        selectedData.writer = "admin";
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
                            title2 = valueSended,
                            description = model.description,
                            description2 = model.description2,
                            mediaURL = model.mediaURL,
                            viedoIframe = model.viedoIframe,
                            contentID = model.contentID,
                            writer = "admin",
                            Date = DateTime.Now,
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


        // pose
        [System.Web.Http.HttpPost]
        public async Task<poseListVM> getPose([FromBody] contentVM model)
        {
            poseListVM output = new poseListVM();

            using (Context dbcontext = new Context())
            {
                content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentID);
                string fields = content.HTML.poseField.ToString();

                output.poseList = await dbcontext.poses.Where(x => x.contentID == model.contentID).Select(x => new poseVM { contentID = x.contentID, title = x.title, title2 = x.title2, poseID = x.poseID }).ToListAsync();
                bool refreshList = false;
                if (!string.IsNullOrEmpty(fields))
                {
                    List<string> newItems = fields.Trim(',').Split(',').ToList();
                    if (output.poseList.Count() != newItems.Count())
                    {
                        foreach (var item in newItems.ToList())
                        {
                            if (!output.poseList.Any(l => item.ToString().Contains(l.title)))
                            {
                                pose newlItem = new pose()
                                {
                                    poseID = Guid.NewGuid(),
                                    title = item,
                                    title2 = "",
                                    contentID = model.contentID,
                                };
                                dbcontext.poses.Add(newlItem);
                                refreshList = true;
                            }

                        }
                    }
                }
                if (refreshList)
                {
                    await dbcontext.SaveChangesAsync();
                    output.poseList = await dbcontext.poses.Where(x => x.contentID == model.contentID).Select(x => new poseVM { poseID = x.poseID, title = x.title, title2 = x.title2, }).ToListAsync();
                }


                output.selectedContent = new contentVM()
                {
                    contentID = content.contentID,
                    title = content.title,
                    image = content.title,
                    fields = content.HTML.dataField
                };

                output.allElements = await dbcontext.contents.Where(x => x.sectionID == content.sectionID).Select(x => new contentVM { contentID = x.contentID, title = x.title }).ToListAsync();
            }

            return output;

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setPose([FromBody] setPoseVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    if (model.poseID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        pose selectedData = await dbcontext.poses.SingleOrDefaultAsync(x => x.poseID == model.poseID);

                        if (model.isCheckbox == "1")
                        {
                            if (model.title2 == "on")
                            {
                                selectedData.title2 = "true";

                            }
                            else
                            {
                                selectedData.title2 = "false";

                            }
                        }
                        else
                        {
                            string toitem = string.IsNullOrEmpty(model.to) ? "" : model.to;
                            poseViewVM posemodel = new poseViewVM()
                            {
                                constant = model.constant,
                                to = toitem
                            };
                            selectedData.title2 = JsonConvert.SerializeObject(posemodel);
                        }
                        response.status = 200;
                        await dbcontext.SaveChangesAsync();
                    }
                    else
                    {
                        data newlItem = new data()
                        {
                            dataID = Guid.NewGuid(),
                            contentID = model.contentID,
                            title = model.title,

                        };

                        if (model.isCheckbox == "1")
                        {
                            newlItem.title2 = "true";
                        }
                        else
                        {
                            poseViewVM posemodel = new poseViewVM()
                            {
                                constant = model.constant,
                                to = model.to
                            };
                            newlItem.title2 = JsonConvert.SerializeObject(posemodel);
                        }

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
        public async Task<JObject> removePose([FromBody] setPoseVM model)
        {
            responseModel response = new responseModel();

            using (Context dbcontext = new Context())
            {
                try
                {
                    pose selectedData = await dbcontext.poses.SingleOrDefaultAsync(x => x.poseID == model.poseID);
                    if (selectedData != null)
                    {
                        dbcontext.poses.Remove(selectedData);
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
                output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title }).ToListAsync();
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
                    if (lp == null)
                    {
                        layoutPart newlItem = new layoutPart()
                        {
                            layoutPartID = Guid.NewGuid(),
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
                output.datalist = await dbcontext.layoutDatas.Where(x => x.layoutPartID == model.layoutPartID).Include(x => x.sectionType).Include(x => x.parentData).Select(x => new layoutpartDataVM { dataType = x.dataType, priority = x.priority, urlTitle = x.urlTitle, parentID = x.parentData.parentID, sectionTypeID = x.sectionType.sectionTypeID, parentName = x.parentData != null ? x.parentData.title : "", image = x.image, title = x.title, url = x.url, typeTitle = x.sectionType.title, typeCount = x.typeCount, layoutDataID = x.layoutDataID }).OrderBy(x => x.dataType).OrderByDescending(x => x.priority).ToListAsync();
                output.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
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

                    if (model.layoutDataID == new Guid("00000000-0000-0000-0000-000000000000") || model.layoutDataID == null)
                    {
                        layoutData layoutdata = await dbcontext.layoutDatas.SingleOrDefaultAsync(x => x.title == model.title && x.layoutPartID == model.layoutPartID);
                        if (layoutdata == null)
                        {
                            layoutData newlItem = new layoutData()
                            {
                                layoutDataID = Guid.NewGuid(),
                                title = model.title,

                                priority = model.priority,
                                dataType = model.dataType,
                                url = model.url,
                                typeCount = model.typeCount,
                                layoutPartID = model.layoutPartID,
                                urlTitle = model.urlTitle,

                            };
                            if (!string.IsNullOrEmpty(model.image))
                            {
                                newlItem.image = model.image;
                            }
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
                        layoutdata.dataType = model.dataType;
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
                    layoutData selectedlayoutPart = await dbcontext.layoutDatas.Include(x => x.childs).SingleOrDefaultAsync(x => x.layoutDataID == model.layoutDataID);
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
                output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title, }).ToListAsync();
                output.layoutObjectLists = await dbcontext.sectionLayouts.Include(x => x.Language).Include(x => x.Layout).Include(x => x.LayoutParts).Select(x => new layoutObjectVM { partID = x.LayoutParts.Select(m => m.layoutPartID).ToList(), partnames = x.LayoutParts.Select(d => d.title).ToList(), menuTitle = x.menuTitle, languageName = x.Language.title, description = x.Layout.description, partName = x.Layout.partName, image = x.Layout.image, name = x.Layout.name, title = x.Layout.title, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
                output.layoutLists = await dbcontext.layouts.Select(x => new layoutVM { partName = x.partName, description = x.description, image = x.image, layoutID = x.layoutID, name = x.name, title = x.title }).ToListAsync();
                output.allPart = await dbcontext.layoutParts.Select(x => new layoutpartVM { title = x.title, typeName = x.typeName, languageID = x.languageID, layoutPartID = x.layoutPartID }).ToListAsync();
                foreach (var item in output.layoutLists)
                {
                    //List<layoutPart> lst = dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).ToList();
                    item.partlist = await dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).Select(x => new layoutpartVM { languageID = x.languageID, title = x.title, typeName = x.typeName, layoutPartID = x.layoutPartID }).ToListAsync();
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
                    if (model.sectionLayoutID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        sectionLayout selectedLS = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).SingleOrDefaultAsync(x => x.sectionLayoutID == model.sectionLayoutID);
                        List<layoutPart> lastids = selectedLS.LayoutParts.ToList();
                        foreach (var item in lastids)
                        {
                            selectedLS.LayoutParts.Remove(item);
                        }
                        await dbcontext.SaveChangesAsync();

                        foreach (var item in model.layoutPartID)
                        {
                            Guid idguid = new Guid(item);
                            layoutPart part = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == idguid);
                            if (part != null)
                            {
                                selectedLS.LayoutParts.Add(part);
                            }
                        }

                        await dbcontext.SaveChangesAsync();

                    }
                    else
                    {
                        sectionLayout layoutdata = await dbcontext.sectionLayouts.SingleOrDefaultAsync(x => x.languageID == model.languageID && x.layoutID == model.layoutID && x.menuTitle == model.menuTitle);
                        if (layoutdata == null)
                        {
                            layout selectlayout = await dbcontext.layouts.SingleOrDefaultAsync(x => x.layoutID == model.layoutID);
                            Guid sectionlayoutID = Guid.NewGuid();
                            sectionLayout newlItem = new sectionLayout()
                            {
                                sectionLayoutID = sectionlayoutID,
                                languageID = model.languageID,
                                layoutID = model.layoutID,
                                menuTitle = model.menuTitle,


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




        /////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        // portal start




        public static DbGeography ConvertLatLonToDbGeography(double longitude, double latitude)
        {
            var point = string.Format("POINT({1} {0})", latitude, longitude);
            return DbGeography.FromText(point);
        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> changeUserLocation([FromBody] getCityNameVM model)
        {
            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);

            Guid userID = new Guid(someObject.ToString());
            using (Context dbcontext = new Context())
            {
                user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
                user.lat = model.lat.ToString();
                user.lon = model.lon.ToString();
                //user.userType = "1";
                DbGeography point = ConvertLatLonToDbGeography(model.lon, model.lat);
                user.point = point;
                await dbcontext.SaveChangesAsync();
            }

            responseModel mymodel = new responseModel();
            mymodel.status = 200;
            mymodel.message = "ok";

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        } // در داخل راننده من استفاده نشده

        //[System.Web.Http.HttpPost]
        //public async Task<JObject> sendNotif([FromBody] sendOrderNotif model)
        //{
        //    using (Context dbcontext = new Context())
        //    {
        //        order order = dbcontext.orders.ToList().Last();
        //        string orderID = order.orderID.ToString();
        //        DbGeography point = ConvertLatLonToDbGeography(model.lat, model.lon);


        //        List<user> useddrs = (from u in dbcontext.users
        //                              where u.userType == "1" && u.point.Distance(point) < 2000000
        //                              select u).ToList();
        //        string src = HostingEnvironment.ApplicationPhysicalPath + "\\File\\key.json";
        //        FirebaseApp.Create(new AppOptions()
        //        {
        //            Credential = GoogleCredential.FromFile(src),
        //        });

        //        foreach (var item in useddrs)
        //        {


        //            notifVM fm = new notifVM();
        //            bigStyle big_style = new bigStyle();
        //            big_style.type = "";
        //            titleModel title = new titleModel();
        //            title.text = "سفارش جدید در اطراف شما ثبت شد";
        //            clickAction click_action = new clickAction();
        //            click_action.title = "";
        //            click_action.type = "openapp";
        //            click_action.data = "/home/viewDetail?q=" + orderID;
        //            fm.big_style = big_style;
        //            fm.title = title;
        //            fm.click_action = click_action;

        //            string mdljson = JsonConvert.SerializeObject(fm);
        //            Dictionary<string, string> dat = new Dictionary<string, string>();
        //            dat.Add("mydata", mdljson);
        //            var message = new Message()
        //            {

        //                Data = dat,
        //                Notification = new Notification
        //                {
        //                    Title = "بار جدید اومد مردک",
        //                    Body = "",


        //                },
        //                Token = item.firebaseToken
        //            };
        //            var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        //        }


        //    }
        //    responseModel mymodel = new responseModel();
        //    mymodel.status = 200;
        //    mymodel.message = "ok";

        //    string result = JsonConvert.SerializeObject(mymodel);
        //    JObject jObject = JObject.Parse(result);
        //    return jObject;

        //}

        [System.Web.Http.HttpPost]
        public async Task<sendCityVM> getCity([FromBody] getCityVM model)
        {
            sendCityVM output = new sendCityVM();

            using (Context dbcontext = new Context())
            {

                if (model == null)
                {

                    List<newcity> cities = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
                    output.lst = cities;
                    output.status = 200;

                }
                else
                {
                    if (model.search == null && model.ID == null)
                    {
                        List<newcity> cities = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
                        output.lst = cities;
                        output.status = 200;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(model.search))
                        {

                            List<city> cities = dbcontext.cities.ToList();
                            List<newcity> afterSearch = await (from u in dbcontext.cities
                                                               join p in dbcontext.cities on u.parentID equals p.userID
                                                               where u.userID != u.parentID && (p.title.Contains(model.search) || u.title.Contains(model.search))
                                                               select new newcity { title = u.title + " ( " + p.title + " ) ", userID = u.userID, parentID = u.parentID }).ToListAsync();


                            output.lst = afterSearch;
                            output.status = 200;

                        }
                        else
                        {
                            Guid myguid = new Guid(model.ID);
                            List<newcity> afterSearch = await (from u in dbcontext.cities
                                                               join p in dbcontext.cities on u.parentID equals p.userID
                                                               where u.parentID == myguid && u.userID != u.parentID
                                                               select new newcity { title = u.title + " ( " + p.title + " ) ", userID = u.userID, parentID = u.parentID }).ToListAsync();
                            output.lst = afterSearch;
                            output.status = 200;


                        }
                    }




                }

            }


            return output;
        }





        [System.Web.Http.HttpPost]
        public JObject register([FromBody] doSignIn model)
        {

            responseModel output = new responseModel();
            string outputstring = "";
            Random rnd = new Random();
            int num = rnd.Next(1111, 9999);


            using (Context dbcontext = new Context())
            {


                //Guid Userguid = new Guid("5417296b-b07e-404a-bc71-f04dc8baac2f");

                //user user = dbcontext.users.SingleOrDefault(x => x.userID == Userguid);
                //dbcontext.users.Remove(user);
                //dbcontext.SaveChanges();
                user myuser = dbcontext.users.SingleOrDefault(x => x.phone == model.phone && x.userType == model.userType);
                if (myuser != null)
                {
                    myuser.code = "9999"; // num.ToString(),
                }
                else
                {
                    string status = model.userType == "1" ? "1" : "0";
                    Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
                    Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;

                    user newuser = new user()
                    {
                        userID = Guid.NewGuid(),
                        phone = model.phone,
                        name = "",
                        code = "9999", // num.ToString(),
                        userType = model.userType,
                        verifyStatusID = statusID,
                        workingStatusID = workingID
                    };
                    dbcontext.users.Add(newuser);
                }

                dbcontext.SaveChanges();
            }

            output.status = 200;
            outputstring = JsonConvert.SerializeObject(output);
            JObject jObject = JObject.Parse(outputstring); return jObject;


        }



        [System.Web.Http.HttpPost]
        public async Task<JObject> UploadFiles()
        {
            try
            {
                responseModel mymodel = new responseModel();
                //Create the Directory.
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Fetch the File.
                HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];


                string fileName = "";
                string name = methods.RandomString(5);
                //Fetch the File Name.
                fileName = name + Path.GetExtension(postedFile.FileName);
                //Save the File.
                postedFile.SaveAs(path + fileName);
                mymodel.status = 200;
                mymodel.message = fileName;
                //Send OK Response to Client.
                string result = JsonConvert.SerializeObject(mymodel);
                JObject jObject = JObject.Parse(result);
                return jObject;
            }



            catch (Exception baseException)
            {

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(baseException.Message),
                    ReasonPhrase = "Critical Exception"
                });
            }

        }

        //[HttpPost]
        //public async Task<JObject> UploadFilesAsync([Microsoft.AspNetCore.Mvc.FromForm] UploadModel model)

        //{
        //    long size = model.Files.Sum(f => f.Length);
        //    string fileName = "";
        //    foreach (var formFile in model.Files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var uploads = System.Web.HttpContext.Current.Server.MapPath("/uploads") ; 
        //            var filePath = Path.GetTempFileName();
        //            fileName = Path.GetFileName(formFile.FileName);
        //            using (var stream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }

        //    }
        //    responseModel mymodel = new responseModel();
        //    mymodel.status = 200;
        //    mymodel.message = fileName;
        //    string result = JsonConvert.SerializeObject(mymodel);
        //    JObject jObject = JObject.Parse(result);
        //    return jObject;

        //}

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<panelSetOrder> setOrderAction()
        {
            sendCityVM citylist = new sendCityVM();
            sendLoadTypeVM loadList = new sendLoadTypeVM();
            sendTypeVM typeList = new sendTypeVM();
            using (Context dbcontext = new Context())
            {
                citylist.lst = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
                panelSetOrder fmodel = new panelSetOrder()
                {
                    cityList = citylist,
                    loadList = loadList,
                    typeList = typeList.lst

                };

                return fmodel;
            }

        }































        //[BasicAuthentication]
        //[System.Web.Http.HttpPost]
        //public async Task<getDashbaord> getDashboard()
        //{

        //    getDashbaord obj = new getDashbaord();
        //    object someObject;
        //    Request.Properties.TryGetValue("UserToken", out someObject);

        //    Guid userID = new Guid(someObject.ToString());
        //    using (Context dbcontext = new Context())
        //    {
        //        user user = dbcontext.users.SingleOrDefault(x => x.userID == userID);
        //        if (!string.IsNullOrEmpty(user.typeID))
        //        {
        //            Guid carguid = new Guid(user.typeID);

        //            obj.status = 200;
        //        }
        //        List<city> citylist = dbcontext.cities.ToList();
        //        List<newcity> citySelected = (from u in dbcontext.cities
        //                                      where u.userID != u.parentID
        //                                      let distance = u.citypoint.Distance(user.point)
        //                                      orderby distance ascending
        //                                      select new newcity { title = u.title, parentID = u.parentID, userID = u.userID, lat = u.lat, lon = u.lon }).ToList();
        //        obj.origin = citySelected.First();
        //        obj.status = 200;


        //    }
        //    return obj;
        //}




















        // process
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<processActionVM> getProcess()
        {
            object someObject;
            processActionVM responseModel = new processActionVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    var query = from process in dbcontext.processes
                                where process.userID == userID
                                select new processVM
                                {
                                    processID = process.processID,
                                    title = process.title
                                };
                    responseModel.processList = await query.ToListAsync();
                    //responseModel.formulaList = await dbcontext.formulas.Where(x => x.name != "").ToListAsync();
                }
            }
            catch (Exception e)
            {

                throw;
            }


            return responseModel;
        }

        //processFormula
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<processFormulaActionVM> getProcessFormula([FromBody] process model)
        {
            object someObject;
            processFormulaActionVM responseModel = new processFormulaActionVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());

            using (Context dbcontext = new Context())
            {

                var query = from process in dbcontext.processes select process;
                responseModel.processFormulaList = await dbcontext.processFormulas.Include(x => x.Process).Include(x => x.Coding).Include(x => x.Formula).Where(x => x.proccessID == model.processID).Select(x => new processFormulaVM { codingType = x.transactionType, codingName = x.Coding.title, formulaName = x.Formula.name, processFormulaID = x.processFormulaID, }).ToListAsync();

                responseModel.FormulaList = await dbcontext.formulas.Where(x => x.name != "" && x.name != null).Select(x => new formulaVM { formulaID = x.formulaID, name = x.name }).ToListAsync();
                responseModel.codingList = await dbcontext.codings.Where(x => x.userID == userID).OrderBy(x => x.codeHesab).Select(x => new codingVM { codingID = x.codingID, title = x.title + "(" + x.codeHesab + ")" }).ToListAsync();

            }

            return responseModel;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setProcessFormula([FromBody] processFormula model)
        {
            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());

            using (Context dbcontext = new Context())
            {
                responseModel mymodel = new responseModel();
                processFormula pf = await dbcontext.processFormulas.SingleOrDefaultAsync(x => x.FormulaID == model.FormulaID && x.proccessID == model.proccessID);

                if (pf == null)
                {
                    dbcontext.processFormulas.Add(new processFormula { codingID = model.codingID, FormulaID = model.FormulaID, proccessID = model.proccessID, transactionType = model.transactionType, processFormulaID = Guid.NewGuid() });
                    await dbcontext.SaveChangesAsync();
                    mymodel.status = 200;
                    mymodel.message = "ok";
                }
                else
                {
                    mymodel.status = 400;
                    mymodel.message = "آیتم مورد نظر وجود دارد";
                }

                string result = JsonConvert.SerializeObject(mymodel);
                JObject jObject = JObject.Parse(result);
                return jObject;
            }
        }



        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setProcess([FromBody] process model)
        {
            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    responseModel mymodel = new responseModel();
                    var process = await dbcontext.processes.FirstOrDefaultAsync(i => i.title == model.title);
                    if (process == null)
                    {
                        dbcontext.processes.Add(new process() { userID = userID, processID = Guid.NewGuid(), title = model.title });
                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }

                    string result = JsonConvert.SerializeObject(mymodel);
                    JObject jObject = JObject.Parse(result);
                    return jObject;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        //processForm
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<processFormActionVM> getProcessForm([FromBody] process model)
        {
            object someObject;
            processFormActionVM responseModel = new processFormActionVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    var query = from process in dbcontext.processes select process;
                    process q = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
                    responseModel.processFormList = q.formList.Select(x => new processFormVM { processFormID = x.formID, title = x.title }).ToList();
                    responseModel.allForm = await dbcontext.forms.Select(x => new processFormVM { processFormID = x.formID, title = x.title }).ToListAsync();

                }
            }
            catch (Exception e)
            {

                throw;
            }


            return responseModel;
        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setNewFormProcess([FromBody] setNewFormProcessVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());

                using (Context dbcontext = new Context())
                {
                    process pr = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
                    form frm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);
                    if (!pr.formList.Contains(frm))
                    {
                        pr.formList.Add(frm);
                        await dbcontext.SaveChangesAsync();
                        mymodel.status = 200;
                        mymodel.message = "";
                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "آیتم تکراری";
                    }



                }


            }
            catch (Exception)
            {
                mymodel.status = 400;
                mymodel.message = "خطا";

            }
            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeProcessForm([FromBody] setNewFormProcessVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());

                using (Context dbcontext = new Context())
                {
                    process pr = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
                    form frm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);
                    pr.formList.Remove(frm);
                    await dbcontext.SaveChangesAsync();
                }


            }
            catch (Exception)
            {
                mymodel.status = 400;
                mymodel.message = "خطا";

            }
            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        //formItem



        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<formItemActionVM> getFormItem(form model)
        {
            object someObject;
            formItemActionVM responseModel = new formItemActionVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());

            try
            {
                using (Context dbcontext = new Context())
                {

                    var query = dbcontext.formItems.Where(x => x.formID == model.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.FormItemType).Select(x => new formItemVM { groupNumber = x.groupNumber, formID = x.formID, UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType });
                    responseModel.formItemList = await query.ToListAsync();

                    var query2 = dbcontext.orderOptions.Where(x => x.userID == userID && x.orderOptionID == x.parentID).Select(x => new orderOptionVM { image = x.image, orderOptionID = x.orderOptionID, title = x.title });
                    responseModel.orderOptionList = await query2.ToListAsync();

                    var query3 = dbcontext.formItemTypes.Select(x => new formItemTypeVM { title = x.title, formItemTypeID = x.formItemTypeID });
                    responseModel.formItemTypeList = await query3.ToListAsync();

                    var query4 = dbcontext.formItemDesigns.Select(x => new formItemDesingVM { title = x.title, formItemDesingID = x.formItemDesignID });
                    responseModel.formItemDesingList = await query4.ToListAsync();
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return responseModel;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setFormItem([FromBody] formItemVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());

                using (Context dbcontext = new Context())
                {

                    if (model.formItemID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {

                        var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.formItemID == model.formItemID);
                        if (string.IsNullOrEmpty(model.itemtImage))
                        {
                            mymodel.message = model.itemtImage;
                        }

                        formItem.itemtImage = model.itemtImage;
                        formItem.itemName = model.itemName;
                        formItem.itemPlaceholder = model.itemPlaceholder;
                        formItem.itemDesc = model.itemDesc;
                        formItem.formItemTypeID = model.formItemTypeID;
                        formItem.OptionID = model.optionSelected;
                        formItem.isMultiple = model.isMultiple;
                        formItem.groupNumber = model.groupNumber;
                        mymodel.status = 200;
                        await dbcontext.SaveChangesAsync();


                    }
                    else
                    {
                        var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.itemName == model.itemName && i.formID == model.formID);
                        if (formItem == null)
                        {

                            formItem fri = new formItem()
                            {
                                catchUrl = model.catchUrl,
                                itemDesc = model.itemDesc,
                                isMultiple = model.isMultiple,
                                formID = model.formID,
                                formItemID = Guid.NewGuid(),
                                formItemTypeID = model.formItemTypeID,
                                itemtImage = model.itemtImage,
                                itemName = model.itemName,
                                mediaType = model.mediaType,
                                itemPlaceholder = model.itemPlaceholder,
                                OptionID = model.optionSelected,
                                groupNumber = model.groupNumber,
                                formItemDesingID = model.formItemDesingID

                            };


                            dbcontext.formItems.Add(fri);
                            await dbcontext.SaveChangesAsync();

                            mymodel.status = 200;
                            mymodel.message = "ok";

                        }
                        else
                        {
                            mymodel.status = 400;
                            mymodel.message = "پروسه هم نام وجود دارد";
                        }
                    }



                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeFormItem([FromBody] formItemVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());
                using (Context dbcontext = new Context())
                {

                    var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.formItemID == model.formItemID);
                    if (formItem != null)
                    {
                        mymodel.message = formItem.itemtImage;
                        dbcontext.formItems.Remove(formItem);
                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;


                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "!خطا";
                    }


                }
            }
            catch (Exception eror)
            {

                mymodel.status = 400;
                mymodel.message = "!خطا";
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        // formula
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<formulaActionVM> getFormula(process process)
        {
            object someObject;
            object phone;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Request.Properties.TryGetValue("Userp", out phone);
            Guid userID = new Guid(someObject.ToString());


            formulaActionVM model = new formulaActionVM();
            try
            {
                using (Context dbcontext = new Context())
                {
                    process prc = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == process.processID);
                    List<formulaVM> formulalst = new List<formulaVM>();
                    var query = dbcontext.formulas.Where(x => x.userID == userID).Include(x => x.namad).Include(x => x.FormItem).AsQueryable();
                    //List<formula> lst = query.ToList();
                    List<formulaVM> formulas = await query.Select(item => new formulaVM
                    {
                        col = item.col,
                        formulaID = item.formulaID,
                        leftID = item.leftID,
                        name = item.name,
                        number = item.number,
                        result = item.result,
                        rightID = item.rightID,
                        namadName = item.namad == null ? "" : item.namad.value,
                        formItemName = item.FormItem == null ? "" : item.FormItem.itemDesc

                    }).ToListAsync();

                    Guid id1 = prc.formList.FirstOrDefault().formID;
                    Guid id2 = prc.formList.Skip(1).FirstOrDefault().formID;
                    formItemType frt = await dbcontext.formItemTypes.SingleOrDefaultAsync(x => x.title == "آیتم عددی");
                    var query1 = from formItem in dbcontext.formItems where formItem.formItemTypeID == frt.formItemTypeID select new formItemVM { itemDesc = formItem.itemDesc, formItemID = formItem.formItemID };
                    var query2 = from namad in dbcontext.namads select new namadVM { namadID = namad.namadID, title = namad.value };
                    model.formulaList = formulas;
                    model.formItemList = await query1.ToListAsync();
                    model.namadList = await query2.ToListAsync();
                    return model;
                }

            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setFormula([FromBody] formula model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());
                model.userID = userID;
                using (Context dbcontext = new Context())
                {

                    var process = await dbcontext.formulas.FirstOrDefaultAsync(i => i.leftID == model.leftID && i.rightID == model.rightID && i.number == model.number && i.namadID == model.namadID && i.formItemID == model.formItemID && i.col == model.col);
                    if (process == null)
                    {
                        var lastprocess = await dbcontext.formulas.OrderByDescending(x => x.col).FirstOrDefaultAsync();
                        int col = lastprocess != null ? lastprocess.col + 1 : 1;

                        var finalLeftFun = await dbcontext.formulas.FirstOrDefaultAsync(x => x.col == model.leftID);
                        var finalRightFun = await dbcontext.formulas.FirstOrDefaultAsync(x => x.col == model.rightID);



                        formItem fi = await dbcontext.formItems.SingleOrDefaultAsync(x => x.formItemID == model.formItemID);
                        namad na = await dbcontext.namads.SingleOrDefaultAsync(x => x.namadID == model.namadID);

                        string fuNamad = HttpUtility.HtmlDecode(na.value);
                        string numberormabna = "";
                        if (fi != null || model.number != 0)
                        {
                            numberormabna = model.number == 0 ? fi.itemDesc : model.number.ToString();

                        }

                        model.result = (model.leftID == 0 && model.rightID == 0) ? "( " + numberormabna + " )" : "( " + finalLeftFun.result + " " + fuNamad + " " + finalRightFun.result + " )";


                        dbcontext.formulas.Add(new formula() { processID = model.processID, name = model.name, userID = userID, formItemID = model.formItemID, number = model.number, formulaID = Guid.NewGuid(), namadID = model.namadID, leftID = model.leftID, rightID = model.rightID, col = col, result = model.result });
                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }


                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        // coding
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<List<codingVM>> getCoding()
        {
            object someObject;
            try
            {

                object phone;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Request.Properties.TryGetValue("Userp", out phone);
                Guid userID = new Guid(someObject.ToString());
                formulaActionVM model = new formulaActionVM();
                using (Context dbcontext = new Context())
                {
                    user userItem = await dbcontext.users.Where(x => x.phone == phone.ToString() && x.userType == "0").Include(x => x.Codings).SingleOrDefaultAsync();
                    List<codingVM> lst = new List<codingVM>();
                    foreach (var coding in userItem.Codings)
                    {
                        lst.Add(new codingVM()
                        {
                            codeHesab = coding.codeHesab,
                            codingID = coding.codingID,
                            codingType = coding.codingType,
                            parentID = coding.parentID,
                            title = coding.title,
                            inList = coding.inList

                        });

                    }
                    return lst;

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setCoding([FromBody] coding model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());
                model.userID = userID;

                if (model.codingID != new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    using (Context dbcontext = new Context())
                    {
                        var coding = await dbcontext.codings.FirstOrDefaultAsync(i => i.codingID == model.codingID);
                        coding.inList = model.inList == "on" ? "1" : "0";
                        coding.title = model.title;
                        coding.codeHesab = model.codeHesab;
                        await dbcontext.SaveChangesAsync();
                        mymodel.status = 200;
                        mymodel.message = "ok";


                    }
                }
                else
                {
                    using (Context dbcontext = new Context())
                    {

                        var coding = await dbcontext.codings.FirstOrDefaultAsync(i => i.codeHesab == model.codeHesab);
                        if (coding == null)
                        {

                            coding parentcoding = await dbcontext.codings.FirstOrDefaultAsync(x => x.codingID == model.parentID);

                            int itemCodingType = 1;


                            if (parentcoding != null)
                            {
                                int parentCodingType = parentcoding.codingType;
                                switch (parentCodingType)
                                {

                                    case 1:
                                        itemCodingType = 2;
                                        break;
                                    case 2:
                                        itemCodingType = 3;
                                        break;
                                    case 3:
                                        itemCodingType = 4;
                                        break;
                                    case 4:
                                        itemCodingType = 5;
                                        break;
                                    case 5:
                                        itemCodingType = 6;
                                        break;
                                    case 6:
                                        itemCodingType = 7;
                                        break;
                                    case 7:
                                        itemCodingType = 8;
                                        break;
                                }
                            }

                            dbcontext.codings.Add(new coding() { userID = userID, codingID = Guid.NewGuid(), codingType = itemCodingType, parentID = model.parentID, codeHesab = model.codeHesab, title = model.title });
                            await dbcontext.SaveChangesAsync();

                            mymodel.status = 200;
                            mymodel.message = "ok";

                        }
                        else
                        {
                            mymodel.status = 400;
                            mymodel.message = "پروسه هم نام وجود دارد";
                        }


                    }
                }


            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }


        // products


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<productActionVM> getProductsAsync()
        {
            object someObject;
            try
            {

                object phone;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Request.Properties.TryGetValue("Userp", out phone);
                Guid userID = new Guid(someObject.ToString());
                productActionVM model = new productActionVM();
                using (Context dbcontext = new Context())
                {
                    var products = await dbcontext.products.Where(x => x.userID == userID).Include(x => x.productTypes).Include(x => x.Tags).ToListAsync();//.Include(x => x.productType)
                    List<productVM> finallst = new List<productVM>();
                    foreach (var x in products)
                    {
                        productVM vmproducts = new productVM()
                        {
                            address = x.address,
                            code = x.code,
                            productID = x.productID,
                            title = x.title,
                            //productTypesrt = x.productType.title,
                            tagsrt = String.Join(", ", x.Tags.Select(t => t.title)),
                            productTypesrt = String.Join(", ", x.productTypes.Select(t => t.title)),

                        };
                        finallst.Add(vmproducts);

                    };
                    model.productList = finallst;
                    model.productTypeList = await dbcontext.productTypes.Select(x => new productTypeVM { productTypeID = x.productTypeID, title = x.title, parentID = x.parentID }).ToListAsync();
                    model.taglist = await dbcontext.tags.Where(x => x.userID == userID).Select(x => new tagVM { tagID = x.tagID, title = x.title }).ToListAsync();
                    return model;

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setProductAsync([FromBody] addProductVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());
                using (Context dbcontext = new Context())
                {

                    var product = await dbcontext.products.FirstOrDefaultAsync(x => x.title == model.title && x.code == model.code && x.barcode == model.barcode);
                    if (product == null)
                    {
                        Guid productID = Guid.NewGuid();
                        product myproduct = new product() { userID = userID, productID = productID, address = model.address, barcode = model.barcode, code = model.code, title = model.title };
                        dbcontext.products.Add(myproduct);
                        await dbcontext.SaveChangesAsync();
                        product selectedproduct = await dbcontext.products.Include(x => x.productTypes).Include(x => x.Tags).SingleOrDefaultAsync(x => x.productID == productID);
                        foreach (var item in model.productTypeID)
                        {
                            productType prt = await dbcontext.productTypes.SingleOrDefaultAsync(x => x.productTypeID == item);
                            selectedproduct.productTypes.Add(prt);


                        }
                        foreach (var item in model.produtTagID)
                        {
                            tag prt = await dbcontext.tags.SingleOrDefaultAsync(x => x.tagID == item);
                            selectedproduct.Tags.Add(prt);

                        }

                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }


                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> removeProductAsync([FromBody] addProductVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());
                using (Context dbcontext = new Context())
                {

                    var product = await dbcontext.products.FirstOrDefaultAsync(x => x.productID == model.productID);
                    if (product != null)
                    {
                        dbcontext.products.Remove(product);

                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }


                }
            }
            catch (Exception eror)
            {

                mymodel.status = 400;
                mymodel.message = "امکان حذف محصول وجود ندارد";
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }


        //productType
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<productTypeActionVM> getProductTypeAsync()
        {
            object someObject;
            try
            {

                object phone;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Request.Properties.TryGetValue("Userp", out phone);
                Guid userID = new Guid(someObject.ToString());
                productTypeActionVM model = new productTypeActionVM();
                using (Context dbcontext = new Context())
                {
                    var products = await dbcontext.productTypes.Where(x => x.userID == userID).Where(x => x.productTypeID == x.parentID).Select(x => new productTypeVM
                    {
                        parentID = x.parentID,
                        productTypeID = x.productTypeID,
                        title = x.title

                    }).ToListAsync();
                    model.prtlist = products;
                    return model;

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> addProductTypeAsync([FromBody] addProductTypeVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());

                using (Context dbcontext = new Context())
                {

                    var coding = await dbcontext.productTypes.FirstOrDefaultAsync(i => i.title == model.title);
                    if (coding == null)
                    {
                        Guid ptid = Guid.NewGuid();
                        Guid parenttid = ptid;


                        productType pr = new productType()
                        {
                            productTypeID = ptid,
                            parentID = parenttid,
                            title = model.title,
                            userID = userID,
                        };
                        dbcontext.productTypes.Add(pr);
                        await dbcontext.SaveChangesAsync();

                        if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            productType pp = await dbcontext.productTypes.SingleOrDefaultAsync(x => x.productTypeID == ptid);
                            pp.parentID = model.parentID;
                            await dbcontext.SaveChangesAsync();
                        }

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }


                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }


        //tag
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<productActionVM> getTagAsync()
        {
            object someObject;
            try
            {

                object phone;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Request.Properties.TryGetValue("Userp", out phone);
                Guid userID = new Guid(someObject.ToString());
                productActionVM model = new productActionVM();
                using (Context dbcontext = new Context())
                {
                    var products = await dbcontext.products.Where(x => x.userID == userID).Select(x => new productVM
                    {
                        address = x.address,
                        code = x.code,
                        productID = x.productID,
                        title = x.title
                    }).ToListAsync();
                    model.productList = products;
                    return model;

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setTag([FromBody] tagVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());

                using (Context dbcontext = new Context())
                {

                    var coding = await dbcontext.tags.FirstOrDefaultAsync(i => i.title == model.title);
                    if (coding == null)
                    {
                        dbcontext.tags.Add(new tag() { userID = userID, tagID = Guid.NewGuid(), title = model.title });
                        await dbcontext.SaveChangesAsync();

                        mymodel.status = 200;
                        mymodel.message = "ok";

                    }
                    else
                    {
                        mymodel.status = 400;
                        mymodel.message = "پروسه هم نام وجود دارد";
                    }


                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }

        // orderOption
        //productType
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<orderOptionActionVM> getOrderOptionAsync()
        {
            object someObject;
            try
            {

                object phone;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Request.Properties.TryGetValue("Userp", out phone);
                Guid userID = new Guid(someObject.ToString());
                orderOptionActionVM model = new orderOptionActionVM();
                using (Context dbcontext = new Context())
                {
                    var orderOption = await dbcontext.orderOptions.Where(x => x.userID == userID).Select(x => new orderOptionVM
                    {
                        parentID = x.parentID,
                        orderOptionID = x.orderOptionID,
                        title = x.title,
                        image = "Uploads/" + x.image

                    }).ToListAsync();
                    model.prtlist = orderOption;
                    return model;

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> addOrderOptionAsync([FromBody] addOrderOptionVM model)
        {
            responseModel mymodel = new responseModel();
            try
            {
                object someObject;
                Request.Properties.TryGetValue("UserToken", out someObject);
                Guid userID = new Guid(someObject.ToString());


                using (Context dbcontext = new Context())
                {

                    if (model.orderOptionID != new Guid("00000000-0000-0000-0000-000000000000"))
                    {

                        orderOption selecteOption = await dbcontext.orderOptions.FirstOrDefaultAsync(x => x.orderOptionID == model.orderOptionID);
                        mymodel.message = selecteOption.image;
                        selecteOption.image = model.image;
                        mymodel.status = 200;
                        await dbcontext.SaveChangesAsync();


                    }
                    else
                    {
                        var orop = await dbcontext.orderOptions.FirstOrDefaultAsync(i => i.title == model.title);
                        if (orop == null)
                        {
                            Guid ptid = Guid.NewGuid();
                            Guid parenttid = ptid;



                            orderOption pr = new orderOption()
                            {
                                orderOptionID = ptid,
                                parentID = parenttid,
                                title = model.title,
                                userID = userID,
                                image = model.image
                            };
                            dbcontext.orderOptions.Add(pr);
                            await dbcontext.SaveChangesAsync();

                            if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
                            {
                                orderOption pp = await dbcontext.orderOptions.SingleOrDefaultAsync(x => x.orderOptionID == ptid);
                                pp.parentID = model.parentID;
                                await dbcontext.SaveChangesAsync();
                            }

                            mymodel.status = 200;
                            mymodel.message = "ok";

                        }
                        else
                        {
                            mymodel.status = 400;
                            mymodel.message = "پروسه هم نام وجود دارد";
                        }
                    }



                }
            }
            catch (Exception eror)
            {

                throw;
            }

            string result = JsonConvert.SerializeObject(mymodel);
            JObject jObject = JObject.Parse(result);
            return jObject;
        }
        // form
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<processFormActionVM> getForm()
        {
            object someObject;
            processFormActionVM responseModel = new processFormActionVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    var query = from process in dbcontext.processes select process;
                    List<form> forlist = dbcontext.forms.ToList();
                    responseModel.processFormList = await dbcontext.forms.Select(x => new processFormVM { title = x.title, processFormID = x.formID }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                string srt = e.InnerException.Message;
                throw e;
            }


            return responseModel;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<JObject> setForm([FromBody] form model)
        {
            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    responseModel mymodel = new responseModel();
                    if (model.formID == new Guid("00000000-0000-0000-0000-000000000000"))
                    {
                        var form = await dbcontext.forms.FirstOrDefaultAsync(i => i.title == model.title);
                        if (form == null)
                        {
                            dbcontext.forms.Add(new form() { userID = userID, formID = Guid.NewGuid(), title = model.title });
                            await dbcontext.SaveChangesAsync();



                            mymodel.status = 200;
                            mymodel.message = "ok";

                        }
                        else
                        {
                            mymodel.status = 400;
                            mymodel.message = "پروسه هم نام وجود دارد";
                        }
                    }
                    else
                    {
                        string message = "";
                        var form = await dbcontext.forms.FirstOrDefaultAsync(i => i.formID == model.formID);
                        message = form.pdfBase + "," + form.pdf;

                        form.pdfBase = model.pdfBase;
                        form.pdf = model.pdf;
                        form.title = model.title;
                        mymodel.status = 200;
                        mymodel.message = message;
                        await dbcontext.SaveChangesAsync();


                    }




                    string result = JsonConvert.SerializeObject(mymodel);
                    JObject jObject = JObject.Parse(result);
                    return jObject;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<managerChart> getManagerChart([FromBody] ManagerChartSearch model)
        {

            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            managerChart managerServent = new managerChart();


            managerServent.list = await GetDataForManagerChart(model);
            return managerServent;


        }


        private async Task<List<serventChartVM>> GetDataForManagerOrderList(ManagerOrderList model)
        {
            List<serventChartVM> serlst = new List<serventChartVM>();

            DateTime toDate;
            DateTime fromDate;
            
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.toDate))
                {
                    toDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.toDate));
                    
                }
            }
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.fromDate))
                {
                    fromDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.fromDate));
                    
                }
            }
            

            try
            {
                using (Context dbcontext = new Context())
                {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }

            return serlst;
        }
        private async Task<List<serventChartVM>> GetDataForManagerChart(ManagerChartSearch model)
        {
            List<serventChartVM> serlst = new List<serventChartVM>();

            DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.startDate))
                {
                    startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.startDate));
                    startDate = startDate.AddDays(-7);
                }
            }
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.endDate))
                {
                    startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.endDate));
                    startDate = startDate.AddDays(1);
                }
            }


            string persianName = customMethodes.returnDayName(startDate);




            try
            {
                using (Context dbcontext = new Context())
                {
                    //List<user> uslist = dbcontext.users.Where(x => x.barbariID == userID).ToList();
                    List<codrivervm> driverList = await dbcontext.users.Where(x => x.barbariID != null).Include(x => x.workingStatus).Include(x => x.verifyStatus).Select(item => new codrivervm
                    {
                        did = item.userID,
                        dname = item.name,
                        phone = item.phone,


                    }).ToListAsync();


                    foreach (var item in driverList)
                    {

                        serventChartVM servent = new serventChartVM();
                        List<serventChartList> serventList = new List<serventChartList>();
                        servent.name = item.dname + " " + item.phone;
                        servent.serventID = item.did;
                        string dayname = persianName;
                        DateTime usingtime = startDate;
                        for (int i = 0; i <= 6; i++)
                        {

                            serventChartList chartlist = new serventChartList();
                            chartlist.dayName = dayname;
                            chartlist.persianDate = dateTimeConvert.ToPersianDateString(usingtime);
                            chartlist.timestamp = Classes.dateTimeConvert.ConvertDateTimeToTimestamp(usingtime);
                            chartlist.flowList = await dbcontext.newOrderFlows.Where(x => x.ServentID == item.did && x.actionDate == usingtime).Include(x => x.NewOrder).Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, orderID = x.NewOrder.newOrderID, isFinished = x.isFinished, flowID = x.newOrderFlowID, processColor = x.newOrderProcess.color, processName = x.newOrderProcess.title, orderName = x.NewOrder.orderName }).ToListAsync();
                            usingtime = usingtime.AddDays(1);
                            dayname = customMethodes.returnDayName(usingtime);

                            serventList.Add(chartlist);
                        }
                        servent.serventList = serventList;
                        serlst.Add(servent);
                    }




                }
            }
            catch (Exception)
            {

                throw;
            }

            return serlst;
        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<managerChart> getUserChart([FromBody] ManagerChartSearch model)
        {

            object someObject;
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());


            DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.startDate))
                {
                    startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.startDate));
                    startDate = startDate.AddDays(-7);
                }
            }
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.endDate))
                {
                    startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.endDate));
                    startDate = startDate.AddDays(1);
                }
            }


            string persianName = customMethodes.returnDayName(startDate);




            try
            {
                using (Context dbcontext = new Context())
                {


                    List<codrivervm> driverList = await dbcontext.users.Where(x => x.userID == userID).Include(x => x.workingStatus).Include(x => x.verifyStatus).Select(item => new codrivervm
                    {
                        did = item.userID,
                        dname = item.name,
                        phone = item.phone,


                    }).ToListAsync();
                    managerChart managerServent = new managerChart();
                    List<serventChartVM> serlst = new List<serventChartVM>();
                    foreach (var item in driverList)
                    {

                        serventChartVM servent = new serventChartVM();
                        List<serventChartList> serventList = new List<serventChartList>();
                        servent.name = item.dname + " " + item.phone;
                        servent.serventID = item.did;
                        string dayname = persianName;
                        DateTime usingtime = startDate;
                        for (int i = 0; i <= 6; i++)
                        {

                            serventChartList chartlist = new serventChartList();
                            chartlist.dayName = dayname;
                            chartlist.persianDate = dateTimeConvert.ToPersianDateString(usingtime);
                            chartlist.timestamp = Classes.dateTimeConvert.ConvertDateTimeToTimestamp(usingtime);
                            chartlist.flowList = await dbcontext.newOrderFlows.Where(x => x.ServentID == item.did && x.actionDate == usingtime).Include(x => x.NewOrder).Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, orderID = x.NewOrder.newOrderID, isFinished = x.isFinished, flowID = x.newOrderFlowID, processColor = x.newOrderProcess.color, processName = x.newOrderProcess.title, orderName = x.NewOrder.orderName }).ToListAsync();
                            usingtime = usingtime.AddDays(1);
                            dayname = customMethodes.returnDayName(usingtime);

                            serventList.Add(chartlist);
                        }
                        servent.serventList = serventList;
                        serlst.Add(servent);
                    }
                    managerServent.list = serlst;
                    return managerServent;


                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        // formDetailAPI
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> setFormDetail([FromBody] setFormDetailVM model)
        {
            object someObject;
            responseModel responseModel = new responseModel();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());

            try
            {
                using (Context dbcontext = new Context())
                {


                    //form formModel = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);

                    if (model.orderID != null)
                    {
                        if (model.orderID == new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            // یک نیو اردر ایجاد میکنیم

                            newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                            //Guid thirdPartyGUID = Guid.NewGuid();
                            //thirdParty thirdParty = new thirdParty()
                            //{
                            //    fullname = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyName").value,
                            //    address = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyAddress").value,
                            //    phone = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyPhone").value,
                            //    ThirdPartyID = thirdPartyGUID,
                            //};
                            //dbcontext.thirdParties.Add(thirdParty);


                            model.orderID = Guid.NewGuid();
                            newOrder neworder = new newOrder()
                            {
                                creationDate = DateTime.Now,
                                terminationDate = DateTime.Now,
                                newOrderID = model.orderID,
                                newOrderStatusID = neworderstatus.newOrderStatusID,
                                orderName = model.name

                                //thirdPartyID = thirdPartyGUID,
                            };
                            newOrder checkorder = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.orderName == model.name);
                            if (checkorder == null)
                            {
                                dbcontext.NewOrders.Add(neworder);
                            }
                            else
                            {
                                responseModel.status = 400;
                                responseModel.message = "سفارش تکراری است";
                                return responseModel;
                            }


                            await dbcontext.SaveChangesAsync();
                        }
                    }// 



                    newOrder orderSelected = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == model.orderID);
                    newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                    orderSelected.newOrderStatusID = stat.newOrderStatusID;

                    if (model.processID != null) //
                    {
                        if (model.processID == new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
                            model.processID = pr.processID;
                        }

                    }
                    Guid newFlowID = Guid.NewGuid();
                    if (model.flowID != null) //
                    {
                        if (model.flowID != new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
                            selectedflow.isFinished = "1";
                            newFlowID = model.flowID;

                        }
                        else
                        {
                            newOrderFlow newOrderFlow = new newOrderFlow()
                            {
                                creationDate = DateTime.Now,
                                actionDate = DateTime.Now,
                                processID = model.processID,
                                isFinished = "1",
                                newOrderID = model.orderID,
                                newOrderFlowID = newFlowID,
                                ServentID = userID,
                                terminationDate = DateTime.Now,
                            };
                            dbcontext.newOrderFlows.Add(newOrderFlow);
                        }

                    }
                    else
                    {
                        newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
                        selectedflow.isFinished = "1";
                        newFlowID = model.flowID;

                    }

                    await dbcontext.SaveChangesAsync();
                    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.formDetailList);
                    foreach (var item in lstform)
                    {
                        string fieldToGo = "";
                        switch (item.formItemTypeCode)
                        {
                            case ("6"): // انتخابی
                                fieldToGo = "valueBool";

                                break;
                            case ("8"): // موقعیت 
                                fieldToGo = "valueString";
                                break;
                            case ("7"):// آپلود
                                fieldToGo = "valueString";
                                break;
                            case ("1"):// چند گزینه ای
                                fieldToGo = "valueGuid";
                                break;
                            case ("5"): // تاریخ
                                fieldToGo = "valueDateTime";
                                break;
                            case ("4"): // عددی
                                fieldToGo = "valueDuoble";
                                break;
                            case ("3"): // متنی
                                fieldToGo = "valueString";
                                break;
                            case ("2"): //  متنی عکس دار
                                fieldToGo = "valueString";
                                break;
                        }
                        newOrderFields fieldItem = new newOrderFields();
                        fieldItem.formItemID = item.formItemID;
                        fieldItem.name = item.key;
                        fieldItem.newOrderFieldsID = Guid.NewGuid();
                        fieldItem.newOrderFlowID = newFlowID;
                        fieldItem.usedFeild = fieldToGo;
                        fieldItem.valueInt = 0;
                        fieldItem.valueDuoble = 0;
                        fieldItem.valueDateTime = DateTime.Now;
                        fieldItem.valueBool = false;
                        fieldItem.valueGuid = new Guid();

                        if (fieldToGo == "valueBool")
                            fieldItem.valueBool = Boolean.Parse(item.value);
                        if (fieldToGo == "valueString")
                            fieldItem.valueString = item.value;
                        if (fieldToGo == "valueDateTime")
                            fieldItem.valueDateTime = DateTime.Parse(item.value);
                        if (fieldToGo == "valueGuid")
                            fieldItem.valueGuid = new Guid(item.value);
                        if (fieldToGo == "valueDuoble")
                            fieldItem.valueDuoble = double.Parse(item.value);


                        dbcontext.newOrderFields.Add(fieldItem);

                    }

                    await dbcontext.SaveChangesAsync();

                    responseModel.status = 200;
                    responseModel.message = "";



                }
            }
            catch (Exception e)
            {

                responseModel.status = 400;
                responseModel.message = e.InnerException.Message;
                return responseModel;
            }

            return responseModel;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<listOfFormVM> formFullDetailInsert([FromBody] formFullDetailRequest model)
        {
            object someObject;
            formFullDetailVM responseModel = new formFullDetailVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            listOfFormVM response = new listOfFormVM();
            List<formItemList> formList = new List<formItemList>();
            try
            {
                using (Context dbcontext = new Context())
                {

                    process process = new process();

                    if (model != null)
                    {
                        if (model.processID == new Guid("00000000-0000-0000-0000-000000000000"))
                        {
                            process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
                        }

                        else
                        {
                            process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.processID == model.processID);
                        }
                    }
                    else
                    {
                        process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");


                    }





                    foreach (var form in process.formList.OrderBy(x => x.priority))
                    {
                        Guid typeid = new Guid("bdbf1018-bad4-43c5-9181-f8ea3fb1d994");// متنی تصویر دار
                        formItemList fil = new formItemList();
                        fil.formID = form.formID;
                        fil.formTitle = form.title;
                        fil.formImage = form.image;
                        fil.formHieght = form.imageHeight;
                        fil.formWidth = form.imageWidth;
                        fil.zaribWidth = form.zaribWidth;
                        fil.zaribHeight = form.zaribHeight;

                        fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { formItemTypeCode = x.FormItemType.formItemTypeCode, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemx = x.itemx, itemy = x.itemy, itemHeight = x.itemHeight, itemlength = x.itemLenght, pageNumber = x.pageNumber, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();

                        List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { itemHeight = l.itemHeight, itemlength = l.itemLenght, itemx = l.itemx, itemy = l.itemy, pageNumber = l.pageNumber, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();
                        int index = 0;
                        foreach (var item in lst)
                        {
                            formFullDetailItemVM extraDetail = new formFullDetailItemVM();
                            extraDetail.stringImageCollection = item;
                            extraDetail.formItemTypeCode = "2";


                            fil.formItemDetailList.Insert(index, extraDetail);
                            index += 1;
                        }


                        formList.Add(fil);
                    }

                    response.allForm = formList;

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
        public async Task<listOfFormVM> formFullDetailView([FromBody] formFullDetailRequest model)
        {
            object someObject;
            formFullDetailVM responseModel = new formFullDetailVM();

            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            listOfFormVM response = new listOfFormVM();
            List<formItemList> formList = new List<formItemList>();
            try
            {
                using (Context dbcontext = new Context())
                {
                    List<newOrderFields> insertedFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == model.flowID).ToListAsync();
                    process process = new process();

                    if (model == null)
                    {
                        process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
                    }
                    else
                    {
                        process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.processID == model.processID);
                    }



                    foreach (var form in process.formList.OrderBy(x => x.priority))
                    {

                        Guid typeid = new Guid("96479ab5-f846-432f-b176-8ad98f0cb89b");// متنی تصویر دار
                        Guid typeid2 = new Guid("9c77d5e9-a956-45dd-8451-b71eb5b5e7a7");// چند گزینه ای




                        formItemList fil = new formItemList();
                        fil.formID = form.formID;
                        fil.formTitle = form.title;
                        fil.formImage = form.image;
                        fil.formHieght = form.imageHeight;
                        fil.formWidth = form.imageWidth;
                        fil.zaribWidth = form.zaribWidth;
                        fil.zaribHeight = form.zaribHeight;
                        if (string.IsNullOrEmpty(fil.formImage))
                        {
                            fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID != typeid2).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
                            foreach (var item in fil.formItemDetailList)
                            {
                                newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
                                if (filed != null)
                                {
                                    var nameOfProperty = filed.usedFeild;
                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
                                    var value = propertyInfo.GetValue(filed, null);
                                    item.itemValue = value.ToString();
                                }

                            }

                            // افزودن متن تصویر دار
                            List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();

                            foreach (var item in lst)
                            {
                                foreach (var dd in item)
                                {
                                    newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == dd.formItemID);
                                    if (filed != null)
                                    {
                                        var nameOfProperty = filed.usedFeild;
                                        var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
                                        var value = propertyInfo.GetValue(filed, null);
                                        dd.itemValue = value.ToString();
                                    }

                                }
                            }
                            int index = 0;
                            foreach (var item in lst)
                            {
                                formFullDetailItemVM extraDetail = new formFullDetailItemVM();
                                extraDetail.stringImageCollection = item.Where(x => x.itemValue != null).ToList();
                                extraDetail.formItemTypeCode = "2";


                                fil.formItemDetailList.Insert(index, extraDetail);
                                index += 1;

                            }



                            // افزودن گزینه ها انتخابی
                            List<formFullDetailItemVM> multiSelectITems = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID == typeid2).Select(x => new formFullDetailItemVM { formItemID = x.formItemID }).ToListAsync();
                            if (multiSelectITems.Count() > 0)
                            {
                                List<Guid> orderOptionID = new List<Guid>();

                                foreach (var item in multiSelectITems)
                                {
                                    newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
                                    if (filed != null)
                                    {
                                        var nameOfProperty = filed.usedFeild;
                                        var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
                                        var value = propertyInfo.GetValue(filed, null);
                                        orderOptionID.Add(new Guid(value.ToString()));
                                    }


                                }
                                List<orderOptionVM> orderotpinVMForSelectedOptions = await dbcontext.orderOptions.Where(x => orderOptionID.Contains(x.orderOptionID)).Select(g => new orderOptionVM { image = "Uploads/" + g.image, orderOptionID = g.orderOptionID, parentID = g.parentID, title = g.title }).ToListAsync();
                                formFullDetailItemVM extraDetailMultiSelect = new formFullDetailItemVM();
                                extraDetailMultiSelect.orderOptions = orderotpinVMForSelectedOptions;
                                extraDetailMultiSelect.formItemTypeCode = "1";
                                extraDetailMultiSelect.itemDesc = "گزینه های انتخابی";
                                fil.formItemDetailList.Insert(0, extraDetailMultiSelect);
                            }
                        }

                        else
                        {
                            fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
                            foreach (var item in fil.formItemDetailList)
                            {
                                newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
                                if (filed != null)
                                {
                                    var nameOfProperty = filed.usedFeild;
                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
                                    var value = propertyInfo.GetValue(filed, null);
                                    item.itemValue = value.ToString();
                                }

                            }
                        }

                        formList.Add(fil);






                    }

                    response.allForm = formList;

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
        public async Task<userFlowVM> getUserFlow()
        {
            object someObject;
            formFullDetailVM responseModel = new formFullDetailVM();
            userFlowVM response = new userFlowVM();
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    response.flowList = await dbcontext.newOrderFlows.Where(x => x.ServentID == userID && x.isFinished != "1").Include(x => x.NewOrder).Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, orderID = x.NewOrder.newOrderID, isFinished = x.isFinished, flowID = x.newOrderFlowID, processName = x.newOrderProcess.title, orderName = x.NewOrder.orderName }).ToListAsync();
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
        public async Task<userFlowVM> getOrderFlow([FromBody] newOrder model)
        {
            object someObject;
            formFullDetailVM responseModel = new formFullDetailVM();
            userFlowVM response = new userFlowVM();
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    response.flowList = await dbcontext.newOrderFlows.Where(x => x.newOrderID == model.newOrderID && x.isFinished == "1").Include(x => x.NewOrder).Include(x => x.newOrderProcess).Select(x => new orderFlowVM { processID = x.newOrderProcess.processID, orderID = x.NewOrder.newOrderID, isFinished = x.isFinished, flowID = x.newOrderFlowID, processName = x.newOrderProcess.title, orderName = x.NewOrder.orderName }).ToListAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<flowCostVM> getFlowCost([FromBody] getFlowCost model)
        {
            object someObject;
            formFullDetailVM responseModel = new formFullDetailVM();
            flowCostVM response = new flowCostVM();
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {

                using (Context dbcontext = new Context())
                {
                    response.codingList = await dbcontext.codings.Where(x => x.inList == "1").Select(x => new codingVM { title = x.title, codingID = x.codingID }).ToListAsync();
                    response.productList = await dbcontext.products.Select(x => new productVM { title = x.title, productID = x.productID }).ToListAsync();
                    response.flowCodingList = await dbcontext.flowCodings.Where(x => x.flowID == model.flowID).Include(x => x.coding).Select(x => new flowCodingVM { amount = x.amount, codingTitle = x.coding.title }).ToListAsync();
                    response.flowProductList = await dbcontext.flowProducts.Where(x => x.flowID == model.flowID).Include(x => x.product).Select(x => new flowProductVM { amount = x.amount, productTitle = x.product.title }).ToListAsync();

                    return response;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> setFlowCoding([FromBody] setFlowCodingVM model)
        {
            object someObject;
            responseModel responseModel = new responseModel();
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    flowCoding flc = new flowCoding()
                    {
                        amount = model.amount,
                        CodingID = model.codingID,
                        flowID = model.flowID,
                        flowCodingID = Guid.NewGuid(),
                        date = DateTime.Now,
                    };
                    dbcontext.flowCodings.Add(flc);
                    await dbcontext.SaveChangesAsync();
                    responseModel.status = 200;
                    responseModel.message = "";
                }
            }
            catch (Exception)
            {
                responseModel.status = 400;
                responseModel.message = "";
                throw;
            }
            return responseModel;
        }
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> setFlowProduct([FromBody] setFlowProductVM model)
        {
            object someObject;
            responseModel responseModel = new responseModel();
            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            try
            {
                using (Context dbcontext = new Context())
                {
                    flowProduct flc = new flowProduct()
                    {
                        amount = model.amount,
                        productID = model.productID,
                        flowID = model.flowID,
                        flowCodingID = Guid.NewGuid(),
                        date = DateTime.Now,
                    };
                    dbcontext.flowProducts.Add(flc);
                    await dbcontext.SaveChangesAsync();
                    responseModel.status = 200;
                    responseModel.message = "";
                }
            }
            catch (Exception)
            {
                responseModel.status = 400;
                responseModel.message = "";
                throw;
            }
            return responseModel;
        }



        // manger 
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<chartDataVM> getDataForChart()
        {
            object someObject;


            Request.Properties.TryGetValue("UserToken", out someObject);
            Guid userID = new Guid(someObject.ToString());
            chartDataVM model = new chartDataVM();
            try
            {
                using (Context dbcontext = new Context())
                {


                    newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                    model.processList = await dbcontext.processes.Select(x => new processVM { processID = x.processID, title = x.title }).ToListAsync();
                    model.orderList = await dbcontext.NewOrders.Where(x => x.newOrderStatusID == orderstatus.newOrderStatusID).Select(x => new newOrderVM { creationDate = x.creationDate, newOrderID = x.newOrderID, orderName = x.orderName, terminationDate = x.terminationDate }).ToListAsync();
                    return model;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> setNewFlow([FromBody] newFlowVM model)
        {
            responseModel response = new responseModel();
            try
            {
                using (Context dbcontext = new Context())
                {
                    Guid newFlowID = Guid.NewGuid();
                    DateTime actinDate = Classes.dateTimeConvert.UnixTimeStampToDateTime(model.actionDate);

                    newOrderFlow newOrderFlow = new newOrderFlow()
                    {
                        creationDate = DateTime.Now,
                        processID = model.processID,
                        isFinished = "0",
                        isAccepted = "0",
                        newOrderID = model.orderID,
                        newOrderFlowID = newFlowID,
                        ServentID = model.serventID,
                        terminationDate = DateTime.Now.Date,
                        actionDate = actinDate.Date,

                    };
                    dbcontext.newOrderFlows.Add(newOrderFlow);
                    await dbcontext.SaveChangesAsync();

                    newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == model.orderID);
                    newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

                    order.newOrderStatusID = stat.newOrderStatusID;

                    user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == model.serventID && x.userType == "1");
                    Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
                    servent.workingStatusID = ustatuid;

                    await dbcontext.SaveChangesAsync();

                    response.status = 200;
                    response.message = "";

                }

            }
            catch (Exception e)
            {
                response.status = 400;
                response.message = "خطا";


            }
            return response;
        }


        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> flowStat([FromBody] acceptFlow model)
        {
            responseModel response = new responseModel();
            try
            {
                using (Context dbcontext = new Context())
                {
                    newOrderFlow flow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
                    flow.isAccepted = model.status;

                    await dbcontext.SaveChangesAsync();
                    response.status = 200;
                    response.message = "";

                }

            }
            catch (Exception e)
            {
                response.status = 400;
                response.message = "خطا";


            }
            return response;
        }

        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public async Task<responseModel> rejectAcceptFlowVM([FromBody] rejectAcceptFlowVM model)
        {
            responseModel response = new responseModel();
            try
            {
                using (Context dbcontext = new Context())
                {
                    newOrderFlow orderFlow = await dbcontext.newOrderFlows.Include(x => x.NewOrder).SingleOrDefaultAsync(x => x.newOrderFlowID == model.orderFlowID);
                    orderFlow.isAccepted = model.status;
                    if (model.status == "0")
                    {
                        newOrderStatus stat1 = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                        orderFlow.NewOrder.newOrderStatusID = stat1.newOrderStatusID;
                        orderFlow.terminationDate = DateTime.Now;
                    }

                    await dbcontext.SaveChangesAsync();


                    response.status = 200;
                    response.message = "";

                }

            }
            catch (Exception)
            {
                response.status = 400;
                response.message = "خطا";


            }
            return response;
        }









        //////////////////////////////////////////////
        ///






    }
}