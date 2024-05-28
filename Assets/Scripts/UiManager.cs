using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI gameover;
    public TextMeshProUGUI hp;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
        player.GetComponent<Player>().OnGameover += UiGameover;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = player.GetComponent<Player>().hp + " / " + player.GetComponent<Player>().max_hp;
    }

    void UiGameover()
    {
        gameover.gameObject.SetActive(true);
    }
}
