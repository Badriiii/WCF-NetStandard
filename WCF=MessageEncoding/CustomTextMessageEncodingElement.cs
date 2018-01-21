// <copyright file="CustomTextMessageEncodingElement.cs" company="Travelport">
//     Copyright (c) Travelport. All rights reserved.
// </copyright>

// The files in the 'TextMessageEncoding' folder (namespace) of the 
// Travelport.Smartpoint.Service.Data assemby are based on example code provided
// by Microsoft in the 'Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4'
// More information can also be found at this Url: 'http://msdn.microsoft.com/en-us/library/ms751486(v=vs.110).aspx'

// ***** This file was added as part of accessing the ACH Reference Data Service *****

using ClassLibrary1;
using System;
using System.Configuration;
using System.ServiceModel.Channels;
using System.Xml;
using Travelport.TravelData.Interfaces.SettingsProviders;
using WCF_MessageEncoding;

namespace Travelport.Smartpoint.Service.Data.WCF.TextMessageEncoding
{
    // using System.ServiceModel.Configuration;

    /// <summary>
    /// Out of the box, WCF only supports a 'textEncoding' value of 'utf-8' or 'utf-16'.
    /// If a web service needs to be called that specifies an encoding other than one of those, 
    /// for example, 'iso-8559-1', then a custom text message encoder must be used to translate the SOAP message.
    /// This class, along with the others in this namespace, can be used to support additional text encoding types.
    /// </summary>
    /// <example>To use the CustomTextMessageEncoder, do the following:
    /// In the configuration file for the receiving WCF endpoint (e.g. the application that is calling the webservice)
    /// In the 'system.serviceModel / extensions / bindingElementExtensions' section, add the customTextMessageEncoder:
    /// add name= 'customTextMessageEncoding' type= 'Travelport.Smartpoint.Service.Data.WCF.TextMessageEncoding.CustomTextMessageEncodingElement, Travelport.Smartpoint.Service.Data' 
    /// (see the Travelport.Smartpoint assembly, WCFConfig folder, extensions.config for an implemented example)
    /// 
    /// In the 'system.serviceModel / bindings / customBindings' section, add a binding that references the customTextMessageEncoder:
    /// customTextMessageEncoding encoding= 'ISO-8859-1'
    /// (see the Travelport.Smartpoint assembly, WCFConfig folder, bindings.config for an implemented example)
    /// 
    /// In the 'system.serviceModel / client' section, add an endpoint that references the custom binding of the customerTextMessageEncoder:
    /// endpoint address= 'addressOfTheService' binding= 'customBinding' bindingConfiguration= 'NameOfTheBindingForTheCustomMessageEncoder'
    /// (see the Travelport.Smartpoint assembly, WCFConfig folder, qa.client.config for an implemented example)
    /// </example>
    public class CustomTextMessageEncodingElement : BindingElementExtensionElement
    {
        #region Constructor
        public CustomTextMessageEncodingElement()
        {
        }
        #endregion

        #region Overrides of BindingElementExtensionElement
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            CustomTextMessageBindingElement binding = (CustomTextMessageBindingElement)bindingElement;
            binding.MessageVersion = this.MessageVersion;
            binding.MediaType = this.MediaType;
            binding.Encoding = this.Encoding;
            this.ApplyConfiguration(binding.ReaderQuotas);
        }

        protected override BindingElement CreateBindingElement()
        {
            CustomTextMessageBindingElement binding = new CustomTextMessageBindingElement();
            this.ApplyConfiguration(binding);
            return binding;
        }

        public override Type BindingElementType
        {
            get
            {
                return typeof(CustomTextMessageBindingElement);
            }
        }
        #endregion

        #region Public Properties
        [ConfigurationProperty(ConfigurationConstants.MessageVersion, DefaultValue = ConfigurationConstants.DefaultMessageVersion)]
        public MessageVersion MessageVersion
        {
            get { return (MessageVersion)base[ConfigurationConstants.MessageVersion]; }
            set { base[ConfigurationConstants.MessageVersion] = value; }
        }

        [ConfigurationProperty(ConfigurationConstants.MediaType, DefaultValue = ConfigurationConstants.DefaultMediaType)]
        public string MediaType
        {
            get
            {
                return (string)base[ConfigurationConstants.MediaType];
            }

            set
            {
                base[ConfigurationConstants.MediaType] = value;
            }
        }

        [ConfigurationProperty(ConfigurationConstants.Encoding, DefaultValue = ConfigurationConstants.DefaultEncoding)]
        public string Encoding
        {
            get
            {
                return (string)base[ConfigurationConstants.Encoding];
            }

            set
            {
                base[ConfigurationConstants.Encoding] = value;
            }
        }

        [ConfigurationProperty(ConfigurationConstants.ReaderQuotas)]
        public IXmlDictionaryReaderQuotasElementSettings ReaderQuotasElement
        {
            get
            {
                return (IXmlDictionaryReaderQuotasElementSettings)base[ConfigurationConstants.ReaderQuotas];
            }
        }
        #endregion

        #region Private Methods
        private void ApplyConfiguration(XmlDictionaryReaderQuotas readerQuotas)
        {
            if (readerQuotas == null)
                throw new ArgumentNullException("readerQuotas");

            if (this.ReaderQuotasElement.MaxDepth != 0)
            {
                readerQuotas.MaxDepth = this.ReaderQuotasElement.MaxDepth;
            }
            if (this.ReaderQuotasElement.MaxStringContentLength != 0)
            {
                readerQuotas.MaxStringContentLength = this.ReaderQuotasElement.MaxStringContentLength;
            }
            if (this.ReaderQuotasElement.MaxArrayLength != 0)
            {
                readerQuotas.MaxArrayLength = this.ReaderQuotasElement.MaxArrayLength;
            }
            if (this.ReaderQuotasElement.MaxBytesPerRead != 0)
            {
                readerQuotas.MaxBytesPerRead = this.ReaderQuotasElement.MaxBytesPerRead;
            }
            if (this.ReaderQuotasElement.MaxNameTableCharCount != 0)
            {
                readerQuotas.MaxNameTableCharCount = this.ReaderQuotasElement.MaxNameTableCharCount;
            }
        }
        #endregion
    }
}
