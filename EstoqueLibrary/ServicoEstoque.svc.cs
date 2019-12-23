using System;
using System.Collections.Generic;
using System.Linq;
using EstoqueEntityModel;
using System.ServiceModel.Activation;

namespace EstoqueLibrary
{
    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(
    RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EstoqueService : IEstoqueService
    {
        public List<EstoqueProdutoData> ListarProdutos()
        {
            // Create a list of products
            List<EstoqueProdutoData> productsList = new List<EstoqueProdutoData>();
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> products = (from product in database.ProdutoEstoques
                                              select product).ToList();
                    foreach (ProdutoEstoque product in products)
                    {
                        EstoqueProdutoData productData = new EstoqueProdutoData()
                        {
                           NumeroProduto = product.NumeroProduto,
                           NomeProduto = product.NomeProduto ,
                           DescricaoProduto = product.DescricaoProduto,
                           EstoqueProduto = product.EstoqueProduto
                        };
                        productsList.Add(productData);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products
            return productsList;
        }        public EstoqueProdutoData VerProduto(string productCode)
        {
            EstoqueProdutoData productData = null;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                     p => String.Compare(p.NumeroProduto, productCode) == 0);
                    productData = new EstoqueProdutoData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return productData;

        }

      

        public bool IncluirProduto(EstoqueProdutoData produto)
        {
            // Connect to the ProductsModel database
            using (ProvedorEstoque database = new ProvedorEstoque())
            {
                try
                {
                    ProdutoEstoque novoProduto = new ProdutoEstoque
                    {
                        NomeProduto = produto.NomeProduto,
                        NumeroProduto = produto.NumeroProduto,
                        DescricaoProduto = produto.DescricaoProduto,
                        EstoqueProduto = produto.EstoqueProduto
                    };

                    database.ProdutoEstoques.Add(novoProduto);

                    database.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool RemoverProduto(string numero)
        {
            // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    try
                    {
                        // Find the first product that matches the specified product code
                        ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                         p => String.Compare(p.NumeroProduto, numero) == 0);

                        database.ProdutoEstoques.Remove(matchingProduct);

                        database.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }
               
                }
        }
          

        public int ConsultarEstoque(string numeroProduto)
        {
            // Connect to the ProductsModel database
            using (ProvedorEstoque database = new ProvedorEstoque())
            {
                try
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                     p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    return matchingProduct.EstoqueProduto;
                }
                catch
                {
                    return 0;
                }

            }
        }

        public bool AdicionarEstoque(string numeroProduto, int qtde)
        {
            // Connect to the ProductsModel database
            using (ProvedorEstoque database = new ProvedorEstoque())
            {
                try
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                     p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    matchingProduct.EstoqueProduto += qtde;

                    database.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }

        public bool RemoverEstoque(string numeroProduto, int qtde)
        {
            // Connect to the ProductsModel database
            using (ProvedorEstoque database = new ProvedorEstoque())
            {
                try
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                     p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    matchingProduct.EstoqueProduto -= qtde;

                    database.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
    }

}
