﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.InteractionGallery.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Samples.Kinect.InteractionGallery.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 Type {0} does not support event: {1} 的本地化字符串。
        /// </summary>
        internal static string CommandOnEventException {
            get {
                return ResourceManager.GetString("CommandOnEventException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 To get started
        ///Lift your hand 的本地化字符串。
        /// </summary>
        internal static string EngagementHandoffGetStarted {
            get {
                return ResourceManager.GetString("EngagementHandoffGetStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Lift your hand
        ///to keep control 的本地化字符串。
        /// </summary>
        internal static string EngagementHandoffKeepControl {
            get {
                return ResourceManager.GetString("EngagementHandoffKeepControl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Selected experience is invalid 的本地化字符串。
        /// </summary>
        internal static string HomeScreenInvalidExperienceSelected {
            get {
                return ResourceManager.GetString("HomeScreenInvalidExperienceSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The supplied Uri {0} points to an invalid article model 的本地化字符串。
        /// </summary>
        internal static string InvalidArticle {
            get {
                return ResourceManager.GetString("InvalidArticle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The supplied Uri {0} points to a invalid content 的本地化字符串。
        /// </summary>
        internal static string InvalidPanningContent {
            get {
                return ResourceManager.GetString("InvalidPanningContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Kinect Controller is invalid 的本地化字符串。
        /// </summary>
        internal static string KinectControllerInvalid {
            get {
                return ResourceManager.GetString("KinectControllerInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 You have selected {0} 的本地化字符串。
        /// </summary>
        internal static string ScrollingListSelectionMessage {
            get {
                return ResourceManager.GetString("ScrollingListSelectionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 This sample was designed 1920 x 1080 screen resolution.
        ///Running it in a lower resolution may result in incorrect layout and reduced functionality.
        ///Do you wish to continue? 的本地化字符串。
        /// </summary>
        internal static string SuboptimalScreenResolutionMessage {
            get {
                return ResourceManager.GetString("SuboptimalScreenResolutionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Suboptimal Screen Resolution 的本地化字符串。
        /// </summary>
        internal static string SuboptimalScreenResolutionTitle {
            get {
                return ResourceManager.GetString("SuboptimalScreenResolutionTitle", resourceCulture);
            }
        }
    }
}