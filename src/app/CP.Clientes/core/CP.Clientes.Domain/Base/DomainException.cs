using System;

namespace CP.Clientes.Domain.Base
{
    public class DomainException : Exception
	{
		public DomainException(string message) : base(message) { }
	}

    public class IntegrationExceptions : Exception
    {
        public IntegrationExceptions(string message) : base(message) { }
    }
}

