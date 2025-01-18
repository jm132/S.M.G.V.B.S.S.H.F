using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthSCRIPT : MonoBehaviour
{

    public float health = 100;
    public float hp;
    public Slider HealthSlider;
    public static int finishtimer;

    void Start()
    {
        hp = health;
    }
    void Update()
    {
        HealthSlider.value = hp;
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        HealthSlider.value = hp / health;
        if (hp <= 0)
        {
            Kill();
        }
    }
    void Kill()
    {
        
        SceneManager.LoadScene("meau");
    }
}