using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondController : MonoBehaviour
{
    private static int points = 0;
    public Text pointsText;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript.DiamondSound();
            points += 5;
            //Debug.Log("Puntos: " + points);
            pointsText.text = "Puntos: " + points.ToString();
            Destroy(gameObject);
        }
    }
}
