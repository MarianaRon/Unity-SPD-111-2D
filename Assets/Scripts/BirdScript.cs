using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI passedLabel;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel;
    [SerializeField]
    private LifeDisplay lifeDisplay; //LifeDisplay
    [SerializeField]
    private PipeScript pipeScript; //PipeScript


    private Rigidbody2D rigidBody; //Посилання
    private int life;
    private int score;
    private bool needClear;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdScript Start");

        //пошук компонента та одержання посилання на нього
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        life = 2;
        needClear = false;
        HideAlert();

        if (lifeDisplay != null)
        {
            lifeDisplay.UpdateLifeDisplay(life);
        }
        else
        {
            Debug.LogError("LifeDisplay is not assigned in the Inspector");
        }

        if (pipeScript == null)
        {
            Debug.LogError("PipeScript is not assigned in the Inspector");
        }


    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 300) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (alert.activeSelf)
            {
                HideAlert();
            }
            else
            {
                ShowAlert("Paused");
            }
        }

    }
    /* Подія, що виникає при перетині колайдерів-тригерів */

    private void OnTriggerEnter2D(Collider2D other)
    {
        /* if(other.gameObject.CompareTag("Pipe"))
         {
             Debug.Log("Enter: " + other.gameObject.name);
             needClear = true;
             ShowAlert("BOOM!)");
         }*/
        if (other.gameObject.CompareTag("Pipe"))
       {
            Debug.Log("Collision: " + other.gameObject.name);
            needClear = true;
            life--;
            if (lifeDisplay != null)
            {
                lifeDisplay.UpdateLifeDisplay(life); // Обновляем отображение жизней
            }
            else
            {
                Debug.LogError("LifeDisplay is not assigned in the Inspector");
            }
            if (life < 1)
            {

                score = 0;
                passedLabel.text = score.ToString("D3");
                life = 2;
                ShowAlert("GAME OVER");
               
            }
            else
            {
                ShowAlert("BOOM!)");
            }


        }
       /* if (other.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("Collision: " + other.gameObject.name);
            //bonusClear = true;
            life++; //тут меняется значение life

            if (lifeDisplay != null)
            {
                lifeDisplay.UpdateLifeDisplay(life); // Обновляем отображение жизней
            }
            else
            {
                Debug.LogError("LifeDisplay is not assigned in the Inspector");
            }

            Destroy(other.gameObject); // Удаляем объект Bonus
        }*/

    }
    /*Подія, що виникає при роз'єднанні колайдерів-тригерів*/
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pass"))
        {
            Debug.Log("+1");
            score++;
            passedLabel.text = score.ToString("D3");
            /////
         
        }

    }
   
    private void ShowAlert(string message)
    {
        alert.SetActive(true);
        alertLabel.text = message;
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);

    }
    public void HideAlert()
    {
        alert.SetActive(false);
        Time.timeScale = 1f;
        if (needClear)
        {
            foreach(var pipe in GameObject.FindGameObjectsWithTag("Pass"))
            {
                GameObject.Destroy(pipe);

            }
            needClear = false;
            
        }
    }


}
