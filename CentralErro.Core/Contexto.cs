using CentralErro.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CentralErro.Core
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Efetua a leitura do arquivo de conexão com o banco de dados criptografada 
            string conexaoCripto = LerArquivoConexao();

            //Descriptografa a string de conexão com o banco de dados e efetua a conexão
            optionsBuilder.UseSqlServer(Criptografia.DescriptografarTripleDES(conexaoCripto));
        }

        private string LerArquivoConexao()
        {
            /*
                Para o funcionamento correto, deve-se importar os pacotes no NUGET
                Microsoft.Extensions.Configuration
                Microsoft.Extensions.Configuration.Abstractions 
                Microsoft.Extensions.Configuration.Json
             */

            //Busca o arquivo de configuração
            ConfigurationBuilder configuracao = new ConfigurationBuilder();
            var arquivoConfiguracao = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configuracao.AddJsonFile(arquivoConfiguracao, false);
            //Monta o arquivo de configuração JSON
            var config = configuracao.Build();
            //Recupera o valor do caminho do arquivo de conexão
            string pathArquivo = config.GetSection("arquivoConexao").Value;

            if (pathArquivo == null)
            {
                throw new Exception("O caminho do arquivo não foi informado, verifique o arquivo de configuração.");
            }

            if (!File.Exists(pathArquivo))
            {
                throw new Exception("O arquivo informado não existe");
            }

            string conexaoCripto = File.ReadAllText(pathArquivo);

            return conexaoCripto;
        }

        public DbSet<TipoErro> TipoErro { get; set; }
        public DbSet<Erro> Erro { get; set; }

    }
}
