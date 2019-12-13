using MongoDB.Driver;
using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {

        public readonly IMongoCollection<Localizacoes> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("opflix");
            _localizacoes = database.GetCollection<Localizacoes>("mapas");
        }

        public void Cadastrar(Localizacoes localizacoes)
        {
            _localizacoes.InsertOne(localizacoes);
        }

        public List<Localizacoes> Listar()
        {
            return _localizacoes.Find(l => true).ToList();
        }
    }
}
