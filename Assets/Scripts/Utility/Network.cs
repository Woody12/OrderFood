using UnityEngine;
using System;

public class Network
{
    private T LoadDataAsync<T>(string data)
    {
        return JSONHelper.ParseJsonArray<T>(data);
    }

    public void retrieveRestaurant(Action<Restaurant[]> function)
    {
        Restaurant[] restaurants = LoadDataAsync<Restaurant[]>(GlobalData.restaurantData);
        Debug.Log("load restaurants are " + restaurants.Length + "and " + restaurants[0].category);
        function(restaurants);
    }

    public void retrieveMenu(Action<Menu[]> function)
    {
        Menu[] menus = LoadDataAsync<Menu[]>(GlobalData.menuData);
        Debug.Log("load menus are " + menus.Length + "and " + menus[0].menuDetails[0].name);
        function(menus);
    }
}
