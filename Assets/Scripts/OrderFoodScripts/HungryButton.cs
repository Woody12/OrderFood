using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryButton : MonoBehaviour
{
    [SerializeField] GameObject _hungryPanel, _hungryImageOne, _hungryImageTwo, _menu;
    // Start is called before the first frame update
    void Start()
    {
        if (_hungryImageOne == null)
            Debug.LogError("HungryButton::_hugnryImageOne is Null");
        if (_hungryImageTwo == null)
            Debug.LogError("HungryButton::_hungryImageTwo is Null");
        if (_hungryPanel == null)
            Debug.LogError("HungryButton::_hungryPanel is null");
        if (_menu == null)
            Debug.LogError("HungryButton::_menu is null");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateHungryDash()
    {
        // This will set up the main screen
        // this is calling on a slight delay
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        _hungryPanel.SetActive(true);
        _hungryImageOne.SetActive(true);
        _hungryImageTwo.SetActive(true);
        //hide the game objects
        if (_menu.activeSelf)
        {
            _menu.transform.localScale = new Vector3(0, 0, 0);
            _hungryImageOne.transform.localScale = new Vector3(0, 0, 0);
            _hungryImageTwo.transform.localScale = new Vector3(0, 0, 0);

        }
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

}
