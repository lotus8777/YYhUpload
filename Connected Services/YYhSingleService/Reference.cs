﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YYhUpload.YYhSingleService {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", ConfigurationName="YYhSingleService.CollectDeclareService")]
    public interface CollectDeclareService {
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(YYhUpload.YYhSingleService.Exception), Action="", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        YYhUpload.YYhSingleService.singleDeclareResponse singleDeclare(YYhUpload.YYhSingleService.singleDeclare request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.singleDeclareResponse> singleDeclareAsync(YYhUpload.YYhSingleService.singleDeclare request);
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(YYhUpload.YYhSingleService.Exception), Action="", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        YYhUpload.YYhSingleService.totalDeclareResponse totalDeclare(YYhUpload.YYhSingleService.totalDeclare request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.totalDeclareResponse> totalDeclareAsync(YYhUpload.YYhSingleService.totalDeclare request);
        
        // CODEGEN: 参数“return”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(YYhUpload.YYhSingleService.Exception), Action="", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        YYhUpload.YYhSingleService.afterDeclareResponse afterDeclare(YYhUpload.YYhSingleService.afterDeclare request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.afterDeclareResponse> afterDeclareAsync(YYhUpload.YYhSingleService.afterDeclare request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="singleDeclare", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class singleDeclare {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public singleDeclare() {
        }
        
        public singleDeclare(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="singleDeclareResponse", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class singleDeclareResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public singleDeclareResponse() {
        }
        
        public singleDeclareResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="totalDeclare", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class totalDeclare {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public totalDeclare() {
        }
        
        public totalDeclare(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="totalDeclareResponse", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class totalDeclareResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public totalDeclareResponse() {
        }
        
        public totalDeclareResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="afterDeclare", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class afterDeclare {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public afterDeclare() {
        }
        
        public afterDeclare(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="afterDeclareResponse", WrapperNamespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", IsWrapped=true)]
    public partial class afterDeclareResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://collectdeclareservice.webservice.entrance.si.neusoft.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public afterDeclareResponse() {
        }
        
        public afterDeclareResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CollectDeclareServiceChannel : YYhUpload.YYhSingleService.CollectDeclareService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CollectDeclareServiceClient : System.ServiceModel.ClientBase<YYhUpload.YYhSingleService.CollectDeclareService>, YYhUpload.YYhSingleService.CollectDeclareService {
        
        public CollectDeclareServiceClient() {
        }
        
        public CollectDeclareServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CollectDeclareServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CollectDeclareServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CollectDeclareServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        YYhUpload.YYhSingleService.singleDeclareResponse YYhUpload.YYhSingleService.CollectDeclareService.singleDeclare(YYhUpload.YYhSingleService.singleDeclare request) {
            return base.Channel.singleDeclare(request);
        }
        
        public string singleDeclare(string arg0) {
            YYhUpload.YYhSingleService.singleDeclare inValue = new YYhUpload.YYhSingleService.singleDeclare();
            inValue.arg0 = arg0;
            YYhUpload.YYhSingleService.singleDeclareResponse retVal = ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).singleDeclare(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.singleDeclareResponse> YYhUpload.YYhSingleService.CollectDeclareService.singleDeclareAsync(YYhUpload.YYhSingleService.singleDeclare request) {
            return base.Channel.singleDeclareAsync(request);
        }
        
        public System.Threading.Tasks.Task<YYhUpload.YYhSingleService.singleDeclareResponse> singleDeclareAsync(string arg0) {
            YYhUpload.YYhSingleService.singleDeclare inValue = new YYhUpload.YYhSingleService.singleDeclare();
            inValue.arg0 = arg0;
            return ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).singleDeclareAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        YYhUpload.YYhSingleService.totalDeclareResponse YYhUpload.YYhSingleService.CollectDeclareService.totalDeclare(YYhUpload.YYhSingleService.totalDeclare request) {
            return base.Channel.totalDeclare(request);
        }
        
        public string totalDeclare(string arg0) {
            YYhUpload.YYhSingleService.totalDeclare inValue = new YYhUpload.YYhSingleService.totalDeclare();
            inValue.arg0 = arg0;
            YYhUpload.YYhSingleService.totalDeclareResponse retVal = ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).totalDeclare(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.totalDeclareResponse> YYhUpload.YYhSingleService.CollectDeclareService.totalDeclareAsync(YYhUpload.YYhSingleService.totalDeclare request) {
            return base.Channel.totalDeclareAsync(request);
        }
        
        public System.Threading.Tasks.Task<YYhUpload.YYhSingleService.totalDeclareResponse> totalDeclareAsync(string arg0) {
            YYhUpload.YYhSingleService.totalDeclare inValue = new YYhUpload.YYhSingleService.totalDeclare();
            inValue.arg0 = arg0;
            return ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).totalDeclareAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        YYhUpload.YYhSingleService.afterDeclareResponse YYhUpload.YYhSingleService.CollectDeclareService.afterDeclare(YYhUpload.YYhSingleService.afterDeclare request) {
            return base.Channel.afterDeclare(request);
        }
        
        public string afterDeclare(string arg0) {
            YYhUpload.YYhSingleService.afterDeclare inValue = new YYhUpload.YYhSingleService.afterDeclare();
            inValue.arg0 = arg0;
            YYhUpload.YYhSingleService.afterDeclareResponse retVal = ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).afterDeclare(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<YYhUpload.YYhSingleService.afterDeclareResponse> YYhUpload.YYhSingleService.CollectDeclareService.afterDeclareAsync(YYhUpload.YYhSingleService.afterDeclare request) {
            return base.Channel.afterDeclareAsync(request);
        }
        
        public System.Threading.Tasks.Task<YYhUpload.YYhSingleService.afterDeclareResponse> afterDeclareAsync(string arg0) {
            YYhUpload.YYhSingleService.afterDeclare inValue = new YYhUpload.YYhSingleService.afterDeclare();
            inValue.arg0 = arg0;
            return ((YYhUpload.YYhSingleService.CollectDeclareService)(this)).afterDeclareAsync(inValue);
        }
    }
}
