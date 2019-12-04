using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Globalization;
/// <summary>
/// Dada una longitud y año calcula las horas de sol
/// 
/// </summary>
/// 
namespace testudines.cls
{
    public class ClsSunHourCalc
    {
        IFormatProvider cultureES = new CultureInfo("es-ES", true);
        //private int m_Año = 0;
        //private double m_pLatitud = 0;
        const double c_diasAño = 365.25;
        const double c_InclinacionEje = 23.27;
        const double c_HorasDia = 24.0;
        double dDiaHorasMax = -1;
        double dDiaHorasMin = 25;

        public ClsSunHourCalc()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        // Solsticio de verano 20 ó 21 de junio 
        private DateTime FncDateFromString(string szDia, string szMes, string szAno)
    {
        if (szDia.Length < 2) szDia = "0" + szDia;
        if (szMes.Length < 2) szMes = "0" + szMes;
        string szDate= szDia+"/"+szMes+ "/"+szAno;
        DateTime oDate = DateTime.ParseExact(szDate, "dd/MM/yyyy", cultureES);
        return oDate;
        

    }
        // calcula las horas de sol del dia 15 para una latitud y año
        public double FncCalAnoMes15(double platitud, int pAno, int pMes)
        {
            double dSunHours = 0;
            //DateTime.Parse(dateString, culture);
            //CultureInfo.CreateSpecificCulture("en-US")
            string szDate = "23/12/" + (pAno - 1).ToString();

            DateTime dSolsticioInvierno = FncDateFromString("23", "12", (pAno - 1).ToString());
            // DateTime dSolsticioInvierno = Convert.ToDateTime(szDate);
            //szDate = "15/" + pMes.ToString() + "/" + (pAno).ToString();
            //DateTime dDia = Convert.ToDateTime(szDate );
            DateTime dDia = FncDateFromString("15", pMes.ToString(), pAno .ToString());
            int iSolsticioInvierno = dSolsticioInvierno.DayOfYear;
            int iDif = dDia.DayOfYear - iSolsticioInvierno; // dias hasta el solticio de invierno
            dSunHours = FncCalHoras(platitud, iDif);
            return dSunHours;
        }

