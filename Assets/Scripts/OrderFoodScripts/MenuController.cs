using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    private Network network = new Network();
    private Restaurant[] restaurants;
    private Menu[] menus;
    private int defaultSelectIndex = 0;

    public Restaurant[] Restaurants
    {
        get => restaurants;
        set => restaurants = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        loadRestaurants();
        loadMenus();
    }

    private void cacheRestaurant(Restaurant[] restaurants)
    {
        this.restaurants = restaurants;
    }

    private void cacheMenu(Menu[] menus)
    {
        this.menus = menus;
    }

    private GameObject findChildFromParent(string parentName, string childNameToFind)
    {
        string childLocation = parentName + "/" + childNameToFind;
        GameObject childObject = GameObject.Find(childLocation);
        return childObject;
    }

    private void setupMenu(Menu[] menus)
    {
        cacheMenu(menus);
        createMenuStore(menus);
        displayRestaurant();
    }

    private void createMenuStore(Menu[] menus) {
        GameObject menuButtonHeader = GameObject.FindGameObjectWithTag("MenuButtonHeader");
        var toggleCollectionImageScript = menuButtonHeader.GetComponent<ToggleCollectionImageChange>();

        if ((menuButtonHeader != null) && (toggleCollectionImageScript != null))
        {
            var sprites = toggleCollectionImageScript.Sprites;
            if ((sprites.Length != menus.Length) && (sprites.Length > 0))
            {
                Debug.LogError("Can't show menus as the length is not the same as the elements");
                return;
            }
            connectMenuElements(sprites);
            toggleCollectionImageScript.manualSetImage(sprites[defaultSelectIndex]);
        } else
        {
            Debug.Log("Can't find Button Header.");
        }
    }

    private void connectMenuElements(Sprite[] sprites)
    {
        for (int index = 0; index < menus.Length; index++)
        {
            GameObject menuButton = GameObject.FindGameObjectWithTag("MenuCategory" + index);
            GameObject buttonImage = findChildFromParent(menuButton.name + "/Image Mask", "Image");

            if (buttonImage != null)
            {
                Image image = buttonImage.GetComponent<Image>();
                Sprite mSprite = Resources.Load<Sprite>("Images/" + menus[index].menuDetails[0].imageName);
                if (mSprite != null)
                {
                    image.sprite = mSprite;
                    sprites[index] = mSprite;
                }
                else
                {
                    Debug.Log("Sprite can't be found");
                }
            }
            else
            {
                Debug.Log("Button image can't be found.");
            }
        }
    }
    private void loadRestaurants()
    {
        network.retrieveRestaurant(cacheRestaurant);
    }

    private void loadMenus()
    {
        network.retrieveMenu(setupMenu);
    }

    public void displayRestaurant()
    {
        GameObject menuButtonHeader = GameObject.FindGameObjectWithTag("MenuButtonHeader");
        var toggleCollectionImageScript = menuButtonHeader.GetComponent<ToggleCollectionImageChange>();

        if ((menuButtonHeader != null) && (toggleCollectionImageScript != null))
        {
            var selectIndex = toggleCollectionImageScript.currentSelectedIndex;
            if (typeof(Category).IsEnumDefined(selectIndex)) {
                Restaurant[] filteredRestaurants = retrieveRestaurant((Category)selectIndex);
                connectToRestaurants(filteredRestaurants);
            }
        }
    }

    private Restaurant[] retrieveRestaurant(Category category)
    {
        Restaurant[] filtered = restaurants.Where(x => x.category == category).ToArray();
        Debug.Log("restaurant filter for category " + category + "length: " + filtered.Length + " is " + filtered[0].name);
        return filtered;
    }

    private void connectToRestaurants(Restaurant[] filteredRestaurants)
    {
        for (int index = 0; index < 4; index++)
        {
            GameObject restaurantButton = GameObject.FindGameObjectWithTag("Restaurant" + index);
            
            if (index < filteredRestaurants.Length)
            {
                // Display the restaurant info
                GameObject displayText = findChildFromParent(restaurantButton.name + "/Frontplate/AnimatedContent", "Text");

                if (displayText != null)
                {
                    TMP_Text textMeshPro = displayText.GetComponent<TMP_Text>();
                   
                    if (textMeshPro != null)
                    {
                        var info = filteredRestaurants[index];
                        
                        textMeshPro.text = info.name + "\n" + info.address + " " + info.city + ", " + info.state + " " + info.zip;
                        
                       //textMeshPro.text = info.name;
                       restaurantButton.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        Debug.Log("Can't find text mesh pro.");
                    }
                }
                else
                {
                    Debug.Log("Button image can't be found.");
                }
            } else
            {
                // Hide the Button
                restaurantButton.transform.localScale = new Vector3(0, 0, 0);
            }
            
        }
    }
}

// TODO later:

/*
 * 
 *  var toggleCollectionImageScript = menuButtonHeader.GetComponent<ToggleCollectionImageChange>();
            var toggleCollection = toggleCollectionImageScript.ToggleCollection;

            if (toggleCollection != null)
            {

            List<StatefulInteractable> toggles = toggleCollection.Toggles; // new List<StatefulInteractable>();
            Debug.Log("there are count: " + toggles.Count);
                    //GameObject heroButton = (GameObject)Resources.Load("HeroButton");
                    Vector3 spawnPos = new Vector3(menuButton.transform.position.x + 50, menuButton.transform.position.y, 0);
                    var newHeroButton = Instantiate(menuButton, spawnPos, menuButton.transform.rotation);
             
                    newHeroButton.transform.parent = menuButtonHeader.transform;
               
                    var newToggle = Instantiate(toggles[0]);
    
                    toggles[0] = newHeroButton;
                    toggles.Add(newToggle);
                    toggleCollection.Toggles = toggles;
                    */