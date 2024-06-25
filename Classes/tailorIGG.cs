using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace greenEnergy.Classes
{
    public class tailorIGG
    {
    }
}



//private async Task<Dictionary<string, string>> setInitData(getURLVM model)
//{
//    Dictionary<string, string> initdata = new Dictionary<string, string>();

//    if (model.slug == "app/requestFormSetNewFLow")
//    {

//        initdata.Add("orderID", model.data["orderID"]);
//    }
//    else if (model.slug == "app/setFormByClient")
//    {

//        using (Context dbcontext = new Context())
//        {
//            int flowID = Int32.Parse(model.data["flowID"]);
//            newOrderFlow selectedFlow = await dbcontext.newOrderFlows.SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);
//            initdata.Add("orderID", selectedFlow.newOrderID.ToString());

//            initdata.Add("processID", selectedFlow.processID.ToString());
//        }

//    }
//    return initdata;
//}
//private async Task<viewVM> getData([FromBody] getURLVM model)
//{
//    //main/chart/
//    viewVM rsp = new viewVM();
//    List<parent> parentlist = new List<parent>();
//    itemParent cycle0 = new itemParent() // برای همه
//    {
//        name = "main",
//    };
//    List<itemParent> lst0 = new List<itemParent>();
//    using (Context dbcontext = new Context())

//    {
//        if (model.slug == "app/showForm")
//        {
//            object someObject;
//            Request.Properties.TryGetValue("UserToken", out someObject);
//            string flowString = model.data["flowID"];
//            showFormInputVM fmodel = new showFormInputVM()
//            {
//                flowID = Int32.Parse(flowString),
//            };
//            Guid flowGUID = new Guid(flowString);
//            if (someObject != null)
//            {
//                List<formItemList> showForm = await getFormItems(fmodel);
//                showFormAllVM formModel = new showFormAllVM()
//                {
//                    name = "showFormMain",
//                    allForm = showForm
//                };

//                parentlist.Add(formModel);

//            }
//            setNewFlowForm info = new setNewFlowForm();
//            info.flowForm = flowString;
//            parentlist.Add(info);

//            cycle0.items = parentlist;
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }

//        else if (model.slug == "app/managerProfile")
//        {
//            profileVM info = new profileVM();
//            info = await getUserInfoHandler(model.userID, dbcontext);

//            parentlist.Add(info);
//            cycle0.items = parentlist;
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/setFormByClient")
//        {
//            string flowId = model.data["flowID"];
//            setNewFlowForm info = new setNewFlowForm();
//            info.flowForm = flowId;

//            parentlist.Add(info);
//            cycle0.items = parentlist;
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/requestFormSetNewFLow")
//        {
//            string orderid = model.data["orderID"];
//            parentlist = new List<parent>();
//            newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
//            List<orderOptionVM> serventList = await dbcontext.users.Where(x => x.barbariID != null).Select(x => new orderOptionVM { title = x.phone, orderOptionID = x.userID }).ToListAsync();
//            formOptionObject orderOBJ = new formOptionObject()
//            {
//                name = "serventList",
//                lst = serventList
//            };
//            parentlist.Add(orderOBJ);
//            List<orderOptionVM> processList = await dbcontext.processes.Select(x => new orderOptionVM { title = x.title, orderOptionID = x.processID }).ToListAsync();
//            orderOBJ = new formOptionObject()
//            {
//                name = "processList",
//                lst = processList
//            };
//            parentlist.Add(orderOBJ);


//            cycle0.items = parentlist;
//            cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/getOrderFlowManager")
//        {
//            string Guidstring = model.data["orderID"];
//            Guid selectedOrderID = new Guid(Guidstring);
//            List<managerFlowList_orderFlowCycle> flowlist = await dbcontext.newOrderFlows.Where(x => x.newOrderID == selectedOrderID).OrderByDescending(x => x.creationDate).Select(x => new managerFlowList_orderFlowCycle { flowStatus_valueColorsrt = x.isFinished == "1" ? "cGreen" : "cRed", flowStatus_valueTextsrt = x.isFinished == "1" ? "Finished" : "In Process", isAccespted = x.isAccepted, orderName_valueTextsrt = x.NewOrder.orderName, processName_valueTextsrt = x.newOrderProcess.title, serventName_valueTextsrt = x.newOrderFlowServent != null ? x.newOrderFlowServent.phone : "", FlowID = x.newOrderFlowID.ToString() }).ToListAsync();


//            parentlist = new List<parent>();
//            foreach (var item in flowlist)
//            {
//                switch (item.isAccespted)
//                {

//                    case ("1"):
//                        item.flowIsAccepted_valueTextsrt = "Accepted";
//                        item.flowIsAccepted_valueColorsrt = "cGreen";
//                        break;
//                    case ("2"):
//                        item.flowIsAccepted_valueTextsrt = "Rejected";
//                        item.flowIsAccepted_valueColorsrt = "cRed";
//                        break;
//                    default:
//                        item.flowIsAccepted_valueTextsrt = "Pending";
//                        item.flowIsAccepted_valueColorsrt = "cGray";
//                        break;

