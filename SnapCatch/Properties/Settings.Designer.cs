﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SnapCatch.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.0.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ru-RU")]
        public global::System.Globalization.CultureInfo DefaultLanguage {
            get {
                return ((global::System.Globalization.CultureInfo)(this["DefaultLanguage"]));
            }
            set {
                this["DefaultLanguage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Blue")]
        public string AccentTheme {
            get {
                return ((string)(this["AccentTheme"]));
            }
            set {
                this["AccentTheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BaseLight")]
        public string BaseTheme {
            get {
                return ((string)(this["BaseTheme"]));
            }
            set {
                this["BaseTheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:")]
        public string ScreenContentFolder {
            get {
                return ((string)(this["ScreenContentFolder"]));
            }
            set {
                this["ScreenContentFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoStartUp {
            get {
                return ((bool)(this["AutoStartUp"]));
            }
            set {
                this["AutoStartUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LControlKey +PrintScreen")]
        public string SquareAreaScreenKey {
            get {
                return ((string)(this["SquareAreaScreenKey"]));
            }
            set {
                this["SquareAreaScreenKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PrintScreen")]
        public string ActiveScreenScreenKey {
            get {
                return ((string)(this["ActiveScreenScreenKey"]));
            }
            set {
                this["ActiveScreenScreenKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool HideInTrayOnClose {
            get {
                return ((bool)(this["HideInTrayOnClose"]));
            }
            set {
                this["HideInTrayOnClose"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ActiveWindowKey {
            get {
                return ((bool)(this["ActiveWindowKey"]));
            }
            set {
                this["ActiveWindowKey"] = value;
            }
        }
    }
}
