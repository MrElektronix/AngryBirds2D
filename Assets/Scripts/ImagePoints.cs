using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ImagePoints : MonoBehaviour {
    //public Sprite[] imageNumbers;
    [SerializeField]
    private Sprite[] imageNumbers;
    [SerializeField]
    private int[] Numbers;

    [SerializeField]
    private Image onesImage;

    [SerializeField]
    private Image tensImage;

    [SerializeField]
    private Image hunderdsImage;

    [SerializeField]
    private Image thousandImage;

    private int oneString;


    // Use this for initialization
    void Start () {
        SetPoint(470);
    }

    void SetPoint(int pointAmount)
    {
        int currentPoints = pointAmount;
        currentPoints += pointAmount;
        Debug.Log(currentPoints);
        string newstring = currentPoints.ToString();

        int one = (int)char.GetNumericValue(newstring[newstring.Length - 1]);
        int two = (int)char.GetNumericValue(newstring[newstring.Length - 2]);
        int three = (int)char.GetNumericValue(newstring[newstring.Length - 3]);

        onesImage.sprite = imageNumbers[one];
        tensImage.sprite = imageNumbers[two];
        hunderdsImage.sprite = imageNumbers[three];
        if (currentPoints >= 1000)
        {
            int four = (int)char.GetNumericValue(newstring[newstring.Length - 4]);
            thousandImage.sprite = imageNumbers[four];
        }
    }


	
	// Update is called once per frame
	void Update () {

    }
}
