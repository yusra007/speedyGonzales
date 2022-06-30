using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class ArabaKontrol : MonoBehaviour
{
    [SerializeField]
    private float MaximumHizlanma = 200f;

    [SerializeField]
    private float donusHassasiyeti = 1f;

    [SerializeField]
    private float MaximumDonusAcisi = 45f;

    [SerializeField]
    private List<Wheel> wheels;

    [SerializeField]
    private float inputX, inputY;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        Move();
    }
    private void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * MaximumHizlanma * 500 * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HareketYonu();
    }


     void HareketYonu()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }
}