//                }
//                List<actionResonse> actionList = new List<actionResonse>();
//                actionResonse action1 = new actionResonse()
//                {
//                    type = "a.putVar",
//                    varName = "flowID",
//                    value = item.FlowID
//                };
//                actionList.Add(action1);


//                actionResonse action2 = new actionResonse()
//                {
//                    type = "a.go",
//                    to = "app/showForm",
//                    value = item.FlowID
//                };
//                actionList.Add(action2);
//                item.actions = actionList;
//                parentlist.Add(item);
//            }
//            itemParent flowCycle = new itemParent()
//            {
//                name = "orderFlowCycle",
//                items = parentlist
//            };

//            List<itemParent> flowParentlst = new List<itemParent>();
//            flowParentlst.Add(flowCycle);
//            rsp.chunkList = flowParentlst;
//        }
//        else if (model.slug == "app/getOrderListManager")
//        {
//            string toDate = "";
//            string fromDate = "";
//            string search = "";
//            if (model.data != null)
//            {
//                foreach (var item in model.data)
//                {
//                    if (item.Key == "toDate")
//                    {
//                        toDate = item.Value;
//                    }
//                    if (item.Key == "fromDate")
//                    {
//                        fromDate = item.Value;
//                    }
//                    if (item.Key == "search")
//                    {
//                        search = item.Value;
//                    }
//                }
//            }

//            List<cycleStackView_orderListManagerVM> cyclelist = await dbcontext.NewOrders.Include(x => x.newOrderStatus).Select(x => new cycleStackView_orderListManagerVM { setFlow_orderListManager_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/requestFormSetNewFLow\"}]", setFlow_orderListManager_visibilitysrt = x.newOrderStatus.statusCode == "1" ? "1" : "0", orderStatus_valueTextsrt = x.newOrderStatus.title, orderStatus_valueColorsrt = x.newOrderStatus.statusCode == "1" ? "cRed" : "cGreen", projectName_orderListManager_valueTextsrt = x.orderName, orderDate_orderListManager_valueTextsrtdate = x.creationDate, historyButton_orderListManager_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/getOrderFlowManager\"}]" }).ToListAsync();
//            parentlist = new List<parent>();
//            foreach (var item in cyclelist)
//            {

//                item.orderDate_orderListManager_valueTextsrt = item.orderDate_orderListManager_valueTextsrtdate.ToShortDateString();
//                parentlist.Add(item);
//            }
//            itemParent cycle = new itemParent()
//            {
//                name = "orderListCycle_orderListManager",
//                items = parentlist
//            };

//            List<itemParent> lst = new List<itemParent>();
//            lst.Add(cycle);
//            rsp.chunkList = lst;
//        }
//        else if (model.slug == "app/managerChart")
//        {
//            ManagerChartSearch inputModel = new ManagerChartSearch();

//            string sd = "";
//            string ed = "";
//            string serventList = "";
//            if (model.data != null)
//            {
//                foreach (var item in model.data)
//                {
//                    if (item.Key == "startDate")
//                    {
//                        sd = item.Value;
//                    }
//                    if (item.Key == "endDate")
//                    {
//                        ed = item.Value;
//                    }
//                    if (item.Key == "phone")
//                    {
//                        serventList = item.Value;
//                    }
//                }
//            }

//            inputModel.startDate = sd;
//            inputModel.endDate = ed;
//            inputModel.phone = serventList;
//            List<serventChartVM> lllsssttt = await GetDataForManagerChart(inputModel);
//            managerChartmain datttamodel = new managerChartmain()
//            {
//                name = "",
//                list = lllsssttt
//            };
//            parentlist.Add(datttamodel);
//            cycle0.items = parentlist;
//            cycle0.name = "chartData";
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/productDetail")
//        {
//            string orderID = model.data["orderID"];
//            Guid orderIDguid = new Guid(orderID);
//            newOrderFlow flowitem = await dbcontext.newOrderFlows.OrderBy(x => x.actionDate).FirstOrDefaultAsync(x => x.newOrderID == orderIDguid);
//            int flowID = flowitem.newOrderFlowID;
//            Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");

//            List<newOrderFields> fields = await dbcontext.newOrderFields.Where(x => x.newOrderFlowID == flowID).ToListAsync();

//            productDetailApp datamodel = new productDetailApp()
//            {
//                pertTextDescription_valueText = fields.SingleOrDefault(x => x.name == "description").valueString,
//                pertTextTitle_valueText = fields.SingleOrDefault(x => x.name == "productTitle").valueString,
//            };
//            parentlist.Add(datamodel);
//            cycle0.items = parentlist;


//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/searchChartManager")
//        {
//            parentlist = new List<parent>();
//            // ابجکت مخصوص استفاده از فرم را ایجاد میکنیم
//            // این فرم برای پر کردن یکی از آیتم های فرم جستجوی چارت استفاده می شود
//            List<orderOptionVM> tailorlst = await dbcontext.users.Where(x => x.barbariID != null).Select(x => new orderOptionVM { title = x.phone, orderOptionID = x.userID }).ToListAsync();
//            formOptionObject mymodel = new formOptionObject()
//            {
//                name = "tailorList",
//                lst = tailorlst
//            };
//            parentlist.Add(mymodel);
//            cycle0.items = parentlist;
//            cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }

