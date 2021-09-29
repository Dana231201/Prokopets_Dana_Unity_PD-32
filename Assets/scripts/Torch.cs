using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private int torch;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playermove player = other.gameObject.GetComponent<playermove>();
        if (player != null)
        {
            player.FindTorch(torch);
            Destroy(gameObject);
        }
    }
}
