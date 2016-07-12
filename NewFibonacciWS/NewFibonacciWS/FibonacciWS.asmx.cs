using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using log4net;
using System.Xml;

namespace NewFibonacciWS
{
    /// <summary>
    /// Description résumée de FibonacciWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class FibonacciWS : System.Web.Services.WebService
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(FibonacciWS));

        [WebMethod]
        public int Fibonacci(int N)
        {
            log.Info("Démarrage de l'application.");
            if (1 <= N && N <= 100)
            {
                if (N == 1 || N == 2)
                {
                    return 1;
                }

                int a = 1;
                int b = 1;
                int c = 0;

                for (int i = 3; i <= N; i++)
                {
                    c = b + a;
                    a = b;
                    b = c;
                }

                log.Info("F(" + N + ") = " + c);

                return c;
            }
            else
            {
                return -1;
            }
        }

        [WebMethod]
        public string XmlToJson(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string json = JsonConvert.SerializeXmlNode(doc);

                log.Debug("conversion XML to Json réussie");

                return json;
            }
            catch (Exception ex)
            {
                log.Error("erreur " + ex);
                string retour = "Bad Xml format";

                return retour;
            }
        }
    }
}