//        else if (model.slug == "app/clientOrderListPending")
//        {
//            object someObject;
//            object userPhone;
//            Request.Properties.TryGetValue("UserToken", out someObject);
//            Request.Properties.TryGetValue("Userp", out userPhone);

//            Guid userID = new Guid(someObject.ToString());
//            parentlist = new List<parent>();
//            List<clientorderListPending> CYCLElIST = await dbcontext.newOrderFlows.Where(x => x.serventPhone == userPhone.ToString() && x.isFinished == "0" && x.isAccepted != "2").
//                Select(x => new clientorderListPending
//                {
//                    flowID = x.newOrderFlowID.ToString(),
//                    projectName_valueTextsrt = x.NewOrder.orderName,
//                    processName_valueTextsrt = x.newOrderProcess.title,
//                    orderDate_valueText = x.creationDate,
//                    historyButton_cycleActionsrt = "[{\"type\" : \"a.putVar\", \"varName\":\"orderID\",\"value\":\"" + x.newOrderID + "\"},{\"type\":\"a.go\",\"to\":\"app/getOrderFlowManager\"}]",
//                    historyButton_visibilitysrt = "1",

//                    acceptOrderButton_cycleActionsrt = x.isAccepted == "0" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"isPopUp\":1,\"width\":300,\"height\":220,\"to\":\"app/clientAcceptFlow\"}]" : "[]",
//                    acceptOrderButton_visibilitysrt = x.isAccepted == "0" ? "1" : "0",

//                    rejectOrderButton_cycleActionsrt = x.isAccepted == "0" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"isPopUp\":1,\"width\":300,\"height\":220,\"to\":\"app/clientRejectFlow\"}]" : "[]",
//                    rejectOrderButton_visibilitysrt = x.isAccepted == "0" ? "1" : "0",

//                    productRegistration_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setProduct\"}]" : "[]",
//                    productRegistration_visibilitysrt = "0",// x.isAccepted == "1" ? "1" : "0",

//                            costRegistration_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setCost\"}]" : "[]",
//                    costRegistration_visibilitysrt = "0",// x.isAccepted ==  "1" ? "1" : "0",

//                            setFlowFormButton_cycleActionsrt = x.isAccepted == "1" ? "[{\"type\" : \"a.putVar\", \"varName\":\"flowID\",\"value\":\"" + x.newOrderFlowID + "\"},{\"type\":\"a.go\",\"to\":\"app/setFormByClient\"}]" : "[]",
//                    setFlowFormButton_visibilitysrt = x.isAccepted == "1" ? "1" : "0",


//                }).ToListAsync();




//            // اینجا ما باید آیتم های مورد استفاده درسایکل رو فراخوانی کنیم
//            foreach (var item in CYCLElIST)
//            {
//                item.orderDate_valueTextsrt = item.orderDate_valueText.ToShortDateString();
//                parentlist.Add(item);

//            }
//            itemParent clientcycle = new itemParent() // برای همه
//            {
//                name = "orderListCycle",
//                items = parentlist
//            };
//            lst0.Add(clientcycle);



//            rsp.chunkList = lst0;
//        }
//        else if (model.slug == "app/clientRejectFlow")
//        {
//            string flowID = model.data["flowID"];
//            acceptFlowByClient info = new acceptFlowByClient();
//            info.putVarRejectFlow_valuesrt = flowID;
//            info.relaodAction_actionssrt = "[{\"type\":\"a.reload\"}]";
//            parentlist.Add(info);
//            cycle0.items = parentlist;
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;

//        }
//        else if (model.slug == "app/clientAcceptFlow")
//        {
//            string flowID = model.data["flowID"];
//            acceptFlowByClient info = new acceptFlowByClient();
//            info.putVarAcceptFlow_valuesrt = flowID;
//            parentlist.Add(info);
//            cycle0.items = parentlist;
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;

//        }

//        else if (model.slug == "app/setFlowForm")
//        {
//            parentlist = new List<parent>();
//            newOrderStatus orderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
//            List<orderOptionVM> orderList = await dbcontext.NewOrders.Where(x => x.newOrderStatusID == orderstatus.newOrderStatusID).Select(x => new orderOptionVM { title = x.orderName, orderOptionID = x.newOrderID }).ToListAsync();
//            formOptionObject orderOBJ = new formOptionObject()
//            {
//                name = "orderList",
//                lst = orderList
//            };
//            parentlist.Add(orderOBJ);
//            List<orderOptionVM> processList = await dbcontext.processes.Select(x => new orderOptionVM { title = x.title, orderOptionID = x.processID }).ToListAsync();
//            orderOBJ = new formOptionObject()
//            {
//                name = "processList",
//                lst = processList
//            };
//            parentlist.Add(orderOBJ);


//            cycle0.items = parentlist;
//            cycle0.name = "formData";  // اینجا مجموعه مرتبط با فرم ها ارسال میشه
//            lst0.Add(cycle0);
//            rsp.chunkList = lst0;
//        }


