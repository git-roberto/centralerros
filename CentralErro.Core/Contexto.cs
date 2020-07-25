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
            string conexaoCripto = LerArquivoConexao();

            optionsBuilder.UseSqlServer(Criptografia.DescriptografarTripleDES(conexaoCripto));
        }

        public DbSet<TipoErro> TipoErro { get; set; }
        public DbSet<Erro> Erro { get; set; }

        private string LerArquivoConexao()
        {
            string pathArquivo = @"D:\Codenation\Conexao\Cripto_CentralErros.config";

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
    }
}
