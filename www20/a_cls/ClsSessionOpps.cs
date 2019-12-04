using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testudines.cls
{
    public class ClsSessionOpps
    {
        public enum eOppsLevel { ico_msg_erro, ico_msg_info, ico_msg_succ, ico_msg_warn }
        private Int32 m_OppsIdMsg = 0;
        private string m_OppsTitle = "";
        private string m_OppsSubject = "";
        private string m_OppsBody = "";
        private string m_OppsReturnULLI = "";

        // se utiliza para pasar mensajes explicitos
        public void FncOppsSet(eOppsLevel OppsLevel, string szOppsTitle, string szOppsSubject, string szOppsBody, string szOppsReturnULLI)
        {
            m_OppsTitle = szOppsTitle;
            m_OppsSubject = szOppsSubject;
            m_OppsBody = szOppsBody;
            m_OppsReturnULLI = szOppsReturnULLI;


        }
        public  void FncOppsIdMsgSet(int OppsIdMsg)
        {
            FncOppsClear();
            m_OppsIdMsg = OppsIdMsg;
            System.Web.HttpContext.Current.Session["oSessionOpps"] = this;

        }
        public void   FncOppsClear()
        {
            m_OppsIdMsg=0;
            m_OppsTitle = "";
            m_OppsSubject = "";
            m_OppsBody = "";
            m_OppsReturnULLI = "";
        }
      
        public Int32  OppsIdMsg { 
            get { return m_OppsIdMsg; }
            set { m_OppsIdMsg=value ; }
        }
        public string OppsTitle { 
            get { return m_OppsTitle; }
            set { m_OppsTitle=value ; }
        }
        public string OppsSubject { 
            get { return m_OppsSubject; } 
            set { m_OppsSubject=value; } 
        }
        
        public string OppsBody 
        { 
            get { return m_OppsBody; } 
            set { m_OppsBody=value ; } 
        }
        public string OppsReturnULLI {
        get { return m_OppsReturnULLI; }
        set { m_OppsReturnULLI=value; }
        }

    }
}
