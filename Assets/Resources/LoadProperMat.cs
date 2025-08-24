using UnityEngine;

public static class LoadProperMat
{
    public static Material[] LoadMat(StateMachine.GameState state)
    {
        switch (state)
        {
            case StateMachine.GameState.All:
                return Resources.LoadAll<Material>("Materials/All");
            case StateMachine.GameState.Protanopia:
                return Resources.LoadAll<Material>("Materials/Protanopia");
            case StateMachine.GameState.Deuteranopia:
                return Resources.LoadAll<Material>("Materials/Deuteranopia");
            case StateMachine.GameState.Tritanopia:
                return Resources.LoadAll<Material>("Materials/Tritanopia");
            case StateMachine.GameState.Protanomaly:
                return Resources.LoadAll<Material>("Materials/Protanomaly");
            case StateMachine.GameState.Deuteranomaly:
                return Resources.LoadAll<Material>("Materials/Deuteranomaly");
            case StateMachine.GameState.Tritanomaly:
                return Resources.LoadAll<Material>("Materials/Tritanomaly");
            case StateMachine.GameState.Monochromacy:
                return Resources.LoadAll<Material>("Materials/Monochromacy");
            default:
                return Resources.LoadAll<Material>("Materials/All");
        }
    }
}
