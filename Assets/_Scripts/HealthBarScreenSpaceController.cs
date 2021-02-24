using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScreenSpaceController : MonoBehaviour
{

    [Range(1, 100)] public int currentHealth = 100;
    [Range(1, 100)] public int maximumHealth = 100;

    private Slider healthbarSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthbarSlider = GetComponent<Slider>();
        currentHealth = maximumHealth;
        healthbarSlider.value = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void TakeDamage(int damage)
    {
        healthbarSlider.value -= damage;
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            healthbarSlider.value = 0;
            currentHealth = 0;
        }
    }

    public void Reset()
    {
        healthbarSlider.value = maximumHealth;
        currentHealth = maximumHealth;
    }
}
