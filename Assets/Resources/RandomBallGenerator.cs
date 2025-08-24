using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RandomBallGenerator : MonoBehaviour
{
    public GameObject ball;
    public int xRadius;
    public int zRadius;
    public GameResetManager resetManager;
    private Material[] materials;

    public void GenerateBalls(int amountGenerated)
    {
        Vector3 centralPos = transform.position;
        int iterateMatNum = 0;

        for (int i = 0; i < amountGenerated; i++)
        {
            float xOffset = Random.Range(-xRadius, xRadius);
            float zOffset = Random.Range(-zRadius, zRadius);
            Vector3 spawnPos = new Vector3(centralPos.x + xOffset, centralPos.y, centralPos.z + zOffset);

            Renderer rend = ball.GetComponent<Renderer>();

            // Load materials for the current game state
            materials = LoadProperMat.LoadMat(StateMachine.Instance.currentState);

            iterateMatNum = (iterateMatNum + 1) % 8;
            rend.material = materials[iterateMatNum];

            ball.tag = $"P{iterateMatNum + 1}";

            GameObject spawnedBall = Instantiate(ball, spawnPos, Quaternion.identity);
            if (resetManager != null)
                resetManager.RegisterBall(spawnedBall);

            Rigidbody rb = spawnedBall.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDirection = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(0.5f, 1.5f),
                    Random.Range(-1f, 1f)
                ).normalized;

                float forceMagnitude = Random.Range(5f, 15f);
                rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
