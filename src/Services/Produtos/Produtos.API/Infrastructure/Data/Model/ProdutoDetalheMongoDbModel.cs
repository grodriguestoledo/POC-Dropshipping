namespace Produtos.API.Infrastructure.Data.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class ProdutoDetalheMongoDbModel
    {
        public ObjectId Id { get; set; }

        [BsonElement("codigo_produto")]
        public string CodigoProduto { get; set; }

        [BsonElement("nome")]
        public string NomeProduto { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }
        [BsonElement("detalhes")]
        public string Detalhes { get; set; }

        [BsonElement("preco")]
        public decimal Preco { get; set; }

        [BsonElement("imagem_url")]
        public string ImagemUrl { get; set; }

        [BsonElement("categoria")]
        public string Categoria { get; set; }
        [BsonElement("fornecedor")]
        public string Fornecedor { get; set; }
        [BsonElement("fornecedorUID")]
        public string FornecedorUID { get; set; }
    }
}