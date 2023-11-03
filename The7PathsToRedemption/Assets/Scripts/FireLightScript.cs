using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireLightScript : MonoBehaviour
{
    [SerializeField] Light2D Light;
    [SerializeField] float Changes = 1f;
    [SerializeField] float Min = 1.2f;
    [SerializeField] float Max = 1.5f;
    float Timer = 0f;
    void Start()
    {
        Light = GetComponent<Light2D>();
    }
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= Changes)
        {
            Timer = 0;
            float sum = Random.Range(Min, Max);
            Light.intensity = sum;
        }
    }
}
