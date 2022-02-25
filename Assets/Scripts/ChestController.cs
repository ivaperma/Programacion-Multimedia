using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    private Animator animatorChest;
    public bool hasKey = false;
    public GameObject panelWin;
    // Start is called before the first frame update
    void Start()
    {
        animatorChest=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && hasKey)
        {
            animatorChest.SetBool("isOpen", true);
            panelWin.SetActive(true);
        }
    }
}
