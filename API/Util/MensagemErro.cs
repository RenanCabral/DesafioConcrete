using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace API.Util
{
    public class MensagemErro
    {
        private HttpStatusCode _codigoErro;

        private string _mensagem;

        public HttpStatusCode CodigoErro
        {
            get { return _codigoErro; }
            set { _codigoErro = value; }
        }

        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }


        public MensagemErro(HttpStatusCode codigoErro, string mensagem)
        {
            this._codigoErro = codigoErro;
            this._mensagem = mensagem;
        }
    }
}