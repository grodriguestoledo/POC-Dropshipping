namespace Produtos.API.Infrastructure.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using Produtos.API.Infrastructure.Data.Model;

    public class ProdutoRepository
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;
        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            var section = _configuration.GetSection("MongoDB");

            _client = new MongoClient(section["server"]);
            _database = _client.GetDatabase("produtos_db");

            IniciarCollections();
        }

        public async Task<IEnumerable<ProdutoMongoDbModel>> ObterProdutos(string filtro = "")
        {
            var filterDef = string.IsNullOrEmpty(filtro) ?
                FilterDefinition<ProdutoMongoDbModel>.Empty :
                Builders<ProdutoMongoDbModel>.Filter.Where(x => x.NomeProduto.ToLower().Contains(filtro.ToLower()) || x.Categoria.ToLower().Contains(filtro.ToLower()));

            var cursor = await _database.GetCollection<ProdutoMongoDbModel>("produtos").FindAsync(filterDef);
            return await cursor.ToListAsync();
        }

        public async Task<ProdutoDetalheMongoDbModel> ObterProdutoDetalhe(string codigoProduto)
        {
            var cursor = await _database.GetCollection<ProdutoDetalheMongoDbModel>("produtos_detalhes").FindAsync(x => x.CodigoProduto == codigoProduto);
            return await cursor.FirstOrDefaultAsync();
        }

        private void IniciarCollections()
        {
            var totalProdutos = _database.GetCollection<ProdutoMongoDbModel>("produtos").EstimatedDocumentCount();
            if (totalProdutos == 0)
            {
                #region [Insere produtos fake]
                var listaProdutos = new List<ProdutoMongoDbModel>();
                var listaProdutosDetalhes = new List<ProdutoDetalheMongoDbModel>();

                var auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Carne 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/193010/product/310001_c%C3%B3pia.jpg?1515177367", Preco = 8.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel { FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe", Descricao = @"- Ração premium especial para gatos adultos;</br>
- Trato urinário saudável;<br/>
- Controle de PH urinário;<br/>
- Minerais cientificamente balanceados;<br/>
- Rico em taurina, aminoácido essencial para os olhos e o coração;<br/>
- Com transgênico;<br/>
- Ingredientes naturais sem corantes ou aromatizantes artificiais;<br/>

- Este produto possui Satisfação Garantida. Saiba mais abaixo na descrição.</br>", Detalhes = @"A Ração Golden Gatos Adultos Sabor Carne é indicada para gatos adultos. Possui um sabor irresistível para seu gatinho e vai proporcionar nutrientes no nível ideal para ele, que merece o que há de mais saudável. Para a melhor eficiência da ração, não é recomendado nenhum tipo de suplementação.<br/>
<br/>

Solicitações referentes à Garantia de Satisfação devem ser encaminhadas diretamente para o fabricante por meio do PremieR Responde – Telefone 0800 55 66 66. Para mais informações acesse: http://www.premierpet.com.br/garantia-premier-pet/", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Carne 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/193010/product/310001_c%C3%B3pia.jpg?1515177367", Preco = 8.5M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Castrados Salmão 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/179953/product/Ra%C3%A7%C3%A3o_Golden_Gatos_Adultos_Castrados_Salm%C3%A3o_31022435.jpg?1523626445", Preco = 18.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe",  Descricao = @"- Ideal para gatos castrados a partir dos 6 meses de idade; </br>
- Ajuda no controle das bolas de pelos;</br>
- Fórmula exclusiva e balanceada que auxilia os gatos castrados a manterem o peso ideal;</br>
- Alimento reduzido em calorias e gorduras, enriquecido com L- Carnitina;</br>
- Com transgênico;</br>
- 

- Este produto possui Satisfação Garantida. Saiba mais abaixo na descrição.", Detalhes = @"A Ração Golden Gatos Adultos Castrados Salmão é um ótimo alimento, mantém a qualidade de Golden Gatos incrementada pelo excepcional sabor do salmão. Uma excelente opção para gatos de paladar mais exigente e trato urinário saudável. Contribui na prevenção da formação de cálculo urinário através de pH e minerais cientificamente balanceados. Com proteínas de qualidade refinada com frango de verdade. </br></br>

Solicitações referentes à Garantia de Satisfação devem ser encaminhadas diretamente para o fabricante por meio do PremieR Responde – Telefone 0800 55 66 66. Para mais informações acesse: http://www.premierpet.com.br/garantia-premier-pet/", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Castrados Salmão 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/179953/product/Ra%C3%A7%C3%A3o_Golden_Gatos_Adultos_Castrados_Salm%C3%A3o_31022435.jpg?1523626445", Preco = 18.5M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Castrados Frango 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/147618/product/GOLDEN-GATOS-CASTRADOS-FRANGO.jpg?1494963421", Preco = 2.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID = "8d58b0c7-7ca0-4e10-a738-579aa1919ffe" ,Descricao = @"- Ração premium especial indicada para gatos adultos e castrados;</br>
- Ideal para gatos castrados a partir dos 6 meses de idade;</br>
- Previne a obesidade; </br>
- Auxilia no cuidado com o trato urinário, controle do pH urinário e minerais balanceados;</br>
- Rico em taurina aminoácido essencial para o coração e olhos;</br>
- Auxilia na eliminação das bolas de pelos: rico em fibras especiais;</br>
- Com transgênico;</br>

- Este produto possui Satisfação Garantida. Saiba mais abaixo na descrição.", Detalhes = @"A Ração Golden Gatos Adultos Castrados Sabor Frango foi especialmente formulada para atender às necessidades dos gatos castrados, auxilia na prevenção da obesidade e no cuidado com o trato urinário, garantindo uma nutrição ótima e saudável.

Solicitações referentes à Garantia de Satisfação devem ser encaminhadas diretamente para o fabricante por meio do PremieR Responde – Telefone 0800 55 66 66. Para mais informações acesse: http://www.premierpet.com.br/garantia-premier-pet/", Fornecedor = "Golden", Categoria = "Ração", NomeProduto = "Ração Golden Gatos Adultos Castrados Frango 1kg", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/147618/product/GOLDEN-GATOS-CASTRADOS-FRANGO.jpg?1494963421", Preco = 2.5M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Fornecedor = "Animais Pet", Categoria = "Ração", NomeProduto = "Ração Whiskas Sachê Frango para Gatos Adultos 85g", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/186903/product/WHISKAS_SACHE_ADULTO_MOLHO_FRANGO_3106420-1.png?1495071215", Preco = 1.89M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Descricao = @"- Alimento 100% completo e balanceado;<br/>
- Deliciosos pedaços cozidos a vapor;<br/>
- Não contém conservantes;<br/>
- Níveis de proteínas essenciais para os gatos;<br/>
- Possui 80% de água na sua composição, o que ajuda a manter um ótimo balanço hídrico.", Detalhes = @"A Ração Whiskas Sachê Frango para Gatos Adultos é super prática de abrir e servir. Cada sachê contém uma deliciosa refeição, 100% completa e balanceada. Contém suculentos pedaços de carne cozidos no vapor, com molho delicioso, rico em proteínas e vitaminas em embalagem individual.", Fornecedor = "Animais Pet", Categoria = "Ração", NomeProduto = "Ração Whiskas Sachê Frango para Gatos Adultos 85g", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/186903/product/WHISKAS_SACHE_ADULTO_MOLHO_FRANGO_3106420-1.png?1495071215", Preco = 1.89M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Fornecedor = "Animais Pet", Categoria = "Higiene", NomeProduto = "Bandeja Sanitária Furba Azul para Gatos", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/142848/product/8003507978010.jpg?1494956557", Preco = 128.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Descricao = @"- 3 bandejas;<br/>
- Borda removível;<br/>
- Fácil de limpar; <br/>
- Ótima durabilidade;<br/>
- Dispensa o uso de pás.<br/>", Detalhes = @"A Bandeja Sanitária Furba para Gatos é sensacional para ser usada por gatos. Diferente, vem com 03 bandejas, a superior vazada e outras duas não, e uma borda removível que impede que seu pet jogue a areia para fora enquanto cava. Muito higiênica, pois ao peneirar a primeira bandeja a areia vai ficar na parte inferior, e as impurezas na superior, basta jogá-las no lixo e higienizar a parte vazada. Sem sujar as suas mãos, a Bandeja Sanitária Furba está pronta para ser usada novamente, pouco trabalho na hora de recolher e muita economia.", Fornecedor = "Animais Pet", Categoria = "Higiene", NomeProduto = "Bandeja Sanitária Furba Azul para Gatos", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/142848/product/8003507978010.jpg?1494956557", Preco = 128.5M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a",Fornecedor = "Animais Pet", Categoria = "Higiene", NomeProduto = "Granulado Sanitário ProGato", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/185249/product/3107699.jpg?1495067600", Preco = 8.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Descricao = @"* Por quê comprar ProGato Tradicional? <br/>
- Granulado branco, não forma torrão nem lama;<br/>
- Neutraliza odores como nenhum outro produto do gênero;<br/>
- Dura mais que o dobro dos granulados concorrentes;<br/>
- Alto Poder de Absorção;<br/>
- Natural e Atóxico;<br/>
- pH Neutro.<br/>", Detalhes = @"O Granulado Higiênico ProGato foi especialmente desenvolvido para absorver líquidos de forma rápida e eficaz. É um granulado sanitário 100% natural, de origem sedimentar vulcânica, o que lhe confere baixa umidade. Este granulado NÃO FORMA TORRÃO NEM LAMA, absorvendo maior quantidade de líquidos. Com coloração branca que se destaca dos granulados higiênicos comuns e rápida absorção, ProGato Tradicional evita que a urina chegue até o fundo da bandeja e que odores desagradáveis se dispersem pelo ar, não mancha e não gruda nas patinhas do seu pet.", Fornecedor = "Animais Pet", Categoria = "Higiene", NomeProduto = "Granulado Sanitário ProGato", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/185249/product/3107699.jpg?1495067600", Preco = 8.5M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Fornecedor = "Lorem Ipsum", Categoria = "Ração", NomeProduto = "Ração Premier Golden Formula Cães Filhotes Carne e Arroz", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/190269/product/Ra%C3%A7%C3%A3o_Premier_Golden_Formula_C%C3%A3es_Filhotes_Carne_e_Arroz_3Kg_3108200-1.jpg?1500407997", Preco = 39.90M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Descricao = @"- Alimento Premium Especial desenvolvido para cães filhotes; <br/>
- Pele saudável e pelagem bonita pela presença e equilibrio entre Omega 3 e Omega 6;<br/>
- Saúde intestinal: Promove fezes firmes e fáceis de limpar;<br/>
- Ótimo desenvolvimento: 27% de proteínas;<br/>
- Naturalmente saudável: Sem corantes e aromatizantes artificiais;<br/>
- Também é indicada para cadelas no terço final da gestação ou em fase de amamentação;<br/>
- Enriquecida com DHA: essencial ao desenvolvimento do cérebro e visão dos filhotes;<br/>

- Este produto possui Satisfação Garantida. Saiba mais abaixo na descrição.", Detalhes = @"A Ração Premier Golden Formula Cães Filhotes Carne e Arroz é um Alimento Premium Especial desenvolvido para cães filhotes desde o desmame até a idade adulta. Por se tratar de um alimento completo, não recomendamos nenhum tipo de suplementação. Devido a sua alta concentração de nutrientes, Golden Formula Cães Filhotes também é indicada para cadelas no terço final da gestação ou em fase de amamentação.<br/><br/>

Solicitações referentes à Garantia de Satisfação devem ser encaminhadas diretamente para o fabricante por meio do PremieR Responde – Telefone 0800 55 66 66. Para mais informações acesse: http://www.premierpet.com.br/garantia-premier-pet/", Fornecedor = "Lorem Ipsum", Categoria = "Ração", NomeProduto = "Ração Premier Golden Formula Cães Filhotes Carne e Arroz", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/190269/product/Ra%C3%A7%C3%A3o_Premier_Golden_Formula_C%C3%A3es_Filhotes_Carne_e_Arroz_3Kg_3108200-1.jpg?1500407997", Preco = 39.90M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Vestido Pickorruchos Tifany Vermelho para Cães", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/184018/product/Tifany-Vermelho.jpg?1495065250", Preco = 40.90M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Descricao = @"- Indicado para os dias quentes de verão; </br>
- Tecido elástico e confortável;</br>
- Vestido gracioso de malha listrada;</br>
- Deixa sua cachorrinha muito mais charmosa!</br>", Detalhes = @"O Vestido Pickorruchos Tifany Vermelho para Cães é um modelo elegante e delicado, próprio para o verão. Vestido gracioso em malha listrada com modelagem evasê e laço com pingente, para dar um charme a mais. Possui botoes de pressão para fechar.", Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Vestido Pickorruchos Tifany Vermelho para Cães", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/184018/product/Tifany-Vermelho.jpg?1495065250", Preco = 40.90M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel { FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a",Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Óculos de Sol The Pets Brasil Sundog - Azul", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/195902/product/%C3%93culos_de_Sol_The_Pets_Brasil_Sundog_-_Azul_1859285_1.jpg?1522955739", Preco = 80M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Descricao = @"- Proteção para seu pet; <br/>
- Com correias ajustáveis;<br/>
- Prático e resistente.<br/>", Detalhes = @"Há acessórios que parecem desnecessários, mas que na realidade pode fazer diferença na vida do seu cachorro, o Óculos de Sol The Pets Brasil Sundog - Azul é um deles. Muito útil, protege a visão do seu cão contra os agentes externos do ambiente. Com lentes que protegem contra os raios UVA e UVB. Para o pet aventureiro que adora um passeio em veículos abertos é a opção ideal, pois evita machucados ocasionados por objetos estranhos. Sem contar que os óculos vai dar um toque todo especial no look do seu amiguinho, deixando-o mais lindo e charmoso!", Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Óculos de Sol The Pets Brasil Sundog - Azul", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/195902/product/%C3%93culos_de_Sol_The_Pets_Brasil_Sundog_-_Azul_1859285_1.jpg?1522955739", Preco = 80M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Casa Pet Injet Plástica - Vermelho", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/174818/product/Casa-Pet-Injet-Pl%C3%A1stica-Vermelho---Tam.-2.jpg?1495051393", Preco = 78M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="5d0566c9-12d4-4321-bccc-22a4c15cf16a", Descricao = @"- Fabricado com matéria-prima de qualidade; <br/>
- Higiênica;<br/>
- Lavável;<br/>
- Longa durabilidade;<br/>
- Protege contra friagem (assento distante do solo).<br/>", Detalhes = @"A Casa Pet Injet Plástica é feita com matéria prima de alta qualidade e resistência, proporcionando ao produto cores vivas e alta durabilidade. Seu pet merece esse luxo, e você toda a praticidade que os produtos Pet Injet oferecem, através de sua linha desenvolvida para os mais exigentes consumidores.", Fornecedor = "Lorem Ipsum", Categoria = "Vestuário", NomeProduto = "Casa Pet Injet Plástica - Vermelho", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/174818/product/Casa-Pet-Injet-Pl%C3%A1stica-Vermelho---Tam.-2.jpg?1495051393", Preco = 78M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Fornecedor = "Animais Pet", Categoria = "Vestuário", NomeProduto = "Casa Monster Cave Verde com Almofada Vermelha", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/165771/product/Casa_Monster_Cave_verde_com_Almofada_Vermelha.jpg?1494977148", Preco = 159.9M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="8efef7d5-3f52-49b4-bed6-804bc514b49a", Descricao = @"- Criados por uma empresa brasileira, o formato oval é patenteado pela Guisa Pet;<br/>
- Sustentável, as casinhas são totalmente recicláveis;<br/>
- Material Polimero Polipropileno, resistente e durável as interpéries (mesmo material usado em peças automotivas);<br/>
- Capa da almofada destacável pode ser lavada separadamente na máquina. O casulo é de fácil limpeza e não retém odores;<br/>
- Proteção (UV) contra raios solares, a cor do produto não desbota ao sol.<br/>", Detalhes = @"Cães são animais de toca. Isto é, costumam preferir dormir e relaxar em pequenas tocas. Dentro delas se sentem protegidos do mau tempo e do ataque de outros animais. Mesmo dentro de casa, onde estão protegidos contra esses perigos, os cães continuam querendo uma toca por necessidade instintiva. Eles gostam de ter um esconderijo ao qual recorrer em noites de trovoadas ou quando sentem dores ou querem comer um osso em paz, entre outras situações. Você percebe isso quando eles correm embaixo da cama ou da mesa.<br/><br/>", Fornecedor = "Animais Pet", Categoria = "Vestuário", NomeProduto = "Casa Monster Cave Verde com Almofada Vermelha", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/165771/product/Casa_Monster_Cave_verde_com_Almofada_Vermelha.jpg?1494977148", Preco = 159.9M });

                auxId = Guid.NewGuid();
                listaProdutos.Add(new ProdutoMongoDbModel {FornecedorUID="d2b54244-daf0-4a6f-ad10-d6441e4cbcbc", Fornecedor = "Mundo das Tartarugas", Categoria = "Ração", NomeProduto = "Ração Zootekna para Jabuti 80g", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/82586/product/jabuti.jpg?1494893343", Preco = 18.5M });
                listaProdutosDetalhes.Add(new ProdutoDetalheMongoDbModel {FornecedorUID="d2b54244-daf0-4a6f-ad10-d6441e4cbcbc", Descricao = "Com probiótico.", Detalhes = "A Ração Zootekna para Jabuti é uma ração balanceada enriquecida com vitaminas e minerais. Excelente fonte de proteína e energia.", Fornecedor = "Mundo das Tartarugas", Categoria = "Ração", NomeProduto = "Ração Zootekna para Jabuti 80g", CodigoProduto = auxId.ToString(), ImagemUrl = "https://www.petlove.com.br/images/products/82586/product/jabuti.jpg?1494893343", Preco = 18.5M });

                _database.GetCollection<ProdutoMongoDbModel>("produtos").InsertMany(listaProdutos);
                _database.GetCollection<ProdutoDetalheMongoDbModel>("produtos_detalhes").InsertMany(listaProdutosDetalhes);

                #endregion
            }
        }
    }
}