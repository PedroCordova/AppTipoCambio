using System;
using RestSharp;
using Newtonsoft.Json.Linq;


namespace AppTipoCambio
{
    public class ConexionBanxico
    {
        #region /* Constantes */
        const string BANXICO_MI_TOKEN = "b916fa717fceee420077a27cfd725e2d0dc27e7f3f12f99bc7159637c8b3845b";
        const string BANXICO_SERIE_TIPOCAMBIOFIX = "SF60653";
        private const double V = 0.00;
        #endregion
        public static double _requestData()
        {
            IRestResponse response = null;
            DateTime _date = DateTime.Today;
            string _dateToday = _date.ToString("yyyy-MM-dd");
            double _dataTCDOF = V;
            try
            {
                var client = new RestClient("https://www.banxico.org.mx/SieAPIRest/service/v1/series/"+BANXICO_SERIE_TIPOCAMBIOFIX+"/datos/"+ _dateToday +"/"+ _dateToday + "");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Bmx-Token", BANXICO_MI_TOKEN);
                request.AddHeader("Accept", "application/json");
                response = client.Execute(request);

                string das = response.Content;
                JObject json = JObject.Parse(das);
              _dataTCDOF = (double) json["bmx"]["series"][0]["datos"][0]["dato"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return _dataTCDOF;
        }

    }
}
