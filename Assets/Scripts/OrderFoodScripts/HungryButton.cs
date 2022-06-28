using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryButton : MonoBehaviour
{
    [SerializeField] GameObject _hungryPanel, _hungryImageOne, _hungryImageTwo;
    // Start is called before the first frame update
    void Start()
    {
        if (_hungryImageOne == null)
            Debug.LogError("HungryButton::_hugnryImageOne is Null");
        if (_hungryImageTwo == null)
            Debug.LogError("HungryButton::_hungryImageTwo is Null");
        if (_hungryPanel == null)
            Debug.LogError("HungryButton::_hungryPanel is null");
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
        this.gameObject.SetActive(false);
    }

}
