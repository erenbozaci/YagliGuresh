using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        //if (PlayerAnim.instance == null)
        //    Debug.Log("PLAER �S NULL");
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    private void Update()
    {
       
       //float healt = PlayerAnim.instance.GetComponent<Health>().currentHealth;
       // SetHealth(healt);
    }

}

//Karakter koduna referanslamak i�in

// public HealthBar healthBar;

//olu�turulmal�.

//Max can� girmek i�in Start fonksiyonunda

// healthBar.SetHealth(maxHealth);

//olu�turulmal�.

//Karakter hasar ald���nda kalan can� g�stermek i�in

// healthBar.SetHealth(currentHealth);

//kodu hasar ald��� fonksiyona eklenmeli.

//Player Scriptine eklendikten sonra Unity �zerinden healthBar adl� gameObject "Health Bar" adl� yere eklenmeli.