        public string FncHtmlSunAnoMeses(double pLatitud, int pAno, int pMesInicial)
        {

            double dHorasSol = 0;
            string szTexto = "<h2> Horas de sol para la latitud " + pLatitud.ToString() + "º en el año " + pAno.ToString() + "</h2>\n";
            szTexto += "<table cellspacing=\"0\" cellpadding=\"1\" border=\"1\" style=\"font-size:13px;\"> \n";

            DateTime dSolsticioInvierno = dSolsticioInvierno = FncDateFromString("23", "12", (pAno - 1).ToString());
            int iSolsticioInvierno = dSolsticioInvierno.DayOfYear;
            DateTime dDia = dSolsticioInvierno = FncDateFromString("31", "12", (pAno - 1).ToString());
            szTexto += "<tr><td>Fecha</td><td>Horas de Sol</br>del dia</td><td>Total del<br> mes</td><td>Media</td></tr>\n";
            int iDif = 0;
            dDiaHorasMax = -1;
            dDiaHorasMin = 25;
            double dSumaHorasMesAño = 0;
            double dSumaHorasMes = 0;
            double dMediaHorasMes = 0;
             string szDate="";
            for (int n = 1; n < 13; n++)
            {
                szDate = "1/" + n.ToString() + "/" + (pAno).ToString();
               // dDia=DateTime.ParseExact(szDate, "dd/MM/yyyy", cultureES);
                dDia = FncDateFromString("1", n.ToString() ,pAno.ToString());
                if (pMesInicial == 6) dDia = dDia.AddMonths(5);
                iDif = dDia.DayOfYear - iSolsticioInvierno;
                // acumulacion del mes
                dSumaHorasMes = 0;
                dMediaHorasMes = 0;

                int iDiasMes = 0;
                FncCalSumaMes(pLatitud, pAno, dDia.Month, ref dSumaHorasMes, ref dMediaHorasMes, ref iDiasMes, ref dSumaHorasMesAño);

                //String.Format("{0:0,0.0}", 12345.67);     // "12,345.7"
                //String.Format("{0,10:0.0}", -123.4567);   // "    -123.5"
                //value.ToString("0.00", CultureInfo.InvariantCulture)
                string szSumaHorasMes = String.Format("{0:0.00}", dSumaHorasMes);
                string szMediaHorasMes = String.Format("{0:0.00}", dMediaHorasMes);

                szTexto += "<tr><td>" + dDia.ToShortDateString() + "</td><td>" + FncCal(pLatitud, iDif, ref dHorasSol) + "</td><td>" + szSumaHorasMes + "</td><td>" + szMediaHorasMes + "</td></tr>\n";
                int m = n;
                if (pMesInicial != 1) m = m + 5;
                
                switch (m)
                {
                    case 3:
                        // 20 al 21 de marzo
                        //szDate="21/" + m.ToString() + "/" + (pAno - 1).ToString();
                        dDia = FncDateFromString("21", m.ToString(), (pAno - 1).ToString());
                        iDif = dDia.DayOfYear - iSolsticioInvierno;
                        szTexto += "<tr><td><b>" + dDia.ToShortDateString() + "</b></td><td>" + FncCal(pLatitud, iDif, ref dHorasSol) + "</td><td></td><td></td></tr>\n";
                        break;

                    case 6:
                        // 22 de junio
                        //szDate = "22/" + m.ToString() + "/" + (pAno - 1).ToString();
                        dDia = FncDateFromString("22", m.ToString(), (pAno - 1).ToString());
                        iDif = dDia.DayOfYear - iSolsticioInvierno;
                        szTexto += "<tr><td ><b>" + dDia.ToShortDateString() + "</b></td><td>" + FncCal(pLatitud, iDif, ref dHorasSol) + "</td><td></td><td></td></tr>\n";
                        break;
                    case 9:
                        // 22 al 23 de septiembre 
                        //szDate  = "22/" + m.ToString() + "/" + (pAno - 1).ToString();

                        dDia = FncDateFromString("22", m.ToString(), (pAno - 1).ToString());
                        iDif = dDia.DayOfYear - iSolsticioInvierno;
                        szTexto += "<tr><td><b>" + dDia.ToShortDateString() + "</b></td><td>" + FncCal(pLatitud, iDif, ref dHorasSol) + "</td><td></td><td></td></tr>\n";
                        break;
                    case 12:
                        // 21 de dici
                       // szDate  ="21/" + m.ToString() + "/" + (pAno - 1).ToString();
                        dDia = FncDateFromString("21", m.ToString(), (pAno - 1).ToString());
                        iDif = dDia.DayOfYear - iSolsticioInvierno;
                        szTexto += "<tr><td><b>" + dDia.ToShortDateString() + "</b></td><td>" + FncCal(pLatitud, iDif, ref dHorasSol) + "</td><td></td><td></td></tr>\n";
                        break;
                }
            }
            szTexto += "</table>";
            szTexto += "El dia mas corto tiene:  " + String.Format("{0:0.00}", dDiaHorasMin) + " horas.";
            szTexto += "<br/>El dia mas largo tiene: " + String.Format("{0:0.00}", dDiaHorasMax) + " horas.";
            // INCREMENTO O DECREMENTO POR DIA
            double dIncremento = Math.Round(((dDiaHorasMax - dDiaHorasMin) * 0.328767123287671), 2); //  PARA PASARLO A MINUTOS 182.5), 4);
            szTexto += "<br/>Desde el solticio de invierno al de verano los dias aumentan: " + string.Format("{0:0.00}", dIncremento) + " minutos cada dia";
            szTexto += "<br/>Desde el solticio de verano al de invierno los dias diminuyen: " + string.Format("{0:0.00}", dIncremento) + " minutos cada dia";
            return szTexto;
        }
        public string FncCalAno(double pLatitud, int pAno)
        {
            double dHoras = 0;
            string szTexto = "<table border=\"1px\" marging=\"0\" padding=\"2px\";> \n";
           DateTime dSolsticioInvierno = FncDateFromString("23", "12", pAno.ToString());

            int iSolsticioInvierno = dSolsticioInvierno.DayOfYear;
           // string szDate = "31/12/" + (pAno - 1).ToString();
            //DateTime dDia = DateTime.ParseExact(szDate, "dd/MM/yyyy", cultureES);
            DateTime dDia = FncDateFromString("31", "12", (pAno - 1).ToString());

            szTexto += "<tr><td>Fecha</td><td>Dias desde<br/>solsticio</td><td>Horas <br/>de Sol</td></tr>\n";
            for (int n = 1; n < 366; n++)
            {

                dDia = dDia.AddDays(1);
                int iDia = dDia.DayOfYear;
                int iDif = iDia - iSolsticioInvierno;
                //szTexto +="<tr><td>"+dDia.ToLongDateString()+"</td><td>" + iDif.ToString ()+"</td><td>" +  FncCal (pLatitud,iDif ) +"</td></tr>\n";
                szTexto += "<tr><td>" + dDia.ToShortDateString() + "</td><td>" + iDif.ToString() + "</td><td>" + FncCal(pLatitud, iDif, ref dHoras) + "</td></tr>\n";
            }
            return szTexto + "</table>";
        }
        public void FncCalSumaMes(double pLatitud, int pAno, int pMes, ref double dSumaHorasMes, ref double dMediaHorasMes, ref int pDiasMes, ref double dSumaHorasMesAño)
        {

            double dHorasSol = 0;
            string szDia ="1/" + pMes.ToString() + "/" + (pAno).ToString();
            DateTime dDia =FncDateFromString ("1",pMes.ToString (),pAno.ToString ());
            //DateTime dDia = DateTime.ParseExact(szDia, "dd/MM/yyyy", cultureES);
            DateTime dSolsticioInvierno = FncDateFromString("23", "12", pAno.ToString());
            int iSolsticioInvierno = dSolsticioInvierno.DayOfYear;
            double dSuma = 0;
            int iDiasMes = 0;
            for (int n = 0; n < 32; n++)
            {


                int iDiaAno = dDia.DayOfYear;
                int iDif = iDiaAno - iSolsticioInvierno;
                if (dDia.Month == pMes)
                {
                    iDiasMes += 1;
                    dHorasSol = 0;
                    FncCal(pLatitud, iDif, ref dHorasSol);
                    dSuma += dHorasSol;
                    if (dDiaHorasMax < dHorasSol) dDiaHorasMax = dHorasSol;
                    if (dDiaHorasMin > dHorasSol) dDiaHorasMin = dHorasSol;
                }
                dDia = dDia.AddDays(1);
            }
            dSumaHorasMes = dSuma;
            dSumaHorasMesAño += dSuma;
            dMediaHorasMes = dSuma / iDiasMes;
            pDiasMes = iDiasMes;

        }
        public string FncCal(double pLatitud, int pNumDiasSolticioVerano, ref double dHorasSol)
        {



            //  V=tan(L*PI/180)*tan(T*PI/180)*cos(2*PI*(D/Y));
            string sHoras = "";
            double dV = Math.Tan(pLatitud * Math.PI / 180) * Math.Tan(c_InclinacionEje * Math.PI / 180) * Math.Cos(2 * Math.PI * (pNumDiasSolticioVerano / c_diasAño));

            //
            //if (V < -1) { V = -1; }
            //        else if (V>1) {V=1;}

            if (dV < -1)
            {
                dV = -1;
            }
            else
            {
                if (dV > 1)
                {
                    dV = 1;
                }
            }
            //
            // X=(H/PI)*acos(V);
            double dH = (c_HorasDia / Math.PI) * Math.Acos(dV);
            dHorasSol = dH;
            //
            // Convertir horas a cristiano

            int iHoras = (int)dH;
            double dHorasDecimal = dH - iHoras;

            int iMinutos = (int)(dHorasDecimal * 60);
            int iDia = (int)(dH * 200 / 15);
            string szDivAnchoDia = iDia.ToString();
            string szDivAnchoNoche = (200 - iDia).ToString(); ;
            // <div style="width: 250px; height: 100%; background-color: gray;" id="pepe2">sss&nbsp;</div>
            szDivAnchoDia = "<div style=\"background-color:grey;\"> <span style=\"width: " + szDivAnchoDia + "px; height: 100%; background-color:lightyellow;\">";

            int iAncho = (int)((dH * 200 / 15));
            string szMinutos = iMinutos.ToString();
            if (szMinutos.Length == 1)
            {
                szMinutos = "0" + szMinutos;
            }
            string szHoras = iHoras.ToString();
            if (szHoras.Length == 1)
            {
                szHoras = "0" + szHoras;
            }
            sHoras = szDivAnchoDia + szHoras + ":" + szMinutos + "</span></div>";

            return sHoras;
        }


