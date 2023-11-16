using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectCanvas : MonoBehaviour
{
    [SerializeField] Canvas myCanvas;
    private void Start()
    {
        myCanvas = GetComponent<Canvas>();
    }
    public void OnClick()
    {
        myCanvas.gameObject.SetActive(false);
    }
}
