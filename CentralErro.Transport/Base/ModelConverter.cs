using CentralErro.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Transport
{
    public static class ModelConverter
    {
        public static K ToDTO<T, K>(this T registro) where K : BaseDTO<T, K> where T : class
        {
            try
            {
                if (registro == null)
                {
                    return null;
                }
                var c = typeof(K).GetConstructor(new Type[] { typeof(T) });
                K retorno = c.Invoke(new object[] { registro }) as K;

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ToModel<T, K>(this K registro, Contexto conn) where K : BaseDTO<T, K> where T : class
        {
            try
            {
                if (registro == null)
                {
                    return null;
                }
                T retorno = registro.Modelo(conn);
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
