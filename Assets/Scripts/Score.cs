using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private ImagePoints imagePoints;
    private int score;

    private void Start()
    {
        imagePoints = GetComponent<ImagePoints>();
        score = 0;
    }

    public void NewPoints(int points)
    {
        score += points;
        imagePoints.SetImagePoints(score);
    }



}
