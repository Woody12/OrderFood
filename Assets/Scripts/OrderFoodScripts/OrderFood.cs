using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using TMPro;

public class OrderFood : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _sendButton;
   
    // Start is called before the first frame update
    void Start()
    {
        if (_menu == null)
            Debug.LogError("OrderFood::_menu is null");
        if (_mainMenu == null)
            Debug.LogError("OrderFood::_mainMenu is null");
        if (_sendButton == null)
            Debug.LogError("OrderFood::_sendButton is Null");
        
    }
    public void GetMenu()
    {
       // displayMenu
        _menu.SetActive(true);
        _sendButton.SetActive(true);

        //hide the main menu
        _mainMenu.transform.localScale = new Vector3(0, 0, 0);
    }
}
