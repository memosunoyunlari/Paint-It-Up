using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PaintingSystem : MonoBehaviour
{
    [SerializeField] GameObject paintCursor;
    [SerializeField] GameObject[] paintPrefabs;

    public float paintAmount = 30;
    [SerializeField] float verticalSpeed;
    [SerializeField] float cursorAccelerationValue = 0.3f;
    [SerializeField] float horizontalSpeed;

    public bool activation;

    private bool tips;
    private bool painting;
    private bool moveCursor;


    //painting prefabs

    Rigidbody rb;

    [SerializeField] GameObject paintPanelAndText;
    [SerializeField] GameObject lastPanel;

    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI paintAmountUI;



    private void Awake()
    {
        paintCursor.SetActive(false);
        tips = false;
        painting = false;
        rb = paintCursor.GetComponent<Rigidbody>();
        paintAmount = 30;
    }

    private void Update()
    {
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
            Time.timeScale = 0;
            lastPanel.SetActive(true);
        }

        if(moveCursor)
        {
            
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            verticalSpeed += cursorAccelerationValue * Time.deltaTime;

            Vector3 tempVect = new Vector3(horizontalInput, 1, 0);
            tempVect = new Vector3( tempVect.normalized.x * horizontalSpeed * Time.deltaTime, tempVect.normalized.y * verticalSpeed * Time.deltaTime);


            rb.MovePosition( paintCursor.transform.position + tempVect);
        }


    }


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
