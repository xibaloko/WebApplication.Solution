﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForm.GtiServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cliente", Namespace="http://schemas.datacontract.org/2004/07/Domain.Models")]
    [System.SerializableAttribute()]
    public partial class Cliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CpfField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataExpedicaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataNascimentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<WebForm.GtiServiceReference.EnderecoCliente> EnderecosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoCivilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrgaoExpedicaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UfExpedicaoField;
        
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
        public string Cpf {
            get {
                return this.CpfField;
            }
            set {
                if ((object.ReferenceEquals(this.CpfField, value) != true)) {
                    this.CpfField = value;
                    this.RaisePropertyChanged("Cpf");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataExpedicao {
            get {
                return this.DataExpedicaoField;
            }
            set {
                if ((this.DataExpedicaoField.Equals(value) != true)) {
                    this.DataExpedicaoField = value;
                    this.RaisePropertyChanged("DataExpedicao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataNascimento {
            get {
                return this.DataNascimentoField;
            }
            set {
                if ((this.DataNascimentoField.Equals(value) != true)) {
                    this.DataNascimentoField = value;
                    this.RaisePropertyChanged("DataNascimento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<WebForm.GtiServiceReference.EnderecoCliente> Enderecos {
            get {
                return this.EnderecosField;
            }
            set {
                if ((object.ReferenceEquals(this.EnderecosField, value) != true)) {
                    this.EnderecosField = value;
                    this.RaisePropertyChanged("Enderecos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EstadoCivil {
            get {
                return this.EstadoCivilField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoCivilField, value) != true)) {
                    this.EstadoCivilField = value;
                    this.RaisePropertyChanged("EstadoCivil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCliente {
            get {
                return this.IdClienteField;
            }
            set {
                if ((this.IdClienteField.Equals(value) != true)) {
                    this.IdClienteField = value;
                    this.RaisePropertyChanged("IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrgaoExpedicao {
            get {
                return this.OrgaoExpedicaoField;
            }
            set {
                if ((object.ReferenceEquals(this.OrgaoExpedicaoField, value) != true)) {
                    this.OrgaoExpedicaoField = value;
                    this.RaisePropertyChanged("OrgaoExpedicao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Rg {
            get {
                return this.RgField;
            }
            set {
                if ((object.ReferenceEquals(this.RgField, value) != true)) {
                    this.RgField = value;
                    this.RaisePropertyChanged("Rg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sexo {
            get {
                return this.SexoField;
            }
            set {
                if ((object.ReferenceEquals(this.SexoField, value) != true)) {
                    this.SexoField = value;
                    this.RaisePropertyChanged("Sexo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UfExpedicao {
            get {
                return this.UfExpedicaoField;
            }
            set {
                if ((object.ReferenceEquals(this.UfExpedicaoField, value) != true)) {
                    this.UfExpedicaoField = value;
                    this.RaisePropertyChanged("UfExpedicao");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="EnderecoCliente", Namespace="http://schemas.datacontract.org/2004/07/Domain.Models")]
    [System.SerializableAttribute()]
    public partial class EnderecoCliente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BairroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CepField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CidadeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ComplementoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdEnderecoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LogradouroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UfField;
        
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
        public string Bairro {
            get {
                return this.BairroField;
            }
            set {
                if ((object.ReferenceEquals(this.BairroField, value) != true)) {
                    this.BairroField = value;
                    this.RaisePropertyChanged("Bairro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cep {
            get {
                return this.CepField;
            }
            set {
                if ((object.ReferenceEquals(this.CepField, value) != true)) {
                    this.CepField = value;
                    this.RaisePropertyChanged("Cep");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cidade {
            get {
                return this.CidadeField;
            }
            set {
                if ((object.ReferenceEquals(this.CidadeField, value) != true)) {
                    this.CidadeField = value;
                    this.RaisePropertyChanged("Cidade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Complemento {
            get {
                return this.ComplementoField;
            }
            set {
                if ((object.ReferenceEquals(this.ComplementoField, value) != true)) {
                    this.ComplementoField = value;
                    this.RaisePropertyChanged("Complemento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCliente {
            get {
                return this.IdClienteField;
            }
            set {
                if ((this.IdClienteField.Equals(value) != true)) {
                    this.IdClienteField = value;
                    this.RaisePropertyChanged("IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdEndereco {
            get {
                return this.IdEnderecoField;
            }
            set {
                if ((this.IdEnderecoField.Equals(value) != true)) {
                    this.IdEnderecoField = value;
                    this.RaisePropertyChanged("IdEndereco");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Logradouro {
            get {
                return this.LogradouroField;
            }
            set {
                if ((object.ReferenceEquals(this.LogradouroField, value) != true)) {
                    this.LogradouroField = value;
                    this.RaisePropertyChanged("Logradouro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Numero {
            get {
                return this.NumeroField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroField, value) != true)) {
                    this.NumeroField = value;
                    this.RaisePropertyChanged("Numero");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Uf {
            get {
                return this.UfField;
            }
            set {
                if ((object.ReferenceEquals(this.UfField, value) != true)) {
                    this.UfField = value;
                    this.RaisePropertyChanged("Uf");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GtiServiceReference.IGtiService")]
    public interface IGtiService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/NovoCadastro", ReplyAction="http://tempuri.org/IGtiService/NovoCadastroResponse")]
        void NovoCadastro(WebForm.GtiServiceReference.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/NovoCadastro", ReplyAction="http://tempuri.org/IGtiService/NovoCadastroResponse")]
        System.Threading.Tasks.Task NovoCadastroAsync(WebForm.GtiServiceReference.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/BuscarClientes", ReplyAction="http://tempuri.org/IGtiService/BuscarClientesResponse")]
        System.Collections.Generic.List<WebForm.GtiServiceReference.Cliente> BuscarClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/BuscarClientes", ReplyAction="http://tempuri.org/IGtiService/BuscarClientesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebForm.GtiServiceReference.Cliente>> BuscarClientesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/ExcluirCadastro", ReplyAction="http://tempuri.org/IGtiService/ExcluirCadastroResponse")]
        void ExcluirCadastro(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/ExcluirCadastro", ReplyAction="http://tempuri.org/IGtiService/ExcluirCadastroResponse")]
        System.Threading.Tasks.Task ExcluirCadastroAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/BuscarCliente", ReplyAction="http://tempuri.org/IGtiService/BuscarClienteResponse")]
        WebForm.GtiServiceReference.Cliente BuscarCliente(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/BuscarCliente", ReplyAction="http://tempuri.org/IGtiService/BuscarClienteResponse")]
        System.Threading.Tasks.Task<WebForm.GtiServiceReference.Cliente> BuscarClienteAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/AtualizarCadastro", ReplyAction="http://tempuri.org/IGtiService/AtualizarCadastroResponse")]
        void AtualizarCadastro(int id, WebForm.GtiServiceReference.Cliente cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGtiService/AtualizarCadastro", ReplyAction="http://tempuri.org/IGtiService/AtualizarCadastroResponse")]
        System.Threading.Tasks.Task AtualizarCadastroAsync(int id, WebForm.GtiServiceReference.Cliente cliente);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGtiServiceChannel : WebForm.GtiServiceReference.IGtiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GtiServiceClient : System.ServiceModel.ClientBase<WebForm.GtiServiceReference.IGtiService>, WebForm.GtiServiceReference.IGtiService {
        
        public GtiServiceClient() {
        }
        
        public GtiServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GtiServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GtiServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GtiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void NovoCadastro(WebForm.GtiServiceReference.Cliente cliente) {
            base.Channel.NovoCadastro(cliente);
        }
        
        public System.Threading.Tasks.Task NovoCadastroAsync(WebForm.GtiServiceReference.Cliente cliente) {
            return base.Channel.NovoCadastroAsync(cliente);
        }
        
        public System.Collections.Generic.List<WebForm.GtiServiceReference.Cliente> BuscarClientes() {
            return base.Channel.BuscarClientes();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebForm.GtiServiceReference.Cliente>> BuscarClientesAsync() {
            return base.Channel.BuscarClientesAsync();
        }
        
        public void ExcluirCadastro(int id) {
            base.Channel.ExcluirCadastro(id);
        }
        
        public System.Threading.Tasks.Task ExcluirCadastroAsync(int id) {
            return base.Channel.ExcluirCadastroAsync(id);
        }
        
        public WebForm.GtiServiceReference.Cliente BuscarCliente(int id) {
            return base.Channel.BuscarCliente(id);
        }
        
        public System.Threading.Tasks.Task<WebForm.GtiServiceReference.Cliente> BuscarClienteAsync(int id) {
            return base.Channel.BuscarClienteAsync(id);
        }
        
        public void AtualizarCadastro(int id, WebForm.GtiServiceReference.Cliente cliente) {
            base.Channel.AtualizarCadastro(id, cliente);
        }
        
        public System.Threading.Tasks.Task AtualizarCadastroAsync(int id, WebForm.GtiServiceReference.Cliente cliente) {
            return base.Channel.AtualizarCadastroAsync(id, cliente);
        }
    }
}
