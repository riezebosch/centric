﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service.Client.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Verbose", Namespace="http://schemas.datacontract.org/2004/07/Service.DataContract")]
    [System.SerializableAttribute()]
    public partial class Verbose : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FoutOmschrijvingField;
        
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
        public string FoutOmschrijving {
            get {
                return this.FoutOmschrijvingField;
            }
            set {
                if ((object.ReferenceEquals(this.FoutOmschrijvingField, value) != true)) {
                    this.FoutOmschrijvingField = value;
                    this.RaisePropertyChanged("FoutOmschrijving");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Boodschap", Namespace="urn:www-infosupport-com:wcf:centric-maatwerk-training:2015")]
    [System.SerializableAttribute()]
    public partial class Boodschap : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TekstField;
        
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
        public string Tekst {
            get {
                return this.TekstField;
            }
            set {
                if ((object.ReferenceEquals(this.TekstField, value) != true)) {
                    this.TekstField = value;
                    this.RaisePropertyChanged("Tekst");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Antwoord", Namespace="http://schemas.datacontract.org/2004/07/Service.DataContract")]
    [System.SerializableAttribute()]
    public partial class Antwoord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TekstField;
        
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
        public string Tekst {
            get {
                return this.TekstField;
            }
            set {
                if ((object.ReferenceEquals(this.TekstField, value) != true)) {
                    this.TekstField = value;
                    this.RaisePropertyChanged("Tekst");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:www-infosupport-com:wcfdev:demo-service", ConfigurationName="ServiceReference1.IHello")]
    public interface IHello {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/GoodMorning", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/GoodMorningResponse")]
        void GoodMorning();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/GoodMorning", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/GoodMorningResponse")]
        System.Threading.Tasks.Task GoodMorningAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/ThisMorningIsNotSoGoodHereIsYo" +
            "urException", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/ThisMorningIsNotSoGoodHereIsYo" +
            "urExceptionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Service.Client.ServiceReference1.Verbose), Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/ThisMorningIsNotSoGoodHereIsYo" +
            "urExceptionVerboseFault", Name="Verbose", Namespace="http://schemas.datacontract.org/2004/07/Service.DataContract")]
        void ThisMorningIsNotSoGoodHereIsYourException();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/ThisMorningIsNotSoGoodHereIsYo" +
            "urException", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/ThisMorningIsNotSoGoodHereIsYo" +
            "urExceptionResponse")]
        System.Threading.Tasks.Task ThisMorningIsNotSoGoodHereIsYourExceptionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/Send", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/SendResponse")]
        Service.Client.ServiceReference1.Antwoord Send(Service.Client.ServiceReference1.Boodschap boodschap);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/Send", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/SendResponse")]
        System.Threading.Tasks.Task<Service.Client.ServiceReference1.Antwoord> SendAsync(Service.Client.ServiceReference1.Boodschap boodschap);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/Slow", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/SlowResponse")]
        void Slow(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:www-infosupport-com:wcfdev:demo-service/IHello/Slow", ReplyAction="urn:www-infosupport-com:wcfdev:demo-service/IHello/SlowResponse")]
        System.Threading.Tasks.Task SlowAsync(int x);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHelloChannel : Service.Client.ServiceReference1.IHello, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HelloClient : System.ServiceModel.ClientBase<Service.Client.ServiceReference1.IHello>, Service.Client.ServiceReference1.IHello {
        
        public HelloClient() {
        }
        
        public HelloClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HelloClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HelloClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void GoodMorning() {
            base.Channel.GoodMorning();
        }
        
        public System.Threading.Tasks.Task GoodMorningAsync() {
            return base.Channel.GoodMorningAsync();
        }
        
        public void ThisMorningIsNotSoGoodHereIsYourException() {
            base.Channel.ThisMorningIsNotSoGoodHereIsYourException();
        }
        
        public System.Threading.Tasks.Task ThisMorningIsNotSoGoodHereIsYourExceptionAsync() {
            return base.Channel.ThisMorningIsNotSoGoodHereIsYourExceptionAsync();
        }
        
        public Service.Client.ServiceReference1.Antwoord Send(Service.Client.ServiceReference1.Boodschap boodschap) {
            return base.Channel.Send(boodschap);
        }
        
        public System.Threading.Tasks.Task<Service.Client.ServiceReference1.Antwoord> SendAsync(Service.Client.ServiceReference1.Boodschap boodschap) {
            return base.Channel.SendAsync(boodschap);
        }
        
        public void Slow(int x) {
            base.Channel.Slow(x);
        }
        
        public System.Threading.Tasks.Task SlowAsync(int x) {
            return base.Channel.SlowAsync(x);
        }
    }
}
