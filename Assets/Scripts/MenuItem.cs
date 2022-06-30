using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    [SerializeField] private MenuController _menuController;

    // Start is called before the first frame update
    void Start()
    {
        if (_menuController != null)
        {
           _menuController.displayMenu();
        }
    }
}
