using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] float timesopened = 0;
    [SerializeField] Canvas myCanvas;
    private void Start()
    {
        //myCanvas = GetComponent<Canvas>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && timesopened<1)
        {
            timesopened += 1;
            myCanvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            myCanvas.gameObject.SetActive(false);
        }
    }
}
