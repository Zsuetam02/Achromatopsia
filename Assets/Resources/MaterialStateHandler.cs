using System.Collections;
using UnityEngine;

public class MaterialStateHandler : MonoBehaviour
{
    private Material[] materials;

    void OnEnable()
    {
        // Subscribe to state change event to update materials dynamically
        StateMachine.OnStateChanged += OnStateChanged;
    }

    void OnDisable()
    {
        // Unsubscribe from event to avoid memory leaks
        StateMachine.OnStateChanged -= OnStateChanged;
    }

    void Start()
    {
        StartCoroutine(InitializeMaterials());
    }

    IEnumerator InitializeMaterials()
    {
        // Wait until StateMachine instance is ready
        yield return new WaitUntil(() => StateMachine.Instance != null);
        
        // Apply materials for current game state at start
        ApplyMaterialsForState(StateMachine.Instance.currentState);
    }

    void OnStateChanged(StateMachine.GameState newState)
    {
        ApplyMaterialsForState(newState);
    }

    void ApplyMaterialsForState(StateMachine.GameState state)
    {
        // Load materials corresponding to the current color blindness state
        materials = LoadProperMat.LoadMat(state);

        if (materials == null || materials.Length == 0)
        {
            Debug.LogWarning("No materials loaded for state: " + state);
            return;
        }

        Debug.Log($"Applying materials for state: {state}, loaded {materials.Length} materials.");

        // Assuming 8 material types and tags "P1" to "P8"
        for (int i = 0; i < 8; i++)
        {
            string checkTag = "P" + (i + 1);
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(checkTag);

            foreach (var obj in taggedObjects)
            {
                Renderer rend = obj.GetComponent<Renderer>();
                if (rend != null && i < materials.Length)
                {
                    rend.material = materials[i];
                }
            }
        }
    }
}
