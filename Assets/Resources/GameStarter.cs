using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameStarter : MonoBehaviour
{
    public RandomBallGenerator generator;
    public float immunityDuration = 5f;
    public float checkInterval = 1f;
    public int ballsAmount = 30;
    public float delayReload = 3f;
    public GameResetManager resetManager;
    private bool immunityOver = false;


    void Start()
    {
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        
        for (int i = 5; i > 0; i--)
        {
            Debug.Log($"Game starts in: {i}");
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Start");
        generator.GenerateBalls(ballsAmount);

       
        yield return new WaitForSeconds(immunityDuration);
        immunityOver = true;
        Debug.Log("Immunity over, tracking starts.");

        
        StartCoroutine(CheckWinCondition());

    }

    IEnumerator CheckWinCondition()
    {
        while (true)
        {
            resetManager.spawnedBalls.RemoveAll(item => item == null);
            if (resetManager.spawnedBalls.Count == 0)
            {
                Debug.Log("You won");
                resetManager.ResetGame();
                yield break;
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }


    public void RestartGame()
    {
        StopAllCoroutines();
        Start();
    }

    public void StopGameAndQuit()
    {
        StopAllCoroutines();
        // YOUR LOGIC TO GO BACK TO PREVIOUS UI
    }
}