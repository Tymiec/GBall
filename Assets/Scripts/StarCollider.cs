using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollider : MonoBehaviour
{
    // The sound to play when the star is collected
    public AudioClip StarCollectedSound;
    
    private void OnCollisionEnter(Collision other) 
    {
        // Check if the object that collided with the star is the player
        if (other.gameObject.CompareTag("Player")) 
        {
            // If it is the player, then destroy the star
            Destroy(gameObject);
            Debug.Log("Star collected!");
        }
    }

    private void OnDestroy() 
    {
        // Play the star collected sound
        AudioSource.PlayClipAtPoint(StarCollectedSound, transform.position);
    }
}
