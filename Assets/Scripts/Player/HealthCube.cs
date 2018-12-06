using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomGates
{   public class HealthCube : MonoBehaviour
    {
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                Destroy(gameObject);  // Destroys Health Box     
                print("Gained 50 Health");
                CharHandler.curHealth += 50;
            }
        }
    }
}
