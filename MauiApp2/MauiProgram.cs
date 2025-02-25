﻿using Microsoft.Extensions.Logging;
using Shiny;
using SlotShark.MobileApp.Core.Jobs;

namespace MauiApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
				.UseMauiApp<App>()
                .UseShiny()
                .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddJob(typeof(CheckStatusJob));

            return builder.Build();
        }
    }
}
