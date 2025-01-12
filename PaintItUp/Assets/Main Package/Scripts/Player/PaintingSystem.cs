﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PaintingSystem : MonoBehaviour
{
    [Header("Painting Variables")]
    [SerializeField] GameObject[] paintPrefabs;
    public float paintAmount = 30;
    [Header("Paint Cursor Variables")]
    [SerializeField] GameObject paintCursor;
    [SerializeField] float verticalSpeed;
    [SerializeField] float cursorAccelerationValue = 0.3f;
    [SerializeField] float horizontalSpeed;
    Rigidbody rb;

    [Header("Segment Bools")]
    public bool activation;
    private bool tips;
    private bool painting;
    private bool moveCursor;

    [Header("UI Elements")]
    [SerializeField] GameObject paintPanelAndText;
    [SerializeField] GameObject lastPanel;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI paintAmountUI;

    MovementManager moveManager;



    private void Awake()
    {
        //setup
        paintCursor.SetActive(false);
        tips = false;
        painting = false;
        rb = paintCursor.GetComponent<Rigidbody>();
        paintAmount = 30;

        moveManager = GetComponent<MovementManager>();
    }

    private void Update()
    {
        //updates paintAmount
        paintAmountUI.text = paintAmount.ToString();   

        if(activation)
        {
            StartCoroutine("PaintTips");
        }

        if(Input.GetKeyDown(KeyCode.Space) && tips)
        {
            StartCoroutine("PaintingItself");
        }

        if(Input.GetKeyDown(KeyCode.Space) && painting &&  0 < paintAmount )
        {
            
            
            var currentPrefabIndex = Random.Range(0, paintPrefabs.Length);
            Instantiate(paintPrefabs[currentPrefabIndex], paintCursor.transform.position, paintCursor.transform.rotation);
            paintAmount--;
            
            
                
        }
        if(paintAmount == 0 || paintCursor.transform.position.y > 53.64f)
        {
            

            paintCursor.SetActive(false);
            
            lastPanel.SetActive(true);

            moveManager.enabled = false;
        }

        //gets triggerred by painting tips part
        if(moveCursor)
        {
            
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            verticalSpeed += cursorAccelerationValue * Time.deltaTime;

            Vector3 tempVect = new Vector3(horizontalInput, 1, 0);
            tempVect = new Vector3( tempVect.normalized.x * horizontalSpeed * Time.deltaTime, tempVect.normalized.y * verticalSpeed * Time.deltaTime);


            rb.MovePosition( paintCursor.transform.position + tempVect);
        }


    }

    //Interconnected IEnumerators

    IEnumerator PaintTips()
    {
        activation = false;
        yield return new WaitForSeconds(1.5f);
        paintPanelAndText.SetActive(true);
        tips = true;
    }

    IEnumerator PaintingItself()
    {
        tips = false;

        paintPanelAndText.SetActive(false);

        countdown.enabled = true;
        countdown.text = 3.ToString();
        yield return new WaitForSeconds(1);
        countdown.text = 2.ToString();
        yield return new WaitForSeconds(1);
        countdown.text = 1.ToString();
        yield return new WaitForSeconds(1);
        countdown.enabled = false;
        
        paintCursor.SetActive(true);

        painting = true;
        moveCursor = true;

    }
}
