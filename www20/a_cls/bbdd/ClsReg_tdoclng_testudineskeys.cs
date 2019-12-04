
using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
//<summary>
//Descripción breve de testudines.cls.bbdd
//<//summary>
public class ClsReg_tdoclng_testudineskeys:IDisposable  {
	private bool _mErrorBoolean=false;
	private string _mErrorString="";

	private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
	private MySqlCommand oSqlCmdInsert = new MySqlCommand();
	private MySqlCommand oSqlCmdDelete = new MySqlCommand();
	private MySqlCommand oSqlCmdSelect = new MySqlCommand();
	private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
    private MySqlCommand oSqlCmdSelectTOWNodeId= new MySqlCommand();

//-------------------------------------------------
#region SQLDEFINICION_VARIABLES#
//------------------------------------------------
	 private UInt64 m_DocId = 0;
	 private String m_TOWNodeId = "";
	 private String m_TOWNodeParentId = "";
	 private Int32 m_TOWNodekeyNum = 0;
	 private String m_TOWDescription = "";
	 private String m_TOWTaxaGroupLevel = "";
	 private String m_TOWTaxaGroupName = "";
	 private String m_TOWTaxaURL = "";
	 private String m_ImgHlpPath01 = "";
	 private String m_ImgHlpPath02 = "";
	 private String m_ImgHlpPath03 = "";
	 private UInt64 m_TaxonDocId = 0;
	 private String m_NodeFullPathListHtml = "";
	 private String m_NodeFullPathList = "";
     private bool m_IsRevised = false;
     private String m_TOWATaxIdGroup = "";
    
    private String m_TOWATaxGrpL2280Specie = "";
    private String m_TOWATaxGrpL2280SpecieSub = "";
    private UInt64  m_DocIdTaxaRelationValue = 0;
    private String m_DocIdTaxaRelationText = "No Relation";
    
#endregion SQLDEFINICION_VARIABLES
//------------------------------

//---------------------------------------------------
//public ClsReg_tdoclng_testudineskeys(string szSqlConnectionString)
//{
public ClsReg_tdoclng_testudineskeys()
{

            
	FncSqlBuildCommands();
	FncClear();
}
//---------------------------------------------------



//---------------------------------------------------
//---------------------------------------------------
//---------------------------------------------------
#region IDisposable implementation
public bool m_Disposed = false;

//...............

public void Dispose()

