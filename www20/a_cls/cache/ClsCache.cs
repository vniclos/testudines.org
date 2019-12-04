using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testudines.cls.cache
{
    public static class ClsCache
    {

        // ==========================================================================
        // ==========================================================================
        // ==========================================================================
        // 
        /// <summary>
        /// obtiene el path completo del fichero cache
        /// </summary>
        /// <param name="idDoc"></param>
        /// <param name="IdDocLng"></param>
        /// <param name="DocType">texto a agar al final del nombre del fichero</param>
        /// <param name="SubDir">Opional subdirectorio dentro del directorio cache</param>
        /// <returns>
        /// si idDoc=215, IdDocLng="es",  doctype="sumary" y subdir=taxon
        /// ejemplo: "d:\\_testudines\\wwwdev\\www\\a_cache\\taxon\\000000215_en_summary.html"
        /// </returns>
        public static string FncCacheFilePath(UInt64 idDoc, String IdDocLng, String DocType, String SubDir="")
        {
            String szFilePath = "";
             szFilePath = ClsGlobal.DirCache;
            if (SubDir != "")  {
                szFilePath = cls.ClsUtils.FncPathCombine( szFilePath ,  SubDir);
                if (!System.IO.Directory.Exists(szFilePath)) { System.IO.Directory.CreateDirectory(szFilePath); }
            }
            String szFilename= idDoc.ToString().PadLeft(9, '0') + "_" + IdDocLng.ToLower() + "_" + DocType.ToLower() + ".html";
            szFilePath = cls.ClsUtils.FncPathCombine(szFilePath, szFilename);

           
            return szFilePath;
        }
     
        public static bool FncCacheFileDelete(string szFilePath)
        {
            if (System.IO.File.Exists(szFilePath))
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
            else
            {
                return true;
            }
        }
        public static bool FncCacheFileDelete(UInt64 idDoc, String IdDocLng, String DocType)
        {

            String szFilePath = FncCacheFilePath(idDoc, IdDocLng, DocType.ToLower());
            return FncCacheFileDelete(szFilePath);

        }
        public static bool FncCacheFilePathExist(String szPath)
        {
            return System.IO.File.Exists(szPath);
        }
        public static bool FncCacheFilePathExist(UInt64 idDoc, String IdDocLng, String DocType)
        {
            String szFilePath = FncCacheFilePath(idDoc, IdDocLng, DocType.ToLower());
            if (System.IO.File.Exists(szFilePath))
            { return true; }
            else
            {
                return false;
            }

        }
        public static String FncCacheFileRead(String pFilePath)
        {
            string szHtml = "";

            if (System.IO.File.Exists(pFilePath))
            {
                try
                {   // Open the text file using a stream reader.
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(pFilePath))
                    {
                        // Read the stream to a string, and write the string to the console.
                        szHtml = sr.ReadToEnd();

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else

            {

                szHtml = "Dont find chache last articles";
            }
            return szHtml;

        }
        public static String FncCacheFileRead(UInt64 idDoc, String IdDocLng, String DocType)
        {

            String szHtml = "";
            String szFilePath = FncCacheFilePath(idDoc, IdDocLng, DocType.ToLower());
            if (System.IO.File.Exists(szFilePath))
            {
                try
                {   // Open the text file using a stream reader.
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(szFilePath))
                    {
                        // Read the stream to a string, and write the string to the console.
                        szHtml = sr.ReadToEnd();

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else

            {

                szHtml = "Dont find chache";
            }
            return szHtml;
        }
        public static void FncCacheFileSave(ref String szFilePath, ref String szHtml)
        {
            try
            {
                if (System.IO.File.Exists(szFilePath))
                {
                    System.IO.File.Delete(szFilePath);
                }
                System.IO.File.WriteAllText(szFilePath, szHtml);
            }
            catch { };
        }

        internal static void FncCacheFileSave()
        {
            throw new NotImplementedException();
        }

        public static void FncCacheFileSave(ref UInt64 idDoc, ref String IdDocLng, ref String DocType, ref String szHtml)
        {
            String szFilePath = FncCacheFilePath(idDoc, IdDocLng, DocType.ToLower());

            FncCacheFileSave(ref szFilePath, ref szHtml);

        }
    }
}