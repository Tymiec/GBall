using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    bool isEffectActive = false;
    [SerializeField] private float effectDuration = 5f;
    [SerializeField] private float changeTo = 10f;
    float effectTimer = 0f;
    public static Controller Singleton;

    public void ActivateEffect()
    {
        isEffectActive = true;
        effectTimer = effectDuration;
    }

    void Update()
    {
        // Debug.Log("Speed:" + Controller.Singleton.speed);
        if (isEffectActive)
        {
            if (effectTimer > 0)
            {
                effectTimer -= Time.deltaTime;
                Debug.Log("Effect is active. Time remaining: " + effectTimer);
                Controller.Singleton.speed = changeTo;

            }
            else
            {
                isEffectActive = false;
                Debug.Log("Effect is inactive.");
                Controller.Singleton.speed = 3f;
            }
        }
    }

        private void OnCollisionEnter(Collision other) 
    {
        // Check if the object that collided with the star is the player
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Activate Effect!");
            ActivateEffect();
        }
    }
}