//    }


//    return rsp;
//}

//[BasicAuthentication]
//[System.Web.Http.HttpPost]
//public async Task<appResponse> setFormData([FromBody] getURLVM model)
//{
//    appResponse response = new appResponse();
//    resultResponse result = new resultResponse();
//    object someObject;
//    Request.Properties.TryGetValue("UserToken", out someObject);

//    if (someObject != null || model.slug == "app/verify" || model.slug == "app/setCode")
//    {


//        if (model.slug == "app/NFFOSubmit")
//        {
//            Guid usi = new Guid(someObject.ToString());
//            await setNewFlowFromOrder(model, usi);
//            List<actionResonse> actionlst = new List<actionResonse>();
//            actionResonse goaction = new actionResonse()
//            {
//                type = "a.meesage",
//                text = "فعلت بنجاح",
//                startDelay = 5000

//            };
//            actionlst.Add(goaction);

//            List<actionResonse> reloadlist = new List<actionResonse>();
//            actionResonse reloadaction = new actionResonse() { type = "a.reload" };
//            reloadlist.Add(reloadaction);


//            goaction = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",

//            };


//            actionlst.Add(goaction);

//            result.actions = actionlst;
//            response.result = result;
//            response.code = 0;

//        }

//        else if (model.slug == "app/editProfile")
//        {
//            Guid usi = new Guid(someObject.ToString());
//            await editProfileHandler(model, usi);
//            List<actionResonse> actionlst = new List<actionResonse>();
//            actionResonse goaction = new actionResonse()
//            {
//                type = "a.meesage",
//                text = "فعلت بنجاح",
//                startDelay = 2000


//            };
//            actionlst.Add(goaction);

//            actionResonse reload = new actionResonse()
//            {
//                type = "a.reload",
//                to = "app/managerProfile",
//            };

//            goaction = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",

//            };
//            goaction.actions.Add(reload);


//            actionlst.Add(goaction);


//            result.actions = actionlst;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/getManagerChartData")
//        {
//            List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();

//            if (model.form != null)
//            {
//                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//                var phone = lstform.SingleOrDefault(x => x.key == "tailorList");

//                if (phone != null)
//                {
//                    if (!string.IsNullOrEmpty(phone.value))
//                    {
//                        actionResonse todate = new actionResonse()
//                        {
//                            type = "a.putVar",
//                            varName = "phone",
//                            value = phone.value

//                        };
//                        getOrderListManagerActionlist.Add(todate);
//                    }
//                }


//            }
//            actionResonse ago = new actionResonse()
//            {
//                type = "a.go",
//                to = "app/managerChart",
//                orientation = 1


//            };
//            getOrderListManagerActionlist.Add(ago);
//            result.actions = getOrderListManagerActionlist;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/rejectFlowByUser")
//        {
//            //انجام کارهای اکسپتی فلو توسط کاربر
//            Guid usi = new Guid(someObject.ToString());
//            await changeFlowStatusByClientHandler(model, usi, "2");
//            List<actionResonse> actionlst = new List<actionResonse>();
//            actionResonse goaction = new actionResonse()
//            {
//                type = "a.meesage",
//                text = "فعلت بنجاح",


//            };
//            actionlst.Add(goaction);
//            goaction = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",
//                startDelay = 3000
//            };


//            actionlst.Add(goaction);


//            result.actions = actionlst;
//            response.result = result;
//            response.code = 0;

//        }
//        else if (model.slug == "app/acceptFlowByUser")
//        {
//            //انجام کارهای اکسپتی فلو توسط کاربر
//            Guid usi = new Guid(someObject.ToString());
//            await changeFlowStatusByClientHandler(model, usi, "1");
//            List<actionResonse> actionlst = new List<actionResonse>();
//            actionResonse goaction = new actionResonse()
//            {
//                type = "a.meesage",
//                text = "فعلت بنجاح",


//            };


//            actionlst.Add(goaction);

//            goaction = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",
//                startDelay = 3000

//            };
//            actionlst.Add(goaction);
//            result.actions = actionlst;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/getOrderListManager")
//        {
//            List<actionResonse> getOrderListManagerActionlist = new List<actionResonse>();

//            if (model.form != null)
//            {
//                List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//                var toDate = lstform.SingleOrDefault(x => x.key == "toDate");
//                var fromDate = lstform.SingleOrDefault(x => x.key == "fromDate");
//                var search = lstform.SingleOrDefault(x => x.key == "search");
//                if (toDate != null)
//                {
//                    if (!string.IsNullOrEmpty(toDate.value))
//                    {
//                        actionResonse todate = new actionResonse()
//                        {
//                            type = "a.putVar",
//                            varName = "toDate",
//                            value = toDate.value

//                        };
//                        getOrderListManagerActionlist.Add(todate);
//                    }
//                }
//                if (fromDate != null)
//                {
//                    if (!string.IsNullOrEmpty(fromDate.value))
//                    {
//                        actionResonse fromdate = new actionResonse()
//                        {
//                            type = "a.putVar",
//                            varName = "fromDate",
//                            value = fromDate.value

