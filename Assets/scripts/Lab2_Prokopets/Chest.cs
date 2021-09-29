using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
   [SerializeField] private int chest;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playermove player = other.gameObject.GetComponent<playermove>();
        if (player != null)
        {
            player.FindChest(chest);
            Destroy(gameObject);
        }
    }
}
