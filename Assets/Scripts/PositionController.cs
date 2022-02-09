using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] private DrawLine drawLine;
    private int pointCount = 0;
    private Vector3 projectionTranslation;
    private Vector3 projectedPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
      if(Input.GetKeyUp(KeyCode.Mouse0))
        {
          pointCount = drawLine.standPoints.Count;
          int i = 0;
        foreach(Transform child in transform)
        {
          projectionTranslation = new Vector3(drawLine.standPoints[i].x,0,drawLine.standPoints[i].y)/3;
          projectedPosition = new Vector3(projectionTranslation.x,child.transform.position.y,transform.position.z+projectionTranslation.z+3);
          child.position=projectedPosition;
          i+=1;
        }
        drawLine.standPoints.Clear();
        }  
    }
}
