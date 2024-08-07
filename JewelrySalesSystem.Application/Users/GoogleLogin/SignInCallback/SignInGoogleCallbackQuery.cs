﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace JewelrySalesSystem.Application.GoogleLogin.SignInCallback
{
    public class SignInGoogleCallbackQuery : IRequest<SignInGoogleCallbackResponse>
    {
        public HttpContext HttpContext { get; }

        public SignInGoogleCallbackQuery(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }
}
