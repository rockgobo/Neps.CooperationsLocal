/*
' Copyright (c) 2014  LIfBi
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace Neps.Cooperations
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from Neps.CooperationsModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : NepsCooperationsModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Scripts
                JavaScript.RequestRegistration(CommonJs.jQuery);
                JavaScript.RequestRegistration(CommonJs.Knockout);
                JavaScript.RequestRegistration(CommonJs.KnockoutMapping);
                //Page.ClientScript.RegisterClientScriptInclude("viewmodel", this.ControlPath + "js/ViewModel/viewmodel.js");
  
                Page.ClientScript.RegisterClientScriptInclude("logging", this.ControlPath + "js/lifbi.logging.js");
                Page.ClientScript.RegisterClientScriptInclude("d3", this.ControlPath + "js/d3.min.js");
                //Page.ClientScript.RegisterClientScriptInclude("view", this.ControlPath + "coopmap_view.js");
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
        /// <summary>
        /// Returns the URL of the Search handler
        /// </summary>
        public string APIPath
        {
            get
            {
                return string.Concat(DesktopModuleAbsolutePath, "LifbiServices/API/Newsletter/");
            }
        }

        /// <summary>
        /// Gets the absolute path of the application (ie. http://localhost)
        /// </summary>
        private string ApplicationAbsolutePath
        {
            get
            {
                return
                    Context.Request.Url.GetLeftPart(UriPartial.Path)
                                       .Substring(0,
                                        Context.Request.Url.GetLeftPart(
                                        UriPartial.Path).IndexOf(
                                        DotNetNuke.Common.Globals.
                                        ApplicationPath,
                                        System.StringComparison.
                                        CurrentCultureIgnoreCase));
            }
        }
        /// <summary>
        /// Gets the absolute path of the DesktopModule (ie. http://localhost/navigio.website/DesktopModules/)
        /// </summary>
        private string DesktopModuleAbsolutePath
        {
            get { return String.Concat(ApplicationAbsolutePath, DotNetNuke.Common.Globals.DesktopModulePath); }
        }

        public string Language
        {
            get { return this.Page.Culture.StartsWith("Deutsch") || this.Page.Culture.StartsWith("German") ? "de" : "en"; }
        }
        public string SelfPath
        {
            get { return this.ControlPath; }
        }
    }
}