        private double FncCalHoras(double pLatitud, int pNumDiasSolticioVerano)
        {



            //  V=tan(L*PI/180)*tan(T*PI/180)*cos(2*PI*(D/Y));

            double dV = Math.Tan(pLatitud * Math.PI / 180) * Math.Tan(c_InclinacionEje * Math.PI / 180) * Math.Cos(2 * Math.PI * (pNumDiasSolticioVerano / c_diasAño));

            //
            //if (V < -1) { V = -1; }
            //        else if (V>1) {V=1;}

            if (dV < -1)
            {
                dV = -1;
            }
            else
            {
                if (dV > 1)
                {
                    dV = 1;
                }
            }
            //
            // X=(H/PI)*acos(V);
            double dHorasSol = (c_HorasDia / Math.PI) * Math.Acos(dV);
            return dHorasSol;

            //
            // Convertir horas a cristiano
        }

        //calcula las horas de sol para cada mes y una latitud dada
        public void FncCalSunMonthValues(Double pLatitud, int pAno, ref Double[] pfSunMonthHourMed, ref Double[] pfSunMonthHourSum, ref Double pfSunHourYear, ref Double pfSunDayHourMax, ref Double pfSunDayHourMin, ref Double pfSunHourDayIncrement)
        {

         //   Double dHorasSol = 0;

            
            DateTime dSolsticioInvierno = FncDateFromString("23", "12", pAno.ToString());
            
            int iSolsticioInvierno = dSolsticioInvierno.DayOfYear;
            //string szDia = "31/12/" + (pAno - 1).ToString();
            //DateTime dDia = DateTime.ParseExact(szDia, "dd/MM/yyyy", cultureES);
            DateTime dDia = FncDateFromString("31", "1", (pAno - 1).ToString());
            //    szTexto += "<tr><td>Fecha</td><td>Horas de Sol</br>del dia</td><td>Total del<br> mes</td><td>Media</td></tr>\n";
            int iDif = 0;
            dDiaHorasMax = -1;
            dDiaHorasMin = 25;
            Double dSumaHorasMesAño = 0;
            Double dSumaHorasMes = 0;
            Double dMediaHorasMes = 0;
            Double[] adSumaHorasMes = new Double[13];
            Double[] adMediaHorasMes = new Double[13];


            for (int n = 1; n < 13; n++)
            {

                //szDia = "15/" + n.ToString() + "/" + (pAno).ToString();

                 //dDia = DateTime.ParseExact(szDia, "dd/MM/yyyy", cultureES);
                 dDia = FncDateFromString("15", n.ToString(), pAno.ToString());
                iDif = dDia.DayOfYear - iSolsticioInvierno;
                // acumulacion del mes
                dSumaHorasMes = 0;
                dMediaHorasMes = 0;

                int iDiasMes = 0;
                FncCalSumaMes(pLatitud, pAno, dDia.Month, ref dSumaHorasMes, ref dMediaHorasMes, ref iDiasMes, ref dSumaHorasMesAño);
                adSumaHorasMes[n] = dSumaHorasMes;
                adMediaHorasMes[n] = dMediaHorasMes;
            }
            Double d = Math.Round(((dDiaHorasMax - dDiaHorasMin) * 0.328767123287671), 2);
            pfSunHourDayIncrement = d;
            pfSunDayHourMax = dDiaHorasMax;
            pfSunDayHourMin = dDiaHorasMin;

            pfSunHourYear = dSumaHorasMesAño;
            for (int n = 1; n < 13; n++)
            {
                pfSunMonthHourMed[n] = adMediaHorasMes[n];
                pfSunMonthHourSum[n] = adSumaHorasMes[n];
            }
            //String DayMoreShortHours =  String.Format("{0:0.00}", ) + "HH";;
            //String DayMoreLongHours =    String.Format("{0:0.00}", ) + "HH.";
            //String DayIncrementeMinutes = String.Format("{0:0.00}", dIncremento) + "MM";


        }
    }

}