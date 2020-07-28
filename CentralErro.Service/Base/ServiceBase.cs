using CentralErro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CentralErro.Service
{
    public class ServiceBase<T> : IDisposable where T : class
    {
        public Contexto Conn { get; private set; }

        public ServiceBase()
        {
            Conn = new Contexto();
        }

        public virtual IQueryable<T> Listar()
        {
                IQueryable<T> retorno = Conn.Set<T>().AsQueryable();

            return retorno;
        }

        public virtual IQueryable<T> Listar(Expression<Func<T, bool>> filtro)
        {
            IQueryable<T> retorno = Conn.Set<T>().Where(filtro).AsQueryable();

            return retorno;
        }

        public virtual T Buscar(int id)
        {
            T retorno = Conn.Set<T>().Find(id);

            return retorno;
        }

        public virtual T Buscar(Expression<Func<T, bool>> filtro)
        {
            T retorno = Conn.Set<T>().FirstOrDefault(filtro);

            return retorno;
        }

        public virtual void Incluir(T registro)
        {
            Conn.Set<T>().Add(registro);
            Conn.SaveChanges();
        }

        public virtual void Atualizar(T registro)
        {
            Conn.Set<T>().Update(registro);
            Conn.SaveChanges();
        }

        public virtual void Excluir(T registro)
        {
            Conn.Set<T>().Remove(registro);
            Conn.SaveChanges();
        }

        public virtual void Excluir(int id)
        {
            T registro = Buscar(id);

            if (registro == null)
            {
                throw new Exception("O registro informado para exclusão não existe na base de dados");
            }

            Excluir(registro);
        }

        public void Dispose()
        {
            if (Conn != null)
            {
                Conn = null;
            }
        }
    }
}
