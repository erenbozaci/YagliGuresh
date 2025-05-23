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
        //    Debug.Log("PLAER ÝS NULL");
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

//Karakter koduna referanslamak için

// public HealthBar healthBar;

//oluþturulmalý.

//Max caný girmek için Start fonksiyonunda

// healthBar.SetHealth(maxHealth);

//oluþturulmalý.

//Karakter hasar aldýðýnda kalan caný göstermek için

// healthBar.SetHealth(currentHealth);

//kodu hasar aldýðý fonksiyona eklenmeli.

//Player Scriptine eklendikten sonra Unity üzerinden healthBar adlý gameObject "Health Bar" adlý yere eklenmeli.