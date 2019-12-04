using System;
using System.Collections.Generic;

using System.Web;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Globalization;
using System.Net;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;
using System.Text;
using Microsoft.AspNet.Identity;



namespace testudines.cls
{
    public static class ClsUtils
    {

        public static string Fnc_BldHtmPdf(String pdfUri)
            {
            string embed = "";
            String path =ClsUtils.FncPathCombine( ClsGlobal.DirRoot ,pdfUri);
             if (FncPathFileExist(path))
            {
                embed += "<div class=\"embed-responsive embed-responsive-210by297\">";
                embed += "<object class=\"embed-responsive-item\" data=\"" + pdfUri + "\" type=\"application/pdf\" >";
                embed += "If you are unable to view file, you can download from <a href = \"{" + pdfUri + "}\">here</a>";
                embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
                embed += "</object></div>";
            }
            else
            { embed = "Can't open Pdf " + pdfUri; }
            return embed;

            //scnPdfEmbed.Text = string.Format(embed, ResolveUrl(PdfUrl));
  
    }

        public static string FncImg_GetMed(String pUrlImg)
        {
            String pUrlImg2 = pUrlImg.ToLower();
            if (pUrlImg2.EndsWith("_min.jpg")) { pUrlImg2 = pUrlImg2.Replace("_min.jpg", "_med.jpg"); }
            if (pUrlImg2.EndsWith("_big.jpg")) { pUrlImg2 = pUrlImg2.Replace("_big.jpg", "_med.jpg"); }
            if (pUrlImg2.EndsWith("_minx.jpg")) { pUrlImg2 = pUrlImg2.Replace("_minx.jpg", "_med.jpg"); }
            if (pUrlImg2.EndsWith("_ful.jpg")) { pUrlImg2 = pUrlImg2.Replace("_ful.jpg", "_med.jpg"); }
            
           if (!FncPathFileExist(FncPathCombine(cls.ClsGlobal.DirRoot, pUrlImg2)))
                {
                pUrlImg2 = "/a_img/noimage600px.jpg";
            }
             
                        return pUrlImg2;
        }


        public static String Oops_Redirect(String pRequestUrl, String pMsg)
        {
            string szReturn = "/oops.aspx?url=" + pRequestUrl + "&msg=" + pMsg;
            return szReturn;
        }
        public static String User_name()
        {
            try
            {
                if (Membership.GetUser().UserName != null)
                {

                    return Membership.GetUser().UserName;
                }
                else
                { return "Anonimous"; }
            }
            catch
            { return "Anonimous"; }
        }



        public static bool User_isAdmin()
        {
            if (FncIPIsLocalGet()) return true;
            try
            {
                if (Membership.GetUser() != null)
                {
                    String szUserName = Membership.GetUser().ToString();
                    return Roles.IsUserInRole(szUserName, "Admin");

                }
            }
            catch
            { return false; }
            return false;

        }

        public static string FncIPLocalGet()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            
            string a =  context.Server.HtmlEncode(context.Request.UserHostAddress);
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }


            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static bool FncIPIsLocalGet()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string szIp = context.Request.ServerVariables["REMOTE_ADDR"];
            if (szIp == "::1") return true; //IP& Loopback

