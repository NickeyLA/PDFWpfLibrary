using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFWpfLIbrary
{
    public static class GetPath
    {
        private static Dictionary<string, string> PDFList = new Dictionary<string, string>
        {
            { "10-1-1-", "10-1-1-informacija-informacionnaja-gramotnosti-kultura.pdf"},
            { "10-2-1-", "10-2-1-podhody-k-izmereniju-informacii.pdf"},
            { "10-3-1-", "10-3-1-informacionnye-svjazi-v-sistemah-razlichnoj prirody.pdf"},
            { "10-4-1-obrabotka-informacii.pdf", "10-4-1-obrabotka-informacii.pdf"},
            { "10-5-1-peredacha-i-hranenie-informacii.pdf", "10-5-1-peredacha-i-hranenie-informacii.pdf"},
            { "10-6-1-", "10-6-1-istorija-razvitija-vt.pdf"},
            { "10-7-1-", "10-7-1-osnovopolagajushhie-principy-ustrojstva-jevm.pdf"},
            { "10-8-1-", "10-8-1-programmnoe-obespechenie-kompjutera.pdf"},
            { "10-9-1-", "10-9-1-fajlovaja-sistema-kompjutera.pdf"},
            { "10-10-1-", "10-10-1-predstavlenie-chisel-v-pozicionnyh-cc.pdf"},
            { "10-11-1-", "10-11-1-perevod-chisel-iz-odnoj-sistemy-schislenija-v-druguju.pdf"},
            { "10-12-1-", "10-12-1-arifmeticheskie-operacii-v-pozicionnyh-sistemah-schislenija.pdf"},
            { "10-13-1-", "10-13-1-predstavlenie-chisel-v-kompjutere.pdf"},
            { "10-14-1-", "10-14-1-kodirovanie-tekstovoj-informacii.pdf"},
            { "10-15-1-", "10-15-1-kodirovanie-graficheskoj-informacii.pdf"},
            { "10-16-1-", "10-16-1-kodirovanie-zvukovoj-informacii.pdf"},
            { "10-17-1-", "10-17-1-nekotorye-svedenija-iz-teorii-mnozhestv.pdf"},
            { "10-18-1-", "10-18-1-algebra-logiki.pdf"},
            { "10-19-1-", "10-19-1-tablicy-istinnosti.pdf"},
            { "10-20-1-", "10-20-1-preobrazovanie-logicheskih-vyrazhenij.pdf"},
            { "10-21-1-", "10-21-1-elementy-shemotehniki.pdf"},
            { "10-22-1-", "10-22-1-logicheskie-zadachi.pdf"},
            { "10-23-1-", "10-23-1-tekstovye-dokumenty.pdf"},
            { "10-24-1-", "10-24-1-obekty-kompjuterno-grafiki.pdf"},
            { "10-25-1-", "10-25-1-kompjuternye-prezentacii.pdf"},
        };

        public static IEnumerable<string> GetTitles(DocType docType)
        {
            return PDFList.Keys;
        }

        public static string GetKeys(string key, DocType docType)
        {
            return PDFList[key];
        }
    }
        
    public enum DocType
    {
        PDF
    }
}