//                        };
//                        getOrderListManagerActionlist.Add(fromdate);
//                    }
//                }
//                if (search != null)
//                {
//                    if (!string.IsNullOrEmpty(search.value))
//                    {
//                        actionResonse searchVar = new actionResonse()
//                        {
//                            type = "a.putVar",
//                            varName = "search",
//                            value = search.value

//                        };
//                        getOrderListManagerActionlist.Add(searchVar);
//                    }

//                }




//            }
//            actionResonse ago = new actionResonse()
//            {
//                type = "a.go",
//                to = "app/getOrderListManager",


//            };
//            getOrderListManagerActionlist.Add(ago);
//            result.actions = getOrderListManagerActionlist;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/setTailorForm")
//        {
//            Guid userID = new Guid(someObject.ToString());

//            await setTailorForm(model, userID);
//            //getListResponceVM modeldata = await getData(model);
//            List<actionResonse> actionlist = new List<actionResonse>();
//            actionResonse action1 = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",
//                startDelay = 2000
//            };


//            actionlist.Add(action1);
//            action1 = new actionResonse()
//            {
//                type = "a.message",
//                text = "فعلت بنجاح",
//            };
//            actionlist.Add(action1);

//            result.actions = actionlist;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/setNewFlow")
//        {
//            Guid userID = new Guid(someObject.ToString());
//            await setNewFlow(model, userID);
//            List<actionResonse> actionlist = new List<actionResonse>();
//            actionResonse action1 = new actionResonse()
//            {
//                type = "a.back",
//                depth = "1",
//                startDelay = 2000
//            };


//            actionlist.Add(action1);
//            action1 = new actionResonse()
//            {
//                type = "a.message",
//                text = "فعلت بنجاح",
//            };
//            actionlist.Add(action1);

//            result.actions = actionlist;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/verify")
//        {
//            string phoneSended = await handleRegistration(model);
//            List<actionResonse> actionlist = new List<actionResonse>();
//            actionResonse action1 = new actionResonse()
//            {
//                type = "a.putVar",
//                varName = "phone",
//                value = phoneSended,
//            };


//            actionlist.Add(action1);
//            action1 = new actionResonse()
//            {
//                type = "a.go",
//                to = "app/verifyPage",
//            };
//            actionlist.Add(action1);

//            result.actions = actionlist;
//            response.result = result;
//            response.code = 0;
//        }
//        else if (model.slug == "app/setCode")
//        {
//            responseModel tokenModel = await handleSetCode(model);
//            if (tokenModel.status == 200)
//            {
//                List<actionResonse> actionlist = new List<actionResonse>();
//                actionResonse action1 = new actionResonse()
//                {
//                    type = "a.login",
//                    value = tokenModel.message,
//                    text = model.data["phone"]
//                };


//                actionlist.Add(action1);
//                action1 = new actionResonse()
//                {
//                    type = "a.restart",
//                };
//                actionlist.Add(action1);
//                result.actions = actionlist;
//            }

//            else
//            {
//                List<actionResonse> actionlist = new List<actionResonse>();
//                actionResonse action1 = new actionResonse()
//                {
//                    type = "a.message",
//                    text = "کد اشتباه است",
//                };
//                actionlist.Add(action1);
//                result.actions = actionlist;
//            }


//            response.result = result;
//            response.code = 0;
//        }


//    }
//    else
//    {
//        List<actionResonse> actionlist = new List<actionResonse>();
//        actionResonse action1 = new actionResonse()
//        {
//            type = "a.go",
//            to = "app/login",
//        };
//        actionlist.Add(action1);
//        result.actions = actionlist;
//        response.result = result;
//    }


//    return response;
//}


//private async Task<profileVM> getUserInfoHandler(string userID, Context dbcontext)
//{
//    Guid guid = new Guid(userID);
//    profileVM model = new profileVM();
//    var users = await dbcontext.users.Where(x => x.userID == guid).Select(x => new profileVM { profileNameLabel_textsrt = !string.IsNullOrEmpty(x.name) ? "Hello " + x.name : "Hello " + x.phone }).ToListAsync();
//    if (users != null)
//    {
//        model = users.First();
//    }
//    return model;
//}
//private async Task<string> handleRegistration(getURLVM model)
//{
//    string phone = "";
//    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//    if (lstform != null)
//    {
//        if (lstform.Count() > 0)
//        {
//            phone = lstform.First().value;
//        }
//    }
//    responseModel output = new responseModel();
//    string outputstring = "";
//    Random rnd = new Random();
//    int num = rnd.Next(1111, 9999);


//    using (Context dbcontext = new Context())
//    {


//        //Guid Userguid = new Guid("5417296b-b07e-404a-bc71-f04dc8baac2f");

//        //user user = dbcontext.users.SingleOrDefault(x => x.userID == Userguid);
//        //dbcontext.users.Remove(user);
//        //dbcontext.SaveChanges();
//        user myuser = dbcontext.users.SingleOrDefault(x => x.phone == phone);
//        if (myuser != null)
//        {
//            myuser.code = "9999"; // num.ToString(),
//        }
//        else
//        {
//            string status = "0";
//            Guid statusID = dbcontext.verifyStatuses.FirstOrDefault().verifyStatusID;
//            Guid workingID = dbcontext.userWorkingStatuses.FirstOrDefault().workingStatusID;

