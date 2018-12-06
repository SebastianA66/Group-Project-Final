using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomGates
{
    public class Axe : MonoBehaviour
    {
        public int playerDMG = 1;
        public GameObject hammer;
        private Animator swing;
        public CharHandler axeCollider;

        public bool canSwing;

        private void Start()
        {
            canSwing = true;
            swing = GetComponent<Animator>();
        }

        private void Update()
        {
            // When left mouse is clicked and can swing is true
            if (Input.GetMouseButton(0) && canSwing)
            {
                Debug.Log("SwungBoi");
                // Disable can swing
                canSwing = false;
                // Play the swing animation
                swing.Play("Swing");
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            // When the axe collides with the enemy
            if (other.gameObject.tag == "Enemy")
            {

                NPCHandler npcHealth = other.GetComponent<NPCHandler>();
                if (npcHealth != null)
                {
                    // Enemy loses health
                   // npcHealth.TakeDMG(playerDMG, NPCHandler.);
                    Debug.Log("EnemyDie");
                }

            }
        }

        public void EnableSwing()
        {
            Debug.Log("EnabledBoi");
            // enable swing
            canSwing = true;
        }
    }

}