using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSystem : MonoBehaviour
{
    [SerializeField] GameObject paintCursor;
    [SerializeField] GameObject[] paintPrefabs;

    [SerializeField] float paintAmount = 15;
    [SerializeField] float verticalSpeed;
    [SerializeField] float cursorAccelerationValue = 0.3f;
    [SerializeField] float horizontalSpeed;

    public bool activation;

    private bool tips;
    private bool painting;
    private bool moveCursor;


    //painting prefabs

    Rigidbody rb;

    [SerializeField] GameObject panelAndText;
    


    private void Awake()
    {
        paintCursor.SetActive(false);
        tips = false;
        painting = false;
        rb = paintCursor.GetComponent<Rigidbody>();
    }

    private void Update()
    {
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
            Debug.Log(paintAmount);
            
                
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
        panelAndText.SetActive(true);
        tips = true;
    }

    IEnumerator PaintingItself()
    {
        tips = false;

        panelAndText.SetActive(false);

        //3
        yield return new WaitForSeconds(1);
        //2
        yield return new WaitForSeconds(1);
        //1
        yield return new WaitForSeconds(1);
        
        paintCursor.SetActive(true);

        painting = true;
        moveCursor = true;

    }
}
