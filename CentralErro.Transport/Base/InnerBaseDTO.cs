using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Transport
{
    public abstract class InnerBaseDTO<T> where T : class
    {
        public InnerBaseDTO()
        {

        }

        public InnerBaseDTO(T model)
        {

        }
    }

}
