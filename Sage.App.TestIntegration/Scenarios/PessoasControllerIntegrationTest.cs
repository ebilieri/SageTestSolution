using FluentAssertions;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Sage.App.TestIntegration.Fixtures;
using Sage.Domain.Entities;
using Xunit;
using Sage.API;
using System.Collections.Generic;

namespace Sage.App.TestIntegration.Scenarios
{
    [ExcludeFromCodeCoverage]
    public class PessoasControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PessoasControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task Get_Returns_Ok_Response()
        {
            var response = await _client.GetAsync("/api/pessoas");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Post_Returns_Created_Response()
        {
            var pessoa = new Pessoa
            {
                Nome = "Maira",
                Sobrenome = "Silva",
                Email = "silva@gmail.com",
                Rg = "1234568",
                Cpf = "012548978",
                EstadoCivil = Domain.Enums.EstadoCivilEnum.Casado,
                EnderecosPessoas = new List<Endereco>
                {
                    new Endereco
                    {
                        CEP = "126647",
                        Estado = "PR",
                        Cidade = "Curitiba",
                        Logradouro = "Rua 123",
                        Numero = 0,
                        Complemento = "AP 96",
                        TipoEndereco = Domain.Enums.TipoEnderecoEnum.Residencial
                    }
                }
            };

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pessoa), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/pessoas");
            postRequest.Content = httpContent;

            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Get_Returns_Ok_ResponseById()
        {
            var response = await _client.GetAsync("/api/pessoas/1");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
