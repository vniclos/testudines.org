using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace testudines.cls.cache
{
    /// <summary>
    /// ATENCION! no llamar  SOLO PARA LEER CACHE. NO lo recrea si no existe.
    /// si se desa recrear llamar a  cls.cache.ClsCache_Tortoise 
    /// </summary>
    public class ClsCache_Reg_tdoclng_testudines
    {
        public bool FncCacheFileDelete(String szFilePath)
        {
            try
            {
                System.IO.File.Delete(szFilePath);
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// Delete taxon cache with same id document
        /// </summary>
        /// <param name="pDocId">Id Document</param>
        /// <returns>False if can't delete any doument (Cratch with other thread)  </returns>
        /// 
        public bool FncCacheFileDeleteDocument(Int64 pDocId)
        {
            bool bOk = true;
            string szStart="*_"+ pDocId.ToString() + "_*" ;
            foreach (string oFile in Directory.GetFiles(ClsGlobal.DirCacheTortoises, szStart))
            {


                try
                {
                    System.IO.File.Delete(oFile);
                }
                catch
                {
                    bOk = false;
                }

            } 
               

            
            return bOk;
        }
        /// <summary>
        /// delete chache of one section of document by ID,LNG and desction
        /// </summary>
        /// <param name="pDocId">Id Document</param>
        /// <param name="pDocLngId">Language of document version</param>
        /// <param name="pSection">section of document</param>
        /// <returns></returns>
        public bool FncCacheFileDeleteSection(UInt64 pDocId, string pDocLngId, string pSection)
        { 
            string szNada="";
            string szFile=FncCacheFileGetFileNameIdPath(pDocId,pDocLngId,pSection, ref szNada);
            if (System.IO.File.Exists (szFile ))
            {
                try 
                {
                System.IO.File.Delete (szFile);
                    return true;
                }
                catch 
                {
                       return false;
                }
            }
            else
            {return true;}
        }
        public bool FncWriteCache(UInt64 pDocId, string pDocLngId, string pSection, string szHtml, bool pOverWrite)
        {
            bool bDeleted = false;
            string pShortFilename = "";
            string FileNameId = FncCacheFileGetFileNameIdPath(pDocId, pDocLngId, pSection, ref pShortFilename);
            if (pOverWrite)
            {
                // si se desea sobre escribir y no lo puede borrar
                // devuelve false;
               bDeleted= FncCacheFileDeleteSection(pDocId, pDocLngId, pSection);
               if (!bDeleted) return false;
            }
             
            // Write the string to a file.
            System.IO.StreamWriter oFile = new System.IO.StreamWriter(FileNameId);
            oFile.WriteLine(szHtml);
            oFile.Close();
        return true;
        }
        public bool FncWriteCache(ref  String szFilename, ref String szHtml)
        {
               bool bDeleted = FncCacheFileDelete(szFilename);
                if (!bDeleted) return false;
           
            // Write the string to a file.
            System.IO.StreamWriter oFile = new System.IO.StreamWriter(szFilename);
            oFile.WriteLine(szHtml);
            oFile.Flush();
            oFile.Close();
            return true;

        }
        public String FncReadCache(String pFilePath)
        {
            String szHtml = "";
            try
            {
                using (StreamReader sr = new StreamReader(pFilePath))
                {
                    szHtml = sr.ReadToEnd();

                }
            }
            catch (Exception xcpt)
            {
                szHtml = "";
                //szHtml = xcpt.Message ;
            }
            return szHtml;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pSection"></param>
        /// <returns></returns>
        public string FncReadCache(UInt64 pDocId, string pDocLngId, string pSection)
        {
            string pShortFilename = "";
            String szHtml = "";
            string FileNameId = FncCacheFileGetFileNameIdPath(pDocId,pDocLngId, pSection, ref pShortFilename);
          try
        {
            using (StreamReader sr = new StreamReader(FileNameId))
            {
                szHtml = sr.ReadToEnd();
               
            }
        }
        catch (Exception xcpt)
        {
            szHtml = "";
            //szHtml = xcpt.Message ;
        }
          return szHtml;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pSection"></param>
        /// <returns></returns>
        private string FncCacheFileGetFileNameIdPath(UInt64 pDocId, string pDocLngId, string pSection, ref String pShortFilename)
        {

            String FileNameId = ClsGlobal.DirCacheTortoises +  pDocLngId +"_"+ pDocId.ToString().PadLeft(9, '0') + "_" + pSection.ToLower() + ".html";
            return FileNameId;
        }
    }
    
    
}