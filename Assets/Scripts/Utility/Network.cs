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
        function(restaurants);
    }

    public void retrieveMenu(Action<Menu[]> function)
    {
        Menu[] menus = LoadDataAsync<Menu[]>(GlobalData.menuData);
        function(menus);
    }
}
