// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Components.Authorization;
// using System.Text.Json;
//
// namespace Workplace.Client.Services
// {
//     public class AuthService : IAuthService
//     {
//         private readonly HttpClient _httpClient;
//         private readonly CustomAuthenticationStateProvider _authenticationStateProvider;
//
//         public AuthService(HttpClient httpClient, CustomAuthenticationStateProvider authenticationStateProvider)
//         {
//             _httpClient = httpClient;
//             _authenticationStateProvider = authenticationStateProvider;
//         }
//
//         public string GetAuthorizationUrl()
//         {
//             var clientId = "workplace";
//             var redirectUri = "http://localhost:3000/";
//             var responseType = "code";
//             var scope = "openid";
//             return $"https://hits1.tyuiu.ru/oauth2/authorize?response_type={responseType}&client_id={clientId}&redirect_uri={redirectUri}&scope={scope}";
//         }
//
//         public async Task<string> GetTokenAsync(string authorizationCode)
//         {
//             var tokenRequestData = new Dictionary<string, string>
//             {
//                 { "grant_type", "authorization_code" },
//                 { "code", authorizationCode },
//                 { "redirect_uri", "http://localhost:3000/" },
//                 { "client_id", "workplace" }
//             };
//
//             var request = new HttpRequestMessage(HttpMethod.Post, "https://hits1.tyuiu.ru/oauth2/token")
//             {
//                 Content = new FormUrlEncodedContent(tokenRequestData)
//             };
//
//             request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//
//             try
//             {
//                 var response = await _httpClient.SendAsync(request);
//
//                 if (response.IsSuccessStatusCode)
//                 {
//                     var responseContent = await response.Content.ReadAsStringAsync();
//                     var jsonDocument = JsonDocument.Parse(responseContent);
//                     var token = jsonDocument.RootElement.GetProperty("access_token").GetString();
//
//                     _authenticationStateProvider.NotifyUserAuthentication(token);
//
//                     return token;
//                 }
//                 else
//                 {
//                     var errorContent = await response.Content.ReadAsStringAsync();
//                     Console.WriteLine("Error response: " + errorContent);
//                     return null;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Exception: " + ex.Message);
//                 throw;
//             }
//         }
//
//         public Task<bool> IsAuthenticatedAsync()
//         {
//             return Task.FromResult(true);
//         }
//     }
// }
