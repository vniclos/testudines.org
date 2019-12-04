using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testudines.cls.tools
{
    public class ClsAccordion_dl
    {
        private string m_html = "";
        private int m_SectionCounter = 0;
        private string m_IdSeccionPrefij = "";
        private const string m_gotop = "<br/><a href=\"#ind_gotop\"  alt=\"go top\" title=\"Go top\"><img  class=\"gotop\" src=\"/a_img/a_site/ico16/gotop.gif\" alt=\"gotop\"></a><br/>";
        public ClsAccordion_dl( )
        {
            m_IdSeccionPrefij = "accfirst";
            m_SectionCounter = 0;

        }
        public void Init(string IdSeccionPrefij)
        {
            m_IdSeccionPrefij = IdSeccionPrefij;
            m_html = "";
            m_SectionCounter = 0;
        }
        public void addSecction(string pTitle, string pHtmSection, bool pIsOpen, bool pShow_ind_gotop)
        {
           
          m_SectionCounter++;
          string szSectionId = (m_IdSeccionPrefij + m_SectionCounter.ToString()).ToLower() ;
          string szHtml="";
          szHtml += "\n  <!--  START SECTION "+  pTitle                +" -->";
          szHtml += "\n       <h2 class=\"h2_secc\" >" + pTitle;
          

          szHtml += "</h2>";
          szHtml += "\n        <div id=\"" + szSectionId + "\">";
          szHtml += pHtmSection;
          if (pShow_ind_gotop) szHtml += m_gotop;
          szHtml += "\n        </div>";
          szHtml += "\n  <!--  END SECTION " + pTitle + " -->";

          m_html += szHtml;
        }

        public void addSecction_accordion(string pTitle, string pHtmSection, bool pIsOpen, bool pShow_ind_gotop)
        {
            /*
              <dl class="accordion" data-accordion>
                  <dd class="accordion-navigation">
                      <a href="#panel1b">Accordion 1</a>
                      <div id="panel1b" class="content active">
                      </div>
              </dd>
            </dl>
             * */

            m_SectionCounter++;
            string szSectionId = (m_IdSeccionPrefij + m_SectionCounter.ToString()).ToLower();
            string szHtml = "";
            string szOpen = "";

            if (pIsOpen) szOpen = " active";

            szHtml += "\n  <!--  START SECTION " + pTitle + " -->";
            szHtml += "\n   <dd class=\"accordion-navigation\">";
            szHtml += "\n       <a href=\"#" + szSectionId + "\">" + pTitle + "</a>";
            szHtml += "\n        <div id=\"" + szSectionId + "\" class=\"content" + szOpen + "\">";
            szHtml += pHtmSection;
            if (pShow_ind_gotop) szHtml += m_gotop;
            szHtml += "\n        </div>";
            szHtml += "\n   </dd>";
            szHtml += "\n  <!--  END SECTION " + pTitle + " -->";

            m_html += szHtml;
        }
        public string html
        {
            get
            {

                //<dl class="accordion" data-accordion>
                return "\n" + m_html + "\n";

            }
        }

        public string htmlacordion
        { 
            get{
              
                //<dl class="accordion" data-accordion>
                return "\n   <dl class=\"accordion\" data-accordion>\n" + m_html + "\n   </dl>";
                
            }
        }
    }
}