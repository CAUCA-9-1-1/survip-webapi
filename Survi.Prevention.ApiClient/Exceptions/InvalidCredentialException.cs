﻿using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
    public class InvalidCredentialException : Exception
    {
        public InvalidCredentialException(string userName) 
            : base($"Credential are invalid for username '{userName}'.")
        {
        }
    }
}