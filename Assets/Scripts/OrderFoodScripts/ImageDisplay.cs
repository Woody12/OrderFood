using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    private Image m_Image;

    [SerializeField]
    private Sprite imageName;

    /// <summary>
    /// The sprites for this color changer.
    /// </summary>
    public Sprite ImageName
    {
        get => imageName;
        set => imageName = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        updateImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateImage()
    {
        m_Image = GetComponent<Image>();
        m_Image.sprite = imageName;
    }
}
