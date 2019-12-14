using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float FullHealth = 100f;
    public float CurrentHealth;
    public Slider healthSlider;
    public Image damageFlash;
    public float flashSpeed = 5f;
    public float flashAlphaScaleToDamage = 0.1f;
    public float flashMaxAlpha = 0.8f;

    Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool isDead = false;
    bool isDamaged = false;
    PlayerMovement playerMovement;

    public void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void Start()
    {
        isDead = false;
        CurrentHealth = FullHealth;
        playerMovement.enabled = true;
    }

    public void Update()
    {
        if (isDamaged)
        {
            damageFlash.color = flashColour;
        }
        else
        {
            damageFlash.color = Color.Lerp(damageFlash.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        isDamaged = false;

        //Test Damage
        if (Input.GetKey("-"))
        {
            Damage(1f);
        }
    }

    public void Kill()
    {
        Debug.Log("U ded");
        isDead = true;
        playerMovement.enabled = false;
    }

    public void Damage(float damageValue)
    {
        isDamaged = true;
        healthSlider.value = CurrentHealth;
        CurrentHealth -= damageValue;
        flashColour.a = Mathf.Min(flashMaxAlpha, damageValue * flashAlphaScaleToDamage);
        if (CurrentHealth <= 0 && !isDead)
        {
            Kill();
        }
    }
}
