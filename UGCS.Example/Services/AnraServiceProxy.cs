using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Services.DTO;

namespace Services
{
	public class AnraServiceProxy
	{
			private string _anraServerUrl;
			private string _clientPrefix;
			private static string _userid;
			private static string _token;

			public AnraServiceProxy(string url)
			{
				_clientPrefix = System.Configuration.ConfigurationManager.AppSettings["clientPrefix"];
				_anraServerUrl = $"https://{url}";
			}

			

			public async Task<List<UssInstanceLookupItem>> GetUssInstances()
			{
				using (var client = new HttpClient())
				{
					// New code:
					var endPoint = "utm/listing";

					// New code:
					client.BaseAddress = new Uri(string.Concat(_anraServerUrl, endPoint));
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);


					var response = await client.GetAsync(client.BaseAddress);
					if (response.IsSuccessStatusCode)
					{
						var dataObjects = response.Content.ReadAsAsync<IEnumerable<UssInstanceLookupItem>>().Result;

						return dataObjects.Where(p => p.IsAnraUssInstance).ToList();
					}
				}

				return null;
			}

			public async Task<AuthResult> DoLogin(AuthRequest authReq)
			{
				using (var client = new HttpClient())
				{
					// New code:
					var endPoint = "/authenticate";

					// New code:
					client.BaseAddress = new Uri(string.Concat(_anraServerUrl, endPoint));
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var response = await client.PostAsJsonAsync(client.BaseAddress, authReq);

					if (response.IsSuccessStatusCode)
					{
						AuthResult result = await response.Content.ReadAsAsync<AuthResult>();
						_userid = result.UserId;
						_token = result.Token;
						return result;
					}
				}

				return null;
			}

			public async Task<object> PostTelemetryMessage(ServiceTelemetryDTO message)
			{
				using (var client = new HttpClient())
				{
					// New code:
					var endPoint = "/telemetry";

					// New code:                
					client.BaseAddress = new Uri(string.Concat(_anraServerUrl, endPoint));
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

					var response = await client.PostAsJsonAsync(client.BaseAddress, message);
					if (response.IsSuccessStatusCode)
					{
						var result = response.Content.ReadAsAsync<object>().Result;
						return result;
					}
				}

				return null;
			}
		}
	}


