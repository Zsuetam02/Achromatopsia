using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetManager : MonoBehaviour
{
    public RandomBallGenerator ballGenerator;
    public GameStarter gameStarter;
    public GameObject player;
    public List<GameObject> spawnedBalls = new List<GameObject>();

    public void RegisterBall(GameObject ball)
    {
        spawnedBalls.Add(ball);
    }

    public void ResetGame()
    {
        StartCoroutine(ResetGameRoutine());
    }

    private IEnumerator ResetGameRoutine()
    {
        Debug.Log("Resetting game");

        SaveScoreForCurrentMode();

        ScoreManager.correctMatches = 0;
        ScoreManager.incorrectMatches = 0;

        if (spawnedBalls.Count != 0)
            spawnedBalls.Clear();

        yield return new WaitForSeconds(1f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MENU");
    }

    private void SaveScoreForCurrentMode()
    {
        var state = StateMachine.Instance.currentState.ToString();
        int correct = ScoreManager.correctMatches;
        int incorrect = ScoreManager.incorrectMatches;

        float finalScore = correct > 0 ? (float)(correct - incorrect) / correct : 0f;

        PlayerPrefs.SetFloat($"Score_{state}", finalScore);
        PlayerPrefs.Save();
    }
}
