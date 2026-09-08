using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MOD.Pms.HttpApi.ExternalApiClients.Jund
{
    public class JundAuthHeaderHandler : HttpClientHandler, ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public JundAuthHeaderHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var oAuthClient = _httpClientFactory.CreateClient();
            var configurationSection = _configuration.GetSection("ExternalApis:Jund");

            var discoveryDoc = await oAuthClient.GetDiscoveryDocumentAsync(configurationSection["ClientCredential:Address"]);


            var clientCredential = new ClientCredentialsTokenRequest
            {
                GrantType = "client_credentials",
                Method = HttpMethod.Post,
                ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader,
                Address = discoveryDoc.TokenEndpoint,
                ClientId = configurationSection["ClientCredential:ClientId"],
                ClientSecret = configurationSection["ClientCredential:ClientSecret"],
                Scope = configurationSection["ClientCredential:Scope"],
            };

            // This code is to preview the request sent 
            if (request.Content != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                //var jsonData = JObject.Parse(requestBody);
                //var nic = jsonData.GetValue("HR023_NIC_NO").ToString();
                //if (nic == "21479268")
                //{

                //}
            }


            var tokenResponse = await oAuthClient.RequestClientCredentialsTokenAsync(clientCredential);
            //potentially refresh token here if it has expired etc.
            request.SetBearerToken(tokenResponse.AccessToken);
     //      request.RequestUri = new Uri("https://jundbe/api/app/integration/person-by-military-service-id/D1-7443");
            //request.RequestUri = new Uri("https://jundbe/api/app/integration/units-by-level-and-tenant/94ffcc2e-7587-419b-e948-39f8ede01390?level=3");
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            var resposne = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // This code is to preview the response received 
            if (resposne.Content != null)
            {
                var responseBody = await resposne.Content.ReadAsStringAsync();
            }
            return resposne;
        }
    }

}
