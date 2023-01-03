using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument _doc;
    private Button _playButton;
    private Button _settingsButton;
    private Button _exitButton;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    private void Awake() 
    {
        _doc = GetComponent<UIDocument>();
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");

        _playButton.clicked += OnPlayButtonClicked;
        _settingsButton.clicked += OnSettingsButtonClicked;
        _exitButton.clicked += OnExitButtonClicked;

        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes/");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }

    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked");
    }

    private void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked");

    }
}
