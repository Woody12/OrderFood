using Microsoft.MixedReality.Toolkit.UX;
using UnityEngine;

public class ToggleCollectionImageChange : MonoBehaviour
{
    [Tooltip("The ToggleCollection for Image change.")]
    [SerializeField]
    private ToggleCollection toggleCollection;

    /// <summary>
    /// The ToggleCollection for this color changer.
    /// </summary>
    public ToggleCollection ToggleCollection
    {
        get => toggleCollection;
        set => toggleCollection = value;
    }

    [SerializeField]
    private GameObject imagePanel;

    [Tooltip("The sprite for this color changer.")]
    [SerializeField]
    private Sprite[] sprites;

    /// <summary>
    /// The sprites for this color changer.
    /// </summary>
    public Sprite[] Sprites
    {
        get => sprites;
        set => sprites = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        ImageDisplay imageDisplay = createImageDisplay();
        if (imageDisplay == null) { return; }

        if (sprites.Length == 0)
        {
            Debug.LogWarning($"The sprites array in the ToggleCollectionImageChange script attached to {gameObject.name} is empty, add sprites.");
        }

        ToggleCollection.OnToggleSelected.AddListener((toggleSelectedIndex) =>
        {
            if (toggleSelectedIndex < sprites.Length && toggleSelectedIndex > -1)
            {
                imageDisplay.ImageName = sprites[toggleSelectedIndex];
                imageDisplay.updateImage();
            }
        });
    }

    private ImageDisplay createImageDisplay()
    {
        ImageDisplay imageDisplay = imagePanel.GetComponent<ImageDisplay>();
        if (imageDisplay != null)
        {
            return imageDisplay;
        }
        else
        {
            Debug.LogError("Can't find Image Display.");
            return null;
        }
    }

    public void manualSetImage(Sprite sprite)
    {
        ImageDisplay imageDisplay = createImageDisplay();
        if (imageDisplay != null)
        {
            imageDisplay.ImageName = sprite;
            imageDisplay.updateImage();
        }
    }
}