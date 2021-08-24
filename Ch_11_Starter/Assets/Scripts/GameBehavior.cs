using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    public int maxItems;
    public Text HealthText;
    public Text ItemText;
    public Text ProgressText;
    public Button WinButton;
    public Button LossButton;

    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= maxItems)
            {
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
            }
            else
            {
                ProgressText.text = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 1;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Player Health: " + HP;

            if (_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }

            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Game Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        Utilities.RestartLevel(0);
    }
}