            if (szIp.StartsWith("127.")) return true;
            if (szIp.StartsWith("192.168")) return true;
            return false;

        }
        /// <summary>
        /// Devuleve solo los numeros que hay en un string con
        /// digitos y letras
        /// </summary>
        /// <param name="szCharacterAndNumber">Strign con numeros y letras Az</param>
        /// <returns>String con solo numeros</returns>
        public static String FncStringOnlyNumber(String szCharacterAndNumber)
        {
           // var OnlyNumber = Regex.Replace(szCharacterAndNumber, @"^[A-Za-z]+", "");

            string OnlyNumber = Regex.Replace(szCharacterAndNumber, "[^.0-9]", "");
            return OnlyNumber;
        }
        // System.Globalization.CompareInfo cmpUrl = System.Globalization.CultureInfo.InvariantCulture.CompareInfo;
        public static T Parse<T>(object value)
        {
            try { return (T)System.ComponentModel.TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value.ToString()); }
            catch (Exception) { return default(T); }
        }
        // Change lenght  string with max len without blank at end
        public static void FncTrimLen(ref String szText, int iLen)
        {
            szText = szText.Trim();
            if (szText.Length > iLen)
            {
                szText = szText.Substring(0, iLen - 1);
            }
        }

        /// <summary>
        /// Replace case insesitive
        /// </summary>
        /// <param name="originalString">Original full string</param>
        /// <param name="oldValue">Old value to replace</param>
        /// <param name="newValue">New value for replace</param>
        /// <returns>Original with text replaced</returns>
        public static string ReplaceCI(string originalString, string oldValue, string newValue)
        {
            Regex regEx = new Regex(oldValue,
               RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return regEx.Replace(originalString, newValue);
        }
        /// <summary>
        /// ELimina dobles barras y convierte barras / en \ 
        /// Para compatibilidad con windows
        /// </summary>
        /// <param name="szPath"></param>
        public static void FncPathClear(ref string szPath)
        {
            szPath = szPath.Replace("\\", "/");
            while (szPath.Contains("//"))
            {
                szPath = szPath.Replace("//", "/");
            }

        }

        public static string FncFileNameShort(string szPath)
        {
            string sz = "";
            string szFilename = "";
            for (Int32 n = (szPath.Length - 1); n > 0; n--)
            {
                sz = szPath.Substring(n, 1);
                if (sz == "/") return szFilename;
                if (sz == "\\") return szFilename;
                szFilename = sz + szFilename;
            }
            return szFilename;
        }
        public static String FncUrlCombine(String UrlRootServer, String UrlLocal)
        {
            if (!UrlRootServer.StartsWith("http://")) { UrlRootServer = "http://" + UrlRootServer; }


            if (!UrlRootServer.EndsWith("/")) { UrlRootServer = UrlRootServer + "/"; }
            if (UrlLocal.StartsWith("/")) { UrlLocal = UrlLocal.Substring(1, UrlLocal.Length - 1); }
            String result = UrlRootServer + UrlLocal;

          while (result.Contains("//"))
            {
                result = result.Replace("//", "/");
            }

            

            return result;

        }
        /// <summary>
        /// Combina un path raiz tipo c:\nombres\
        /// Con un path relativo tipo \pepe\
        /// convirtiendolo a minusculas y evitando barras dobles
        /// o poniendolas si hacen falta
        /// </summary>
        /// <param name="PathStart"></param>
        /// <param name="PathEnd"></param>
        /// <returns></returns>
        public static String FncPathCombine(String PathStart, String PathEnd)
        {
            PathStart = PathStart.ToLower();
            PathEnd = PathEnd.ToLower();
            if (!PathStart.EndsWith("\\")) { PathStart = PathStart + "\\"; }
            String result = PathStart + PathEnd;
            FncPathFileNameNormaliceSlashes(ref result);
            return result;

        }
        /// <summary>
        /// Crear un directorio si no existe
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public static bool FncPathDirectoryBuid(string pPath)
        {

            try
            {
                if (!System.IO.Directory.Exists(pPath))
                {
                    System.IO.Directory.CreateDirectory(pPath);
                }
                return true;
            }
            catch { return false; }
        }
        public static bool FncPathDirectoryDelete(string pPath)
        {

            try
            {
                if (System.IO.Directory.Exists(pPath))
                {
                    System.IO.Directory.Delete(pPath, true);

                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch { return false; }
        }
        /// <summary>
        /// Devuelve el nombre del fichero con un numerador
        /// de forma que se guardan versiones numeradas del los ficheros.
        /// Si dos personas subieran un mismo fichero a un mismo destino simultaneamente
        /// se remplazarian, 
        /// </summary>
        /// <param name="szFileFulPath">Ruta del fichero que se desea</param>
        /// <returns>Ruta de fichero con un mumerador unico</returns>
        public static string FncPathFileNameUnique(string szFileFulPath)
        {
            string szFileNameUnique = "";
            string szFileType = FncPathFileGetExtensionType(szFileFulPath);
            string szFilePathNoType = "";
            //szFileFulPath = FncPathFileNameNormalice(szFileFulPath);

            string szI = "";
            string szFile = "";
            try
            {
                szFilePathNoType = szFileFulPath.Substring(0, szFileFulPath.Length - szFileType.Length);
                for (int i = 0; i < 9999; i++)
                {

                    szI = "_" + i.ToString().PadLeft(4, '0');
                    szFile = szFilePathNoType + szI + szFileType; ;
                    if (!System.IO.File.Exists(szFile))
                    {
                        szFileNameUnique = szFile;
                        i = 10000;

                    }

                }
            }
            catch {; }
            return szFileNameUnique;

        }
        /// <summary>
        /// path normalizado en cuanto a barrasa a minuscuals
        /// lo cambia a minusculas y paso por referencia.
        /// cambia los / por \ y elimina las dobles \\
        /// </summary>
        /// <param name="pPath"></param>
        private static void FncPathFileNameNormaliceSlashes(ref String pPath)
        {
            pPath = pPath.ToLower();
            pPath = pPath.Replace("/", "\\");
            while (pPath.Contains("\\\\"))
            {
                pPath = pPath.Replace("\\\\", "\\");
            }
            pPath = pPath.Replace("\\", "/");
        }
        /// <summary>
        /// Limpia caracteres estraños, acentos, barras, signos de puntuacion
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string FncPathFileNameNormalice(string inputString)
        {
            inputString = inputString.Trim().ToLower();
            string szFileNameType = inputString.Substring(inputString.Length - 4, 4);
            inputString = inputString.Substring(0, inputString.Length - 4);
            // remove doubles spacesy
            while (inputString.Contains("  "))
            {
                inputString = inputString.Replace("  ", " ");
            }
            inputString = inputString.Replace(".", "_");
            inputString = inputString.Replace(" ", "_");
            inputString = inputString.Replace("-", "_");
            inputString = inputString.Replace("|)", "");

            //inputString = szFile.Replace(":", "");
            //inputString = szFile.Replace(".", "-");
            //inputString = szFile.Replace(",", "-");
            //inputString = szFile.Replace("@", "");
            //inputString = szFile.Replace(";", "-");

            //szFile = szFile.Replace("'", "");
            //szFile = szFile.Replace("(", "");
            //szFile = szFile.Replace(")", "");
            //szFile = szFile.Replace("^)", "");
            //szFile = szFile.Replace("!)", "");
            //szFile = szFile.Replace("¡)", "");
            //szFile = szFile.Replace("¿)", "");
            //szFile = szFile.Replace("?)", "");
            //szFile = szFile.Replace("&)", "");
            //szFile = szFile.Replace("$)", "");
            //szFile = szFile.Replace("#)", "");

            // szFile = szFile.Replace(@"/", "");
            //szFile = szFile.Replace("\\)", "");
            // szFile = szFile.Replace("+)", "");
            // szFile = szFile.Replace("=)", "");



            Regex replace_a_Accents = new Regex("[á|à|ä|â|ä]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|ë]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î|ï]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô|ö]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|ü]", RegexOptions.Compiled);
            Regex replace_signs = new Regex("['|,|:|?|¿|$|+|&|!|¡|=|@|#|\\|^|´|¨|/|(|)|;]", RegexOptions.Compiled);

            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");

            inputString = inputString.Replace("ñ", "n");
            inputString = replace_signs.Replace(inputString, "");

            inputString = FncPathRemoveAccentsWithNormalization(inputString);
            while (inputString.Contains("__"))
            {
                inputString = inputString.Replace("__", "_");
            }
            inputString = inputString + szFileNameType;
            return inputString;
        }
        public static string RemoveAccentsWithNormalization(string inputString)
        {
            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static string FncPathRemoveAccentsWithNormalization(string inputString)
        {
            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
        public static bool FncPathFileDelete(String filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                try { System.IO.File.Delete(filePath); }
                catch { return false; }
            }
            return true;
        }
        /// <summary>
        /// copia el fichero origen en destino con numerador de versiones al final, evitando sustituciones
        /// </summary>
        /// <param name="szFileFullPathSrc">Ruta completa del fichero origen</param>
        /// <param name="szFileFulPathTarget">Ruta completa del fichero destino</param>
        /// <returns>Nombre de fichero gravado sin la ruta, y con el numerador asignado</returns>
        public static string FncPathFileCopyUnique(string szFileFullPathSrc, string szFileFulPathTarget)
        {
            string szError = "";
            string szFileName = "";
            try
            {
                szFileFulPathTarget = FncPathFileNameUnique(szFileFulPathTarget);
                System.IO.File.Copy(szFileFullPathSrc, szFileFulPathTarget, true);
                System.IO.FileInfo oInfo = new System.IO.FileInfo(szFileFulPathTarget);
                szFileName = oInfo.Name;
            }
            catch (Exception xcpt)
            { szError = xcpt.Message; ; }
            return szFileName;
        }
        public static string FncPathFileGetExtensionType(string szFilePath)
        {
            string szExtension = "";
            string szChar = "";
            bool bFindDot = false;
            for (int n = szFilePath.Length - 1; n > 0; n--)
            {
                szChar = szFilePath.Substring(n, 1);
                if (szChar == ".")
                {
                    bFindDot = true;
                    n = -1; // fuerza salida del bucle
                }
                szExtension = szChar + szExtension;

            }
            if (!bFindDot) szExtension = "";
            return szExtension.ToLower();
        }
        public static string FncDateToAAAAMMDD(DateTime oDate)
        {
            string szDate = oDate.Year.ToString();
            string sz = oDate.Month.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + sz;
            sz = oDate.Day.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + sz;
            return szDate;
            ;


        }
        /// <summary>
        /// devuelve la cadena DD/MM/YYY
        /// </summary>
        /// <param name="oDate"></param>
        /// <returns></returns>
        public static string FncDateTo_DD_MM_YYY(DateTime oDate)
        {
            string szDate = "";

            string sz = oDate.Day.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + sz+"/";

            sz=oDate.Month.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + sz+"/";

            sz = oDate.Year.ToString();
            szDate = szDate + sz;
            return szDate;
            


        }
        public static string FncDateToAAAA_MM_DD(DateTime oDate)
        {
            string szDate = oDate.Year.ToString();
            string sz = oDate.Month.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + "-" + sz;
            sz = oDate.Day.ToString();
            if (sz.Length < 2) sz = "0" + sz;
            szDate = szDate + "-" + sz;
            return szDate;
            ;


        }
        public static string FncCountryFromCodes(string szCountriesCodes, string szLngId)
        {
            string szKey = "";
            string szColon = "";
            string szCountries = "";
            string[] aCodes = szCountriesCodes.Split(',');
            cls.bbdd.ClsReg_tmst_geo_country oReg = new testudines.cls.bbdd.ClsReg_tmst_geo_country();
            for (int i = 0; i < aCodes.Length; i++)
            {
                szKey = (aCodes[i].Trim());
                if (szKey != "")
                {
                    oReg.FncSqlFind(szKey);
                    szCountries += szColon + oReg.CountryName;
                    szColon = ", ";
                }
            }
            return szCountries;
        }
        #region radiobutton
        public static string FncRadioButton_Get_StringValues(ref RadioButtonList oRadioButton)
        {
            return oRadioButton.SelectedValue;
        }

        #endregion

        //==================================================================
        #region regcombo

        public static void FncDropDown(ref DropDownList oDropDownList, String pTableName, string pFieldName, Int32 pIdSelected)
        {
            string szSql = "select IdTranlation, CONCAT( LogDateTimeCreation,' - ',LogIdUser,'- Published= ',Published) as Value from tdoclng_translations";
            szSql = "where TableSource='" + pTableName + "' and FieldName='" + pFieldName + "'";
            szSql = "order by IdTranlation desc";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            bool bExist = false;
            string szId = "";
            string szText = "";
            int iSelected = -1;
            string szIdSelected = pIdSelected.ToString();
            int iCount = -1;
            foreach (DataRow oRow in oTb.Rows)
            {
                szId = oRow[0].ToString().Trim().ToLower();
                szText = oRow[1].ToString();

                if (pIdSelected.ToString() == szId)
                {
                    bExist = true;
                }
                iCount++;
                oDropDownList.Items.Add(new ListItem(szId, szText));
                if (szId == szIdSelected)
                { iSelected = iCount; }

            }
            if (!bExist)
            {

                oDropDownList.Items.Add(new ListItem(szIdSelected, szIdSelected));
                iCount++;
                iSelected = iCount;
            }
            if (iSelected > -1) oDropDownList.SelectedIndex = iSelected;

        }

        //-------------------------------------

        //-------------------------------------
        public static void FncDropDownDocIdTaxaRelationValue(ref DropDownList oDropDownList, UInt64 defValue, string doclngId)
        {
            String szDefValue = defValue.ToString();
            string szSql = "select DocId, CONCAT( tdoclng_testudines_taxa_all.ATaxGrpL2270Genus,' ',tdoclng_testudines_taxa_all.ATaxGrpL2280Specie) as IdName ,'specie' as ttable from tdoclng_testudines_taxa_all union select DocId, ATaxIdName,'group'  from tdoclng_testudines_groups order by IdName";
            if (doclngId == "") doclngId = ClsGlobal.default_DocLngId;

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            // si no hay datos tomar los del ingles
            if (oTb.Rows.Count == 0)
            {

            }
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Close();
            oCnn.Dispose();
            bool bExist = false;

            oDropDownList.Items.Clear();
            oDropDownList.Items.Add(new ListItem("No relation", "-1"));
            // oDropDownList.Items.Add(new ListItem("?", "no"));

            foreach (DataRow oRow in oTb.Rows)
            {
                string szValue = oRow["DocId"].ToString().Trim().ToLower();
                if (szDefValue == szValue) bExist = true;
                oDropDownList.Items.Add(new ListItem(oRow["IdName"].ToString().Trim(), szValue));
            }
            if (bExist == false)
            {
                oDropDownList.Items.Add(new ListItem(szDefValue, szDefValue));

            }
            if (szDefValue != "")
            {
                oDropDownList.Text = szDefValue;
            }
            else
            {
                oDropDownList.SelectedIndex = 0;
            }

        }
        public static void FncDropDownEcozones(ref DropDownList oDropDownList, string defValue, string doclngId)
        {
            if (doclngId == "") doclngId = ClsGlobal.default_DocLngId;

            string szSql = "select EcozoneListCode , Title,    ImgRainTemp, Abstract";
            szSql += " from tdoclng_geoclimate_koppengeigers";
            szSql += " where DocLngId ='" + doclngId + "'";
            szSql += " order by EcozoneListOrder";

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            // si no hay datos tomar los del ingles
            if (oTb.Rows.Count == 0)
            {
                szSql = "select EcozoneListCode , Title,    ImgRainTemp, Abstract";
                szSql += " from tdoclng_geoclimate_koppengeigers";
                szSql += " where DocLngId ='en'";
                szSql += " order by EcozoneListOrder";
                oCmd.CommandText = szSql;
                oDa.Fill(oTb);
            }
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Close();
            oCnn.Dispose();
            bool bExist = false;
            oDropDownList.Items.Clear();
            // oDropDownList.Items.Add(new ListItem("?", "no"));

            foreach (DataRow oRow in oTb.Rows)
            {
                string szValue = oRow["EcozoneListCode"].ToString().Trim().ToLower();
                if (defValue == szValue) bExist = true;
                oDropDownList.Items.Add(new ListItem(oRow["Title"].ToString().Trim(), szValue));
            }
            if (bExist == false)
            {
                oDropDownList.Items.Add(new ListItem(defValue, defValue));

            }
            if (defValue != "")
            {
                oDropDownList.Text = defValue;
            }
            else
            {
                oDropDownList.SelectedIndex = 0;
            }


        }

        public static void FncDropDownAvatars(ref DropDownList oDropDownList, string defValue)
        {
            defValue = defValue.Trim().ToLower();
            if (defValue == "") defValue = "avt_default.png";
            // borrar posibles valores
            oDropDownList.Items.Clear();
            // hacer consulta
            string szSql = "Select description, filenamesrc, isactive, ispublicuse from tmst_avatars where isActive=true order by description";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            bool bExist = false;
            foreach (DataRow oRow in oTb.Rows)
            {
                string szValue = oRow["filenamesrc"].ToString().Trim().ToLower();
                if (defValue == szValue) bExist = true;
                oDropDownList.Items.Add(new ListItem(oRow["description"].ToString().Trim(), szValue));
            }
            if (bExist == false)
            {
                oDropDownList.Items.Add(new ListItem(defValue, defValue));

            }

            oDropDownList.Text = defValue;

        }
        public static void FncDropDownSetSelect(ref DropDownList poDropDownList, string SelectValue)
        {
            poDropDownList.ClearSelection();
            for (int i = 0; i < poDropDownList.Items.Count;i++)
            {
                if (poDropDownList.Items[i].Value.ToString() == SelectValue)
                {
                   poDropDownList.Items[i].Selected = true;
                    return;
                }
            }
            // if not exit add
            ListItem item = new ListItem(SelectValue, SelectValue);
            item.Selected = true;
            poDropDownList.Items.Add(item); 

        }
        private static void FncDropDownSql(ref DropDownList poDropDownList, string pszSqlSelect, Int32 pdefValueSelected)
        {
            poDropDownList.Items.Clear();
            // hacer consulta
            string pszdefValueSelected = pdefValueSelected.ToString();
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(pszSqlSelect, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            bool bExist = false;
            string szValue = "";
            string szName = "";
            int idSelected = -1;
            int iCount = -1;
            foreach (DataRow oRow in oTb.Rows)
            {
                iCount++;
                szValue = oRow["value"].ToString().Trim();
                szName = oRow["name"].ToString().Trim();
                if (pszdefValueSelected.ToString().ToLower() == szValue.Trim().ToLower())
                {
                    bExist = true;
                    idSelected = iCount;
                }
                poDropDownList.Items.Add(new ListItem(szName, szValue));
            }
            if (bExist == false && pszdefValueSelected != "0")
            {
                iCount++;
                idSelected = iCount;
                poDropDownList.Items.Add(new ListItem(pszdefValueSelected, pszdefValueSelected));

            }

            try
            {
                if (pszdefValueSelected != "0")
                {
                    poDropDownList.SelectedIndex = idSelected;
                }
                else
                {
                    poDropDownList.SelectedIndex = 0;
                }
            }
            catch {; }

        }
        
        private static void FncDropDownSql(ref DropDownList oDropDownList, string szSqlSelect, string defSelecteValue)
        {
            // borrar posibles valores
            oDropDownList.Items.Clear();
            // hacer consulta

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSqlSelect, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            bool bExist = false;
            string szValue = "";
            string szName = "";
            int idSelected = -1;
            int iCount = -1;
            foreach (DataRow oRow in oTb.Rows)
            {
                iCount++;
                szValue = oRow["value"].ToString().Trim();
                szName = oRow["name"].ToString().Trim();
                if (defSelecteValue.Trim().ToLower() == szValue.Trim().ToLower())
                {
                    bExist = true;
                    idSelected = iCount;
                }
                oDropDownList.Items.Add(new ListItem(szName, szValue));
            }
            if (bExist == false && defSelecteValue != "")
            {
                iCount++;
                idSelected = iCount;
                oDropDownList.Items.Add(new ListItem(defSelecteValue, defSelecteValue));

            }

            try
            {
                if (defSelecteValue != "")
                {
                    oDropDownList.SelectedIndex = idSelected;
                }
                else
                {
                    oDropDownList.SelectedIndex = 0;
                }
            }
            catch {; }
        }
        public static void FncDropDownRedList(ref DropDownList oDropDownList, ref Image oImage, string DocLngId, String defIdSelected)
        {
            string szSql = "select  RL_levelID as value, RL_levelID, CONCAT_WS(' - ',RL_Key, LR_DecriptionShort)  as name from tmst_iucn_redlist where DocLngId='" + DocLngId + "' order by RL_levelID";
            FncDropDownSql(ref oDropDownList, szSql, defIdSelected);
        }

        public static void FncDropDownTranlationsTableField(ref DropDownList oDropDownList, string pKeyTableSource, string pKeyFieldName, Int64 pKeyDocId, string pKeyDocLngId, Int32 pIdTranlationSelected)
        {

            string szSql = "select IdTranlation as value, CONCAT( LogDateTimeCreation,' - ',LogIdUser,'- Published= ',Published,', ID=',IdTranlation) as name from tdoclng_translations";
            szSql += " where KeyTableSource='" + pKeyTableSource + "' and KeyFieldName='" + pKeyFieldName + "' and KeyDocId='" + pKeyDocId.ToString() + "' and KeyDocLngId='" + pKeyDocLngId + "' order by IdTranlation desc";
            FncDropDownSql(ref oDropDownList, szSql, pIdTranlationSelected);

            oDropDownList.SelectedIndex = 0;
        }

        public static void FncDropDownCountry(ref DropDownList oDropDownList, string defValue)
        {
            string szSql = "Select  IdCoutryISO3Plus AS value,CountryName as name from tmst_geo_country where id_lng='EN' order by CountryName";
            FncDropDownSql(ref oDropDownList, szSql, defValue);
        }
        public static void FncDropDownLngTranlatables(ref DropDownList oDropDownList, string defValue)
        {
            string szSql = "SELECT LngId as value, LanguageName_EN as name FROM tmst_geo_languages where isTraslatable=true order by LngId";
            FncDropDownSql(ref oDropDownList, szSql, defValue);
        }
        public static void FncDropDownUICulture(ref DropDownList oDropDownList, string defValue)
        {
            if (defValue.Trim() == "") defValue = ClsGlobal.default_UICulture;
            string szSql = "SELECT UICulture as value, LanguageName_EN as name FROM tmst_geo_languages where isTraslatable=true order by LngId";
            FncDropDownSql(ref oDropDownList, szSql, defValue);
        }
        public static void FncDropDownLng(ref DropDownList oDropDownList, string defValue)
        {
            string szSql = "SELECT LngId as value, LanguageName_En as name FROM tmst_geo_languages order by LngId";
            FncDropDownSql(ref oDropDownList, szSql, defValue);
        }
        #endregion regcombo
        //==================================================================
        #region checkboxes_general
        /// <summary>
        /// Build  with the selected values, separated by comma
        /// </summary>
        /// <param name="oCheckBoxList">Ref CkeckBoxList</param>
        /// <returns>String with values, sep by comma</returns>
        public static string FncChecbox_Get_StringValues(ref CheckBoxList oCheckBoxList)
        {
            //string szComa = ", ";
            string sz = "";
            bool bComa = false;
            for (int n = 0; n < oCheckBoxList.Items.Count; n++)
            {
                if (oCheckBoxList.Items[n].Selected)
                {
                    if (bComa) sz += ", ";
                    sz += oCheckBoxList.Items[n].Value;
                    bComa = true;
                }
            }
            return sz;
        }

        /// <summary>
        /// Add marck to checkbox list,  marc to 
        /// </summary>
        /// <param name="oCheckBoxList">Ref checkboxlistcontro</param>
        /// <param name="szValuesComa">String with values to check separted by coma</param>

        private static void FncFill_ListBoxChecked(ref CheckBoxList oCheckBoxList, string szValuesComa)
        {
            string[] aSelectedValues = szValuesComa.Split(',');
            string szItem = "";
            string szItemSelected = "";
            bool bInlist = false;
            // Opps, if are item selected, and it is not in list, then add to list
            for (int i = 0; i < aSelectedValues.Length; i++)
            {
                szItemSelected = aSelectedValues[i].Trim().ToLower();
                bInlist = false;
                for (int n = 0; n < oCheckBoxList.Items.Count; n++)
                {
                    szItem = oCheckBoxList.Items[n].Value.Trim().ToLower();
                    if (szItemSelected == szItem)
                    {
                        bInlist = true;
                        n = oCheckBoxList.Items.Count + 1; // force exit
                    }

                }
                // if not in list, then add and check
                if (!bInlist)
                {
                    oCheckBoxList.Items.Add(new ListItem(szItemSelected, szItemSelected, true));

                }
            }

            // check selected items,
            for (int n = 0; n < oCheckBoxList.Items.Count; n++)
            {
                szItem = oCheckBoxList.Items[n].Value.Trim().ToLower();
                for (int i = 0; i < aSelectedValues.Length; i++)
                {
                    szItemSelected = aSelectedValues[i].Trim().ToLower();
                    if (szItem == szItemSelected)
                    {
                        oCheckBoxList.Items[n].Selected = true;
                    }
                }
            }
        }
        public static void FncFillCheckBox(ref CheckBox pCheckBox, bool pChecked)
        {
            if (pChecked)
            { pCheckBox.Checked = true; }
            else
            { pCheckBox.Checked = false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oChkLst"></param>
        /// <param name="szListValue">Array text|value, separated by comman,
        /// Exemaple Naranja|apple, Reloj|clock,Coche|car</param>
        /// <param name="szListChecked">Array values selected</param>
        /// 
        public static void FncFillCheckBoxList(ref CheckBoxList oChkLst, string szListTexValue, string szListCheked)
        {
            oChkLst.Items.Clear();
            string[] aListTextValues = szListTexValue.Split('#');
            string[] aListCheked = szListCheked.Split(',');
            string szText = "";
            string szValue = "";
            bool bChecked = false;
            string szCheked = "";

            // bucle fill 
            for (int n = 0; n < aListTextValues.Length; n++)
            {
                string[] szPar = aListTextValues[n].Split('|');
                bChecked = false;
                //Is checked
                for (int i = 0; i < aListCheked.Length; i++)
                {
                    if (szPar[1].Trim().ToLower() == aListCheked[i].Trim().ToLower())
                    {
                        bChecked = true;
                    }
                }



                //string sz= Resources.strings.Article;
                string sz = System.Threading.Thread.CurrentThread.CurrentUICulture.Parent.ToString();
                szText = szPar[0].Trim();
                szValue = szPar[1].Trim().ToLower();
                oChkLst.Items.Add(new ListItem(szText, szValue, true));
                oChkLst.Items[oChkLst.Items.Count - 1].Selected = bChecked;
            }
            // by the flys, If checked is not in list then add and checked
            bool bInList = false;
            for (int i = 0; i < aListCheked.Length; i++)
            {
                bInList = false;
                for (int n = 0; n < oChkLst.Items.Count; n++)
                {
                    szValue = oChkLst.Items[n].Value.Trim().ToLower();
                    szCheked = aListCheked[i].Trim().ToLower();

                    if (szValue == szCheked)
                    {
                        bInList = true;
                    }
                }
                if (!bInList && szCheked != "")
                {
                    oChkLst.Items.Add(new ListItem(szCheked, szCheked, true));
                    oChkLst.Items[oChkLst.Items.Count - 1].Selected = true;
                }
            }

        }
        #endregion
        #region regCheckBoxList_type_type_sub

        public static void FncDropDownListDownContinent(ref DropDownList scnCheckBoxList, string szValueContinentSelected, string pDocLngId)
        {

            scnCheckBoxList.Items.Clear();
            string[] aListSelected = szValueContinentSelected.Split(',');
            string szSql = "select ContinentId as sValue, ContinentName as sText from `tmst_geo_continent` where `ContinetLngId`='" + pDocLngId + "' order by `ContinentName`";
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oSqlCmd = new MySqlCommand(szSql, oSqlCnn);
            DataTable oDt = new DataTable();
            MySqlDataAdapter oSqlDa = new MySqlDataAdapter(oSqlCmd);
            oSqlCnn.Open();

            oSqlDa.Fill(oDt);
            cls.bbdd.ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            oSqlCmd.Dispose();
            //oChkLst.Items.Add(new ListItem(szText, szValue, true));
            string szText = "";
            string szValue = "";
            bool bChecked = false;
            foreach (DataRow oRow in oDt.Rows)
            {
                szText = oRow["sText"].ToString().Trim();
                szValue = oRow["sValue"].ToString().Trim();
                bChecked = false;
                for (int n = 0; n < aListSelected.Length; n++)
                {
                    string szSelected = aListSelected[n].Trim().ToLower();
                    foreach (ListItem oItem in scnCheckBoxList.Items)
                    {
                        if (szValue.ToLower() == szSelected)
                        {
                            bChecked = true;
                            n = aListSelected.Length + 1;
                        }



                    }
                    scnCheckBoxList.Items.Add(new ListItem(szText, szValue, true));
                    try
                    {
                        scnCheckBoxList.Items[n].Selected = bChecked;
                    }
                    catch {; }
                }

            }
            oSqlDa.Dispose();
            oDt.Dispose();
        }
        public static string FncGetContinentNamesFromCodes(string pContinentCodes, string pDocLngId)
        {
            string szId = "";
            string szReturn = "";
            string szComa = "";
            string[] aCodes = pContinentCodes.Split(',');
            cls.bbdd.ClsReg_tmst_geo_continent oRegContinent = new testudines.cls.bbdd.ClsReg_tmst_geo_continent();
            for (int i = 0; i < aCodes.Length; i++)
            {
                szId = aCodes[i].Trim().ToLower();

                if (oRegContinent.FncSqlFind(szId, pDocLngId))
                {
                    szReturn += szComa + oRegContinent.ContinentName;
                    szComa += ", ";
                }
            }

            return szReturn;
        }
        public static void FncCheckBox_ReferenceTypeSubFill(ref CheckBoxList scnCheckBoxList, string szReferenceTypeSubSelected)
        {
            scnCheckBoxList.Items.Clear();

            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetype_people, ClsGlobal.E_ReferenceType.people.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_breader, ClsGlobal.E_ReferenceTypeSub.breader.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_cientific, ClsGlobal.E_ReferenceTypeSub.cientific.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_conservationgroup, ClsGlobal.E_ReferenceTypeSub.conservationGroup.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_education, ClsGlobal.E_ReferenceTypeSub.education.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_goverment, ClsGlobal.E_ReferenceTypeSub.goverment.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_zoo, ClsGlobal.E_ReferenceTypeSub.zoo.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.referencetypesub_other, ClsGlobal.E_ReferenceTypeSub.other.ToString()));

            if (szReferenceTypeSubSelected.Trim() == "")
            {
                scnCheckBoxList.ClearSelection();
            }
            else
            {
                // poner la marca de seleccionados en los elementos del checkboxlist
                string[] aListSelected = szReferenceTypeSubSelected.Split(',');
                for (int n = 0; n < aListSelected.Length; n++)
                {
                    string szSelected = aListSelected[n].Trim().ToLower();
                    foreach (ListItem oItem in scnCheckBoxList.Items)
                    {
                        if (oItem.Value.Trim().ToLower() == szSelected)
                        {
                            oItem.Selected = true;
                        }
                    }
                }

            }
        }
        public static void FncDropDownList_scnATaxLevel(ref DropDownList scnDropDownList, string szE_ReferenceTypeSelected)
        {
            scnDropDownList.Items.Clear();
            if (szE_ReferenceTypeSelected == ClsGlobal.E_TaxonType.noselect.ToString() | szE_ReferenceTypeSelected == "")
            {
                szE_ReferenceTypeSelected = "*";
            }


            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_class_, ClsGlobal.E_TaxonType.class_.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_family, ClsGlobal.E_TaxonType.family.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_subfamily, ClsGlobal.E_TaxonType.subfamily.ToString()));

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_genus, ClsGlobal.E_TaxonType.genus.ToString()));

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_order, ClsGlobal.E_TaxonType.order.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_specie, ClsGlobal.E_TaxonType.specie.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_subclass, ClsGlobal.E_TaxonType.subclass.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_suborder, ClsGlobal.E_TaxonType.suborder.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_superfamily, ClsGlobal.E_TaxonType.superfamily.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_noselect, ClsGlobal.E_TaxonType.noselect.ToString()));
            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_ReferenceType)))
            {
                if (str == szE_ReferenceTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

            }


            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString())
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                        return;
                    }

            }
        }

        //////////////////////////////////////
        public static void FncDropDownList_ReferenceTypeFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSelected)
        {
            scnDropDownList.Items.Clear();
            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString())
            {
                szE_ReferenceTypeSelected = "*";
            }


            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_people, ClsGlobal.E_ReferenceType.people.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_veterinary, ClsGlobal.E_ReferenceType.veterinary.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_agrupation, ClsGlobal.E_ReferenceType.agrupation.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_institution, ClsGlobal.E_ReferenceType.institution.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_publication, ClsGlobal.E_ReferenceType.publication.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_mutimedia, ClsGlobal.E_ReferenceType.multimedia.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_website, ClsGlobal.E_ReferenceType.website.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetype_other, ClsGlobal.E_ReferenceType.other.ToString()));
            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_ReferenceType)))
            {
                if (str == szE_ReferenceTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

            }


            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString())
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncDropDownList_ReferenceTypeSubFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSubSelected)
        {
            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ReferenceType.noselect.ToString().ToLower())
            {
                szE_ReferenceTypeSubSelected = "*";
            }
            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_breader, ClsGlobal.E_ReferenceTypeSub.breader.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_cientific, ClsGlobal.E_ReferenceTypeSub.cientific.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_conservationgroup, ClsGlobal.E_ReferenceTypeSub.conservationGroup.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_education, ClsGlobal.E_ReferenceTypeSub.education.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_goverment, ClsGlobal.E_ReferenceTypeSub.goverment.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_zoo, ClsGlobal.E_ReferenceTypeSub.zoo.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.referencetypesub_other, ClsGlobal.E_ReferenceTypeSub.other.ToString()));
            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_ReferenceTypeSub)))
            {
                if (str == szE_ReferenceTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSubSelected, szE_ReferenceTypeSubSelected));

            }


            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString())
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSubSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncDropDownList_FoodTypeFill(ref DropDownList scnDropDownList, string szeFoodsTypeSelected)
        {
            if (szeFoodsTypeSelected == "" || szeFoodsTypeSelected == ClsGlobal.E_ArticleType.noselect.ToString().ToLower())
            {
                szeFoodsTypeSelected = "*";
            }
            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_animal, ClsGlobal.E_FoodType.animal.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_vegetable, ClsGlobal.E_FoodType.vegetable.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_manufactured, ClsGlobal.E_FoodType.manufactured.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_supplements, ClsGlobal.E_FoodType.supplements.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_medicines, ClsGlobal.E_FoodType.medicines.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodType_other, ClsGlobal.E_FoodType.other.ToString()));

            scnDropDownList.Items.Add(new ListItem("*", "*"));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            if (szeFoodsTypeSelected != "*")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_FoodType)))
                {
                    if (str == szeFoodsTypeSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnDropDownList.Items.Add(new ListItem(szeFoodsTypeSelected, szeFoodsTypeSelected));

                }
            }
            // selecccionar el pasado como seleccionado

            foreach (ListItem oItem in scnDropDownList.Items)
                if (oItem.Value.Trim().ToLower() == szeFoodsTypeSelected.Trim().ToLower())
                {
                    oItem.Selected = true;
                }




        }
        public static void FncDropDownList_FoodTypeSubFill(ref DropDownList scnDropDownList, string szeFoodsTypeSubSelected)
        {
            if (szeFoodsTypeSubSelected == "" || szeFoodsTypeSubSelected == ClsGlobal.E_ArticleTypeSub.noselect.ToString().ToLower())
            {
                szeFoodsTypeSubSelected = "*";
            }
            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_very_good, ClsGlobal.E_FoodTypeSub.very_good.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_good, ClsGlobal.E_FoodTypeSub.good.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_very_occasionally, ClsGlobal.E_FoodTypeSub.occasionally.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_bad, ClsGlobal.E_FoodTypeSub.bad.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_prohibited, ClsGlobal.E_FoodTypeSub.prohibited.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_other, ClsGlobal.E_FoodTypeSub.other.ToString()));

            //scnDropDownList.Items.Add(new ListItem(Resources.combos.E_FoodTypeSub_very_good, ClsGlobal.E_FoodTypeSub.noselect.ToString()));
            scnDropDownList.Items.Add(new ListItem("*", "*"));
            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================

            bool bExit = false;
            if (szeFoodsTypeSubSelected != "*")
            {
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_FoodTypeSub)))
                {
                    if (str == szeFoodsTypeSubSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnDropDownList.Items.Add(new ListItem(szeFoodsTypeSubSelected, szeFoodsTypeSubSelected));

                }
            }
            //________________________
            // selecccionar el pasado como seleccionado

            foreach (ListItem oItem in scnDropDownList.Items)
                if (oItem.Value.Trim().ToLower() == szeFoodsTypeSubSelected.Trim().ToLower())
                {
                    oItem.Selected = true;
                }


        }

        public static void FncDropDownList_ArticleTypeFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSelected)
        {
            szE_ReferenceTypeSelected = szE_ReferenceTypeSelected.Trim();
            if (szE_ReferenceTypeSelected == "" || szE_ReferenceTypeSelected == ClsGlobal.E_ArticleType.noselect.ToString().ToLower())
            {
                szE_ReferenceTypeSelected = "*";
            }
            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_caresheet, ClsGlobal.E_ArticleType.caresheet.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_conservancy_project, ClsGlobal.E_ArticleType.conservancy_project.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_biology, ClsGlobal.E_ArticleType.biology.ToString()));
            //scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_foods, ClsGlobal.E_ArticleType.foods.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_diseases, ClsGlobal.E_ArticleType.diseases.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_other, ClsGlobal.E_ArticleType.other.ToString()));
            //scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_people, ClsGlobal.E_ArticleType.people.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleType_art_society, ClsGlobal.E_ArticleType.art_society.ToString()));
            scnDropDownList.Items.Add(new ListItem("*", "*"));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            if (szE_ReferenceTypeSelected != "*")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_ArticleType)))
                {
                    if (str == szE_ReferenceTypeSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

                }
            }
            // selecccionar el pasado como seleccionado
            if (szE_ReferenceTypeSelected.Trim().ToLower() == ClsGlobal.E_ReferenceType.noselect.ToString().ToLower())
            {
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }



        }
        public static void FncDropDownList_taxons_groupsTypeFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSubSelected)
        {
            scnDropDownList.Items.Clear();
            scnDropDownList.Items.Add(new ListItem("taxonsgroups", "taxonsgroups", true));
        }
        public static void FncDropDownList_taxons_groupsTypeSubFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSubSelected)
        {
            scnDropDownList.Items.Clear();
            scnDropDownList.Items.Add(new ListItem("taxonsgroups", "taxonsgroups", true));

        }
        public static void FncDropDownList_ArticleTypeSubFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSubSelected)
        {
            szE_ReferenceTypeSubSelected = szE_ReferenceTypeSubSelected.Trim();
            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ArticleTypeSub.noselect.ToString().ToLower())
            {
                szE_ReferenceTypeSubSelected = "*";
            }
            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_basic, ClsGlobal.E_ArticleTypeSub.basic.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_expert, ClsGlobal.E_ArticleTypeSub.expert.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_hightrecomendable, ClsGlobal.E_ArticleTypeSub.highrecomendable.ToString()));
            scnDropDownList.Items.Add(new ListItem("*", "*"));
            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            if (szE_ReferenceTypeSubSelected != "*")
            {

                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_ArticleTypeSub)))
                {
                    if (str == szE_ReferenceTypeSubSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSubSelected, szE_ReferenceTypeSubSelected));

                }
            }
            //________________________
            // selecccionar el pasado como seleccionado

            foreach (ListItem oItem in scnDropDownList.Items)
                if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSubSelected.Trim().ToLower())
                {
                    oItem.Selected = true;
                }


        }

        public static void FncDropDownList_AppendixTypeFill(ref DropDownList scnDropDownList, string szeAppendixTypeSelected)
        {

            scnDropDownList.Items.Clear();
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesType_botanic, ClsGlobal.E_AppendixesType.botanic.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesType_ecology, ClsGlobal.E_AppendixesType.ecology.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesType_zoology, ClsGlobal.E_AppendixesType.zoology.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesType_other, ClsGlobal.E_AppendixesType.other.ToString()));
            //  scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesType_noselect, ClsGlobal.E_AppendixesType.noselect.ToString()));
            //  scnDropDownList.Items.Add(new ListItem("*","*"));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_AppendixesType)))
            {
                if (str == szeAppendixTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szeAppendixTypeSelected, szeAppendixTypeSelected));

            }
            // selecccionar el pasado como seleccionado
            if (szeAppendixTypeSelected.Trim().ToLower() == ClsGlobal.E_AppendixesType.noselect.ToString().ToLower())
            {
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szeAppendixTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }



        }
        public static void FncDropDownList_AppendixTypeSubFill(ref DropDownList scnDropDownList, string szeAppendixTypeSubSelected)
        {

            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesTypeSub_anathomy, ClsGlobal.E_AppendixesTypeSub.anathomy.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesTypeSub_ethimology, ClsGlobal.E_AppendixesTypeSub.ethimology.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesTypeSub_chemist, ClsGlobal.E_AppendixesTypeSub.chemist.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesTypeSub_other, ClsGlobal.E_AppendixesTypeSub.other.ToString()));
            //scnDropDownList.Items.Add(new ListItem(Resources.combos.E_AppendixesTypeSub_zoology, ClsGlobal.E_AppendixesTypeSub.noselect.ToString()));
            // scnDropDownList.Items.Add(new ListItem("*", "*"));

            // scnAppendixMediaType.Items.Add(new ListItem(Resources.combos.Appendixmediatype_other, ClsGlobal.eAppendixMediaType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_AppendixesTypeSub)))
            {
                if (str == szeAppendixTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szeAppendixTypeSubSelected, szeAppendixTypeSubSelected));

            }

            //________________________
            // selecccionar el pasado como seleccionado
            if (szeAppendixTypeSubSelected.Trim().ToLower() == ClsGlobal.E_AppendixesType.noselect.ToString().ToLower())
            {
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szeAppendixTypeSubSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }




        public static void FncRadiobuton_ArticleTypeFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSelected)
        {

            scnRadioButtonList.Items.Clear();

            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_caresheet, ClsGlobal.E_ArticleType.caresheet.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_conservancy_project, ClsGlobal.E_ArticleType.conservancy_project.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_biology, ClsGlobal.E_ArticleType.biology.ToString()));
            //scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_foods, ClsGlobal.E_ArticleType.foods.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_diseases, ClsGlobal.E_ArticleType.diseases.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_other, ClsGlobal.E_ArticleType.other.ToString()));
            //scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_people, ClsGlobal.E_ArticleType.people.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_art_society, ClsGlobal.E_ArticleType.art_society.ToString()));

            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleType_art_society, ClsGlobal.E_ArticleType.art_society.ToString()));

            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString())
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                foreach (ListItem oItem in scnRadioButtonList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncRadiobuton_ArticleTypeSubFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSubSelected)
        {

            scnRadioButtonList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_basic, ClsGlobal.E_ArticleTypeSub.basic.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_expert, ClsGlobal.E_ArticleTypeSub.expert.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_hightrecomendable, ClsGlobal.E_ArticleTypeSub.highrecomendable.ToString()));

            // scnReferenceMediaType.Items.Add(new ListItem(Resources.combos.referencemediatype_other, ClsGlobal.eReferenceMediaType.noselect.ToString()));

            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString())
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                RadioButtonList oRblItem = (RadioButtonList)scnRadioButtonList.FindControl(szE_ReferenceTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_ReferenceTypeSubSelected;
                }
            }
        }
        public static void FncCheckBox_ArticleTypeSubFill(ref CheckBoxList scnCheckBoxList, string szReferenceTypeSubSelected)
        {
            scnCheckBoxList.Items.Clear();

            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_basic, ClsGlobal.E_ArticleTypeSub.basic.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_expert, ClsGlobal.E_ArticleTypeSub.expert.ToString()));
            scnCheckBoxList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_hightrecomendable, ClsGlobal.E_ArticleTypeSub.highrecomendable.ToString()));

            if (szReferenceTypeSubSelected.Trim() == "")
            {
                scnCheckBoxList.ClearSelection();
            }
            else
            {
                // poner la marca de seleccionados en los elementos del checkboxlist
                string[] aListSelected = szReferenceTypeSubSelected.Split(',');
                for (int n = 0; n < aListSelected.Length; n++)
                {
                    string szSelected = aListSelected[n].Trim().ToLower();
                    foreach (ListItem oItem in scnCheckBoxList.Items)
                    {
                        if (oItem.Value.Trim().ToLower() == szSelected)
                        {
                            oItem.Selected = true;
                        }
                    }
                }

            }
        }
        public static void FncDropDownList_EcozoneTypeFill(ref DropDownList scnDropDownList, string szE_EcozoneTypeSelected)
        {

            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_EcozoneType_description.ToLower().Trim(), ClsGlobal.E_EcozoneType.description.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_EcozoneType)))
            {
                if (str.Trim().ToLower() == szE_EcozoneTypeSelected.Trim().ToLower()) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_EcozoneTypeSelected, szE_EcozoneTypeSelected));

            }
            //==================================================================



            if (szE_EcozoneTypeSelected == ClsGlobal.E_EcozoneType.noselect.ToString())
            {
                scnDropDownList.ClearSelection();

            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_EcozoneTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncDropDownList_EcozoneTypeSubFill(ref DropDownList scnDropDownList, string szE_EcozoneTypeSubSelected)
        {

            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_EcozoneTypesub_ecozone.ToLower().Trim(), ClsGlobal.E_EcozoneTypeSub.ecozone.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_EcozoneTypeSub)))
            {
                if (str == szE_EcozoneTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_EcozoneTypeSubSelected, szE_EcozoneTypeSubSelected));

            }
            //==================================================================



            if (szE_EcozoneTypeSubSelected == ClsGlobal.E_EcozoneTypeSub.noselect.ToString())
            {
                scnDropDownList.ClearSelection();
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_EcozoneTypeSubSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncDropDownList_OtherTypeFill(ref DropDownList scnDropDownList, string szeNotizeTypeSelected)
        {
            if (szeNotizeTypeSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString())
            {
                szeNotizeTypeSelected = "*";
            }
            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_conservancy_project, ClsGlobal.E_NoticeType.conservancy_project.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_society, ClsGlobal.E_NoticeType.society.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_law, ClsGlobal.E_NoticeType.law.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_other, ClsGlobal.E_NoticeType.other.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_NoticeType)))
            {
                if (str == szeNotizeTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szeNotizeTypeSelected, szeNotizeTypeSelected));

            }
            //==================================================================



            if (szeNotizeTypeSelected == "*")
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szeNotizeTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }

        public static void FncDropDownList_OtherTypeSubFill(ref DropDownList scnDropDownList, string szE_OtherTypeSubSelected)
        {

            if (szE_OtherTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString())
            {
                szE_OtherTypeSubSelected = "*";
            }

            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_basic, ClsGlobal.E_OtherTypeSub.basic.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_expert, ClsGlobal.E_OtherTypeSub.expert.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_hightrecomendable, ClsGlobal.E_OtherTypeSub.highrecomendable.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_other, ClsGlobal.E_OtherTypeSub.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_OtherTypeSub)))
            {
                if (str == szE_OtherTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_OtherTypeSubSelected, szE_OtherTypeSubSelected));

            }
            //==================================================================


            if (szE_OtherTypeSubSelected == "*")
            {
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                DropDownList oRblItem = (DropDownList)scnDropDownList.FindControl(szE_OtherTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_OtherTypeSubSelected;
                }
            }
        }
        public static void FncDropDownList_NoticeTypeFill(ref DropDownList scnDropDownList, string szE_TodoTypeSelected)
        {
            if (szE_TodoTypeSelected == ClsGlobal.E_TodoType.noselect.ToString()) szE_TodoTypeSelected = "*";
            if (szE_TodoTypeSelected == "") szE_TodoTypeSelected = "*";
            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_conservancy_project, ClsGlobal.E_NoticeType.conservancy_project.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_law, ClsGlobal.E_NoticeType.law.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_specie, ClsGlobal.E_NoticeType.specie.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_society, ClsGlobal.E_NoticeType.society.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_other, ClsGlobal.E_NoticeType.other.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_NoticeType_nolect, ClsGlobal.E_NoticeType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_NoticeType)))
            {
                if (str == szE_TodoTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_TodoTypeSelected, szE_TodoTypeSelected));

            }
            //==================================================================



            if (szE_TodoTypeSelected == "*")
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_TodoTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }



        public static void FncDropDownList_NoticeTypeSubFill(ref DropDownList scnDropDownList, string szE_NoticeTypeSubSelected)
        {

            if (szE_NoticeTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString())
            {
                szE_NoticeTypeSubSelected = "*";
            }

            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_basic, ClsGlobal.E_NoticeTypeSub.basic.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_expert, ClsGlobal.E_NoticeTypeSub.expert.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_hightrecomendable, ClsGlobal.E_NoticeTypeSub.highrecomendable.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_ArticleTypesub_other, ClsGlobal.E_NoticeTypeSub.other.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_NoticeTypeSub)))
            {
                if (str == szE_NoticeTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_NoticeTypeSubSelected, szE_NoticeTypeSubSelected));

            }
            //==================================================================


            if (szE_NoticeTypeSubSelected == "*")
            {
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                DropDownList oRblItem = (DropDownList)scnDropDownList.FindControl(szE_NoticeTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_NoticeTypeSubSelected;
                }
            }
        }
        public static void FncDropDownList_TodoTypeFill(ref DropDownList scnDropDownList, string szE_TodoTypeSelected)
        {
            if (szE_TodoTypeSelected == ClsGlobal.E_TodoType.noselect.ToString()) szE_TodoTypeSelected = "*";
            if (szE_TodoTypeSelected == "") szE_TodoTypeSelected = "*";
            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoType_waiting, ClsGlobal.E_TodoType.waiting.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoType_doing, ClsGlobal.E_TodoType.doing.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoType_done, ClsGlobal.E_TodoType.done.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoType_cancel, ClsGlobal.E_TodoType.cancel.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoType_noselect, ClsGlobal.E_TodoType.noselect.ToString()));

            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TodoType)))
            {
                if (str == szE_TodoTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_TodoTypeSelected, szE_TodoTypeSelected));

            }
            //==================================================================



            if (szE_TodoTypeSelected == "*")
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                foreach (ListItem oItem in scnDropDownList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_TodoTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }



        public static void FncDropDownList_TodoTypeSubFill(ref DropDownList scnDropDownList, string szE_TodoTypeSubSelected)
        {
            if (szE_TodoTypeSubSelected == "") szE_TodoTypeSubSelected = "*";
            if (szE_TodoTypeSubSelected == ClsGlobal.E_TodoType.noselect.ToString()) szE_TodoTypeSubSelected = "*";

            scnDropDownList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoTypesub_hight, ClsGlobal.E_TodoTypeSub.hight.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoTypesub_medium, ClsGlobal.E_TodoTypeSub.medium.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoTypesub_low, ClsGlobal.E_TodoTypeSub.low.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoTypesub_nothing, ClsGlobal.E_TodoTypeSub.nothing.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TodoTypesub_noselect, ClsGlobal.E_TodoTypeSub.noselect.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TodoTypeSub)))
            {
                if (str == szE_TodoTypeSubSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_TodoTypeSubSelected, szE_TodoTypeSubSelected));

            }
            //==================================================================


            if (szE_TodoTypeSubSelected == "*")
            {
                scnDropDownList.ClearSelection();
                scnDropDownList.SelectedValue = "*";
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                DropDownList oRblItem = (DropDownList)scnDropDownList.FindControl(szE_TodoTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_TodoTypeSubSelected;
                }
            }
        }
        public static void FncRadiobuton_AgreetmentTypeFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSelected)
        {

            scnRadioButtonList.Items.Clear();
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAgreetment_people, ClsGlobal.E_AgreetmentType.people.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAgreetment_organitatiton, ClsGlobal.E_AgreetmentType.organitatiton.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAgreetment_other, ClsGlobal.E_AgreetmentType.other.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAgreetment_noselect, ClsGlobal.E_AgreetmentType.noselect.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================

            if (szE_ReferenceTypeSelected != "")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TodoType)))
                {
                    if (str == szE_ReferenceTypeSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnRadioButtonList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

                }
            }
            //==================================================================



            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString() || szE_ReferenceTypeSelected == "")
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                foreach (ListItem oItem in scnRadioButtonList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncRadiobuton_AgreetmentTypeSubFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSubSelected)
        {

            scnRadioButtonList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAcknowledgementsub_articles, ClsGlobal.E_AgreetmentTypeSub.articles.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAcknowledgementsub_pictures, ClsGlobal.E_AgreetmentTypeSub.pictures.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAcknowledgementsub_both, ClsGlobal.E_AgreetmentTypeSub.both.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAcknowledgementsub_other, ClsGlobal.E_AgreetmentTypeSub.other.ToString()));
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.eAcknowledgementsub_noselect, ClsGlobal.E_AgreetmentTypeSub.noselect.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================

            if (szE_ReferenceTypeSubSelected != "")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TodoTypeSub)))
                {
                    if (str == szE_ReferenceTypeSubSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnRadioButtonList.Items.Add(new ListItem(szE_ReferenceTypeSubSelected, szE_ReferenceTypeSubSelected));

                }
            }
            //==================================================================


            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString() || szE_ReferenceTypeSubSelected == "")
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                RadioButtonList oRblItem = (RadioButtonList)scnRadioButtonList.FindControl(szE_ReferenceTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_ReferenceTypeSubSelected;
                }
            }
        }
        public static void FncRadiobuton_MediaGalTypeFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSelected)
        {

            scnRadioButtonList.Items.Clear();
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_MediaGalType_Gallery, ClsGlobal.E_MediaGalType.media.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================

            if (szE_ReferenceTypeSelected != "")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_MediaGalType)))
                {
                    if (str == szE_ReferenceTypeSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnRadioButtonList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

                }
            }
            //==================================================================



            if (szE_ReferenceTypeSelected == ClsGlobal.E_ReferenceType.noselect.ToString() || szE_ReferenceTypeSelected == "")
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                foreach (ListItem oItem in scnRadioButtonList.Items)
                    if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                    {
                        oItem.Selected = true;
                    }

            }
        }
        public static void FncRadiobuton_MediaGalTypeSubFill(ref RadioButtonList scnRadioButtonList, string szE_ReferenceTypeSubSelected)
        {

            scnRadioButtonList.Items.Clear();
            // breader, education, cientific, zoo, conservationGroup, goverment, other,  noselect 
            scnRadioButtonList.Items.Add(new ListItem(Resources.combos.E_MediaGalTypeSub_files, ClsGlobal.E_MediaGalTypeSub.images.ToString()));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================

            if (szE_ReferenceTypeSubSelected != "")
            {
                bool bExit = false;
                foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_MediaGalTypeSub)))
                {
                    if (str == szE_ReferenceTypeSubSelected) bExit = true;
                }
                if (!bExit)
                {
                    scnRadioButtonList.Items.Add(new ListItem(szE_ReferenceTypeSubSelected, szE_ReferenceTypeSubSelected));

                }
            }
            //==================================================================


            if (szE_ReferenceTypeSubSelected == ClsGlobal.E_ReferenceTypeSub.noselect.ToString() || szE_ReferenceTypeSubSelected == "")
            {
                scnRadioButtonList.ClearSelection();
            }
            else
            {
                //RadioButtonList oRbl = (RadioButtonList)scnReferenceMediaType.FindControl(eMediaType.ToString());
                RadioButtonList oRblItem = (RadioButtonList)scnRadioButtonList.FindControl(szE_ReferenceTypeSubSelected);
                if (oRblItem != null)
                {
                    oRblItem.SelectedValue = szE_ReferenceTypeSubSelected;
                }
            }
        }
        public static void FncDropDownList_TaxonTypeFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSelected)
        {

            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_class_.ToLower().Trim(), ClsGlobal.E_TaxonType.class_.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_subclass.ToLower().Trim(), ClsGlobal.E_TaxonType.subclass.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_order.ToLower().Trim(), ClsGlobal.E_TaxonType.order.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_suborder.ToLower().Trim(), ClsGlobal.E_TaxonType.suborder.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_superfamily.ToLower().Trim(), ClsGlobal.E_TaxonType.superfamily.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_family.ToLower().Trim(), ClsGlobal.E_TaxonType.family.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_genus.ToLower().Trim(), ClsGlobal.E_TaxonType.genus.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonType_specie.ToLower().Trim(), ClsGlobal.E_TaxonType.specie.ToString()));
            // scnDropDownList.Items.Add(new ListItem("*", "*"));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TaxonType)))
            {
                if (str.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower()) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

            }
            //==================================================================




            foreach (ListItem oItem in scnDropDownList.Items)
                if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                {
                    oItem.Selected = true;
                }


        }
        public static void FncDropDownList_TaxonTypeSubFill(ref DropDownList scnDropDownList, string szE_ReferenceTypeSelected)
        {
            //  //public enum E_TaxonTypeSub { live, extinct_wild, extinct, extinct_fossil, error, noselect }

            scnDropDownList.Items.Clear();

            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonTypeSub_live.ToLower().Trim(), ClsGlobal.E_TaxonTypeSub.live.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonTypeSub_extinct_wild.ToLower().Trim(), ClsGlobal.E_TaxonTypeSub.extinct_wild.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonTypeSub_extinct.ToLower().Trim(), ClsGlobal.E_TaxonTypeSub.extinct.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonTypeSub_extinct_fossil.ToLower().Trim(), ClsGlobal.E_TaxonTypeSub.extinct_fossil.ToString()));
            scnDropDownList.Items.Add(new ListItem(Resources.combos.E_TaxonTypeSub_error.ToLower().Trim(), ClsGlobal.E_TaxonTypeSub.error.ToString()));
            //scnDropDownList.Items.Add(new ListItem("*", "*"));


            //==================================================================
            // por si las moscas
            // si pasan valor que ya no esta en la lista enumerada,  lo añadimos 
            //==================================================================
            bool bExit = false;
            foreach (string str in Enum.GetNames(typeof(ClsGlobal.E_TaxonTypeSub)))
            {
                if (str == szE_ReferenceTypeSelected) bExit = true;
            }
            if (!bExit)
            {
                scnDropDownList.Items.Add(new ListItem(szE_ReferenceTypeSelected, szE_ReferenceTypeSelected));

            }
            //==================================================================




            foreach (ListItem oItem in scnDropDownList.Items)
                if (oItem.Value.Trim().ToLower() == szE_ReferenceTypeSelected.Trim().ToLower())
                {
                    oItem.Selected = true;
                }


        }





        #endregion
        ////==================================================================
        ///// <summary>
        ///// Devuleve si una cadena se encuentra en un enumerado
        ///// </summary>
        ///// <param name="szValue"></param>
        ///// <param name="myEnum"></param>
        ///// <returns></returns>
        //public static bool FncEnumExistName(string szValue,  Enum myEnum)
        //{

        //    foreach (string val in Enum.GetNames(typeof(myEnum)))
        //    {
        //        if (szValue == val) return true;
        //    }
        //    return false;
        //}
        //==================================================================
        public static bool FncIsMailOk(string szMail)
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(szMail, expresion))
            {
                if (Regex.Replace(szMail, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static string FncUrlClearProtocol(string szUrl)
        {
            string sz = szUrl.Trim().ToLower();
            // limpiar protocolo
            sz = sz.Replace("http://", "");
            sz = sz.Replace("https://", "");
            sz = sz.Replace("ftp://", "");
            return sz;
        }
        /// <summary>
        /// Html format mesage with message boxs template
        /// </summary>
        /// <param name="pMmsg">Mesasage to show</param>
        /// <param name="ClsGlobal_E_MsgType"> E_MsgType: alert,success,  warning </param>
        /// <returns>return html div section for message</returns>
   
        public static bool FncUrlExist(string szUrl, ref string xcptMessage)
        {
            System.Threading.Thread.Sleep(2000);
            try
            {

                WebRequest httpReq = WebRequest.Create(szUrl);
                using (HttpWebResponse response = (HttpWebResponse)httpReq.GetResponse())
                {
                    if (response != null)
                        return true;
                }

                return false;
            }
            catch (UriFormatException)
            {
                return false;
            }
            catch (Exception xcpt)
            {

                xcptMessage = xcpt.Message;
                return false;
            }

        }
        
            public static bool IsMail(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress  m = new System.Net.Mail.MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool  IsUrl(String pUrl)
        {
            return Uri.IsWellFormedUriString(pUrl, UriKind.RelativeOrAbsolute);
        }
        public static bool FncUrlIsOk(string szUrl)
        {

            System.Globalization.CompareInfo cmpUrl = System.Globalization.CultureInfo.InvariantCulture.CompareInfo;
            if (cmpUrl.IsPrefix(szUrl, "http://") == false)
            {
                szUrl = "http://" + szUrl;
            }

            try
            {
                Uri myUri = new Uri(szUrl);
                Regex RgxUrl = new Regex("(([a-zA-Z][0-9a-zA-Z+\\-\\.]*:)?/{0,2}[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?(#[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?");
                if (RgxUrl.IsMatch(szUrl))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }








        public static bool FncPathFileExist(String FileFullPath)
        {
            if (System.IO.File.Exists(FileFullPath)) { return true; }
            return false;

        }
   

        public static String FncGalleryMP_AddImages_3(ref String imgMin_1, ref String imgMin_2, ref String imgMin_3, ref String title)
        {
            /*
             <div class="popup-images" style="text-align:center; width:100%;">
                 <a href="/a_test/img/img_001_Med.jpg" title="The Cleaner"><img src="/a_test/img/img_001_Min.jpg" class="thumbnail float-center "></a>
                 <a href="/a_test/img/img_002_Med.jpg" title="Winter Dance"><img src="/a_test/img/img_002_Min.jpg" class="thumbnail float-center"></a>
                 <a href="/a_test/img/img_003_Med.jpg" title="The Uninvited Guest"><img src="/a_test/img/img_003_Min.jpg" class="thumbnail  float-center"></a>
                </div>
              */

            String szReturn = "\n <div class=\"popup-images\">";
            String szImgBig = "";
            String szTitle = "";
            imgMin_1 = imgMin_1.ToLower();
            imgMin_2 = imgMin_2.ToLower();
            imgMin_3 = imgMin_3.ToLower();
            szImgBig = imgMin_1.Replace("_min.", "_med.");
            szTitle = title + " 1";
            szReturn += FncGalleryMP_AddImage(ref imgMin_1, ref szImgBig, ref title);

            szImgBig = imgMin_2.Replace("_min.", "_med.");
            szTitle = title + " 2";
            szReturn += FncGalleryMP_AddImage(ref imgMin_2, ref szImgBig, ref title);

            szImgBig = imgMin_3.Replace("_min.", "_med.");
            szTitle = title + " 3";
            szReturn += FncGalleryMP_AddImage(ref imgMin_2, ref szImgBig, ref title);

            szReturn += "\n</div>\n";
            return szReturn;
        }
        public static String FncGalleryMP_AddImage(ref String pImgThb, ref String pImgBig, ref String pText)
        {
            String szReturn = "\n<a href=\"#imgBig#\" title=\"#Text#\"><img src=\"#imgThb#\" class=\"thumbnail float-center\"></a>";
            szReturn = szReturn.Replace("#imgThb#", pImgThb);
            szReturn = szReturn.Replace("#imgBig#", pImgBig);
            szReturn = szReturn.Replace("#Text#", pText);
            return szReturn;
        }
       

        private static bool FncUsrLogged()
        {
            bool b = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            return b;
        }
        private static String FncUsrId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
        private static bool FncUserIsAdmin()
        {

            if (FncUsrId() == "vniclos") return true;
            return false;
        }

    }
}