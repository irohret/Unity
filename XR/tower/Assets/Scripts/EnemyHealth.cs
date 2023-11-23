using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxHealth = 100f;
    private float health;
    // [SerializeField] private float damage = 10;

    //private Dropdown tagDropdown;

  //  public string[] Tags;
   //  public string SingleTag;

    public void Start(){
        health = maxHealth;
        
        //tagDropdown = GetComponent<Dropdown>();
        // UpdateHealthSlider();
        // PopulateDropdown();
    }

    private void Update(){
        if(slider != null && slider.value != health){
            slider.value = health;
        }
    }           

    // Function to populate the dropdown menu with available tags
    /*
    private void PopulateDropdown(){
        if(tagDropdown != null){
            tagDropdown.ClearOptions();

            // Populate the dropdown options with available tags
           // tagDropdown.AddOptions(new List<string>(Tags));
        }
    }*/

    public void TakeDamage(float damage){  
        health -= damage;

        if(health <= 0){
            die();
        }
        // Debug.Log("damage " + damage);
    }

    void die(){
        Destroy(gameObject);
    }
}
