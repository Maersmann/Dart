using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programm.Finish
{
    public class FinishWeg : FinishText
    {
        static private int[] LIST_ONCE = { 25, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        static private int[] LIST_TRIPLE = { 60, 57, 54, 51, 48, 45, 42, 39, 36, 33, 30, 27, 24, 21, 18, 15, 12, 9, 6, 3 };

        static private int[] LIST_DOUBLE_CHECK = { 40, 32, 24, 38, 16, 18, 12, 36, 20, 34, 50, 30, 28, 26, 22, 14, 10, 8, 6, 4, 2 };

        private int _FinishZahl;

        private int _FinishEins;
        private int _FinishZwei;
        private int _FinishDrei;

        private char _FinishEinsFeld;
        private char _FinishZweiFeld;
        private char _FinishDreiFeld;

        public FinishWeg()
        {
           
            InitialisiereWerte();
        }

        public bool AktualisiereFinsish(int pNewFinishzahl , int pAnzahlWuerfe)
        {
            _FinishZahl = pNewFinishzahl;
            InitialisiereWerte();
            if (pNewFinishzahl <=1)
            {
                return false;
            }
            return ErrechneFinsishWeg(pAnzahlWuerfe);
        }

        public String getWurf1() { return getText(_FinishEins, _FinishEinsFeld); }

        public String getWurf2() { return getText(_FinishZwei, _FinishZweiFeld); }

        public String getWurf3() { return getText(_FinishDrei, _FinishDreiFeld); }

        private void InitialisiereWerte()
        {
            _FinishEins = 0;
            _FinishZwei = 0;
            _FinishDrei = 0;
            _FinishEinsFeld = ' ';
            _FinishZweiFeld = ' ';
            _FinishDreiFeld = ' ';
        }

        private bool ErrechneFinsishWeg(int pAnzahlWuerfe)
        {
            int PunktzahlOhneDoppel;

            if (_FinishZahl <= 40 && pAnzahlWuerfe > 0)
            {
                if (_FinishZahl % 2 == 0)
                {
                    _FinishEins = _FinishZahl;
                    _FinishEinsFeld = WEG_DOPPEL;
                    return true;
                }

            }

            
                
                
            if (pAnzahlWuerfe > 1)
            {
                for (int i = 0; i < LIST_DOUBLE_CHECK.Length; i++)
                {
                    PunktzahlOhneDoppel = _FinishZahl - LIST_DOUBLE_CHECK[i];
                    for (int j = 0; j < LIST_ONCE.Length; j++)
                    {
                        if (LIST_ONCE[j] == PunktzahlOhneDoppel)
                        {
                            _FinishEins = LIST_ONCE[j];
                            _FinishEinsFeld = WEG_EINFACH;

                            _FinishZwei = LIST_DOUBLE_CHECK[i];
                            _FinishZweiFeld = WEG_DOPPEL;
                            return true;
                        }
                    }

                    for (int j = 0; j < LIST_TRIPLE.Length; j++)
                    {
                        if (LIST_TRIPLE[j] == PunktzahlOhneDoppel)
                        {
                            _FinishEins = LIST_TRIPLE[j];
                            _FinishEinsFeld = WEG_TRIPLE;

                            _FinishZwei = LIST_DOUBLE_CHECK[i];
                            _FinishZweiFeld = WEG_DOPPEL;
                            return true;
                        }
                    }
                }
            }

            if (pAnzahlWuerfe > 2)
            {
                for (int i = 0; i < LIST_DOUBLE_CHECK.Length; i++)
                {
                    PunktzahlOhneDoppel = _FinishZahl - LIST_DOUBLE_CHECK[i];
                    for (int j = 0; j < LIST_TRIPLE.Length; j++)
                    {
                        for (int k = 0; k < LIST_ONCE.Length; k++)
                        {
                            if ((LIST_TRIPLE[j] + LIST_ONCE[k]) == PunktzahlOhneDoppel)
                            {
                                _FinishEins = LIST_TRIPLE[j];
                                _FinishEinsFeld = WEG_TRIPLE;

                                _FinishZwei = LIST_ONCE[k];
                                _FinishZweiFeld = WEG_EINFACH;

                                _FinishDrei = LIST_DOUBLE_CHECK[i];
                                _FinishDreiFeld = WEG_DOPPEL;
                                return true;
                            }
                        }

                    }
                }
            }

            if (pAnzahlWuerfe > 2)
            {
                for (int i = 0; i < LIST_DOUBLE_CHECK.Length; i++)
                {
                    PunktzahlOhneDoppel = _FinishZahl - LIST_DOUBLE_CHECK[i];
                    for (int j = 0; j < LIST_TRIPLE.Length; j++)
                    {
                        for (int k = 0; k < LIST_TRIPLE.Length; k++)
                        {
                            if ((LIST_TRIPLE[j] + LIST_TRIPLE[k]) == PunktzahlOhneDoppel)
                            {
                                _FinishEins = LIST_TRIPLE[j];
                                _FinishEinsFeld = WEG_TRIPLE;

                                _FinishZwei = LIST_TRIPLE[k];
                                _FinishZweiFeld = WEG_TRIPLE;

                                _FinishDrei = LIST_DOUBLE_CHECK[i];
                                _FinishDreiFeld = WEG_DOPPEL;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
