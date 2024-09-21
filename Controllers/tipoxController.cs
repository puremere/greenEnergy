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
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using System.Web.Hosting;
using System.Text;
using System.Net.Http;
using Spire.Pdf;
using Spire.Pdf.Texts;
using System.Drawing;
using StreamChat.Clients;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


//using Spire.OCR;

namespace greenEnergy.Controllers
{
    //public class appController : System.Web.Http.ApiController
    //{


    //    public string getFlowData(string title, viewVM? datamodel)
    //    {
    //        string srt = "";
    //        var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "main");

    //        if (formDataSection != null)
    //        {
    //            var inmodel = formDataSection.items.SingleOrDefault(x => x.name == title);
    //            if (inmodel != null)
    //            {
    //                showFormAllVM mymodel = (showFormAllVM)inmodel;
    //                srt = JsonConvert.SerializeObject(mymodel);

    //            }
    //        }
            


    //        return srt;

    //    }


    //    public async Task<string> getLineChartData(viewVM? datamodel)
    //    {
    //        string srt = "[]";
    //        var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "lineChart");
    //        if (formDataSection != null)
    //        {
    //            showChartAllVM mymodel = (showChartAllVM)formDataSection.items.First();
    //            srt = JsonConvert.SerializeObject(mymodel);

    //        }


    //        return srt;

    //    }
    //    public async Task<string> getChartData(viewVM? datamodel)
    //    {

    //        string srt = "";
    //        var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "chartData");
    //        managerChartmain mymodel = (managerChartmain)formDataSection.items.First();
    //        srt = JsonConvert.SerializeObject(mymodel);
    //        return srt;

    //    }

    //    public async Task<List<formItemList>> getFormDataFromForm(int formID)
    //    {
    //        string srt = "";
    //        listOfFormVM response = new listOfFormVM();
    //        List<formItemList> formList = new List<formItemList>();
    //        using (Context dbcontext = new Context())
    //        {
    //            form form = new form();
    //            form = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == formID);

    //            Guid typeid = new Guid("bdbf1018-bad4-43c5-9181-f8ea3fb1d994");// متنی تصویر دار
    //            formItemList fil = new formItemList();
    //            fil.formID = form.formID;
    //            fil.formTitle = form.title;
    //            fil.formImage = form.image;
    //            fil.formHieght = form.imageHeight;
    //            fil.formWidth = form.imageWidth;
    //            fil.zaribWidth = form.zaribWidth;
    //            fil.zaribHeight = form.zaribHeight;

    //            fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).OrderBy(x => x.priority).Select(x => new formFullDetailItemVM { continueWithError = x.continueWithError.ToString(), referTo = x.referTo, regx = x.regx, validationType = x.validationType, isRequired = x.isRequired, minNumber = x.minNumber, maxNumber = x.maxNumber, otherFieldName = x.otherFieldName, formID = x.formID, isHidden = x.isHidden, operat = x.operat, relatedFormItemID = x.relatedForemItemID, formItemTypeCode = x.FormItemType.formItemTypeCode, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemx = x.itemx, itemy = x.itemy, itemHeight = x.itemHeight, itemlength = x.itemLenght, pageNumber = x.pageNumber, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).OrderBy(x => x.formItemID).ToListAsync();

    //            foreach (var item in fil.formItemDetailList)
    //            {
    //                if (item.isRequired == "on")
    //                {
    //                    validator validator = new validator();
    //                    validatorItem requiredItem = new validatorItem()
    //                    {
    //                        error = "مقدار آیتم نمیتواند خالی باشد",
    //                    };
    //                    validator.required = requiredItem;
    //                    if (item.validationType == "observe")
    //                    {
    //                        validatorItem observe = new validatorItem()
    //                        {
    //                            type = "observe",
    //                            error = "مقدار وارد شده صحیح نیست",
    //                            referTo = item.referTo,
    //                        };
    //                        validator.observe = observe;

    //                    }
    //                    else if (item.validationType == "range")
    //                    {
    //                        validatorItem lenght = new validatorItem()
    //                        {
    //                            type = "range",
    //                            error = " مقدار وارد شده باید در بازه " + item.minNumber.ToString() + " و " + item.maxNumber.ToString() + " باشد. ",
    //                            min = item.minNumber.ToString(),
    //                            max = item.maxNumber.ToString(),
    //                        };
    //                        validator.valueNumber = lenght;
    //                    }
    //                    else if (item.validationType == "min")
    //                    {
    //                        validatorItem min = new validatorItem()
    //                        {
    //                            type = "min",
    //                            error = "حداقل مقدار وارد شده  " + item.minNumber.ToString() + " می باشد",
    //                            value = item.minNumber.ToString(),

    //                        };
    //                        validator.valueNumber = min;
    //                    }
    //                    else if (item.validationType == "max")
    //                    {
    //                        validatorItem max = new validatorItem()
    //                        {
    //                            type = "max",
    //                            error = "کداکثر مقدار وارد شده " + item.maxNumber.ToString() + " می باشد",
    //                            value = item.maxNumber.ToString(),
    //                        };
    //                        validator.valueNumber = max;
    //                    }
    //                    else if (item.validationType == "regex")
    //                    {
    //                        string finalValue = "";
    //                        if (item.regx == "email")
    //                        {

    //                        }
    //                        else if (item.regx == "ID")
    //                        {
    //                            finalValue = "^([0-9]){10}$";
    //                        }
    //                        validatorItem format = new validatorItem()
    //                        {
    //                            type = "regex",
    //                            error = "فورمت وارد شده صحیح نیست",
    //                            value = finalValue,
    //                            max = item.maxNumber.ToString(),
    //                        };
    //                        validator.format = format;
    //                    }
    //                    item.validator = validator;

    //                }
    //            }
    //            formList.Add(fil);
    //        }
    //        return formList;


    //    }
    //    public async Task<string> getFormData(int? flowID, int? formID, viewVM? datamodel)
    //    {
    //        string srt = "";
    //        listOfFormVM response = new listOfFormVM();
    //        List<formItemList> formList = new List<formItemList>();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                form form = new form();
    //                if (flowID != null)
    //                {
    //                    List<process> prc = await dbcontext.newOrderFlows.Include(x => x.newOrderProcess).Include(x => x.newOrderProcess.formList).Where(x => x.newOrderFlowID == flowID).Select(x => x.newOrderProcess).ToListAsync();
    //                    form = prc.First().formList.First();

    //                }
    //                else
    //                {
    //                    form = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == formID);
    //                }

    //                Guid typeid = new Guid("bdbf1018-bad4-43c5-9181-f8ea3fb1d994");// متنی تصویر دار
    //                formItemList fil = new formItemList();
    //                fil.formID = form.formID;
    //                fil.formTitle = form.title;
    //                fil.formImage = form.image;
    //                fil.formHieght = form.imageHeight;
    //                fil.formWidth = form.imageWidth;
    //                fil.zaribWidth = form.zaribWidth;
    //                fil.zaribHeight = form.zaribHeight;

    //                fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).OrderBy(x => x.priority).Select(x => new formFullDetailItemVM { continueWithError = x.continueWithError, referTo = x.referTo, regx = x.regx, validationType = x.validationType, isRequired = x.isRequired, minNumber = x.minNumber, maxNumber = x.maxNumber, otherFieldName = x.otherFieldName, isHidden = x.isHidden, operat = x.operat, relatedFormItemID = x.relatedForemItemID, formItemTypeCode = x.FormItemType.formItemTypeCode, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemx = x.itemx, itemy = x.itemy, itemHeight = x.itemHeight, itemlength = x.itemLenght, pageNumber = x.pageNumber, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).OrderBy(x => x.formItemID).ToListAsync();

    //                foreach (var item in fil.formItemDetailList)
    //                {
    //                    if (item.isRequired == "on")
    //                    {
    //                        validator validator = new validator();
    //                        validatorItem requiredItem = new validatorItem()
    //                        {
    //                            error = "مقدار آیتم نمیتواند خالی باشد",
    //                        };
    //                        validator.required = requiredItem;
    //                        if (item.validationType == "observe")
    //                        {
    //                            validatorItem observe = new validatorItem()
    //                            {
    //                                type = "observe",
    //                                error = "مقدار وارد شده صحیح نیست",
    //                                referTo = item.referTo,
    //                            };
    //                            validator.observe = observe;

    //                        }
    //                        else if (item.validationType == "range")
    //                        {
    //                            validatorItem lenght = new validatorItem()
    //                            {
    //                                type = "range",
    //                                error = " مقدار وارد شده باید در بازه " + item.minNumber.ToString() + " و " + item.maxNumber.ToString() + " باشد. ",
    //                                min = item.minNumber.ToString(),
    //                                max = item.maxNumber.ToString(),
    //                            };
    //                            validator.valueNumber = lenght;
    //                        }
    //                        else if (item.validationType == "min")
    //                        {
    //                            validatorItem min = new validatorItem()
    //                            {
    //                                type = "min",
    //                                error = "حداقل مقدار وارد شده  " + item.minNumber.ToString() + " می باشد",
    //                                value = item.minNumber.ToString(),

    //                            };
    //                            validator.valueNumber = min;
    //                        }
    //                        else if (item.validationType == "max")
    //                        {
    //                            validatorItem max = new validatorItem()
    //                            {
    //                                type = "max",
    //                                error = "کداکثر مقدار وارد شده " + item.maxNumber.ToString() + " می باشد",
    //                                value = item.maxNumber.ToString(),
    //                            };
    //                            validator.valueNumber = max;
    //                        }
    //                        else if (item.validationType == "regex")
    //                        {
    //                            string finalValue = "";
    //                            if (item.regx == "email")
    //                            {

    //                            }
    //                            else if (item.regx == "ID")
    //                            {
    //                                finalValue = "^([0-9]){10}$";
    //                            }
    //                            validatorItem format = new validatorItem()
    //                            {
    //                                type = "regex",
    //                                error = "فورمت وارد شده صحیح نیست",
    //                                value = finalValue,
    //                                max = item.maxNumber.ToString(),
    //                            };
    //                            validator.format = format;
    //                        }
    //                        item.validator = validator;

    //                    }
    //                }



    //                if (datamodel.chunkList != null)
    //                {
    //                    var formDataSection = datamodel.chunkList.SingleOrDefault(x => x.name == "formData");


    //                    if (formDataSection != null)
    //                    {

    //                        foreach (var oplist in formDataSection.items)
    //                        {
    //                            var selecteditem = fil.formItemDetailList.SingleOrDefault(x => x.itemName == oplist.name);
    //                            if (selecteditem != null)
    //                            {
    //                                formOptionObject mymodel = (formOptionObject)oplist;
    //                                selecteditem.orderOptions = mymodel.lst;
    //                            }
    //                        }
    //                    }

    //                }


    //                List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { isHidden = l.isHidden, relatedFormItemID = l.relatedForemItemID, operat = l.operat, itemHeight = l.itemHeight, itemlength = l.itemLenght, itemx = l.itemx, itemy = l.itemy, pageNumber = l.pageNumber, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();

    //                int index = 0;

    //                foreach (var item in lst)
    //                {
    //                    formFullDetailItemVM extraDetail = new formFullDetailItemVM();
    //                    extraDetail.stringImageCollection = item;
    //                    extraDetail.formItemTypeCode = "2";


    //                    fil.formItemDetailList.Insert(index, extraDetail);
    //                    index += 1;
    //                }


    //                formList.Add(fil);
    //            }
    //            response.allForm = formList;
    //            srt = JsonConvert.SerializeObject(response);
    //            return srt.Replace("\"validator\":null,", "");
    //        }
    //        catch (Exception e)
    //        {
    //            return "";
    //            throw;
    //        }
            

    //    }


    //    private async Task<List<pageContentVM>> getChildContentWeb(Guid? sectinoID, pageContentVM? content, string lang)
    //    {
    //        using (Context dbcontext = new Context())
    //        {
    //            List<pageContentVM> response = new List<pageContentVM>();
    //            if (sectinoID != null)
    //            {
    //                response = await dbcontext.contents.Include(x => x.HTML).Where(x => x.sectionID == sectinoID && x.parentID == null).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM { useParentSection = l.useParentSection, htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();
    //            }
    //            else
    //            {
    //                response = await dbcontext.contents.Include(x => x.HTML).Where(x => x.parentID == content.conentID).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM { useParentSection = l.useParentSection, htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, poseMeta = l.HTML.poseMeta, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, poseList = l.Poses.Select(x => new poseVM { poseID = x.poseID, title = x.title, title2 = x.title2 }).ToList(), dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();
    //            }

    //            foreach (var item in response)
    //            {
    //                if (item.typeID != null)
    //                {

    //                    language langselected = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == lang);
    //                    var qrrr = dbcontext.sections.Where(x => x.sectionTypeID == item.typeID);
    //                    if (langselected != null)
    //                    {
    //                        qrrr = qrrr.Where(x => x.languageID == langselected.languageID);
    //                    }
    //                    item.childList = await qrrr.OrderByDescending(x => x.date).Select(x => new sectionVM { categoryName = x.Category.title, url = x.url, title = x.title, description = x.description, image = x.image, date = x.date, writer = x.writer, buttonText = x.buttonText }).Take(10).ToListAsync();
    //                }
    //                item.contentChild = await getChildContentWeb(null, item, lang);
    //            }

    //            return response;


    //        }

    //    }

    //    private async Task<string> replaceSection(List<pageContentVM> contents, pageSectionVM section)
    //    {

    //        foreach (var item in contents)
    //        {
    //            if (item.useParentSection == 1)
    //            {
    //                List<sectionVM> lst = new List<sectionVM>();
    //                sectionVM sectionItem = new sectionVM()
    //                {
    //                    title = section.title,
    //                    description = section.description,
    //                    image = section.image,
    //                    date = section.date,
    //                    writer = section.writer,
    //                    tags = section.tags

    //                };
    //                lst.Add(sectionItem);
    //                item.childList = lst;
    //                if (item.contentChild != null)
    //                {
    //                    if (item.contentChild.Count() > 0)
    //                    {
    //                        await replaceSection(item.contentChild, section);
    //                    }
    //                }
    //            }
    //        }
    //        return "";
    //    }
    //    public async Task<getChildContentVM> getChildContent(Guid? sectinoID, pageContentVM? content, viewVM? datamodel, Dictionary<string, string> HtmlItems)
    //    {
    //        List<pageContentVM> response = new List<pageContentVM>();
    //        getChildContentVM modelResponce = new getChildContentVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            string finalStackPose = "";

    //            string finalPose = "";
    //            string finalHtml = "";
    //            string finalCycleFields = "";
    //            if (sectinoID != null)
    //            {
    //                response = await dbcontext.contents.Where(x => x.sectionID == sectinoID && x.parentID == null).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM { htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();

    //                foreach (var item in response)
    //                {

    //                    if (string.IsNullOrEmpty(item.cycleFields))
    //                    {
    //                        if (!string.IsNullOrEmpty(item.cycleFields))
    //                        {
    //                            List<string> fieldslist = item.cycleFields.Trim(',').Split(',').ToList();
    //                            foreach (var field in fieldslist)
    //                            {
    //                                recycleDataMapVM mdl = new recycleDataMapVM()
    //                                {
    //                                    viewID = item.title,
    //                                    dataProperty = item.title + "_" + field,
    //                                    viewProperty = item.title
    //                                };
    //                                finalCycleFields += JsonConvert.SerializeObject(mdl);
    //                            }
    //                        }

    //                    }
    //                    List<string> values = !string.IsNullOrEmpty(item.htmlFields) ? item.htmlFields.Split(',').Select(s => s.ToString()).ToList() : new List<string>();
    //                    foreach (var htmlfield in values)
    //                    {
    //                        dataVM sdata = item.dataList.SingleOrDefault(x => x.title == htmlfield && !string.IsNullOrEmpty(x.title2));
    //                        if (sdata != null)
    //                        {
    //                            item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
    //                        }
    //                        else
    //                        {
    //                            item.appMeta = await methods.removenull(item.appMeta, htmlfield, item.title);
    //                        }
    //                    }

    //                    if (!string.IsNullOrEmpty(item.stackWeight))
    //                    {
    //                        stackPoseVM sp = new stackPoseVM()
    //                        {
    //                            viewID = item.title,
    //                            weight = double.Parse(item.stackWeight)
    //                        };
    //                        finalStackPose += JsonConvert.SerializeObject(sp) + ",";
    //                    }
    //                    if (item.formID != null)
    //                    {
    //                        finalHtml += item.appMeta + ",";
    //                        dataVM sdata = item.dataList.SingleOrDefault(x => x.title == "isReadableOnlysrt" && x.title2 == "1");
    //                        string myresult = "";
    //                        if (sdata != null)
    //                        {

    //                            myresult = getFlowData(item.title, datamodel);
    //                        }
    //                        else
    //                        {
    //                            myresult = await getFormData(null, item.formID, datamodel);
    //                        }



    //                        item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                        item.appMeta = item.appMeta.Replace("actionIDsrt", item.title);
    //                        item.appMeta = item.appMeta.Replace("childMetaString", myresult);

    //                    }
    //                    else
    //                    {


    //                        if (!HtmlItems.ContainsKey(item.title))
    //                        {
    //                            HtmlItems["childMetaString"] += item.appMeta + ",";
    //                        }
    //                        else
    //                        {
    //                            HtmlItems[item.title] += item.appMeta + ",";
    //                        }
    //                        //finalHtml += item.appMeta + ",";
    //                        Dictionary<string, string> hitems = new Dictionary<string, string>();
    //                        hitems.Add("childMetaString", "");
    //                        if (item.appType == "page")
    //                        {
    //                            hitems.Add("leadsrt", "");
    //                            hitems.Add("trailsrt", "");
    //                        }
    //                        getChildContentVM myresult = await getChildContent(null, item, datamodel, hitems);
    //                        item.contentChild = myresult.list;
    //                        item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                        item.appMeta = item.appMeta.Replace("actionIDsrt", item.title);
    //                        foreach (var nm in myresult.newMeta)
    //                        {
    //                            string replacestring = nm.Value;
    //                            if (string.IsNullOrEmpty(replacestring) && nm.Key != "childMetaString")
    //                            {
    //                                replacestring = "null";
    //                            }
    //                            item.appMeta = item.appMeta.Replace(nm.Key, replacestring.Trim(',')).Trim(',');
    //                        }

    //                        item.poseMeta = item.appMeta.Replace("childPoseString", myresult.newPose.Trim(','));
    //                        if (item.appType == "cycleView")
    //                        {
    //                            item.appMeta = item.appMeta.Replace("dataMapString", myresult.cycleMeta.Trim(','));
    //                        }


    //                    }


    //                }
    //                //{"nav": null,"view": {"type": "stackView","orientation": 0,"backColor": "#222222","cornerRadius": 10,"content": [childMetaString] }}
    //                //{"type": "pairTextView","viewID": "secondLabel","id": "priceID","keyText": "Name","valueText": "title","keyColor": "#ffffff","valueColor": "#ececec"}
    //                //{"type": "button","viewID" :"viewMetaIDsrt","text":"textsrt","color":"colorsrt","backColor":"backColorsrt","borderColor":"borderColorsrt","cornerRadius":cornerRadiussrt,"alignment":"alignmentsrt","font":"fontsrt","size":sizesrt,"width":widthsrt,"height":heightsrt,"margin":marginsrt, "actions":[childMetaString] }
    //                // {"type":"typesrt","to":"tosrt","varName":"varNamesrt", {"type":"typesrt","to":"tosrt","orientation":orientationsrt,"varName":"varNamesrt", "value":"valuesrt","depth":depthsrt,"actions":actionssrt} {"type":"typesrt","to":"tosrt","orientation":orientationsrt,"varName":"varNamesrt", "value":"valuesrt"}
    //            }
    //            else
    //            {

    //                response = await dbcontext.contents.Where(x => x.parentID == content.conentID).Include(x => x.Poses).Include(x => x.Datas).OrderBy(l => l.priority).Select(l => new pageContentVM { htmlFields = l.HTML.dataField, stackWeight = l.stackWeight, cycleFields = l.cycleFields, formID = l.formID, poseMeta = l.HTML.poseMeta, appMeta = l.HTML.appMeta, appType = l.HTML.appType, description = l.description, typeID = l.sectionTypeID, priority = l.priority, conentID = l.contentID, parentID = l.parentID, title = l.title, partialName = l.HTML.partialView, poseList = l.Poses.Select(x => new poseVM { poseID = x.poseID, title = x.title, title2 = x.title2 }).ToList(), dataList = l.Datas.Select(m => new dataVM { dataID = m.dataID, title = m.title, description = m.description, description2 = m.description2, mediaURL = m.mediaURL, title2 = m.title2, viedoIframe = m.viedoIframe }).ToList() }).ToListAsync();

    //                foreach (var item in response)
    //                {

    //                    if (item.appType == "action")
    //                    {

    //                    }
    //                    if (!string.IsNullOrEmpty(item.cycleFields))
    //                    {
    //                        List<string> fieldslist = item.cycleFields.Trim(',').Split(',').ToList();
    //                        if (item.appType == "action")
    //                        {
    //                            foreach (var field in fieldslist)
    //                            {

    //                                recycleDataMapVM mdl = new recycleDataMapVM()
    //                                {
    //                                    viewID = content.title,
    //                                    actionID = item.title,
    //                                    viewProperty = field.Replace("srt", ""),
    //                                    dataProperty = item.title + "_" + field,



    //                                };
    //                                finalCycleFields += JsonConvert.SerializeObject(mdl) + ",";
    //                            }

    //                        }
    //                        else
    //                        {
    //                            foreach (var field in fieldslist)
    //                            {
    //                                recycleDataMapVM mdl = new recycleDataMapVM()
    //                                {
    //                                    viewID = item.title,
    //                                    viewProperty = field.Replace("srt", ""),
    //                                    dataProperty = item.title + "_" + field,



    //                                };
    //                                finalCycleFields += JsonConvert.SerializeObject(mdl) + ",";
    //                            }
    //                        }

    //                    }
    //                    List<string> values = item.htmlFields.Split(',').Select(s => s.ToString()).ToList();


    //                    foreach (var htmlfield in values)
    //                    {
    //                        dataVM sdata = item.dataList.SingleOrDefault(x => x.title == htmlfield && !string.IsNullOrEmpty(x.title2));
    //                        if (sdata != null) // داخل پنل یه مقداری برای یک اتریبیوت گذاشتیم
    //                        {

    //                            if (datamodel.chunkList != null)
    //                            {
    //                                bool canContinue = true;
    //                                itemParent dlist = datamodel.chunkList.SingleOrDefault(x => x.name == "dynamicField");
    //                                string itemnamee = item.title + "_" + sdata.title;
    //                                if (dlist != null)
    //                                {

    //                                    if (dlist.items != null)
    //                                    {
    //                                        flowDetailAll flowDetail = dlist.items[0] as flowDetailAll;
    //                                        if (flowDetail.allData.ContainsKey(itemnamee))
    //                                        {
    //                                            string newsrt = flowDetail.allData[itemnamee];
    //                                            item.appMeta = item.appMeta.Replace(sdata.title, newsrt);
    //                                            canContinue = false;
    //                                        }

    //                                    }
    //                                } // با چک میکنیم اگه داخل داینامیک بود دیگه کاری به بقیه چیزا نداریم
    //                                if (canContinue)
    //                                {
    //                                    itemParent dlst = datamodel.chunkList.SingleOrDefault(x => x.name == "main");
    //                                    if (dlst != null)
    //                                    {

    //                                        if (dlst.items != null)
    //                                        {
    //                                            flowDetailAll flowDetail = dlst.items[0] as flowDetailAll;
    //                                            if (flowDetail != null)
    //                                            {
    //                                                if (flowDetail.allData.ContainsKey(item.title))
    //                                                {
    //                                                    string newsrt = flowDetail.allData[item.title];
    //                                                    if ((item.appType == "imageView" && sdata.title == "srcsrt") || (item.appType == "label" && sdata.title == "textsrt") || (item.appType == "perTextView" && sdata.title == "valueTextsrt") || (item.appType == "action" && sdata.title == "valuesrt"))
    //                                                    {
    //                                                        item.appMeta = item.appMeta.Replace(sdata.title, newsrt);
    //                                                        canContinue = false;
    //                                                    }
    //                                                }
    //                                            }
    //                                            else
    //                                            {
    //                                                {
    //                                                    if (dlst.items[0].GetType().GetProperty(itemnamee) != null)
    //                                                    {
    //                                                        string newsrt = dlst.items[0].GetType().GetProperty(itemnamee).GetValue(dlst.items[0], null) + "";
    //                                                        item.appMeta = item.appMeta.Replace(sdata.title, newsrt);
    //                                                        canContinue = false;
    //                                                    }
    //                                                }
    //                                            }

    //                                        }

    //                                    }
    //                                }


    //                                if (canContinue)
    //                                {
    //                                    item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
    //                                }

    //                            }
    //                            else
    //                            {
    //                                item.appMeta = item.appMeta.Replace(sdata.title, sdata.title2);
    //                            }

    //                        }
    //                        else
    //                        {
    //                            item.appMeta = await methods.removenull(item.appMeta, htmlfield, item.title);
    //                        }
    //                    }

    //                    if (!string.IsNullOrEmpty(item.stackWeight))
    //                    {
    //                        stackPoseVM sp = new stackPoseVM()
    //                        {
    //                            viewID = item.title,
    //                            weight = double.Parse(item.stackWeight)
    //                        };
    //                        finalStackPose += JsonConvert.SerializeObject(sp) + ",";
    //                    }
    //                    if (item.appType == "form")
    //                    {
    //                        //finalHtml += item.appMeta + ",";

    //                        dataVM sdata = item.dataList.SingleOrDefault(x => x.title == "isReadableOnlysrt" && x.title2 == "1");
    //                        string myresult = "";
    //                        if (sdata != null)
    //                        {

    //                            myresult = getFlowData(item.title, datamodel);
    //                        }
    //                        else
    //                        {
    //                            if (item.formID == null)
    //                            {
    //                                myresult = getFlowData(item.title, datamodel);
    //                            }
    //                            else
    //                            {
    //                                int? finalFlowID = null;
    //                                if (datamodel.chunkList != null)
    //                                {
    //                                    itemParent dlst = datamodel.chunkList.SingleOrDefault(x => x.name == "main");

    //                                    if (dlst != null)
    //                                    {
    //                                        string itemnamee = item.title;

    //                                        if (dlst.items != null)
    //                                        {

    //                                            if (dlst.items[0].GetType().GetProperty(itemnamee) != null)
    //                                            {
    //                                                string newsrt = dlst.items[0].GetType().GetProperty(itemnamee).GetValue(dlst.items[0], null) + "";
    //                                                finalFlowID = Int32.Parse(newsrt); // new Guid(newsrt);
    //                                            }

    //                                        }
    //                                    }

    //                                }


    //                                myresult = await getFormData(finalFlowID, item.formID, datamodel);
    //                            }

    //                        }
    //                        item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                        item.appMeta = item.appMeta.Replace("actionIDsrt", item.title);
    //                        item.appMeta = item.appMeta.Replace("childMetaString", myresult);

    //                        if (!HtmlItems.ContainsKey(item.title))
    //                        {
    //                            HtmlItems["childMetaString"] += item.appMeta + ",";
    //                        }
    //                        else
    //                        {
    //                            HtmlItems[item.title] += item.appMeta + ",";
    //                        }
    //                        //finalHtml += item.appMeta + ",";
    //                        //finalPose += item.poseMeta + ",";
    //                        int counter = 0;
    //                        foreach (var poseItem in item.poseList)
    //                        {
    //                            if (string.IsNullOrEmpty(poseItem.title2))
    //                            {
    //                                item.poseMeta = await methods.removenull(item.poseMeta, poseItem.title, item.title);
    //                            }
    //                            else
    //                            {
    //                                item.poseMeta = item.poseMeta.Replace(poseItem.title, poseItem.title2);
    //                                counter += 1;
    //                            }



    //                        }
    //                        if (counter != 0)
    //                        {
    //                            string newposemeta = item.poseMeta.Replace("ViewIDsrt", item.title);
    //                            item.poseMeta = newposemeta;
    //                            finalPose += item.poseMeta + ",";
    //                        }

    //                    }
    //                    else
    //                    {
    //                        if (item.appType == "lineChart")
    //                        {
    //                            string myresult = await getLineChartData(datamodel);
    //                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                            item.appMeta = item.appMeta.Replace("childMetaString", myresult);
    //                            HtmlItems["childMetaString"] += item.appMeta + ",";
    //                            finalPose += item.poseMeta + ",";
    //                            int counter = 0;
    //                            foreach (var poseItem in item.poseList)
    //                            {
    //                                if (string.IsNullOrEmpty(poseItem.title2))
    //                                {
    //                                    item.poseMeta = await methods.removenull(item.poseMeta, poseItem.title, item.title);
    //                                }
    //                                else
    //                                {
    //                                    item.poseMeta = item.poseMeta.Replace(poseItem.title, poseItem.title2);
    //                                    counter += 1;
    //                                }



    //                            }
    //                            if (counter != 0)
    //                            {
    //                                string newposemeta = item.poseMeta.Replace("ViewIDsrt", item.title);
    //                                item.poseMeta = newposemeta;
    //                                finalPose += item.poseMeta + ",";
    //                            }
    //                        }
    //                        else if (item.appType == "chartView")
    //                        {
    //                            string myresult = await getChartData(datamodel);
    //                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                            item.appMeta = item.appMeta.Replace("childMetaString", myresult);

    //                            if (!HtmlItems.ContainsKey(item.title))
    //                            {
    //                                HtmlItems["childMetaString"] += item.appMeta + ",";
    //                            }
    //                            else
    //                            {
    //                                HtmlItems[item.title] += item.appMeta + ",";
    //                            }
    //                            //finalHtml += item.appMeta + ",";
    //                            finalPose += item.poseMeta + ",";
    //                            int counter = 0;
    //                            foreach (var poseItem in item.poseList)
    //                            {
    //                                if (string.IsNullOrEmpty(poseItem.title2))
    //                                {
    //                                    item.poseMeta = await methods.removenull(item.poseMeta, poseItem.title, item.title);
    //                                }
    //                                else
    //                                {
    //                                    item.poseMeta = item.poseMeta.Replace(poseItem.title, poseItem.title2);
    //                                    counter += 1;
    //                                }



    //                            }
    //                            if (counter != 0)
    //                            {
    //                                string newposemeta = item.poseMeta.Replace("ViewIDsrt", item.title);
    //                                item.poseMeta = newposemeta;
    //                                finalPose += item.poseMeta + ",";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            if (item.appType == "action")
    //                            {
    //                                //string newposemeta = item.poseMeta.Replace("namesrt", item.title);
    //                            }
    //                            Dictionary<string, string> hitems = new Dictionary<string, string>();
    //                            hitems.Add("childMetaString", "");
    //                            if (item.appType == "page")
    //                            {
    //                                hitems.Add("leadsrt", "");
    //                                hitems.Add("trailsrt", "");
    //                            }
    //                            getChildContentVM myresult = await getChildContent(null, item, datamodel, hitems);
    //                            item.appMeta = item.appMeta.Replace("childPoseString", myresult.newPose.Trim(','));
    //                            item.appMeta = item.appMeta.Replace("stackPose", myresult.stackPose.Trim(','));
    //                            item.contentChild = myresult.list;
    //                            finalCycleFields += myresult.cycleMeta;
    //                            int counter = 0;
    //                            foreach (var poseItem in item.poseList)
    //                            {
    //                                if (string.IsNullOrEmpty(poseItem.title2))
    //                                {
    //                                    item.poseMeta = await methods.removenull(item.poseMeta, poseItem.title, item.title);
    //                                }
    //                                else
    //                                {
    //                                    item.poseMeta = item.poseMeta.Replace(poseItem.title, poseItem.title2);
    //                                    counter += 1;
    //                                }



    //                            }
    //                            if (counter != 0)
    //                            {
    //                                string newposemeta = item.poseMeta.Replace("ViewIDsrt", item.title);
    //                                item.poseMeta = newposemeta;
    //                                finalPose += item.poseMeta + ",";
    //                            }
    //                            item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);
    //                            item.appMeta = item.appMeta.Replace("actionIDsrt", item.title);
    //                            foreach (var nm in myresult.newMeta)
    //                            {
    //                                string replacestring = nm.Value;
    //                                if (string.IsNullOrEmpty(replacestring) && nm.Key != "childMetaString")
    //                                {
    //                                    replacestring = "null";
    //                                }
    //                                item.appMeta = item.appMeta.Replace(nm.Key, replacestring.Trim(',')).Trim(',');
    //                            }



    //                            if (item.appType == "cycleView")
    //                            {
    //                                //item.poseMeta = item.poseMeta.Replace("ViewIDsrt", item.title);
    //                                //
    //                                if (datamodel.chunkList != null)
    //                                {
    //                                    itemParent dlst = datamodel.chunkList.SingleOrDefault(x => x.name == item.title);

    //                                    List<recycleDataMapVM> mylist = JsonConvert.DeserializeObject<List<recycleDataMapVM>>("[" + myresult.cycleMeta + "]");
    //                                    List<Dictionary<string, object>> finaldatalist = new List<Dictionary<string, object>>();


    //                                    if (dlst != null)
    //                                    {
    //                                        for (int i = 0; i < dlst.items.Count(); i++)
    //                                        {

    //                                            Dictionary<string, object> iii = new Dictionary<string, object>();
    //                                            iii.Add("patternId", "patternId1");
    //                                            if (dlst.items[i].GetType().GetProperty("actions") != null)
    //                                            {
    //                                                iii.Add("onClick", dlst.items[i].GetType().GetProperty("actions").GetValue(dlst.items[i], null));
    //                                            }

    //                                            foreach (var cycleM in mylist)
    //                                            {
    //                                                var dd = dlst.items[i];
    //                                                flowDetailAll flowDetail = dlst.items[i] as flowDetailAll;
    //                                                if (flowDetail != null)
    //                                                {
    //                                                    //speciality_textsrt
    //                                                    //speciality_textsrt
    //                                                    if (flowDetail.allData.ContainsKey(cycleM.dataProperty))
    //                                                    {
    //                                                        if (!iii.ContainsKey(cycleM.dataProperty))
    //                                                        {
    //                                                            iii.Add(cycleM.dataProperty, flowDetail.allData[cycleM.dataProperty]);
    //                                                        }

    //                                                    }
    //                                                    else
    //                                                    {
    //                                                        iii.Add(cycleM.dataProperty, "");
    //                                                    }
    //                                                }
    //                                                else
    //                                                {
                                                        
    //                                                    string vll = dd.GetType().GetProperty(cycleM.dataProperty).GetValue(dd, null) == null ? "" : dd.GetType().GetProperty(cycleM.dataProperty).GetValue(dd, null).ToString();
    //                                                    iii.Add(cycleM.dataProperty, vll);
    //                                                }


    //                                            }
    //                                            finaldatalist.Add(iii);




    //                                        }
    //                                    }
    //                                    string srtt = JsonConvert.SerializeObject(finaldatalist).Trim(',');
    //                                    item.appMeta = item.appMeta.Replace("dataitemsstring", JsonConvert.SerializeObject(finaldatalist).Trim(','));
    //                                    item.appMeta = item.appMeta.Replace("dataMapString", myresult.cycleMeta.Trim(','));
    //                                }
    //                                else
    //                                {
    //                                    item.appMeta = item.appMeta.Replace("dataitemsstring", "[]");
    //                                    item.appMeta = item.appMeta.Replace("dataMapString", "");

    //                                }
    //                                item.appMeta = item.appMeta.Replace("viewMetaIDsrt", item.title);


    //                            }
    //                            if (!HtmlItems.ContainsKey(item.title))
    //                            {
    //                                HtmlItems["childMetaString"] += item.appMeta.Trim(',') + ",";
    //                            }
    //                            else
    //                            {
    //                                HtmlItems[item.title] += item.appMeta.Trim(',');
    //                            }
    //                        }

    //                        //finalHtml += item.appMeta + ",";

    //                    }

    //                }

    //            }


    //            modelResponce.newMeta = HtmlItems;
    //            modelResponce.newPose = finalPose;
    //            modelResponce.list = response;
    //            modelResponce.cycleMeta = finalCycleFields;
    //            modelResponce.stackPose = finalStackPose;
    //        }





    //        return modelResponce;
    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<streamModel> getStream()
    //    {
    //        object someObject;
    //        object Userp;
    //        Request.Properties.TryGetValue("UserToken", out someObject);

    //        // Instantiate your Stream client factory using the API key and secret
    //        // the secret is only used server side and gives you full access to the API.

    //        var factory = new StreamClientFactory("uk93sxysc2jg", "q236gwsgtmdpz5zgx68skegmzq7ekjuunsj8zestgyppfs9vtcm396e9jzjpv34w");
    //        var userClient = factory.GetUserClient();
    //        var token = userClient.CreateToken(someObject.ToString());
    //        // Or with an expiration:

    //        string mytoken = userClient.CreateToken(someObject.ToString(), DateTimeOffset.UtcNow.AddHours(1));

    //        Guid userguid = new Guid(someObject.ToString());
    //        callVM response = new callVM()
    //        {
    //            api = "uk93sxysc2jg",
    //            callUserID = someObject.ToString(),
    //            token = mytoken
    //        };
    //        //using (Context dbcontext = new Context())
    //        //{
    //        //    user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userguid);
    //        //    user.
    //        //}
    //        streamModel model = new streamModel()
    //        {
    //            code = 0,
    //            result = response
    //        };
    //        return model;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<appPageSectionVM> getAppURL([FromBody] getURLVM model)

    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        bool ifcontiniu = await checktoken(model, someObject);
    //        if (!ifcontiniu)
    //        {
    //            model.slug = "app/loginPage";
    //        }

    //        model.userID = someObject != null ? someObject.ToString() : "";

    //        viewVM data = await getData(model);

    //        Dictionary<string, string> initdata = new Dictionary<string, string>();
    //        initdata = await setInitData(model);



    //        appPageSectionVM finalResult = new appPageSectionVM();
    //        pageSectionVM response = new pageSectionVM();
    //        try
    //        {



    //            model.slug = model.slug == null ? "" : model.slug;
    //            using (Context dbcontext = new Context())
    //            {
    //                model.lang = string.IsNullOrEmpty(model.lang) ? "En" : model.lang;
    //                language lng = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.lang);
    //                //Include(x => x.Contents.Select(l => l.HTML)).Include(x => x.Contents.Select(y => y.Datas)).Include(x => x.Contents.Select(y => y.childContent)).Include(x => x.Contents.Select(y => y.childContent.Select(z => z.Datas)))

    //                var responseList = await dbcontext.sections.Include(x => x.SectionLayout).Include(x => x.Metas).Where(x => x.url == model.slug && x.languageID == lng.languageID).Select(x => new pageSectionVM { sectionID = x.sectionID, Metas = x.Metas.Select(p => new MetaVM { Name = p.name, Content = p.content }).ToList(), date = x.date, title = x.title, image = x.image, url = x.url, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
    //                response = responseList.First();


    //                var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == response.sectionLayoutID).Select(x => new getsectionLayoutVM { menuTitle = x.menuTitle, title = x.Layout.name, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.typeName, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { layoutDataID = m.layoutDataID, parentID = m.parentID == null ? null : m.parentID, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).OrderBy(m => m.priority).ToList() }).ToList() }).ToListAsync();


    //                response.layoutModel = list.First();
    //                Dictionary<string, string> hitems = new Dictionary<string, string>();
    //                hitems.Add("childMetaString", "");
    //                getChildContentVM myresult = await getChildContent(response.sectionID, null, data, hitems);
    //                response.Contents = myresult.list;
    //                JAResult rslt = new JAResult()
    //                {
    //                    page = response.Contents.First().appMeta,
    //                    initData = initdata,
    //                };

    //                finalResult.code = 0;

    //                finalResult.result = rslt;
    //                //foreach (var item in response.Contents)
    //                //{
    //                //    if (item.typeID != new Guid("00000000-0000-0000-0000-000000000000") && item.typeID != null)
    //                //    {
    //                //        item.childList = await dbcontext.sections.Include(x => x.Category).Where(x => x.sectionTypeID == item.typeID).Select(x => new sectionVM { buttonText = x.buttonText, categoryName = x.Category.title, title = x.title, description = x.description, metaTitle = x.metatitle, image = x.image, writer = x.writer, date = x.date, url = x.url }).ToListAsync();
    //                //    }
    //                //}
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            throw;
    //        }
    //        return finalResult;
    //    }
    //    private string removeUnwanted(string finalResult)
    //    {

    //        return finalResult;
    //    }
    //    private async Task<bool> checktoken(getURLVM model, object userID)
    //    {
    //        bool cont = true;
    //        List<string> srtlist = new List<string>();
    //        srtlist.Add("app/showNewProfile");
    //        srtlist.Add("app/clientAddedProfileList");
    //        srtlist.Add("app/payeshPage");
    //        srtlist.Add("app/clientDashboard");
    //        if (srtlist.Contains(model.slug))
    //        {
    //            if (userID == null)
    //            {
    //                cont = false;
    //            }
    //        }
    //        return cont;
    //    }
    //    private async Task<Dictionary<string, string>> setInitData(getURLVM model)
    //    {
    //        Dictionary<string, string> initdata = new Dictionary<string, string>();


    //        if (model.data != null)
    //        {
    //            if (model.data.ContainsKey("flowID"))
    //            {
    //                initdata.Add("flowID", model.data["flowID"]);
    //            }
    //        }


    //        else if (model.slug == "app/requestFormSetNewFLow")
    //        {
    //            initdata.Add("orderID", model.data["orderID"]);
    //        }
    //        else if (model.slug == "app/setFormByClient")
    //        {

    //            using (Context dbcontext = new Context())
    //            {
    //                int flowID = Int32.Parse(model.data["flowID"]);
    //                newOrderFlow selectedFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                initdata.Add("orderID", selectedFlow.newOrderID.ToString());

    //                initdata.Add("processID", selectedFlow.processID.ToString());
    //            }

    //        }
    //        return initdata;
    //    }
    //    private async Task<viewVM> getData([FromBody] getURLVM model)
    //    {
    //        //main/chart/
    //        viewVM rsp = new viewVM();
    //        List<parent> parentlist = new List<parent>();
    //        List<parent> dynamiclistParent = new List<parent>();
    //        itemParent cycle0 = new itemParent() // برای همه
    //        {
    //            name = "main",
    //        };
    //        itemParent dynamicParent = new itemParent() // برای همه
    //        {
    //            name = "dynamicField",
    //        };
    //        List<itemParent> dybmaicList = new List<itemParent>();
    //        List<itemParent> lst0 = new List<itemParent>();
    //        flowDetailAll allitemsDynamic = new flowDetailAll();
    //        Dictionary<string, string> allDataDynamic = new Dictionary<string, string>();
    //        using (Context dbcontext = new Context())
    //        {


    //            try
    //            {
    //                List<newOrderFlow> allflow = await dbcontext.newOrderFlows.ToListAsync();
    //                List<urlData> urlDatas = await dbcontext.urlDatas.Include(x => x.section).Where(x => x.section.url == model.slug).ToListAsync();
    //                // گرفتن داده های مرتبط با اون فلو ها  و افزودن paret
    //                if (urlDatas != null)
    //                {
    //                    if (urlDatas.Count() > 0)
    //                    {
    //                        string sUserID = model.userID;
    //                        int flowID = 0;
    //                        string thirdID = "";

    //                        if (model.data != null)
    //                        {
    //                            if (model.data.ContainsKey("flowID"))
    //                            {
    //                                flowID = Int32.Parse(model.data["flowID"]);
    //                            }
    //                            if (model.data.ContainsKey("thirdID"))
    //                            {
    //                                thirdID = model.data["thirdID"];
    //                            }
    //                        }
    //                        if (model.data != null)
    //                        {
    //                            if (model.data.ContainsKey("userToken"))
    //                            {
    //                                sUserID = model.data["userToken"];
    //                            }
    //                        }
    //                        List<itemParent> flowParentlstTest = new List<itemParent>();

    //                        foreach (var item in urlDatas.Where(x => x.isCycle == 0))
    //                        {
    //                            // ار کجا بفهمیم کل اطلاعاتو میخواد
    //                            // ار کجا بفهمیم میخواد اطلاعاتیو حساب کنه به ما بده
    //                            // اگر operats null بود  
    //                            // باید یک چیزی رو از یک فرم خاصی حساب کنه به ما بده
    //                            // وگرنه باید اطلاعات اون فرم رو برای ما بیاره
    //                            // میتونیم main , flowID رو جدا کنیم

    //                        }
    //                        urlData flowParent = urlDatas.SingleOrDefault(x => x.name == "flowID");
    //                        if (flowParent != null)
    //                        {
    //                            if (model.data.ContainsKey("flowID"))
    //                            {
    //                                flowDetailAll allitems = await getDataFromFlowDetaialGeneral(sUserID, Int32.Parse(model.data["flowID"]), 0, dbcontext);
    //                                parentlist.Add(allitems);

    //                                cycle0.items = parentlist;
    //                                lst0.Add(cycle0);
    //                                rsp.chunkList = lst0;
    //                            }
    //                        }
    //                        urlData flowMain = urlDatas.SingleOrDefault(x => x.name == "main"); //اگر میخواهیم از اطلاعات خود کاربر استفاده کنیم باید داخل صفحه فیلدهای کاربر با اولین کلمه مین را درست کنیم
    //                        if (flowMain != null)
    //                        {

    //                            flowDetailAll allitems = await getDataFromFlowDetaialGeneral(sUserID, 0, 0, dbcontext);
    //                            foreach (var item in allitems.allData)
    //                            {
    //                                if (item.Key == "image")
    //                                {
    //                                    allDataDynamic.Add("main_" + item.Key + "_srcsrt", item.Value);
    //                                }
    //                                else
    //                                {
    //                                    allDataDynamic.Add("main_" + item.Key + "_textsrt", item.Value);
    //                                }

    //                            }
    //                        }
    //                        urlData userMain = urlDatas.SingleOrDefault(x => x.name == "userMain"); //اگر میخواهیم از اطلاعات خود کاربر استفاده کنیم باید داخل صفحه فیلدهای کاربر با اولین کلمه مین را درست کنیم
    //                        if (userMain != null)
    //                        {
    //                            flowDetailAll allitems = await getDataFromFlowDetaialGeneral(sUserID, Int32.Parse(model.data["flowID"]), 1, dbcontext);
    //                            foreach (var item in allitems.allData)
    //                            {
    //                                if (item.Key == "image")
    //                                {
    //                                    allDataDynamic.Add("userFlow_" + item.Key + "_srcsrt", item.Value);
    //                                }
    //                                else
    //                                {
    //                                    allDataDynamic.Add("userFlow_" + item.Key + "_textsrt", item.Value);
    //                                }

    //                            }
    //                        }
    //                        // تا اینجا دینامیک دیتا ایجاد می شود

    //                        foreach (var item in urlDatas.Where(x => x.isCycle == 1))
    //                        {
    //                            List<parent> parentlistTest = new List<parent>();
    //                            List<flowDetailAll> list = new List<flowDetailAll>();
    //                            if (model.data != null)
    //                            {
    //                                if (model.data.ContainsKey("flows"))// این حالت برای پیج های تک لیستی از آیتم هاست که لیست فلو از سرچ میاد
    //                                {

    //                                    List<int> flows = string.IsNullOrEmpty(model.data["flows"]) ? new List<int>() : model.data["flows"].Split(',').Select(x => Int32.Parse(x)).ToList();// new List<int>();
    //                                    list = await getDataFlowGenral(flows, item);
    //                                }
    //                                else
    //                                {
    //                                    list = await getDataFromFlowGeneral(sUserID, item, flowID, thirdID);
    //                                }
    //                            }
    //                            else
    //                            {
    //                                list = await getDataFromFlowGeneral(sUserID, item, flowID, thirdID);
    //                            }
    //                            //فلو هایی که قرار است از توش دیتا دراد داخل خود متود پیدا میشن
    //                            if (model.slug == "app/homePageClient")
    //                            {
    //                                if (model.data == null)
    //                                {
    //                                    Dictionary<string, string> data = new Dictionary<string, string>();
    //                                    model.data = data;
    //                                }
    //                                model.data.Add("next", "doctorListHomePageCycleView#go*a.go*app/doctorDetail");
    //                            }
    //                            if (model.slug == "app/clientPayeshList")
    //                            {
    //                                if (model.data == null)
    //                                {
    //                                    Dictionary<string, string> data = new Dictionary<string, string>();
    //                                    model.data = data;
    //                                }
    //                                else
    //                                {
    //                                    if (model.data.ContainsKey("next"))
    //                                    {
    //                                        model.data["next"] = "payeshReminder#putVar*formType*3_putVar*reload*app/clientPayeshList_go*a.go*app/dynamicFormAssess";

    //                                    }
    //                                    else
    //                                    {
    //                                        model.data.Add("next", "payeshReminder#putVar*formType*3_putVar*reload*app/clientPayeshList_go*a.go*app/dynamicFormAssess");

    //                                    }

    //                                }
    //                            }
    //                            else if (model.slug == "app/homePageDoctor")
    //                            {
    //                                if (model.data == null)
    //                                {
    //                                    Dictionary<string, string> data = new Dictionary<string, string>();
    //                                    model.data = data;
    //                                }
    //                                else
    //                                {
    //                                    if (model.data.ContainsKey("next"))
    //                                    {
    //                                        model.data["next"] = "payeshHomeCycleForDoctor#go*a.go*app/doctorPatientInfo";

    //                                    }
    //                                    else
    //                                    {
    //                                        model.data.Add("next", "payeshHomeCycleForDoctor#go*a.go*app/doctorPatientInfo");

    //                                    }
    //                                }
    //                            }
    //                            else if (model.slug == "app/donePageDoctor")
    //                            {
    //                                if (model.data == null)
    //                                {
    //                                    Dictionary<string, string> data = new Dictionary<string, string>();
    //                                    model.data = data;
    //                                }
    //                                model.data.Add("next", "payeshCycleForDoctor#go*a.go*app/doctorPatientInfo");
    //                            }
    //                            else if (model.slug == "app/donPageMedium")
    //                            {
    //                                if (model.data == null)
    //                                {
    //                                    Dictionary<string, string> data = new Dictionary<string, string>();
    //                                    model.data = data;
    //                                }
    //                                model.data.Add("next", "payeshCycleForMediumDone#go*a.go*app/mediumPatientInfo");
    //                            }
    //                            foreach (var item0 in list)
    //                            {
    //                                if (model.data != null)
    //                                {

    //                                    if (model.data.ContainsKey("next"))
    //                                    {
    //                                        List<actionResonse> actionList = new List<actionResonse>();
    //                                        actionResonse action1 = new actionResonse()
    //                                        {
    //                                            type = "a.putVar",
    //                                            varName = "flowID",
    //                                            value = item0.allData["ID"]
    //                                        };
    //                                        actionList.Add(action1);
    //                                        string nexturl = model.data["next"];

    //                                        foreach (string url in nexturl.Trim(';').Split(';').ToList())
    //                                        {
    //                                            var nextList = url.Trim('#').Split('#').ToList();
    //                                            if (nextList[0] == item.name)
    //                                            {
    //                                                foreach (var initdata in nextList[1].Split('_').ToList())
    //                                                {
    //                                                    List<string> initDataSecList = initdata.Split('*').ToList();

    //                                                    if (initDataSecList[0] == "removeVar")
    //                                                    {
    //                                                        string putVarName = initDataSecList[1];

    //                                                        actionResonse action2 = new actionResonse()
    //                                                        {
    //                                                            type = "a.removeVar",
    //                                                            varName = initDataSecList[2],
    //                                                        };
    //                                                        actionList.Add(action2);
    //                                                    }
    //                                                    else if (initDataSecList[0] == "putVar")
    //                                                    {

    //                                                        string putVarName = initDataSecList[1];
    //                                                        string putVarValue = initDataSecList[2];
    //                                                        if (item0.allData.ContainsKey(putVarName + "_valuesrt"))
    //                                                        {
    //                                                            putVarValue = item0.allData[putVarName + "_valuesrt"];
    //                                                        }
    //                                                        actionResonse action2 = new actionResonse()
    //                                                        {
    //                                                            type = "a.putVar",
    //                                                            varName = initDataSecList[1],
    //                                                            value = putVarValue,
    //                                                        };
    //                                                        actionList.Add(action2);
    //                                                    }
    //                                                    else if (initDataSecList[0] == "tab")
    //                                                    {
    //                                                        actionResonse action2 = new actionResonse()
    //                                                        {
    //                                                            type = initDataSecList[1],
    //                                                            to = initDataSecList[2],
    //                                                        };
    //                                                        actionList.Add(action2);
    //                                                    }
    //                                                    else if (initDataSecList[0] == "go")
    //                                                    {
    //                                                        actionResonse action2 = new actionResonse()
    //                                                        {
    //                                                            type = initDataSecList[1],
    //                                                            to = initDataSecList[2],
    //                                                        };
    //                                                        actionList.Add(action2);
    //                                                    }



    //                                                }

    //                                            }

    //                                        }

    //                                        item0.actions = actionList;
    //                                    }
    //                                }


    //                                parentlistTest.Add(item0);
    //                            }
    //                            itemParent flowCycle = new itemParent()
    //                            {
    //                                name = item.name,
    //                                items = parentlistTest
    //                            };
    //                            lst0.Add(flowCycle);
    //                        }
    //                        rsp.chunkList = lst0;
    //                    }

    //                }
    //                if (model.slug == "app/notif")
    //                {
    //                    await sendNotif("2", "", "فرم ارزیابی جدیدی ثبت شده است", "reload", "app/homePageMedium");
    //                }
    //                if (model.slug == "app/verificationPopup")
    //                {
    //                    if (model.data.ContainsKey("submit"))
    //                    {
    //                        string submit = model.data["submit"];
    //                        allDataDynamic.Add("submit_tosrt", submit);
    //                    }
    //                    if (model.data.ContainsKey("label"))
    //                    {
    //                        string message = model.data["label"];
    //                        allDataDynamic.Add("label_textsrt", message);
    //                    }
    //                    //if (model.data.ContainsKey("status"))
    //                    //{
    //                    //    string status = model.data["status"];
    //                    //    allDataDynamic.Add("status_valuesrt", status);
    //                    //}
    //                    //if (model.data.ContainsKey("label"))
    //                    //{
    //                    //    string label = model.data["label"];
    //                    //    allDataDynamic.Add("label_textsrt", label);
    //                    //}

    //                    //if (model.data.ContainsKey("reload"))
    //                    //{
    //                    //    string reload = model.data["reload"];
    //                    //    allDataDynamic.Add("reload_valuesrt", reload);
    //                    //}
    //                    //if (model.data.ContainsKey("go"))
    //                    //{
    //                    //    string go = model.data["go"];
    //                    //    allDataDynamic.Add("go_valuesrt", go);
    //                    //}
    //                    //if (model.data.ContainsKey("formType"))
    //                    //{
    //                    //    string formType = model.data["formType"];
    //                    //    allDataDynamic.Add("formType_valuesrt", formType);
    //                    //}

    //                    // همه این آیتم ها باید در این صفحه وجود داشته باشند که یا پر شوند یا نه
    //                }
    //                if (model.slug.Contains("dynamicForm"))
    //                {


    //                    if (model.data.ContainsKey("nextFormType"))

    //                    {
    //                        string nextFormType = model.data["nextFormType"];
    //                        allDataDynamic.Add("formType_valuesrt", nextFormType);
    //                    }


    //                    // در اینجا وریشن های دکمه سابمیت فرم داینامیک ست میشود 
    //                    // این وریشن های در خود سابمیت تعریف شده اند
    //                    // و در اینجا از متغیرهای دیتا که از صفحه قبل میاد پر میشن

    //                    int flowID = Int32.Parse(model.data["flowID"]);
    //                    newOrderFlow sflow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    int formType = Int32.Parse(model.data["formType"]);
    //                    var formIDRow = await dbcontext.forms.SingleOrDefaultAsync(x => x.formTypeID == formType && x.userID == sflow.userID);


    //                    List<formItemList> showForm = await getFormDataFromForm(formIDRow.formID);
    //                    showFormAllVM formModel = new showFormAllVM()
    //                    {
    //                        name = "dynamicForm",
    //                        allForm = showForm
    //                    };
    //                    parentlist.Add(formModel);
    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    //lst0.SingleOrDefault(x => x.name == "main").items.Add(formModel);



    //                }
    //                if (model.slug.Contains("StaticForm"))
    //                {


    //                    if (model.data.ContainsKey("nextFormType"))

    //                    {
    //                        string nextFormType = model.data["nextFormType"];
    //                        allDataDynamic.Add("formType_valuesrt", nextFormType);
    //                    }

    //                    int formID = Int32.Parse(model.data["formType"]);


    //                    List<formItemList> showForm = await getFormDataFromForm(formID);
    //                    showFormAllVM formModel = new showFormAllVM()
    //                    {
    //                        name = "staticForm",
    //                        allForm = showForm
    //                    };
    //                    parentlist.Add(formModel);

    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                }
    //                if (model.slug == "app/showDynamicForm")
    //                {
    //                    object someObject;
    //                    Request.Properties.TryGetValue("UserToken", out someObject);
    //                    string flowString = model.data["flowID"];
    //                    showFormInputVM fmodel = new showFormInputVM()
    //                    {
    //                        flowID = Int32.Parse(flowString),
    //                    };

    //                    if (someObject != null)
    //                    {
    //                        List<formItemList> showForm = await getFormItems(fmodel);
    //                        showFormAllVM formModel = new showFormAllVM()
    //                        {
    //                            name = "showFormMain",
    //                            allForm = showForm
    //                        };
    //                        parentlist.Add(formModel);
    //                    }
    //                    setNewFlowForm info = new setNewFlowForm();
    //                    info.flowForm = flowString;
    //                    parentlist.Add(info);

    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                // putting All DynamicFields

    //                // health
    //                if (model.slug == "app/showNewProfile")
    //                {
    //                    object userPhone;
    //                    Request.Properties.TryGetValue("Userp", out userPhone);
    //                    string orderID = model.data["orderID"];

    //                    int flowString = await getNewProfileFLowFromOrder(orderID, userPhone.ToString());
    //                    showFormInputVM fmodel = new showFormInputVM()
    //                    {
    //                        flowID = flowString,
    //                    };

    //                    List<formItemList> showForm = await getFormItems(fmodel);
    //                    showFormAllVM formModel = new showFormAllVM()
    //                    {
    //                        name = "showNewProfForm",
    //                        allForm = showForm
    //                    };

    //                    parentlist.Add(formModel);
    //                    setNewFlowForm info = new setNewFlowForm();
    //                    info.flowForm = flowString.ToString();
    //                    parentlist.Add(info);

    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/doctorPatientInfo")
    //                {
    //                    object userOBJID;
    //                    Request.Properties.TryGetValue("UserToken", out userOBJID);
    //                    Guid userID = new Guid(userOBJID.ToString());
    //                    int FlowID = Int32.Parse(model.data["flowID"]);
    //                    newOrderFlow payeshFLow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == FlowID);

    //                    List<int> userPayeshFlows = await dbcontext.newOrderFlows.Where(x => x.userID == payeshFLow.userID && x.formID == payeshFLow.formID).Select(x => x.newOrderFlowID).ToListAsync();
    //                    List<formItemVM> formItem = await dbcontext.formItems.Where(x => x.formID == payeshFLow.formID).Select(x => new formItemVM { formItemID = x.formItemID, itemName = x.itemName }).ToListAsync();

    //                    List<chartList> chartList = await getLineChartData(model, formItem, userPayeshFlows);
    //                    itemParent lineChartParent = new itemParent() // برای همه
    //                    {
    //                        name = "lineChart",
    //                    };
    //                    List<parent> lineChartParentlist = new List<parent>();

    //                    showChartAllVM formModel = new showChartAllVM()
    //                    {
    //                        name = "dynamicChart",
    //                        allChart = chartList
    //                    };

    //                    lineChartParentlist.Add(formModel);
    //                    lineChartParent.items = lineChartParentlist;
    //                    lst0.Add(lineChartParent);

    //                    flowRelation relation = await dbcontext.flowRelations.Include(x => x.parentFlow).Include(x => x.parentFlow.NewOrderFields).OrderByDescending(x => x.flowRelationID).FirstOrDefaultAsync(x => x.childID == payeshFLow.newOrderFlowID && x.formID == 29);

    //                    string mediumString = "";
    //                    if (relation != null)
    //                    {
    //                        if (relation.parentFlow.NewOrderFields != null)
    //                        {
    //                            var descc = relation.parentFlow.NewOrderFields.SingleOrDefault(x => x.name == "description");

    //                            if (descc != null)
    //                            {
    //                                mediumString = descc.valueString;
    //                            }
    //                        }
    //                    }


    //                    allDataDynamic.Add("mediumDescription_textsrt", mediumString);
    //                    allDataDynamic.Add("userToken_valuesrt", payeshFLow.userID.ToString());
    //                    allDataDynamic.Add("relation_valuesrt", FlowID.ToString());
    //                    allitemsDynamic.allData = allDataDynamic;
    //                    dynamiclistParent.Add(allitemsDynamic);


    //                }
    //                else if (model.slug == "app/mediumPatientInfo")
    //                {
    //                    object userOBJID;
    //                    Request.Properties.TryGetValue("UserToken", out userOBJID);
    //                    Guid userID = new Guid(userOBJID.ToString());
    //                    int FlowID = Int32.Parse(model.data["flowID"]);
    //                    newOrderFlow payeshFLow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == FlowID);

    //                    List<int> userPayeshFlows = await dbcontext.newOrderFlows.Where(x => x.userID == payeshFLow.userID && x.formID == payeshFLow.formID).Select(x => x.newOrderFlowID).ToListAsync();
    //                    List<formItemVM> formItem = await dbcontext.formItems.Where(x => x.formID == payeshFLow.formID).Select(x => new formItemVM { formItemID = x.formItemID, itemName = x.itemName }).ToListAsync();

    //                    List<chartList> chartList = await getLineChartData(model, formItem, userPayeshFlows);
    //                    itemParent lineChartParent = new itemParent() // برای همه
    //                    {
    //                        name = "lineChart",
    //                    };
    //                    List<parent> lineChartParentlist = new List<parent>();

    //                    showChartAllVM formModel = new showChartAllVM()
    //                    {
    //                        name = "dynamicChart",
    //                        allChart = chartList
    //                    };

    //                    lineChartParentlist.Add(formModel);
    //                    lineChartParent.items = lineChartParentlist;
    //                    lst0.Add(lineChartParent);

    //                    flowRelation relation = await dbcontext.flowRelations.Include(x => x.parentFlow).Include(x => x.parentFlow.NewOrderFields).OrderByDescending(x => x.flowRelationID).FirstOrDefaultAsync(x => x.childID == payeshFLow.newOrderFlowID && x.formID == 29);

    //                    string mediumString = "";
    //                    if (relation != null)
    //                    {
    //                        if (relation.parentFlow.NewOrderFields != null)
    //                        {
    //                            var descc = relation.parentFlow.NewOrderFields.SingleOrDefault(x => x.name == "description");

    //                            if (descc != null)
    //                            {
    //                                mediumString = descc.valueString;
    //                            }
    //                        }
    //                    }


    //                    allDataDynamic.Add("mediumDescription_textsrt", mediumString);
    //                    allDataDynamic.Add("userToken_valuesrt", payeshFLow.userID.ToString());
    //                    allDataDynamic.Add("relation_valuesrt", FlowID.ToString());
    //                    allitemsDynamic.allData = allDataDynamic;
    //                    dynamiclistParent.Add(allitemsDynamic);


    //                }
    //                else if (model.slug == "app/clientDashboard")
    //                {



    //                    flowDetailAll allitems = new flowDetailAll();
    //                    Dictionary<string, string> allData = new Dictionary<string, string>();
    //                    allDataDynamic.Add("doctorSpecificConstraintView_visibilitysrt", "0");
    //                    allDataDynamic.Add("doctorSpecificStack_visibilitysrt", "0");
    //                    allDataDynamic.Add("currentDateLabel_textsrt", dateTimeConvert.ToPersianDateString(DateTime.Now));



    //                    if (model.data != null)
    //                    {
    //                        if (model.data.ContainsKey("flowID"))
    //                        {


    //                            allDataDynamic["doctorSpecificConstraintView_visibilitysrt"] = "1";
    //                            allDataDynamic["doctorSpecificStack_visibilitysrt"] = "1";


    //                        }
    //                    }

    //                    if (model.data.ContainsKey("flowID"))
    //                    {
    //                        object userOBJID;
    //                        Request.Properties.TryGetValue("UserToken", out userOBJID);
    //                        Guid userID = new Guid(userOBJID.ToString());
    //                        int FlowID = Int32.Parse(model.data["flowID"]);
    //                        newOrderFlow docFLow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == FlowID);
    //                        form docForm = await dbcontext.forms.SingleOrDefaultAsync(x => x.userID == docFLow.userID && x.formTypeID == 3);

    //                        List<int> userPayeshFlows = await dbcontext.newOrderFlows.Where(x => x.userID == userID && x.formID == docForm.formID).Select(x => x.newOrderFlowID).ToListAsync();
    //                        List<formItemVM> formItem = await dbcontext.formItems.Where(x => x.formID == docForm.formID).Select(x => new formItemVM { formItemID = x.formItemID, itemName = x.itemName }).ToListAsync();

    //                        List<chartList> chartList = await getLineChartData(model, formItem, userPayeshFlows);
    //                        itemParent lineChartParent = new itemParent() // برای همه
    //                        {
    //                            name = "lineChart",
    //                        };
    //                        List<parent> lineChartParentlist = new List<parent>();

    //                        showChartAllVM formModel = new showChartAllVM()
    //                        {
    //                            name = "dynamicChart",
    //                            allChart = chartList
    //                        };

    //                        lineChartParentlist.Add(formModel);
    //                        lineChartParent.items = lineChartParentlist;
    //                        lst0.Add(lineChartParent);
    //                    }

    //                };


    //                allitemsDynamic.allData = allDataDynamic;
    //                dynamiclistParent.Add(allitemsDynamic);

    //                dynamicParent.items = dynamiclistParent;
    //                lst0.Add(dynamicParent);
    //                rsp.chunkList = lst0;


    //                /// iggTailor
    //                if (model.slug == "app/showForm")
    //                {
    //                    object someObject;
    //                    Request.Properties.TryGetValue("UserToken", out someObject);
    //                    string flowString = model.data["flowID"];
    //                    showFormInputVM fmodel = new showFormInputVM()
    //                    {
    //                        flowID = Int32.Parse(flowString),
    //                    };
                        
    //                    if (someObject != null)
    //                    {
    //                        List<formItemList> showForm = await getFormItems(fmodel);
    //                        showFormAllVM formModel = new showFormAllVM()
    //                        {
    //                            name = "showFormMain",
    //                            allForm = showForm
    //                        };
    //                        parentlist.Add(formModel);
    //                    }
    //                    setNewFlowForm info = new setNewFlowForm();
    //                    info.flowForm = flowString;
    //                    parentlist.Add(info);

    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/managerProfile")
    //                {
    //                    profileVM info = new profileVM();
    //                    info = await getUserInfoHandler(model.userID, dbcontext);

    //                    parentlist.Add(info);
    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/setFormByClient")
    //                {
    //                    string flowId = model.data["flowID"];
    //                    setNewFlowForm info = new setNewFlowForm();
    //                    info.flowForm = flowId;

    //                    parentlist.Add(info);
    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/requestFormSetNewFLow")
    //                {
    //                    string orderid = model.data["orderID"];
    //                    parentlist = new List<parent>();
    //                    newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    List<orderOptionVM> serventList = await dbcontext.users.Where(x => x.barbariID != null).Select(x => new orderOptionVM { title = x.phone, orderOptionID = x.userID }).ToListAsync();
    //                    formOptionObject orderOBJ = new formOptionObject()
    //                    {
    //                        name = "serventList",
    //                        lst = serventList
    //                    };
    //                    parentlist.Add(orderOBJ);
    //                    List<orderOptionVM> processList = await dbcontext.processes.Select(x => new orderOptionVM { title = x.title, orderOptionID = x.processID }).ToListAsync();
    //                    orderOBJ = new formOptionObject()
    //                    {
    //                        name = "processList",
    //                        lst = processList
    //                    };
    //                    parentlist.Add(orderOBJ);


    //                    cycle0.items = parentlist;
    //                    cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/getOrderFlowManager")
    //                {
    //                    string Guidstring = model.data["orderID"];
    //                    Guid selectedOrderID = new Guid(Guidstring);
    //                    List<managerFlowList_orderFlowCycle> flowlist = await dbcontext.newOrderFlows.Where(x => x.newOrderID == selectedOrderID).OrderByDescending(x => x.creationDate).Select(x => new managerFlowList_orderFlowCycle { flowStatus_valueColorsrt = x.isFinished == "1" ? "cGreen" : "cRed", flowStatus_valueTextsrt = x.isFinished == "1" ? "Finished" : "In Process", isAccespted = x.isAccepted, /*orderName_valueTextsrt = x.NewOrder.orderName,*/ processName_valueTextsrt = x.newOrderProcess.title, serventName_valueTextsrt = x.newOrderFlowServent != null ? x.newOrderFlowServent.phone : "", FlowID = x.newOrderFlowID.ToString() }).ToListAsync();


    //                    parentlist = new List<parent>();
    //                    foreach (var item in flowlist)
    //                    {
    //                        switch (item.isAccespted)
    //                        {

    //                            case ("1"):
    //                                item.flowIsAccepted_valueTextsrt = "Accepted";
    //                                item.flowIsAccepted_valueColorsrt = "cGreen";
    //                                break;
    //                            case ("2"):
    //                                item.flowIsAccepted_valueTextsrt = "Rejected";
    //                                item.flowIsAccepted_valueColorsrt = "cRed";
    //                                break;
    //                            default:
    //                                item.flowIsAccepted_valueTextsrt = "Pending";
    //                                item.flowIsAccepted_valueColorsrt = "cGray";
    //                                break;

    //                        }
    //                        List<actionResonse> actionList = new List<actionResonse>();
    //                        actionResonse action1 = new actionResonse()
    //                        {
    //                            type = "a.putVar",
    //                            varName = "flowID",
    //                            value = item.FlowID
    //                        };
    //                        actionList.Add(action1);


    //                        actionResonse action2 = new actionResonse()
    //                        {
    //                            type = "a.go",
    //                            to = "app/showForm",
    //                            value = item.FlowID
    //                        };
    //                        actionList.Add(action2);
    //                        item.actions = actionList;
    //                        parentlist.Add(item);
    //                    }
    //                    itemParent flowCycle = new itemParent()
    //                    {
    //                        name = "orderFlowCycle",
    //                        items = parentlist
    //                    };

    //                    List<itemParent> flowParentlst = new List<itemParent>();
    //                    flowParentlst.Add(flowCycle);
    //                    rsp.chunkList = flowParentlst;
    //                }
    //                else if (model.slug == "app/getOrderListManager")
    //                {
    //                    string toDate = "";
    //                    string fromDate = "";
    //                    string search = "";
    //                    if (model.data != null)
    //                    {
    //                        foreach (var item in model.data)
    //                        {
    //                            if (item.Key == "toDate")
    //                            {
    //                                toDate = item.Value;
    //                            }
    //                            if (item.Key == "fromDate")
    //                            {
    //                                fromDate = item.Value;
    //                            }
    //                            if (item.Key == "search")
    //                            {
    //                                search = item.Value;
    //                            }
    //                        }
    //                    }

    //                    List<cycleStackView_orderListManagerVM> cyclelist = await dbcontext.NewOrders.Include(x => x.newOrderStatus).Select(x => new cycleStackView_orderListManagerVM { setFlow_orderListManager_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/requestFormSetNewFLow\"}]", setFlow_orderListManager_visibilitysrt = x.newOrderStatus.statusCode == "1" ? "1" : "0", orderStatus_valueTextsrt = x.newOrderStatus.title, orderStatus_valueColorsrt = x.newOrderStatus.statusCode == "1" ? "cRed" : "cGreen", projectName_orderListManager_valueTextsrt = x.orderName, orderDate_orderListManager_valueTextsrtdate = x.creationDate, historyButton_orderListManager_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/getOrderFlowManager\"}]" }).ToListAsync();
    //                    parentlist = new List<parent>();
    //                    foreach (var item in cyclelist)
    //                    {

    //                        item.orderDate_orderListManager_valueTextsrt = item.orderDate_orderListManager_valueTextsrtdate.ToShortDateString();
    //                        parentlist.Add(item);
    //                    }
    //                    itemParent cycle = new itemParent()
    //                    {
    //                        name = "orderListCycle_orderListManager",
    //                        items = parentlist
    //                    };

    //                    List<itemParent> lst = new List<itemParent>();
    //                    lst.Add(cycle);
    //                    rsp.chunkList = lst;
    //                }
    //                else if (model.slug == "app/managerChart")
    //                {
    //                    ManagerChartSearch inputModel = new ManagerChartSearch();

    //                    string sd = "";
    //                    string ed = "";
    //                    string serventList = "";
    //                    if (model.data != null)
    //                    {
    //                        foreach (var item in model.data)
    //                        {
    //                            if (item.Key == "startDate")
    //                            {
    //                                sd = item.Value;
    //                            }
    //                            if (item.Key == "endDate")
    //                            {
    //                                ed = item.Value;
    //                            }
    //                            if (item.Key == "phone")
    //                            {
    //                                serventList = item.Value;
    //                            }
    //                        }
    //                    }

    //                    inputModel.startDate = sd;
    //                    inputModel.endDate = ed;
    //                    inputModel.phone = serventList;
    //                    List<serventChartVM> lllsssttt = await GetDataForManagerChart(inputModel);
    //                    managerChartmain datttamodel = new managerChartmain()
    //                    {
    //                        name = "",
    //                        list = lllsssttt
    //                    };
    //                    parentlist.Add(datttamodel);
    //                    cycle0.items = parentlist;
    //                    cycle0.name = "chartData";
    //                    lst0.Add(cycle0);

    //                    allDataDynamic = new Dictionary<string, string>();
    //                    DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
    //                    if (model != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(sd))
    //                        {
    //                            startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(sd));
    //                            startDate = startDate.AddDays(-7);
    //                        }
    //                    }
    //                    if (model != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(ed))
    //                        {
    //                            startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(ed));
    //                            startDate = startDate.AddDays(1);
    //                        }
    //                    }

    //                    double startDateTimestamp = dateTimeConvert.ConvertDateTimeToTimestamp(startDate);
    //                    double endDateTimestamp = dateTimeConvert.ConvertDateTimeToTimestamp(startDate.AddDays(6));
    //                    allDataDynamic["startDateAction_valuesrt"] = startDateTimestamp.ToString();
    //                    allDataDynamic["endDateAction_valuesrt"] = endDateTimestamp.ToString();
    //                    allDataDynamic["currentTime_textsrt"] = startDate.ToShortDateString() + " - " + startDate.AddDays(6).ToShortDateString();
                        
    //                    allitemsDynamic.allData = allDataDynamic;
    //                    dynamiclistParent.Add(allitemsDynamic);

    //                    dynamicParent.items = dynamiclistParent;
    //                    if(lst0.Any(x => x.name == "dynamicField"))
    //                    {
    //                        var item = lst0.SingleOrDefault(x => x.name == "dynamicField");
    //                        item.items = dynamiclistParent;
    //                    }
    //                    else
    //                    {
    //                        lst0.Add(dynamicParent);
    //                    }
                        

    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/productDetail")
    //                {
    //                    string orderID = model.data["orderID"];
    //                    Guid orderIDguid = new Guid(orderID);
    //                    newOrderFlow flowitem = await dbcontext.newOrderFlows.OrderBy(x => x.actionDate).FirstOrDefaultAsync(x => x.newOrderID == orderIDguid);
    //                    int flowID = flowitem.newOrderFlowID;
    //                    Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");

    //                    List<newOrderFields> fields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flowID).ToListAsync();

    //                    productDetailApp datamodel = new productDetailApp()
    //                    {
    //                        pertTextDescription_valueText = fields.SingleOrDefault(x => x.name == "description").valueString,
    //                        pertTextTitle_valueText = fields.SingleOrDefault(x => x.name == "productTitle").valueString,
    //                    };
    //                    parentlist.Add(datamodel);
    //                    cycle0.items = parentlist;


    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/searchChartManager")
    //                {
    //                    parentlist = new List<parent>();
    //                    // ابجکت مخصوص استفاده از فرم را ایجاد میکنیم
    //                    // این فرم برای پر کردن یکی از آیتم های فرم جستجوی چارت استفاده می شود
    //                    List<orderOptionVM> tailorlst = await dbcontext.users.Where(x => x.barbariID != null).Select(x => new orderOptionVM { title = x.phone, orderOptionID = x.userID }).ToListAsync();
    //                    formOptionObject mymodel = new formOptionObject()
    //                    {
    //                        name = "tailorList",
    //                        lst = tailorlst
    //                    };
    //                    parentlist.Add(mymodel);
    //                    cycle0.items = parentlist;
    //                    cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }

    //                else if (model.slug == "app/clientOrderListPending")
    //                {
    //                    object someObject;
    //                    object userPhone;
    //                    Request.Properties.TryGetValue("UserToken", out someObject);
    //                    Request.Properties.TryGetValue("Userp", out userPhone);

    //                    Guid userID = new Guid(someObject.ToString());
    //                    parentlist = new List<parent>();
    //                    List<clientorderListPending> CYCLElIST = await dbcontext.newOrderFlows.Where(x => x.serventPhone == userPhone.ToString() && x.isFinished == "0" && x.isAccepted != "2").
    //                        Select(x => new clientorderListPending
    //                        {
    //                            flowID = x.newOrderFlowID.ToString(),
    //                            //projectName_valueTextsrt = x.NewOrder.orderName,
    //                            processName_valueTextsrt = x.newOrderProcess.title,
    //                            orderDate_valueText = x.creationDate,
    //                            historyButton_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/getOrderFlowManager\"}]",
    //                            historyButton_visibilitysrt = "1",

    //                            acceptOrderButton_cycleActionsrt = x.isAccepted == "0" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"isPopUp\":1,\"width\":300,\"height\":220,\"to\":\"app/clientAcceptFlow\"}]" : "[]",
    //                            acceptOrderButton_visibilitysrt = x.isAccepted == "0" ? "1" : "0",

    //                            rejectOrderButton_cycleActionsrt = x.isAccepted == "0" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"isPopUp\":1,\"width\":300,\"height\":220,\"to\":\"app/clientRejectFlow\"}]" : "[]",
    //                            rejectOrderButton_visibilitysrt = x.isAccepted == "0" ? "1" : "0",

    //                            productRegistration_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setProduct\"}]" : "[]",
    //                            productRegistration_visibilitysrt = "0",// x.isAccepted == "1" ? "1" : "0",

    //                            costRegistration_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setCost\"}]" : "[]",
    //                            costRegistration_visibilitysrt = "0",// x.isAccepted ==  "1" ? "1" : "0",

    //                            setFlowFormButton_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setFormByClient\"}]" : "[]",
    //                            setFlowFormButton_visibilitysrt = x.isAccepted == "1" ? "1" : "0",


    //                        }).ToListAsync();




    //                    // اینجا ما باید آیتم های مورد استفاده درسایکل رو فراخوانی کنیم
    //                    foreach (var item in CYCLElIST)
    //                    {
    //                        item.orderDate_valueTextsrt = item.orderDate_valueText.ToShortDateString();
    //                        parentlist.Add(item);

    //                    }
    //                    itemParent clientcycle = new itemParent() // برای همه
    //                    {
    //                        name = "orderListCycle",
    //                        items = parentlist
    //                    };
    //                    lst0.Add(clientcycle);



    //                    rsp.chunkList = lst0;
    //                }
    //                else if (model.slug == "app/clientRejectFlow")
    //                {
    //                    string flowID = model.data["flowID"];
    //                    acceptFlowByClient info = new acceptFlowByClient();
    //                    info.putVarRejectFlow_valuesrt = flowID;
    //                    info.relaodAction_actionssrt = "[{\"type\":\"a.reload\"}]";
    //                    parentlist.Add(info);
    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;

    //                }
    //                else if (model.slug == "app/clientAcceptFlow")
    //                {
    //                    string flowID = model.data["flowID"];
    //                    acceptFlowByClient info = new acceptFlowByClient();
    //                    info.putVarAcceptFlow_valuesrt = flowID;
    //                    parentlist.Add(info);
    //                    cycle0.items = parentlist;
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;

    //                }

    //                else if (model.slug == "app/setFlowForm")
    //                {
    //                    parentlist = new List<parent>();
    //                    newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    List<orderOptionVM> orderList = await dbcontext.NewOrders.Where(x => x.newOrderStatusID == orderstatus.newOrderStatusID).Select(x => new orderOptionVM { title = x.orderName, orderOptionID = x.newOrderID }).ToListAsync();
    //                    formOptionObject orderOBJ = new formOptionObject()
    //                    {
    //                        name = "orderList",
    //                        lst = orderList
    //                    };
    //                    parentlist.Add(orderOBJ);
    //                    List<orderOptionVM> processList = await dbcontext.processes.Select(x => new orderOptionVM { title = x.title, orderOptionID = x.processID }).ToListAsync();
    //                    orderOBJ = new formOptionObject()
    //                    {
    //                        name = "processList",
    //                        lst = processList
    //                    };
    //                    parentlist.Add(orderOBJ);


    //                    cycle0.items = parentlist;
    //                    cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
    //                    lst0.Add(cycle0);
    //                    rsp.chunkList = lst0;
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                //throw;
    //            }



    //        }


    //        return rsp;
    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<appResponse> setFormData([FromBody] getURLVM model)
    //    {
    //        appResponse response = new appResponse();
    //        resultResponse result = new resultResponse();
    //        object someObject;
    //        object Userp;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Request.Properties.TryGetValue("Userp", out Userp);

    //        if (someObject != null || (model.slug == "app/verify" || model.slug == "app/setCode"))
    //        {
    //            if (model.slug == "app/verify")
    //            {
    //                string phoneSended = await handleRegistration(model,"");
    //                List<actionResonse> actionlist = new List<actionResonse>();
    //                actionResonse action1 = new actionResonse()
    //                {
    //                    type = "a.putVar",
    //                    varName = "phone",
    //                    value = phoneSended,
    //                };


    //                actionlist.Add(action1);
    //                action1 = new actionResonse()
    //                {
    //                    type = "a.go",
    //                    to = "app/verifyPage",
    //                };
    //                actionlist.Add(action1);

    //                result.actions = actionlist;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/setCode")
    //            {
    //                responseModel tokenModel = await handleSetCode(model);
    //                if (tokenModel.status == 200)
    //                {
    //                    List<actionResonse> actionlist = new List<actionResonse>();
    //                    actionResonse action1 = new actionResonse()
    //                    {
    //                        type = "a.login",
    //                        value = tokenModel.message,
    //                        text = model.data["phone"]
    //                    };


    //                    actionlist.Add(action1);
    //                    action1 = new actionResonse()
    //                    {
    //                        type = "a.restart",
    //                    };
    //                    actionlist.Add(action1);
    //                    result.actions = actionlist;
    //                }

    //                else
    //                {
    //                    List<actionResonse> actionlist = new List<actionResonse>();
    //                    actionResonse action1 = new actionResonse()
    //                    {
    //                        type = "a.message",
    //                        text = "کد اشتباه است",
    //                    };
    //                    actionlist.Add(action1);
    //                    result.actions = actionlist;
    //                }


    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/searchFlow")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                List<int> lst = new List<int>();
    //                if (model.data.ContainsKey("custom"))
    //                {
    //                    lst = await getSearchedFlowCustom(model, usi);
    //                }
    //                else
    //                {
    //                    lst = await getSearchedFlow(model, usi);
    //                }



    //                List<actionResonse> actionlst = new List<actionResonse>();


    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.putVar",
    //                    varName = "flows",
    //                    value = String.Join(",", lst.Select(x => x.ToString()).ToArray()),
    //                };


    //                actionlst.Add(goaction);
    //                // درحالت معمولی بعد از سرچ میره داخل سرچ پیج ولی اگه بخوایم گو نشه باید بره تو ریلود که یک ریلود به پوت ور اضافه میکنیم
    //                if (model.data.ContainsKey("reload"))
    //                {
    //                    actionResonse reload = new actionResonse()
    //                    {
    //                        type = "a.reload",
    //                        to = model.data["reload"],
    //                    };
    //                    actionResonse goactionreload = new actionResonse()
    //                    {
    //                        type = "a.putVar",
    //                        varName = "flows",
    //                        value = String.Join(",", lst.Select(x => x.ToString()).ToArray()),
    //                    };


    //                    actionlst.Add(goaction);

    //                    actionResonse newgoaction = new actionResonse()
    //                    {
    //                        type = "a.back",
    //                        depth = "1",

    //                    };
    //                    newgoaction.actions.Add(goactionreload);
    //                    newgoaction.actions.Add(reload);
    //                    actionlst.Add(newgoaction);

    //                }
    //                else
    //                {
    //                    goaction = new actionResonse()
    //                    {
    //                        type = "a.go",
    //                        to = model.data["searchPage"],

    //                    };
    //                    actionlst.Add(goaction);
    //                }



    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/setClientForm")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string rsp = await setUserDynamicFormData(model, usi);

    //                string actionToGo = "app/clientDashboard";
    //                List<actionResonse> actionlst = new List<actionResonse>();


    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد",


    //                };
    //                actionlst.Add(goaction);
    //                if (model.data.ContainsKey("level2"))
    //                {
    //                    string level2 = model.data["level2"];
    //                    var nextList = level2.Trim(';').Split(';').ToList();
    //                    if (nextList[0] == "reload")
    //                    {


    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };

    //                        actionResonse reload = new actionResonse()
    //                        {
    //                            type = "a.reload",
    //                            to = nextList[1],
    //                        };
    //                        //actionlst.Add(reload);

    //                        newgoaction.actions.Add(reload);
    //                        actionlst.Add(newgoaction);
    //                    }
    //                    else if (nextList[0] == "go")
    //                    {
    //                        actionResonse reload = new actionResonse()
    //                        {
    //                            type = "a.go",
    //                            to = nextList[1],

    //                        };
    //                        //actionlst.Add(reload);
    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };
    //                        newgoaction.actions.Add(reload);
    //                        actionlst.Add(newgoaction);

    //                    }
    //                    else if (nextList[0] == "back")
    //                    {
    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "2",
    //                            startDelay = 1000

    //                        };

    //                        actionlst.Add(newgoaction);
    //                    }
    //                    else if (nextList[0] == "tab")
    //                    {
    //                        actionResonse reload = new actionResonse()
    //                        {
    //                            type = "a.tab",
    //                            to = nextList[1],

    //                        };
    //                        //actionlst.Add(reload);
    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };
    //                        newgoaction.actions.Add(reload);
    //                        actionlst.Add(newgoaction);

    //                    }


    //                }
    //                else
    //                {
    //                    if (model.data.ContainsKey("back"))
    //                    {

    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };

    //                        actionlst.Add(newgoaction);

    //                    }
    //                    if (model.data.ContainsKey("reload"))
    //                    {
    //                        string rld = model.data["reload"];
    //                        if (rld != "sample")
    //                        {
    //                            actionResonse reload = new actionResonse()
    //                            {
    //                                type = "a.reload",
    //                                to = rld,
    //                            };

    //                            actionResonse newgoaction = new actionResonse()
    //                            {
    //                                type = "a.back",
    //                                depth = "1",
    //                                startDelay = 1000

    //                            };
    //                            newgoaction.actions.Add(reload);


    //                            actionlst.Add(newgoaction);
    //                        }

    //                    }
    //                    if (model.data.ContainsKey("go"))
    //                    {
    //                        string go = model.data["go"];
    //                        if (go != "sample")
    //                        {
    //                            actionResonse gogoaction = new actionResonse()
    //                            {
    //                                type = "a.go",
    //                                to = go,
    //                            };
    //                            actionlst.Add(gogoaction);
    //                        }



    //                    }
    //                    else if (model.data.ContainsKey("tab"))
    //                    {
    //                        string tab = model.data["tab"];
    //                        actionResonse reload = new actionResonse()
    //                        {
    //                            type = "a.tab",
    //                            to = tab,

    //                        };
    //                        //actionlst.Add(reload);
    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };
    //                        newgoaction.actions.Add(reload);
    //                        actionlst.Add(newgoaction);

    //                    }

    //                }
    //                if (model.data.ContainsKey("nextFormType"))
    //                {
    //                    string formType = model.data["nextFormType"];
    //                    if (formType != "sample")
    //                    {
    //                        goaction = new actionResonse()
    //                        {
    //                            type = "a.putVar",
    //                            varName = "formType",
    //                            value = formType
    //                        };

    //                        actionlst.Add(goaction);
    //                    }

    //                }





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //                // این ینی برو وفرم دوم این داکتر  وردار بیار
    //            }
    //            else if (model.slug == "app/changeFlowStatus")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string rsp = await changeFlowStatus(model, usi);

    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "با موفقیت انجام شد",


    //                };
    //                actionlst.Add(goaction);

    //                if (model.data.ContainsKey("go"))
    //                {
    //                    string rld = model.data["go"];


    //                    if (model.data.ContainsKey("direct"))
    //                    {
    //                        actionResonse goAction = new actionResonse()
    //                        {
    //                            type = "a.go",
    //                            to = rld,

    //                        };
    //                        actionlst.Add(goAction);
    //                    }
    //                    else
    //                    {
    //                        if (rld != "sample")
    //                        {


    //                            actionResonse newgoaction = new actionResonse()
    //                            {
    //                                type = "a.back",
    //                                depth = "1",
    //                                startDelay = 1000

    //                            };

    //                            actionResonse goAction = new actionResonse()
    //                            {
    //                                type = "a.go",
    //                                to = rld,
    //                            };
    //                            newgoaction.actions.Add(goAction);
    //                            actionlst.Add(newgoaction);
    //                        }
    //                    }


    //                }
    //                else if (model.data.ContainsKey("back"))
    //                {


    //                    actionResonse newgoaction = new actionResonse()
    //                    {
    //                        type = "a.back",
    //                        depth = "1",
    //                        startDelay = 1000

    //                    };
    //                    actionlst.Add(newgoaction);
    //                }
    //                else if (model.data.ContainsKey("reload"))
    //                {
    //                    string rld = model.data["reload"];
    //                    if (rld != "sample")
    //                    {
    //                        actionResonse reload = new actionResonse()
    //                        {
    //                            type = "a.reload",
    //                            to = rld,
    //                        };

    //                        actionResonse newgoaction = new actionResonse()
    //                        {
    //                            type = "a.back",
    //                            depth = "1",
    //                            startDelay = 1000

    //                        };
    //                        newgoaction.actions.Add(reload);
    //                        actionlst.Add(newgoaction);
    //                    }

    //                }

    //                if (model.data.ContainsKey("nextFormType"))
    //                {
    //                    string formType = model.data["nextFormType"];
    //                    if (formType != "sample")
    //                    {
    //                        goaction = new actionResonse()
    //                        {
    //                            type = "a.putVar",
    //                            varName = "formType",
    //                            value = formType
    //                        };

    //                        actionlst.Add(goaction);
    //                    }

    //                }





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/sendCallNotif")
    //            {
    //                string roomid = methods.RandomString(16);
    //                string userToken = model.data["userToken"];
    //                using (Context dbcontext = new Context())
    //                {
    //                    Guid usertogui = new Guid(userToken);
    //                    user usr = await dbcontext.users.FirstOrDefaultAsync(x => x.userID == usertogui);
    //                    sendOrderNotif notifModel = new sendOrderNotif()
    //                    {
    //                        text = roomid
    //                    };

    //                    //string destinationUserToken = await sendCallNotif(userToken);
    //                    List<actionResonse> actionlst = new List<actionResonse>();
    //                    actionResonse goaction = new actionResonse()
    //                    {
    //                        type = "a.makeCall",
    //                        to = roomid,
    //                        value = userToken,
    //                        text = usr.deviceToken,
    //                        varName = SignES256(),


    //                    };

    //                    actionlst.Add(goaction);

    //                    result.actions = actionlst;
    //                    response.result = result;
    //                    response.code = 0;
    //                }

    //            }


    //            //tipax
    //            else if (model.slug == "app/submitEditProfileTipox")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = "";
    //                using (Context dbcontext = new Context())
    //                {
    //                    phoneSended = await setUserTipoxProfile(model, usi, dbcontext);
    //                }


    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload", to = "app/adminProfile" };
    //                reloadlist.Add(reloadaction);

    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    text = "با موفقیت انجام شد",
    //                    actions = reloadlist,
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد"


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/addNewTipaxClientSubmit")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = await setNewtipaxClient(model, usi);

    //                string message = "با موفقیت انجام شد";
    //                if (phoneSended == "400")
    //                {
    //                    message = "کاربر تکراری است";
    //                }


    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload", to = "app/clientAddedProfileList" };
    //                reloadlist.Add(reloadaction);

    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    actions = reloadlist,
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = message


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }

    //            //health
    //            else if (model.slug == "app/submitEditProfile")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = "";
    //                using (Context dbcontext = new Context())
    //                {
    //                    phoneSended = await setUserProfile(model, usi, dbcontext);
    //                }


    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload", to = "app/clientProfile" };
    //                reloadlist.Add(reloadaction);

    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    text = "با موفقیت انجام شد",
    //                    actions = reloadlist,
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد"


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/addNewProfileSubmit")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = await setNewProfile(model, usi);

    //                string message = "با موفقیت انجام شد";
    //                if (phoneSended == "400")
    //                {
    //                    message = "کاربر تکراری است";
    //                }


    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload", to = "app/clientAddedProfileList" };
    //                reloadlist.Add(reloadaction);

    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    actions = reloadlist,
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = message


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/addNewPatientSubmit")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = await setNewPatient(model, usi);

    //                string message = "با موفقیت انجام شد";
    //                if (phoneSended == "400")
    //                {
    //                    message = "کاربر تکراری است";
    //                }



    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = message


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/submitNewDoctor")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string phoneSended = await setNewDoctor(model, usi);

    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload", to = "app/clientDashboard" };
    //                reloadlist.Add(reloadaction);


    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    text = "با موفقیت انجام شد",
    //                    actions = reloadlist,
    //                    startDelay = 2000

    //                };

    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد"


    //                };
    //                actionlst.Add(goaction);





    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;

    //            }
    //            else if (model.slug == "app/submitPayesh")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string rsp = await setUserDynamicFormData(model, usi);
    //                List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();
    //                actionResonse ago = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",
    //                    startDelay = 2000
    //                };


    //                getOrderListManagerActionlist.Add(ago);
    //                ago = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد",
    //                };
    //                getOrderListManagerActionlist.Add(ago);
    //                ago = new actionResonse()
    //                {
    //                    type = "a.reload",
    //                    to = "app/clientDashboard",
    //                };

    //                getOrderListManagerActionlist.Add(ago);
    //                result.actions = getOrderListManagerActionlist;
    //                response.result = result;
    //                response.code = 0;
    //                // این ینی برو وفرم دوم این داکتر  وردار بیار
    //            }
    //            else if (model.slug == "app/submitAssess")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string rsp = await setUserDynamicFormData(model, usi);
    //                List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();
    //                actionResonse ago = new actionResonse()
    //                {
    //                    type = "a.putVar",
    //                    varName = "formType",
    //                    value = "2"
    //                };

    //                getOrderListManagerActionlist.Add(ago);
    //                ago = new actionResonse()
    //                {
    //                    type = "a.go",
    //                    to = "app/dynamicFormMoney",
    //                };

    //                getOrderListManagerActionlist.Add(ago);
    //                result.actions = getOrderListManagerActionlist;
    //                response.result = result;
    //                response.code = 0;
    //                // این ینی برو وفرم دوم این داکتر  وردار بیار
    //            }

    //            else if (model.slug == "app/submitDiscount")
    //            {
    //                //List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                //var discount = lstform.SingleOrDefault(x => x.key == "discount");
    //                checkDiscountVM discountFlowID = await checkDiscount(model, Userp.ToString());
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.modify",
    //                    to = "discountResult",
    //                    varName = "text",
    //                    value = discountFlowID.message

    //                };
    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.modify",
    //                    to = "discountResult",
    //                    varName = "color",
    //                    value = "cGreen"

    //                };
    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.formModify",
    //                    to = "dynamicForm",
    //                    varName = "discount",
    //                    value = discountFlowID.id

    //                };
    //                actionlst.Add(goaction);

    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/submitMoney")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string flowIDsrt = await setUserDynamicFormData(model, usi);
    //                paymentVM finalModel = await paymentProcess(model, usi, flowIDsrt);
    //                if (finalModel.status == 200)
    //                {
    //                    if (finalModel.payment == "1")
    //                    {
    //                        await finalizePayment(finalModel.payment, usi, Int32.Parse(flowIDsrt));
    //                    }
    //                }

    //                List<actionResonse> actionlst = new List<actionResonse>();

    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "با موفقیت انجام شد",


    //                };
    //                actionlst.Add(goaction);
    //                actionResonse newgoaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "4",
    //                    startDelay = 1000

    //                };
    //                actionResonse rm = new actionResonse()
    //                {
    //                    type = "a.removeVar",
    //                    varName = "flows",

    //                };
    //                newgoaction.actions.Add(rm);
    //                actionResonse reload = new actionResonse()
    //                {
    //                    type = "a.reload",
    //                    to = "app/clientDashboard",
    //                };
    //                newgoaction.actions.Add(reload);
    //                actionlst.Add(newgoaction);

    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;


    //            }
    //            else if (model.slug == "app/setNewStaticForm")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                string rsp = await setUserDynamicFormData(model, usi);
    //                string urlreload = model.data["reload"];
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "فعلت بنجاح",
    //                    startDelay = 2000


    //                };
    //                actionlst.Add(goaction);

    //                actionResonse reload = new actionResonse()
    //                {
    //                    type = "a.reload",
    //                    to = urlreload,
    //                };

    //                goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",

    //                };
    //                goaction.actions.Add(reload);


    //                actionlst.Add(goaction);


    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }

    //            // iggTailor
    //            else if (model.slug == "app/NFFOSubmit")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                await setNewFlowFromOrder(model, usi);
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "فعلت بنجاح",
    //                    startDelay = 5000

    //                };
    //                actionlst.Add(goaction);

    //                List<actionResonse> reloadlist = new List<actionResonse>();
    //                actionResonse reloadaction = new actionResonse() { type = "a.reload" };
    //                reloadlist.Add(reloadaction);


    //                goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",

    //                };


    //                actionlst.Add(goaction);

    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;

    //            }
    //            else if (model.slug == "app/editProfile")
    //            {
    //                Guid usi = new Guid(someObject.ToString());
    //                await editProfileHandler(model, usi);
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "فعلت بنجاح",
    //                    startDelay = 2000


    //                };
    //                actionlst.Add(goaction);

    //                actionResonse reload = new actionResonse()
    //                {
    //                    type = "a.reload",
    //                    to = "app/managerProfile",
    //                };

    //                goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",

    //                };
    //                goaction.actions.Add(reload);


    //                actionlst.Add(goaction);


    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/getManagerChartData")
    //            {
    //                List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();

    //                if (model.form != null)
    //                {
    //                    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                    var phone = lstform.SingleOrDefault(x => x.key == "tailorList");

    //                    if (phone != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(phone.value))
    //                        {
    //                            actionResonse todate = new actionResonse()
    //                            {
    //                                type = "a.putVar",
    //                                varName = "phone",
    //                                value = phone.value

    //                            };
    //                            getOrderListManagerActionlist.Add(todate);
    //                        }
    //                    }


    //                }
    //                actionResonse ago = new actionResonse()
    //                {
    //                    type = "a.go",
    //                    to = "app/managerChart",
    //                    orientation = 1


    //                };
    //                getOrderListManagerActionlist.Add(ago);
    //                result.actions = getOrderListManagerActionlist;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/rejectFlowByUser")
    //            {
    //                //انجام کارهای اکسپتی فلو توسط کاربر
    //                Guid usi = new Guid(someObject.ToString());
    //                await changeFlowStatusByClientHandler(model, usi, "2");
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "فعلت بنجاح",


    //                };
    //                actionlst.Add(goaction);
    //                goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",
    //                    startDelay = 3000
    //                };


    //                actionlst.Add(goaction);


    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;

    //            }
    //            else if (model.slug == "app/acceptFlowByUser")
    //            {
    //                //انجام کارهای اکسپتی فلو توسط کاربر
    //                Guid usi = new Guid(someObject.ToString());
    //                await changeFlowStatusByClientHandler(model, usi, "1");
    //                List<actionResonse> actionlst = new List<actionResonse>();
    //                actionResonse goaction = new actionResonse()
    //                {
    //                    type = "a.meesage",
    //                    text = "فعلت بنجاح",


    //                };


    //                actionlst.Add(goaction);

    //                goaction = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",
    //                    startDelay = 3000

    //                };
    //                actionlst.Add(goaction);
    //                result.actions = actionlst;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/getOrderListManager")
    //            {
    //                List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();

    //                if (model.form != null)
    //                {
    //                    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                    var toDate = lstform.SingleOrDefault(x => x.key == "toDate");
    //                    var fromDate = lstform.SingleOrDefault(x => x.key == "fromDate");
    //                    var search = lstform.SingleOrDefault(x => x.key == "search");
    //                    if (toDate != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(toDate.value))
    //                        {
    //                            actionResonse todate = new actionResonse()
    //                            {
    //                                type = "a.putVar",
    //                                varName = "toDate",
    //                                value = toDate.value

    //                            };
    //                            getOrderListManagerActionlist.Add(todate);
    //                        }
    //                    }
    //                    if (fromDate != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(fromDate.value))
    //                        {
    //                            actionResonse fromdate = new actionResonse()
    //                            {
    //                                type = "a.putVar",
    //                                varName = "fromDate",
    //                                value = fromDate.value

    //                            };
    //                            getOrderListManagerActionlist.Add(fromdate);
    //                        }
    //                    }
    //                    if (search != null)
    //                    {
    //                        if (!string.IsNullOrEmpty(search.value))
    //                        {
    //                            actionResonse searchVar = new actionResonse()
    //                            {
    //                                type = "a.putVar",
    //                                varName = "search",
    //                                value = search.value

    //                            };
    //                            getOrderListManagerActionlist.Add(searchVar);
    //                        }

    //                    }




    //                }
    //                actionResonse ago = new actionResonse()
    //                {
    //                    type = "a.go",
    //                    to = "app/getOrderListManager",


    //                };
    //                getOrderListManagerActionlist.Add(ago);
    //                result.actions = getOrderListManagerActionlist;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/setTailorForm")
    //            {
    //                Guid userID = new Guid(someObject.ToString());

    //                await setTailorForm(model, userID);
    //                //getListResponceVM modeldata = await getData(model);
    //                List<actionResonse> actionlist = new List<actionResonse>();
    //                actionResonse action1 = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",
    //                    startDelay = 2000
    //                };


    //                actionlist.Add(action1);
    //                action1 = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "فعلت بنجاح",
    //                };
    //                actionlist.Add(action1);

    //                result.actions = actionlist;
    //                response.result = result;
    //                response.code = 0;
    //            }
    //            else if (model.slug == "app/setNewFlow")
    //            {
    //                Guid userID = new Guid(someObject.ToString());
    //                await setNewFlow(model, userID);
    //                List<actionResonse> actionlist = new List<actionResonse>();
    //                actionResonse action1 = new actionResonse()
    //                {
    //                    type = "a.back",
    //                    depth = "1",
    //                    startDelay = 2000
    //                };


    //                actionlist.Add(action1);
    //                action1 = new actionResonse()
    //                {
    //                    type = "a.message",
    //                    text = "فعلت بنجاح",
    //                };
    //                actionlist.Add(action1);

    //                result.actions = actionlist;
    //                response.result = result;
    //                response.code = 0;
    //            }



    //        }
    //        else
    //        {
    //            List<actionResonse> actionlist = new List<actionResonse>();
    //            actionResonse action1 = new actionResonse()
    //            {
    //                type = "a.go",
    //                to = "app/login",
    //            };
    //            actionlist.Add(action1);
    //            result.actions = actionlist;
    //            response.result = result;
    //        }


    //        return response;
    //    }

    //    private async Task<flowDetailAll> getDataFromFlowDetaialGeneral(string userID, int flowID, int aboutUserFlow, Context dbcontext)
    //    {
    //        List<user> userlist = dbcontext.users.ToList();
    //        List<newOrderFlow> neworders = dbcontext.newOrderFlows.ToList();
    //        flowDetailAll response = new flowDetailAll();
    //        try
    //        {

    //            Dictionary<string, string> dic = new Dictionary<string, string>();

    //            List<newOrderFieldsVM> allFields = new List<newOrderFieldsVM>();
    //            if (flowID == 0)
    //            {
    //                Guid userGuid = new Guid(userID);
    //                user suser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userGuid);
    //                int formbase = dynamicMethods.getBaseFlowID(suser.userType);

    //                var flo = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userGuid && x.formID == formbase);
    //                if (flo != null)
    //                {
    //                    allFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flo.newOrderFlowID).Select(x => new newOrderFieldsVM { formItemID = x.formItemID, newOrderFieldsID = x.newOrderFieldsID, name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();
    //                }

    //            }
    //            else
    //            {
    //                if (aboutUserFlow == 1)
    //                {
    //                    newOrderFlow flw = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    user user = await dbcontext.users.FirstOrDefaultAsync(x => x.userID == flw.userID);
    //                    int formbase = dynamicMethods.getBaseFlowID(user.userType);
    //                    var flo = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == flw.userID && x.formID == formbase);
    //                    if (flo != null)
    //                    {
    //                        allFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flo.newOrderFlowID).Select(x => new newOrderFieldsVM { formItemID = x.formItemID, newOrderFieldsID = x.newOrderFieldsID, name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();
    //                    }
    //                }
    //                else
    //                {
    //                    newOrderFlow flw = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    allFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flowID).Select(x => new newOrderFieldsVM { name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();
    //                    dic.Add("userID", flw.userID.ToString());
    //                }


    //            }
    //            foreach (var item in allFields)
    //            {
    //                string name = "";
    //                string value = "";
    //                switch (item.usedFeild)
    //                {

    //                    case ("valueString"): // موقعیت 
    //                        value = item.valueString;
    //                        break;
    //                    case ("valueGuid"):// چند گزینه ای
    //                        value = item.valueString;
    //                        break;
    //                    case ("valueDateTime"): // تاریخ
    //                        value = item.valueDateTime.ToString();
    //                        break;
    //                    case ("valueDuoble"): // عددی
    //                        value = item.valueDuoble.ToString();
    //                        break;
    //                }
    //                if (!dic.ContainsKey(item.name))
    //                {
    //                    dic.Add(item.name, value);
    //                }
    //                else
    //                {
    //                    string lastPart = dic[item.name];
    //                    lastPart += lastPart + "/" + value;
    //                    dic[item.name] = lastPart;
    //                }
    //            }

    //            response.allData = dic;
    //            return response;
    //        }
    //        catch (Exception e)
    //        {
    //            return response;
    //        }


    //    }
    //    private async Task<List<flowDetailAll>> getDataFromFlowGeneral(string userID, urlData Item, int? flowID, string thirdID)
    //    {
    //        List<flowDetailAll> response = new List<flowDetailAll>();
    //        using (Context dbcontext = new Context())
    //        {
    //            if (Item.isLinkToMain == 1)
    //            {
    //                Guid userGuid = new Guid(userID);
    //                user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userGuid);
    //                int userFirstFormID = 0;
    //                switch (user.userType)
    //                {
    //                    case ("0"):
    //                        userFirstFormID = 5; // ینی کاربر معمولی و فلو جنرال کاربر معمولی میاد بالا
    //                        break;
    //                    case ("3"):
    //                        userFirstFormID = 6; // ینی کاربر معمولی و فلو جنرال کاربر معمولی میاد بالا
    //                        break;
    //                    case ("2"):
    //                        userFirstFormID = 7; // ینی کاربر معمولی و فلو جنرال کاربر معمولی میاد بالا
    //                        break;
    //                }
    //                if (Item.formID == null)// اینجا ینی فرم خاصی نیست و داینامیک است پس باید ای دی داینامیک دربیاد
    //                {
    //                    var selectedFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    Guid gu = selectedFlow.userID;
    //                    form dynamicForm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formTypeID == Item.formTypeID && x.userID == gu);
    //                    if (dynamicForm == null)
    //                    {
    //                        Item.formID = selectedFlow.formID;
    //                    }
    //                    else
    //                    {
    //                        Item.formID = dynamicForm.formID;

    //                    }
    //                }



    //                if (Item.thirdIDIsNeeded == 1)
    //                {

    //                    newOrderFlow firstFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).SingleOrDefaultAsync(x => x.formID == userFirstFormID && x.userID == userGuid);


    //                    newOrderFlow doctorFLow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    Guid uid = doctorFLow.userID;
    //                    List<flowRelation> flowRelations = await dbcontext.flowRelations.Include(x => x.parentFlow).Where(x => x.childID == firstFlow.newOrderFlowID && x.formID == Item.formID && x.parentFlow.userID == uid).ToListAsync();
    //                    if (flowRelations != null)
    //                    {

    //                    }
    //                    List<int> flowListID = flowRelations.Select(x => x.parentID).Distinct().ToList();
    //                    response = await getDataFlowGenral(flowListID, Item);


    //                }
    //                else
    //                {


    //                    if (Item.isCustom == 1)// کالکشن شرایط نال نیست
    //                    {
    //                        newOrderFlow firstFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).SingleOrDefaultAsync(x => x.formID == userFirstFormID && x.userID == userGuid);
    //                        var flowListQuery = firstFlow.childFlows.Where(x => x.formID == Item.formID && x.status == 1).ToList();
    //                        //health
    //                        if (Item.name == "payeshReminder")
    //                        {
    //                            List<int> flowListID = flowListQuery.Select(x => x.parentID).Distinct().ToList();
    //                            List<int> finalID = new List<int>();
    //                            foreach (var doc in flowListID)
    //                            {
    //                                DateTime toDayTime = DateTime.Today;
    //                                // میگم فرم اختصاصی هر کسی رو پیدا کن ببین اون روز فلو دارد با کاربر یانه
    //                                newOrderFlow docflow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(c => c.newOrderFlowID == doc);
    //                                form docform = await dbcontext.forms.SingleOrDefaultAsync(c => c.formTypeID == 3 && c.userID == docflow.userID);

    //                                List<int> isUserList = await dbcontext.newOrderFlows.Where(x => x.formID == docform.formID && x.userID == userGuid && x.creationDate >= toDayTime).Select(x => x.newOrderFlowID).ToListAsync();
    //                                if (isUserList.Count() == 0)
    //                                {
    //                                    finalID.Add(doc);
    //                                }
    //                            }
    //                            response = await getDataFlowGenral(finalID, Item);
    //                        }
    //                        else if (Item.name == "otherAccountListCycleView")
    //                        { // پروفایل های زیر مجمجوعه ای که استتوس شون از طرف سیستم تایید شده
    //                            List<int> finalID = new List<int>();
    //                            //firstFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.childFlows.Select(l => l.parentFlow)).SingleOrDefaultAsync(x => x.formID == userFirstFormID && x.userID == userGuid);

    //                            //var newQuery = firstFlow.childFlows.Where(x => x.formID == Item.formID); // && x.parentFlow.flowStatusID == 5
    //                            //if (newQuery != null)
    //                            //{
    //                            //    finalID = newQuery.Select(x => x.parentID).ToList();
    //                            //}
    //                            if (flowListQuery != null)
    //                            {
    //                                finalID = flowListQuery.Select(x => x.parentID).ToList();
    //                            }

    //                            response = await getDataFlowGenral(finalID, Item);

    //                        }
    //                    }
    //                    else
    //                    {
    //                        newOrderFlow firstFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).SingleOrDefaultAsync(x => x.formID == userFirstFormID && x.userID == userGuid);
    //                        var flowListQuery = firstFlow.childFlows.Where(x => x.formID == Item.formID).ToList();
    //                        //دریافت لیست فلو ها
    //                        List<int> flowListID = flowListQuery.Select(x => x.parentID).Distinct().ToList();
    //                        response = await getDataFlowGenral(flowListID, Item);

    //                    }
    //                }


    //            }
    //            else
    //            {
    //                // مثال اینجا میشه لیستی که باید برای دکتر واسط بیاد و تایپ آی دی ارسال میشه تا همه آیتم ها بیان
    //                List<int> lstt = new List<int>();
    //                List<int> orderList = new List<int>();
    //                IQueryable<newOrderFlow> lsttquery;

    //                // باید چک کنیم ببینیم فرم خاصی یا تایپ خاصی از فلو مد نظر است  یا خیر
    //                if (Item.formTypeID != null)
    //                {
    //                    List<int?> IDArrayNullable = new List<int?>();
    //                    if (Item.formOwner == 1)
    //                    {
    //                        Guid uguid = new Guid(userID);
    //                        form ownerForm = await dbcontext.forms.SingleOrDefaultAsync(c => c.formTypeID == Item.formTypeID && c.userID == uguid);
    //                        lsttquery = dbcontext.newOrderFlows.Where(x => x.formID == ownerForm.formID);

    //                    }
    //                    else
    //                    {
    //                        lsttquery = dbcontext.newOrderFlows.Where(x => x.formType == Item.formTypeID);
    //                    }

    //                    //var lll = lsttquery.ToList();
    //                    if (Item.isCustom == 1)
    //                    {
    //                        // tipax
    //                        //if (Item.name == "actionCycle")
    //                        //{
    //                        //    lsttquery = lsttquery.Where(x => x.flowStatusID == 3);
    //                        //    //List<newOrderFlow> lst = lsttquery.ToList();
    //                        //}

    //                        List<int> IDArray = Item.conditionStatus.Split(',').Select(int.Parse).ToList();
    //                        IDArrayNullable = IDArray.Cast<int?>().ToList();
    //                        List<newOrderFlow> lll = lsttquery.ToList();
    //                        if (Item.conditionStatusOperator == 1)
    //                        {
    //                            lsttquery = lsttquery.Where(x => IDArrayNullable.Contains(x.flowStatusID));
    //                        }
    //                        else
    //                        {
    //                            lsttquery = lsttquery.Where(x => !IDArrayNullable.Contains(x.flowStatusID));

    //                        }

    //                    }
    //                    if (Item.isForCurrentDay == 1)
    //                    {
    //                        lsttquery = lsttquery.Where(x => x.creationDate >= DateTime.Today);
    //                    }
    //                    if (IDArrayNullable.Count() > 0 && Item.conditionStatusOperator == 1)
    //                    {
    //                        IQueryable<newOrderFlow> lsttqueryOrderBy = dbcontext.newOrderFlows.Where(x => x.newOrderFlowID == 0).AsQueryable();
    //                        List<newOrderFlow> lll = lsttquery.ToList();
    //                        foreach (var flowitem in IDArrayNullable)
    //                        {
    //                            List<newOrderFlow> lll00 = lsttquery.Where(x => x.flowStatusID == flowitem).ToList();
    //                            lsttqueryOrderBy = lsttqueryOrderBy.Concat(lsttquery.Where(x => x.flowStatusID == flowitem));
    //                        }
    //                        List<newOrderFlow> lll0 = lsttqueryOrderBy.ToList();
    //                        lsttquery = lsttqueryOrderBy;


    //                    }
    //                    if (Item.isOrderByDate == 1)
    //                    {
    //                        lstt = await lsttquery.OrderByDescending(x => x.changeStatusDate).Select(x => x.newOrderFlowID).ToListAsync();

    //                    }
    //                    else
    //                    {
    //                        lstt = await lsttquery.Select(x => x.newOrderFlowID).ToListAsync();

    //                    }



    //                    //var list = lsttquery.ToList();
    //                }
    //                if (Item.formID != null)
    //                {
    //                    lstt = await dbcontext.newOrderFlows.OrderByDescending(x => x.flowStatusID).OrderByDescending(x => x.changeStatusDate).Where(x => x.formID == Item.formID).Select(x => x.newOrderFlowID).ToListAsync();

    //                }

    //                response = await getDataFlowGenral(lstt, Item);

    //            }
    //        }

    //        return response;
    //    }
    //    private async Task<List<flowDetailAll>> getDataFlowGenral(List<int> flows, urlData Item)
    //    {
    //        List<flowDetailAll> lst = new List<flowDetailAll>();


    //        if (flows != null)
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                //List<int> values = flows.Split(',').Select(s => Int32.Parse(s)).ToList();
    //                foreach (var flowID in flows)
    //                {
    //                    newOrderFlow selectedFLow = await dbcontext.newOrderFlows.Include(x => x.form).SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);

    //                    flowDetailAll eachFlow = new flowDetailAll();

    //                    Dictionary<string, string> dic = new Dictionary<string, string>();
    //                    dic.Add("ID", flowID.ToString());
    //                    dic.Add("flowID_valuesrt", flowID.ToString());
    //                    dic.Add("relation_valuesrt", flowID.ToString());

    //                    if (Item.logFields != null)
    //                    {
    //                        List<string> logListItems = Item.logFields.Trim().Split(',').ToList();
    //                        foreach (var log in logListItems)
    //                        {
    //                            List<string> logItems = log.Split('*').ToList();
    //                            string userType = logItems[0];
    //                            string formID = logItems[1];
    //                            string userID = logItems[2];

    //                            var lastItemLogList = dbcontext.FlowLogs.Where(x => x.actorUserType == userType && x.baseFlowID == flowID);
    //                            if (formID != "0")
    //                            {
    //                                int formint = Int32.Parse(formID);
    //                                lastItemLogList = lastItemLogList.Where(x => x.formID == formint);
    //                            }
    //                            if (userID != "")
    //                            {
    //                                Guid userGUID = new Guid(userID);
    //                                lastItemLogList = lastItemLogList.Where(x => x.userID == userGUID);
    //                            }

    //                            List<flowLog> logList = await lastItemLogList.OrderByDescending(x => x.flowLogID).ToListAsync();
    //                            if (logList != null)
    //                            {
    //                                if (logList.Count() > 0)
    //                                {
    //                                    dic.Add(log + "_textsrt", logList.First().actionTitle);

    //                                }
    //                            }


    //                        }
    //                    }
    //                    if (Item.flowFields != null)
    //                    {
    //                        foreach (var ffield in Item.flowFields.Trim().Split(',').ToList())
    //                        {
    //                            string firstPart = ffield.Split('_').ToList()[0];
    //                            if (selectedFLow.GetType().GetProperty(firstPart) != null)
    //                            {
    //                                string selectedValue = selectedFLow.GetType().GetProperty(firstPart).GetValue(selectedFLow, null) + "";

    //                                if (firstPart == "childStatus")
    //                                {
    //                                    switch (selectedValue)
    //                                    {
    //                                        case ("0"):
    //                                            selectedValue = "در انتظار";
    //                                            break;
    //                                    }
    //                                }
    //                                if (firstPart == "creationDate")
    //                                {
    //                                    selectedValue = DateTime.Parse(selectedValue).ToPersianDateString();
    //                                }

    //                                dic.Add(ffield, selectedValue);
    //                            }
    //                            else
    //                            {
    //                                if (firstPart == "formName")
    //                                {
    //                                    string selectedValue = selectedFLow.form.title;
    //                                    dic.Add(ffield, selectedValue);
    //                                }
    //                            }
    //                        }
    //                    }
    //                    if (Item.formFields != null)
    //                    {
    //                        List<newOrderFieldsVM> allFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flowID).Select(x => new newOrderFieldsVM { flowID = x.newOrderFlowID, name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();
    //                        foreach (var field in Item.formFields.Trim().Split(',').ToList())
    //                        {
    //                            if (!string.IsNullOrEmpty(field))
    //                            {

    //                                string firstPart = field.Split('_').ToList()[0];
    //                                var neworderfield = allFields.Where(x => x.flowID == flowID && x.name.Contains(firstPart)).ToList();
    //                                if (neworderfield.Count() > 0)
    //                                {
    //                                    string rfinal = "";
    //                                    foreach (var insertedItem in neworderfield)
    //                                    {
    //                                        if (insertedItem.usedFeild == "valueString" || insertedItem.usedFeild == "valueGuid")
    //                                            rfinal += "/" + insertedItem.valueString;
    //                                        else if (insertedItem.usedFeild == "valueBool")
    //                                        {
    //                                            rfinal += insertedItem.valueBool == true ? "1" : "0";
    //                                        }
    //                                        else if (insertedItem.usedFeild == "valueDateTime")
    //                                        {
    //                                            rfinal += "/" + insertedItem.valueDateTime.ToString();
    //                                        }
    //                                        else if (insertedItem.usedFeild == "valueDuoble")
    //                                        {
    //                                            rfinal += "/" + insertedItem.valueDuoble.ToString();
    //                                        }
    //                                    }

    //                                    dic.Add(field, rfinal.Trim('/'));

    //                                }
    //                            }



    //                        }
    //                    }
    //                    if (Item.userFields != null)
    //                    {
    //                        Guid userID = selectedFLow.userID;
    //                        user suser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                        int selectedNumber = dynamicMethods.getBaseFlowID(suser.userType);// 5;

    //                        newOrderFlow userFLow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userID && x.formID == selectedNumber);
    //                        dic.Add("userToken_valuesrt", userID.ToString());
    //                        if (userFLow != null)
    //                        {
    //                            List<newOrderFieldsVM> userFlowFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == userFLow.newOrderFlowID).Select(x => new newOrderFieldsVM { flowID = x.newOrderFlowID, name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();

    //                            foreach (var field in Item.userFields.Trim().Split(',').ToList())
    //                            {


    //                                if (!string.IsNullOrEmpty(field))
    //                                {
    //                                    string firstPart = field.Split('_').ToList()[1];
    //                                    var allfields = userFlowFields.Where(x => x.name.Contains(firstPart)).ToList();
    //                                    if (allfields.Count() > 0)
    //                                    {
    //                                        string rfinal = "";
    //                                        foreach (var insertedItem in allfields)
    //                                        {
    //                                            if (insertedItem.usedFeild == "valueString" || insertedItem.usedFeild == "valueGuid")
    //                                                rfinal += insertedItem.valueString;
    //                                            else if (insertedItem.usedFeild == "valueBool")
    //                                            {
    //                                                rfinal += insertedItem.valueBool == true ? "1" : "0";
    //                                            }
    //                                            else if (insertedItem.usedFeild == "valueDateTime")
    //                                            {
    //                                                rfinal += insertedItem.valueDateTime.ToString();
    //                                            }
    //                                            else if (insertedItem.usedFeild == "valueDuoble")
    //                                            {
    //                                                rfinal += insertedItem.valueDuoble.ToString();
    //                                            }
    //                                        }

    //                                        dic.Add(field, rfinal);
    //                                    }


    //                                }
    //                            }
    //                        }

    //                    }
    //                    if (Item.statusFields != null)
    //                    {
    //                        foreach (var field in Item.statusFields.Trim().Split(',').ToList())
    //                        {
    //                            if (selectedFLow.flowStatusID != null)
    //                            {
    //                                int statusID = (int)selectedFLow.flowStatusID;
    //                                flowStatus statusFLow = await dbcontext.flowStatuses.SingleOrDefaultAsync(x => x.flowStatusID == statusID);

    //                                if (!string.IsNullOrEmpty(field))
    //                                {
    //                                    string firstPart = field.Split('_').ToList()[1];
    //                                    if (statusFLow.GetType().GetProperty(firstPart) != null)
    //                                    {
    //                                        string selectedValue = statusFLow.GetType().GetProperty(firstPart).GetValue(statusFLow, null) + "";


    //                                        dic.Add(field, selectedValue);
    //                                    }
    //                                }
    //                            }

    //                        }

    //                    }
    //                    if (Item.extraRelation != null)
    //                    {
    //                        List<string> lll = Item.extraRelation.Trim(',').Split(',').ToList();
    //                        int formID = int.Parse(lll[0]);
    //                        int isSingle = int.Parse(lll[1]);
    //                        string Operat = lll[2];
    //                        string field = lll[3];

    //                        // من اینجا در نظر میگیرم که فرمی که برای یک
    //                        if (isSingle == 0)
    //                        {
    //                            flowRelation rl = await dbcontext.flowRelations.Include(x => x.parentFlow).Include(x => x.parentFlow.NewOrderFields).OrderByDescending(x => x.flowRelationID).FirstOrDefaultAsync(x => x.childID == selectedFLow.newOrderFlowID && x.formID == formID);
    //                            if (rl != null)
    //                            {
    //                                foreach (var insertedItem in rl.parentFlow.NewOrderFields)
    //                                {
    //                                    if (field.Contains(insertedItem.name))
    //                                    {
    //                                        string rfinal = "";
    //                                        if (insertedItem.usedFeild == "valueString" || insertedItem.usedFeild == "valueGuid")
    //                                            rfinal = insertedItem.valueString;
    //                                        else if (insertedItem.usedFeild == "valueBool")
    //                                        {
    //                                            rfinal = insertedItem.valueBool == true ? "1" : "0";
    //                                        }
    //                                        else if (insertedItem.usedFeild == "valueDateTime")
    //                                        {
    //                                            rfinal = insertedItem.valueDateTime.ToString();
    //                                        }
    //                                        else if (insertedItem.usedFeild == "valueDuoble")
    //                                        {
    //                                            rfinal = insertedItem.valueDuoble.ToString();
    //                                        }
    //                                        dic.Add(formID + "_" + field, rfinal);
    //                                    }
    //                                }
    //                            }

    //                        }

    //                    }

    //                    eachFlow.allData = dic;
    //                    lst.Add(eachFlow);
    //                }


    //            }

    //        }

    //        return lst;
    //    }
    //    private async Task<List<int>> getSearchedFlow(getURLVM model, Guid userID)
    //    {
    //        // ما ابتدا باید فلو آ ی ددی ها رو پیدا کنیم که جستجو خیلی کمتر کنیم




    //        using (Context dbcontext = new Context())
    //        {
    //            List<int> flowIDS = await findFlowsForSearch(model, dbcontext, userID);
    //            List<int> response = new List<int>();


    //            List<detailCollection> lstform = new List<detailCollection>();
    //            if (model.form != null)
    //            {
    //                lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                lstform = lstform.Where(x => !string.IsNullOrEmpty(x.value)).ToList();
    //            }

    //            List<newOrderFields> allData = new List<newOrderFields>();

    //            IQueryable<newOrderFields> querable = dbcontext.newOrderFields.Where(x => flowIDS.Contains(x.newOrderFlowID)).AsQueryable();
    //            //List<newOrderFields> ql = querable.ToList();
    //            IQueryable<newOrderFields> listOppLineData = dbcontext.newOrderFields.Where(x => x.newOrderFlowID == 0).AsQueryable();
    //            //List<newOrderFields> qll = listOppLineData.ToList();

    //            if (lstform.Count() > 0)
    //            {
    //                foreach (var item in lstform)
    //                {
    //                    if (lstform.IndexOf(item) == 0)
    //                    {
    //                        switch (item.formItemTypeCode)
    //                        {
    //                            case ("6"): // انتخابی
    //                                bool boovalue = bool.Parse(item.value);
    //                                var qb = from q in querable
    //                                         where q.formItemID == item.relatedFormItemID && q.valueBool == boovalue
    //                                         select q;
    //                                listOppLineData.Concat(qb);


    //                                break;
    //                            case ("1"):// چند گزینه ای
    //                                IQueryable<newOrderFields> loopQuarable = dbcontext.newOrderFields.Where(x => x.newOrderFlowID == 0).AsQueryable();

    //                                List<string> items = item.value.Trim(',').Split(',').ToList();
    //                                foreach (var check in items)
    //                                {
    //                                    List<string> checkDetail = check.Split(':').ToList();
    //                                    Guid idguid = new Guid(checkDetail[0]);
    //                                    qb = loopQuarable.Concat(from q in querable
    //                                                             where q.formItemID == item.relatedFormItemID && q.valueGuid == idguid
    //                                                             select q);
    //                                    loopQuarable = loopQuarable.Concat(qb);
    //                                }

    //                                listOppLineData = listOppLineData.Concat(loopQuarable);





    //                                break;
    //                            case ("5"): // تاریخ

    //                                DateTime datetime = DateTime.Parse(item.value);
    //                                if (item.operat == "From")
    //                                {
    //                                    qb = from q in querable

    //                                         where q.formItemID == item.relatedFormItemID && q.valueDateTime >= datetime
    //                                         select q;
    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                else
    //                                {
    //                                    qb = from q in querable

    //                                         where q.formItemID == item.relatedFormItemID && q.valueDateTime <= datetime
    //                                         select q;
    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                break;
    //                            case ("4"): // عددی

    //                                double numberbvalue = Int64.Parse(item.value);
    //                                qb = from q in querable

    //                                     where q.formItemID == item.relatedFormItemID && q.valueDuoble == numberbvalue
    //                                     select q;
    //                                listOppLineData = listOppLineData.Concat(qb);


    //                                break;
    //                            case ("3"): // متنی
    //                                if (item.operat == "equal")
    //                                {
    //                                    qb = from q in querable

    //                                         where q.formItemID == item.relatedFormItemID && q.valueString == item.value
    //                                         select q;
    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                else if (item.operat == "contain")
    //                                {
    //                                    qb = from q in querable

    //                                         where q.formItemID == item.relatedFormItemID && q.valueString.Contains(item.value)
    //                                         select q;
    //                                    //List<newOrderFields> dblist = qb.ToList();
    //                                    listOppLineData = listOppLineData.Concat(qb);
    //                                    //dblist = listOppLineData.ToList();
    //                                }
    //                                break;


    //                        }

    //                    }
    //                    else
    //                    {
    //                        switch (item.formItemTypeCode)
    //                        {
    //                            case ("6"): // انتخابی
    //                                bool boovalue = bool.Parse(item.value);
    //                                var qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueBool == boovalue
    //                                          select q).Distinct();
    //                                listOppLineData = listOppLineData.Concat(qb);

    //                                break;
    //                            case ("1"):// چند گزینه ای
    //                                IQueryable<newOrderFields> loopQuarable = dbcontext.newOrderFields.Where(x => x.newOrderFlowID == 0).AsQueryable();

    //                                List<string> items = item.value.Trim(',').Split(',').ToList();
    //                                foreach (var check in items)
    //                                {
    //                                    List<string> checkDetail = check.Split(':').ToList();
    //                                    Guid idguid = new Guid(checkDetail[0]);
    //                                    qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueGuid == idguid
    //                                          select q).Distinct();
    //                                    loopQuarable = loopQuarable.Concat(qb);
    //                                }


    //                                listOppLineData = listOppLineData.Concat(loopQuarable);
    //                                List<newOrderFields> dblist = loopQuarable.ToList();


    //                                break;
    //                            case ("5"): // تاریخ

    //                                DateTime datetime = DateTime.Parse(item.value);
    //                                if (item.operat == "From")
    //                                {
    //                                    qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueDateTime >= datetime
    //                                          select q).Distinct();
    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                else
    //                                {
    //                                    qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueDateTime <= datetime
    //                                          select q).Distinct();
    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                break;
    //                            case ("4"): // عددی

    //                                double numberbvalue = Int64.Parse(item.value);
    //                                qb = (from q in querable
    //                                      join l in listOppLineData
    //                                      on q.newOrderFlowID equals l.newOrderFlowID
    //                                      where q.formItemID == item.relatedFormItemID && q.valueDuoble == numberbvalue
    //                                      select q).Distinct();
    //                                listOppLineData = listOppLineData.Concat(qb);


    //                                break;
    //                            case ("3"): // متنی
    //                                if (item.operat == "equal")
    //                                {

    //                                    qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueString == item.value
    //                                          select q).Distinct();

    //                                    listOppLineData = listOppLineData.Concat(qb);

    //                                }
    //                                else if (item.operat == "contain")
    //                                {

    //                                    qb = (from q in querable
    //                                          join l in listOppLineData
    //                                          on q.newOrderFlowID equals l.newOrderFlowID
    //                                          where q.formItemID == item.relatedFormItemID && q.valueString.Contains(item.value)
    //                                          select q).Distinct();
    //                                    //dblist = qb.ToList();
    //                                    //dblist = listOppLineData.ToList();
    //                                    listOppLineData = listOppLineData.Concat(qb);
    //                                    //dblist = listOppLineData.ToList();
    //                                }
    //                                break;


    //                        }

    //                    }




    //                }

    //                allData = await listOppLineData.ToListAsync();
    //                int finalCOUnt = lstform.Count();
    //                List<int> flowList = new List<int>();
    //                foreach (var itt in allData.GroupBy(x => x.newOrderFlowID))
    //                {
    //                    if (itt.Count() == finalCOUnt)
    //                    {
    //                        response.Add(itt.First().newOrderFlowID);
    //                    }
    //                }
    //            }
    //            else
    //            {



    //                //if (model.data.ContainsKey("defautlFormID"))
    //                //{
    //                //    int formID = Int32.Parse(model.data["defautlFormID"]);
    //                //    response = await dbcontext.newOrderFlows.Where(x => x.formID == formID && flowIDS.Contains(x.newOrderFlowID)).Select(x => x.newOrderFlowID).ToListAsync();

    //                //}

    //                response = flowIDS;

    //            }


    //            return response;
    //            //listOppLineData.GroupBy(x=>x.formItemID).Select(x=>new flowSelectedVM {  flowID = x.})
    //        }

    //    }
    //    private async Task<List<int>> getSearchedFlowCustom(getURLVM model, Guid userID)
    //    {
    //        // ما ابتدا باید فلو آ ی ددی ها رو پیدا کنیم که جستجو خیلی کمتر کنیم


    //        List<int> response = new List<int>();

    //        using (Context dbcontext = new Context())
    //        {
    //            string name = model.data["name"];
    //            //tipax
    //            if (name == "userActionList")
    //            {
    //                var responsQuerable = dbcontext.newOrderFlows.Include(x => x.newOrderFlowServent).Where(x => x.formID == 4).AsQueryable();
    //                if (model.form != null)
    //                {
    //                    List<detailCollection> lstform = model == null ? new List<detailCollection>() : JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                    var dataFrom = lstform.SingleOrDefault(x => x.key == "dateFrom");
    //                    var dateTo = lstform.SingleOrDefault(x => x.key == "dateTo");
    //                    var query = lstform.SingleOrDefault(x => x.key == "query");
    //                    if (dataFrom != null)
    //                    {
    //                        DateTime timeFrom = DateTime.Parse(dataFrom.value);
    //                        responsQuerable = responsQuerable.Where(x => x.creationDate >= timeFrom);
    //                    }
    //                    if (dateTo != null)
    //                    {
    //                        DateTime timeTo = DateTime.Parse(dateTo.value);
    //                        responsQuerable = responsQuerable.Where(x => x.creationDate <= timeTo);
    //                    }
    //                    if (query != null)
    //                    {

    //                        responsQuerable = responsQuerable.Where(x => x.newOrderFlowServent.phone.Contains(query.value) || x.newOrderFlowServent.name.Contains(query.value));
    //                    }
    //                }


    //                response = await responsQuerable.OrderByDescending(x => x.creationDate).Select(x => x.newOrderFlowID).ToListAsync();

    //            }


    //            return response;
    //            //listOppLineData.GroupBy(x=>x.formItemID).Select(x=>new flowSelectedVM {  flowID = x.})
    //        }

    //    }

    //    private async Task<List<int>> findFlowsForSearch(getURLVM model, Context dbcontext, Guid userID)
    //    {
    //        List<int> response = new List<int>();
    //        if (model.data.ContainsKey("name"))
    //        {
    //            string name = model.data["name"];
    //            if (name == "searchDoctor")
    //            {
    //                int formID = Int32.Parse(model.data["defautlFormID"]);
    //                response = await dbcontext.newOrderFlows.Where(x => x.formID == formID).Select(x => x.newOrderFlowID).ToListAsync();

    //            }
    //            else if (name == "searchUserDoctor")
    //            {
    //                // ابتدا باید بیس فرم دکتر دربیاد

    //                newOrderFlow userFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userID && x.formID == 7);//اولین فلو ثبت اطلاعات کاربر

    //                var responseqeuery = dbcontext.flowRelations.Where(x => x.parentID == userFlow.newOrderFlowID && x.formID == 7).AsQueryable(); // اینجا ینی همه 
    //                if (responseqeuery != null)
    //                {
    //                    response = responseqeuery.Select(x => x.childID).Distinct().ToList();
    //                }
    //            }
    //        }


    //        return response;
    //    }

    //    private async Task<checkDiscountVM> checkDiscount(getURLVM model, string Userp)
    //    {
    //        checkDiscountVM response = new checkDiscountVM()
    //        {
    //            message = "کد تخفیفی جهت دکتر مورد نظر وجود ندارد",
    //            id = ""
    //        };
    //        using (Context dbcontext = new Context())
    //        {

    //            int flowID = Int32.Parse(model.data["flowID"]);
    //            newOrderFlow doctorflow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);

    //            newOrderFields selectedFild = await dbcontext.newOrderFields.Include(x => x.NewOrderFlow).SingleOrDefaultAsync(x => x.valueString == Userp && x.NewOrderFlow.userID == doctorflow.userID);


    //            if (selectedFild != null)
    //            {
    //                newOrderFields itemselectedfield = await dbcontext.newOrderFields.Include(x => x.NewOrderFlow).SingleOrDefaultAsync(x => x.newOrderFlowID == selectedFild.newOrderFlowID && x.usedFeild == "valueGuid");
    //                response.message = "کد تخفیف جهت دکتر مورد نظر : " + itemselectedfield.valueString;
    //                response.id = selectedFild.newOrderFlowID.ToString();
    //            }
    //        }


    //        return response;
    //    }


    //    //tipox
    //    private async Task<string> setUserTipoxProfile(getURLVM model, Guid userID, Context dbcontext)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = model == null ? new List<detailCollection>() : JsonConvert.DeserializeObject<List<detailCollection>>(model.form);




    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);

    //            // formID 5 فرم ثبت اطلاعات
    //            //formID 6 فرم ثبت پروفایل
    //            user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            //finding userinfoFlowID
    //            newOrderFlow userInfoFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == sendingUser.userID && x.formID == 1); // 

    //            var fullnameItem = lstform.SingleOrDefault(x => x.key == "fullname");
    //            string fullname = "";
    //            if (fullnameItem != null)
    //            {
    //                fullname = lstform.SingleOrDefault(x => x.key == "fullname").value;
    //                sendingUser.name = fullname;
    //            }


    //            if (userInfoFlow != null)
    //            {
    //                await doSaveForm(lstform, userInfoFlow.newOrderFlowID, dbcontext);

    //                return "";
    //            }

    //            string status = "0";
    //            //Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //            //Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;
    //            Guid partnerID = Guid.NewGuid();



    //            // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده

    //            //newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //            //newOrderType neworderType = await dbcontext.newOrderTypes.SingleOrDefaultAsync(x => x.orderTypeCode == 3); // ینی اطلاعات خود کاربر

    //            rnd = new Random();
    //            int month = rnd.Next(11111, 99999);
    //            string orderName = fullname;

    //            Guid orderID = Guid.NewGuid();
    //            //newOrder neworder = new newOrder()
    //            //{
    //            //    creationDate = DateTime.Now,
    //            //    terminationDate = DateTime.Now,
    //            //    newOrderID = orderID,
    //            //    newOrderStatusID = neworderstatus.newOrderStatusID,
    //            //    orderName = orderName,
    //            //    newOrderTypeID = neworderType.newOrderTypeID,
    //            //    thirdPartyID = userID

    //            //    //thirdPartyID = thirdPartyGUID,
    //            //};
    //            //dbcontext.NewOrders.Add(neworder);


    //            //process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.orderTypeID == neworderType.newOrderTypeID && x.isDefault == "1");
    //            //Guid processID = pr.processID;

    //            newOrderFlow newOrderFlow = new newOrderFlow()
    //            {
    //                creationDate = DateTime.Now,
    //                actionDate = DateTime.Now,
    //                isFinished = "1",
    //                newOrderID = orderID,
    //                serventPhone = sendingUser.phone,
    //                userID = userID,
    //                terminationDate = DateTime.Now,
    //                changeStatusDate = DateTime.Now,
    //                formID = 1 // ینی فرم ثبت اطلاعات کاربر

    //            };




    //            dbcontext.newOrderFlows.Add(newOrderFlow);
    //            await dbcontext.SaveChangesAsync();
    //            await doSaveForm(lstform, newOrderFlow.newOrderFlowID, dbcontext);
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }
    //    private async Task<string> setNewtipaxClient(getURLVM model, Guid userID)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);


    //            string fullname = lstform.SingleOrDefault(x => x.key == "fullname").value;
    //            string IDCode = methods.PersianToEnglish(lstform.SingleOrDefault(x => x.key == "ID").value);
    //            string userPhone = methods.PersianToEnglish( lstform.SingleOrDefault(x => x.key == "phone").value);
    //            string image = lstform.Any(x => x.key == "image") ? lstform.SingleOrDefault(x => x.key == "image").value : "";

    //            IDCode = string.IsNullOrEmpty(IDCode) ? "" : IDCode;




    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);

    //            // formID 5 فرم ثبت اطلاعات
    //            //formID 6 فرم ثبت پروفایل

    //            int flowID = 0;
    //            using (Context dbcontext = new Context())
    //            {
    //                user userToAdd = await dbcontext.users.SingleOrDefaultAsync(x => x.name == fullname && (x.codeMelli == IDCode));
    //                Guid partnerID = Guid.NewGuid();
    //                if (userToAdd == null)
    //                {
    //                    string status = "0";
    //                    Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //                    Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;


    //                    // ثبت کاربر
    //                    user newuser = new user()
    //                    {
    //                        userID = partnerID,
    //                        phone = userPhone,
    //                        name = fullname,
    //                        codeMelli = IDCode,
    //                        code = IDCode, // num.ToString(),
    //                        userType = "0",
    //                        verifyStatusID = statusID,
    //                        workingStatusID = workingID
    //                    };
    //                    dbcontext.users.Add(newuser);
    //                    // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده

    //                    //newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    //newOrderType neworderType = await dbcontext.newOrderTypes.SingleOrDefaultAsync(x => x.orderTypeCode == 1);

    //                    rnd = new Random();
    //                    int month = rnd.Next(11111, 99999);
    //                    string orderName = fullname;

    //                    Guid orderID = Guid.NewGuid();
    //                    //newOrder neworder = new newOrder()
    //                    //{
    //                    //    creationDate = DateTime.Now,
    //                    //    terminationDate = DateTime.Now,
    //                    //    newOrderID = orderID,
    //                    //    newOrderStatusID = neworderstatus.newOrderStatusID,
    //                    //    orderName = orderName,
    //                    //    newOrderTypeID = neworderType.newOrderTypeID,
    //                    //    thirdPartyID = partnerID,


    //                    //    //thirdPartyID = thirdPartyGUID,
    //                    //};
    //                    //dbcontext.NewOrders.Add(neworder);

    //                    //process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.orderTypeID == neworderType.newOrderTypeID && x.isDefault == "1");
    //                    //Guid processID = pr.processID;



    //                    // اینجا اطلاعات خود کاربر به عنوان نفر تازه با فلو جدید ایجاد میشود
    //                    newOrderFlow newUserFlow = new newOrderFlow()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        actionDate = DateTime.Now,
    //                        isFinished = "1",
    //                        newOrderID = orderID,
    //                        serventPhone = userPhone,
    //                        userID = partnerID,
    //                        terminationDate = DateTime.Now,
    //                        formID = 1, // ینی فرم ثبت پروفایل
    //                        flowStatusID = 2,
    //                        changeStatusDate = DateTime.Now

    //                    };
    //                    dbcontext.newOrderFlows.Add(newUserFlow);

    //                    await dbcontext.SaveChangesAsync();

    //                    // دیتاهای مرتبط با فلو کاربر باید ثبت شود همانهاییی که هست
    //                    List<formItem> fieldList = await dbcontext.formItems.Where(x => x.formID == 1).ToListAsync();
    //                    List<detailCollection> user5InfoDetail = new List<detailCollection>();
    //                    foreach (var item in fieldList)
    //                    {
    //                        if (item.itemName == "fullname")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 1,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = fullname,
    //                                formItemTypeCode = "3"


    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }
    //                        else if (item.itemName == "image")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 1,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = image,
    //                                formItemTypeCode = "3"

    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }

    //                    }
    //                    await doSaveForm(user5InfoDetail, newUserFlow.newOrderFlowID, dbcontext); // اینجا اطلاعات کاربر با ججزئیات ثبت می شود



    //                    user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                    newOrderFlow sendingUserInfoFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.childFlows.Select(l => l.parentFlow)).Include(x => x.childFlows.Select(l => l.parentFlow.newOrderFlowServent)).SingleOrDefaultAsync(x => x.userID == sendingUser.userID && x.formID == 1); //  اینجا ادمین میخواد کلاینت اضافه کنه



    //                    // ارتباط ادمین یا فرم کاربر جدید ایجاد می شود
    //                    flowRelation nr = new flowRelation()
    //                    {
    //                        childID = sendingUserInfoFlow.newOrderFlowID,
    //                        parentID = newUserFlow.newOrderFlowID,
    //                        status = 1,
    //                        childEndDate = DateTime.Now,
    //                        childStartDate = DateTime.Now,
    //                        formID = 1
    //                    };

    //                    dbcontext.flowRelations.Add(nr);
    //                    await dbcontext.SaveChangesAsync();
    //                }

    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }

    //    //health

    //    private async Task<List<chartList>> getLineChartData(getURLVM model, List<formItemVM> formItem, List<int> userPayeshFlows)
    //    {
    //        List<chartList> rsp = new List<chartList>();

    //        using (Context dbcontext = new Context())
    //        {


    //            //private Random rnd = new Random();
    //            //Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
    //            foreach (var item in formItem)
    //            {
    //                chartList chartItemData = new chartList();
    //                chartItemData.name = item.itemName;
    //                chartItemData.id = item.relatedFormItemID.ToString();
    //                Random rnd = new Random();
    //                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
    //                chartItemData.lineDashColor = "#" + randomColor.Name;
    //                List<chartItemList> formItemSet = await dbcontext.newOrderFields.Include(x => x.NewOrderFlow).OrderBy(x => x.NewOrderFlow.creationDate).Where(x => x.formItemID == item.formItemID && userPayeshFlows.Contains(x.newOrderFlowID)).Select(x => new chartItemList { xValue = 0, xLable = x.NewOrderFlow.creationDate.ToString(), yValue = x.valueDuoble }).ToListAsync();
    //                foreach (var fitem in formItemSet)
    //                {
    //                    fitem.xValue = formItemSet.IndexOf(fitem) + 1;
    //                    DateTime xdatetime = DateTime.Parse(fitem.xLable).Date;
    //                    string finalSrt = dateTimeConvert.ToPersianDateNoHourString(xdatetime);
    //                    fitem.xLable = finalSrt;
    //                }
    //                chartItemData.values = formItemSet;
    //                rsp.Add(chartItemData);
    //            }


    //        }
    //        return rsp;
    //    }
    //    private async Task<string> setUserProfile(getURLVM model, Guid userID, Context dbcontext)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = model == null ? new List<detailCollection>() : JsonConvert.DeserializeObject<List<detailCollection>>(model.form);




    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);

    //            // formID 5 فرم ثبت اطلاعات
    //            //formID 6 فرم ثبت پروفایل
    //            user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            //finding userinfoFlowID
    //            newOrderFlow userInfoFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == sendingUser.userID && x.formID == 5); // 

    //            var fullnameItem = lstform.SingleOrDefault(x => x.key == "fullname");
    //            string fullname = "";
    //            if (fullnameItem != null)
    //            {
    //                fullname = lstform.SingleOrDefault(x => x.key == "fullname").value;
    //                sendingUser.name = fullname;
    //            }


    //            if (userInfoFlow != null)
    //            {
    //                foreach (var item in lstform)
    //                {

    //                    newOrderFields neworderfiled = await dbcontext.newOrderFields.SingleOrDefaultAsync(x => x.newOrderFlowID == userInfoFlow.newOrderFlowID && x.formItemID == item.formItemID);
    //                    string fieldToGo = "";
    //                    switch (item.formItemTypeCode)
    //                    {
    //                        case ("6"): // انتخابی
    //                            fieldToGo = "valueBool";

    //                            break;
    //                        case ("8"): // موقعیت 
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("7"):// آپلود
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("1"):// چند گزینه ای
    //                            fieldToGo = "valueGuid";
    //                            break;
    //                        case ("5"): // تاریخ
    //                            fieldToGo = "valueDateTime";
    //                            break;
    //                        case ("4"): // عددی
    //                            fieldToGo = "valueDuoble";
    //                            break;
    //                        case ("3"): // متنی
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("2"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("9"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        default:
    //                            fieldToGo = "valueString";
    //                            break;
    //                    }
    //                    if (neworderfiled == null)
    //                    {
    //                        neworderfiled = new newOrderFields();

    //                        neworderfiled.newOrderFlowID = userInfoFlow.newOrderFlowID;
    //                        neworderfiled.formItemID = item.formItemID;
    //                        neworderfiled.name = item.key;
    //                        neworderfiled.newOrderFieldsID = Guid.NewGuid();
    //                        neworderfiled.usedFeild = fieldToGo;
    //                        neworderfiled.valueInt = 0;
    //                        neworderfiled.valueDuoble = 0;
    //                        neworderfiled.valueDateTime = DateTime.Now;
    //                        neworderfiled.valueBool = false;
    //                        neworderfiled.valueGuid = new Guid();

    //                        if (fieldToGo == "valueBool")
    //                            neworderfiled.valueBool = Boolean.Parse(item.value);
    //                        if (fieldToGo == "valueString")
    //                            neworderfiled.valueString = item.value;
    //                        if (fieldToGo == "valueDateTime")
    //                            neworderfiled.valueDateTime = DateTime.Parse(item.value);
    //                        if (fieldToGo == "valueGuid")
    //                        {
    //                            List<string> lst = item.value.Split(':').ToList();
    //                            neworderfiled.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                            neworderfiled.valueGuid = new Guid(lst[0]);
    //                        }


    //                        if (fieldToGo == "valueDuoble")
    //                            neworderfiled.valueDuoble = double.Parse(item.value);

    //                        dbcontext.newOrderFields.Add(neworderfiled);
    //                        await dbcontext.SaveChangesAsync();

    //                    }
    //                    else
    //                    {

    //                        if (fieldToGo == "valueBool")

    //                            neworderfiled.valueBool = Boolean.Parse(item.value);
    //                        if (fieldToGo == "valueString")
    //                            if (!string.IsNullOrEmpty(neworderfiled.valueString))
    //                            {
    //                                if (neworderfiled.name == "image")
    //                                {
    //                                    neworderfiled.valueString = item.value;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                neworderfiled.valueString = item.value;
    //                            }

    //                        if (fieldToGo == "valueDateTime")
    //                            neworderfiled.valueDateTime = DateTime.Parse(item.value);
    //                        if (fieldToGo == "valueGuid")
    //                        {
    //                            List<string> lst = item.value.Split(':').ToList();
    //                            neworderfiled.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                            neworderfiled.valueGuid = new Guid(lst[0]);
    //                        }

    //                        if (fieldToGo == "valueDuoble")
    //                        {
    //                            if (string.IsNullOrEmpty(neworderfiled.valueString))
    //                            {
    //                                neworderfiled.valueDuoble = double.Parse(item.value);
    //                            }

    //                        }


    //                        await dbcontext.SaveChangesAsync();
    //                    }






    //                }



    //                return "";
    //            }

    //            string status = "0";
    //            Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //            Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;
    //            Guid partnerID = Guid.NewGuid();



    //            // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده

    //            newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //            newOrderType neworderType = await dbcontext.newOrderTypes.SingleOrDefaultAsync(x => x.orderTypeCode == 3); // ینی اطلاعات خود کاربر

    //            rnd = new Random();
    //            int month = rnd.Next(11111, 99999);
    //            string orderName = fullname;

    //            Guid orderID = Guid.NewGuid();
    //            newOrder neworder = new newOrder()
    //            {
    //                creationDate = DateTime.Now,
    //                terminationDate = DateTime.Now,
    //                newOrderID = orderID,
    //                newOrderStatusID = neworderstatus.newOrderStatusID,
    //                orderName = orderName,
    //                newOrderTypeID = neworderType.newOrderTypeID,
    //                thirdPartyID = userID

    //                //thirdPartyID = thirdPartyGUID,
    //            };
    //            dbcontext.NewOrders.Add(neworder);


    //            process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.orderTypeID == neworderType.newOrderTypeID && x.isDefault == "1");
    //            Guid processID = pr.processID;

    //            newOrderFlow newOrderFlow = new newOrderFlow()
    //            {
    //                creationDate = DateTime.Now,
    //                actionDate = DateTime.Now,
    //                processID = processID,
    //                isFinished = "1",
    //                newOrderID = orderID,
    //                serventPhone = sendingUser.phone,
    //                userID = userID,
    //                terminationDate = DateTime.Now,
    //                changeStatusDate = DateTime.Now,
    //                formID = 5 // ینی فرم ثبت اطلاعات کاربر

    //            };




    //            dbcontext.newOrderFlows.Add(newOrderFlow);
    //            await dbcontext.SaveChangesAsync();
    //            newOrderFlow flowRow = await dbcontext.newOrderFlows.OrderByDescending(x => x.newOrderFlowID).FirstOrDefaultAsync();
    //            int flowID = flowRow.newOrderFlowID;
    //            foreach (var item in lstform)
    //            {
    //                string fieldToGo = "";
    //                switch (item.formItemTypeCode)
    //                {
    //                    case ("6"): // انتخابی
    //                        fieldToGo = "valueBool";

    //                        break;
    //                    case ("8"): // موقعیت 
    //                        fieldToGo = "valueString";
    //                        break;
    //                    case ("7"):// آپلود
    //                        fieldToGo = "valueString";
    //                        break;
    //                    case ("1"):// چند گزینه ای
    //                        fieldToGo = "valueGuid";
    //                        break;
    //                    case ("5"): // تاریخ
    //                        fieldToGo = "valueDateTime";
    //                        break;
    //                    case ("4"): // عددی
    //                        fieldToGo = "valueDuoble";
    //                        break;
    //                    case ("3"): // متنی
    //                        fieldToGo = "valueString";
    //                        break;
    //                    case ("2"): //  متنی عکس دار
    //                        fieldToGo = "valueString";
    //                        break;
    //                    case ("9"): //  متنی عکس دار
    //                        fieldToGo = "valueString";
    //                        break;
    //                    default:
    //                        fieldToGo = "valueString";
    //                        break;
    //                }
    //                newOrderFields fieldItem = new newOrderFields();
    //                fieldItem.formItemID = item.formItemID;
    //                fieldItem.name = item.key;
    //                fieldItem.newOrderFieldsID = Guid.NewGuid();
    //                fieldItem.newOrderFlowID = flowID;
    //                fieldItem.usedFeild = fieldToGo;
    //                fieldItem.valueInt = 0;
    //                fieldItem.valueDuoble = 0;
    //                fieldItem.valueDateTime = DateTime.Now;
    //                fieldItem.valueBool = false;
    //                fieldItem.valueGuid = new Guid();

    //                if (fieldToGo == "valueBool")
    //                    fieldItem.valueBool = Boolean.Parse(item.value);
    //                if (fieldToGo == "valueString")
    //                    fieldItem.valueString = item.value;
    //                if (fieldToGo == "valueDateTime")
    //                    fieldItem.valueDateTime = DateTime.Parse(item.value);
    //                if (fieldToGo == "valueGuid")
    //                {
    //                    List<string> lst = item.value.Split(':').ToList();
    //                    fieldItem.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                    fieldItem.valueGuid = new Guid(lst[0]);
    //                }
    //                if (fieldToGo == "valueDuoble")
    //                    fieldItem.valueDuoble = double.Parse(item.value);


    //                dbcontext.newOrderFields.Add(fieldItem);

    //            }
    //            await dbcontext.SaveChangesAsync();
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }

    //    private async Task<string> setNewProfile(getURLVM model, Guid userID)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);


    //            string fullname = lstform.SingleOrDefault(x => x.key == "fullname").value;
    //            string IDCode = lstform.SingleOrDefault(x => x.key == "ID").value;
    //            string image = lstform.Any(x => x.key == "image") ? lstform.SingleOrDefault(x => x.key == "image").value : "";

    //            IDCode = string.IsNullOrEmpty(IDCode) ? "" : IDCode;




    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);

    //            // formID 5 فرم ثبت اطلاعات
    //            //formID 6 فرم ثبت پروفایل

    //            int flowID = 0;
    //            using (Context dbcontext = new Context())
    //            {
    //                user userToAdd = await dbcontext.users.SingleOrDefaultAsync(x => x.name == fullname && (x.codeMelli == IDCode));
    //                Guid partnerID = Guid.NewGuid();
    //                if (userToAdd == null)
    //                {
    //                    string status = "0";
    //                    Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //                    Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;


    //                    // ثبت کاربر
    //                    user newuser = new user()
    //                    {
    //                        userID = partnerID,
    //                        phone = "",
    //                        name = fullname,
    //                        codeMelli = IDCode,
    //                        code = "9999", // num.ToString(),
    //                        userType = "0",
    //                        verifyStatusID = statusID,
    //                        workingStatusID = workingID
    //                    };
    //                    dbcontext.users.Add(newuser);
    //                    // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده

    //                    newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    newOrderType neworderType = await dbcontext.newOrderTypes.SingleOrDefaultAsync(x => x.orderTypeCode == 1);

    //                    rnd = new Random();
    //                    int month = rnd.Next(11111, 99999);
    //                    string orderName = fullname;

    //                    Guid orderID = Guid.NewGuid();
    //                    newOrder neworder = new newOrder()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        terminationDate = DateTime.Now,
    //                        newOrderID = orderID,
    //                        newOrderStatusID = neworderstatus.newOrderStatusID,
    //                        orderName = orderName,
    //                        newOrderTypeID = neworderType.newOrderTypeID,
    //                        thirdPartyID = partnerID,


    //                        //thirdPartyID = thirdPartyGUID,
    //                    };
    //                    dbcontext.NewOrders.Add(neworder);

    //                    process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.orderTypeID == neworderType.newOrderTypeID && x.isDefault == "1");
    //                    Guid processID = pr.processID;

    //                    newOrderFlow flowRow = await dbcontext.newOrderFlows.OrderByDescending(x => x.newOrderFlowID).FirstOrDefaultAsync();

    //                    // اینجا اطلاعات خود کاربر به عنوان نفر تازه با فلو جدید ایجاد میشود
    //                    newOrderFlow newUserFlow = new newOrderFlow()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        actionDate = DateTime.Now,
    //                        processID = processID,
    //                        isFinished = "1",
    //                        newOrderID = orderID,
    //                        serventPhone = "",
    //                        userID = partnerID,
    //                        terminationDate = DateTime.Now,
    //                        formID = 5, // ینی فرم ثبت پروفایل
    //                        flowStatusID = 5,
    //                        changeStatusDate = DateTime.Now

    //                    };
    //                    dbcontext.newOrderFlows.Add(newUserFlow);

    //                    await dbcontext.SaveChangesAsync();

    //                    // دیتاهای مرتبط با فلو کاربر باید ثبت شود همانهاییی که هست
    //                    List<formItem> fieldList = await dbcontext.formItems.Where(x => x.formID == 5).ToListAsync();
    //                    List<detailCollection> user5InfoDetail = new List<detailCollection>();
    //                    foreach (var item in fieldList)
    //                    {
    //                        if (item.itemName == "fullname")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 5,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = fullname,
    //                                formItemTypeCode = "3"


    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }
    //                        else if (item.itemName == "image")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 5,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = image,
    //                                formItemTypeCode = "3"

    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }

    //                    }
    //                    await doSaveForm(user5InfoDetail, newUserFlow.newOrderFlowID, dbcontext); // اینجا اطلاعات کاربر با ججزئیات ثبت می شود


    //                    // این فلو پرونده توسط کاربر تولید میشود و پرونده از جنس 6 برای اطلاعات زیر نفر
    //                    user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                    newOrderFlow sendingUserInfoFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.childFlows.Select(l => l.parentFlow)).Include(x => x.childFlows.Select(l => l.parentFlow.newOrderFlowServent)).SingleOrDefaultAsync(x => x.userID == sendingUser.userID && x.formID == 5); //  اینجا دکتر که داره کارارو پیش میبره


    //                    newOrderFlow childFIleFLow = new newOrderFlow()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        actionDate = DateTime.Now,
    //                        processID = processID,
    //                        isFinished = "1",
    //                        newOrderID = orderID,
    //                        serventPhone = sendingUser.phone,
    //                        userID = sendingUserInfoFlow.userID,
    //                        terminationDate = DateTime.Now,
    //                        formID = 6, // ینی فرم ثبت پروفایل
    //                        flowStatusID = 5,
    //                        changeStatusDate = DateTime.Now
    //                    };
    //                    dbcontext.newOrderFlows.Add(childFIleFLow);
    //                    await dbcontext.SaveChangesAsync();
    //                    // اطلاعات فرم قیمومیت توسط یوز ثبت می شود 
    //                    await doSaveForm(lstform, childFIleFLow.newOrderFlowID, dbcontext);


    //                    // ارتباط کاربر یا فرم قیمومیت ایجاد می شود
    //                    flowRelation nr = new flowRelation()
    //                    {
    //                        childID = sendingUserInfoFlow.newOrderFlowID,
    //                        parentID = newUserFlow.newOrderFlowID,
    //                        status = 1,
    //                        childEndDate = DateTime.Now,
    //                        childStartDate = DateTime.Now,
    //                        formID = 6
    //                    };

    //                    dbcontext.flowRelations.Add(nr);
    //                    await dbcontext.SaveChangesAsync();
    //                }

    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }
    //    private async Task<string> setNewPatient(getURLVM model, Guid userID)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);


    //            string fullname = lstform.SingleOrDefault(x => x.key == "fullname").value;
    //            string IDCode = lstform.SingleOrDefault(x => x.key == "ID").value;
    //            string phn = lstform.SingleOrDefault(x => x.key == "phone").value;

    //            IDCode = string.IsNullOrEmpty(IDCode) ? "" : IDCode;
    //            phn = string.IsNullOrEmpty(phn) ? "" : phn;



    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);

    //            // formID 5 فرم ثبت اطلاعات
    //            //formID 6 فرم ثبت پروفایل
    //            newOrderFlow newOrderFlow = new newOrderFlow();
    //            int flowID = 0;
    //            using (Context dbcontext = new Context())
    //            {
    //                user userToAdd = await dbcontext.users.SingleOrDefaultAsync(x => x.name == fullname && (x.codeMelli == IDCode || x.phone == phn));
    //                Guid partnerID = Guid.NewGuid();
    //                if (userToAdd == null)
    //                {
    //                    string status = "0";
    //                    Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //                    Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;


    //                    // ثبت کاربر
    //                    user newuser = new user()
    //                    {
    //                        userID = partnerID,
    //                        phone = phn,
    //                        name = fullname,
    //                        codeMelli = IDCode,
    //                        code = "9999", // num.ToString(),
    //                        userType = "0",
    //                        verifyStatusID = statusID,
    //                        workingStatusID = workingID
    //                    };
    //                    dbcontext.users.Add(newuser);
    //                    // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده

    //                    newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    newOrderType neworderType = await dbcontext.newOrderTypes.SingleOrDefaultAsync(x => x.orderTypeCode == 1);

    //                    rnd = new Random();
    //                    int month = rnd.Next(11111, 99999);
    //                    string orderName = fullname;

    //                    Guid orderID = Guid.NewGuid();
    //                    newOrder neworder = new newOrder()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        terminationDate = DateTime.Now,
    //                        newOrderID = orderID,
    //                        newOrderStatusID = neworderstatus.newOrderStatusID,
    //                        orderName = orderName,
    //                        newOrderTypeID = neworderType.newOrderTypeID,
    //                        thirdPartyID = partnerID,


    //                        //thirdPartyID = thirdPartyGUID,
    //                    };
    //                    dbcontext.NewOrders.Add(neworder);

    //                    process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.orderTypeID == neworderType.newOrderTypeID && x.isDefault == "1");
    //                    Guid processID = pr.processID;
    //                    newOrderFlow flowRow = await dbcontext.newOrderFlows.OrderByDescending(x => x.newOrderFlowID).FirstOrDefaultAsync();



    //                    newOrderFlow = new newOrderFlow()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        actionDate = DateTime.Now,
    //                        processID = processID,
    //                        isFinished = "1",
    //                        newOrderID = orderID,
    //                        serventPhone = phn,
    //                        userID = partnerID,
    //                        terminationDate = DateTime.Now,
    //                        formID = 5, // ینی فرم ثبت پروفایل
    //                        flowStatusID = 5,
    //                        changeStatusDate = DateTime.Now




    //                    };
    //                    dbcontext.newOrderFlows.Add(newOrderFlow);
    //                    // دیتاهای مرتبط با فلو کاربر باید ثبت شود همانهاییی که هست
    //                    List<formItem> fieldList = await dbcontext.formItems.Where(x => x.formID == 5).ToListAsync();
    //                    List<detailCollection> user5InfoDetail = new List<detailCollection>();
    //                    foreach (var item in fieldList)
    //                    {
    //                        if (item.itemName == "fullname")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 5,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = fullname

    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }
    //                        if (item.itemName == "phone")
    //                        {
    //                            detailCollection it = new detailCollection()
    //                            {
    //                                formID = 5,
    //                                formItemID = item.formItemID,
    //                                key = item.itemName,
    //                                value = phn

    //                            };
    //                            user5InfoDetail.Add(it);
    //                        }

    //                    }
    //                    await doSaveForm(user5InfoDetail, newOrderFlow.newOrderFlowID, dbcontext); // اینجا اطلاعات کاربر با ججزئیات ثبت می شود



    //                }
    //                else
    //                {
    //                    newOrderFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userToAdd.userID && x.formID == 5);

    //                }


    //                user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                newOrderFlow doctorInfoFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.childFlows.Select(l => l.parentFlow)).Include(x => x.childFlows.Select(l => l.parentFlow.newOrderFlowServent)).SingleOrDefaultAsync(x => x.userID == sendingUser.userID && x.formID == 7); //  اینجا دکتر که داره کارارو پیش میبره


    //                await dbcontext.SaveChangesAsync();
    //                flowRelation nr = new flowRelation()
    //                {
    //                    childID = newOrderFlow.newOrderFlowID,
    //                    parentID = doctorInfoFlow.newOrderFlowID,
    //                    status = 0,
    //                    childEndDate = DateTime.Now,
    //                    childStartDate = DateTime.Now,
    //                    formID = 7
    //                };

    //                dbcontext.flowRelations.Add(nr);
    //                await dbcontext.SaveChangesAsync();


    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }

    //    private async Task<string> setNewDoctor(getURLVM model, Guid userID)
    //    {
    //        try
    //        {
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);


    //            string fullname = lstform.SingleOrDefault(x => x.key.Contains("fullname")) != null ? lstform.SingleOrDefault(x => x.key.Contains("fullname")).value : "";
    //            string dphone = lstform.SingleOrDefault(x => x.key.Contains("phone")) != null ? lstform.SingleOrDefault(x => x.key.Contains("phone")).value : "";

    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);


    //            using (Context dbcontext = new Context())
    //            {


    //                user sendingUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                if (sendingUser.userType == "2")
    //                {

    //                    //List<newOrderFlow> lkjlk = dbcontext.newOrderFlows.Where(x => x.userID == userID && x.formID == 7).ToList();
    //                    int flowDoctorID = 0;
    //                    newOrderFlow docflow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userID && x.formID == 7);
    //                    if (docflow != null)
    //                    {
    //                        flowDoctorID = docflow.newOrderFlowID;
    //                        foreach (var item in lstform)
    //                        {
    //                            //List<newOrderFields> lkjlk = dbcontext.newOrderFields.Where(x => x.newOrderFlowID == docflow.newOrderFlowID && x.formItemID == item.formItemID).ToList();
    //                            newOrderFields neworderfiled = await dbcontext.newOrderFields.SingleOrDefaultAsync(x => x.newOrderFlowID == docflow.newOrderFlowID && x.formItemID == item.formItemID);
    //                            string fieldToGo = "";
    //                            switch (item.formItemTypeCode)
    //                            {
    //                                case ("6"): // انتخابی
    //                                    fieldToGo = "valueBool";

    //                                    break;
    //                                case ("8"): // موقعیت 
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                                case ("7"):// آپلود
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                                case ("1"):// چند گزینه ای
    //                                    fieldToGo = "valueGuid";
    //                                    break;
    //                                case ("5"): // تاریخ
    //                                    fieldToGo = "valueDateTime";
    //                                    break;
    //                                case ("4"): // عددی
    //                                    fieldToGo = "valueDuoble";
    //                                    break;
    //                                case ("3"): // متنی
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                                case ("2"): //  متنی عکس دار
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                                case ("9"): //  متنی عکس دار
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                                default:
    //                                    fieldToGo = "valueString";
    //                                    break;
    //                            }
    //                            if (neworderfiled == null)
    //                            {
    //                                neworderfiled = new newOrderFields();

    //                                neworderfiled.newOrderFlowID = docflow.newOrderFlowID;
    //                                neworderfiled.formItemID = item.formItemID;
    //                                neworderfiled.name = item.key;
    //                                neworderfiled.newOrderFieldsID = Guid.NewGuid();
    //                                neworderfiled.usedFeild = fieldToGo;
    //                                neworderfiled.valueInt = 0;
    //                                neworderfiled.valueDuoble = 0;
    //                                neworderfiled.valueDateTime = DateTime.Now;
    //                                neworderfiled.valueBool = false;
    //                                neworderfiled.valueGuid = new Guid();

    //                                if (fieldToGo == "valueBool")
    //                                    neworderfiled.valueBool = Boolean.Parse(item.value);
    //                                if (fieldToGo == "valueString")
    //                                    neworderfiled.valueString = item.value;
    //                                if (fieldToGo == "valueDateTime")
    //                                    neworderfiled.valueDateTime = DateTime.Parse(item.value);
    //                                if (fieldToGo == "valueGuid")
    //                                {
    //                                    List<string> lst = item.value.Split(':').ToList();
    //                                    neworderfiled.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                                    neworderfiled.valueGuid = new Guid(lst[0]);
    //                                }


    //                                if (fieldToGo == "valueDuoble")
    //                                    neworderfiled.valueDuoble = double.Parse(item.value);

    //                                dbcontext.newOrderFields.Add(neworderfiled);
    //                                await dbcontext.SaveChangesAsync();

    //                            }
    //                            else
    //                            {
    //                                if (fieldToGo == "valueBool")
    //                                    neworderfiled.valueBool = Boolean.Parse(item.value);
    //                                if (fieldToGo == "valueString")
    //                                    neworderfiled.valueString = item.value;
    //                                if (fieldToGo == "valueDateTime")
    //                                    neworderfiled.valueDateTime = DateTime.Parse(item.value);
    //                                if (fieldToGo == "valueGuid")
    //                                {
    //                                    List<string> lst = item.value.Split(':').ToList();
    //                                    neworderfiled.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                                    neworderfiled.valueGuid = new Guid(lst[0]);
    //                                }


    //                                if (fieldToGo == "valueDuoble")
    //                                    neworderfiled.valueDuoble = double.Parse(item.value);

    //                                //dbcontext.newOrderFields.Add(neworderfiled);
    //                                await dbcontext.SaveChangesAsync();
    //                            }
    //                        }
    //                        return "";
    //                    }


    //                }
    //                string status = "0";
    //                verifyStatus statusquery = await dbcontext.verifyStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                Guid statusID = statusquery.verifyStatusID;
    //                List<userWorkingStatus> workingquery = await dbcontext.userWorkingStatuses.ToListAsync();
    //                Guid workingID = workingquery.First().workingStatusID;
    //                Guid partnerID = Guid.NewGuid();

    //                user newuser = await dbcontext.users.SingleOrDefaultAsync(x => x.phone == sendingUser.phone);
    //                // ثبت کاربر
    //                if (newuser == null)
    //                {
    //                    newuser = new user()
    //                    {
    //                        userID = partnerID,
    //                        phone = dphone,
    //                        name = fullname,
    //                        code = "9999", // num.ToString(),
    //                        userType = "2",// doctor 2 
    //                        verifyStatusID = statusID,
    //                        workingStatusID = workingID
    //                    };
    //                    dbcontext.users.Add(newuser);
    //                    await dbcontext.SaveChangesAsync();

    //                    // ثبت اردر جدید و فلو جدید که فرم ارسالیو تشکیل میده


    //                }





    //                DateTime timetosave = DateTime.Now;
    //                newOrderFlow newOrderFlow = new newOrderFlow()
    //                {
    //                    creationDate = timetosave,
    //                    actionDate = timetosave,
    //                    isFinished = "1",
    //                    serventPhone = sendingUser.phone,
    //                    userID = partnerID,
    //                    terminationDate = timetosave,
    //                    formID = 7,
    //                    changeStatusDate = DateTime.Now,
    //                };
    //                dbcontext.newOrderFlows.Add(newOrderFlow);

    //                await dbcontext.SaveChangesAsync();
    //                newOrderFlow flowRow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.userID == partnerID && x.formID == 7);
    //                int flowID = flowRow.newOrderFlowID;
    //                foreach (var item in lstform)
    //                {
    //                    string fieldToGo = "";
    //                    switch (item.formItemTypeCode)
    //                    {
    //                        case ("6"): // انتخابی
    //                            fieldToGo = "valueBool";

    //                            break;
    //                        case ("8"): // موقعیت 
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("7"):// آپلود
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("1"):// چند گزینه ای
    //                            fieldToGo = "valueGuid";
    //                            break;
    //                        case ("5"): // تاریخ
    //                            fieldToGo = "valueDateTime";
    //                            break;
    //                        case ("4"): // عددی
    //                            fieldToGo = "valueDuoble";
    //                            break;
    //                        case ("3"): // متنی
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("2"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("9"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        default:
    //                            fieldToGo = "valueString";
    //                            break;
    //                    }
    //                    if (!string.IsNullOrEmpty(item.value))
    //                    {
    //                        foreach (var dddd in item.value.Trim(',').Split(',').ToList())
    //                        {
    //                            newOrderFields fieldItem = new newOrderFields();
    //                            fieldItem.formItemID = item.formItemID;
    //                            fieldItem.name = item.key;
    //                            fieldItem.newOrderFieldsID = Guid.NewGuid();
    //                            fieldItem.newOrderFlowID = flowID;
    //                            fieldItem.usedFeild = fieldToGo;
    //                            fieldItem.valueInt = 0;
    //                            fieldItem.valueDuoble = 0;
    //                            fieldItem.valueDateTime = DateTime.Now;
    //                            fieldItem.valueBool = false;
    //                            fieldItem.valueGuid = new Guid();

    //                            if (fieldToGo == "valueBool")
    //                                fieldItem.valueBool = Boolean.Parse(item.value);
    //                            if (fieldToGo == "valueString")
    //                                fieldItem.valueString = item.value;
    //                            if (fieldToGo == "valueDateTime")
    //                                fieldItem.valueDateTime = DateTime.Parse(item.value);
    //                            if (fieldToGo == "valueGuid")
    //                            {
    //                                List<string> lst = item.value.Split(':').ToList();
    //                                fieldItem.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                                fieldItem.valueGuid = new Guid(lst[0]);
    //                            }

    //                            if (fieldToGo == "valueDuoble")
    //                                fieldItem.valueDuoble = double.Parse(item.value);


    //                            dbcontext.newOrderFields.Add(fieldItem);
    //                        }
    //                    }



    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        string phone = "";
    //        return phone;
    //    }

    //    private async Task<string> finalizePayment(string payment, Guid userID, int flowID)
    //    {

    //        // تغییر استتوس فلو
    //        // افزودن کاربر به دکتر
    //        // ثبت سند مالی
    //        // هندل کردن زمان؟
    //        // 
    //        using (Context dbcontext = new Context())
    //        {
    //            if (payment == "1")  // ینی پرداخت با کد تخفیف
    //            {

    //                newOrderFlow pardakhtFlow = await dbcontext.newOrderFlows.Include(x => x.NewOrderFields).SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                newOrderFields pardakhtPlan = pardakhtFlow.NewOrderFields.SingleOrDefault(x => x.name == "plan");
    //                orderOption optionSelected = await dbcontext.orderOptions.SingleOrDefaultAsync(x => x.orderOptionID == pardakhtPlan.valueGuid);
    //                string val = optionSelected.Value;
    //                string month = val.Trim(',').Split(',').ToList().Last();



    //                form docForm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == pardakhtFlow.formID);
    //                // فلو ثبت دکتر
    //                newOrderFlow docInfoFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == docForm.userID && x.formID == 7);
    //                // فلو ثبت یوز
    //                newOrderFlow userInfoFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userID && x.formID == 5);

    //                flowRelation fln = new flowRelation()
    //                {
    //                    childID = userInfoFlow.newOrderFlowID,
    //                    parentID = docInfoFlow.newOrderFlowID,
    //                    formID = 7,
    //                    status = 1,
    //                    childStartDate = DateTime.Now,
    //                    childEndDate = DateTime.Now.AddMonths(Int32.Parse(month))
    //                };

    //                dbcontext.flowRelations.Add(fln);

    //                await dbcontext.SaveChangesAsync();
    //                docInfoFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.parentFlows).SingleOrDefaultAsync(x => x.userID == docForm.userID && x.formID == 7);
    //                userInfoFlow = await dbcontext.newOrderFlows.Include(x => x.childFlows).Include(x => x.parentFlows).SingleOrDefaultAsync(x => x.userID == userID && x.formID == 5);

    //            }

    //        }


    //        return "";
    //    }
    //    private async Task<paymentVM> paymentProcess(getURLVM model, Guid userID, string flowID)
    //    {
    //        string url = "";
    //        List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //        var plan = lstform.SingleOrDefault(x => x.key == "plan");
    //        var discount = lstform.SingleOrDefault(x => x.key == "discount");
    //        using (Context dbcontext = new Context())
    //        {
    //            List<string> lst = plan.value.Trim(',').Split(':').ToList();
    //            Guid opID = new Guid(lst[0]);
    //            var orderOp = await dbcontext.orderOptions.SingleOrDefaultAsync(x => x.orderOptionID == opID);
    //        }
    //        paymentVM response = new paymentVM();
    //        response.payment = "1"; // ینی پرداخت با کد تخفیف
    //        response.status = 200;
    //        return response;
    //    }
    //    private async Task<string> setUserDynamicFormData(getURLVM model, Guid userID)
    //    {
    //        List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);

    //        int formID = lstform.First().formID;
    //        using (Context dbcontext = new Context())
    //        {
    //            form frm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == formID);
    //            List<user> userlist = await dbcontext.users.ToListAsync();
    //            user selectedUser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            int baseFormID = dynamicMethods.getBaseFlowID(selectedUser.userType);

    //            // انیجا فلو کاربر باید پیدا بشه که به اردر کاربر فلو اضافه بشه
    //            newOrderFlow userFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == userID && x.formID == baseFormID);//اولین فلو ثبت اطلاعات کاربر


    //            DateTime creationTIME = DateTime.Now;
    //            newOrderFlow newOrderFlow = new newOrderFlow()
    //            {
    //                creationDate = creationTIME,
    //                actionDate = DateTime.Now,
    //                isFinished = "1",
    //                serventPhone = selectedUser.phone,
    //                userID = userID,
    //                terminationDate = DateTime.Now,
    //                formID = formID,
    //                flowStatusID = 1,
    //                formType = frm.formTypeID,
    //                changeStatusDate = DateTime.Now,

    //            };
    //            dbcontext.newOrderFlows.Add(newOrderFlow);
    //            await dbcontext.SaveChangesAsync();
    //            //newOrderFlow flowRow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x=>x.creationDate == creationTIME && x.formType == frm.formTypeID && x.formID == formID);
    //            int flowID = newOrderFlow.newOrderFlowID;

    //            flowRelation nr = new flowRelation()
    //            {
    //                childID = userFlow.newOrderFlowID,
    //                parentID = newOrderFlow.newOrderFlowID,
    //                status = 1,
    //                childEndDate = DateTime.Now,
    //                childStartDate = DateTime.Now,
    //                formID = formID
    //            };
    //            dbcontext.flowRelations.Add(nr);



    //            if (model.data.ContainsKey("relation"))
    //            {
    //                flowRelation nr2 = new flowRelation()
    //                {
    //                    childID = Int32.Parse(model.data["relation"]),
    //                    parentID = newOrderFlow.newOrderFlowID,
    //                    status = 1,
    //                    childEndDate = DateTime.Now,
    //                    childStartDate = DateTime.Now,
    //                    formID = formID
    //                };
    //                dbcontext.flowRelations.Add(nr2);



    //                // چون ریلیشن وجود داره میخوایم لاگ بندازیم
    //                // فعلا برای آیتم هایی تکی هستن لاگ نمیندازیم
    //                // ینی مثلا تولید یک پزشک لاگ نداره
    //                string actiontitle = "";
    //                // تایتل لاگ باید اسم فرم باشد
    //                // اگر فرم انتخاب اقدام باشد تایتل باید مقدار اقدام مورد نظر باشد
    //                // بنابراین اگر فرم ثبت اقدام برابر با 31 بود با مقدار 
    //                // یکی از آیتم های ارسالی با نام
    //                // option
    //                // باید انتخاب بشه و مقدارش به عنوان تایتل استفاده بشه
    //                // فقط پزشک میتونه به جز 31 لاگ بندازه پس اگه 31 نبود لاگ ننداز
    //                if (formID == 31)
    //                {
    //                    var optionRow = lstform.FirstOrDefault(x => x.key == "option");
    //                    if (optionRow != null)
    //                    {
    //                        var liststring = optionRow.value.Trim(':').Split(':').ToList();
    //                        actiontitle = liststring[1];
    //                    }
    //                    flowLog newflowlog = new flowLog()
    //                    {
    //                        actionFlowID = flowID,
    //                        baseFlowID = Int32.Parse(model.data["relation"]),
    //                        actorFlowID = userFlow.newOrderFlowID,
    //                        actorUserType = selectedUser.userType,
    //                        formID = formID,
    //                        userID = selectedUser.userID,
    //                        creationDate = DateTime.Now,
    //                        actionTitle = actiontitle,

    //                    };
    //                    dbcontext.FlowLogs.Add(newflowlog);
    //                }
    //                else
    //                {

    //                    form form = await dbcontext.forms.FirstOrDefaultAsync(x => x.formID == formID);
    //                    actiontitle = form.title;
    //                    if (selectedUser.userType == "2")
    //                    {
    //                        flowLog newflowlog = new flowLog()
    //                        {
    //                            actionFlowID = flowID,
    //                            baseFlowID = Int32.Parse(model.data["relation"]),
    //                            actorFlowID = userFlow.newOrderFlowID,
    //                            actorUserType = selectedUser.userType,
    //                            formID = formID,
    //                            userID = selectedUser.userID,
    //                            creationDate = DateTime.Now,
    //                            actionTitle = actiontitle,

    //                        };
    //                        dbcontext.FlowLogs.Add(newflowlog);
    //                    }
    //                }

    //            }
    //            if (model.data.ContainsKey("userToken"))
    //            {
    //                string ut = model.data["userToken"];
    //                Guid relatedUser = new Guid(ut);
    //                newOrderFlow urelatedFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.userID == relatedUser && x.formID == 5);//اولین فلو ثبت اطلاعات کاربر

    //                flowRelation nr2 = new flowRelation()
    //                {
    //                    childID = urelatedFlow.newOrderFlowID,
    //                    parentID = newOrderFlow.newOrderFlowID,
    //                    status = 1,
    //                    childEndDate = DateTime.Now,
    //                    childStartDate = DateTime.Now,
    //                    formID = formID
    //                };
    //                dbcontext.flowRelations.Add(nr2);
    //            }

    //            await dbcontext.SaveChangesAsync();



    //            await doSaveForm(lstform, flowID, dbcontext);
    //            int wholeFormID = lstform.First().formID;
    //            form formSent = await dbcontext.forms.FirstOrDefaultAsync(x => x.formID == wholeFormID);
    //            if (formSent.formTypeID == 3)
    //            {
    //                // دریافت اطلاعات کاربر 
    //                List<newOrderFields> filesList = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == userFlow.newOrderFlowID).ToListAsync();
    //                bool isOK = true;
    //                List<string> usedOne = new List<string>();
    //                foreach (var item in lstform)
    //                {
    //                    if (usedOne.Contains(item.key))
    //                    {
    //                        continue;
    //                    }
    //                    usedOne.Add(item.key);
    //                    var fildMinList = filesList.Where(x => x.name.Contains(item.key));
    //                    if (fildMinList != null)
    //                    {
    //                        if (fildMinList.Count() > 2)
    //                        {
    //                            var minList = fildMinList.OrderByDescending(x => x.valueDuoble).Where(x => x.name.Contains("Min")).Select(x => x.valueDuoble).ToList();
    //                            var maxList = fildMinList.OrderByDescending(x => x.valueDuoble).Where(x => x.name.Contains("Max")).Select(x => x.valueDuoble).ToList();


    //                            var insertedListquery = lstform.Where(x => x.key == item.key).Select(x => x.value).ToList();
    //                            List<double> insertedList = insertedListquery.Select(x => double.Parse(x)).OrderByDescending(x => x).ToList();

    //                            if (insertedList.First() < minList.First() || insertedList.First() > maxList.First() || insertedList.Last() < minList.Last() || insertedList.Last() > maxList.Last())
    //                            {
    //                                isOK = false;
    //                                break;
    //                            }

    //                        }
    //                        else
    //                        {

    //                            var List = fildMinList.OrderByDescending(x => x.valueDuoble).Select(x => x.valueDuoble).ToList();

    //                            var insertedListquery = lstform.Where(x => x.key == item.key).Select(x => x.value).ToList();
    //                            List<double> insertedList = insertedListquery.Select(x => double.Parse(x)).OrderByDescending(x => x).ToList();

    //                            if (insertedList.First() > List.First() || insertedList.Last() < List.Last())
    //                            {
    //                                isOK = false;
    //                                break;
    //                            }

    //                        }
    //                    }


    //                }

    //                if (isOK == true)
    //                {
    //                    newOrderFlow.flowStatusID = 2;
    //                    await dbcontext.SaveChangesAsync();
    //                }

    //                // ینی نوتیف برای ارسال فرم پالس
    //                await sendNotif("3", "", "فرم ارزیابی جدیدی ثبت شده است", "reload", "app/homePageMeduim");
    //            }
    //            //;
    //            return flowID.ToString();
    //        }

    //        return "";
    //    }
    //    private async Task<string> changeFlowStatus(getURLVM model, Guid userID)
    //    {
    //        string response = "";
    //        int flowID = Int32.Parse(model.data["flowID"]);
    //        int status = Int32.Parse(model.data["status"]);
    //        using (Context dbcontext = new Context())
    //        {
    //            newOrderFlow flow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //            flow.flowStatusID = status;
    //            flow.changeStatusDate = DateTime.Now;
    //            await dbcontext.SaveChangesAsync();
    //        }
    //        return response;
    //    }
    //    private async Task<string> doSaveForm(List<detailCollection> collection, int flowID, Context dbcontext)
    //    {
    //        foreach (var item in collection)
    //        {
    //            string fieldToGo = "";
    //            switch (item.formItemTypeCode)
    //            {
    //                case ("6"): // انتخابی
    //                    fieldToGo = "valueBool";
    //                    break;
    //                case ("8"): // موقعیت 
    //                    fieldToGo = "valueString";
    //                    break;
    //                case ("7"):// آپلود
    //                    fieldToGo = "valueString";
    //                    break;
    //                case ("1"):// چند گزینه ای
    //                    fieldToGo = "valueGuid";
    //                    break;
    //                case ("5"): // تاریخ
    //                    fieldToGo = "valueDateTime";
    //                    break;
    //                case ("4"): // عددی
    //                    fieldToGo = "valueDuoble";
    //                    break;
    //                case ("3"): // متنی
    //                    fieldToGo = "valueString";
    //                    break;
    //                case ("2"): //  متنی عکس دار
    //                    fieldToGo = "valueString";
    //                    break;
    //                case ("9"): //  متنی عکس دار
    //                    fieldToGo = "valueString";
    //                    break;

    //                default:
    //                    fieldToGo = "valueString";
    //                    break;

    //            }
    //            if (!string.IsNullOrEmpty(item.value))
    //            {
    //                item.value = methods.PersianToEnglish(item.value);
    //                foreach (var dddd in item.value.Trim(',').Split(',').ToList())
    //                {
    //                    newOrderFields fieldItem = new newOrderFields();
    //                    fieldItem.formItemID = item.formItemID;
    //                    fieldItem.name = item.key;
    //                    fieldItem.newOrderFieldsID = Guid.NewGuid();
    //                    fieldItem.newOrderFlowID = flowID;
    //                    fieldItem.usedFeild = fieldToGo;
    //                    fieldItem.valueInt = 0;
    //                    fieldItem.valueDuoble = 0;
    //                    fieldItem.valueDateTime = DateTime.Now;
    //                    fieldItem.valueBool = false;
    //                    fieldItem.valueGuid = new Guid();

    //                    if (fieldToGo == "valueBool")
    //                        fieldItem.valueBool = Boolean.Parse(item.value);
    //                    if (fieldToGo == "valueString")
    //                    {
    //                        //if (item.formItemTypeCode == "9")
    //                        //{
    //                        //    string timestamp = item.value.Trim().Split(':').ToList().Last();
    //                        //    try
    //                        //    {
    //                        //        double time = double.Parse(timestamp) / 1000;
    //                        //        string persianTime = dateTimeConvert.UnixTimeStampToDateTime(time).ToPersianDateString();
    //                        //        fieldItem.valueString = persianTime;
    //                        //    }
    //                        //    catch (Exception)
    //                        //    {

    //                        //        fieldItem.valueString = item.value;
    //                        //    }
    //                        //}
    //                        //else
    //                        //{
                               
    //                        //}
    //                        fieldItem.valueString = item.value;
    //                    }


    //                    if (fieldToGo == "valueDateTime")
    //                        fieldItem.valueDateTime = DateTime.Parse(item.value);
    //                    if (fieldToGo == "valueGuid")
    //                    {
    //                        List<string> lst = item.value.Split(':').ToList();
    //                        fieldItem.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                        fieldItem.valueGuid = new Guid(lst[0]);
    //                    }

    //                    if (fieldToGo == "valueDuoble")
    //                        fieldItem.valueDuoble = double.Parse(item.value);


    //                    dbcontext.newOrderFields.Add(fieldItem);
    //                }
    //            }



    //        }
    //        await dbcontext.SaveChangesAsync();
    //        return "";
    //    }
    //    private async Task<int> getNewProfileFLowFromOrder(string orderID, string phone)
    //    {
    //        int flowID = 0;
    //        Guid odguid = new Guid(orderID);
    //        using (Context dbcontext = new Context())
    //        {
    //            var query = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderID == odguid && x.serventPhone == phone);
    //            flowID = query.newOrderFlowID;
    //        }
    //        return flowID;
    //    }

    //    private async Task<List<flowDetailAll>> getDataFromFlow(getURLVM model)
    //    {
    //        List<flowDetailAll> lst = new List<flowDetailAll>();
    //        string flows = model.data["flows"];
    //        string classname = model.data["class"];

    //        if (flows != null)
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                List<int> values = flows.Split(',').Select(s => Int32.Parse(s)).ToList();
    //                List<newOrderFieldsVM> allFields = await dbcontext.newOrderFields.Where(x => values.Contains(x.newOrderFlowID)).Select(x => new newOrderFieldsVM { flowID = x.newOrderFlowID, name = x.name, usedFeild = x.usedFeild, valueBool = x.valueBool, valueDateTime = x.valueDateTime, valueDuoble = x.valueDuoble, valueGuid = x.valueGuid, valueInt = x.valueInt, valueString = x.valueString }).ToListAsync();
    //                foreach (var item in flows.Split(',').ToList())
    //                {
    //                    flowDetailAll eachFlow = new flowDetailAll();
    //                    int itemint = Int32.Parse(item);
    //                    Dictionary<string, string> dic = new Dictionary<string, string>();
    //                    dic.Add("ID", item);
    //                    foreach (var field in classname.Split(',').ToList())
    //                    {
    //                        string firstPart = field.Split('_').ToList()[0];
    //                        List<newOrderFieldsVM> neworderfield = allFields.Where(x => x.flowID == itemint && x.name.Contains(firstPart)).ToList();
    //                        if (neworderfield != null)
    //                        {
    //                            string rfinal = "";
    //                            foreach (var insertedItem in neworderfield)
    //                            {
    //                                if (insertedItem.usedFeild == "valueString" || insertedItem.usedFeild == "valueGuid")
    //                                    rfinal += insertedItem.valueString;
    //                                else if (insertedItem.usedFeild == "valueBool")
    //                                {
    //                                    rfinal += insertedItem.valueBool == true ? "1" : "0";
    //                                }
    //                                else if (insertedItem.usedFeild == "valueDateTime")
    //                                {
    //                                    rfinal += insertedItem.valueDateTime.ToString();
    //                                }
    //                                else if (insertedItem.usedFeild == "valueDuoble")
    //                                {
    //                                    rfinal += insertedItem.valueDuoble.ToString();
    //                                }
    //                            }

    //                            dic.Add(field, rfinal);

    //                        }


    //                    }
    //                    eachFlow.allData = dic;
    //                    lst.Add(eachFlow);
    //                }


    //            }

    //        }

    //        return lst;
    //    }







    //    private async Task<profileVM> getUserInfoHandler(string userID, Context dbcontext)
    //    {
    //        Guid guid = new Guid(userID);
    //        profileVM model = new profileVM();
    //        var users = await dbcontext.users.Where(x => x.userID == guid).Select(x => new profileVM { profileNameLabel_textsrt = !string.IsNullOrEmpty(x.name) ? "Hello " + x.name : "Hello " + x.phone }).ToListAsync();
    //        if (users != null)
    //        {
    //            model = users.First();
    //        }
    //        return model;
    //    }
    //    private async Task<string> handleRegistration(getURLVM model,string phoneInserted)
    //    {
    //        string phone = "";
    //        try
    //        {
    //            if (!string.IsNullOrEmpty(phoneInserted))
    //            {
    //                phone = phoneInserted;
    //            }
    //            else
    //            {
    //                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                if (lstform != null)
    //                {
    //                    if (lstform.Count() > 0)
    //                    {
    //                        phone = lstform.First().value;
    //                    }
    //                }
    //            }

    //            responseModel output = new responseModel();
    //            string outputstring = "";
    //            Random rnd = new Random();
    //            int num = rnd.Next(1111, 9999);


    //            using (Context dbcontext = new Context())
    //            {


    //                //Guid Userguid = new Guid("5417296b-b07e-404a-bc71-f04dc8baac2f");

    //                //user user = dbcontext.users.SingleOrDefault(x => x.userID == Userguid);
    //                //dbcontext.users.Remove(user);
    //                //dbcontext.SaveChanges();
    //                string finalPhone = methods.PersianToEnglish(phone);
    //                user myuser = dbcontext.users.SingleOrDefault(x => x.phone == finalPhone);
    //                if (myuser != null)
    //                {
    //                    myuser.code = "9999"; // num.ToString(),
    //                    dbcontext.SaveChanges();
    //                }
    //                else
    //                {

    //                    //string status = "0";
    //                    //Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //                    //Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;
    //                    //Guid uid = Guid.NewGuid();
    //                    //user newuser = new user()
    //                    //{
    //                    //    userID = uid,
    //                    //    phone = finalPhone,
    //                    //    name = "",
    //                    //    code = "9999", // num.ToString(),
    //                    //    userType = "0",
    //                    //    verifyStatusID = statusID,
    //                    //    workingStatusID = workingID
    //                    //};
    //                    //dbcontext.users.Add(newuser);
    //                    //dbcontext.SaveChanges();
    //                    //await setUserProfile(null, uid, dbcontext);
    //                }


    //            }
    //        }
    //        catch (Exception e)
    //        {

                
    //        }
           
            
    //        return phone;
    //    }

    //    private async Task<responseModel> handleSetCode(getURLVM model)
    //    {
    //        string phone = model.data["phone"];
    //        List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //        string code = lstform.First().value;
    //        string token = "";
    //        responseModel output = new responseModel();
    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                string finalPhone = methods.PersianToEnglish(phone);
    //                string finalcode = methods.PersianToEnglish(code);
    //                user myuser = dbcontext.users.SingleOrDefault(x => x.phone == finalPhone && x.code == finalcode);
    //                if (myuser != null)
    //                {
    //                    output.message = TokenManager.GenerateToken(phone, myuser.userID.ToString());
    //                    output.status = 200;

    //                }
    //                else
    //                {
    //                    output.message = "Invalid User.";
    //                    output.status = 400;
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                throw;
    //            }

    //        }
    //        return output;
    //    }

    //    [spalshAuthentication]
    //    private async Task<initDataVM> setTailorForm(getURLVM model, Guid userID)
    //    {

    //        initDataVM initdatamodel = new initDataVM();
    //        Dictionary<string, string> finaldic = new Dictionary<string, string>();
    //        if (model.initdata != null)
    //        {
    //            foreach (var item in model.initdata)
    //            {
    //                if (!finaldic.ContainsKey(item.Key))
    //                    finaldic.Add(item.Key, item.Value);
    //            }
    //        }
    //        if (model.data != null)
    //        {
    //            foreach (var item in model.data)
    //            {
    //                if (!finaldic.ContainsKey(item.Key))
    //                    finaldic.Add(item.Key, item.Value);
    //            }
    //        }

    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                var userPhoneQuery = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //                string userPhone = userPhoneQuery.phone;
    //                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                Guid orderID = finaldic.ContainsKey("orderID") ? new Guid(finaldic["orderID"]) : Guid.NewGuid();
    //                Guid processID = finaldic.ContainsKey("processID") ? new Guid(finaldic["processID"]) : Guid.NewGuid();
    //                int flowID = finaldic.ContainsKey("flowID") ? Int32.Parse(finaldic["flowID"]) : 0;
    //                //Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");
    //                DateTime now = DateTime.Now;
    //                if (!finaldic.ContainsKey("orderID"))
    //                {
    //                    // یک نیو اردر ایجاد میکنیم

    //                    newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");


    //                    Random rnd = new Random();
    //                    int month = rnd.Next(11111, 99999);
    //                    string orderName = month.ToString();
    //                    detailCollection nameItem = lstform.SingleOrDefault(x => x.key == "name");
    //                    if (nameItem != null)
    //                    {
    //                        orderName = nameItem.value;
    //                    }

    //                    newOrder neworder = new newOrder()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        terminationDate = DateTime.Now,
    //                        newOrderID = orderID,
    //                        newOrderStatusID = neworderstatus.newOrderStatusID,
    //                        orderName = orderName,

    //                        //thirdPartyID = thirdPartyGUID,
    //                    };
    //                    dbcontext.NewOrders.Add(neworder);
    //                    //newOrder checkorder = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.orderName == model.name);
    //                    //if (checkorder == null)
    //                    //{

    //                    //}
    //                    await dbcontext.SaveChangesAsync();
    //                }// 



    //                newOrder orderSelected = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
    //                newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                orderSelected.newOrderStatusID = stat.newOrderStatusID;

    //                if (!finaldic.ContainsKey("processID")) //
    //                {
    //                    process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
    //                    processID = pr.processID;
    //                }


    //                if (finaldic.ContainsKey("flowID"))
    //                {
    //                    newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == flowID);
    //                    selectedflow.isFinished = "1";


    //                }
    //                else
    //                {
                        
    //                    newOrderFlow newOrderFlow = new newOrderFlow()
    //                    {
    //                        creationDate = now,
    //                        actionDate = now,
    //                        processID = processID,
    //                        isFinished = "1",
    //                        newOrderID = orderID,
    //                        serventPhone = userPhone,
    //                        userID = userID,
    //                        terminationDate = now,
    //                        changeStatusDate = now,
    //                    };
    //                    dbcontext.newOrderFlows.Add(newOrderFlow);
    //                }

    //                await dbcontext.SaveChangesAsync();
    //                DateTime nowend = now.AddMilliseconds(999);
    //                newOrderFlow lastflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.creationDate >= now && x.creationDate< nowend && x.userID == userID) ;
    //                foreach (var item in lstform)
    //                {
    //                    string fieldToGo = "";
    //                    switch (item.formItemTypeCode)
    //                    {
    //                        case ("6"): // انتخابی
    //                            fieldToGo = "valueBool";
    //                            break;
    //                        case ("8"): // موقعیت 
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("7"):// آپلود
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("1"):// چند گزینه ای
    //                            fieldToGo = "valueGuid";
    //                            break;
    //                        case ("5"): // تاریخ
    //                            fieldToGo = "valueDateTime";
    //                            break;
    //                        case ("4"): // عددی
    //                            fieldToGo = "valueDuoble";
    //                            break;
    //                        case ("3"): // متنی
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("2"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("9"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        default:
    //                            fieldToGo = "valueString";
    //                            break;
    //                    }
    //                    newOrderFields fieldItem = new newOrderFields();
    //                    fieldItem.formItemID = item.formItemID;
    //                    fieldItem.name = item.key;
    //                    fieldItem.newOrderFieldsID = Guid.NewGuid();
    //                    fieldItem.newOrderFlowID = lastflow.newOrderFlowID ;
    //                    fieldItem.usedFeild = fieldToGo;
    //                    fieldItem.valueInt = 0;
    //                    fieldItem.valueDuoble = 0;
    //                    fieldItem.valueDateTime = DateTime.Now;
    //                    fieldItem.valueBool = false;
    //                    fieldItem.valueGuid = new Guid();

    //                    if (fieldToGo == "valueBool")
    //                        fieldItem.valueBool = Boolean.Parse(item.value);
    //                    if (fieldToGo == "valueString")
    //                        fieldItem.valueString = item.value;
    //                    if (fieldToGo == "valueDateTime")
    //                        fieldItem.valueDateTime = DateTime.Parse(item.value);
    //                    if (fieldToGo == "valueGuid")

    //                    {
    //                        List<string> lst = item.value.Split(':').ToList();
    //                        fieldItem.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                        fieldItem.valueGuid = new Guid(lst[0]);
    //                    }
    //                    if (fieldToGo == "valueDuoble")
    //                        fieldItem.valueDuoble = double.Parse(item.value);


    //                    dbcontext.newOrderFields.Add(fieldItem);

    //                }

    //                await dbcontext.SaveChangesAsync();


    //            }
    //        }
    //        catch(Exception e)
    //        {

    //        }
    //        return initdatamodel;
    //    }
    //    private async Task<initDataVM> setNewFlow(getURLVM model, Guid userID)
    //    {
    //        initDataVM initdatamodel = new initDataVM();
    //        Dictionary<string, string> finaldic = new Dictionary<string, string>();
    //        if (model.initdata != null)
    //        {
    //            foreach (var item in model.initdata)
    //            {
    //                finaldic.Add(item.Key, item.Value);
    //            }
    //        }
    //        if (model.data != null)
    //        {
    //            foreach (var item in model.data)
    //            {
    //                finaldic.Add(item.Key, item.Value);
    //            }
    //        }

    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                string phone = finaldic.ContainsKey("phone") ? finaldic["phone"] : "";
    //                if (finaldic.ContainsKey("serventID"))
    //                {
    //                    var phoneList = finaldic["serventID"].Split(':').ToList();
    //                    if (phoneList.Count > 1)
    //                    {
    //                        phone = phoneList[1];
    //                    }
    //                }
    //                DateTime actinDate = Classes.dateTimeConvert.UnixTimeStampToDateTime(double.Parse(finaldic["actionDate"]));
    //                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //                Guid orderID = new Guid(lstform.SingleOrDefault(x => x.key == "orderList").value.Split(':').ToList().First());
    //                Guid processID = new Guid(lstform.SingleOrDefault(x => x.key == "processList").value.Split(':').ToList().First());



    //                newOrderFlow newOrderFlow = new newOrderFlow()
    //                {
    //                    creationDate = DateTime.Now,
    //                    processID = processID,
    //                    isFinished = "0",
    //                    isAccepted = "0",
    //                    newOrderID = orderID,
    //                    serventPhone = phone,
    //                    userID = userID,
    //                    terminationDate = DateTime.Now,
    //                    actionDate = actinDate.Date,
    //                    changeStatusDate = DateTime.Now,

    //                };
    //                dbcontext.newOrderFlows.Add(newOrderFlow);
    //                await dbcontext.SaveChangesAsync();

    //                newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
    //                newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

    //                order.newOrderStatusID = stat.newOrderStatusID;

    //                //user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == phone && x.userType == "1");
    //                //Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
    //                //servent.workingStatusID = ustatuid;

    //                await dbcontext.SaveChangesAsync();



    //            }
    //        }
    //        catch
    //        {

    //        }
    //        return initdatamodel;
    //    }

    //    private async Task<string> editProfileHandler(getURLVM model, Guid userID)
    //    {
    //        Dictionary<string, string> finaldic = new Dictionary<string, string>();
    //        using (Context dbcontext = new Context())
    //        {
    //            user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //            string name = lstform.SingleOrDefault(x => x.key == "Fullname").value;
    //            user.name = name;
    //            await dbcontext.SaveChangesAsync();
    //        }
    //        return "";
    //    }
    //    private async Task<initDataVM> changeFlowStatusByClientHandler(getURLVM model, Guid userID, string status)
    //    {
    //        initDataVM initdatamodel = new initDataVM();
    //        Dictionary<string, string> finaldic = new Dictionary<string, string>();
    //        string flowIDstring = model.data["flowID"];
    //        int flowID = Int32.Parse(flowIDstring);
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                newOrderFlow flow = await dbcontext.newOrderFlows/*.Include(x => x.NewOrder)*/.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);

    //                flow.isAccepted = status;
    //                if (status == "2")
    //                {
    //                    newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
                       
    //                    newOrder orderflow = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == flow.newOrderID);
    //                    orderflow.newOrderStatusID = neworderstatus.newOrderStatusID;
    //                    flow.terminationDate = DateTime.Now;
    //                    //flow.NewOrder.newOrderStatusID = neworderstatus.newOrderStatusID;
    //                }

    //                await dbcontext.SaveChangesAsync();
    //            }
    //        }
    //        catch
    //        {

    //        }
    //        return initdatamodel;
    //    }
    //    private async Task<initDataVM> setNewFlowFromOrder(getURLVM model, Guid userID)
    //    {
    //        initDataVM initdatamodel = new initDataVM();
    //        using (Context dbcontext = new Context())
    //        {

    //            string orderIDstring = model.data["orderID"];
    //            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
    //            Guid orderID = new Guid(orderIDstring);
    //            Guid processID = new Guid(lstform.SingleOrDefault(x => x.key == "processList").value.Split(':').ToList()[0]);
    //            string phone = lstform.SingleOrDefault(x => x.key == "serventList").value.Split(':').ToList()[1];
    //            DateTime actinDate = DateTime.Parse(lstform.SingleOrDefault(x => x.key == "date").value);


    //            newOrderFlow newOrderFlow = new newOrderFlow()
    //            {
    //                creationDate = DateTime.Now.Date,
    //                processID = processID,
    //                isFinished = "0",
    //                isAccepted = "0",
    //                newOrderID = orderID,
    //                serventPhone = phone,
    //                userID = userID,
    //                terminationDate = DateTime.Now.Date,
    //                actionDate = actinDate.Date,
    //                changeStatusDate = DateTime.Now,

    //            };
    //            dbcontext.newOrderFlows.Add(newOrderFlow);
    //            //await dbcontext.SaveChangesAsync();

    //            newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
    //            newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

    //            order.newOrderStatusID = stat.newOrderStatusID;

    //            //user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == phone && x.userType == "1");
    //            //Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
    //            //servent.workingStatusID = ustatuid;

    //            await dbcontext.SaveChangesAsync();
    //        }


    //        return initdatamodel;
    //    }



    //    // بخش مربوط به تولید داده اختصاصی ویوهای اختصاصی مثل چارت و فرم

    //    private async Task<List<serventChartVM>> GetDataForManagerOrderList(ManagerOrderList model)
    //    {
    //        List<serventChartVM> serlst = new List<serventChartVM>();

    //        DateTime toDate;
    //        DateTime fromDate;

    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.toDate))
    //            {
    //                toDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.toDate));

    //            }
    //        }
    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.fromDate))
    //            {
    //                fromDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.fromDate));

    //            }
    //        }


    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {

    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //        return serlst;
    //    }
    //    private async Task<List<serventChartVM>> GetDataForManagerChart(ManagerChartSearch model)
    //    {
    //        string phone = model.phone;

    //        List<Guid> guids = new List<Guid>();
    //        if (!string.IsNullOrEmpty(phone))
    //        {
    //            List<string> list0 = phone.Split(',').ToList();
    //            foreach(var item in list0)
    //            {
    //                if (item != "")
    //                {
    //                    List<string> finalList = item.Split(':').ToList();
    //                    guids.Add(new Guid(finalList[0]));
    //                }
                    
    //            }
    //           // guids = phone.Split(',').Select(s => Guid.Parse(s)).ToList();
    //        }
    //        List<serventChartVM> serlst = new List<serventChartVM>();

    //        DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.startDate))
    //            {
    //                startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.startDate));
    //                startDate = startDate.AddDays(-7);
    //            }
    //        }
    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.endDate))
    //            {
    //                startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.endDate));
    //                startDate = startDate.AddDays(1);
    //            }
    //        }


    //        string persianName = customMethodes.returnDayName(startDate);




    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                //List<user> uslist = dbcontext.users.Where(x => x.barbariID == userID).ToList();

    //                var driverListquery = dbcontext.users.Where(x => x.barbariID != null).Include(x => x.workingStatus).Include(x => x.verifyStatus).Select(item => new codrivervm
    //                {
    //                    did = item.userID,
    //                    dname = item.name,
    //                    phone = item.phone,


    //                });
    //                if (guids.Count() > 0)
    //                {
    //                    driverListquery = driverListquery.Where(x => guids.Contains(x.did));
    //                }
    //                List<codrivervm> driverList = await driverListquery.ToListAsync();
    //                foreach (var item in driverList)
    //                {

    //                    serventChartVM servent = new serventChartVM();
    //                    List<serventChartList> serventList = new List<serventChartList>();
    //                    servent.name = item.dname + " " + item.phone;
    //                    servent.phone = item.did.ToString() + ":" +item.phone;
    //                    string dayname = startDate.DayOfWeek.ToString();
                       
    //                    DateTime usingtime = startDate.Date;
    //                    for (int i = 0; i <= 6; i++)
    //                    {

    //                        serventChartList chartlist = new serventChartList();
    //                        chartlist.dayName = dayname;
    //                        chartlist.persianDate = usingtime.ToShortDateString();// dateTimeConvert.ToPersianDateString(usingtime);
    //                        DateTime tommorow = usingtime.AddDays(1);
    //                        chartlist.timestamp = Classes.dateTimeConvert.ConvertDateTimeToTimestamp(usingtime);
    //                        chartlist.flowList = await dbcontext.newOrderFlows.Where(x => x.serventPhone == item.phone && x.actionDate >= usingtime && x.actionDate< tommorow)/*.Include(x => x.NewOrder)*/.Include(x => x.newOrderProcess).Select(x => new orderFlowVM  { orderID = x.newOrderID, isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, /*orderID = x.NewOrder.newOrderID,*/ isFinished = x.isFinished, flowID = x.newOrderFlowID, processColor = x.newOrderProcess.color, processName = x.newOrderProcess.title, /*orderName = x.NewOrder.orderName*/ }).ToListAsync();
    //                        usingtime = usingtime.AddDays(1);
    //                        dayname = usingtime.DayOfWeek.ToString(); //customMethodes.returnDayName(usingtime);

    //                        serventList.Add(chartlist);
    //                    }
    //                    servent.serventList = serventList;
    //                    serlst.Add(servent);
    //                }




    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //        return serlst;
    //    }



    //    private async Task<List<formItemList>> getFormItems(showFormInputVM model)
    //    {


    //        List<formItemList> formList = new List<formItemList>();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {

    //                newOrderFlow selectedFlow = await dbcontext.newOrderFlows.Include(x => x.NewOrderFields).SingleOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
    //                process process = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == selectedFlow.processID);
    //                if (process == null)
    //                {
    //                    form form = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == selectedFlow.formID);

    //                    Guid typeid = new Guid("96479ab5-f846-432f-b176-8ad98f0cb89b");// متنی تصویر دار
    //                    Guid typeid2 = new Guid("9c77d5e9-a956-45dd-8451-b71eb5b5e7a7");// چند گزینه ای




    //                    formItemList fil = new formItemList();
    //                    fil.formID = form.formID;
    //                    fil.formTitle = form.title;
    //                    fil.formImage = form.image;
    //                    fil.formHieght = form.imageHeight;
    //                    fil.formWidth = form.imageWidth;
    //                    fil.zaribWidth = form.zaribWidth;
    //                    fil.zaribHeight = form.zaribHeight;
    //                    if (string.IsNullOrEmpty(fil.formImage))
    //                    {
    //                        fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID != typeid2).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { continueWithError = x.continueWithError, isRequired = x.isRequired, validationType = x.validationType, referTo = x.referTo, isHidden = x.isHidden, itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).OrderBy(x=>x.formItemID).ToListAsync();
    //                        List<newOrderFields> neworderfields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == model.flowID).ToListAsync();// .NewOrderFields.ToList();
    //                        foreach (var item in fil.formItemDetailList)
    //                        {
    //                            newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.newOrderFlowID == model.flowID && x.formItemID == item.formItemID);
    //                            if (filed != null)
    //                            {
                                   
    //                                var nameOfProperty = filed.usedFeild;
    //                                var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                var value = propertyInfo.GetValue(filed, null);
    //                                string finalValue = value.ToString();
    //                                string addsonValue = "";
    //                                if (item.formItemTypeCode == "9")
    //                                {
    //                                    string timestamp = finalValue.Trim().Split(':').ToList().Last();
    //                                    string barcodevalue = finalValue.Trim().Split(':').ToList().First();
    //                                    try
    //                                    {
    //                                        double time = double.Parse(timestamp);
    //                                        DateTime datetime = dateTimeConvert.UnixTimeStampToDateTime(time);
    //                                        string persianTime = dateTimeConvert.UnixTimeStampToDateTime(time).ToPersianDateString();
                                            
    //                                        if (item.isRequired == "on")
    //                                        {

    //                                            if (item.continueWithError == "1")
    //                                            {
    //                                                if (barcodevalue != item.referTo)
    //                                                {
    //                                                    addsonValue = " - نامعتبر";
    //                                                }
    //                                            }
    //                                        }

    //                                        finalValue = persianTime + addsonValue;
                                            
    //                                    }
    //                                    catch
    //                                    {
                                            
    //                                    }

                                        
    //                                }
    //                                item.itemValue = finalValue;
    //                            }

    //                        }

    //                        // افزودن متن تصویر دار
    //                        List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { isHidden = l.isHidden, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();

    //                        foreach (var item in lst)
    //                        {
    //                            foreach (var dd in item)
    //                            {
    //                                newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == dd.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    dd.itemValue = value.ToString();
    //                                }

    //                            }
    //                        }
    //                        int index = 0;
    //                        foreach (var item in lst)
    //                        {
    //                            formFullDetailItemVM extraDetail = new formFullDetailItemVM();
    //                            extraDetail.stringImageCollection = item.Where(x => x.itemValue != null).ToList();
    //                            extraDetail.formItemTypeCode = "2";


    //                            fil.formItemDetailList.Insert(index, extraDetail);
    //                            index += 1;

    //                        }



    //                        // افزودن گزینه ها انتخابی
    //                        List<formFullDetailItemVM> multiSelectITems = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID == typeid2).Select(x => new formFullDetailItemVM { formItemID = x.formItemID }).ToListAsync();
    //                        if (multiSelectITems.Count() > 0)
    //                        {
    //                            List<Guid> orderOptionID = new List<Guid>();

    //                            foreach (var item in multiSelectITems)
    //                            {
    //                                newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    orderOptionID.Add(new Guid(value.ToString()));
    //                                }


    //                            }
    //                            List<orderOptionVM> orderotpinVMForSelectedOptions = await dbcontext.orderOptions.Where(x => orderOptionID.Contains(x.orderOptionID)).Select(g => new orderOptionVM { image = "Uploads/" + g.image, orderOptionID = g.orderOptionID, parentID = g.parentID, title = g.title }).ToListAsync();
    //                            formFullDetailItemVM extraDetailMultiSelect = new formFullDetailItemVM();
    //                            extraDetailMultiSelect.orderOptions = orderotpinVMForSelectedOptions;
    //                            extraDetailMultiSelect.formItemTypeCode = "1";
    //                            extraDetailMultiSelect.itemDesc = "گزینه های انتخابی";
    //                            fil.formItemDetailList.Insert(0, extraDetailMultiSelect);
    //                        }
    //                    }

    //                    else
    //                    {
    //                        fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
    //                        foreach (var item in fil.formItemDetailList)
    //                        {
    //                            newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                            if (filed != null)
    //                            {
    //                                var nameOfProperty = filed.usedFeild;
    //                                var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                var value = propertyInfo.GetValue(filed, null);
    //                                item.itemValue = value.ToString();
    //                            }

    //                        }
    //                    }

    //                    formList.Add(fil);

    //                }
    //                else
    //                {
    //                    foreach (var form in process.formList.OrderBy(x => x.priority))
    //                    {

    //                        Guid typeid = new Guid("96479ab5-f846-432f-b176-8ad98f0cb89b");// متنی تصویر دار
    //                        Guid typeid2 = new Guid("9c77d5e9-a956-45dd-8451-b71eb5b5e7a7");// چند گزینه ای




    //                        formItemList fil = new formItemList();
    //                        fil.formID = form.formID;
    //                        fil.formTitle = form.title;
    //                        fil.formImage = form.image;
    //                        fil.formHieght = form.imageHeight;
    //                        fil.formWidth = form.imageWidth;
    //                        fil.zaribWidth = form.zaribWidth;
    //                        fil.zaribHeight = form.zaribHeight;
    //                        if (string.IsNullOrEmpty(fil.formImage))
    //                        {
    //                            fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID != typeid2).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { isHidden = x.isHidden, itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
    //                            foreach (var item in fil.formItemDetailList)
    //                            {
    //                                newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    item.itemValue = value.ToString();
    //                                }

    //                            }

    //                            // افزودن متن تصویر دار
    //                            List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { isHidden = l.isHidden, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();

    //                            foreach (var item in lst)
    //                            {
    //                                foreach (var dd in item)
    //                                {
    //                                    newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == dd.formItemID);
    //                                    if (filed != null)
    //                                    {
    //                                        var nameOfProperty = filed.usedFeild;
    //                                        var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                        var value = propertyInfo.GetValue(filed, null);
    //                                        dd.itemValue = value.ToString();
    //                                    }

    //                                }
    //                            }
    //                            int index = 0;
    //                            foreach (var item in lst)
    //                            {
    //                                formFullDetailItemVM extraDetail = new formFullDetailItemVM();
    //                                extraDetail.stringImageCollection = item.Where(x => x.itemValue != null).ToList();
    //                                extraDetail.formItemTypeCode = "2";


    //                                fil.formItemDetailList.Insert(index, extraDetail);
    //                                index += 1;

    //                            }



    //                            // افزودن گزینه ها انتخابی
    //                            List<formFullDetailItemVM> multiSelectITems = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID == typeid2).Select(x => new formFullDetailItemVM { formItemID = x.formItemID }).ToListAsync();
    //                            if (multiSelectITems.Count() > 0)
    //                            {
    //                                List<Guid> orderOptionID = new List<Guid>();

    //                                foreach (var item in multiSelectITems)
    //                                {
    //                                    newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                                    if (filed != null)
    //                                    {
    //                                        var nameOfProperty = filed.usedFeild;
    //                                        var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                        var value = propertyInfo.GetValue(filed, null);
    //                                        orderOptionID.Add(new Guid(value.ToString()));
    //                                    }


    //                                }
    //                                List<orderOptionVM> orderotpinVMForSelectedOptions = await dbcontext.orderOptions.Where(x => orderOptionID.Contains(x.orderOptionID)).Select(g => new orderOptionVM { image = "Uploads/" + g.image, orderOptionID = g.orderOptionID, parentID = g.parentID, title = g.title }).ToListAsync();
    //                                formFullDetailItemVM extraDetailMultiSelect = new formFullDetailItemVM();
    //                                extraDetailMultiSelect.orderOptions = orderotpinVMForSelectedOptions;
    //                                extraDetailMultiSelect.formItemTypeCode = "1";
    //                                extraDetailMultiSelect.itemDesc = "گزینه های انتخابی";
    //                                fil.formItemDetailList.Insert(0, extraDetailMultiSelect);
    //                            }
    //                        }

    //                        else
    //                        {
    //                            fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
    //                            foreach (var item in fil.formItemDetailList)
    //                            {
    //                                newOrderFields filed = selectedFlow.NewOrderFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    item.itemValue = value.ToString();
    //                                }

    //                            }
    //                        }

    //                        formList.Add(fil);






    //                    }


    //                }



    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }
    //        return formList;

    //    }


    //    //


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setProfile([FromBody] setProfileVM model) // setNotifToken
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);

    //        Guid userID = new Guid(someObject.ToString());

    //        using (Context dbcontext = new Context())
    //        {
    //            if (model != null)
    //            {
    //                if (!string.IsNullOrEmpty(model.firebaseToken))
    //                {
    //                    user lastUser = await dbcontext.users.FirstOrDefaultAsync(x => x.firebaseToken == model.firebaseToken);
    //                    if (lastUser != null)
    //                    {
    //                        lastUser.firebaseToken = "";
    //                        lastUser.deviceToken = "";
    //                    }
    //                }

    //            }

    //            user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            if (user != null)
    //            {
    //                if (model != null)
    //                {
    //                    if (!string.IsNullOrEmpty(model.firebaseToken))
    //                        user.firebaseToken = model.firebaseToken;
    //                    if (!string.IsNullOrEmpty(model.deviceToken))
    //                        user.deviceToken = user.deviceToken;

    //                }

    //                user.badge = 0;

    //            }
    //            await dbcontext.SaveChangesAsync();
    //        }

    //        responseModel mymodel = new responseModel();
    //        mymodel.status = 200;
    //        mymodel.message = "ok";
    //        string result = JsonConvert.SerializeObject(mymodel);

    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [spalshAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<splash> getSplash([FromBody] doSignIn model)
    //    {

    //        object someObject;
    //        processActionVM responseModel = new processActionVM();

    //        Request.Properties.TryGetValue("Splash", out someObject);
    //        try
    //        {
    //            string splashstring = someObject.ToString();

    //            Dictionary<string, string> initdata = new Dictionary<string, string>();
                
    //            if (model != null)
    //            {
    //                if (!string.IsNullOrEmpty(model.phone))
    //                {
    //                    initdata.Add("phone", model.phone);
    //                    string phoneSended = await handleRegistration(null, model.phone);
    //                    splashstring = splashstring.Replace("app/loginPage", "app/verifyPage");
    //                }
    //            }
               
    //            splash sp = JsonConvert.DeserializeObject<splash>(splashstring);
    //            sp.result.data = initdata;
    //            return sp;
    //        }
    //        catch (Exception e)
    //        {
    //            splash sp = new splash();
    //            return sp;
    //        }


    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> getTab([FromBody] getTabVM model)
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        ViewModel.splashMain splashModel = spalshAuthenticationAttribute.setUserURL(someObject.ToString(), model.tabRole);
    //        if (model.data != null)
    //        {
    //            if (splashModel.tabs != null)
    //            {
    //                foreach (var item in splashModel.tabs)
    //                {
    //                    item.data = model.data;
    //                }
    //            }
    //        }
    //        if (model.input != null)
    //        {
    //            if (splashModel.tabs != null)
    //            {
    //                foreach (var item in splashModel.tabs)
    //                {
    //                    item.input = model.input;
    //                }
    //            }
    //        }
    //        responseModel mymodel = new responseModel();
    //        mymodel.status = 200;
    //        mymodel.message = "ok";


    //        string SerializedString = "{\"code\":0,\"result\":{\"tabBar\":null}}";
    //        SerializedString = SerializedString.Replace("startpagestring", splashModel.startPage);
    //        string tabstring = JsonConvert.SerializeObject(splashModel.tabs);
    //        SerializedString = SerializedString.Replace("\"tabBar\":null", "\"pages\": " + tabstring + "");

    //        JObject jObject = JObject.Parse(SerializedString);
    //        return jObject;

    //    }

    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> updateFormItemPostion([FromBody] form model)
    //    {
    //        //methods.ScanTextFromImageWithCoordinates("");
    //        responseModel mymodel = new responseModel();
    //        string json;
    //        string messagestring = "";
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                form form = await dbcontext.forms.Include(x => x.FormItems).SingleOrDefaultAsync(x => x.formID == model.formID);
    //                var testFile = "";


    //                testFile = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "PDF\\" + form.pdfBase);

    //                // doIMG(testFile,form);
    //                Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
    //                doc.LoadFromFile(testFile);




    //                foreach (var item in form.FormItems)
    //                {
    //                    string xposition = "";
    //                    string yposition = "0";

    //                    if (!string.IsNullOrEmpty(item.itemName))
    //                    {

    //                        foreach (PdfPageBase page in doc.Pages)
    //                        {

    //                            PdfTextFinder finder = new PdfTextFinder(page);
    //                            PdfTextFindOptions options = new PdfTextFindOptions();
    //                            options.Parameter = TextFindParameter.IgnoreCase;
    //                            finder.Options = options;
    //                            List<PdfTextFragment> fragments = finder.Find(item.itemName); //
    //                            PointF found1 = new PointF();
    //                            PointF found2 = new PointF();
    //                            if (fragments.Count > 0)
    //                            {
    //                                found1 = fragments[0].Positions[0];
    //                                item.itemx = found1.X + "," + found1.Y;
    //                                item.pageNumber = doc.Pages.IndexOf(page);
    //                            }
    //                            if (fragments.Count > 1)
    //                            {
    //                                found2 = fragments[1].Positions[0];
    //                                item.itemy = found2.X + "," + found2.Y;
    //                                item.pageNumber = doc.Pages.IndexOf(page);

    //                                item.itemLenght = (found1.X - found2.X).ToString();
    //                                item.itemHeight = (found1.Y - found2.Y).ToString();

    //                            }


    //                        }






    //                    }
    //                    string json2;


    //                }
    //                messagestring += "1-";
    //                await dbcontext.SaveChangesAsync();
    //                // تولید عکس از روی پی دی اف
    //                // string pt = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
    //                // string path = System.IO.Path.Combine(pt,  "Upload");// HttpRuntime.AppDomainAppPath; // System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
    //                string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");// Server.MapPath("~/Upload/");// HostingEnvironment.MapPath("~/Uploads/");// ;
    //                string pdfFilePath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "PDF\\" + form.pdf);
    //                messagestring += folderPath;
    //                messagestring += "-" + folderPath;
    //                PdfDocument pdf = new PdfDocument();
    //                pdf.LoadFromFile(pdfFilePath);
    //                List<Image> images = new List<Image>();
    //                string finalImag = "";
    //                string finalwidth = "";
    //                string finalhieght = "";
    //                string zaribWidth = "";
    //                string zaribHeight = "";
    //                foreach (PdfPageBase page in pdf.Pages)
    //                {
    //                    string filename = form.pdf.Replace(".pdf", "") + pdf.Pages.IndexOf(page) + ".png";
    //                    //finalImag += filename + ",";
    //                    string imagename = System.IO.Path.Combine(folderPath, filename);
    //                    messagestring += imagename;
    //                    foreach (Image image in page.ExtractImages())
    //                    {
    //                        image.Save(imagename, System.Drawing.Imaging.ImageFormat.Png);
    //                        finalwidth += image.Width + ",";
    //                        finalhieght += image.Height + ",";
    //                        finalImag += System.Configuration.ConfigurationManager.AppSettings["domain"] + "/Uploads/" + filename + ",";
    //                        zaribWidth += (image.Width / page.ActualSize.Width).ToString() + ",";
    //                        zaribHeight += (image.Height / page.ActualSize.Height).ToString() + ",";
    //                    }
    //                }


    //                form.imageWidth = finalwidth.Trim(',');
    //                form.imageHeight = finalhieght.Trim(',');
    //                form.image = finalImag.Trim(',');
    //                form.zaribWidth = zaribWidth;
    //                form.zaribHeight = zaribHeight;


    //                await dbcontext.SaveChangesAsync();
    //                // پایان

    //                mymodel.status = 200;
    //                await dbcontext.SaveChangesAsync();
    //                string result = JsonConvert.SerializeObject(mymodel);
    //                JObject jObject = JObject.Parse(result);
    //                return jObject;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            mymodel.status = 400;
    //            mymodel.message = messagestring;
    //            string result = JsonConvert.SerializeObject(mymodel);
    //            JObject jObject = JObject.Parse(result);
    //            return jObject;

    //        }

    //        //deviceID = "6";
    //        //using (var client = new WebClient())
    //        //{
    //        //    json = client.DownloadString("http://supectco.com/webs/GDP/Admin/getListOfFeatures.php?CatID=" + deviceID);
    //        //}

    //        //FeatureModel log = JsonConvert.DeserializeObject<FeatureModel>(json);


    //    }

    //    //[BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<pageSectionVM> getURL([FromBody] getURLVM model)
    //    {




    //        pageSectionVM response = new pageSectionVM();
    //        try
    //        {
    //            model.slug = model.slug == null ? "" : model.slug;
    //            using (Context dbcontext = new Context())
    //            {

    //                language lng = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.lang);
    //                //Include(x => x.Contents.Select(l => l.HTML)).Include(x => x.Contents.Select(y => y.Datas)).Include(x => x.Contents.Select(y => y.childContent)).Include(x => x.Contents.Select(y => y.childContent.Select(z => z.Datas)))

    //                var responseList = await dbcontext.sections.Include(x => x.SectionLayout).Include(x => x.SecTags).Include(x => x.Metas).Where(x => x.url == model.slug).Select(x => new pageSectionVM { sectionID = x.sectionID, tags = x.SecTags.Select(t => new secTagVM { title = t.title, tagID = t.secTagID }).ToList(), Metas = x.Metas.Select(p => new MetaVM { Name = p.name, Content = p.content }).ToList(), date = x.date, title = x.title, image = x.image, url = x.url, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
    //                response = responseList.First();
    //                var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == response.sectionLayoutID).Select(x => new getsectionLayoutVM { sectionLayoutID = x.sectionLayoutID, menuTitle = x.menuTitle, title = x.Layout.name, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { layoutPartID = l.layoutPartID, title = l.typeName, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { layoutDataID = m.layoutDataID, parentID = m.parentID, dataType = m.dataType, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).ToList() }).ToList() }).ToListAsync();
    //                response.layoutModel = list.First();
    //                response.layoutModel.dynamicList = await getLayoutDynamic(model.slug);


    //                response.Contents = await getChildContentWeb(response.sectionID, null, model.lang);
    //                await replaceSection(response.Contents, response); // اگر یک آیتم از داده های خود سکشن قرار بود استفاده کنه
    //                                                                   //foreach (var item in response.Contents)
    //                                                                   //{
    //                                                                   //    if (item.typeID != new Guid("00000000-0000-0000-0000-000000000000") && item.typeID != null)
    //                                                                   //    {
    //                                                                   //        item.childList = await dbcontext.sections.Include(x => x.Category).Where(x => x.sectionTypeID == item.typeID).Select(x => new sectionVM { buttonText = x.buttonText, categoryName = x.Category.title, title = x.title, description = x.description, metaTitle = x.metatitle, image = x.image, writer = x.writer, date = x.date, url = x.url }).ToListAsync();
    //                                                                   //    }
    //                                                                   //}
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            throw;
    //        }



    //        return response;
    //    }


    //    private async Task<List<layoutDynamics>> getLayoutDynamic(string slug)
    //    {
    //        List<layoutDynamics> lst = new List<layoutDynamics>();
    //        if (slug.Contains("blog"))
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                sectionType st = await dbcontext.sectionTypes.SingleOrDefaultAsync(x => x.title == "blog");
    //                var blogItems = await dbcontext.sections.Where(x => x.sectionTypeID == st.sectionTypeID).OrderByDescending(x => x.date).ToListAsync();
    //                var categoryItems = await dbcontext.categories.Where(x => x.sectionTypeID == st.sectionTypeID).ToListAsync();
    //                var tagItems = await dbcontext.SecTags.Where(x => x.sectionTypeID == st.sectionTypeID).ToListAsync();

    //                foreach (var item in blogItems)
    //                {
    //                    layoutDynamics ld = new layoutDynamics()
    //                    {
    //                        header = "blog",
    //                        title = item.title,
    //                        value = item.url
    //                    };
    //                    lst.Add(ld);
    //                }
    //                foreach (var item in categoryItems)
    //                {
    //                    layoutDynamics ld = new layoutDynamics()
    //                    {
    //                        header = "category",
    //                        title = item.title,
    //                        value = "blog"
    //                    };
    //                    lst.Add(ld);
    //                }
    //                foreach (var item in tagItems)
    //                {
    //                    layoutDynamics ld = new layoutDynamics()
    //                    {
    //                        header = "tag",
    //                        title = item.title,
    //                        value = "tag"
    //                    };
    //                    lst.Add(ld);
    //                }
    //            }
    //        }

    //        return lst;
    //    }

    //    [System.Web.Http.HttpPost]
    //    public async Task<getsectionLayoutVM> getPageLayout([FromBody] sectionLayoutVM model)
    //    {
    //        getsectionLayoutVM response = new getsectionLayoutVM();
    //        using (Context dbcontext = new Context())
    //        {

    //            var list = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).Include(x => x.Layout).Include(x => x.LayoutParts.Select(l => l.LayoutDatas)).Where(x => x.sectionLayoutID == model.sectionLayoutID).Select(x => new getsectionLayoutVM { sectionLayoutID = x.sectionLayoutID, menuTitle = x.menuTitle, title = x.Layout.title, LayoutParts = x.LayoutParts.Select(l => new getlayoutPartVM { title = l.title, LayoutDatas = l.LayoutDatas.Select(m => new getlayoutDataVM { dataType = m.dataType, image = m.image, priority = m.priority, url = m.url, urlTitle = m.urlTitle }).ToList() }).ToList() }).ToListAsync();

    //            response = list.First();

    //        }


    //        return response;
    //    }

    //    //verify
    //    [System.Web.Http.HttpPost]
    //    public JObject Verify([FromBody] doSignIn model)
    //    {
    //        responseModel output = new responseModel();
    //        using (Context dbcontext = new Context())
    //        {

    //            try
    //            {
    //                //List<newOrderFlow> allflow = dbcontext.newOrderFlows.ToList();
    //                //List<newOrder> allflow = dbcontext.NewOrders.ToList();
    //                //List<newOrderFields> allflow1 = dbcontext.newOrderFields.ToList();
    //                //List<newOrderFlow> allflow2 = dbcontext.newOrderFlows.ToList();

    //                string codeSent = methods.PersianToEnglish(model.code);
    //                string phoneSent = methods.PersianToEnglish(model.phone);
    //                List<user> lst = dbcontext.users.ToList();
    //                List<html> htmls = dbcontext.htmls.ToList();
    //                user myuser = dbcontext.users.SingleOrDefault(x => x.phone == phoneSent && x.code == codeSent && x.userType == model.userType);
    //                if (myuser != null)
    //                {
    //                    output.status = 200;
    //                    output.message = TokenManager.GenerateToken(model.phone, myuser.userID.ToString());
    //                }
    //                else
    //                {
    //                    output.message = "Invalid User.";
    //                    output.status = 400;
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                output.message = e.Message;
    //                string inner = e.InnerException.ToString();
    //                output.status = 400;
    //            }

    //        }
    //        string outputstring = JsonConvert.SerializeObject(output);
    //        JObject jObject = JObject.Parse(outputstring); return jObject;

    //    }


    //    // dashboard

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<dashbaordVM> getDashboard([FromBody] doSignIn model)
    //    {

    //        dashbaordVM response = new dashbaordVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            response.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //        }

    //        return response;
    //    }


    //    // lanuage
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<LanguagePageVM> getLanguageList([FromBody] doSignIn model)
    //    {
    //        LanguagePageVM response = new LanguagePageVM();

    //        using (Context dbcontext = new Context())
    //        {
    //            response.list = await dbcontext.languages.Select(x => new languagVM { title = x.title, languageID = x.languageID }).ToListAsync();
    //        }
    //        return response;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setLanguage([FromBody] languagVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.languageID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {

    //                }
    //                else
    //                {
    //                    language exist = await dbcontext.languages.SingleOrDefaultAsync(x => x.title == model.title);
    //                    if (exist == null)
    //                    {
    //                        language newlItem = new language()
    //                        {
    //                            languageID = Guid.NewGuid(),
    //                            title = model.title
    //                        };
    //                        dbcontext.languages.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Language already Exists";
    //                    }


    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }
    //    // type

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<typePageVM> getTypeList([FromBody] doSignIn model)
    //    {
    //        typePageVM response = new typePageVM();

    //        using (Context dbcontext = new Context())
    //        {
    //            response.list = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //        }
    //        return response;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setType([FromBody] typeVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.typeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {

    //                }
    //                else
    //                {
    //                    sectionType exist = await dbcontext.sectionTypes.SingleOrDefaultAsync(x => x.title == model.title);
    //                    if (exist == null)
    //                    {
    //                        sectionType newlItem = new sectionType()
    //                        {
    //                            sectionTypeID = Guid.NewGuid(),
    //                            title = model.title
    //                        };
    //                        dbcontext.sectionTypes.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Language already Exists";
    //                    }


    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    // category
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<categoryPageVM> getCategoryList([FromBody] doSignIn model)
    //    {
    //        categoryPageVM response = new categoryPageVM();

    //        using (Context dbcontext = new Context())
    //        {
    //            response.list = await dbcontext.categories.Include(x => x.sectionType).Select(x => new categoryVM { sectionTypeName = x.sectionType.title, title = x.title, categoryID = x.sectionTypeID }).ToListAsync();
    //            response.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //        }
    //        return response;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setCategory([FromBody] categoryVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.categoryID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {

    //                }
    //                else
    //                {
    //                    category exist = await dbcontext.categories.SingleOrDefaultAsync(x => x.title == model.title);
    //                    if (exist == null)
    //                    {
    //                        category newlItem = new category()
    //                        {
    //                            categoryID = Guid.NewGuid(),
    //                            title = model.title,
    //                            sectionTypeID = model.sectionTypeID
    //                        };
    //                        dbcontext.categories.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Language already Exists";
    //                    }


    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    // tag
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<tagPageVM> getTagList([FromBody] doSignIn model)
    //    {
    //        tagPageVM response = new tagPageVM();

    //        using (Context dbcontext = new Context())
    //        {
    //            response.list = await dbcontext.SecTags.Include(x => x.sectionType).Select(x => new secTagVM { sectionTypeName = x.sectionType.title, title = x.title, tagID = x.secTagID }).ToListAsync();
    //            response.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //        }
    //        return response;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setsecTag([FromBody] secTagVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.tagID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {

    //                }
    //                else
    //                {
    //                    secTag exist = await dbcontext.SecTags.SingleOrDefaultAsync(x => x.title == model.title);
    //                    if (exist == null)
    //                    {
    //                        secTag newlItem = new secTag()
    //                        {
    //                            secTagID = Guid.NewGuid(),
    //                            title = model.title,
    //                            sectionTypeID = model.sectionTypeID
    //                        };
    //                        dbcontext.SecTags.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Language already Exists";
    //                    }


    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    // page 
    //    [System.Web.Http.HttpPost]
    //    public async Task<pageListVM> getPage([FromBody] typeVM model)
    //    {
    //        pageListVM output = new pageListVM();
    //        try
    //        {

    //            using (Context dbcontext = new Context())
    //            {
    //                var imlist = await dbcontext.medias.ToListAsync();
    //                output.imageList = imlist.Count > 0 ? imlist.Select(x => x.title).ToList() : new List<string>();
    //                output.categoryList = await dbcontext.categories.Where(x => x.sectionTypeID == model.typeID).Select(x => new categoryVM { categoryID = x.categoryID, title = x.title }).ToListAsync();
    //                output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title }).ToListAsync();
    //                output.sectionList = await dbcontext.sections.Where(x => x.sectionTypeID == model.typeID).OrderBy(x => x.title).Select(x => new sectionVM { categoryID = x.categoryID, buttonText = x.buttonText, languateID = x.languageID, sectionLayoutID = x.sectionLayoutID, image = x.image, metaTitle = x.metatitle, title = x.title, url = x.url, sectinoID = x.sectionID, writer = x.writer }).ToListAsync();
    //                output.layoutList = await dbcontext.sectionLayouts.Select(x => new sectionLayoutVM { menuTitle = x.menuTitle, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
    //                output.tagList = await dbcontext.SecTags.Where(x => x.sectionTypeID == model.typeID).Select(x => new secTagVM { title = x.title, tagID = x.secTagID }).ToListAsync();
    //                sectionType sections = await dbcontext.sectionTypes.FirstOrDefaultAsync(x => x.sectionTypeID == model.typeID);

    //                output.selectedType = new typeVM()
    //                {
    //                    typeID = sections.sectionTypeID,
    //                    title = sections.title
    //                };
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }


    //        return output;

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setSection([FromBody] sectionVM model)
    //    {

    //        responseModel response = new responseModel();
    //        model.url = model.url == null ? "" : model.url;
    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.sectinoID != new Guid("00000000-0000-0000-0000-000000000000") && model.sectinoID != null)
    //                {
    //                    section exist = await dbcontext.sections.SingleOrDefaultAsync(x => x.sectionID == model.sectinoID);
    //                    string lastmessag = exist.image;
    //                    exist.title = model.title;
    //                    exist.metatitle = model.metaTitle;
    //                    exist.buttonText = model.buttonText;
    //                    exist.url = model.url;
    //                    if (!string.IsNullOrEmpty(model.image))
    //                    {
    //                        exist.image = model.image;

    //                        if (!dbcontext.medias.Any(x => x.title == model.image))
    //                        {
    //                            dbcontext.medias.Add(new media() { title = model.image });
    //                        }
    //                    }

    //                    if (model.sectionLayoutID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        exist.sectionLayoutID = model.sectionLayoutID;
    //                    if (model.sectinoTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        exist.sectionTypeID = model.sectinoTypeID;
    //                    if (model.languateID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        exist.languageID = model.languateID;
    //                    response.message = lastmessag;
    //                    response.status = 200;
    //                    await dbcontext.SaveChangesAsync();
    //                }
    //                else
    //                {
    //                    section exist = await dbcontext.sections.SingleOrDefaultAsync(x => x.url == model.url && x.languageID == model.languateID);
    //                    if (exist == null)
    //                    {

    //                        section newlItem = new section()
    //                        {
    //                            sectionID = Guid.NewGuid(),
    //                            title = model.title,
    //                            description = model.description,
    //                            metatitle = model.metaTitle,
    //                            image = model.image,
    //                            sectionTypeID = model.sectinoTypeID,
    //                            sectionLayoutID = model.sectionLayoutID,
    //                            languageID = model.languateID,
    //                            buttonText = model.buttonText,

    //                            date = DateTime.Now,
    //                            url = model.url.Trim('/'),
    //                            writer = "admin",



    //                        };
    //                        if (model.sectinoID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                            newlItem.categoryID = model.categoryID;

    //                        //sectionLayoutID = new Guid()
    //                        dbcontext.sections.Add(newlItem);
    //                        if (model.secTagID != null)
    //                        {
    //                            foreach (var item in model.secTagID)
    //                            {
    //                                secTag secitem = await dbcontext.SecTags.SingleOrDefaultAsync(x => x.secTagID == item);
    //                                newlItem.SecTags.Add(secitem);
    //                            }
    //                        }

    //                        if (!dbcontext.medias.Any(x => x.title == model.image))
    //                        {
    //                            dbcontext.medias.Add(new media() { title = model.image });
    //                        }
    //                        response.status = 200;
    //                        response.message = "";
    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Language already Exists";
    //                    }


    //                }
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    // content 
    //    [System.Web.Http.HttpPost]
    //    public async Task<contentListVM> getContent([FromBody] sectionVM model)
    //    {
    //        contentListVM output = new contentListVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                output.allContents = await dbcontext.contents.Include(x => x.HTML).Select(x => new contentVM { title = x.title, contentID = x.contentID }).ToListAsync();
    //                content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentParent);
    //                Guid parentHTML = new Guid();
    //                if (content != null)
    //                {
    //                    parentHTML = content.HTML.htmlID;
    //                    model.sectinoID = content.sectionID;
    //                    output.parentSelected = new contentVM
    //                    {
    //                        title = content.title,
    //                        contentID = content.contentID
    //                    };
    //                }
    //                section section = await dbcontext.sections.Include(x => x.SectionLayout).FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);

    //                var querycontent = dbcontext.contents.Include(x => x.HTML).Include(x => x.sectionType).Include(x => x.HTML).AsQueryable();
    //                List<contentVM> querycontentList = await dbcontext.contents.Include(x => x.sectionType).Include(x => x.HTML).Select(x => new contentVM { htmlType = x.HTML.appType, stackWeight = x.stackWeight, cycleFields = x.cycleFields, htmlFeilds = x.HTML.dataField, formID = x.formID, htmlFormLink = x.HTML.formLink, description = x.description, multilayer = x.HTML.multilayer, priority = x.priority, title = x.title, image = x.HTML.image, contentID = x.contentID, htmlName = x.title, typeName = x.sectionType != null ? x.sectionType.title : "" }).ToListAsync();
    //                if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    querycontent = querycontent.Where(x => x.parentID == model.contentParent);
    //                }
    //                else
    //                {
    //                    querycontent = querycontent.Where(x => x.sectionID == model.sectinoID && x.parentID == null);
    //                }

    //                output.contentList = await querycontent.Select(x => new contentVM { htmlType = x.HTML.appType, stackWeight = x.stackWeight, cycleFields = x.cycleFields, htmlFeilds = x.HTML.dataField, formID = x.formID, htmlFormLink = x.HTML.formLink, description = x.description, multilayer = x.HTML.multilayer, priority = x.priority, title = x.title, image = x.HTML.image, contentID = x.contentID, htmlName = x.title, typeName = x.sectionType != null ? x.sectionType.title : "" }).OrderBy(x => x.priority).ToListAsync();


    //                var htmlquery = dbcontext.htmls.Where(x => x.layout == section.SectionLayout.layoutID).AsQueryable();
    //                if (parentHTML != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    htmlquery = htmlquery.Where(x => x.parentID == parentHTML || x.ispublic == "1");
    //                    var lll = htmlquery.ToList();
    //                }
    //                else
    //                {
    //                    htmlquery = htmlquery.Where(x => x.parentID == null);

    //                }
    //                output.htmlList = await htmlquery.Select(x => new HTMLVM { partialView = x.partialView, image = x.image, htmlName = x.title, htmlID = x.htmlID }).ToListAsync();
    //                output.typeList = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //                output.selectedSection = new sectionVM()
    //                {
    //                    sectinoID = section.sectionID,
    //                    title = section.title
    //                };
    //                output.formList = await dbcontext.forms.Select(x => new formVM { formID = x.formID, title = x.title }).ToListAsync();

    //            }
    //            catch (Exception e)
    //            {


    //            }

    //        }

    //        return output;

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setContent([FromBody] setContentVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {

    //                if (model.contentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    content cnt = await dbcontext.contents.SingleOrDefaultAsync(x => x.contentID == model.contentID);
    //                    if (model.newParent != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        cnt.parentID = model.newParent;
    //                        await dbcontext.SaveChangesAsync();
    //                        response.status = 200;
    //                        response.message = "";
    //                        string result0 = JsonConvert.SerializeObject(response);
    //                        JObject jObject0 = JObject.Parse(result0);
    //                        return jObject0;

    //                    }
    //                    if (model.contentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        if (!string.IsNullOrEmpty(model.stackWeight))
    //                        {
    //                            cnt.stackWeight = model.stackWeight;

    //                        }
    //                        else if (model.formID != 0)
    //                        {
    //                            cnt.formID = model.formID;
    //                        }
    //                        if (!string.IsNullOrEmpty(model.title))
    //                        {
    //                            cnt.title = model.title;
    //                        }
    //                        else
    //                        {
    //                            cnt.priority = model.priority;
    //                            if (model.chosenForCycle != null)
    //                            {
    //                                if (model.chosenForCycle.Count() > 0)
    //                                {
    //                                    cnt.cycleFields = string.Join(",", model.chosenForCycle);
    //                                }
    //                            }

    //                        }

    //                    }

    //                }
    //                else
    //                {

    //                    if (model.mirrorID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        copyWholeContent(model.sectionID, model.priority, model.title, model.mirrorID, model.contentParent, dbcontext);
    //                        dbcontext.SaveChanges();
    //                        response.status = 200;
    //                        response.message = "";
    //                        string rs = JsonConvert.SerializeObject(response);

    //                        JObject ob = JObject.Parse(rs);
    //                        return ob;
    //                    }

    //                    html selectedHtml = await dbcontext.htmls.SingleOrDefaultAsync(x => x.htmlID == model.htmlID);
    //                    Guid contentID = Guid.NewGuid();
    //                    content newlItem = new content()
    //                    {
    //                        contentID = contentID,
    //                        htmlID = model.htmlID,
    //                        priority = model.priority,
    //                        description = model.description,
    //                        title = model.title,
    //                        sectionID = model.sectionID,
    //                        stackWeight = model.stackWeight,
    //                        useParentSection = model.selfUsed == "on" ? 1 : 0,

    //                    };




    //                    if (model.typeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        newlItem.sectionTypeID = model.typeID;
    //                    if (model.contentParent != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        newlItem.parentID = model.contentParent;
    //                    if (model.formID != 0)
    //                        newlItem.formID = model.formID;
    //                    dbcontext.contents.Add(newlItem);

    //                    string fielditem = selectedHtml.dataField;
    //                    if (!string.IsNullOrEmpty(fielditem))
    //                    {
    //                        List<string> itemlist = fielditem.Trim(',').Split(',').ToList();
    //                        foreach (var item in itemlist)
    //                        {
    //                            int index = itemlist.IndexOf(item) + 1;
    //                            data newData = new data()
    //                            {
    //                                dataID = Guid.NewGuid(),
    //                                title = item,
    //                                title2 = "",
    //                                description = "",
    //                                description2 = "",
    //                                mediaURL = "",
    //                                viedoIframe = "",
    //                                contentID = contentID,
    //                                writer = "admin",
    //                                Date = DateTime.Now,
    //                                url = "",
    //                                priority = index
    //                            };
    //                            dbcontext.datas.Add(newData);
    //                        }
    //                    }


    //                }
    //                response.status = 200;
    //                response.message = "";
    //                await dbcontext.SaveChangesAsync();
    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    private void copyWholeContent(Guid? sectionID, int priority, string title, Guid mirrorID, Guid? parentID, Context dbcontext)
    //    {
    //        responseModel response = new responseModel();
    //        try
    //        {

    //            parentID = parentID != new Guid("00000000-0000-0000-0000-000000000000") ? parentID : null;

    //            content mirror = dbcontext.contents.Include(x => x.Datas).Include(x => x.Poses).Include(x => x.childContent).SingleOrDefault(x => x.contentID == mirrorID);
    //            Guid contentID = Guid.NewGuid();
    //            content newContent = new content
    //            {
    //                contentID = contentID,
    //                htmlID = mirror.htmlID,
    //                priority = priority,
    //                description = mirror.description,
    //                title = mirror.title + "_" + title,
    //                sectionID = sectionID,
    //                stackWeight = mirror.stackWeight,


    //            };

    //            if (mirror.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                newContent.sectionTypeID = mirror.sectionTypeID;
    //            if (mirror.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                newContent.parentID = parentID;
    //            if (mirror.formID != 0)
    //                newContent.formID = mirror.formID;
    //            dbcontext.contents.Add(newContent);
    //            dbcontext.SaveChanges();

    //            if (mirror.Datas != null)
    //            {
    //                foreach (var dataM in mirror.Datas)
    //                {
    //                    data data = new data
    //                    {
    //                        dataID = Guid.NewGuid(),
    //                        title = dataM.title,
    //                        title2 = dataM.title2,
    //                        description = dataM.description,
    //                        description2 = dataM.description2,
    //                        mediaURL = dataM.mediaURL,
    //                        viedoIframe = dataM.viedoIframe,
    //                        contentID = contentID,
    //                        writer = "admin",
    //                        Date = DateTime.Now,
    //                        url = dataM.url,
    //                        priority = dataM.priority
    //                    };
    //                    dbcontext.datas.Add(data);
    //                }

    //            }

    //            if (mirror.Poses != null)
    //            {
    //                foreach (var item in mirror.Poses)
    //                {
    //                    pose newpose = new pose()
    //                    {
    //                        poseID = Guid.NewGuid(),
    //                        title = item.title,
    //                        title2 = item.title2,
    //                        contentID = contentID,
    //                    };
    //                    dbcontext.poses.Add(newpose);
    //                }
    //            }
    //            dbcontext.SaveChanges();

    //            if (mirror.childContent != null)
    //            {
    //                foreach (var chitem in mirror.childContent)
    //                {
    //                    copyWholeContent(chitem.sectionID, chitem.priority, title, chitem.contentID, contentID, dbcontext);
    //                }
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }



    //    }

    //    private async Task<responseModel> setNewData(data model, string title)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                data newlItem = new data()
    //                {



    //                };


    //                dbcontext.datas.Add(newlItem);
    //                response.status = 200;
    //                response.message = "";
    //                await dbcontext.SaveChangesAsync();


    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }
    //        return response;
    //    }


    //    private void removeItem(setContentVM model, Context dbcontext)
    //    {
    //        try
    //        {
    //            content selectedContent = dbcontext.contents.Include(x => x.Datas).SingleOrDefault(x => x.contentID == model.contentID);
    //            if (selectedContent != null)
    //            {
    //                selectedContent.Datas.ToList().ForEach(p => dbcontext.datas.Remove(p));
    //                selectedContent.Poses.ToList().ForEach(p => dbcontext.poses.Remove(p));
    //                dbcontext.SaveChanges();
    //                if (selectedContent.childContent != null)
    //                {
    //                    List<Guid> GUidlist = selectedContent.childContent.Select(x => x.contentID).ToList();
    //                    foreach (var child in GUidlist)
    //                    {
    //                        setContentVM viewmodel = new setContentVM()
    //                        {
    //                            contentID = child,
    //                        };
    //                        removeItem(viewmodel, dbcontext);
    //                    }

    //                }
    //            }

    //            dbcontext.Entry(selectedContent).State = EntityState.Deleted;
    //            dbcontext.SaveChanges();

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeContent([FromBody] setContentVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            removeItem(model, dbcontext);
    //            await dbcontext.SaveChangesAsync();
    //        }




    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    //element

    //    [System.Web.Http.HttpPost]
    //    public async Task<elementListVM> getElement([FromBody] sectionVM model)
    //    {
    //        elementListVM output = new elementListVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            output.elementList = await dbcontext.urlDatas.Include(x => x.form).Where(x => x.sectionID == model.sectinoID).Select(x => new elementVM { formName = x.form.title, name = x.name, flowFields = x.flowFields, formFields = x.formFields, isCycle = x.isCycle, formID = x.formID, formItemID = x.formItemID, operat = x.operat, isLinkToMain = x.isLinkToMain }).ToListAsync();
    //            section section = await dbcontext.sections.FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);
    //            output.allForm = await dbcontext.forms.Select(x => new formVM { formID = x.formID, title = x.title }).ToListAsync();
    //            output.selectedSection = new sectionVM()
    //            {
    //                sectinoID = section.sectionID,
    //                title = section.title
    //            };
    //        }
    //        return output;

    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setElement([FromBody] elementVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                urlData newlItem = new urlData()
    //                {
    //                    urlDataID = Guid.NewGuid(),
    //                    name = model.name,
    //                    isLinkToMain = model.isLinkToMain,
    //                    operat = model.operat,
    //                    flowFields = model.flowFields,
    //                    formFields = model.formFields,
    //                    formID = model.formID,
    //                    formItemID = model.formItemID,
    //                    isCycle = model.isCycle,
    //                    sectionID = model.sectionID,
    //                };


    //                dbcontext.urlDatas.Add(newlItem);
    //                response.status = 200;
    //                response.message = "";
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeElement([FromBody] MetaVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                meta selectedContent = await dbcontext.metas.SingleOrDefaultAsync(x => x.metaID == model.metaID);
    //                if (selectedContent != null)
    //                {
    //                    dbcontext.metas.Remove(selectedContent);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }
    //    // meta 
    //    [System.Web.Http.HttpPost]
    //    public async Task<metaListVM> getMeta([FromBody] sectionVM model)
    //    {
    //        metaListVM output = new metaListVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            output.metaList = await dbcontext.metas.Where(x => x.sectionID == model.sectinoID).Select(x => new MetaVM { Name = x.name, Content = x.content, metaID = x.metaID, sectionID = x.sectionID }).ToListAsync();
    //            section section = await dbcontext.sections.FirstOrDefaultAsync(x => x.sectionID == model.sectinoID);

    //            output.selectedSection = new sectionVM()
    //            {
    //                sectinoID = section.sectionID,
    //                title = section.title
    //            };
    //        }
    //        return output;

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setMeta([FromBody] MetaVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                meta newlItem = new meta()
    //                {
    //                    metaID = Guid.NewGuid(),
    //                    name = model.Name,
    //                    content = model.Content,
    //                    sectionID = model.sectionID,



    //                };


    //                dbcontext.metas.Add(newlItem);
    //                response.status = 200;
    //                response.message = "";
    //                await dbcontext.SaveChangesAsync();

    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeMeta([FromBody] MetaVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                meta selectedContent = await dbcontext.metas.SingleOrDefaultAsync(x => x.metaID == model.metaID);
    //                if (selectedContent != null)
    //                {
    //                    dbcontext.metas.Remove(selectedContent);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }



    //    // data
    //    [System.Web.Http.HttpPost]
    //    public async Task<dataListVM> getData([FromBody] contentVM model)
    //    {
    //        dataListVM output = new dataListVM();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentID);
    //                var imlist = await dbcontext.medias.ToListAsync();
    //                output.imageList = imlist.Count > 0 ? imlist.Select(x => x.title).ToList() : new List<string>();
    //                string fields = "";
    //                if (string.IsNullOrEmpty(model.fields))
    //                {
    //                    fields = content.HTML.dataField.ToString();
    //                }


    //                output.dataList = await dbcontext.datas.Where(x => x.contentID == model.contentID).OrderBy(x => x.priority).Select(x => new dataVM { date = x.Date, writer = x.writer, priority = x.priority, URL = x.url, dataID = x.dataID, title = x.title, title2 = x.title2, description = x.description, description2 = x.description2, mediaURL = x.mediaURL, viedoIframe = x.viedoIframe }).ToListAsync();
    //                bool refreshList = false;
    //                if (!string.IsNullOrEmpty(fields))
    //                {
    //                    List<string> newItems = fields.Trim(',').Split(',').ToList();
    //                    if (output.dataList.Count() != newItems.Count())
    //                    {
    //                        foreach (var item in newItems.ToList())
    //                        {
    //                            if (!output.dataList.Any(l => item.ToString().Contains(l.title)))
    //                            {
    //                                data newlItem = new data()
    //                                {
    //                                    dataID = Guid.NewGuid(),
    //                                    title = item,
    //                                    title2 = "",

    //                                    contentID = model.contentID,
    //                                    writer = "admin",
    //                                    Date = DateTime.Now,
    //                                    priority = model.priority


    //                                };
    //                                dbcontext.datas.Add(newlItem);
    //                                refreshList = true;
    //                            }

    //                        }
    //                    }
    //                }
    //                if (refreshList)
    //                {
    //                    await dbcontext.SaveChangesAsync();
    //                    output.dataList = await dbcontext.datas.Where(x => x.contentID == model.contentID).OrderBy(x => x.priority).Select(x => new dataVM { date = x.Date, writer = x.writer, priority = x.priority, URL = x.url, dataID = x.dataID, title = x.title, title2 = x.title2, description = x.description, description2 = x.description2, mediaURL = x.mediaURL, viedoIframe = x.viedoIframe }).ToListAsync();
    //                }


    //                output.selectedContent = new contentVM()
    //                {
    //                    contentID = content.contentID,
    //                    title = content.title,
    //                    image = content.title,
    //                    fields = content.HTML.dataField
    //                };
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }


    //        return output;

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setData([FromBody] setDataVM model)
    //    {
    //        responseModel response = new responseModel();
    //        string imageToSave = "";
    //        string valueSended = "";
    //        if (model.title.Contains("img"))
    //        {
    //            imageToSave = model.title2[0];
    //        }
    //        if (model.title == "marginsrt")
    //        {
    //            marginVM marginModel = new marginVM();
    //            marginModel.lead = model.title2.Count() > 0 ? Int32.Parse(model.title2[0]) : 0;
    //            marginModel.trail = model.title2.Count() > 1 ? Int32.Parse(model.title2[1]) : 0;
    //            marginModel.top = model.title2.Count() > 2 ? Int32.Parse(model.title2[2]) : 0;
    //            marginModel.bottom = model.title2.Count() > 3 ? Int32.Parse(model.title2[3]) : 0;
    //            valueSended = JsonConvert.SerializeObject(marginModel);
    //        }
    //        else if (model.title == "style")
    //        {
    //            styleVM marginModel = new styleVM();
    //            marginModel.background_image = model.title2.Count() > 0 ? model.title2[0] : "";
    //            imageToSave = model.title2.Count() > 0 ? model.title2[0] : "";
    //            marginModel.background = model.title2.Count() > 1 ? model.title2[1] : "";
    //            marginModel.border_size = model.title2.Count() > 2 ? model.title2[2] : "";
    //            marginModel.border_radius = model.title2.Count() > 3 ? model.title2[3] : "";
    //            marginModel.width = model.title2.Count() > 4 ? model.title2[4] : "";
    //            marginModel.height = model.title2.Count() > 5 ? model.title2[5] : "";
    //            marginModel.padding = model.title2.Count() > 6 ? model.title2[6] : "";
    //            marginModel.margin = model.title2.Count() > 7 ? model.title2[7] : "";
    //            marginModel.box_shadow = model.title2.Count() > 8 ? model.title2[8] : "";
    //            valueSended = JsonConvert.SerializeObject(marginModel);
    //        }
    //        else if (model.title == "paddingsrt")
    //        {
    //            marginVM marginModel = new marginVM();
    //            marginModel.lead = model.title2.Count() > 0 ? Int32.Parse(model.title2[0]) : 0;
    //            marginModel.trail = model.title2.Count() > 1 ? Int32.Parse(model.title2[1]) : 0;
    //            marginModel.top = model.title2.Count() > 2 ? Int32.Parse(model.title2[2]) : 0;
    //            marginModel.bottom = model.title2.Count() > 3 ? Int32.Parse(model.title2[3]) : 0;
    //            valueSended = JsonConvert.SerializeObject(marginModel);
    //        }

    //        else
    //        {
    //            string final = string.Join(",", model.title2);
    //            valueSended = model.title2.Count() > 0 ? final : "";
    //        }



    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (!string.IsNullOrEmpty(imageToSave))
    //                {
    //                    if (!dbcontext.medias.Any(x => x.title == imageToSave))
    //                    {
    //                        dbcontext.medias.Add(new media() { title = imageToSave });
    //                    }
    //                    await dbcontext.SaveChangesAsync();
    //                }
    //                if (model.dataID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    data selectedData = await dbcontext.datas.SingleOrDefaultAsync(x => x.dataID == model.dataID);

    //                    string lastimage = "";
    //                    selectedData.title2 = valueSended;
    //                    selectedData.description = model.description;
    //                    selectedData.Date = DateTime.Now;
    //                    selectedData.writer = "admin";
    //                    selectedData.description2 = model.description2;
    //                    selectedData.viedoIframe = model.viedoIframe;
    //                    selectedData.priority = model.priority;
    //                    selectedData.url = model.url;


    //                    if (!string.IsNullOrEmpty(model.mediaURL))
    //                    {
    //                        lastimage = selectedData.mediaURL;
    //                        selectedData.mediaURL = model.mediaURL;

    //                    }




    //                    response.status = 200;
    //                    response.message = lastimage;
    //                    await dbcontext.SaveChangesAsync();
    //                }
    //                else
    //                {
    //                    data newlItem = new data()
    //                    {
    //                        dataID = Guid.NewGuid(),
    //                        title = model.title,
    //                        title2 = valueSended,
    //                        description = model.description,
    //                        description2 = model.description2,
    //                        mediaURL = model.mediaURL,
    //                        viedoIframe = model.viedoIframe,
    //                        contentID = model.contentID,
    //                        writer = "admin",
    //                        Date = DateTime.Now,
    //                        url = model.url,
    //                        priority = model.priority


    //                    };


    //                    dbcontext.datas.Add(newlItem);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();

    //                }




    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeData([FromBody] setDataVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                data selectedData = await dbcontext.datas.SingleOrDefaultAsync(x => x.dataID == model.dataID);
    //                if (selectedData != null)
    //                {
    //                    dbcontext.datas.Remove(selectedData);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    // pose
    //    [System.Web.Http.HttpPost]
    //    public async Task<poseListVM> getPose([FromBody] contentVM model)
    //    {
    //        poseListVM output = new poseListVM();

    //        using (Context dbcontext = new Context())
    //        {
    //            content content = await dbcontext.contents.Include(x => x.HTML).FirstOrDefaultAsync(x => x.contentID == model.contentID);
    //            string fields = content.HTML.poseField.ToString();

    //            output.poseList = await dbcontext.poses.Where(x => x.contentID == model.contentID).Select(x => new poseVM { contentID = x.contentID, title = x.title, title2 = x.title2, poseID = x.poseID }).ToListAsync();
    //            bool refreshList = false;
    //            if (!string.IsNullOrEmpty(fields))
    //            {
    //                List<string> newItems = fields.Trim(',').Split(',').ToList();
    //                if (output.poseList.Count() != newItems.Count())
    //                {
    //                    foreach (var item in newItems.ToList())
    //                    {
    //                        if (!output.poseList.Any(l => item.ToString().Contains(l.title)))
    //                        {
    //                            pose newlItem = new pose()
    //                            {
    //                                poseID = Guid.NewGuid(),
    //                                title = item,
    //                                title2 = "",
    //                                contentID = model.contentID,
    //                            };
    //                            dbcontext.poses.Add(newlItem);
    //                            refreshList = true;
    //                        }

    //                    }
    //                }
    //            }
    //            if (refreshList)
    //            {
    //                await dbcontext.SaveChangesAsync();
    //                output.poseList = await dbcontext.poses.Where(x => x.contentID == model.contentID).Select(x => new poseVM { poseID = x.poseID, title = x.title, title2 = x.title2, }).ToListAsync();
    //            }


    //            output.selectedContent = new contentVM()
    //            {
    //                contentID = content.contentID,
    //                title = content.title,
    //                image = content.title,
    //                fields = content.HTML.dataField
    //            };

    //            output.allElements = await dbcontext.contents.Where(x => x.sectionID == content.sectionID).Select(x => new contentVM { contentID = x.contentID, title = x.title }).ToListAsync();
    //        }

    //        return output;

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setPose([FromBody] setPoseVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.poseID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    pose selectedData = await dbcontext.poses.SingleOrDefaultAsync(x => x.poseID == model.poseID);

    //                    if (model.isCheckbox == "1")
    //                    {
    //                        if (model.title2 == "on")
    //                        {
    //                            selectedData.title2 = "true";

    //                        }
    //                        else
    //                        {
    //                            selectedData.title2 = "false";

    //                        }
    //                    }
    //                    else
    //                    {
    //                        string toitem = string.IsNullOrEmpty(model.to) ? "" : model.to;
    //                        poseViewVM posemodel = new poseViewVM()
    //                        {
    //                            constant = model.constant,
    //                            to = toitem
    //                        };
    //                        selectedData.title2 = JsonConvert.SerializeObject(posemodel);
    //                    }
    //                    response.status = 200;
    //                    await dbcontext.SaveChangesAsync();
    //                }
    //                else
    //                {
    //                    data newlItem = new data()
    //                    {
    //                        dataID = Guid.NewGuid(),
    //                        contentID = model.contentID,
    //                        title = model.title,

    //                    };

    //                    if (model.isCheckbox == "1")
    //                    {
    //                        newlItem.title2 = "true";
    //                    }
    //                    else
    //                    {
    //                        poseViewVM posemodel = new poseViewVM()
    //                        {
    //                            constant = model.constant,
    //                            to = model.to
    //                        };
    //                        newlItem.title2 = JsonConvert.SerializeObject(posemodel);
    //                    }

    //                    dbcontext.datas.Add(newlItem);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();

    //                }


    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removePose([FromBody] setPoseVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                pose selectedData = await dbcontext.poses.SingleOrDefaultAsync(x => x.poseID == model.poseID);
    //                if (selectedData != null)
    //                {
    //                    dbcontext.poses.Remove(selectedData);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    //layoutpart

    //    [System.Web.Http.HttpPost]
    //    public async Task<layoutPartPageVM> getLayoutPart(sectionLayoutVM model)
    //    {
    //        layoutPartPageVM output = new layoutPartPageVM();

    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                sectionLayout sectionlayout = await dbcontext.sectionLayouts.Include(x => x.Layout).SingleOrDefaultAsync(x => x.sectionLayoutID == model.sectionLayoutID);
    //                output.partlist = await dbcontext.layoutParts.Where(x => x.sectionLayoutID == model.sectionLayoutID).Select(x => new layoutpartVM { layoutPartID = x.layoutPartID, title = x.title, typeName = x.typeName }).ToListAsync();
    //                output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title }).ToListAsync();
    //                output.allPart = await dbcontext.layoutParts.Select(x => new layoutpartVM { layoutPartID = x.layoutPartID, title = x.title, typeName = x.typeName }).ToListAsync();
    //                output.partNames = sectionlayout.Layout.partName.Trim(',').Split(',').ToList();
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        return output;

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setLayoutPart([FromBody] layoutPartSetVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                layoutPart lp = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.title == model.title && x.languageID == model.languageID);
    //                if (lp == null)
    //                {
    //                    layoutPart newlItem = new layoutPart()
    //                    {
    //                        layoutPartID = Guid.NewGuid(),
    //                        sectionLayoutID = model.sectionLayoutID,
    //                        title = model.title,
    //                        languageID = model.languageID,
    //                        typeName = model.typeName
    //                    };


    //                    dbcontext.layoutParts.Add(newlItem);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }
    //                else
    //                {
    //                    response.status = 400;
    //                    response.message = "Item exists";

    //                }




    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeLayoutPart([FromBody] layoutPartSetVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                layoutPart selectedlayoutPart = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == model.layoutPartID);
    //                if (selectedlayoutPart != null)
    //                {
    //                    dbcontext.layoutParts.Remove(selectedlayoutPart);
    //                    response.status = 200;
    //                    response.message = "";
    //                    await dbcontext.SaveChangesAsync();
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    //layoutpartData

    //    [System.Web.Http.HttpPost]
    //    public async Task<layoutPartDataPageVM> getLayoutPartData(layoutpartVM model)
    //    {
    //        layoutPartDataPageVM output = new layoutPartDataPageVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            output.datalist = await dbcontext.layoutDatas.Where(x => x.layoutPartID == model.layoutPartID).Include(x => x.sectionType).Include(x => x.parentData).Select(x => new layoutpartDataVM { dataType = x.dataType, priority = x.priority, urlTitle = x.urlTitle, parentID = x.parentData.parentID, sectionTypeID = x.sectionType.sectionTypeID, parentName = x.parentData != null ? x.parentData.title : "", image = x.image, title = x.title, url = x.url, typeTitle = x.sectionType.title, typeCount = x.typeCount, layoutDataID = x.layoutDataID }).OrderBy(x => x.dataType).OrderByDescending(x => x.priority).ToListAsync();
    //            output.typelist = await dbcontext.sectionTypes.Select(x => new typeVM { title = x.title, typeID = x.sectionTypeID }).ToListAsync();
    //            var layoutpart = await dbcontext.layoutParts.Include(x => x.SectionLayout).Include(x => x.SectionLayout.Layout).SingleOrDefaultAsync(x => x.layoutPartID == model.layoutPartID);

    //            output.layoutpart = new layoutpartVM()
    //            {
    //                layoutPartID = layoutpart.layoutPartID,
    //                title = layoutpart.title,
    //            };
    //            output.partDetailList = layoutpart.SectionLayout.Layout.partDetailName.Trim(',').Split(',').ToList();
    //        }
    //        return output;

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setLayoutPartData([FromBody] layoutpartDataVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {

    //                if (model.layoutDataID == new Guid("00000000-0000-0000-0000-000000000000") || model.layoutDataID == null)
    //                {
    //                    layoutData layoutdata = await dbcontext.layoutDatas.SingleOrDefaultAsync(x => x.title == model.title && x.layoutPartID == model.layoutPartID);
    //                    if (layoutdata == null)
    //                    {
    //                        layoutData newlItem = new layoutData()
    //                        {
    //                            layoutDataID = Guid.NewGuid(),
    //                            title = model.title,

    //                            priority = model.priority,
    //                            dataType = model.dataType,
    //                            url = model.url,
    //                            typeCount = model.typeCount,
    //                            layoutPartID = model.layoutPartID,
    //                            urlTitle = model.urlTitle,

    //                        };
    //                        if (!string.IsNullOrEmpty(model.image))
    //                        {
    //                            newlItem.image = model.image;
    //                        }
    //                        if (model.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        {
    //                            newlItem.sectionTypeID = model.sectionTypeID;
    //                        }
    //                        if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        {
    //                            newlItem.parentID = model.parentID;
    //                        }

    //                        dbcontext.layoutDatas.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                        await dbcontext.SaveChangesAsync();

    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Item exists";
    //                    }

    //                }
    //                else
    //                {
    //                    layoutData layoutdata = await dbcontext.layoutDatas.SingleOrDefaultAsync(x => x.layoutDataID == model.layoutDataID);
    //                    string lastmessag = layoutdata.image;

    //                    layoutdata.title = model.title;
    //                    layoutdata.urlTitle = model.urlTitle;
    //                    layoutdata.priority = model.priority;
    //                    layoutdata.image = model.image;
    //                    layoutdata.dataType = model.dataType;
    //                    layoutdata.url = model.url;
    //                    layoutdata.typeCount = model.typeCount;
    //                    if (model.sectionTypeID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        layoutdata.sectionTypeID = model.sectionTypeID;
    //                    }
    //                    if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        layoutdata.parentID = model.parentID;
    //                    }
    //                    response.message = lastmessag;
    //                    response.status = 200;
    //                    await dbcontext.SaveChangesAsync();

    //                }




    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeLayoutPartData([FromBody] layoutpartDataVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                layoutData selectedlayoutPart = await dbcontext.layoutDatas.Include(x => x.childs).SingleOrDefaultAsync(x => x.layoutDataID == model.layoutDataID);
    //                if (selectedlayoutPart != null)
    //                {
    //                    if (selectedlayoutPart.childs.Count > 0)
    //                    {
    //                        response.status = 400;
    //                        response.message = "this model is uesed in layouts";

    //                    }
    //                    else
    //                    {

    //                        dbcontext.layoutDatas.Remove(selectedlayoutPart);
    //                        response.status = 200;
    //                        response.message = "";
    //                        await dbcontext.SaveChangesAsync();
    //                    }
    //                }



    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    //layout

    //    [System.Web.Http.HttpPost]
    //    public async Task<layoutPageVM> getLayout()
    //    {
    //        layoutPageVM output = new layoutPageVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            output.langauageList = await dbcontext.languages.Select(x => new languagVM { languageID = x.languageID, title = x.title, }).ToListAsync();
    //            output.layoutObjectLists = await dbcontext.sectionLayouts.Include(x => x.Language).Include(x => x.Layout).Include(x => x.LayoutParts).Select(x => new layoutObjectVM { partID = x.LayoutParts.Select(m => m.layoutPartID).ToList(), partnames = x.LayoutParts.Select(d => d.title).ToList(), menuTitle = x.menuTitle, languageName = x.Language.title, description = x.Layout.description, partName = x.Layout.partName, image = x.Layout.image, name = x.Layout.name, title = x.Layout.title, sectionLayoutID = x.sectionLayoutID }).ToListAsync();
    //            output.layoutLists = await dbcontext.layouts.Select(x => new layoutVM { partName = x.partName, description = x.description, image = x.image, layoutID = x.layoutID, name = x.name, title = x.title }).ToListAsync();
    //            output.allPart = await dbcontext.layoutParts.Select(x => new layoutpartVM { title = x.title, typeName = x.typeName, languageID = x.languageID, layoutPartID = x.layoutPartID }).ToListAsync();
    //            foreach (var item in output.layoutLists)
    //            {
    //                //List<layoutPart> lst = dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).ToList();
    //                item.partlist = await dbcontext.layoutParts.Where(x => item.partName.Contains(x.typeName)).Select(x => new layoutpartVM { languageID = x.languageID, title = x.title, typeName = x.typeName, layoutPartID = x.layoutPartID }).ToListAsync();
    //            }

    //        }
    //        return output;

    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setSectionLayout([FromBody] setSectionLayoutVM model)
    //    {
    //        responseModel response = new responseModel();

    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                if (model.sectionLayoutID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {
    //                    sectionLayout selectedLS = await dbcontext.sectionLayouts.Include(x => x.LayoutParts).SingleOrDefaultAsync(x => x.sectionLayoutID == model.sectionLayoutID);
    //                    List<layoutPart> lastids = selectedLS.LayoutParts.ToList();
    //                    foreach (var item in lastids)
    //                    {
    //                        selectedLS.LayoutParts.Remove(item);
    //                    }
    //                    await dbcontext.SaveChangesAsync();

    //                    //foreach (var item in model.layoutPartID)
    //                    //{
    //                    //    Guid idguid = new Guid(item);
    //                    //    layoutPart part = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == idguid);
    //                    //    if (part != null)
    //                    //    {
    //                    //        selectedLS.LayoutParts.Add(part);
    //                    //    }
    //                    //}

    //                    await dbcontext.SaveChangesAsync();

    //                }
    //                else
    //                {
    //                    sectionLayout layoutdata = await dbcontext.sectionLayouts.SingleOrDefaultAsync(x => x.languageID == model.languageID && x.layoutID == model.layoutID && x.menuTitle == model.menuTitle);
    //                    if (layoutdata == null)
    //                    {
    //                        layout selectlayout = await dbcontext.layouts.SingleOrDefaultAsync(x => x.layoutID == model.layoutID);
    //                        Guid sectionlayoutID = Guid.NewGuid();
    //                        sectionLayout newlItem = new sectionLayout()
    //                        {
    //                            sectionLayoutID = sectionlayoutID,
    //                            languageID = model.languageID,
    //                            layoutID = model.layoutID,
    //                            menuTitle = model.menuTitle,


    //                        };


    //                        //foreach (var item in model.layoutPartID)
    //                        //{
    //                        //    Guid idguid = new Guid(item);
    //                        //    layoutPart part = await dbcontext.layoutParts.SingleOrDefaultAsync(x => x.layoutPartID == idguid);
    //                        //    if (part != null)
    //                        //    {
    //                        //        newlItem.LayoutParts.Add(part);
    //                        //    }
    //                        //}
    //                        dbcontext.sectionLayouts.Add(newlItem);
    //                        response.status = 200;
    //                        response.message = "";
    //                        await dbcontext.SaveChangesAsync();

    //                    }
    //                    else
    //                    {
    //                        response.status = 400;
    //                        response.message = "Item exists";
    //                    }
    //                }







    //            }
    //            catch (Exception e)
    //            {
    //                response.status = 400;
    //                response.message = "Error ! ";

    //            }


    //        }

    //        string result = JsonConvert.SerializeObject(response);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }




    //    /////////////////////////////////////////////////////////////////////////////////
    //    ////////////////////////////////////////////////////////////////////////////////
    //    ////////////////////////////////////////////////////////////////////////////////
    //    ///////////////////////////////////////////////////////////////////////////////
    //    ///////////////////////////////////////////////////////////////////////////////

    //    // portal start




    //    public static DbGeography ConvertLatLonToDbGeography(double longitude, double latitude)
    //    {
    //        var point = string.Format("POINT({1} {0})", latitude, longitude);
    //        return DbGeography.FromText(point);
    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> changeUserLocation([FromBody] getCityNameVM model)
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);

    //        Guid userID = new Guid(someObject.ToString());
    //        using (Context dbcontext = new Context())
    //        {
    //            user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
    //            user.lat = model.lat.ToString();
    //            user.lon = model.lon.ToString();
    //            //user.userType = "1";
    //            DbGeography point = ConvertLatLonToDbGeography(model.lon, model.lat);
    //            user.point = point;
    //            await dbcontext.SaveChangesAsync();
    //        }

    //        responseModel mymodel = new responseModel();
    //        mymodel.status = 200;
    //        mymodel.message = "ok";

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    } // در داخل راننده من استفاده نشده




    //    [System.Web.Http.HttpPost]
    //    public async Task<object> sendNotifIOS()
    //    {

    //        string tuoken = SignES256();
    //        responseModel mymodel = new responseModel();
    //        mymodel.status = 200;
    //        mymodel.message = tuoken;

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;





    //    }

    //    public static string SignES25()
    //    {
    //        string privateKey = @"MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgl2NGOBmla4Tcwvbh
    //            CDjHHOrZeD/V4lZ+5QG7k4bXMJKgCgYIKoZIzj0DAQehRANCAARXeYcE/plBzDiG
    //            5rZ3BrYPB2DptI7AeFrEMz9lq67r4UR8/AGLA2V6uE5t9HMwI7XYviZf+Mw8PszC
    //            cpZt0UQ+"; // Create JWT header
    //        var header = $"{{\"alg\":\"ES256\",\"kid\":\"A33U67GF3M\",\"typ\":\"JWT\"}}";

    //        // Create JWT payload
    //        var payload = $"{{\"iss\":\"UU68LW623V\",\"iat\":1723738952}}";
    //        CngKey key = CngKey.Import(
    //            Convert.FromBase64String(privateKey),
    //            CngKeyBlobFormat.Pkcs8PrivateBlob);

    //        using (ECDsaCng dsa = new ECDsaCng(key))
    //        {
    //            dsa.HashAlgorithm = CngAlgorithm.Sha256;
    //            var unsignedJwtData =
    //               Base64UrlEncode(Encoding.UTF8.GetBytes(header)) + "." + Base64UrlEncode(Encoding.UTF8.GetBytes(payload));
    //            var signature =
    //                dsa.SignData(Encoding.UTF8.GetBytes(unsignedJwtData));
    //            return unsignedJwtData + "." + Base64UrlEncode(signature);
    //        }
    //        return "";
    //    }
    //    public static string SignES256()
    //    {
    //        string timestamp = dateTimeConvert.ConvertDateTimeToTimestamp(DateTime.Now).ToString();
    //        string privateKey = @"MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgl2NGOBmla4Tcwvbh
    //            CDjHHOrZeD/V4lZ+5QG7k4bXMJKgCgYIKoZIzj0DAQehRANCAARXeYcE/plBzDiG
    //            5rZ3BrYPB2DptI7AeFrEMz9lq67r4UR8/AGLA2V6uE5t9HMwI7XYviZf+Mw8PszC
    //            cpZt0UQ+";


    //        byte[] key = Convert.FromBase64String(privateKey);
    //        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
    //        // Create JWT header
    //        var header = $"{{\"alg\":\"ES256\",\"kid\":\"A33U67GF3M\",\"typ\":\"JWT\"}}";

    //        // Create JWT payload
    //        var payload = $"{{\"iss\":\"UU68LW623V\",\"iat\":1723734561}}";
    //        // privateKey, Base64UrlEncode(header), Base64UrlEncode(payload)

    //        string base64Header = Base64UrlEncode(Encoding.UTF8.GetBytes(header));
    //        string base64Payload = Base64UrlEncode(Encoding.UTF8.GetBytes(payload));
    //        var cipherText = $"{base64Header}.{base64Payload}";
    //        HMACSHA256 hMACSHA256 = new HMACSHA256(Encoding.UTF8.GetBytes(privateKey));
    //        var hashResult = hMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(cipherText));
    //        var result1 = Base64UrlEncode(hashResult);
    //        var final = $"{base64Header}.{base64Payload}.{result1}";

    //        return final;
    //        //var current_time = DateTime.UtcNow;
    //        //var expiration_time = current_time.AddDays(10);
    //        //var claims = new Claim[]
    //        //{
    //        //   new Claim(JwtRegisteredClaimNames.Iss, "UU68LW623V"),
    //        //   new Claim(JwtRegisteredClaimNames.Iat,GetUnixTimeSeconds().ToString()),
    //        //};
    //        //var permClaims = new List<Claim>();
    //        //permClaims.Add(new Claim(JwtRegisteredClaimNames.Iss, "UU68LW623V"));
    //        //permClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, GetUnixTimeSeconds().ToString()));

    //        //SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
    //        //{
    //        //    Subject = new ClaimsIdentity(permClaims),
    //        //    SigningCredentials = new SigningCredentials(securityKey,
    //        //    SecurityAlgorithms.HmacSha256Signature),

    //        //};
    //        //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    //        //var credentials = new SigningCredentials(securityKey,
    //        //    SecurityAlgorithms.HmacSha256Signature);
    //        //var token = new JwtSecurityToken(claims: claims, signingCredentials: credentials);
    //        ////JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
    //        //token.Header.Remove("typ");
    //        //token.Payload.Remove("nbf");
    //        //token.Payload.Remove("exp");
    //        //token.Header.Add("kid", "A33U67GF3M");

    //        //token.Header["alg"] = "ES256";

    //        //var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
    //        //return handler.WriteToken(token);





    //        ////Base64 URL encode header and payload
    //        //var encodedHeader = Base64UrlEncode(Encoding.UTF8.GetBytes(header));
    //        //var encodedPayload = Base64UrlEncode(Encoding.UTF8.GetBytes(payload));

    //        ////Combine header and payload
    //        //var unsignedJwtData = $"{encodedHeader}.{encodedPayload}";


    //        //Create CngKey from the privateKey
    //        //try
    //        //{


    //        //    var secretKeyFile = Convert.FromBase64String(privateKey);
    //        //    var secretKey = CngKey.Import(secretKeyFile, CngKeyBlobFormat.Pkcs8PrivateBlob);

    //        //    Sign the data
    //        //    using (ECDsaCng dsa = new ECDsaCng(secretKey))
    //        //    {
    //        //        dsa.HashAlgorithm = CngAlgorithm.Sha256;

    //        //        Sign the unsigned JWT data
    //        //       var signature = dsa.SignData(Encoding.UTF8.GetBytes(unsignedJwtData));

    //        //        Return the final JWT token
    //        //        return $"{unsignedJwtData}.{Base64UrlEncode(signature)}";
    //        //    }
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    return $"Error importing CngKey: {ex.InnerException.InnerException.ToString()}";
    //        //    Handle or log the exception as needed
    //        //}



    //    }


    //    private static long GetUnixTimeSeconds()
    //    {
    //        return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
    //    }

    //    private static string Base64UrlEncode(byte[] input)
    //    {
    //        // Encode to Base64 and replace special characters
    //        var base64 = Convert.ToBase64String(input);
    //        return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
    //    }
    //    private static string Base64UrlEncode(string input)
    //    {
    //        var bytes = Encoding.UTF8.GetBytes(input);
    //        return Base64UrlEncode(bytes);
    //    }



    //    private async Task<JObject> sendNotif(string userType, string userID, string notifTitle, string notifType, string notifFlowID)
    //    {
    //        using (Context dbcontext = new Context())
    //        {
    //            //order order = dbcontext.orders.ToList().Last();
    //            //string orderID = order.orderID.ToString();
    //            //DbGeography point = ConvertLatLonToDbGeography(model.lat, model.lon);
    //            List<user> useddrs = new List<user>();
    //            if (!string.IsNullOrEmpty(userType))
    //            {
    //                useddrs = (from u in dbcontext.users where u.firebaseToken != null && u.userType == userType select u).ToList();

    //            }
    //            if (!string.IsNullOrEmpty(userID))
    //            {
    //                Guid userguid = new Guid(userID);
    //                useddrs = (from u in dbcontext.users where u.firebaseToken != null && u.userID == userguid select u).ToList();

    //            }
    //            string src = HostingEnvironment.ApplicationPhysicalPath + "\\private\\key.json";
    //            if (FirebaseApp.DefaultInstance == null)
    //            {
    //                FirebaseApp.Create(new AppOptions()
    //                {
    //                    Credential = GoogleCredential.FromFile(src),
    //                });
    //            }


    //            foreach (var item in useddrs)
    //            {

    //                item.badge += 1;
    //                try
    //                {
    //                    notifVM fm = new notifVM();
    //                    bigStyle big_style = new bigStyle();
    //                    big_style.type = "";
    //                    titleModel title = new titleModel();
    //                    title.text = "";
    //                    clickAction click_action = new clickAction();
    //                    click_action.title = "";
    //                    click_action.type = "openapp";
    //                    click_action.data = "/home/viewDetail?q=";
    //                    fm.big_style = big_style;
    //                    fm.title = title;
    //                    fm.click_action = click_action;
    //                    callBackVM callback = new callBackVM();
    //                    callback.type = notifType;
    //                    callback.data = notifFlowID;
    //                    string mdljson = JsonConvert.SerializeObject(callback);
    //                    Dictionary<string, string> dat = new Dictionary<string, string>();
    //                    dat.Add("mydata", mdljson);
    //                    var message = new Message()
    //                    {

    //                        Data = dat,
    //                        Notification = new Notification
    //                        {
    //                            Title = notifTitle,
    //                            Body = "",
    //                        },
    //                        Android = new AndroidConfig
    //                        {
    //                            Notification = new AndroidNotification
    //                            {
    //                                Sound = "default",
    //                                NotificationCount = item.badge,
    //                            }
    //                        },
    //                        Apns = new ApnsConfig
    //                        {
    //                            Aps = new Aps
    //                            {
    //                                Sound = "default",
    //                                ContentAvailable = true,
    //                                Badge = item.badge
    //                            },

    //                        },
    //                        Token = item.firebaseToken
    //                    };
    //                    var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
    //                }
    //                catch (Exception e)
    //                {


    //                }

    //            }

    //            await dbcontext.SaveChangesAsync();
    //        }

    //        responseModel mymodel = new responseModel();
    //        mymodel.status = 200;
    //        mymodel.message = "ok";

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;

    //    }
    //    private async Task<string> sendCallNotif(string userToken)
    //    {
    //        using (Context dbcontext = new Context())
    //        {

    //            //Guid guuid = new Guid(userToken);
    //            //user useddrs = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == guuid);
    //            // return useddrs.firebaseToken;
    //            string src = HostingEnvironment.ApplicationPhysicalPath + "\\private\\key.json";
    //            if (FirebaseApp.DefaultInstance == null)
    //            {
    //                FirebaseApp.Create(new AppOptions()
    //                {
    //                    Credential = GoogleCredential.FromFile(src),
    //                });
    //            }


    //            try
    //            {
    //                notifVM fm = new notifVM();
    //                bigStyle big_style = new bigStyle();
    //                big_style.type = "";
    //                titleModel title = new titleModel();
    //                title.text = "";
    //                clickAction click_action = new clickAction();
    //                click_action.title = "";
    //                click_action.type = "openapp";
    //                click_action.data = "/home/viewDetail?q=";
    //                fm.big_style = big_style;
    //                fm.title = title;
    //                fm.click_action = click_action;
    //                callBackVM callback = new callBackVM();
    //                callback.type = "joinCall";
    //                callback.data = "";
    //                string mdljson = JsonConvert.SerializeObject(callback);
    //                Dictionary<string, string> dat = new Dictionary<string, string>();
    //                dat.Add("mydata", mdljson);
    //                var message = new Message()
    //                {

    //                    Data = dat,
    //                    Notification = new Notification
    //                    {
    //                        Title = "زنگ جدید داری یارو",
    //                        Body = "",


    //                    },
    //                    Token = "f1855099b91012abae31e4e7557312ece355172ba3aca0e0c886774969ff8179"// item.firebaseToken
    //                };
    //                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
    //            }
    //            catch (Exception e)
    //            {


    //            }

    //            return "";
    //        }
    //        //responseModel mymodel = new responseModel();
    //        //mymodel.status = 200;
    //        //mymodel.message = "ok";

    //        //string result = JsonConvert.SerializeObject(mymodel);
    //        //JObject jObject = JObject.Parse(result);
    //        //return jObject;

    //    }

    //    [System.Web.Http.HttpPost]
    //    public async Task<sendCityVM> getCity([FromBody] getCityVM model)
    //    {
    //        sendCityVM output = new sendCityVM();

    //        using (Context dbcontext = new Context())
    //        {

    //            if (model == null)
    //            {

    //                List<newcity> cities = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
    //                output.lst = cities;
    //                output.status = 200;

    //            }
    //            else
    //            {
    //                if (model.search == null && model.ID == null)
    //                {
    //                    List<newcity> cities = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
    //                    output.lst = cities;
    //                    output.status = 200;
    //                }
    //                else
    //                {
    //                    if (!string.IsNullOrEmpty(model.search))
    //                    {

    //                        List<city> cities = dbcontext.cities.ToList();
    //                        List<newcity> afterSearch = await (from u in dbcontext.cities
    //                                                           join p in dbcontext.cities on u.parentID equals p.userID
    //                                                           where u.userID != u.parentID && (p.title.Contains(model.search) || u.title.Contains(model.search))
    //                                                           select new newcity { title = u.title + " ( " + p.title + " ) ", userID = u.userID, parentID = u.parentID }).ToListAsync();


    //                        output.lst = afterSearch;
    //                        output.status = 200;

    //                    }
    //                    else
    //                    {
    //                        Guid myguid = new Guid(model.ID);
    //                        List<newcity> afterSearch = await (from u in dbcontext.cities
    //                                                           join p in dbcontext.cities on u.parentID equals p.userID
    //                                                           where u.parentID == myguid && u.userID != u.parentID
    //                                                           select new newcity { title = u.title + " ( " + p.title + " ) ", userID = u.userID, parentID = u.parentID }).ToListAsync();
    //                        output.lst = afterSearch;
    //                        output.status = 200;


    //                    }
    //                }




    //            }

    //        }


    //        return output;
    //    }



    //    [System.Web.Http.HttpPost]
    //    public JObject register([FromBody] doSignIn model)
    //    {

    //        responseModel output = new responseModel();
    //        string outputstring = "";
    //        Random rnd = new Random();
    //        int num = rnd.Next(1111, 9999);


    //        using (Context dbcontext = new Context())
    //        {


    //            //Guid Userguid = new Guid("5417296b-b07e-404a-bc71-f04dc8baac2f");

    //            //user user = dbcontext.users.SingleOrDefault(x => x.userID == Userguid);
    //            //dbcontext.users.Remove(user);
    //            //dbcontext.SaveChanges();
    //            user myuser = dbcontext.users.SingleOrDefault(x => x.phone == model.phone && x.userType == model.userType);
    //            if (myuser != null)
    //            {
    //                myuser.code = "9999"; // num.ToString(),
    //            }
    //            else
    //            {
    //                string status = model.userType == "1" ? "1" : "0";
    //                Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
    //                Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;

    //                user newuser = new user()
    //                {
    //                    userID = Guid.NewGuid(),
    //                    phone = model.phone,
    //                    name = "",
    //                    code = "9999", // num.ToString(),
    //                    userType = model.userType,
    //                    verifyStatusID = statusID,
    //                    workingStatusID = workingID
    //                };
    //                dbcontext.users.Add(newuser);
    //            }

    //            dbcontext.SaveChanges();
    //        }

    //        output.status = 200;
    //        outputstring = JsonConvert.SerializeObject(output);
    //        JObject jObject = JObject.Parse(outputstring); return jObject;


    //    }



    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> UploadFiles()
    //    {
    //        try
    //        {
    //            responseModel mymodel = new responseModel();
    //            ////Create the Directory.
    //            string path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
    //            if (!Directory.Exists(path))
    //            {
    //                Directory.CreateDirectory(path);
    //            }

    //            //Fetch the File.
    //            HttpPostedFile postedFile = System.Web.HttpContext.Current.Request.Files[0];


    //            string fileName = "";
    //            string name = methods.RandomString(5);
    //            //Fetch the File Name.
    //            fileName = name + Path.GetExtension(postedFile.FileName);
    //            //Save the File.
    //            postedFile.SaveAs(path + fileName);
    //            mymodel.status = 200;
    //            mymodel.message = fileName;
    //            //Send OK Response to Client.
    //            string result = JsonConvert.SerializeObject(mymodel);
    //            JObject jObject = JObject.Parse(result);
    //            return jObject;
    //        }



    //        catch (Exception baseException)
    //        {

    //            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
    //            {
    //                Content = new StringContent(baseException.Message),
    //                ReasonPhrase = "Critical Exception"
    //            });
    //        }

    //    }

    //    //[HttpPost]
    //    //public async Task<JObject> UploadFilesAsync([Microsoft.AspNetCore.Mvc.FromForm] UploadModel model)

    //    //{
    //    //    int size = model.Files.Sum(f => f.Length);
    //    //    string fileName = "";
    //    //    foreach (var formFile in model.Files)
    //    //    {
    //    //        if (formFile.Length > 0)
    //    //        {
    //    //            var uploads = System.Web.HttpContext.Current.Server.MapPath("/uploads") ; 
    //    //            var filePath = Path.GetTempFileName();
    //    //            fileName = Path.GetFileName(formFile.FileName);
    //    //            using (var stream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
    //    //            {
    //    //                await formFile.CopyToAsync(stream);
    //    //            }
    //    //        }

    //    //    }
    //    //    responseModel mymodel = new responseModel();
    //    //    mymodel.status = 200;
    //    //    mymodel.message = fileName;
    //    //    string result = JsonConvert.SerializeObject(mymodel);
    //    //    JObject jObject = JObject.Parse(result);
    //    //    return jObject;

    //    //}

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<panelSetOrder> setOrderAction()
    //    {
    //        sendCityVM citylist = new sendCityVM();
    //        sendLoadTypeVM loadList = new sendLoadTypeVM();
    //        sendTypeVM typeList = new sendTypeVM();
    //        using (Context dbcontext = new Context())
    //        {
    //            citylist.lst = await dbcontext.cities.Where(x => x.userID == x.parentID).Select(x => new newcity { title = x.title, parentID = x.parentID, userID = x.userID }).ToListAsync();
    //            panelSetOrder fmodel = new panelSetOrder()
    //            {
    //                cityList = citylist,
    //                loadList = loadList,
    //                typeList = typeList.lst

    //            };

    //            return fmodel;
    //        }

    //    }































    //    //[BasicAuthentication]
    //    //[System.Web.Http.HttpPost]
    //    //public async Task<getDashbaord> getDashboard()
    //    //{

    //    //    getDashbaord obj = new getDashbaord();
    //    //    object someObject;
    //    //    Request.Properties.TryGetValue("UserToken", out someObject);

    //    //    Guid userID = new Guid(someObject.ToString());
    //    //    using (Context dbcontext = new Context())
    //    //    {
    //    //        user user = dbcontext.users.SingleOrDefault(x => x.userID == userID);
    //    //        if (!string.IsNullOrEmpty(user.typeID))
    //    //        {
    //    //            Guid carguid = new Guid(user.typeID);

    //    //            obj.status = 200;
    //    //        }
    //    //        List<city> citylist = dbcontext.cities.ToList();
    //    //        List<newcity> citySelected = (from u in dbcontext.cities
    //    //                                      where u.userID != u.parentID
    //    //                                      let distance = u.citypoint.Distance(user.point)
    //    //                                      orderby distance ascending
    //    //                                      select new newcity { title = u.title, parentID = u.parentID, userID = u.userID, lat = u.lat, lon = u.lon }).ToList();
    //    //        obj.origin = citySelected.First();
    //    //        obj.status = 200;


    //    //    }
    //    //    return obj;
    //    //}




















    //    // process
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<processActionVM> getProcess()
    //    {
    //        object someObject;
    //        processActionVM responseModel = new processActionVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                var query = from process in dbcontext.processes
    //                            where process.userID == userID
    //                            select new processVM
    //                            {
    //                                processID = process.processID,
    //                                title = process.title
    //                            };
    //                responseModel.processList = await query.ToListAsync();
    //                //responseModel.formulaList = await dbcontext.formulas.Where(x => x.name != "").ToListAsync();
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }


    //        return responseModel;
    //    }

    //    //processFormula
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<processFormulaActionVM> getProcessFormula([FromBody] process model)
    //    {
    //        object someObject;
    //        processFormulaActionVM responseModel = new processFormulaActionVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());

    //        using (Context dbcontext = new Context())
    //        {

    //            var query = from process in dbcontext.processes select process;
    //            responseModel.processFormulaList = await dbcontext.processFormulas.Include(x => x.Process).Include(x => x.Coding).Include(x => x.Formula).Where(x => x.proccessID == model.processID).Select(x => new processFormulaVM { codingType = x.transactionType, codingName = x.Coding.title, formulaName = x.Formula.name, processFormulaID = x.processFormulaID, }).ToListAsync();

    //            responseModel.FormulaList = await dbcontext.formulas.Where(x => x.name != "" && x.name != null).Select(x => new formulaVM { formulaID = x.formulaID, name = x.name }).ToListAsync();
    //            responseModel.codingList = await dbcontext.codings.Where(x => x.userID == userID).OrderBy(x => x.codeHesab).Select(x => new codingVM { codingID = x.codingID, title = x.title + "(" + x.codeHesab + ")" }).ToListAsync();

    //        }

    //        return responseModel;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setProcessFormula([FromBody] processFormula model)
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());

    //        using (Context dbcontext = new Context())
    //        {
    //            responseModel mymodel = new responseModel();
    //            processFormula pf = await dbcontext.processFormulas.SingleOrDefaultAsync(x => x.FormulaID == model.FormulaID && x.proccessID == model.proccessID);

    //            if (pf == null)
    //            {
    //                dbcontext.processFormulas.Add(new processFormula { codingID = model.codingID, FormulaID = model.FormulaID, proccessID = model.proccessID, transactionType = model.transactionType, processFormulaID = Guid.NewGuid() });
    //                await dbcontext.SaveChangesAsync();
    //                mymodel.status = 200;
    //                mymodel.message = "ok";
    //            }
    //            else
    //            {
    //                mymodel.status = 400;
    //                mymodel.message = "آیتم مورد نظر وجود دارد";
    //            }

    //            string result = JsonConvert.SerializeObject(mymodel);
    //            JObject jObject = JObject.Parse(result);
    //            return jObject;
    //        }
    //    }



    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setProcess([FromBody] process model)
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                responseModel mymodel = new responseModel();
    //                var process = await dbcontext.processes.FirstOrDefaultAsync(i => i.title == model.title);
    //                if (process == null)
    //                {
    //                    dbcontext.processes.Add(new process() { userID = userID, processID = Guid.NewGuid(), title = model.title });
    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }

    //                string result = JsonConvert.SerializeObject(mymodel);
    //                JObject jObject = JObject.Parse(result);
    //                return jObject;
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    //processForm
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<processFormActionVM> getProcessForm([FromBody] process model)
    //    {
    //        object someObject;
    //        processFormActionVM responseModel = new processFormActionVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                var query = from process in dbcontext.processes select process;
    //                process q = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
    //                responseModel.processFormList = q.formList.Select(x => new processFormVM { processFormID = x.formID, title = x.title }).ToList();
    //                responseModel.allForm = await dbcontext.forms.Select(x => new processFormVM { processFormID = x.formID, title = x.title }).ToListAsync();

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }


    //        return responseModel;
    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setNewFormProcess([FromBody] setNewFormProcessVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());

    //            using (Context dbcontext = new Context())
    //            {
    //                process pr = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
    //                form frm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);
    //                if (!pr.formList.Contains(frm))
    //                {
    //                    pr.formList.Add(frm);
    //                    await dbcontext.SaveChangesAsync();
    //                    mymodel.status = 200;
    //                    mymodel.message = "";
    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "آیتم تکراری";
    //                }



    //            }


    //        }
    //        catch (Exception)
    //        {
    //            mymodel.status = 400;
    //            mymodel.message = "خطا";

    //        }
    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeProcessForm([FromBody] setNewFormProcessVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());

    //            using (Context dbcontext = new Context())
    //            {
    //                process pr = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == model.processID);
    //                form frm = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);
    //                pr.formList.Remove(frm);
    //                await dbcontext.SaveChangesAsync();
    //            }


    //        }
    //        catch (Exception)
    //        {
    //            mymodel.status = 400;
    //            mymodel.message = "خطا";

    //        }
    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    //formItem



    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<formItemActionVM> getFormItem(form model)
    //    {
    //        object someObject;
    //        formItemActionVM responseModel = new formItemActionVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());

    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {

    //                var query = dbcontext.formItems.Where(x => x.formID == model.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.FormItemType).Select(x => new formItemVM { continueWithError = x.continueWithError.ToString(), maxNumber = x.maxNumber, minNumber = x.minNumber, isRequired = x.isRequired, validationType = x.validationType, regx = x.regx, referTo = x.referTo, priority = x.priority, isHidden = x.isHidden, groupNumber = x.groupNumber, formID = x.formID, UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType });
    //                responseModel.formItemList = await query.ToListAsync();

    //                query = dbcontext.formItems.Select(x => new formItemVM { formID = x.formID, formItemID = x.formItemID, itemName = x.itemName }); ;
    //                responseModel.formItemListALL = await query.ToListAsync();

    //                var query2 = dbcontext.orderOptions.Where(x => x.userID == userID && x.orderOptionID == x.parentID).Select(x => new orderOptionVM { image = x.image, orderOptionID = x.orderOptionID, title = x.title });
    //                responseModel.orderOptionList = await query2.ToListAsync();

    //                var query3 = dbcontext.formItemTypes.Select(x => new formItemTypeVM { title = x.title, formItemTypeID = x.formItemTypeID });
    //                responseModel.formItemTypeList = await query3.ToListAsync();

    //                var query4 = dbcontext.formItemDesigns.Select(x => new formItemDesingVM { title = x.title, formItemDesingID = x.formItemDesignID });
    //                responseModel.formItemDesingList = await query4.ToListAsync();

    //                responseModel.allForm = await dbcontext.forms.Select(x => new processFormVM { title = x.title, processFormID = x.formID }).ToListAsync();
    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        return responseModel;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setFormItem([FromBody] formItemVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());

    //            using (Context dbcontext = new Context())
    //            {

    //                string continueWithError = model.continueWithError == "on" ? "1" : "0";
    //                if (model.formItemID != 0)
    //                {

    //                    var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.formItemID == model.formItemID);
    //                    if (string.IsNullOrEmpty(model.itemtImage))
    //                    {
    //                        mymodel.message = model.itemtImage;
    //                    }
                        
    //                    formItem.itemtImage = model.itemtImage;
    //                    formItem.itemName = model.itemName;
    //                    formItem.priority = model.priority;
    //                    formItem.itemPlaceholder = model.itemPlaceholder;
    //                    formItem.itemDesc = model.itemDesc;
    //                    formItem.formItemTypeID = model.formItemTypeID;
    //                    formItem.OptionID = model.optionSelected;
    //                    formItem.isMultiple = model.isMultiple;
    //                    formItem.isRequired = model.isRequired;
    //                    formItem.validationType = model.validationType;
    //                    formItem.otherFieldName = model.otherFieldName;
    //                    formItem.referTo = model.referTo;
    //                    formItem.isRequired = model.isRequired;
    //                    formItem.minNumber = model.minNumber;
    //                    formItem.maxNumber = model.maxNumber;
    //                    formItem.regx = model.regx;
    //                    formItem.groupNumber = model.groupNumber;
    //                    formItem.continueWithError = continueWithError;
    //                    mymodel.status = 200;
    //                    await dbcontext.SaveChangesAsync();


    //                }
    //                else
    //                {
    //                    var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.itemName == model.itemName && i.formID == model.formID && i.itemDesc == model.itemDesc);
    //                    if (formItem == null)
    //                    {

    //                        formItem fri = new formItem()
    //                        {
    //                            catchUrl = model.catchUrl,
    //                            itemDesc = model.itemDesc,
    //                            isMultiple = model.isMultiple,
    //                            formID = model.formID,
    //                            formItemTypeID = model.formItemTypeID,
    //                            itemtImage = model.itemtImage,
    //                            itemName = model.itemName,
    //                            mediaType = model.mediaType,
    //                            itemPlaceholder = model.itemPlaceholder,
    //                            OptionID = model.optionSelected,
    //                            groupNumber = model.groupNumber,
    //                            formItemDesingID = model.formItemDesingID,
    //                            relatedForemItemID = model.relatedFormItemID,
    //                            isHidden = model.hiddenCheckBox == "on" ? 1 : 0,
    //                            priority = model.priority,
    //                            isRequired = model.isRequired,
    //                            referTo = model.referTo,
    //                            otherFieldName = model.otherFieldName,
    //                            validationType = model.validationType,
    //                            minNumber = model.minNumber,
    //                            maxNumber = model.maxNumber,
    //                            regx = model.regx,
    //                            continueWithError = continueWithError

    //                        };


    //                        dbcontext.formItems.Add(fri);
    //                        await dbcontext.SaveChangesAsync();

    //                        mymodel.status = 200;
    //                        mymodel.message = "ok";

    //                    }
    //                    else
    //                    {
    //                        mymodel.status = 400;
    //                        mymodel.message = "پروسه هم نام وجود دارد";
    //                    }
    //                }



    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeFormItem([FromBody] formItemVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());
    //            using (Context dbcontext = new Context())
    //            {

    //                var formItem = await dbcontext.formItems.FirstOrDefaultAsync(i => i.formItemID == model.formItemID);
    //                if (formItem != null)
    //                {
    //                    mymodel.message = formItem.itemtImage;
    //                    dbcontext.formItems.Remove(formItem);
    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;


    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "!خطا";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            mymodel.status = 400;
    //            mymodel.message = "!خطا";
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    // formula
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<formulaActionVM> getFormula(process process)
    //    {
    //        object someObject;
    //        object phone;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Request.Properties.TryGetValue("Userp", out phone);
    //        Guid userID = new Guid(someObject.ToString());


    //        formulaActionVM model = new formulaActionVM();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                process prc = await dbcontext.processes.Include(x => x.formList).SingleOrDefaultAsync(x => x.processID == process.processID);
    //                List<formulaVM> formulalst = new List<formulaVM>();
    //                var query = dbcontext.formulas.Where(x => x.userID == userID).Include(x => x.namad).Include(x => x.FormItem).AsQueryable();
    //                //List<formula> lst = query.ToList();
    //                List<formulaVM> formulas = await query.Select(item => new formulaVM
    //                {
    //                    col = item.col,
    //                    formulaID = item.formulaID,
    //                    leftID = item.leftID,
    //                    name = item.name,
    //                    number = item.number,
    //                    result = item.result,
    //                    rightID = item.rightID,
    //                    namadName = item.namad == null ? "" : item.namad.value,
    //                    formItemName = item.FormItem == null ? "" : item.FormItem.itemDesc

    //                }).ToListAsync();

    //                int id1 = prc.formList.FirstOrDefault().formID;
    //                int id2 = prc.formList.Skip(1).FirstOrDefault().formID;
    //                formItemType frt = await dbcontext.formItemTypes.SingleOrDefaultAsync(x => x.title == "آیتم عددی");
    //                var query1 = from formItem in dbcontext.formItems where formItem.formItemTypeID == frt.formItemTypeID select new formItemVM { itemDesc = formItem.itemDesc, formItemID = formItem.formItemID };
    //                var query2 = from namad in dbcontext.namads select new namadVM { namadID = namad.namadID, title = namad.value };
    //                model.formulaList = formulas;
    //                model.formItemList = await query1.ToListAsync();
    //                model.namadList = await query2.ToListAsync();
    //                return model;
    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setFormula([FromBody] formula model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());
    //            model.userID = userID;
    //            using (Context dbcontext = new Context())
    //            {

    //                var process = await dbcontext.formulas.FirstOrDefaultAsync(i => i.leftID == model.leftID && i.rightID == model.rightID && i.number == model.number && i.namadID == model.namadID && i.formItemID == model.formItemID && i.col == model.col);
    //                if (process == null)
    //                {
    //                    var lastprocess = await dbcontext.formulas.OrderByDescending(x => x.col).FirstOrDefaultAsync();
    //                    int col = lastprocess != null ? lastprocess.col + 1 : 1;

    //                    var finalLeftFun = await dbcontext.formulas.FirstOrDefaultAsync(x => x.col == model.leftID);
    //                    var finalRightFun = await dbcontext.formulas.FirstOrDefaultAsync(x => x.col == model.rightID);



    //                    formItem fi = await dbcontext.formItems.SingleOrDefaultAsync(x => x.formItemID == model.formItemID);
    //                    namad na = await dbcontext.namads.SingleOrDefaultAsync(x => x.namadID == model.namadID);

    //                    string fuNamad = HttpUtility.HtmlDecode(na.value);
    //                    string numberormabna = "";
    //                    if (fi != null || model.number != 0)
    //                    {
    //                        numberormabna = model.number == 0 ? fi.itemDesc : model.number.ToString();

    //                    }

    //                    model.result = (model.leftID == 0 && model.rightID == 0) ? "( " + numberormabna + " )" : "( " + finalLeftFun.result + " " + fuNamad + " " + finalRightFun.result + " )";


    //                    dbcontext.formulas.Add(new formula() { processID = model.processID, name = model.name, userID = userID, formItemID = model.formItemID, number = model.number, formulaID = Guid.NewGuid(), namadID = model.namadID, leftID = model.leftID, rightID = model.rightID, col = col, result = model.result });
    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    // coding
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<List<codingVM>> getCoding()
    //    {
    //        object someObject;
    //        try
    //        {

    //            object phone;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Request.Properties.TryGetValue("Userp", out phone);
    //            Guid userID = new Guid(someObject.ToString());
    //            formulaActionVM model = new formulaActionVM();
    //            using (Context dbcontext = new Context())
    //            {
    //                user userItem = await dbcontext.users.Where(x => x.phone == phone.ToString() && x.userType == "0").Include(x => x.Codings).SingleOrDefaultAsync();
    //                List<codingVM> lst = new List<codingVM>();
    //                foreach (var coding in userItem.Codings)
    //                {
    //                    lst.Add(new codingVM()
    //                    {
    //                        codeHesab = coding.codeHesab,
    //                        codingID = coding.codingID,
    //                        codingType = coding.codingType,
    //                        parentID = coding.parentID,
    //                        title = coding.title,
    //                        inList = coding.inList

    //                    });

    //                }
    //                return lst;

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setCoding([FromBody] coding model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());
    //            model.userID = userID;

    //            if (model.codingID != new Guid("00000000-0000-0000-0000-000000000000"))
    //            {
    //                using (Context dbcontext = new Context())
    //                {
    //                    var coding = await dbcontext.codings.FirstOrDefaultAsync(i => i.codingID == model.codingID);
    //                    coding.inList = model.inList == "on" ? "1" : "0";
    //                    coding.title = model.title;
    //                    coding.codeHesab = model.codeHesab;
    //                    await dbcontext.SaveChangesAsync();
    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";


    //                }
    //            }
    //            else
    //            {
    //                using (Context dbcontext = new Context())
    //                {

    //                    var coding = await dbcontext.codings.FirstOrDefaultAsync(i => i.codeHesab == model.codeHesab);
    //                    if (coding == null)
    //                    {

    //                        coding parentcoding = await dbcontext.codings.FirstOrDefaultAsync(x => x.codingID == model.parentID);

    //                        int itemCodingType = 1;


    //                        if (parentcoding != null)
    //                        {
    //                            int parentCodingType = parentcoding.codingType;
    //                            switch (parentCodingType)
    //                            {

    //                                case 1:
    //                                    itemCodingType = 2;
    //                                    break;
    //                                case 2:
    //                                    itemCodingType = 3;
    //                                    break;
    //                                case 3:
    //                                    itemCodingType = 4;
    //                                    break;
    //                                case 4:
    //                                    itemCodingType = 5;
    //                                    break;
    //                                case 5:
    //                                    itemCodingType = 6;
    //                                    break;
    //                                case 6:
    //                                    itemCodingType = 7;
    //                                    break;
    //                                case 7:
    //                                    itemCodingType = 8;
    //                                    break;
    //                            }
    //                        }

    //                        dbcontext.codings.Add(new coding() { userID = userID, codingID = Guid.NewGuid(), codingType = itemCodingType, parentID = model.parentID, codeHesab = model.codeHesab, title = model.title });
    //                        await dbcontext.SaveChangesAsync();

    //                        mymodel.status = 200;
    //                        mymodel.message = "ok";

    //                    }
    //                    else
    //                    {
    //                        mymodel.status = 400;
    //                        mymodel.message = "پروسه هم نام وجود دارد";
    //                    }


    //                }
    //            }


    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    // products


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<productActionVM> getProductsAsync()
    //    {
    //        object someObject;
    //        try
    //        {

    //            object phone;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Request.Properties.TryGetValue("Userp", out phone);
    //            Guid userID = new Guid(someObject.ToString());
    //            productActionVM model = new productActionVM();
    //            using (Context dbcontext = new Context())
    //            {
    //                var products = await dbcontext.products.Where(x => x.userID == userID).Include(x => x.productTypes).Include(x => x.Tags).ToListAsync();//.Include(x => x.productType)
    //                List<productVM> finallst = new List<productVM>();
    //                foreach (var x in products)
    //                {
    //                    productVM vmproducts = new productVM()
    //                    {
    //                        address = x.address,
    //                        code = x.code,
    //                        productID = x.productID,
    //                        title = x.title,
    //                        //productTypesrt = x.productType.title,
    //                        tagsrt = String.Join(", ", x.Tags.Select(t => t.title)),
    //                        productTypesrt = String.Join(", ", x.productTypes.Select(t => t.title)),

    //                    };
    //                    finallst.Add(vmproducts);

    //                };
    //                model.productList = finallst;
    //                model.productTypeList = await dbcontext.productTypes.Select(x => new productTypeVM { productTypeID = x.productTypeID, title = x.title, parentID = x.parentID }).ToListAsync();
    //                model.taglist = await dbcontext.tags.Where(x => x.userID == userID).Select(x => new tagVM { tagID = x.tagID, title = x.title }).ToListAsync();
    //                return model;

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setProductAsync([FromBody] addProductVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());
    //            using (Context dbcontext = new Context())
    //            {

    //                var product = await dbcontext.products.FirstOrDefaultAsync(x => x.title == model.title && x.code == model.code && x.barcode == model.barcode);
    //                if (product == null)
    //                {
    //                    Guid productID = Guid.NewGuid();
    //                    product myproduct = new product() { userID = userID, productID = productID, address = model.address, barcode = model.barcode, code = model.code, title = model.title };
    //                    dbcontext.products.Add(myproduct);
    //                    await dbcontext.SaveChangesAsync();
    //                    product selectedproduct = await dbcontext.products.Include(x => x.productTypes).Include(x => x.Tags).SingleOrDefaultAsync(x => x.productID == productID);
    //                    foreach (var item in model.productTypeID)
    //                    {
    //                        productType prt = await dbcontext.productTypes.SingleOrDefaultAsync(x => x.productTypeID == item);
    //                        selectedproduct.productTypes.Add(prt);


    //                    }
    //                    foreach (var item in model.produtTagID)
    //                    {
    //                        tag prt = await dbcontext.tags.SingleOrDefaultAsync(x => x.tagID == item);
    //                        selectedproduct.Tags.Add(prt);

    //                    }

    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> removeProductAsync([FromBody] addProductVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());
    //            using (Context dbcontext = new Context())
    //            {

    //                var product = await dbcontext.products.FirstOrDefaultAsync(x => x.productID == model.productID);
    //                if (product != null)
    //                {
    //                    dbcontext.products.Remove(product);

    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            mymodel.status = 400;
    //            mymodel.message = "امکان حذف محصول وجود ندارد";
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    //productType
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<productTypeActionVM> getProductTypeAsync()
    //    {
    //        object someObject;
    //        try
    //        {

    //            object phone;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Request.Properties.TryGetValue("Userp", out phone);
    //            Guid userID = new Guid(someObject.ToString());
    //            productTypeActionVM model = new productTypeActionVM();
    //            using (Context dbcontext = new Context())
    //            {
    //                var products = await dbcontext.productTypes.Where(x => x.userID == userID).Where(x => x.productTypeID == x.parentID).Select(x => new productTypeVM
    //                {
    //                    parentID = x.parentID,
    //                    productTypeID = x.productTypeID,
    //                    title = x.title

    //                }).ToListAsync();
    //                model.prtlist = products;
    //                return model;

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> addProductTypeAsync([FromBody] addProductTypeVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());

    //            using (Context dbcontext = new Context())
    //            {

    //                var coding = await dbcontext.productTypes.FirstOrDefaultAsync(i => i.title == model.title);
    //                if (coding == null)
    //                {
    //                    Guid ptid = Guid.NewGuid();
    //                    Guid parenttid = ptid;


    //                    productType pr = new productType()
    //                    {
    //                        productTypeID = ptid,
    //                        parentID = parenttid,
    //                        title = model.title,
    //                        userID = userID,
    //                    };
    //                    dbcontext.productTypes.Add(pr);
    //                    await dbcontext.SaveChangesAsync();

    //                    if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        productType pp = await dbcontext.productTypes.SingleOrDefaultAsync(x => x.productTypeID == ptid);
    //                        pp.parentID = model.parentID;
    //                        await dbcontext.SaveChangesAsync();
    //                    }

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }


    //    //tag
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<productActionVM> getTagAsync()
    //    {
    //        object someObject;
    //        try
    //        {

    //            object phone;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Request.Properties.TryGetValue("Userp", out phone);
    //            Guid userID = new Guid(someObject.ToString());
    //            productActionVM model = new productActionVM();
    //            using (Context dbcontext = new Context())
    //            {
    //                var products = await dbcontext.products.Where(x => x.userID == userID).Select(x => new productVM
    //                {
    //                    address = x.address,
    //                    code = x.code,
    //                    productID = x.productID,
    //                    title = x.title
    //                }).ToListAsync();
    //                model.productList = products;
    //                return model;

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setTag([FromBody] tagVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());

    //            using (Context dbcontext = new Context())
    //            {

    //                var coding = await dbcontext.tags.FirstOrDefaultAsync(i => i.title == model.title);
    //                if (coding == null)
    //                {
    //                    dbcontext.tags.Add(new tag() { userID = userID, tagID = Guid.NewGuid(), title = model.title });
    //                    await dbcontext.SaveChangesAsync();

    //                    mymodel.status = 200;
    //                    mymodel.message = "ok";

    //                }
    //                else
    //                {
    //                    mymodel.status = 400;
    //                    mymodel.message = "پروسه هم نام وجود دارد";
    //                }


    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }

    //    // orderOption
    //    //productType
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<orderOptionActionVM> getOrderOptionAsync()
    //    {
    //        object someObject;
    //        try
    //        {

    //            object phone;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Request.Properties.TryGetValue("Userp", out phone);
    //            Guid userID = new Guid(someObject.ToString());
    //            orderOptionActionVM model = new orderOptionActionVM();
    //            using (Context dbcontext = new Context())
    //            {
    //                var orderOption = await dbcontext.orderOptions.Where(x => x.userID == userID).Select(x => new orderOptionVM
    //                {
    //                    parentID = x.parentID,
    //                    orderOptionID = x.orderOptionID,
    //                    title = x.title,
    //                    image = "Uploads/" + x.image,
    //                    value = x.Value

    //                }).ToListAsync();
    //                model.prtlist = orderOption;
    //                return model;

    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> addOrderOptionAsync([FromBody] addOrderOptionVM model)
    //    {
    //        responseModel mymodel = new responseModel();
    //        try
    //        {
    //            object someObject;
    //            Request.Properties.TryGetValue("UserToken", out someObject);
    //            Guid userID = new Guid(someObject.ToString());


    //            using (Context dbcontext = new Context())
    //            {

    //                if (model.orderOptionID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                {

    //                    orderOption selecteOption = await dbcontext.orderOptions.FirstOrDefaultAsync(x => x.orderOptionID == model.orderOptionID);
    //                    mymodel.message = selecteOption.image;
    //                    selecteOption.image = model.image;
    //                    mymodel.status = 200;
    //                    await dbcontext.SaveChangesAsync();


    //                }
    //                else
    //                {
    //                    var orop = await dbcontext.orderOptions.FirstOrDefaultAsync(i => i.title == model.title);
    //                    if (orop == null)
    //                    {
    //                        Guid ptid = Guid.NewGuid();
    //                        Guid parenttid = ptid;



    //                        orderOption pr = new orderOption()
    //                        {
    //                            orderOptionID = ptid,
    //                            parentID = parenttid,
    //                            title = model.title,
    //                            userID = userID,
    //                            image = model.image,
    //                            Value = model.value
    //                        };
    //                        dbcontext.orderOptions.Add(pr);
    //                        await dbcontext.SaveChangesAsync();

    //                        if (model.parentID != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        {
    //                            orderOption pp = await dbcontext.orderOptions.SingleOrDefaultAsync(x => x.orderOptionID == ptid);
    //                            pp.parentID = model.parentID;
    //                            await dbcontext.SaveChangesAsync();
    //                        }

    //                        mymodel.status = 200;
    //                        mymodel.message = "ok";

    //                    }
    //                    else
    //                    {
    //                        mymodel.status = 400;
    //                        mymodel.message = "پروسه هم نام وجود دارد";
    //                    }
    //                }



    //            }
    //        }
    //        catch (Exception eror)
    //        {

    //            throw;
    //        }

    //        string result = JsonConvert.SerializeObject(mymodel);
    //        JObject jObject = JObject.Parse(result);
    //        return jObject;
    //    }
    //    // form
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<processFormActionVM> getForm()
    //    {
    //        object someObject;
    //        processFormActionVM responseModel = new processFormActionVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                var query = from process in dbcontext.processes select process;
    //                responseModel.processFormList = await dbcontext.forms.Select(x => new processFormVM { title = x.title, processFormID = x.formID }).ToListAsync();
    //                responseModel.userList = await dbcontext.users.Where(x => x.userType == "2").Select(x => new userVM { userID = x.userID, name = x.name + "(" + x.phone + ")" }).ToListAsync();
    //                responseModel.formTypeList = await dbcontext.formType.Select(x => new formTypeVM { formTypeID = x.formTypeID, title = x.title }).ToListAsync();
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            string srt = e.InnerException.Message;
    //            throw e;
    //        }


    //        return responseModel;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<JObject> setForm([FromBody] formVM model)
    //    {
    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = model.userSelected != new Guid("00000000-0000-0000-0000-000000000000") ? model.userSelected : new Guid(someObject.ToString());
    //        string result = "";
    //        using (Context dbcontext = new Context())
    //        {
    //            try
    //            {
    //                responseModel mymodel = new responseModel();
    //                if (model.formID == 0)
    //                {
    //                    var form = await dbcontext.forms.FirstOrDefaultAsync(i => i.title == model.title);
    //                    if (form == null)
    //                    {
    //                        form addform = new form() { title = model.title };
    //                        if (model.formTypeID != 0)
    //                        {
    //                            addform.formTypeID = model.formTypeID;
    //                        }
    //                        if (model.userSelected != new Guid("00000000-0000-0000-0000-000000000000"))
    //                        {
    //                            addform.userID = model.userSelected;
    //                        }


    //                        dbcontext.forms.Add(addform);


    //                        await dbcontext.SaveChangesAsync();



    //                        mymodel.status = 200;
    //                        mymodel.message = "ok";

    //                    }
    //                    else
    //                    {
    //                        mymodel.status = 400;
    //                        mymodel.message = "پروسه هم نام وجود دارد";
    //                    }
    //                }
    //                else
    //                {
    //                    string message = "";
    //                    var form = await dbcontext.forms.FirstOrDefaultAsync(i => i.formID == model.formID);
    //                    message = form.pdfBase + "," + form.pdf;

    //                    form.pdfBase = model.pdfBase;
    //                    form.pdf = model.pdf;
    //                    form.title = model.title;
    //                    if (model.formTypeID != 0)
    //                    {
    //                        form.formTypeID = model.formTypeID;
    //                    }

    //                    form.userID = userID;
    //                    mymodel.status = 200;
    //                    mymodel.message = message;
    //                    await dbcontext.SaveChangesAsync();

    //                    result = JsonConvert.SerializeObject(mymodel);
    //                }
    //            }
    //            catch (Exception e)
    //            {

    //                throw;
    //            }






    //            JObject jObject = JObject.Parse(result);
    //            return jObject;
    //        }

    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<managerChart> getManagerChart([FromBody] ManagerChartSearch model)
    //    {

    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        managerChart managerServent = new managerChart();


    //        managerServent.list = await GetDataForManagerChart(model);
    //        return managerServent;


    //    }





    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<managerChart> getUserChart([FromBody] ManagerChartSearch model)
    //    {

    //        object someObject;
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());


    //        DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.startDate))
    //            {
    //                startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.startDate));
    //                startDate = startDate.AddDays(-7);
    //            }
    //        }
    //        if (model != null)
    //        {
    //            if (!string.IsNullOrEmpty(model.endDate))
    //            {
    //                startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.endDate));
    //                startDate = startDate.AddDays(1);
    //            }
    //        }


    //        string persianName = customMethodes.returnDayName(startDate);




    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {


    //                List<codrivervm> driverList = await dbcontext.users.Where(x => x.userID == userID).Include(x => x.workingStatus).Include(x => x.verifyStatus).Select(item => new codrivervm
    //                {
    //                    did = item.userID,
    //                    dname = item.name,
    //                    phone = item.phone,


    //                }).ToListAsync();
    //                managerChart managerServent = new managerChart();
    //                List<serventChartVM> serlst = new List<serventChartVM>();
    //                foreach (var item in driverList)
    //                {

    //                    serventChartVM servent = new serventChartVM();
    //                    List<serventChartList> serventList = new List<serventChartList>();
    //                    servent.name = item.dname + " " + item.phone;
    //                    servent.phone = item.phone;
    //                    string dayname = persianName;
    //                    DateTime usingtime = startDate;
    //                    for (int i = 0; i <= 6; i++)
    //                    {

    //                        serventChartList chartlist = new serventChartList();
    //                        chartlist.dayName = dayname;
    //                        chartlist.persianDate = dateTimeConvert.ToPersianDateString(usingtime);
    //                        chartlist.timestamp = Classes.dateTimeConvert.ConvertDateTimeToTimestamp(usingtime);
    //                        chartlist.flowList = await dbcontext.newOrderFlows.Where(x => x.serventPhone == item.phone && x.actionDate == usingtime)/*.Include(x => x.NewOrder)*/.Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, /*orderID = x.NewOrder.newOrderID,*/ isFinished = x.isFinished, flowID = x.newOrderFlowID, processColor = x.newOrderProcess.color, processName = x.newOrderProcess.title,/* orderName = x.NewOrder.orderName*/ }).ToListAsync();
    //                        usingtime = usingtime.AddDays(1);
    //                        dayname = customMethodes.returnDayName(usingtime);

    //                        serventList.Add(chartlist);
    //                    }
    //                    servent.serventList = serventList;
    //                    serlst.Add(servent);
    //                }
    //                managerServent.list = serlst;
    //                return managerServent;


    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }


    //    }


    //    // formDetailAPI
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> setFormDetail([FromBody] setFormDetailVM model)
    //    {
    //        object someObject;
    //        object userPhone;
    //        responseModel responseModel = new responseModel();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Request.Properties.TryGetValue("Userp", out userPhone);
    //        Guid userID = new Guid(someObject.ToString());

    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {


    //                //form formModel = await dbcontext.forms.SingleOrDefaultAsync(x => x.formID == model.formID);

    //                if (model.orderID != null)
    //                {
    //                    if (model.orderID == new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        // یک نیو اردر ایجاد میکنیم

    //                        newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                        //Guid thirdPartyGUID = Guid.NewGuid();
    //                        //thirdParty thirdParty = new thirdParty()
    //                        //{
    //                        //    fullname = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyName").value,
    //                        //    address = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyAddress").value,
    //                        //    phone = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyPhone").value,
    //                        //    ThirdPartyID = thirdPartyGUID,
    //                        //};
    //                        //dbcontext.thirdParties.Add(thirdParty);


    //                        model.orderID = Guid.NewGuid();
    //                        newOrder neworder = new newOrder()
    //                        {
    //                            creationDate = DateTime.Now,
    //                            terminationDate = DateTime.Now,
    //                            newOrderID = model.orderID,
    //                            newOrderStatusID = neworderstatus.newOrderStatusID,
    //                            orderName = model.name

    //                            //thirdPartyID = thirdPartyGUID,
    //                        };
    //                        newOrder checkorder = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.orderName == model.name);
    //                        if (checkorder == null)
    //                        {
    //                            dbcontext.NewOrders.Add(neworder);
    //                        }
    //                        else
    //                        {
    //                            responseModel.status = 400;
    //                            responseModel.message = "سفارش تکراری است";
    //                            return responseModel;
    //                        }


    //                        await dbcontext.SaveChangesAsync();
    //                    }
    //                }// 



    //                newOrder orderSelected = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == model.orderID);
    //                newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                orderSelected.newOrderStatusID = stat.newOrderStatusID;

    //                if (model.processID != null) //
    //                {
    //                    if (model.processID == new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
    //                        model.processID = pr.processID;
    //                    }

    //                }
    //                //Guid newFlowID = Guid.NewGuid();

    //                int newFlowID = 0;
    //                if (model.flowID != 0)
    //                {
    //                    newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
    //                    selectedflow.isFinished = "1";


    //                }
    //                else
    //                {
    //                    var newFlowIDRow = await dbcontext.newOrderFlows.OrderByDescending(x => x.newOrderFlowID).FirstOrDefaultAsync();
    //                    newFlowID = newFlowIDRow.newOrderFlowID + 1;

    //                    newOrderFlow newOrderFlow = new newOrderFlow()
    //                    {
    //                        creationDate = DateTime.Now,
    //                        actionDate = DateTime.Now,
    //                        processID = model.processID,
    //                        isFinished = "1",
    //                        newOrderID = model.orderID,
    //                        newOrderFlowID = newFlowID,
    //                        serventPhone = userPhone.ToString(),
    //                        userID = userID,
    //                        terminationDate = DateTime.Now,
    //                        changeStatusDate = DateTime.Now,
    //                    };
    //                    dbcontext.newOrderFlows.Add(newOrderFlow);
    //                }

    //                await dbcontext.SaveChangesAsync();
    //                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.formDetailList);
    //                foreach (var item in lstform)
    //                {
    //                    string fieldToGo = "";
    //                    switch (item.formItemTypeCode)
    //                    {
    //                        case ("6"): // انتخابی
    //                            fieldToGo = "valueBool";

    //                            break;
    //                        case ("8"): // موقعیت 
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("7"):// آپلود
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("1"):// چند گزینه ای
    //                            fieldToGo = "valueGuid";
    //                            break;
    //                        case ("5"): // تاریخ
    //                            fieldToGo = "valueDateTime";
    //                            break;
    //                        case ("4"): // عددی
    //                            fieldToGo = "valueDuoble";
    //                            break;
    //                        case ("3"): // متنی
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("2"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        case ("9"): //  متنی عکس دار
    //                            fieldToGo = "valueString";
    //                            break;
    //                        default:
    //                            fieldToGo = "valueString";
    //                            break;
    //                    }
    //                    newOrderFields fieldItem = new newOrderFields();
    //                    fieldItem.formItemID = item.formItemID;
    //                    fieldItem.name = item.key;
    //                    fieldItem.newOrderFieldsID = Guid.NewGuid();
    //                    fieldItem.newOrderFlowID = newFlowID;
    //                    fieldItem.usedFeild = fieldToGo;
    //                    fieldItem.valueInt = 0;
    //                    fieldItem.valueDuoble = 0;
    //                    fieldItem.valueDateTime = DateTime.Now;
    //                    fieldItem.valueBool = false;
    //                    fieldItem.valueGuid = new Guid();

    //                    if (fieldToGo == "valueBool")
    //                        fieldItem.valueBool = Boolean.Parse(item.value);
    //                    if (fieldToGo == "valueString")
    //                        fieldItem.valueString = item.value;
    //                    if (fieldToGo == "valueDateTime")
    //                        fieldItem.valueDateTime = DateTime.Parse(item.value);
    //                    if (fieldToGo == "valueGuid")
    //                    {
    //                        List<string> lst = item.value.Split(':').ToList();
    //                        fieldItem.valueString = string.IsNullOrEmpty(lst[1]) ? "" : lst[1];
    //                        fieldItem.valueGuid = new Guid(lst[0]);
    //                    }
    //                    if (fieldToGo == "valueDuoble")
    //                        fieldItem.valueDuoble = double.Parse(item.value);


    //                    dbcontext.newOrderFields.Add(fieldItem);

    //                }

    //                await dbcontext.SaveChangesAsync();

    //                responseModel.status = 200;
    //                responseModel.message = "";



    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            responseModel.status = 400;
    //            responseModel.message = e.InnerException.Message;
    //            return responseModel;
    //        }

    //        return responseModel;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<listOfFormVM> formFullDetailInsert([FromBody] formFullDetailRequest model)
    //    {
    //        object someObject;
    //        formFullDetailVM responseModel = new formFullDetailVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        listOfFormVM response = new listOfFormVM();
    //        List<formItemList> formList = new List<formItemList>();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {

    //                process process = new process();

    //                if (model != null)
    //                {
    //                    if (model.processID == new Guid("00000000-0000-0000-0000-000000000000"))
    //                    {
    //                        process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
    //                    }

    //                    else
    //                    {
    //                        process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.processID == model.processID);
    //                    }
    //                }
    //                else
    //                {
    //                    process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");


    //                }





    //                foreach (var form in process.formList.OrderBy(x => x.priority))
    //                {
    //                    Guid typeid = new Guid("bdbf1018-bad4-43c5-9181-f8ea3fb1d994");// متنی تصویر دار
    //                    formItemList fil = new formItemList();
    //                    fil.formID = form.formID;
    //                    fil.formTitle = form.title;
    //                    fil.formImage = form.image;
    //                    fil.formHieght = form.imageHeight;
    //                    fil.formWidth = form.imageWidth;
    //                    fil.zaribWidth = form.zaribWidth;
    //                    fil.zaribHeight = form.zaribHeight;

    //                    fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { formItemTypeCode = x.FormItemType.formItemTypeCode, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeTitle = x.FormItemType.title, itemx = x.itemx, itemy = x.itemy, itemHeight = x.itemHeight, itemlength = x.itemLenght, pageNumber = x.pageNumber, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();

    //                    List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { itemHeight = l.itemHeight, itemlength = l.itemLenght, itemx = l.itemx, itemy = l.itemy, pageNumber = l.pageNumber, groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();
    //                    int index = 0;
    //                    foreach (var item in lst)
    //                    {
    //                        formFullDetailItemVM extraDetail = new formFullDetailItemVM();
    //                        extraDetail.stringImageCollection = item;
    //                        extraDetail.formItemTypeCode = "2";


    //                        fil.formItemDetailList.Insert(index, extraDetail);
    //                        index += 1;
    //                    }


    //                    formList.Add(fil);
    //                }

    //                response.allForm = formList;

    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        return response;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<listOfFormVM> formFullDetailView([FromBody] formFullDetailRequest model)
    //    {
    //        object someObject;
    //        formFullDetailVM responseModel = new formFullDetailVM();

    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        listOfFormVM response = new listOfFormVM();
    //        List<formItemList> formList = new List<formItemList>();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                List<newOrderFields> insertedFields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == model.flowID).ToListAsync();
    //                process process = new process();

    //                if (model == null)
    //                {
    //                    process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
    //                }
    //                else
    //                {
    //                    process = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.processID == model.processID);
    //                }



    //                foreach (var form in process.formList.OrderBy(x => x.priority))
    //                {

    //                    Guid typeid = new Guid("96479ab5-f846-432f-b176-8ad98f0cb89b");// متنی تصویر دار
    //                    Guid typeid2 = new Guid("9c77d5e9-a956-45dd-8451-b71eb5b5e7a7");// چند گزینه ای




    //                    formItemList fil = new formItemList();
    //                    fil.formID = form.formID;
    //                    fil.formTitle = form.title;
    //                    fil.formImage = form.image;
    //                    fil.formHieght = form.imageHeight;
    //                    fil.formWidth = form.imageWidth;
    //                    fil.zaribWidth = form.zaribWidth;
    //                    fil.zaribHeight = form.zaribHeight;
    //                    if (string.IsNullOrEmpty(fil.formImage))
    //                    {
    //                        fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID != typeid2).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
    //                        foreach (var item in fil.formItemDetailList)
    //                        {
    //                            newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                            if (filed != null)
    //                            {
    //                                var nameOfProperty = filed.usedFeild;
    //                                var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                var value = propertyInfo.GetValue(filed, null);
    //                                item.itemValue = value.ToString();
    //                            }

    //                        }

    //                        // افزودن متن تصویر دار
    //                        List<List<formFullDetailItemVM>> lst = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID == typeid).OrderBy(x => x.FormItemType.formItemTypeCode).Include(x => x.FormItemType).GroupBy(x => x.groupNumber).Select(grp => grp.Select(l => new formFullDetailItemVM { groupNumber = l.groupNumber, formItemTypeCode = l.FormItemType.formItemTypeCode, UIName = l.FormItemDesign.title, formItemTypeTitle = l.FormItemType.title, itemDesc = l.itemDesc, formItemID = l.formItemID, itemName = l.itemName, itemPlaceholder = l.itemPlaceholder, itemtImage = "Uploads/" + l.itemtImage, mediaType = l.mediaType }).ToList()).ToListAsync();

    //                        foreach (var item in lst)
    //                        {
    //                            foreach (var dd in item)
    //                            {
    //                                newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == dd.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    dd.itemValue = value.ToString();
    //                                }

    //                            }
    //                        }
    //                        int index = 0;
    //                        foreach (var item in lst)
    //                        {
    //                            formFullDetailItemVM extraDetail = new formFullDetailItemVM();
    //                            extraDetail.stringImageCollection = item.Where(x => x.itemValue != null).ToList();
    //                            extraDetail.formItemTypeCode = "2";


    //                            fil.formItemDetailList.Insert(index, extraDetail);
    //                            index += 1;

    //                        }



    //                        // افزودن گزینه ها انتخابی
    //                        List<formFullDetailItemVM> multiSelectITems = await dbcontext.formItems.Where(x => x.formID == form.formID && x.formItemTypeID != typeid && x.formItemTypeID == typeid2).Select(x => new formFullDetailItemVM { formItemID = x.formItemID }).ToListAsync();
    //                        if (multiSelectITems.Count() > 0)
    //                        {
    //                            List<Guid> orderOptionID = new List<Guid>();

    //                            foreach (var item in multiSelectITems)
    //                            {
    //                                newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                                if (filed != null)
    //                                {
    //                                    var nameOfProperty = filed.usedFeild;
    //                                    var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                    var value = propertyInfo.GetValue(filed, null);
    //                                    orderOptionID.Add(new Guid(value.ToString()));
    //                                }


    //                            }
    //                            List<orderOptionVM> orderotpinVMForSelectedOptions = await dbcontext.orderOptions.Where(x => orderOptionID.Contains(x.orderOptionID)).Select(g => new orderOptionVM { image = "Uploads/" + g.image, orderOptionID = g.orderOptionID, parentID = g.parentID, title = g.title }).ToListAsync();
    //                            formFullDetailItemVM extraDetailMultiSelect = new formFullDetailItemVM();
    //                            extraDetailMultiSelect.orderOptions = orderotpinVMForSelectedOptions;
    //                            extraDetailMultiSelect.formItemTypeCode = "1";
    //                            extraDetailMultiSelect.itemDesc = "گزینه های انتخابی";
    //                            fil.formItemDetailList.Insert(0, extraDetailMultiSelect);
    //                        }
    //                    }

    //                    else
    //                    {
    //                        fil.formItemDetailList = await dbcontext.formItems.Where(x => x.formID == form.formID).Include(x => x.FormItemDesign).Include(x => x.op).Include(x => x.op.childList).Include(x => x.FormItemType).Select(x => new formFullDetailItemVM { itemy = x.itemy, itemx = x.itemx, itemHeight = x.itemHeight, itemlength = x.itemLenght, groupNumber = x.groupNumber, pageNumber = x.pageNumber, orderOptions = x.op.childList.Where(x => x.parentID != x.orderOptionID).Select(t => new orderOptionVM { parentID = t.parentID, image = "Uploads/" + t.image, orderOptionID = t.orderOptionID, title = t.title }).ToList(), UIName = x.FormItemDesign.title, formItemDesingID = x.FormItemDesign.formItemDesignID, formItemDesignNumber = x.FormItemDesign == null ? 0 : x.FormItemDesign.number, formItemTypeID = x.formItemTypeID, optionSelected = x.OptionID, collectionName = x.op.title, formItemTypeCode = x.FormItemType.formItemTypeCode, formItemTypeTitle = x.FormItemType.title, itemDesc = x.itemDesc, catchUrl = x.catchUrl, formItemID = x.formItemID, isMultiple = x.isMultiple, itemName = x.itemName, itemPlaceholder = x.itemPlaceholder, itemtImage = "Uploads/" + x.itemtImage, mediaType = x.mediaType }).ToListAsync();
    //                        foreach (var item in fil.formItemDetailList)
    //                        {
    //                            newOrderFields filed = insertedFields.SingleOrDefault(x => x.formItemID == item.formItemID);
    //                            if (filed != null)
    //                            {
    //                                var nameOfProperty = filed.usedFeild;
    //                                var propertyInfo = filed.GetType().GetProperty(nameOfProperty);
    //                                var value = propertyInfo.GetValue(filed, null);
    //                                item.itemValue = value.ToString();
    //                            }

    //                        }
    //                    }

    //                    formList.Add(fil);






    //                }

    //                response.allForm = formList;

    //            }

    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //        return response;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<userFlowVM> getUserFlow()
    //    {
    //        object someObject;
    //        object userPhone;
    //        formFullDetailVM responseModel = new formFullDetailVM();
    //        userFlowVM response = new userFlowVM();
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Request.Properties.TryGetValue("Userp", out userPhone);

    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                response.flowList = await dbcontext.newOrderFlows.Where(x => x.serventPhone == userPhone.ToString() && x.isFinished != "1")/*.Include(x => x.NewOrder)*/.Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID,/* orderID = x.NewOrder.newOrderID, */isFinished = x.isFinished, flowID = x.newOrderFlowID, processName = x.newOrderProcess.title, /*orderName = x.NewOrder.orderName*/ }).ToListAsync();
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }
    //        return response;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<userFlowVM> getOrderFlow([FromBody] newOrder model)
    //    {
    //        object someObject;
    //        formFullDetailVM responseModel = new formFullDetailVM();
    //        userFlowVM response = new userFlowVM();
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                response.flowList = await dbcontext.newOrderFlows.Where(x => x.newOrderID == model.newOrderID && x.isFinished == "1")/*.Include(x => x.NewOrder)*/.Include(x => x.newOrderProcess).Select(x => new orderFlowVM { processID = x.newOrderProcess.processID, /*orderID = x.NewOrder.newOrderID,*/ isFinished = x.isFinished, flowID = x.newOrderFlowID, processName = x.newOrderProcess.title, /*orderName = x.NewOrder.orderName*/ }).ToListAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //        return response;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<flowCostVM> getFlowCost([FromBody] getFlowCost model)
    //    {
    //        object someObject;
    //        formFullDetailVM responseModel = new formFullDetailVM();
    //        flowCostVM response = new flowCostVM();
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {

    //            using (Context dbcontext = new Context())
    //            {
    //                response.codingList = await dbcontext.codings.Where(x => x.inList == "1").Select(x => new codingVM { title = x.title, codingID = x.codingID }).ToListAsync();
    //                response.productList = await dbcontext.products.Select(x => new productVM { title = x.title, productID = x.productID }).ToListAsync();
    //                response.flowCodingList = await dbcontext.flowCodings.Where(x => x.flowID == model.flowID).Include(x => x.coding).Select(x => new flowCodingVM { amount = x.amount, codingTitle = x.coding.title }).ToListAsync();
    //                response.flowProductList = await dbcontext.flowProducts.Where(x => x.flowID == model.flowID).Include(x => x.product).Select(x => new flowProductVM { amount = x.amount, productTitle = x.product.title }).ToListAsync();

    //                return response;
    //            }
    //        }
    //        catch (Exception e)
    //        {

    //            throw;
    //        }

    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> setFlowCoding([FromBody] setFlowCodingVM model)
    //    {
    //        object someObject;
    //        responseModel responseModel = new responseModel();
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                flowCoding flc = new flowCoding()
    //                {
    //                    amount = model.amount,
    //                    CodingID = model.codingID,
    //                    flowID = model.flowID,
    //                    flowCodingID = Guid.NewGuid(),
    //                    date = DateTime.Now,
    //                };
    //                dbcontext.flowCodings.Add(flc);
    //                await dbcontext.SaveChangesAsync();
    //                responseModel.status = 200;
    //                responseModel.message = "";
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            responseModel.status = 400;
    //            responseModel.message = "";
    //            throw;
    //        }
    //        return responseModel;
    //    }
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> setFlowProduct([FromBody] setFlowProductVM model)
    //    {
    //        object someObject;
    //        responseModel responseModel = new responseModel();
    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                flowProduct flc = new flowProduct()
    //                {
    //                    amount = model.amount,
    //                    productID = model.productID,
    //                    flowID = model.flowID,
    //                    flowCodingID = Guid.NewGuid(),
    //                    date = DateTime.Now,
    //                };
    //                dbcontext.flowProducts.Add(flc);
    //                await dbcontext.SaveChangesAsync();
    //                responseModel.status = 200;
    //                responseModel.message = "";
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            responseModel.status = 400;
    //            responseModel.message = "";
    //            throw;
    //        }
    //        return responseModel;
    //    }



    //    // manger 
    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<chartDataVM> getDataForChart()
    //    {
    //        object someObject;


    //        Request.Properties.TryGetValue("UserToken", out someObject);
    //        Guid userID = new Guid(someObject.ToString());
    //        chartDataVM model = new chartDataVM();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {


    //                newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                model.processList = await dbcontext.processes.Select(x => new processVM { processID = x.processID, title = x.title }).ToListAsync();
    //                model.orderList = await dbcontext.NewOrders.Where(x => x.newOrderStatusID == orderstatus.newOrderStatusID).Select(x => new newOrderVM { creationDate = x.creationDate, newOrderID = x.newOrderID, orderName = x.orderName, terminationDate = x.terminationDate }).ToListAsync();
    //                return model;
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }




    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> setNewFlow([FromBody] newFlowVM model)
    //    {
    //        responseModel response = new responseModel();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {

    //                DateTime actinDate = Classes.dateTimeConvert.UnixTimeStampToDateTime(model.actionDate);
    //                user suser = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == model.userID);
    //                newOrderFlow newOrderFlow = new newOrderFlow()
    //                {
    //                    creationDate = DateTime.Now,
    //                    processID = model.processID,
    //                    isFinished = "0",
    //                    isAccepted = "0",
    //                    newOrderID = model.orderID,
    //                    userID = model.userID,
    //                    serventPhone = suser.phone,
    //                    terminationDate = DateTime.Now.Date,
    //                    actionDate = actinDate.Date,
    //                    changeStatusDate = DateTime.Now,

    //                };
    //                dbcontext.newOrderFlows.Add(newOrderFlow);
    //                await dbcontext.SaveChangesAsync();

    //                newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == model.orderID);
    //                newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

    //                order.newOrderStatusID = stat.newOrderStatusID;

    //                user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == model.userID && x.userType == "1");
    //                Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
    //                servent.workingStatusID = ustatuid;

    //                await dbcontext.SaveChangesAsync();

    //                response.status = 200;
    //                response.message = "";

    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            response.status = 400;
    //            response.message = "خطا";


    //        }
    //        return response;
    //    }


    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> flowStat([FromBody] acceptFlow model)
    //    {
    //        responseModel response = new responseModel();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                newOrderFlow flow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == model.flowID);
    //                flow.isAccepted = model.status;

    //                await dbcontext.SaveChangesAsync();
    //                response.status = 200;
    //                response.message = "";

    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            response.status = 400;
    //            response.message = "خطا";


    //        }
    //        return response;
    //    }

    //    [BasicAuthentication]
    //    [System.Web.Http.HttpPost]
    //    public async Task<responseModel> rejectAcceptFlowVM([FromBody] rejectAcceptFlowVM model)
    //    {
    //        responseModel response = new responseModel();
    //        try
    //        {
    //            using (Context dbcontext = new Context())
    //            {
    //                newOrderFlow orderFlow = await dbcontext.newOrderFlows/*.Include(x => x.NewOrder)*/.SingleOrDefaultAsync(x => x.newOrderFlowID == model.orderFlowID);
    //                orderFlow.isAccepted = model.status;
    //                if (model.status == "2")
    //                {
    //                    newOrderStatus stat1 = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
    //                    newOrder orderflow = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderFlow.newOrderID);
    //                    orderflow.newOrderStatusID = stat1.newOrderStatusID;
    //                    orderFlow.terminationDate = DateTime.Now;
    //                }

    //                await dbcontext.SaveChangesAsync();


    //                response.status = 200;
    //                response.message = "";

    //            }

    //        }
    //        catch (Exception)
    //        {
    //            response.status = 400;
    //            response.message = "خطا";


    //        }
    //        return response;
    //    }









    //    //////////////////////////////////////////////
    //    ///






    //}
}