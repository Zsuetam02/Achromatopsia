using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text correctScoreText;
    public TMP_Text incorrectScoreText;

    void Update()
    {
        correctScoreText.text = "Correct: " + ScoreManager.correctMatches;
        incorrectScoreText.text = "Wrong: " + ScoreManager.incorrectMatches;
    }
}