//            user newuser = new user()
//            {
//                userID = Guid.NewGuid(),
//                phone = phone,
//                name = "",
//                code = "9999", // num.ToString(),
//                userType = "0",
//                verifyStatusID = statusID,
//                workingStatusID = workingID
//            };
//            dbcontext.users.Add(newuser);
//        }

//        dbcontext.SaveChanges();
//    }
//    return phone;
//}

//private async Task<responseModel> handleSetCode(getURLVM model)
//{
//    string phone = model.data["phone"];
//    List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//    string code = lstform.First().value;
//    string token = "";
//    responseModel output = new responseModel();
//    using (Context dbcontext = new Context())
//    {
//        try
//        {
//            user myuser = dbcontext.users.SingleOrDefault(x => x.phone == phone && x.code == code);
//            if (myuser != null)
//            {
//                output.message = TokenManager.GenerateToken(phone, myuser.userID.ToString());
//                output.status = 200;

//            }
//            else
//            {
//                output.message = "Invalid User.";
//                output.status = 400;
//            }
//        }
//        catch (Exception e)
//        {

//            throw;
//        }

//    }
//    return output;
//}

//[spalshAuthentication]
//private async Task<initDataVM> setTailorForm(getURLVM model, Guid userID)
//{

//    initDataVM initdatamodel = new initDataVM();
//    Dictionary<string, string> finaldic = new Dictionary<string, string>();
//    if (model.initdata != null)
//    {
//        foreach (var item in model.initdata)
//        {
//            if (!finaldic.ContainsKey(item.Key))
//                finaldic.Add(item.Key, item.Value);
//        }
//    }
//    if (model.data != null)
//    {
//        foreach (var item in model.data)
//        {
//            if (!finaldic.ContainsKey(item.Key))
//                finaldic.Add(item.Key, item.Value);
//        }
//    }

//    try
//    {
//        using (Context dbcontext = new Context())
//        {
//            var userPhoneQuery = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
//            string userPhone = userPhoneQuery.phone;
//            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//            Guid orderID = finaldic.ContainsKey("orderID") ? new Guid(finaldic["orderID"]) : Guid.NewGuid();
//            Guid processID = finaldic.ContainsKey("processID") ? new Guid(finaldic["processID"]) : Guid.NewGuid();
//            int flowID = finaldic.ContainsKey("flowID") ? Int32.Parse(finaldic["flowID"]) : 0;
//            //Guid userID = new Guid("d981cd48-403c-4560-b1e4-22ae8fcb5989");
//            if (!finaldic.ContainsKey("orderID"))
//            {
//                // یک نیو اردر ایجاد میکنیم

//                newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
//                //Guid thirdPartyGUID = Guid.NewGuid();
//                //thirdParty thirdParty = new thirdParty()
//                //{
//                //    fullname = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyName").value,
//                //    address = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyAddress").value,
//                //    phone = model.formDetailList.SingleOrDefault(x => x.key == "thirdPartyPhone").value,
//                //    ThirdPartyID = thirdPartyGUID,
//                //};
//                //dbcontext.thirdParties.Add(thirdParty);

//                Random rnd = new Random();
//                int month = rnd.Next(11111, 99999);
//                string orderName = month.ToString();
//                detailCollection nameItem = lstform.SingleOrDefault(x => x.key == "name");
//                if (nameItem != null)
//                {
//                    orderName = nameItem.value;
//                }

//                newOrder neworder = new newOrder()
//                {
//                    creationDate = DateTime.Now,
//                    terminationDate = DateTime.Now,
//                    newOrderID = orderID,
//                    newOrderStatusID = neworderstatus.newOrderStatusID,
//                    orderName = orderName

//                    //thirdPartyID = thirdPartyGUID,
//                };
//                dbcontext.NewOrders.Add(neworder);
//                //newOrder checkorder = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.orderName == model.name);
//                //if (checkorder == null)
//                //{

//                //}
//                await dbcontext.SaveChangesAsync();
//            }// 



//            newOrder orderSelected = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
//            newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
//            orderSelected.newOrderStatusID = stat.newOrderStatusID;

//            if (!finaldic.ContainsKey("processID")) //
//            {
//                process pr = await dbcontext.processes.Include(x => x.formList).Include(x => x.formList.Select(t => t.FormItems)).SingleOrDefaultAsync(x => x.isDefault == "1");
//                processID = pr.processID;
//            }


//            if (finaldic.ContainsKey("flowID"))
//            {
//                newOrderFlow selectedflow = await dbcontext.newOrderFlows.FirstOrDefaultAsync(x => x.newOrderFlowID == flowID);
//                selectedflow.isFinished = "1";


