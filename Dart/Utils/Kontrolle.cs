using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Programm.Utils
{
    class Kontrolle
    {
        
        public Boolean Check(String pWurf1, String pWurf2, String pWurf3)
        {
            
            if (pWurf1.Trim() == "")
            {
                MessageBox.Show("Der erste Wurf fehlt");
                return false;
            }
            if (pWurf2.Trim() == "")
            {
                MessageBox.Show("Der zweite Wurf fehlt");
                return false;
            }
            if (pWurf3.Trim() == "")
            {
                MessageBox.Show("Der dritte Wurf fehlt");
                //MessageBox.Show("Der dritte Wurf fehlt");
                return false;
            }

            bool bWurf1 = false;
            bool bWurf2 = false;
            bool bWurf3 = false;


            string sTemp;
            int iTemp;
            char ctemp;
         
            Boolean bBuchstabe = true;
            for (int iL1 = 0; iL1 < pWurf1.Length; iL1++)
            {
                sTemp = pWurf1.Substring(iL1, 1);
                ctemp = Convert.ToChar(sTemp);
                iTemp = Convert.ToInt32(ctemp);
                if (iTemp > 64 && iTemp < 91)
                {
                    MessageBox.Show("Es wurde bei Wurf 1 ein Großbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;

                }
                if (iTemp > 96 && iTemp < 123)
                {
                    MessageBox.Show("Es wurde bei Wurf 2 ein Kleinbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;

                }
            }
    
            for (int iL1 = 0; iL1 < pWurf2.Length; iL1++)
            {
                sTemp = pWurf2.Substring(iL1, 1);
                ctemp = Convert.ToChar(sTemp);
                iTemp = Convert.ToInt32(ctemp);
                if (iTemp > 64 && iTemp < 91)
                {
                    MessageBox.Show("Es wurde bei Wurf 2 ein Großbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;

                }
                if (iTemp > 96 && iTemp < 123)
                {
                    MessageBox.Show("Es wurde bei Wurf 2 ein Kleinbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;
                }
            }
            
            for (int iL1 = 0; iL1 < pWurf3.Length; iL1++)
            {
                sTemp = pWurf3.Substring(iL1, 1);
                ctemp = Convert.ToChar(sTemp);
                iTemp = Convert.ToInt32(ctemp);
                if (iTemp > 64 && iTemp < 91)
                {
                    MessageBox.Show("Es wurde bei Wurf 3 ein Kleinbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;
                }
                if (ctemp > 96 && ctemp < 123)
                {
                    MessageBox.Show("Es wurde bei Wurf 3 ein Kleinbuchstabe eingegeben");
                    bBuchstabe = false;
                    return false;
                }
            }

            if (bBuchstabe)
            {
                if (Convert.ToInt32(pWurf1)<61)
                {
                    bWurf1 = true;
                }
                if (Convert.ToInt32(pWurf2) < 61)
                {
                    bWurf2 = true;
                }
                if (Convert.ToInt32(pWurf3) < 61)
                {
                    bWurf3 = true;
                }
            }



            if (bWurf1 == false || bWurf2 == false || bWurf3 == false)
            {
                MessageBox.Show("Die eingegeben Zahl war über 60");
                return false;
            }
            return true;
        }
    }
}
