using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryButton : MonoBehaviour
{
    [SerializeField] GameObject _hungryPanel, _hungryImageOne, _hungryImageTwo, _menu, _endDialog, _dashHolster;
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
        if (_endDialog == null)
            Debug.LogError("HungryButton::_endDialog is null");
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
        if (_menu == null)
        {
            Debug.LogError("HungryButton::_menu is null");
        }
        else if (!_menu.activeSelf)
        {
            _hungryPanel.SetActive(true);
            _hungryImageOne.SetActive(true);
            _hungryImageTwo.SetActive(true);
        }
        //hide the game objects
        else if (_menu.activeSelf)
        {
            // there would be methods to send the data to the different delivery sevices
            _hungryPanel.transform.localScale = new Vector3(0, 0, 0);
            //_hungryImageOne.transform.localScale = new Vector3(0, 0, 0);
            //_hungryImageTwo.transform.localScale = new Vector3(0, 0, 0);
            _menu.transform.localScale = new Vector3(0, 0, 0);
            _endDialog.SetActive(true);

        }
        else
        {
            Debug.LogError("HungryButton::_menu active not set");
        }
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

}
