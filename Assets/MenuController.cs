using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Restaurant[] restaurants;

    // Start is called before the first frame update
    void Start()
    {
        retrieveRestaurant();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task<bool> retrieveRestaurant()
    {
        Debug.Log("Restaurant Info");
        Network network = new Network();
        restaurants = network.retrieveRestaurant(Category.mexican);
        
        Debug.Log("restaurant is " + restaurants.Length);
        Debug.Log("restaurant result is " + restaurants);
        return true;
    }
}