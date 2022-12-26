using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{

    bool isEffectActive = false;
    [SerializeField] private float effectDuration = 5f;
    [SerializeField] private float changeTo = 15f;
    float effectTimer = 0f;
    public static Controller Singleton;

    public void ActivateEffect()
    {
        isEffectActive = true;
        effectTimer = effectDuration;
    }

    void Update()
    {
        // Debug.Log("Jump height:" + Controller.Singleton.jumpHeight);
        if (isEffectActive)
        {
            if (effectTimer > 0)
            {
                effectTimer -= Time.deltaTime;
                // if (effectTimer < 0.1)
                // {
                //     Debug.Log("Jump effect is active. Time remaining: " + effectTimer);
                // }
                Controller.Singleton.jumpHeight = changeTo;
            }
            else
            {
                isEffectActive = false;
                Debug.Log("Jump effect is inactive.");
                Controller.Singleton.jumpHeight = 10f;
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        // Check if the object that collided with the star is the player
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Activate jump boost effect!");
            ActivateEffect();
        }
    }
}
