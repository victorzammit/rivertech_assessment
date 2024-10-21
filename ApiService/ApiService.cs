using Newtonsoft.Json.Linq;

public class ApiService
{
    private static readonly HttpClient _client = new HttpClient();

    public async Task<JObject> GetUserData()
    {
        HttpResponseMessage response = await _client.GetAsync("https://jsonplaceholder.typicode.com/users/1");
        response.EnsureSuccessStatusCode();
        string responseData = await response.Content.ReadAsStringAsync();
        return JObject.Parse(responseData);
    }
}
