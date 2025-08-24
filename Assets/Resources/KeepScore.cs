using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (CompareTag(col.tag))
        {
            Debug.Log("Correct score!");
            Destroy(col.gameObject);
            ScoreManager.correctMatches++;
        }
        else
        {
            Debug.Log("Wrong bin!");
            col.transform.position = new Vector3(0f, 2f, 0f);
            ScoreManager.incorrectMatches++;
        }
    }
}