	{
	   Dispose(true);
	GC.SuppressFinalize(this);
	}

protected virtual void Dispose(bool disposing)
	{
	if (cls.bbdd.ClsMysql.MySqlConnection.State == ConnectionState.Open )  ClsMysql.FncClose();
	//oSqlCnn.Dispose ();
	oSqlCmdUpdate.Dispose();
	oSqlCmdUpdate.Dispose();
	oSqlCmdInsert.Dispose();
	oSqlCmdDelete.Dispose();
	oSqlCmdSelect.Dispose();
	oSqlCmdSelectExist.Dispose();
    oSqlCmdSelectTOWNodeId.Dispose ();
	m_Disposed = true;
	}

//...............
~ClsReg_tdoclng_testudineskeys()    
{        
	Dispose(false);
}
#endregion
//---------------------------------------------------
//---------------------------------------------------

//--------------------------------------------------
#region CLEAR
//--------------------------------------------------
 public void FncClear(){
	 m_DocId = 0;
	 m_TOWNodeId = "";
	 m_TOWNodeParentId = "";
	 m_TOWNodekeyNum = 0;
	 m_TOWDescription = "";
	 m_TOWTaxaGroupLevel = "";
	 m_TOWTaxaGroupName = "";
	 m_TOWTaxaURL = "";
	 m_ImgHlpPath01 = "";
	 m_ImgHlpPath02 = "";
	 m_ImgHlpPath03 = "";
	 m_TaxonDocId = 0;
	 m_NodeFullPathListHtml = "";
    
	 m_NodeFullPathList = "";
     m_IsRevised = false;
     m_TOWATaxIdGroup = "";
     m_TOWATaxGrpL2280Specie = "";
     m_TOWATaxGrpL2280SpecieSub = "";
     m_DocIdTaxaRelationValue = 0;
     m_DocIdTaxaRelationText = "No Relation";
}
#endregion CLEAR
//------------------------------
//--------------------------------------------------------
//----------------FncSqlBuildCommands-----------------------
//--------------------------------------------------------
public void FncSqlBuildCommands() {


	 string szSql = "";



	//----------------------------------------------------------------------
	//-------------- COMANDO SELECT  ---------------------------------------
	//----------------------------------------------------------------------
	szSql="SELECT * FROM tdoclng_testudines_keys  ";
	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 

	oSqlCmdSelect.CommandText =szSql;
	 oSqlCmdSelect.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	//----------------------------------------------------------------------
    //----------------------------------------------------------------------
	//-------------- COMANDO SELECT  TOWNodeId -----------------------------
	//----------------------------------------------------------------------
    szSql="SELECT docid FROM tdoclng_testudines_keys  ";
	 szSql+=" WHERE ";
	 szSql+="(TOWNodeId=@TOWNodeId )"; 

	oSqlCmdSelectTOWNodeId.CommandText =szSql;
	oSqlCmdSelectTOWNodeId.Parameters.Add ("@TOWNodeId",MySql.Data.MySqlClient.MySqlDbType.String);
    



	//----------------------------------------------------------------------
	//-------------- COMANDO INSERT ----------------------------------------
	//----------------------------------------------------------------------
	 szSql="INSERT INTO tdoclng_testudines_keys";

	 szSql+="(";

	 szSql+=" DocId "; 
	 szSql+=", TOWNodeId "; 
	 szSql+=", TOWNodeParentId "; 
	 szSql+=", TOWNodekeyNum "; 
	 szSql+=", TOWDescription "; 
	 szSql+=", TOWTaxaGroupLevel "; 
	 szSql+=", TOWTaxaGroupName "; 
	 szSql+=", TOWTaxaURL "; 
	 szSql+=", ImgHlpPath01 "; 
	 szSql+=", ImgHlpPath02 "; 
	 szSql+=", ImgHlpPath03 "; 
	 szSql+=", TaxonDocId "; 
	 szSql+=", NodeFullPathListHtml "; 
	 szSql+=", NodeFullPathList ";
     szSql += ", IsRevised ";
     szSql += ", TOWATaxIdGroup ";
     szSql += ", TOWATaxGrpL2280Specie ";
     szSql += ", TOWATaxGrpL2280SpecieSub ";
     szSql += ", DocIdTaxaRelationValue ";
     szSql += ", DocIdTaxaRelationText ";

   
    


	 szSql+=" ) VALUES     (";
	 szSql+=" @DocId "; 
	 szSql+=", @TOWNodeId "; 
	 szSql+=", @TOWNodeParentId "; 
	 szSql+=", @TOWNodekeyNum "; 
	 szSql+=", @TOWDescription "; 
	 szSql+=", @TOWTaxaGroupLevel "; 
	 szSql+=", @TOWTaxaGroupName "; 
	 szSql+=", @TOWTaxaURL "; 
	 szSql+=", @ImgHlpPath01 "; 
	 szSql+=", @ImgHlpPath02 "; 
	 szSql+=", @ImgHlpPath03 "; 
	 szSql+=", @TaxonDocId "; 
	 szSql+=", @NodeFullPathListHtml "; 
	 szSql+=", @NodeFullPathList ";
     szSql += ", @IsRevised ";
     szSql += ", @TOWATaxIdGroup ";
     szSql += ", @TOWATaxGrpL2280Specie ";
     szSql += ", @TOWATaxGrpL2280SpecieSub ";
     szSql += ", @DocIdTaxaRelationValue ";
    szSql += ", @DocIdTaxaRelationText ";
    

    
	 szSql+=")";
	 // szSql+= " ; SELECT LAST_INSERT_ID()"
	//-----------------------------------------------------
	// TODO Para configurar el comando Insert recuperando la identidad. 
	// descomentar la linea anterior  


	oSqlCmdInsert.CommandText =szSql;
	 oSqlCmdInsert.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdInsert.Parameters.Add ("@TOWNodeId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TOWNodeParentId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TOWNodekeyNum",MySql.Data.MySqlClient.MySqlDbType.Int32);
	 oSqlCmdInsert.Parameters.Add ("@TOWDescription",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TOWTaxaGroupLevel",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TOWTaxaGroupName",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TOWTaxaURL",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@ImgHlpPath01",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@ImgHlpPath02",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@ImgHlpPath03",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@TaxonDocId",MySql.Data.MySqlClient.MySqlDbType.Int32);
	 oSqlCmdInsert.Parameters.Add ("@NodeFullPathListHtml",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@NodeFullPathList",MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdInsert.Parameters.Add("@IsRevised", MySql.Data.MySqlClient.MySqlDbType.Bit );
     oSqlCmdInsert.Parameters.Add("@TOWATaxIdGroup", MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdInsert.Parameters.Add("@TOWATaxGrpL2280Specie", MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdInsert.Parameters.Add("@TOWATaxGrpL2280SpecieSub", MySql.Data.MySqlClient.MySqlDbType.String);

     oSqlCmdInsert.Parameters.Add("@DocIdTaxaRelationValue", MySql.Data.MySqlClient.MySqlDbType.UInt64);
     oSqlCmdInsert.Parameters.Add("@DocIdTaxaRelationText", MySql.Data.MySqlClient.MySqlDbType.String );

     
    
    //----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO UPDATE ---------------------------------------
	//----------------------------------------------------------------------
	 szSql="UPDATE tdoclng_testudines_keys SET " ;

	 szSql+="TOWNodeId=@TOWNodeId "; 
	 szSql+=", TOWNodeParentId=@TOWNodeParentId "; 
	 szSql+=", TOWNodekeyNum=@TOWNodekeyNum "; 
	 szSql+=", TOWDescription=@TOWDescription "; 
	 szSql+=", TOWTaxaGroupLevel=@TOWTaxaGroupLevel "; 
	 szSql+=", TOWTaxaGroupName=@TOWTaxaGroupName "; 
	 szSql+=", TOWTaxaURL=@TOWTaxaURL "; 
	 szSql+=", ImgHlpPath01=@ImgHlpPath01 "; 
	 szSql+=", ImgHlpPath02=@ImgHlpPath02 "; 
	 szSql+=", ImgHlpPath03=@ImgHlpPath03 "; 
	 szSql+=", TaxonDocId=@TaxonDocId "; 
	 szSql+=", NodeFullPathListHtml=@NodeFullPathListHtml "; 
	 szSql+=", NodeFullPathList=@NodeFullPathList ";
     szSql += ", IsRevised=@IsRevised ";
     szSql += ", TOWATaxIdGroup=@TOWATaxIdGroup ";
     szSql += ", TOWATaxGrpL2280Specie=@TOWATaxGrpL2280Specie ";
     szSql += ", TOWATaxGrpL2280SpecieSub=@TOWATaxGrpL2280SpecieSub ";
     szSql += ", DocIdTaxaRelationValue=@DocIdTaxaRelationValue ";
     szSql += ", DocIdTaxaRelationText=@DocIdTaxaRelationText ";
    
 

	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	oSqlCmdUpdate.CommandText =szSql;


	 oSqlCmdUpdate.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdUpdate.Parameters.Add ("@TOWNodeId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TOWNodeParentId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TOWNodekeyNum",MySql.Data.MySqlClient.MySqlDbType.Int32);
	 oSqlCmdUpdate.Parameters.Add ("@TOWDescription",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TOWTaxaGroupLevel",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TOWTaxaGroupName",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TOWTaxaURL",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@ImgHlpPath01",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@ImgHlpPath02",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@ImgHlpPath03",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@TaxonDocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdUpdate.Parameters.Add ("@NodeFullPathListHtml",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@NodeFullPathList",MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdUpdate.Parameters.Add ("@IsRevised", MySql.Data.MySqlClient.MySqlDbType.Bit);
     oSqlCmdUpdate.Parameters.Add ("@TOWATaxIdGroup", MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdUpdate.Parameters.Add ("@TOWATaxGrpL2280Specie", MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdUpdate.Parameters.Add ("@TOWATaxGrpL2280SpecieSub", MySql.Data.MySqlClient.MySqlDbType.String);
     oSqlCmdUpdate.Parameters.Add ("@DocIdTaxaRelationValue", MySql.Data.MySqlClient.MySqlDbType.UInt64);
     oSqlCmdUpdate.Parameters.Add("@DocIdTaxaRelationText", MySql.Data.MySqlClient.MySqlDbType.String);




     //----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO DELETE  ---------------------------------------
	//----------------------------------------------------------------------
	szSql="DELETE FROM tdoclng_testudines_keys  ";
	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 

	oSqlCmdDelete.CommandText =szSql;
	 oSqlCmdDelete.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO SELECT  exist ---------------------------------
	//----------------------------------------------------------------------
	szSql="SELECT ";
	 szSql+=" DocId";
	szSql+=" FROM tdoclng_testudines_keys  ";

	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	oSqlCmdSelectExist.CommandText =szSql;
	 oSqlCmdSelectExist.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	//----------------------------------------------------------------------
}
//--------------------------------------------------------



//	-------------------------------------------------

public bool FncSqlSave()

	{
	_mErrorBoolean =false;

	_mErrorString="";

	bool b=false;	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;

	//.............................................................
	//.............................................................
	//.TODO DESCOMENTAR LINEAS CON PUNTOS EN CASO DE AUTONUMERICOS
	//.............................................................
	// TODO CAMBIAR m_idKey por la clave autonumerica que proceda..
	//   if (m_IdKEY == 0)
	//   {
	//       b = false;
	//   }
	//   else
	//   {
	//............................................................
	//............................................................

	// comprobar si existe el id a añadir

	// TODO Atencion en caso de claves alternavas

	// Atencion en caso de claves alternativas

	// añadir una fucion que la controle

	oSqlCmdSelectExist.Parameters["@DocId"].Value=m_DocId;

	 oSqlCmdSelectExist.Connection= cls.bbdd.ClsMysql.MySqlConnection;
	MySqlDataReader oDR=oSqlCmdSelectExist.ExecuteReader();
	 b=oDR.HasRows; 
	oDR.Close ();
            cls.bbdd.ClsMysql.FncClose();
	//.............................................................
	//........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
	//// } 
	//.............................................................
    // recalcular el path de las rutas gerargicas antes de salvar
    m_NodeFullPathList = "";
    m_NodeFullPathListHtml = "";
    FncGetPathNodes(ref m_NodeFullPathList, ref m_NodeFullPathListHtml, m_TOWNodeId);
	if (b)
	{
		b=FncSqlUpdate() ;
	}
	else
	{
		b=FncSqlInsert();
	}
	_mErrorBoolean = b;
	 return b;
	}
//------------------------------------------------------


//-------------------------------------------------------
//----------------FncSqlUpdate)--------------------------
//-------------------------------------------------------
private bool FncSqlUpdate() {
	_mErrorBoolean  =false;
	_mErrorString="";
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
	////-----------------------------------------------------;
	//// Configurar comando update. 
	////-------------------------------------------------------;
	oSqlCmdUpdate.Parameters["@DocId"].Value=m_DocId;
	oSqlCmdUpdate.Parameters["@TOWNodeId"].Value=m_TOWNodeId;
	oSqlCmdUpdate.Parameters["@TOWNodeParentId"].Value=m_TOWNodeParentId;
	oSqlCmdUpdate.Parameters["@TOWNodekeyNum"].Value=m_TOWNodekeyNum;
	oSqlCmdUpdate.Parameters["@TOWDescription"].Value=m_TOWDescription;
	oSqlCmdUpdate.Parameters["@TOWTaxaGroupLevel"].Value=m_TOWTaxaGroupLevel;
	oSqlCmdUpdate.Parameters["@TOWTaxaGroupName"].Value=m_TOWTaxaGroupName;
	oSqlCmdUpdate.Parameters["@TOWTaxaURL"].Value=m_TOWTaxaURL;
	oSqlCmdUpdate.Parameters["@ImgHlpPath01"].Value=m_ImgHlpPath01;
	oSqlCmdUpdate.Parameters["@ImgHlpPath02"].Value=m_ImgHlpPath02;
	oSqlCmdUpdate.Parameters["@ImgHlpPath03"].Value=m_ImgHlpPath03;
	oSqlCmdUpdate.Parameters["@TaxonDocId"].Value=m_TaxonDocId;
	oSqlCmdUpdate.Parameters["@NodeFullPathListHtml"].Value=m_NodeFullPathListHtml;
	oSqlCmdUpdate.Parameters["@NodeFullPathList"].Value=m_NodeFullPathList;
    oSqlCmdUpdate.Parameters["@IsRevised"].Value=m_IsRevised;
    oSqlCmdUpdate.Parameters["@TOWATaxIdGroup"].Value = m_TOWATaxIdGroup;
    oSqlCmdUpdate.Parameters["@TOWATaxGrpL2280Specie"].Value = m_TOWATaxGrpL2280Specie;
    oSqlCmdUpdate.Parameters["@TOWATaxGrpL2280SpecieSub"].Value = m_TOWATaxGrpL2280SpecieSub;
    oSqlCmdUpdate.Parameters["@DocIdTaxaRelationValue"].Value = m_DocIdTaxaRelationValue;
    oSqlCmdUpdate.Parameters["@DocIdTaxaRelationText"].Value = m_DocIdTaxaRelationText;
  
    
    

    
	//-----------------------------------------------------;
	//            ACTUALIZAR 
	//-------------------------------------------------------;
	oSqlCmdUpdate.Connection = cls.bbdd.ClsMysql.MySqlConnection;
	try {
		int i=oSqlCmdUpdate.ExecuteNonQuery();
	}
	catch (SystemException ex) {
		_mErrorBoolean=true;
		_mErrorString= ex.ToString ();
		//  MessageBox.Show (_mErrorString);
	}
	ClsMysql.FncClose();
	//oSqlCnn.Dispose();
	return !_mErrorBoolean;
	}
//-------------------------------------------------------;


//--------------------------------------------------------
//----------------FncSqlInsert--------------------------
//--------------------------------------------------------
private bool FncSqlInsert() {
	_mErrorBoolean =false;
	_mErrorString="";
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
	//-----------------------------------------------------
	// Configurar comando Insert recuperando la identidad. 
	// CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). 
	// Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); 
	// ; SELECT @@IDENTITY	//-----------------------------------------------------
	oSqlCmdInsert.Parameters["@DocId"].Value=m_DocId;
	oSqlCmdInsert.Parameters["@TOWNodeId"].Value=m_TOWNodeId;
	oSqlCmdInsert.Parameters["@TOWNodeParentId"].Value=m_TOWNodeParentId;
	oSqlCmdInsert.Parameters["@TOWNodekeyNum"].Value=m_TOWNodekeyNum;
	oSqlCmdInsert.Parameters["@TOWDescription"].Value=m_TOWDescription;
	oSqlCmdInsert.Parameters["@TOWTaxaGroupLevel"].Value=m_TOWTaxaGroupLevel;
	oSqlCmdInsert.Parameters["@TOWTaxaGroupName"].Value=m_TOWTaxaGroupName;
	oSqlCmdInsert.Parameters["@TOWTaxaURL"].Value=m_TOWTaxaURL;
	oSqlCmdInsert.Parameters["@ImgHlpPath01"].Value=m_ImgHlpPath01;
	oSqlCmdInsert.Parameters["@ImgHlpPath02"].Value=m_ImgHlpPath02;
	oSqlCmdInsert.Parameters["@ImgHlpPath03"].Value=m_ImgHlpPath03;
	oSqlCmdInsert.Parameters["@TaxonDocId"].Value=m_TaxonDocId;
	oSqlCmdInsert.Parameters["@NodeFullPathListHtml"].Value=m_NodeFullPathListHtml;
	oSqlCmdInsert.Parameters["@NodeFullPathList"].Value=m_NodeFullPathList;
    oSqlCmdInsert.Parameters["@IsRevised"].Value = m_IsRevised;
    oSqlCmdInsert.Parameters["@TOWATaxIdGroup"].Value = m_TOWATaxIdGroup;
    oSqlCmdInsert.Parameters["@TOWATaxGrpL2280Specie"].Value = m_TOWATaxGrpL2280Specie;
    oSqlCmdInsert.Parameters["@TOWATaxGrpL2280SpecieSub"].Value = m_TOWATaxGrpL2280SpecieSub;
    oSqlCmdInsert.Parameters["@DocIdTaxaRelationValue"].Value = m_DocIdTaxaRelationValue;
    oSqlCmdInsert.Parameters["@DocIdTaxaRelationText"].Value = m_DocIdTaxaRelationText;
    
    

  
    
	try {
	oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;;
	oSqlCmdInsert.ExecuteNonQuery();
}
	catch (SystemException ex) {
		_mErrorBoolean=true;
		_mErrorString= ex.ToString ();
		//  MessageBox.Show (_mErrorString);
	}
	ClsMysql.FncClose();
	
	return !_mErrorBoolean;
	}//--------------------------------------------------------
//----------------FncSqlFind------------------------------
//--------------------------------------------------------

public bool FncSqlFindTOWNodeId(string TOWNodeId)
{ 
    _mErrorBoolean =false;
	_mErrorString="";
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
//---------------------------------------------------
//Asignar parametros al commando para búsqueda       
//----------------------------------------------------
	oSqlCmdSelectTOWNodeId.Parameters["@TOWNodeId"].Value=TOWNodeId;
//----------------------------------------------------
	 
    UInt64 DocId=0;
	
	    try
        {
            oSqlCmdSelectTOWNodeId.Connection = ClsMysql.MySqlConnection;;
                 ClsMysql.FncOpen("");
    
            DocId = Convert.ToUInt64(oSqlCmdSelectTOWNodeId.ExecuteScalar());
            // si lo encuentra buscar por DocId para rellenar los campos
            return FncSqlFind(DocId);
        }
        catch  (Exception xcpt)
        {
            ErrorBoolean =true ;
            ErrorString =xcpt.Message ;
            return false ;
        }
}
public bool FncSqlFind(UInt64 DocId) {
	_mErrorBoolean =false;
	_mErrorString="";
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
//---------------------------------------------------
//Asignar parametros al commando para búsqueda       
//----------------------------------------------------
	oSqlCmdSelect.Parameters["@DocId"].Value=DocId;
//----------------------------------------------------
	 MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
	try {
		oSqlCmdSelect.Connection= cls.bbdd.ClsMysql.MySqlConnection;
		ClsMysql.FncOpen("");
		 oDR = oSqlCmdSelect.ExecuteReader();
	//----------------------------------------------------
	// recoger los datos leidos
	//----------------------------------------------------
if ((oDR.HasRows)&&(oDR.Read())) {
			m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
			m_TOWNodeId = oDR["TOWNodeId"].ToString().Trim();
			m_TOWNodeParentId = oDR["TOWNodeParentId"].ToString().Trim();
			m_TOWNodekeyNum = Convert.ToInt32(oDR["TOWNodekeyNum"].ToString().Trim());
			m_TOWDescription = oDR["TOWDescription"].ToString().Trim();
			m_TOWTaxaGroupLevel = oDR["TOWTaxaGroupLevel"].ToString().Trim();
			m_TOWTaxaGroupName = oDR["TOWTaxaGroupName"].ToString().Trim();
			m_TOWTaxaURL = oDR["TOWTaxaURL"].ToString().Trim();
			m_ImgHlpPath01 = oDR["ImgHlpPath01"].ToString().Trim();
			m_ImgHlpPath02 = oDR["ImgHlpPath02"].ToString().Trim();
			m_ImgHlpPath03 = oDR["ImgHlpPath03"].ToString().Trim();
         
                m_TaxonDocId = Convert.ToUInt64(oDR["TaxonDocId"].ToString().Trim());
         
			m_NodeFullPathListHtml = oDR["NodeFullPathListHtml"].ToString().Trim();
			m_NodeFullPathList = oDR["NodeFullPathList"].ToString().Trim();

           
            string szRevised= oDR["IsRevised"].ToString().Trim();
            m_TOWATaxIdGroup = oDR["TOWATaxIdGroup"].ToString().Trim();
            m_TOWATaxGrpL2280Specie = oDR["TOWATaxGrpL2280Specie"].ToString().Trim();
            m_TOWATaxGrpL2280SpecieSub = oDR["TOWATaxGrpL2280SpecieSub"].ToString().Trim();
            m_DocIdTaxaRelationValue =Convert.ToUInt64 (   oDR["DocIdTaxaRelationValue"].ToString().Trim());
            m_DocIdTaxaRelationText = oDR["DocIdTaxaRelationText"].ToString().Trim();
    if (szRevised == "1")
    {
        m_IsRevised = true;
    }
    else
    { m_IsRevised = false; }
       
    
			oDR.Close();
		} //Cierre de if 
	else {
		 _mErrorBoolean=true; 
		 _mErrorString="Not found."; 
	}//Cierre de else 
	}//Cierre de try 
	catch (SystemException ex) {
	
		_mErrorBoolean=true;
		_mErrorString= ex.ToString ();
		//  MessageBox.Show (_mErrorString); 
	}	
	//------------------------------------------------------
	// cierre.
	//-------------------------------------------------------
	ClsMysql.FncClose();
	return !_mErrorBoolean;
	//--------------------------------------------------------------------
	}
//--------------------------------------------------------r
//----------------FncSqlDelete--------------------------
//--------------------------------------------------------
public bool FncSqlDelete(Int64 DocId) {
	_mErrorBoolean  =false;
	_mErrorString="";
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
	//-----------------------------------------------------;
	// ELIMINAR REGISTRO. 
	//-------------------------------------------------------;
	oSqlCmdDelete.Connection = cls.bbdd.ClsMysql.MySqlConnection;
	try {
	oSqlCmdDelete.Parameters["@DocId"].Value=DocId;
		int i =oSqlCmdDelete.ExecuteNonQuery();
		if (i>0) {
			FncClear();
		}
	}
	catch (MySqlException xcpt) {
		_mErrorString = xcpt.Message;
		_mErrorBoolean=true;
		//  MessageBox.Show (xcpt.Message );
	}
	ClsMysql.FncClose();
	//oSqlCnn.Dispose();
	return !_mErrorBoolean;
}
	//------------------------------------------------;

//--------------------------------------------------------
//----------------FncSqlExist------------------------------
//--------------------------------------------------------
public bool FncSqlExist(Int64 DocId) {
	_mErrorBoolean =false;
	_mErrorString="";
	bool b=false;
	//-------------------------------------------------
	// abrir conexion
	//--------------------------------------------------
	if (!ClsMysql.FncOpen("")) 
 		 return false;
//---------------------------------------------------
//Asignar parametros al commando para búsqueda       
//----------------------------------------------------
	oSqlCmdSelectExist.Parameters["@DocId"].Value=DocId;

	 oSqlCmdSelectExist.Connection= cls.bbdd.ClsMysql.MySqlConnection;
	MySqlDataReader oDR=oSqlCmdSelectExist.ExecuteReader();
	 b=oDR.HasRows; 
	oDR.Close ();
            cls.bbdd.ClsMysql.FncClose();

    return b;
}


//--------------------------------------------------
#region VALORES_GETSET
//--------------------------------------------------

//------------------------------
	public bool ErrorBoolean {
	get{return _mErrorBoolean;}
	set{_mErrorBoolean=value;}
	}
//------------------------------
	public string ErrorString {
	get {return _mErrorString;}
	set {_mErrorString=value;}
	}
//------------------------------
//................................

public UInt64 DocId
{
	set {
	m_DocId=value;
	}
	get {return m_DocId;}
}

//................................

public String TOWNodeId
{
	set {
		string sz=value.Trim();
		if(sz.Length>5) 
		{ 
		sz=sz.Substring(0,4);
           
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWNodeId because is it too long,MaxLength=5";
		}
        sz = sz.PadLeft(5, '0') ;
	m_TOWNodeId=sz;

	}
	get {return m_TOWNodeId;}
}

//................................

public String TOWNodeParentId
{
	set {
		string sz=value.Trim();
		if(sz.Length>5) 
		{ 
		sz=sz.Substring(0,4);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWNodeParentId because is it too long,MaxLength=5";
		}
        sz = sz.PadLeft(5, '0');
	m_TOWNodeParentId=sz;

	}
	get {return m_TOWNodeParentId;}
}

//................................

public Int32 TOWNodekeyNum
{
	set {
	m_TOWNodekeyNum=value;
	}
	get {return m_TOWNodekeyNum;}
}

//................................

public String TOWDescription
{
	set {
	m_TOWDescription=value;
	}
	get {return m_TOWDescription;}
}

//................................

public String TOWTaxaGroupLevel
{
	set {
		string sz=value.Trim();
		if(sz.Length>150) 
		{ 
		sz=sz.Substring(0,149);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWTaxaGroupLevel because is it too long,MaxLength=150";
		}
	m_TOWTaxaGroupLevel=sz;

	}
	get {return m_TOWTaxaGroupLevel;}
}

//................................

public String TOWTaxaGroupName
{
	set {
		string sz=value.Trim();
		if(sz.Length>150) 
		{ 
		sz=sz.Substring(0,149);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWTaxaGroupName because is it too long,MaxLength=150";
		}
	m_TOWTaxaGroupName=sz;

	}
	get {return m_TOWTaxaGroupName;}
}

//................................

public String TOWTaxaURL
{
	set {
		string sz=value.Trim();
		if(sz.Length>255) 
		{ 
		sz=sz.Substring(0,254);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWTaxaURL because is it too long,MaxLength=255";
		}
	m_TOWTaxaURL=sz;

	}
	get {return m_TOWTaxaURL;}
}

//................................

public String ImgHlpPath01
{
	set {
		string sz=value.Trim();
		if(sz.Length>300) 
		{ 
		sz=sz.Substring(0,299);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_ImgHlpPath01 because is it too long,MaxLength=300";
		}
	m_ImgHlpPath01=sz;

	}
	get {return m_ImgHlpPath01;}
}

//................................

public String ImgHlpPath02
{
	set {
		string sz=value.Trim();
		if(sz.Length>300) 
		{ 
		sz=sz.Substring(0,299);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_ImgHlpPath02 because is it too long,MaxLength=300";
		}
	m_ImgHlpPath02=sz;

	}
	get {return m_ImgHlpPath02;}
}

//................................

public String ImgHlpPath03
{
	set {
		string sz=value.Trim();
		if(sz.Length>300) 
		{ 
		sz=sz.Substring(0,299);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_ImgHlpPath03 because is it too long,MaxLength=300";
		}
	m_ImgHlpPath03=sz;

	}
	get {return m_ImgHlpPath03;}
}

//................................

public UInt64 TaxonDocId
{
	set {
	m_TaxonDocId=value;
	}
	get {return m_TaxonDocId;}
}

//................................

public String NodeFullPathListHtml
{
	
	get {
        // recacular las rutas por si han cambiado niveles superiores de gerarquia
        m_NodeFullPathList = "";
        m_NodeFullPathListHtml = "";
        FncGetPathNodes(ref m_NodeFullPathList, ref m_NodeFullPathListHtml,m_TOWNodeId );
        return m_NodeFullPathListHtml;}
}


//................................

public String NodeFullPathList
{
	

	
	get {
        // recacular las rutas por si han cambiado niveles superiores de gerarquia
        m_NodeFullPathList = "";
        m_NodeFullPathListHtml = "";
        FncGetPathNodes(ref m_NodeFullPathList, ref m_NodeFullPathListHtml, m_TOWNodeId);
        return m_NodeFullPathList;}
}
public bool IsRevised
{
    get { return m_IsRevised; }
    set { m_IsRevised =value; }
}

public String TOWATaxIdGroup
{
	

	
	get {return m_TOWATaxIdGroup;}
    set{
       string sz=value.Trim();
		if(sz.Length>49) 
		{ 
		sz=sz.Substring(0,49);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_TOWATaxIdGroup because is it too long,MaxLength=300";
		}
	m_TOWATaxIdGroup=sz;

    }
}
 public String TOWATaxGrpL2280Specie
{
	

	
	get {return m_TOWATaxGrpL2280Specie;}
    set{
       string sz=value.Trim();
		if(sz.Length>49) 
		{ 
		sz=sz.Substring(0,49);
		_mErrorBoolean=true;
        _mErrorString = "Trimmed m_TOWATaxGrpL2280Specie because is it too long,MaxLength=300";
		}
	m_TOWATaxGrpL2280Specie=sz;

    }
}

 public String
TOWATaxGrpL2280SpecieSub
{
	

	
	get {return m_TOWATaxGrpL2280SpecieSub;}
    set{
       string sz=value.Trim();
		if(sz.Length>49) 
		{ 
		sz=sz.Substring(0,49);
		_mErrorBoolean=true;
        _mErrorString = "Trimmed m_TOWATaxGrpL2280SpecieSub because is it too long,MaxLength=300";
		}

        m_TOWATaxGrpL2280SpecieSub = sz;

    }
}
    public UInt64  DocIdTaxaRelationValue
    {
        get { return m_DocIdTaxaRelationValue; }
        set { m_DocIdTaxaRelationValue = value; }
}
    public String DocIdTaxaRelationText
    {
        get { return m_DocIdTaxaRelationText; }
        set {
            value = value.Trim();
            if (value.Length > 50) value = value.Substring(0, 49);
            m_DocIdTaxaRelationText = value; }
    }
#endregion VALORES_GETSET

private MySqlDataAdapter m_oSqlDA = new MySqlDataAdapter();
private  MySqlConnection m_oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB); //providerName= MySql.Data.MySqlClient; CharSet=UTF8;
private MySqlCommand m_oSqlCmd = new MySqlCommand();
private DataTable m_DT = new DataTable();
     
// obtener el path completo de cada nodo de la tabla
/// <summary>
/// Recursive function to obtain full path of one node ,
/// Return html in ref variables
/// </summary>
/// <param name="szPath">return full path as txt split by , </param>
/// <param name="szPathUrl">Return full path as html with links </param>
/// <param name="szNodeId">Id Node</param>
/// <returns></returns>
public void FncGetPathNodes(ref string szPathTxt, ref string szPathUrlHtml, string szTOWNodeId)
{

    string szSql = "select docid, TOWNodeParentId,TOWDescription,TOWTaxaURL,TOWTaxaGroupLevel, TOWTaxaGroupName from tdoclng_testudines_keys where TOWNodeId= '" + szTOWNodeId + "'";
    if (m_oSqlCnn.State != ConnectionState.Open)
    {
        m_oSqlCnn.Open();
    }
    if (m_oSqlCmd.Connection == null)
    {
        m_oSqlCmd.Connection = m_oSqlCnn;
    }
        m_oSqlCmd.CommandText = szSql;
    m_oSqlDA.SelectCommand = m_oSqlCmd;
    m_DT.Rows.Clear();
    m_oSqlDA.Fill(m_DT);
    if (m_DT.Rows.Count > 0)
    {
        string szDocId = m_DT.Rows[0]["docid"].ToString();
        string szParentId = m_DT.Rows[0]["TOWNodeParentId"].ToString();
        szPathTxt = szTOWNodeId + ", " + szPathTxt;
        szPathUrlHtml = "<a href=\"/en" + "/tortoises/keys/key/" + szDocId + "\">-" + szTOWNodeId + "</a> - \n" + szPathUrlHtml;

        if (szTOWNodeId != "00000")
        {
            FncGetPathNodes(ref szPathTxt, ref szPathUrlHtml, szParentId);
        }

    


    }
    else
    {
        szPathTxt = "00000, " + szPathTxt;
        szPathUrlHtml = "<a href=\"/en"+"/tortoises/key/00000\">00000</a> - \n" + szPathUrlHtml;

    }
    return;

}
}
}
