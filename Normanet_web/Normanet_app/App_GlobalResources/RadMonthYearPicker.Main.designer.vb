'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace Resources.RadMonthYearPicker
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option or rebuild the Visual Studio project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Main
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Resources.RadMonthYearPicker.Main", Global.System.Reflection.[Assembly].Load("App_GlobalResources"))
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Cancel.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationCancelButtonCaption() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationCancelButtonCaption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &amp;gt;.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationNextText() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationNextText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &gt;.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationNextToolTip() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationNextToolTip", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to OK.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationOkButtonCaption() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationOkButtonCaption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &amp;lt;.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationPrevText() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationPrevText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationPrevToolTip() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationPrevToolTip", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Today.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearNavigationTodayButtonCaption() As String
            Get
                Return ResourceManager.GetString("MonthYearNavigationTodayButtonCaption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Month year picker.
        '''</summary>
        Friend Shared ReadOnly Property MonthYearViewCaptionText() As String
            Get
                Return ResourceManager.GetString("MonthYearViewCaptionText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Table holding time picker for selecting time of day..
        '''</summary>
        Friend Shared ReadOnly Property MonthYearViewSummary() As String
            Get
                Return ResourceManager.GetString("MonthYearViewSummary", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Open the monthyear view popup..
        '''</summary>
        Friend Shared ReadOnly Property PopupButtonToolTip() As String
            Get
                Return ResourceManager.GetString("PopupButtonToolTip", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please do not remove this key..
        '''</summary>
        Friend Shared ReadOnly Property ReservedResource() As String
            Get
                Return ResourceManager.GetString("ReservedResource", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
