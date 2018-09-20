using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
    int health;
    int damage;
    int actionpoints;
    public GameObject enemy;
    public Image healthbar;
    public Image actionbar;
    // Use this for initialization
    void Awake () {
        health = PlayerPrefs.GetInt("Health");
        damage = PlayerPrefs.GetInt("Damage");
        actionpoints = PlayerPrefs.GetInt("ActionPoints");
    }

    // Update is called once per frame
    void Update () {
        healthbar.fillAmount = health * 0.01f;
        actionbar.fillAmount = actionpoints * 0.01f;

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void Attack()
    {
        enemy.GetComponent<Stats>().TakeDamage(damage);
        actionpoints -= 20;
    }
    public void Defend()
    {
        health += 10;
        actionpoints += 20;
    }

}
