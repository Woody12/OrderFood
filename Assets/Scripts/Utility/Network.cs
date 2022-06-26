using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Linq;

static class GlobalData
{
    public static string restaurantData = @"[{
		""id"": 0,
		""category"": 0,
		""name"": ""Jack's Burger"",
		""address"": ""100 Main Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 1,
		""category"": 1,
		""name"": ""Panda Express"",
		""address"": ""110 Jack Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 2,
		""category"": 1,
		""name"": ""Asian Pearl"",
		""address"": ""240 Temple Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 3,
		""category"": 2,
		""name"": ""Gyro Bay"",
		""address"": ""250 Smith Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
""id"": 4,
		""category"": 2,
		""name"": ""Awesome Gyro"",
		""address"": ""3560 Big Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 5,
		""category"": 3,
		""name"": ""Mexico Lindo"",
		""address"": ""270 St John Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	},
	{
	""id"": 6,
		""category"": 3,
		""name"": ""Green Burrito"",
		""address"": ""350 Bay Street"",
		""city"": ""Los Angeles"",
		""state"": ""CA"",
		""zip"": ""90019""
	}
]";

	public static string menuData = @"  

";
}


public class Network
{
    public IEnumerator GetData(string url, System.Action<string, bool> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        byte[] result = request.downloadHandler.data;
        string jsonData = System.Text.Encoding.Default.GetString(result);

        callback(jsonData, request.error == null);
    }

    public async Task<string> FetchData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");

        UnityWebRequestAsyncOperation operation = request.SendWebRequest();

        while(!operation.isDone)
        {
            await Task.Yield();
        }

        if (request.error != null)
        {
            Debug.LogError("Error Fetching: " + request.error);
            return "";
        } else
        {
            return request.downloadHandler.text;
        }
    }
	/*
    public async Task<T> LoadLevelAsync<T>(string api, int num)
    {
        // Retrieve Data from source (DB)
        string url = "https://deathscape-express.herokuapp.com/" + api;
       
        string jsonData = await FetchData(url);
        Debug.Log(jsonData);

        BaseSchema[] baseSchemas = JSONHelper.ParseJsonArray<BaseSchema[]>
        return JSONHelper.ParseJsonArray<T>(baseSchemas[0].data);
    }
	*/
	private Restaurant[] LoadRestaurantAsync(Category category)  {
		return JSONHelper.ParseJsonArray<Restaurant[]>(GlobalData.restaurantData);
    }

	public Restaurant[] retrieveRestaurant(Category category)
    {
        Restaurant[] restaurants = (Restaurant[])LoadRestaurantAsync(category);
		Debug.Log("load restaurants are " + restaurants.Length + "and " + restaurants[0].category);
		
		Restaurant[] filtered =  restaurants.Where(x => x.category == category).ToArray();
		Debug.Log("restaurant filter for category " + category + "length: " + filtered.Length + " is " + filtered[1].name);
		return restaurants.Where(x => x.category == category).ToArray();
	}
}