//            }
//            else
//            {
//                newOrderFlow newOrderFlow = new newOrderFlow()
//                {
//                    creationDate = DateTime.Now,
//                    actionDate = DateTime.Now,
//                    processID = processID,
//                    isFinished = "1",
//                    newOrderID = orderID,
//                    newOrderFlowID = flowID,
//                    serventPhone = userPhone,
//                    userID = userID,
//                    terminationDate = DateTime.Now,
//                };
//                dbcontext.newOrderFlows.Add(newOrderFlow);
//            }

//            await dbcontext.SaveChangesAsync();

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
//                    fieldItem.valueGuid = new Guid(item.value);
//                if (fieldToGo == "valueDuoble")
//                    fieldItem.valueDuoble = double.Parse(item.value);


//                dbcontext.newOrderFields.Add(fieldItem);

//            }

//            await dbcontext.SaveChangesAsync();


//        }
//    }
//    catch
//    {

//    }
//    return initdatamodel;
//}
//private async Task<initDataVM> setNewFlow(getURLVM model, Guid userID)
//{
//    initDataVM initdatamodel = new initDataVM();
//    Dictionary<string, string> finaldic = new Dictionary<string, string>();
//    if (model.initdata != null)
//    {
//        foreach (var item in model.initdata)
//        {
//            finaldic.Add(item.Key, item.Value);
//        }
//    }
//    if (model.data != null)
//    {
//        foreach (var item in model.data)
//        {
//            finaldic.Add(item.Key, item.Value);
//        }
//    }

//    try
//    {
//        using (Context dbcontext = new Context())
//        {
//            string phone = finaldic.ContainsKey("phone") ? finaldic["phone"] : "";
//            DateTime actinDate = Classes.dateTimeConvert.UnixTimeStampToDateTime(double.Parse(finaldic["actionDate"]));
//            List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//            Guid orderID = new Guid(lstform.SingleOrDefault(x => x.key == "orderList").value);
//            Guid processID = new Guid(lstform.SingleOrDefault(x => x.key == "processList").value);



//            newOrderFlow newOrderFlow = new newOrderFlow()
//            {
//                creationDate = DateTime.Now,
//                processID = processID,
//                isFinished = "0",
//                isAccepted = "0",
//                newOrderID = orderID,
//                serventPhone = phone,
//                userID = userID,
//                terminationDate = DateTime.Now,
//                actionDate = actinDate.Date,

//            };
//            dbcontext.newOrderFlows.Add(newOrderFlow);
//            await dbcontext.SaveChangesAsync();

//            newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
//            newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

//            order.newOrderStatusID = stat.newOrderStatusID;

//            //user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == phone && x.userType == "1");
//            //Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
//            //servent.workingStatusID = ustatuid;

//            await dbcontext.SaveChangesAsync();



//        }
//    }
//    catch
//    {

//    }
//    return initdatamodel;
//}

//private async Task<string> editProfileHandler(getURLVM model, Guid userID)
//{
//    Dictionary<string, string> finaldic = new Dictionary<string, string>();
//    using (Context dbcontext = new Context())
//    {
//        user user = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == userID);
//        List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//        string name = lstform.SingleOrDefault(x => x.key == "Fullname").value;
//        user.name = name;
//        await dbcontext.SaveChangesAsync();
//    }
//    return "";
//}
//private async Task<initDataVM> changeFlowStatusByClientHandler(getURLVM model, Guid userID, string status)
//{
//    initDataVM initdatamodel = new initDataVM();
//    Dictionary<string, string> finaldic = new Dictionary<string, string>();
//    string flowIDstring = model.data["flowID"];
//    int flowID = Int32.Parse(flowIDstring);
//    try
//    {
//        using (Context dbcontext = new Context())
//        {
//            newOrderFlow flow = await dbcontext.newOrderFlows.Include(x => x.NewOrder).SingleOrDefaultAsync(x => x.newOrderFlowID == flowID);

//            flow.isAccepted = status;
//            if (status == "2")
//            {
//                newOrderStatus neworderstatus = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "1");
//                flow.NewOrder.newOrderStatusID = neworderstatus.newOrderStatusID;
//            }

//            await dbcontext.SaveChangesAsync();
//        }
//    }
//    catch
//    {

//    }
//    return initdatamodel;
//}
//private async Task<initDataVM> setNewFlowFromOrder(getURLVM model, Guid userID)
//{
//    initDataVM initdatamodel = new initDataVM();
//    using (Context dbcontext = new Context())
//    {

//        string orderIDstring = model.initdata["orderID"];
//        List<detailCollection> lstform = JsonConvert.DeserializeObject<List<detailCollection>>(model.form);
//        Guid orderID = new Guid(orderIDstring);
//        Guid processID = new Guid(lstform.SingleOrDefault(x => x.key == "processList").value);
//        string phone = lstform.SingleOrDefault(x => x.key == "serventList").value;
//        DateTime actinDate = DateTime.Parse(lstform.SingleOrDefault(x => x.key == "date").value);


//        newOrderFlow newOrderFlow = new newOrderFlow()
//        {
//            creationDate = DateTime.Now.Date,
//            processID = processID,
//            isFinished = "0",
//            isAccepted = "0",
//            newOrderID = orderID,
//            serventPhone = phone,
//            userID = userID,
//            terminationDate = DateTime.Now.Date,
//            actionDate = actinDate.Date,

