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
using System.IO;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace Neps.Cooperations
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from Neps.CooperationsSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : NepsCooperationsModuleSettingsBase
    {

        private string FileName
        {
            get { return "DesktopModules/Neps.Cooperations/data/network."+Language; }
        }

        public string Data
        {
            get
            {

                try
                {
                    //using (StreamReader sr = new StreamReader(Page.MapPath("DesktopModules/Lifbi.Cooperations/data/network." + Language + ".js")))
                    using (StreamReader sr = new StreamReader(Page.MapPath(FileName+".js")))
                    {
                        String line = DecodeCharacters(sr.ReadToEnd());
                        return line;
                    }
                }
                catch (Exception e)
                {

                    InfoPanel.Attributes.Add("Class", "dnnFormMessage dnnFormError");
                    InfoPanel.InnerText = e.Message;
                    return "";
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                    /* uncomment to load saved settings in the text boxes*/
                    txtSettingData.Text = Data;
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public void SaveData(Object sender, EventArgs e)
        {
            if (txtSettingData.Text.Equals(Data))
            {
                InfoPanel.Attributes.Add("Class", "dnnFormMessage dnnFormInfo");
                InfoPanel.InnerText = "No changes needs to be saved";
                return;
            }

            // Write the stream contents to a new file named "AllTxtFiles.txt".
            try
            {
                //Backup old file
                using (
                    var outfile =
                        new StreamWriter(
                            Page.MapPath(FileName + "_" + DateTime.Now.Ticks + "." + Language + ".js"), false))
                {
                    outfile.Write(EncodeCharacters(Data));
                }

                //Save new File
                using (
                    var outfile =
                        new StreamWriter(
                            Page.MapPath(FileName+".js"), false))
                {
                    outfile.Write(EncodeCharacters(txtSettingData.Text));
                    InfoPanel.Attributes.Add("Class", "dnnFormMessage dnnFormSuccess");
                    InfoPanel.InnerText = "File Saved";
                }
            }
            catch (Exception exc)
            {
                InfoPanel.Attributes.Add("Class", "dnnFormMessage dnnFormError");
                InfoPanel.InnerText = exc.Message;
            }
        }

        public string Language
        {
            get { return this.Page.Culture.StartsWith("Deutsch") || this.Page.Culture.StartsWith("German") ? "de" : "en"; }
        }

        private string EncodeCharacters(string text)
        {
            return text;
            /*var newText = text;
            newText = newText.Replace("Ä", "\\u00C4");
            newText = newText.Replace("Ö", "\\u00D6");
            newText = newText.Replace("Ü", "\\u00DC");
            newText = newText.Replace("ä", "\\u00E4");
            newText = newText.Replace("ö", "\\u00F6");
            newText = newText.Replace("ü", "\\u00FC");

            return newText;*/
        }
        private string DecodeCharacters(string text)
        {
            return text;
            /*
            var newText = text;
            newText = newText.Replace("\\u00C4", "Ä");
            newText = newText.Replace("\\u00D6", "Ö");
            newText = newText.Replace("\\u00DC", "Ü");
            newText = newText.Replace("\\u00E4", "ä");
            newText = newText.Replace("\\u00F6", "ö");
            newText = newText.Replace("\\u00FC", "ü");

            return newText;*/
        }



        #region Base Method Implementations

        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                //modules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text);
                //modules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text);

                //tab module settings
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting1",  txtSetting1.Text);
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting2",  txtSetting2.Text);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}