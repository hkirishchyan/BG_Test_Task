using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private GameObject brush;
    [SerializeField] private Vector3 positionFix;
    [SerializeField] private float scaleFix;
    [SerializeField] private Vector2 mousePos;
    [SerializeField] private float edgeDifference;

    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;
    private Vector2 lastDistPos;
    private GameObject brushInstance;
    
    public List<Vector2> standPoints = new List<Vector2>();

    private void Update()
    {
        Drawing();
    }

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Destroy(brushInstance);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
            Distribution();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        brushInstance = Instantiate(brush,transform.position,Quaternion.identity,transform);
        brushInstance.layer = 6;
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = scaleFix; //distance of the plane from the camera
        mousePos = Camera.main.ScreenToWorldPoint(screenPoint)+positionFix;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = scaleFix; //distance of the plane from the camera
        mousePos = Camera.main.ScreenToWorldPoint(screenPoint)+positionFix;
        if (lastPos != mousePos && mousePos.x>-9 && mousePos.x<9 && mousePos.y>-8 && mousePos.y<8)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
    void Distribution()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = scaleFix; //distance of the plane from the camera
        mousePos = Camera.main.ScreenToWorldPoint(screenPoint)+positionFix;
        if(Vector2.Distance(lastDistPos,mousePos) > edgeDifference)
        {
            standPoints.Add(mousePos);
            lastDistPos = mousePos;
        }
    }
}
