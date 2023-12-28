using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public event Action OnDie;

    private Image healthBar;
    private Dictionary<Transform, Image> enemyHealthBars = new Dictionary<Transform, Image>();
    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;

        if (CompareTag("Player"))
        {
            InitPlayerHealthUI();
        }
        else if (CompareTag("Enemy"))
        {
            //healthBar = transform.Find("UI_Enemy/EnemyHPBar").GetComponent<Image>();
            //InitEnemyHealthUI();
            Transform enemyUI = transform.Find("UI_Enemy");
            healthBar = enemyUI.Find("EnemyHPBar").GetComponent<Image>();
            InitEnemyHealthUI();
            enemyHealthBars.Add(transform, healthBar);
        }
    }

   

    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        health = Mathf.Max(health - damage, 0);

        if (health == 0)
            OnDie?.Invoke();

        Debug.Log(health);


        if (CompareTag("Player"))
        {
            InitPlayerHealthUI();
        }
        else if (CompareTag("Enemy"))
        {
            InitEnemyHealthUI();
        }
    }

    private void InitPlayerHealthUI()
    {
        Image playerHPBar = GameObject.Find("PlayerHPBar").GetComponent<Image>();
        playerHPBar.fillAmount = (float)health / maxHealth;
    }

    private void InitEnemyHealthUI()
    {
        Image enemyHPBar;

        if (enemyHealthBars.TryGetValue(transform, out enemyHPBar))
        {
            enemyHPBar.fillAmount = (float)health / maxHealth;
        }
       
        //Image enemyHPBar = GameObject.Find("EnemyHPBar").GetComponent<Image>();
        //enemyHPBar.fillAmount = (float)health / maxHealth;
    }
}