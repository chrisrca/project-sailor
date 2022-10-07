using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public KeyCode inputShift = KeyCode.LeftShift;
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public GameObject staff;
    public GameObject player;
    private Vector3 cursorLocation = new Vector3(0f,0f,0f);
    private Vector3 cursorOffset = new Vector3(-500f,-340f,0f);
    private float angle;

    void Update()
    {
        if (Input.GetKey(inputShift)) {
            staff.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.layers[0].id;
        } else if (Input.GetKey(inputUp)) { 
            staff.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.layers[1].id;
        } else if (Input.GetKey(inputDown) || Input.GetKey(inputLeft) || Input.GetKey(inputRight)) {
            staff.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.layers[2].id;
        } 

        cursorLocation = (Input.mousePosition);
        cursorLocation = cursorLocation + cursorOffset;
        angle = Mathf.Abs(((Mathf.Atan2(cursorLocation.x, cursorLocation.y) * Mathf.Rad2Deg) - 450) % 360);
        staff.transform.eulerAngles = new Vector3(
            staff.transform.eulerAngles.x,
            staff.transform.eulerAngles.y,
            angle - 90);

        staff.transform.position = player.transform.position + new Vector3 (0f,0f,20f); 
    }
}
