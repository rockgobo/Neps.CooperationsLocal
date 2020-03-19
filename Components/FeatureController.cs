/*
' Copyright (c) 2014 LIfBi
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Neps.Cooperations.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Neps.Cooperations
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<Neps.CooperationsInfo> colNeps.Cooperationss = GetNeps.Cooperationss(ModuleID);
        //if (colNeps.Cooperationss.Count != 0)
        //{
        //    strXML += "<Neps.Cooperationss>";

        //    foreach (Neps.CooperationsInfo objNeps.Cooperations in colNeps.Cooperationss)
        //    {
        //        strXML += "<Neps.Cooperations>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objNeps.Cooperations.Content) + "</content>";
        //        strXML += "</Neps.Cooperations>";
        //    }
        //    strXML += "</Neps.Cooperationss>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlNeps.Cooperationss = DotNetNuke.Common.Globals.GetContent(Content, "Neps.Cooperationss");
        //foreach (XmlNode xmlNeps.Cooperations in xmlNeps.Cooperationss.SelectNodes("Neps.Cooperations"))
        //{
        //    Neps.CooperationsInfo objNeps.Cooperations = new Neps.CooperationsInfo();
        //    objNeps.Cooperations.ModuleId = ModuleID;
        //    objNeps.Cooperations.Content = xmlNeps.Cooperations.SelectSingleNode("content").InnerText;
        //    objNeps.Cooperations.CreatedByUser = UserID;
        //    AddNeps.Cooperations(objNeps.Cooperations);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<Neps.CooperationsInfo> colNeps.Cooperationss = GetNeps.Cooperationss(ModInfo.ModuleID);

        //foreach (Neps.CooperationsInfo objNeps.Cooperations in colNeps.Cooperationss)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objNeps.Cooperations.Content, objNeps.Cooperations.CreatedByUser, objNeps.Cooperations.CreatedDate, ModInfo.ModuleID, objNeps.Cooperations.ItemId.ToString(), objNeps.Cooperations.Content, "ItemId=" + objNeps.Cooperations.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
