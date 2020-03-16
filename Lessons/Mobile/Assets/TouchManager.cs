using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public Text label;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {
        //(bool, Vector2) result = GetTouchPosition();
        //if (result.Item1)
        //    label.text = "(" + result.Item2.x.ToString("0.00") + "," + result.Item2.y.ToString("0.00") + ")";

        if (Input.touchCount > 0)
            label.text = Input.GetTouch(0).phase.ToString();

        DrawerThyLine();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();


        #region appunti
        //if (Input.touchCount > 1)
        //{
        //    Touch t0 = Input.GetTouch(0);
        //    Touch t1 = Input.GetTouch(1);
        //    switch (t0.phase)
        //    {
        //        case TouchPhase.Began:
        //            float xPos = t0.position.x / Screen.width;
        //            break;
        //        case TouchPhase.Moved:
        //            Vector2 deltaM = t0.deltaPosition;
        //            float distance = (t1.position - t0.position).magnitude;
        //            break;
        //        case TouchPhase.Stationary:
        //            Vector2 deltaSpeed = t0.deltaPosition / t0.deltaTime;
        //            break;
        //        case TouchPhase.Ended:
        //        case TouchPhase.Canceled:
        //            float charge = Time.deltaTime * t0.pressure;
        //            break;
        //    }
        //}
        #endregion
    }

    public (bool, Vector2) GetTouchPosition()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Touch t0 = Input.GetTouch(0);
                return (true, Rapportizer(t0.position));
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                return (true, Rapportizer(Input.mousePosition));
            }
        }
        return (false, Vector2.zero);
    }

    private void DrawerThyLine()
    {
        if (Input.touchCount >= 2)
        {
            List<Vector3> points = new List<Vector3>();
            for (int i = 0; i < Input.touchCount; i++)
                points.Add((Vector2)Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position));

            points.Add((Vector2)Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));

            line.positionCount = points.Count;
            line.SetPositions(points.ToArray());
        }
        else
        {
            line.positionCount = 0;
            line.SetPositions(new Vector3[0]);
        }
    }

    private Vector2 Rapportizer(Vector3 pixelVector)
    {
        Vector2 rapported;
        rapported.x = pixelVector.x / Screen.width;
        rapported.y = pixelVector.y / Screen.height;
        return rapported;
    }

}
