using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace KingdomGates
{
    public class CharHandler : MonoBehaviour
    {
        public bool alive;
        public int maxHealth = 100;
        public static float curHealth;
        public GUIStyle healthBar;
        public bool takeDMG;
        //public int damage = 25;
        public int playerDMG = 1;
        public BoxCollider axeCollider;

        public Slider healthSlider;
        public float lerpSpeed;

        private void Awake()
        {
            // Health starts at max health
            curHealth = maxHealth;
            // Player starts alive
            alive = true;

        
        }

        private void Update()
        {

            if (curHealth >= 10)
            {
                if (curHealth != healthSlider.value)
                {
                    // Set the health bar's value to the current health.
                    healthSlider.value = Mathf.Lerp(healthSlider.value, curHealth, Time.deltaTime * lerpSpeed);
                }
            }
            else
            {

                healthSlider.value = curHealth;


            }


            // If current health is less than or equal to 0 and the player is alive
            if (curHealth <= 0 && alive)
            {
                // Make the player dead
                alive = false;
                Dead();
            }
            //if (curHealth <= 0)
            //{
            //    alive = false;
            //}
        }


        public void TakeDamage(int npcDmg)
        {
            curHealth -= npcDmg;
        }
        // When the player is dead
        public void Dead()
        {
            // Deactivate the player
            gameObject.SetActive(false);

            SceneManager.LoadScene(1);
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {

                NPCHandler npcHealth = other.GetComponent<NPCHandler>();
                if (npcHealth != null)
                {
                    npcHealth.TakeDMG( playerDMG, axeCollider);
                    Debug.Log("Enemy takes damage and doesn't know how to write debugs");
                    GameObject.Destroy(other.gameObject);
                }

                else if (GetComponent<PlayerController>().moveSpeed >= 30)
                {
                    npcHealth.TakeDMG( playerDMG, axeCollider);
                }
            }

        }

    }
}