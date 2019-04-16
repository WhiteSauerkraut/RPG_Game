using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewScript : MonoBehaviour
{
    string playerName;
    int max_hp;
    int curr_hp;
    string detialHp;
    PlayerComponent player;
    Text detialText;
    public void Init(GameObject player)
    {
        this.player = player.GetComponent<PlayerComponent>();
        max_hp = this.player.M_BattleProperty.M_MaxHp;
        curr_hp = this.player.M_BattleProperty.M_CurrentHp;
        playerName = this.player.M_BasicProperty.M_Name;
        detialHp = curr_hp.ToString() + "/" + max_hp.ToString();
        detialText = transform.Find("Slider/DetailHP").GetComponent<Text>();
        detialText.text = detialHp;
        gameObject.GetComponentInChildren<Slider>().value = (float)curr_hp / max_hp;
        transform.Find("Name").GetComponent<Text>().text = playerName;
    }
    void Update()
    {
        int curr_hp_temp = player.M_BattleProperty.M_CurrentHp;

        if ( curr_hp != curr_hp_temp)
        {
            curr_hp = curr_hp_temp;
            detialHp = curr_hp.ToString() + "/" + max_hp.ToString();
            detialText.text = detialHp;
            gameObject.GetComponentInChildren<Slider>().value = (float)curr_hp / max_hp;
        }

    }
}
