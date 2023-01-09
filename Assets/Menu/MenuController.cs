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
    private VisualElement _buttonsWrapper;
    [SerializeField] private VisualTreeAsset _settingsButtonsTemplate;
    private VisualElement _settingsButtons;
    [SerializeField] private VisualTreeAsset _playButtonsTemplate;
    private VisualElement _playButtons;

    // private AssetBundle myLoadedAssetBundle;
    // private string[] scenePaths;

    private void Awake() 
    {
        _doc = GetComponent<UIDocument>();
        _buttonsWrapper = _doc.rootVisualElement.Q<VisualElement>("Buttons");
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");

        _settingsButtons = _settingsButtonsTemplate.CloneTree();
        _playButtons = _playButtonsTemplate.CloneTree();

        _playButton.clicked += OnPlayButtonClicked;
        _settingsButton.clicked += OnSettingsButtonClicked;
        _exitButton.clicked += OnExitButtonClicked;

        var backButton = _settingsButtons.Q<Button>("BackButton");
        var backButton2 = _playButtons.Q<Button>("BackButton2");
        backButton.clicked += BackButtonOnClicked;
        backButton2.clicked += BackButtonOnClicked;
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked");
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_playButtons);
        // SceneManager.LoadScene(0);
    }

    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked");
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_settingsButtons);
    }

    private void BackButtonOnClicked()
    {
        Debug.Log("Back button clicked");
        _buttonsWrapper.Clear();
        _buttonsWrapper.Add(_playButton);
        _buttonsWrapper.Add(_settingsButton);
        _buttonsWrapper.Add(_exitButton);
    }

    private void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }
}
