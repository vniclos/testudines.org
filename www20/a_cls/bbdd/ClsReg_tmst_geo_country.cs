using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
//<summary>
//Descripción breve de testudines.cls.bbdd
//<//summary>
public class ClsReg_tmst_geo_country {
	private bool _mErrorBoolean=false;
        private String _mErrorString = "";

    private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
	private MySqlCommand oSqlCmdInsert = new MySqlCommand();
	private MySqlCommand oSqlCmdDelete = new MySqlCommand();
	private MySqlCommand oSqlCmdSelect = new MySqlCommand();
	private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();

//-------------------------------------------------
#region SQLDEFINICION_VARIABLES#
//------------------------------------------------

	 private String m_IdCoutryISO3Plus = "";
	 private String m_Id_Lng = "";
	 private String m_IdGrpTypeGeo = "";
	 private String m_Id_Iso2Plus = "";
	 private String m_CountryName = "";
	 private String m_CountryNameLocal = "";
	 private String m_IdGroupList = "";
	 private String m_IdContinent = "";
	 private String  m_ContinentName = "";
	 private String m_ContinentRegion = "";
     private String m_IdContinentRegion = "";
	 private Int32 m_Capital = 0;
#endregion SQLDEFINICION_VARIABLES
//------------------------------

//---------------------------------------------------
//public ClsReg_tmst_geo_country(string szSqlConnectionString)
//{
public ClsReg_tmst_geo_country()
{
	
	FncSqlBuildCommands();
	FncClear();
}
//---------------------------------------------------



//--------------------------------------------------
#region CLEAR
//--------------------------------------------------
 public void FncClear(){
	 m_IdCoutryISO3Plus = "";
	 m_Id_Lng = "";
	 m_IdGrpTypeGeo = "";
	 m_Id_Iso2Plus = "";
	 m_CountryName = "";
	 m_CountryNameLocal = "";
	 m_IdGroupList = "";
	 m_IdContinent = "";
	 m_IdContinentRegion = "";
	 m_ContinentName = "";
	 m_ContinentRegion = "";
	 m_Capital = 0;
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
	szSql="SELECT * FROM tmst_geo_country  ";
	 szSql+=" WHERE ";
	 szSql+="(IdCoutryISO3Plus=@IdCoutryISO3Plus )"; 

	oSqlCmdSelect.CommandText =szSql;
	 oSqlCmdSelect.Parameters.Add ("@IdCoutryISO3Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	//----------------------------------------------------------------------

	//----------------------------------------------------------------------
	//-------------- COMANDO INSERT ----------------------------------------
	//----------------------------------------------------------------------
	 szSql="INSERT INTO tmst_geo_country";

	 szSql+="(";

	 szSql+=" IdCoutryISO3Plus "; 
	 szSql+=", Id_Lng "; 
	 szSql+=", IdGrpTypeGeo "; 
	 szSql+=", Id_Iso2Plus "; 
	 szSql+=", CountryName "; 
	 szSql+=", CountryNameLocal "; 
	 szSql+=", IdGroupList "; 
	 szSql+=", IdContinent "; 
	 szSql+=", IdContinentRegion "; 
	 szSql+=", ContinentName "; 
	 szSql+=", ContinentRegion "; 
	 szSql+=", Capital ";
	 szSql+=" ) VALUES     (";
	 szSql+=" @IdCoutryISO3Plus "; 
	 szSql+=", @Id_Lng "; 
	 szSql+=", @IdGrpTypeGeo "; 
	 szSql+=", @Id_Iso2Plus "; 
	 szSql+=", @CountryName "; 
	 szSql+=", @CountryNameLocal "; 
	 szSql+=", @IdGroupList "; 
	 szSql+=", @IdContinent "; 
	 szSql+=", @IdContinentRegion "; 
	 szSql+=", @ContinentName "; 
	 szSql+=", @ContinentRegion "; 
	 szSql+=", @Capital "; 
	 szSql+=")";
	 // szSql+= " ; SELECT LAST_INSERT_ID()"
	//-----------------------------------------------------
	// TODO Para configurar el comando Insert recuperando la identidad. 
	// descomentar la linea anterior  


	oSqlCmdInsert.CommandText =szSql;
	 oSqlCmdInsert.Parameters.Add ("@IdCoutryISO3Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Id_Lng",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@IdGrpTypeGeo",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Id_Iso2Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@CountryName",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@CountryNameLocal",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@IdGroupList",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@IdContinent",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@IdContinentRegion",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@ContinentName",MySql.Data.MySqlClient.MySqlDbType.Enum);
	 oSqlCmdInsert.Parameters.Add ("@ContinentRegion",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Capital",MySql.Data.MySqlClient.MySqlDbType.Int32);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO UPDATE ---------------------------------------
	//----------------------------------------------------------------------
	 szSql="UPDATE tmst_geo_country SET " ;

	 szSql+="Id_Lng=@Id_Lng "; 
	 szSql+=", IdGrpTypeGeo=@IdGrpTypeGeo "; 
	 szSql+=", Id_Iso2Plus=@Id_Iso2Plus "; 
	 szSql+=", CountryName=@CountryName "; 
	 szSql+=", CountryNameLocal=@CountryNameLocal "; 
	 szSql+=", IdGroupList=@IdGroupList "; 
	 szSql+=", IdContinent=@IdContinent "; 
	 szSql+=", IdContinentRegion=@IdContinentRegion "; 
	 szSql+=", ContinentName=@ContinentName "; 
	 szSql+=", ContinentRegion=@ContinentRegion "; 
	 szSql+=", Capital=@Capital ";
	 szSql+=" WHERE ";
	 szSql+="(IdCoutryISO3Plus=@IdCoutryISO3Plus )"; 
	oSqlCmdUpdate.CommandText =szSql;


	 oSqlCmdUpdate.Parameters.Add ("@IdCoutryISO3Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Id_Lng",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@IdGrpTypeGeo",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Id_Iso2Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@CountryName",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@CountryNameLocal",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@IdGroupList",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@IdContinent",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@IdContinentRegion",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@ContinentName",MySql.Data.MySqlClient.MySqlDbType.Enum);
	 oSqlCmdUpdate.Parameters.Add ("@ContinentRegion",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Capital",MySql.Data.MySqlClient.MySqlDbType.Int32);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO DELETE  ---------------------------------------
	//----------------------------------------------------------------------
	szSql="DELETE FROM tmst_geo_country  ";
	 szSql+=" WHERE ";
	 szSql+="(IdCoutryISO3Plus=@IdCoutryISO3Plus )"; 

	oSqlCmdDelete.CommandText =szSql;
	 oSqlCmdDelete.Parameters.Add ("@IdCoutryISO3Plus",MySql.Data.MySqlClient.MySqlDbType.String);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO SELECT  exist ---------------------------------
	//----------------------------------------------------------------------
	szSql="SELECT ";
	 szSql+=" IdCoutryISO3Plus";
	szSql+=" FROM tmst_geo_country  ";

	 szSql+=" WHERE ";
	 szSql+="(IdCoutryISO3Plus=@IdCoutryISO3Plus )"; 
	oSqlCmdSelectExist.CommandText =szSql;
	 oSqlCmdSelectExist.Parameters.Add ("@IdCoutryISO3Plus",MySql.Data.MySqlClient.MySqlDbType.String);
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

	oSqlCmdSelectExist.Parameters["@IdCoutryISO3Plus"].Value=m_IdCoutryISO3Plus;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
	MySqlDataReader oDR=oSqlCmdSelectExist.ExecuteReader();
	 b=oDR.HasRows; 
	oDR.Close ();
            ClsMysql.FncClose();
	
	//.............................................................
	//........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
	//// } 
	//.............................................................
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
	oSqlCmdUpdate.Parameters["@IdCoutryISO3Plus"].Value=m_IdCoutryISO3Plus;
	oSqlCmdUpdate.Parameters["@Id_Lng"].Value=m_Id_Lng;
	oSqlCmdUpdate.Parameters["@IdGrpTypeGeo"].Value=m_IdGrpTypeGeo;
	oSqlCmdUpdate.Parameters["@Id_Iso2Plus"].Value=m_Id_Iso2Plus;
	oSqlCmdUpdate.Parameters["@CountryName"].Value=m_CountryName;
	oSqlCmdUpdate.Parameters["@CountryNameLocal"].Value=m_CountryNameLocal;
	oSqlCmdUpdate.Parameters["@IdGroupList"].Value=m_IdGroupList;
	oSqlCmdUpdate.Parameters["@IdContinent"].Value=m_IdContinent;
	oSqlCmdUpdate.Parameters["@IdContinentRegion"].Value=m_IdContinentRegion;
	oSqlCmdUpdate.Parameters["@ContinentName"].Value=m_ContinentName;
	oSqlCmdUpdate.Parameters["@ContinentRegion"].Value=m_ContinentRegion;
	oSqlCmdUpdate.Parameters["@Capital"].Value=m_Capital;
            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdUpdate.Connection = ClsMysql.MySqlConnection;
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
	oSqlCmdInsert.Parameters["@IdCoutryISO3Plus"].Value=m_IdCoutryISO3Plus;
	oSqlCmdInsert.Parameters["@Id_Lng"].Value=m_Id_Lng;
	oSqlCmdInsert.Parameters["@IdGrpTypeGeo"].Value=m_IdGrpTypeGeo;
	oSqlCmdInsert.Parameters["@Id_Iso2Plus"].Value=m_Id_Iso2Plus;
	oSqlCmdInsert.Parameters["@CountryName"].Value=m_CountryName;
	oSqlCmdInsert.Parameters["@CountryNameLocal"].Value=m_CountryNameLocal;
	oSqlCmdInsert.Parameters["@IdGroupList"].Value=m_IdGroupList;
	oSqlCmdInsert.Parameters["@IdContinent"].Value=m_IdContinent;
	oSqlCmdInsert.Parameters["@IdContinentRegion"].Value=m_IdContinentRegion;
	oSqlCmdInsert.Parameters["@ContinentName"].Value=m_ContinentName;
	oSqlCmdInsert.Parameters["@ContinentRegion"].Value=m_ContinentRegion;
	oSqlCmdInsert.Parameters["@Capital"].Value=m_Capital;
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
	//oSqlCnn.Dispose ();
	return !_mErrorBoolean;
	}//--------------------------------------------------------
//----------------FncSqlFind------------------------------
//--------------------------------------------------------
public bool FncSqlFind(String IdCoutryISO3Plus) {
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
	oSqlCmdSelect.Parameters["@IdCoutryISO3Plus"].Value=IdCoutryISO3Plus;
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
			m_IdCoutryISO3Plus = oDR["IdCoutryISO3Plus"].ToString().Trim();
			m_Id_Lng = oDR["Id_Lng"].ToString().Trim();
			m_IdGrpTypeGeo = oDR["IdGrpTypeGeo"].ToString().Trim();
			m_Id_Iso2Plus = oDR["Id_Iso2Plus"].ToString().Trim();
			m_CountryName = oDR["CountryName"].ToString().Trim();
			m_CountryNameLocal = oDR["CountryNameLocal"].ToString().Trim();
			m_IdGroupList = oDR["IdGroupList"].ToString().Trim();
			m_IdContinent = oDR["IdContinent"].ToString().Trim();
			m_IdContinentRegion = oDR["IdContinentRegion"].ToString().Trim();
			m_ContinentName = Convert.ToString(oDR["ContinentName"].ToString().Trim());
			m_ContinentRegion = oDR["ContinentRegion"].ToString().Trim();
			m_Capital = Convert.ToInt32(oDR["Capital"].ToString().Trim());
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
public bool FncSqlDelete(String IdCoutryISO3Plus) {
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
	oSqlCmdDelete.Parameters["@IdCoutryISO3Plus"].Value=IdCoutryISO3Plus;
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
public bool FncSqlExist(String IdCoutryISO3Plus) {
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
	oSqlCmdSelectExist.Parameters["@IdCoutryISO3Plus"].Value=IdCoutryISO3Plus;

	 oSqlCmdSelectExist.Connection= cls.bbdd.ClsMysql.MySqlConnection;
	MySqlDataReader oDR=oSqlCmdSelectExist.ExecuteReader();
	 b=oDR.HasRows; 
	oDR.Close ();
            ClsMysql.FncClose();
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

public String IdCoutryISO3Plus
{
	set {
		string sz=value.Trim();
		if(sz.Length>7) 
		{ 
		sz=sz.Substring(0,6);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_IdCoutryISO3Plus because is it too long,MaxLength=7";
		}
	m_IdCoutryISO3Plus=sz;

	}
	get {return m_IdCoutryISO3Plus;}
}

//................................

public String Id_Lng
{
	set {
		string sz=value.Trim();
		if(sz.Length>3) 
		{ 
		sz=sz.Substring(0,2);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_Id_Lng because is it too long,MaxLength=3";
		}
	m_Id_Lng=sz;

	}
	get {return m_Id_Lng;}
}

//................................

public String IdGrpTypeGeo
{
	set {
		string sz=value.Trim();
		if(sz.Length>3) 
		{ 
		sz=sz.Substring(0,2);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_IdGrpTypeGeo because is it too long,MaxLength=3";
		}
	m_IdGrpTypeGeo=sz;

	}
	get {return m_IdGrpTypeGeo;}
}

//................................

public String Id_Iso2Plus
{
	set {
		string sz=value.Trim();
		if(sz.Length>5) 
		{ 
		sz=sz.Substring(0,4);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_Id_Iso2Plus because is it too long,MaxLength=5";
		}
	m_Id_Iso2Plus=sz;

	}
	get {return m_Id_Iso2Plus;}
}

//................................

public String CountryName
{
	set {
		string sz=value.Trim();
		if(sz.Length>52) 
		{ 
		sz=sz.Substring(0,51);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_CountryName because is it too long,MaxLength=52";
		}
	m_CountryName=sz;

	}
	get {return m_CountryName;}
}

//................................

public String CountryNameLocal
{
	set {
		string sz=value.Trim();
		if(sz.Length>45) 
		{ 
		sz=sz.Substring(0,44);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_CountryNameLocal because is it too long,MaxLength=45";
		}
	m_CountryNameLocal=sz;

	}
	get {return m_CountryNameLocal;}
}

//................................

public String IdGroupList
{
	set {
		string sz=value.Trim();
		if(sz.Length>20) 
		{ 
		sz=sz.Substring(0,19);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_IdGroupList because is it too long,MaxLength=20";
		}
	m_IdGroupList=sz;

	}
	get {return m_IdGroupList;}
}

//................................

public String IdContinent
{
	set {
		string sz=value.Trim();
		if(sz.Length>3) 
		{ 
		sz=sz.Substring(0,2);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_IdContinent because is it too long,MaxLength=3";
		}
	m_IdContinent=sz;

	}
	get {return m_IdContinent;}
}

//................................

public String IdContinentRegion
{
	set {
		string sz=value.Trim();
		if(sz.Length>5) 
		{ 
		sz=sz.Substring(0,4);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_IdContinentRegion because is it too long,MaxLength=5";
		}
	m_IdContinentRegion=sz;

	}
	get {return m_IdContinentRegion;}
}

//................................

public String  ContinentName
{
	set {
	m_ContinentName=value;
	}
	get {return m_ContinentName;}
}

//................................

public String ContinentRegion
{
	set {
		string sz=value.Trim();
		if(sz.Length>26) 
		{ 
		sz=sz.Substring(0,25);
		_mErrorBoolean=true;
		_mErrorString="Trimmed m_ContinentRegion because is it too long,MaxLength=26";
		}
	m_ContinentRegion=sz;

	}
	get {return m_ContinentRegion;}
}

//................................

public Int32 Capital
{
	set {
	m_Capital=value;
	}
	get {return m_Capital;}
}

#endregion VALORES_GETSET

}
}
