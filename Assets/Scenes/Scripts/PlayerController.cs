using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedDecFactor;
    public Text countText;
    public Text winText;

   
    public GameObject[] WallsToDestory;//Creates Array of walls I will knock down
    public GameObject FirstAid;//Lets me reference The First Aid Kit
    public AudioClip FAPickedUp;

    private Rigidbody rb;
    private int health;
    private int EnemiesKilled;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 100;
        EnemiesKilled = 0;
        updateScore();
        winText.text = "";

        FirstAid = GameObject.Find("FirstAid");//Allows reference to FirstAid Kit
        WallsToDestory = GameObject.FindGameObjectsWithTag("SouthWalls");
        if(FirstAid != null)
        {
            //Debug.Log("Found FA");
            FirstAid.SetActive(false);
            //Debug.Log("FA Deactive");//Just testing stuff
        }
        if (WallsToDestory.Length == 0)
        {
            Debug.Log("No game objects are tagged with 'SouthWalls'");
        }
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
     }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            
            EnemiesKilled += 1;
            health -= 10;
            updateScore();
            speed *= speedDecFactor;
            
        }

        if (EnemiesKilled == 5)//Allows Player to Heal
        {
            FirstAid.SetActive(true);
            foreach (GameObject wall in WallsToDestory)
            {
                wall.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("FirstAid"))
        {

            Debug.Log("FA PICKED UP");
            AudioSource.PlayClipAtPoint(FAPickedUp, transform.position, 1);
            other.gameObject.SetActive(false);
            health += 40;
            speed = 15;
            updateScore();
            
            
            
        }

        if (EnemiesKilled == 10)//Game ends
        {
            winText.text = "You Won!";
        }

    }

    void updateScore()
    {
        countText.text = "Health: " + health.ToString();
        if(health == 0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        winText.text = "You done died...Somehow";
        speed = 0;
    }
}

