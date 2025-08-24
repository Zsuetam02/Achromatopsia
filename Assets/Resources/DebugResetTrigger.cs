using UnityEngine;

public class DebugResetTrigger : MonoBehaviour
{
    public GameResetManager resetManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetManager.ResetGame();
        }
    }
}