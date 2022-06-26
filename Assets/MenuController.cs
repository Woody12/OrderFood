using UnityEngine;
using System.Linq;
using System;

public class MenuController : MonoBehaviour
{
    private Network network = new Network();
    private Restaurant[] restaurants;
    private Menu[] menus;

    public Restaurant[] Restaurants
    {
        get => restaurants;
        set => restaurants = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        loadRestaurants();
      //  loadMenus();

        Debug.Log("restaurant is " + retrieveRestaurant(Category.greek)[1].name);
    }

    private void cacheRestaurant(Restaurant[] restaurants)
    {
        this.restaurants = restaurants;
    }

    private void cacheMenu(Menu[] menus)
    {
        this.menus = menus;
    }

    private void setupMenu(Menu[] menus)
    {
        cacheMenu(menus);
    }

    private void loadRestaurants()
    {
        network.retrieveRestaurant(cacheRestaurant);
        
        Debug.Log("restaurant is " + restaurants.Length);
        Debug.Log("restaurant result is " + restaurants[1].name);
    }

    private void loadMenus()
    {
        network.retrieveMenu(setupMenu);

        Debug.Log("menu is " + menus.Length);
        Debug.Log("menu result is " + menus[0].id);
    }

    public Restaurant[] retrieveRestaurant(Category category)
    {
        Restaurant[] filtered = restaurants.Where(x => x.category == category).ToArray();
        Debug.Log("restaurant filter for category " + category + "length: " + filtered.Length + " is " + filtered[1].name);
        return filtered;
    }
}