//        };
//        dbcontext.newOrderFlows.Add(newOrderFlow);
//        //await dbcontext.SaveChangesAsync();

//        newOrder order = await dbcontext.NewOrders.SingleOrDefaultAsync(x => x.newOrderID == orderID);
//        newOrderStatus stat = await dbcontext.newOrderStatuses.SingleOrDefaultAsync(x => x.statusCode == "2");

//        order.newOrderStatusID = stat.newOrderStatusID;

//        //user servent = await dbcontext.users.SingleOrDefaultAsync(x => x.userID == phone && x.userType == "1");
//        //Guid ustatuid = new Guid("569bb370-b49d-4713-883f-1a3750f92978");// عملیاتی
//        //servent.workingStatusID = ustatuid;

//        await dbcontext.SaveChangesAsync();
//    }


//    return initdatamodel;
//}

//// بخش مربوط به تولید داده اختصاصی ویوهای اختصاصی مثل چارت و فرم

//private async Task<List<serventChartVM>> GetDataForManagerOrderList(ManagerOrderList model)
//{
//    List<serventChartVM> serlst = new List<serventChartVM>();

//    DateTime toDate;
//    DateTime fromDate;

//    if (model != null)
//    {
//        if (!string.IsNullOrEmpty(model.toDate))
//        {
//            toDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.toDate));

//        }
//    }
//    if (model != null)
//    {
//        if (!string.IsNullOrEmpty(model.fromDate))
//        {
//            fromDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.fromDate));

//        }
//    }


//    try
//    {
//        using (Context dbcontext = new Context())
//        {

//        }
//    }
//    catch (Exception)
//    {

//        throw;
//    }

//    return serlst;
//}
//private async Task<List<serventChartVM>> GetDataForManagerChart(ManagerChartSearch model)
//{
//    string phone = model.phone;

//    List<Guid> guids = new List<Guid>();
//    if (!string.IsNullOrEmpty(phone))
//    {
//        guids = phone.Split(',').Select(s => Guid.Parse(s)).ToList();
//    }
//    List<serventChartVM> serlst = new List<serventChartVM>();

//    DateTime startDate = customMethodes.returnFirstDayWeekTime().Date;
//    if (model != null)
//    {
//        if (!string.IsNullOrEmpty(model.startDate))
//        {
//            startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.startDate));
//            startDate = startDate.AddDays(-7);
//        }
//    }
//    if (model != null)
//    {
//        if (!string.IsNullOrEmpty(model.endDate))
//        {
//            startDate = dateTimeConvert.UnixTimeStampToDateTime(double.Parse(model.endDate));
//            startDate = startDate.AddDays(1);
//        }
//    }


//    string persianName = customMethodes.returnDayName(startDate);




//    try
//    {
//        using (Context dbcontext = new Context())
//        {
//            //List<user> uslist = dbcontext.users.Where(x => x.barbariID == userID).ToList();

//            var driverListquery = dbcontext.users.Where(x => x.barbariID != null).Include(x => x.workingStatus).Include(x => x.verifyStatus).Select(item => new codrivervm
//            {
//                did = item.userID,
//                dname = item.name,
//                phone = item.phone,


//            });
//            if (guids.Count() > 0)
//            {
//                driverListquery = driverListquery.Where(x => guids.Contains(x.did));
//            }
//            List<codrivervm> driverList = await driverListquery.ToListAsync();
//            foreach (var item in driverList)
//            {

//                serventChartVM servent = new serventChartVM();
//                List<serventChartList> serventList = new List<serventChartList>();
//                servent.name = item.dname + " " + item.phone;
//                servent.phone = item.phone;
//                string dayname = startDate.DayOfWeek.ToString();
//                DateTime usingtime = startDate;
//                for (int i = 0; i <= 6; i++)
//                {

//                    serventChartList chartlist = new serventChartList();
//                    chartlist.dayName = dayname;
//                    chartlist.persianDate = usingtime.ToShortDateString();// dateTimeConvert.ToPersianDateString(usingtime);
//                    chartlist.timestamp = Classes.dateTimeConvert.ConvertDateTimeToTimestamp(usingtime);
//                    chartlist.flowList = await dbcontext.newOrderFlows.Where(x => x.serventPhone == item.phone && x.actionDate == usingtime).Include(x => x.NewOrder).Include(x => x.newOrderProcess).Select(x => new orderFlowVM { isAccepted = x.isAccepted, processID = x.newOrderProcess.processID, orderID = x.NewOrder.newOrderID, isFinished = x.isFinished, flowID = x.newOrderFlowID, processColor = x.newOrderProcess.color, processName = x.newOrderProcess.title, orderName = x.NewOrder.orderName }).ToListAsync();
//                    usingtime = usingtime.AddDays(1);
//                    dayname = usingtime.DayOfWeek.ToString(); //customMethodes.returnDayName(usingtime);

//                    serventList.Add(chartlist);
//                }
//                servent.serventList = serventList;
//                serlst.Add(servent);
//            }




//        }
//    }
//    catch (Exception)
//    {

//        throw;
//    }

//    return serlst;
//}