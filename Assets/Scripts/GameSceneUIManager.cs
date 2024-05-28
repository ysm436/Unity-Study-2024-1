using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSceneUIManager : MonoBehaviour
{
    public GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI PlayerHPText;
    public string playerHPText
    {
        set
        {
            PlayerHPText.text = value;
        }
    }

    void Awake()
    {
        GameOverUI.SetActive(false);
    }

    public void OnGameOver()
    {
        GameOverUI.SetActive(true);
    }

}
