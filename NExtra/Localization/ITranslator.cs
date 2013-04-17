﻿using System.Globalization;

namespace NExtra.Localization
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can translate language keys in any way, either by
    /// using the current or a specific culture.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ITranslator
    {
        string Translate(string key);
        string Translate(string key, CultureInfo cultureInfo);
        bool TranslationExists(string key);
        bool TranslationExists(string key, CultureInfo cultureInfo);
    }
}
