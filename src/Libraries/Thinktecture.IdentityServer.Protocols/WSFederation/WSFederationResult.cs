/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Services;
using System.Web.Mvc;

namespace Thinktecture.IdentityServer.Protocols.WSFederation
{
    public class WSFederationResult : ContentResult
    {
        public WSFederationResult(SignInResponseMessage message, bool requireSsl)
        {
            //if (requireSsl)
            //{
            //    if (message.BaseUri.Scheme != Uri.UriSchemeHttps)
            //    {
            //        Tracing.Error(Resources.WSFederation.WSFederationResult.ReturnUrlMustBeSslException);
            //        throw new InvalidRequestException(Resources.WSFederation.WSFederationResult.ReturnUrlMustBeSslException);
            //    }
            //}

            message.Parameters.Add(new KeyValuePair<string, string>("tokentype", "saml"));
            Content = message.WriteFormPost();
        }
    }
}