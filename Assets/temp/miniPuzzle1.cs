using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniPuzzle1 : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private void Start() 
    {
        
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel corrdinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z corrdinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag() {
        transform.position = GetMouseWorldPos() + mOffset;  
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.collider.CompareTag("object"))
        {
            // if(Input.GetKey(KeyCode.F))
            // {
            //     GameManager.Instance.SetClearPuzzle(0);
            //     SceneManager.LoadScene("Temp 1");
            // }
        }
    }
}
