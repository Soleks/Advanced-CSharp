﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lesson_7.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Department", Namespace="http://schemas.datacontract.org/2004/07/WcfService_")]
    [System.SerializableAttribute()]
    public partial class Department : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Lesson_7.ServiceReference1.Employee[] EmployeeField;
        
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
        public string DepartmentName {
            get {
                return this.DepartmentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentNameField, value) != true)) {
                    this.DepartmentNameField = value;
                    this.RaisePropertyChanged("DepartmentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Lesson_7.ServiceReference1.Employee[] Employee {
            get {
                return this.EmployeeField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeeField, value) != true)) {
                    this.EmployeeField = value;
                    this.RaisePropertyChanged("Employee");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/WcfService_")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Sum", ReplyAction="http://tempuri.org/IService1/SumResponse")]
        int Sum();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Sum", ReplyAction="http://tempuri.org/IService1/SumResponse")]
        System.Threading.Tasks.Task<int> SumAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetEmployeeData", ReplyAction="http://tempuri.org/IService1/SetEmployeeDataResponse")]
        Lesson_7.ServiceReference1.Department[] SetEmployeeData(string dep, string name, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SetEmployeeData", ReplyAction="http://tempuri.org/IService1/SetEmployeeDataResponse")]
        System.Threading.Tasks.Task<Lesson_7.ServiceReference1.Department[]> SetEmployeeDataAsync(string dep, string name, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveDepAndEmp", ReplyAction="http://tempuri.org/IService1/RemoveDepAndEmpResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lesson_7.ServiceReference1.Department[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lesson_7.ServiceReference1.Department))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lesson_7.ServiceReference1.Employee[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Lesson_7.ServiceReference1.Employee))]
        Lesson_7.ServiceReference1.Department[] RemoveDepAndEmp(object o, Lesson_7.ServiceReference1.Department[] d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveDepAndEmp", ReplyAction="http://tempuri.org/IService1/RemoveDepAndEmpResponse")]
        System.Threading.Tasks.Task<Lesson_7.ServiceReference1.Department[]> RemoveDepAndEmpAsync(object o, Lesson_7.ServiceReference1.Department[] d);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Lesson_7.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Lesson_7.ServiceReference1.IService1>, Lesson_7.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public int Sum() {
            return base.Channel.Sum();
        }
        
        public System.Threading.Tasks.Task<int> SumAsync() {
            return base.Channel.SumAsync();
        }
        
        public Lesson_7.ServiceReference1.Department[] SetEmployeeData(string dep, string name, string lastName) {
            return base.Channel.SetEmployeeData(dep, name, lastName);
        }
        
        public System.Threading.Tasks.Task<Lesson_7.ServiceReference1.Department[]> SetEmployeeDataAsync(string dep, string name, string lastName) {
            return base.Channel.SetEmployeeDataAsync(dep, name, lastName);
        }
        
        public Lesson_7.ServiceReference1.Department[] RemoveDepAndEmp(object o, Lesson_7.ServiceReference1.Department[] d) {
            return base.Channel.RemoveDepAndEmp(o, d);
        }
        
        public System.Threading.Tasks.Task<Lesson_7.ServiceReference1.Department[]> RemoveDepAndEmpAsync(object o, Lesson_7.ServiceReference1.Department[] d) {
            return base.Channel.RemoveDepAndEmpAsync(o, d);
        }
    }
}
