using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // load selected scene
        // Application.LoadLevel("Game");
        SceneManager.LoadScene("Game");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
