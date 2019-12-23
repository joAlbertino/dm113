using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EstoqueEntityModel;

namespace EstoqueLibrary

{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IEstoqueService
    {

        [OperationContract]
        List<EstoqueProdutoData> ListarProdutos();

        [OperationContract]
        EstoqueProdutoData VerProduto(string productCode);

        [OperationContract]
        bool IncluirProduto(EstoqueProdutoData produto);

        [OperationContract]
        bool RemoverProduto(string numero);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int qtde);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int qtde);

    }


    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class EstoqueProdutoData
    {

        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;

    }
}
