using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScoreDisplay : MonoBehaviour
{
    public GameObject scoreTextPrefab; 
    public Transform scoreListParent;  

    private readonly List<string> gameModes = new List<string> 
    {
        "All",
        "Protanopia",
        "Deuteranopia",
        "Tritanopia",
        "Protanomaly",
        "Deuteranomaly",
        "Tritanomaly",
        "Monochromacy"
    };

    void Start()
    {
        foreach (string mode in gameModes)
        {
            int correct = PlayerPrefs.GetInt($"{mode}_Correct", 0);
            int wrong = PlayerPrefs.GetInt($"{mode}_Wrong", 0);

            string scoreStr;
            if (correct > 0)
            {
                float score = (float)(correct - wrong) / correct;
                scoreStr = $"{mode}: {score:F2}";
            }
            else
            {
                scoreStr = $"{mode}: N/A";
            }

            TMP_Text scoreText = Instantiate(scoreTextPrefab, scoreListParent).GetComponent<TMP_Text>();
            scoreText.text = scoreStr;
        }
    }
}
