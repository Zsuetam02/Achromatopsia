using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameModeMenu : MonoBehaviour
{
    public TMP_Dropdown dropdown; 

    public void PlayGame()
    {
        string selected = dropdown.options[dropdown.value].text;

       
        if (System.Enum.TryParse(selected, out StateMachine.GameState selectedState))
        {
            GameSettings.SelectedGameState = selectedState;
        }
        else
        {
            GameSettings.SelectedGameState = StateMachine.GameState.All; 
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
