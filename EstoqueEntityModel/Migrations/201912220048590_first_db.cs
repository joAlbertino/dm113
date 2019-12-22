namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_db : DbMigration
    {
        public override void Up()
        {
            //CREATE TABLE
            CreateTable("dbo.ProdutoEstoque", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                NumeroProduto = c.String(nullable: false),
                NomeProduto = c.String(nullable: false),
                DescricaoProduto = c.String(nullable: true),
                EstoqueProduto = c.Int(nullable: false)

            });
        }
        
        public override void Down()
        {
        }
    }
}
