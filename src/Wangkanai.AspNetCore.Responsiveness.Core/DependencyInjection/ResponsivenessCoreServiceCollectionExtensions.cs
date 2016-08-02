﻿// Copyright (c) 2015 Sarin Na Wangkanai, All Rights Reserved.
// The GNU GPLv3. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Wangkanai.AspNetCore.Responsiveness.Internal;
using Wangkanai.AspNetCore.Responsiveness.Preference;

namespace Wangkanai.AspNetCore.Responsiveness.DependencyInjection
{
    public static class ResponsivenessCoreServiceCollectionExtensions
    {
        public static IResponsivenessCoreBuilder AddResponsivenessCore(
            this IServiceCollection services)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));


            return new ResponsivenessCoreBuilder(services);
        }

        private static ResponsivenessManager GetResponsivenessManager(IServiceCollection services)
        {
            var manager = GetServiceFromCollection<ResponsivenessManager>(services);
            if (manager == null)
            {
                manager = new ResponsivenessManager();
            }
            return manager;
        }

        private static T GetServiceFromCollection<T>(IServiceCollection services) 
            => (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
    }
}
