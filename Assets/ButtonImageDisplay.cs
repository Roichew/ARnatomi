using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageDisplay : MonoBehaviour
{
    public Button button;
    public Image image;
    public List<string> imagePaths = new List<string>();
    public List<Vector2> imageSizes = new List<Vector2>();

    private RectTransform imageRectTransform;
    private Dictionary<Sprite, Vector2> imageDict = new Dictionary<Sprite, Vector2>();

    private void Start()
    {
        // Get the RectTransform component of the image
        imageRectTransform = image.GetComponent<RectTransform>();

        // Build the dictionary of images and sizes
        BuildImageDictionary();

        // Attach the button click listener
        button.onClick.AddListener(ChangeButtonImage);
    }

    private void ChangeButtonImage()
    {
        // Get a random image and its corresponding size from the dictionary
        KeyValuePair<Sprite, Vector2> randomImageSize = GetRandomImageSize();

        // Change the image sprite to the new image
        image.sprite = randomImageSize.Key;

        // Update the size of the image
        imageRectTransform.sizeDelta = randomImageSize.Value;
    }

    private void BuildImageDictionary()
    {
        // Clear the existing dictionary
        imageDict.Clear();

        // Ensure that the number of image paths and sizes match
        if (imagePaths.Count != imageSizes.Count)
        {
            Debug.LogError("The number of image paths does not match the number of image sizes.");
            return;
        }

        // Load images and their corresponding sizes
        for (int i = 0; i < imagePaths.Count; i++)
        {
            Sprite imageSprite = Resources.Load<Sprite>(imagePaths[i]);

            if (imageSprite != null)
            {
                imageDict.Add(imageSprite, imageSizes[i]);
            }
            else
            {
                Debug.LogError("Failed to load image at path: " + imagePaths[i]);
            }
        }
    }

    private KeyValuePair<Sprite, Vector2> GetRandomImageSize()
    {
        // Get a random key-value pair from the dictionary
        int randomIndex = Random.Range(0, imageDict.Count);
        KeyValuePair<Sprite, Vector2> randomImageSize = new KeyValuePair<Sprite, Vector2>();
        int currentIndex = 0;

        foreach (KeyValuePair<Sprite, Vector2> pair in imageDict)
        {
            if (currentIndex == randomIndex)
            {
                randomImageSize = pair;
                break;
            }

            currentIndex++;
        }

        return randomImageSize;
    }
}
