using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragger : MonoBehaviour
{
    [SerializeField] private GameObject currentDrag;
    private bool isDragging;
    private bool horizontal;
    //private float moveSpeed = .1f;
    public void OnMouseDown()
    {
        isDragging = true;
    }
    public void OnMouseUp()
    {
        float roundx = 0f;
        float roundy = 0f;
        isDragging = false;
        if(currentDrag.name.Equals("Player")|| currentDrag.name.Equals("HorizontalCar")){
            roundx = MathF.Round(currentDrag.transform.position.x);
            roundy = currentDrag.transform.position.y;
        }
        if(currentDrag.name.Equals("HorizontalTruck1")|| currentDrag.name.Equals("HorizontalTruck2"))
        {
            roundx = Mathf.Round(currentDrag.transform.position.x) - .5f;
            roundy = currentDrag.transform.position.y;
        }
        if(currentDrag.name.Equals("VerticalCar1")|| currentDrag.name.Equals("VerticalCar2"))
        {
            roundx = currentDrag.transform.position.x;
            roundy = Mathf.Round(currentDrag.transform.position.y);
        }
        if (currentDrag.name.Equals("VerticalTruck"))
        {
            roundx = currentDrag.transform.position.x;
            roundy = Mathf.Round(currentDrag.transform.position.y) - .5f;
        }
        transform.position = new Vector3(roundx, roundy);
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float mousePositionRound = (mousePosition.x);
        if (horizontal && isDragging)
        {
            transform.Translate(mousePosition.x, 0f, 0f);
        }
        else if(!horizontal && isDragging)
        {
            print("!horizontal");
            transform.Translate(0f, mousePosition.y, 0f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isDragging = false;
    }
    void Start()
    {
        if (currentDrag.name.Equals("Player") || currentDrag.name.Equals("HorizontalTruck1") || currentDrag.name.Equals("HorizontalTruck2")|| currentDrag.name.Equals("HorizontalCar"))
        {
            horizontal = true;
            print("horizontal");
        }
        if (currentDrag.name.Equals("VerticalTruck") || currentDrag.name.Equals("VerticalCar1")||currentDrag.name.Equals("VerticalCar2"))
        {
            horizontal = false;
            print("vertical");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Finish") && currentDrag.name.Equals("Player"))
        {
            print("you win");
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(2);
            }
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
