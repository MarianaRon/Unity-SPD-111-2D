using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesroyerScript : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)

        {
            GameObject.Destroy(other.gameObject);

        }


    }

