using UnityEngine;
using UnityEngine.UI;

public class ImagePoints : MonoBehaviour {
    //public Sprite[] imageNumbers;
    [SerializeField]
    private Sprite[] imageNumbers;

    [SerializeField]
    private int[] Numbers;

    [SerializeField]
    private Image onesImage, tensImage, hunderdsImage, thousandImage, tenthousandImage, hunderdthousandImage;
    private int oneString;

    private int Score;
    //public static ImagePoints instance;

    [SerializeField]
    private Text PointText;

    // Use this for initialization
    void Start () {
        tensImage.gameObject.SetActive(false);
        hunderdsImage.gameObject.SetActive(false);
        thousandImage.gameObject.SetActive(false);
        tenthousandImage.gameObject.SetActive(false);
        hunderdthousandImage.gameObject.SetActive(false);
        SetPoint(50);
        SetPoint(2000);
    }

    public void SetPoint(int pointAmount)
    {
        Score += pointAmount;
        //Debug.Log(Score);
        string newstring = Score.ToString();
        PointText.text = pointAmount.ToString();

        int one = (int)char.GetNumericValue(newstring[newstring.Length - 1]);
        onesImage.sprite = imageNumbers[one];
        
        
        if (Score >= 10)
        {
            int two = (int)char.GetNumericValue(newstring[newstring.Length - 2]);
            tensImage.sprite = imageNumbers[two];
            tensImage.gameObject.SetActive(true);
        }

        if (Score >= 100)
        {
            int three = (int)char.GetNumericValue(newstring[newstring.Length - 3]);
            hunderdsImage.sprite = imageNumbers[three];
            tensImage.gameObject.SetActive(true);
            hunderdsImage.gameObject.SetActive(true);
        }
        
        if (Score >= 1000)
        {
            int four = (int)char.GetNumericValue(newstring[newstring.Length - 4]);
            thousandImage.sprite = imageNumbers[four];
            tensImage.gameObject.SetActive(true);
            hunderdsImage.gameObject.SetActive(true);
            thousandImage.gameObject.SetActive(true);
        }
        if (Score >= 10000)
        {   
            int five = (int)char.GetNumericValue(newstring[newstring.Length - 5]);
            tenthousandImage.sprite = imageNumbers[five];
            tensImage.gameObject.SetActive(true);
            hunderdsImage.gameObject.SetActive(true);
            thousandImage.gameObject.SetActive(true);
            tenthousandImage.gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
 
    }
}
