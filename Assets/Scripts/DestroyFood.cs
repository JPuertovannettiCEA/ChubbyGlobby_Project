using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFood : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DestroyFood"))
        {
            Destroy(gameObject);
            Debug.Log("DestroyingFood");
        }

        //if(other.gameObject.CompareTag("Player"))
        //{
            //Debug.Log("On Player Mouth");
            //_isOnMouth = true;
        //}
    }
}
