using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rigidBody; //Посилання


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdScript");

        //пошук компонента та одержання посилання на нього
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 500));
        } 
    }
}
