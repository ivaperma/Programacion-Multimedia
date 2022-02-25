using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform playerPosition;
    private float speed = 3f;
    private SpriteRenderer spriteRendererEnemy;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position,speed * Time.deltaTime);
        if(transform.position.x < playerPosition.position.x)
        {
            spriteRendererEnemy.flipX = true;
        }else
        {
            spriteRendererEnemy.flipX = false;
        }

    }
}
