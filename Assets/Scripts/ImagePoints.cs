using UnityEngine;
using UnityEngine.UI;

public class ImagePoints : MonoBehaviour {

    [SerializeField]
    private Sprite[] spriteNumbers;

    [SerializeField]
    private Image[] spritePositionImages;

    void Start () {
        SetImageActivity(-1, spritePositionImages.Length - 1, false);
    }


    public void SetImagePoints(int pointAmount)
    {
        string pointString = pointAmount.ToString();

        if (pointAmount > 0)
        {
            ImageNumber(1, pointString);
        }
        
        if (pointAmount >= 10)
        {
            ImageNumber(2, pointString);
        }
        
        if (pointAmount >= 100)
        {
            ImageNumber(3, pointString);
        }
        
        if (pointAmount >= 1000)
        {
            ImageNumber(4, pointString);
        }
        if (pointAmount >= 10000)
        {
            ImageNumber(5, pointString);
        }
    }

    private void ImageNumber(int characterCount, string newstring)
    {
        int numericValue = (int)char.GetNumericValue(newstring[newstring.Length - characterCount]);
        spritePositionImages[characterCount].sprite = spriteNumbers[numericValue];

        SetImageActivity(0, characterCount, true);
    }


    private void SetImageActivity(int minIndex, int maxIndex, bool active)
    {
        for (int i = maxIndex; i > minIndex; i--)
        {
            spritePositionImages[i].gameObject.SetActive(active);
        }
        
    }


}
