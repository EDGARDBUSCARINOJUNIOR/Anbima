using Anbima.Application.Services.Interfaces;
using Anbima.Domain.Entities;
using Anbima.Infra.Data.Files;
using Anbima.Infra.Data.Files.MapFiles;
using Anbima.Infra.Data.HTTPClient;
using System.Text.Json;

namespace Anbima.Application.Services
{
    public class AnbimaService : IAnbimaService
    {
        public void GetAnbimaSerieHistorica()
        {
            try
            { 
                var listParametrosEntrada =  new MapParametrosEntrada().CarregarParametrosEntrada();

                if (listParametrosEntrada == null)
                    return;

                foreach (var item in listParametrosEntrada)
                {
                    var codigoFundo = item.CodigoFundo;
                    var dataInicio = item.DataInicio;
                    var dataFim = item.DataFim;

                    var retornoURLFormatada = montaURL(codigoFundo, dataInicio, dataFim);


                    //https://api.anbima.com.br/oauth/access-token

                    ////Chama a aPI
                    //var retApi = Task.Run(() => new Methods().Get(retornoURLFormatada));
                    ////retApi.Wait();

                    //Converte retorno em arquivo excel
                    var jtexto = @"[{""Nome"": ""Teste1"", ""Sobrenome"": ""TesteS1""},{""Nome"": ""Teste2"", ""Sobrenome"": ""TesteS2""}]";

                   List<Resgate>? listaResgate = JsonSerializer.Deserialize<List<Resgate>>(jtexto);

                    var MapSerieHistorica = new MapSeriesHistorica();
                    
                    MapSerieHistorica.GerarArquivo(listaResgate, codigoFundo);
                }
            }
            catch (Exception)
            {
                //gravar erro
            }
        }

        private string montaURL(string codigoFundo, DateTime dataInicio,  DateTime dataFim)
        {
            //Regras para a chamada de api
            return "";
        }

    }
}
