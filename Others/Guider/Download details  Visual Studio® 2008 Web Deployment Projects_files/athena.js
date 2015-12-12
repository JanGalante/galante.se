var ah_productId = "productID=";
var ah_categoryId = "categoryid=";
var ah_renderFaq = "content=help";
var ah_renderUpdateServices = "content=updateservices";
var ah_renderNotification = "content=notifications";
var ah_renderRelatedSites = "content=relatedsites";

var ah_cookieName = "athena";

var ah_oldHome = "/downloads/Search.aspx";
var ah_render = "/downloads/render.aspx";
var ah_wwlist = "/downloads/wwlist.aspx";
var ah_browseUrl = "/downloads/Browse.aspx?displaylang=en";
var ah_products = "/downloads/Products.aspx?displaylang=en"
var ah_advanced = "u=advancedsearch.aspx";

var ah_newdownloads = "/downloads/en";
var ah_resultsForCategory = ah_newdownloads + "/resultsforcategory.aspx?";
var ah_resultsForProduct = ah_newdownloads + "/resultsforproduct.aspx?";
var ah_newHome = ah_newdownloads + "/default.aspx";
var ah_newWWList = ah_newdownloads + "/worldwidesites.aspx";
var ah_faqPage = ah_newdownloads + "/faq.aspx";
var ah_downloadNotification =  ah_newdownloads + "/DownloadNotifications.aspx"
var ah_A2ZPage = ah_newdownloads + "/A2ZPage.aspx";
var ah_advancedPage = ah_newdownloads + "/AdvancedSearch.aspx";
var ah_resultsPage = ah_newdownloads + "/results.aspx";
var ah_UpdateServices = ah_faqPage + "#How-can-I-keep-my-software-up-to-date";
var ah_RelatedSites = ah_faqPage + "#Which-other-Microsoft-Web-sites-offer-downloads";

function ApplyAthenaChanges() {
    var myCookie = document.cookie;
    var pageUrl = document.URL;
    var pathName = location.pathname;

    if (pathName.match(/details.aspx/i) || pathName.match(/thankyou.aspx/i) || pathName.match(/genuineValidation.aspx/i) || pathName.match(/MozillaValidation.aspx/i) || pathName.match(/exeValidation2.aspx/i)) {
        if(pageUrl.match(/displaylang=en/i) && myCookie.indexOf(ah_cookieName) != -1){
            AthenaUrlFix();    
        }
    }
}

function AthenaUrlFix() {
    var quickSearchObj = document.getElementById("quicksearch");
    if (quickSearchObj != null) {
        var formObj = quickSearchObj.getElementsByTagName("form")
        if (formObj != null && formObj.length > 0) {
            var inputElems = formObj[0].getElementsByTagName("input");
            if (inputElems != null && inputElems.length > 0) {
                for (var i in inputElems) {
                    if (inputElems[i].className == "searchBtn") {
                        inputElems[i].onclick = AthenaGoButtonClick;
                    }
                    if (inputElems[i].className == "textinput") {
                        inputElems[i].id = "athenaTextInput";
                        var keyPress = function(e) { return function() { return AthenaTextInputClick(e); } }
                        if (window.attachEvent)
                            inputElems[i].attachEvent("onkeypress", keyPress(event))
                        else if (window.addEventListener)
                            inputElems[i].addEventListener("keypress", keyPress, false);
                    }
                }
            }
            
            var anch = formObj[0].getElementsByTagName("a");
            if(anch != null && anch.length > 0){
                var advanceSearch = anch[0];
                advanceSearch.href = ah_advancedPage;
            }
        }
    }
    var mnpMenuTop = document.getElementById("mnpMenuTop");
    if (mnpMenuTop) {
        var divCollection = mnpMenuTop.getElementsByTagName("div");
        if (divCollection != null && divCollection.length > 0) {
            var divMnpInherit = divCollection[0];
            if (divMnpInherit) {
                var divMenuRowCollection = divMnpInherit.getElementsByTagName("div");
                if (divMenuRowCollection) {
                    for (var x in divMenuRowCollection) {
                        if (divMenuRowCollection[x].className == "mnpMenuRow") {
                            AthenaUpdateUrl(divMenuRowCollection[x].getElementsByTagName("a")[0]);
                        }
                    }
                }
            }            
        }        
    }
}

function AthenaUpdateUrl(anchorObj) {
    if (anchorObj != null) {
        var existingUrl = anchorObj.href;
        if (existingUrl.indexOf(ah_browseUrl) != -1) {
            if (existingUrl.indexOf(ah_productId) != -1) {
                //redirect to resultsforProduct.aspx
                anchorObj.href = ah_resultsForProduct + existingUrl.substr(existingUrl.indexOf(ah_productId));
            }
            else if (existingUrl.indexOf(ah_categoryId) != -1) {
                //redirect to resultsforCategory.aspx
                anchorObj.href = ah_resultsForCategory + existingUrl.substr(existingUrl.indexOf(ah_categoryId));
            }
        }
        else if(existingUrl.indexOf(ah_oldHome) != -1){
                anchorObj.href = ah_newHome;
        }
        else if(existingUrl.indexOf(ah_wwlist) != -1){
                anchorObj.href = ah_newWWList;
        }
        else if(existingUrl.indexOf(ah_render) != -1){
            if(existingUrl.indexOf(ah_renderFaq) != -1){
                anchorObj.href = ah_faqPage;
            }
            else if(existingUrl.indexOf(ah_renderNotification) != -1){
                anchorObj.href = ah_downloadNotification;
            }
            else if (existingUrl.indexOf(ah_renderRelatedSites) != -1) {
                anchorObj.href = ah_RelatedSites;
            }
            else if (existingUrl.indexOf(ah_renderUpdateServices) != -1) {
                anchorObj.href = ah_UpdateServices;
            }
        }
        else if(existingUrl.indexOf(ah_products) != -1){
            anchorObj.href = ah_A2ZPage;
        } 
    }
}

function AthenaGoButtonClick() {
    var athenaTextInput = document.getElementById("athenaTextInput");
    if (athenaTextInput != null) {
        location.href = ah_resultsPage + "?freetext=" + athenaTextInput.value;
    }
    return false;
}

function AthenaTextInputClick(e) {
    var keyCode = e.which || e.keyCode;
    if (keyCode == 13) {
        AthenaGoButtonClick();
        if (e.preventDefault)
            e.preventDefault();
        else
            return false;
    }
}