using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SeleniumWebDriverBasics
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultValue) => ConfigurationManager.AppSettings[var] ?? defaultValue;

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentVar("Browser", "Firefox");
        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://yandex.by/");
    }
}