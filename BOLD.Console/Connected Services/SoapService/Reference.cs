﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOLD.Console.SoapService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SoapParam", Namespace="http://schemas.datacontract.org/2004/07/MES.API.Services.Contracts")]
    [System.SerializableAttribute()]
    public partial class SoapParam : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsisdnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ServiceIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string From {
            get {
                return this.FromField;
            }
            set {
                if ((object.ReferenceEquals(this.FromField, value) != true)) {
                    this.FromField = value;
                    this.RaisePropertyChanged("From");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string Msisdn {
            get {
                return this.MsisdnField;
            }
            set {
                if ((object.ReferenceEquals(this.MsisdnField, value) != true)) {
                    this.MsisdnField = value;
                    this.RaisePropertyChanged("Msisdn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string MessageType {
            get {
                return this.MessageTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageTypeField, value) != true)) {
                    this.MessageTypeField = value;
                    this.RaisePropertyChanged("MessageType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string ServiceID {
            get {
                return this.ServiceIDField;
            }
            set {
                if ((object.ReferenceEquals(this.ServiceIDField, value) != true)) {
                    this.ServiceIDField = value;
                    this.RaisePropertyChanged("ServiceID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MESAPIFault", Namespace="http://schemas.datacontract.org/2004/07/MES.API.Services.Contracts")]
    [System.SerializableAttribute()]
    public partial class MESAPIFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SoapService.ISoapService")]
    public interface ISoapService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/Send", ReplyAction="http://tempuri.org/ISoapService/SendResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(BOLD.Console.SoapService.MESAPIFault), Action="http://tempuri.org/ISoapService/SendMESAPIFaultFault", Name="MESAPIFault", Namespace="http://schemas.datacontract.org/2004/07/MES.API.Services.Contracts")]
        string Send(BOLD.Console.SoapService.SoapParam parameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/Send", ReplyAction="http://tempuri.org/ISoapService/SendResponse")]
        System.Threading.Tasks.Task<string> SendAsync(BOLD.Console.SoapService.SoapParam parameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/AsyncSend", ReplyAction="http://tempuri.org/ISoapService/AsyncSendResponse")]
        string AsyncSend(BOLD.Console.SoapService.SoapParam parameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/AsyncSend", ReplyAction="http://tempuri.org/ISoapService/AsyncSendResponse")]
        System.Threading.Tasks.Task<string> AsyncSendAsync(BOLD.Console.SoapService.SoapParam parameters);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISoapServiceChannel : BOLD.Console.SoapService.ISoapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SoapServiceClient : System.ServiceModel.ClientBase<BOLD.Console.SoapService.ISoapService>, BOLD.Console.SoapService.ISoapService {
        
        public SoapServiceClient() {
        }
        
        public SoapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SoapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Send(BOLD.Console.SoapService.SoapParam parameters) {
            return base.Channel.Send(parameters);
        }
        
        public System.Threading.Tasks.Task<string> SendAsync(BOLD.Console.SoapService.SoapParam parameters) {
            return base.Channel.SendAsync(parameters);
        }
        
        public string AsyncSend(BOLD.Console.SoapService.SoapParam parameters) {
            return base.Channel.AsyncSend(parameters);
        }
        
        public System.Threading.Tasks.Task<string> AsyncSendAsync(BOLD.Console.SoapService.SoapParam parameters) {
            return base.Channel.AsyncSendAsync(parameters);
        }
    }
}