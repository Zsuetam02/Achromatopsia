using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepToCenter : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject creepObject;

    public float forceStrength;
    public float jerkForce;
    public float minJerkInterval;
    public float maxJerkInterval;

    public bool possesedBalls;

    private bool isHeld = false;
    private float disableTimeUntil = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        creepObject = GameObject.Find("BallGenerator");

        if (possesedBalls)
            StartCoroutine(RandomJerkRoutine());
    }

    void FixedUpdate()
    {
        if (creepObject == null || isHeld || Time.time < disableTimeUntil)
            return;

        Vector3 center = creepObject.transform.position;
        Vector3 direction = (center - transform.position).normalized;
        rb.AddForce(direction * forceStrength);
    }

    public void SetHeld(bool held)
    {
        isHeld = held;

        if (!held)
            disableTimeUntil = Time.time + 3f; 
    }

    IEnumerator RandomJerkRoutine()
    {
        while (true)
        {
            float interval = Random.Range(minJerkInterval, maxJerkInterval);
            yield return new WaitForSeconds(interval);

            if (!isHeld && Time.time >= disableTimeUntil)
            {
                Vector3 randomDirection = Random.onUnitSphere;
                rb.AddForce(randomDirection * jerkForce, ForceMode.Impulse);
            }
        }
    }
}