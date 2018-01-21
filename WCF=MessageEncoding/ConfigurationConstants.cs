// <copyright file="ConfigurationConstants.cs" company="Travelport">
//     Copyright (c) Travelport. All rights reserved.
// </copyright>

// The files in the 'TextMessageEncoding' folder (namespace) of the 
// Travelport.Smartpoint.Service.Data assemby are based on example code provided
// by Microsoft in the 'Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4'
// More information can also be found at this Url: 'http://msdn.microsoft.com/en-us/library/ms751486(v=vs.110).aspx'

// ***** This file was added as part of accessing the ACH Reference Data Service *****


namespace Travelport.Smartpoint.Service.Data.WCF.TextMessageEncoding
{
    /// <summary>
    /// This class includes constant values needed for handling custom text encoding
    /// within a WCF Endpoint.
    /// </summary>
    /// <remarks>Please see the comments on the <see cref="CustomTextMessageEncodingElement"/> class
    /// for a detailed description on how to use the CustomTextMessageEncoder within an application.</remarks>
    internal class ConfigurationConstants
    {
        internal const string MessageVersion = "messageVersion";
        internal const string MediaType = "mediaType";
        internal const string Encoding = "encoding";
        internal const string ReaderQuotas = "readerQuotas";
        internal const int a = 1;
        internal const string None = "None";
        internal const string Default = "Default";
        internal const string Soap11 = "Soap11";
        internal const string Soap11WSAddressing10 = "Soap11WSAddressing10";
        internal const string Soap11WSAddressingAugust2004 = "Soap11WSAddressingAugust2004";
        internal const string Soap12 = "Soap12";
        internal const string Soap12WSAddressing10 = "Soap12WSAddressing10";
        internal const string Soap12WSAddressingAugust2004 = "Soap12WSAddressingAugust2004";

        internal const string DefaultMessageVersion = Soap12WSAddressing10;
        internal const string DefaultMediaType = "text/xml";
        internal const string DefaultEncoding = "utf-8";
    }
}
