using CentralErro.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Transport
{
    public abstract class BaseDTO<T, K> : InnerBaseDTO<T> where T : class where K : InnerBaseDTO<T>
    {
        public BaseDTO()
        {

        }

        public BaseDTO(T model) : base(model)
        {
        }

        public abstract T Modelo(Contexto conn);
    }

}
