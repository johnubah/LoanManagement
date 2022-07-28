using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.Common
{
    public  class LoanException<T> : Exception where T : class
    {
        private T requestData;
        public LoanException(T data ,String message):base(message)
        {
            this.requestData = data;
            

        }
        public LoanException(T data,String message, Exception ex):base(message,ex.InnerException)
        {
            this.requestData = data;
        }
        public T RequestData {
            get 
            {
                if(this.requestData != default(T))
                {
                    IResponse response = this.requestData as IResponse;
                    if(response != null)
                    {
                        response.Successful = false;
                        response.Message = this.Message;
                    }
                }
                return requestData; 
            } 
        }
       
    }
}
