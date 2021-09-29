using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   [SerializeField] private int water;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playermove player = other.gameObject.GetComponent<playermove>();
        if (player != null)
        {
           player.TakeWater(water);
            Destroy(gameObject);
        }
    }
}
