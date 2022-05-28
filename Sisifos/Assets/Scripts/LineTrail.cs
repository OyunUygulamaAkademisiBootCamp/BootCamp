using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrail : MonoBehaviour
{
    [SerializeField] LineRenderer myTrail = null;
    [SerializeField] Camera myCam;
    [SerializeField] float clearSpeed = 0.5f;
    [SerializeField] float cameraDistance = 1;

    private LineRenderer trailCurrent;
    private List<Vector3> points = new List<Vector3>();

    private void Update()
    {
        //if(Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            DestroyCurrentTrail();
            CreateCurrentTrail();
            AddPoint();
        }

        if (Input.GetMouseButton(0))
        //if (Input.touchCount == 1)
        {
            AddPoint();
        }

        UpdateTrailPoints();

        ClearTrailPoints();
    }

    private void DestroyCurrentTrail()
    {
        if (trailCurrent != null)
        {
            Destroy(trailCurrent.gameObject);
            trailCurrent = null;
            points.Clear();
        }
    }

    private void CreateCurrentTrail()
    {
        trailCurrent = Instantiate(myTrail);
        trailCurrent.transform.SetParent(transform, true);
    }

    private void AddPoint()
    {
        Vector3 touchPosition = Input.GetTouch(0).position;
        points.Add(myCam.ViewportToWorldPoint(new Vector3(touchPosition.x / Screen.width, touchPosition.y / Screen.height, cameraDistance)));

    }

    private void UpdateTrailPoints()
    {
        if (trailCurrent != null && points.Count > 1)
        {
            trailCurrent.positionCount = points.Count;
            trailCurrent.SetPositions(points.ToArray());
        }
        else
        {
            DestroyCurrentTrail();
        }
    }

    private void ClearTrailPoints()
    {
        float distanceClear = Time.deltaTime * clearSpeed;
        while (points.Count > 1 && distanceClear > 0)
        {
            float distance = (points[1] - points[0]).magnitude;
            if (distanceClear > distance)
            {
                points.RemoveAt(0);
            }
            else
            {
                points[0] = Vector3.Lerp(points[0], points[1], distanceClear / distance);

            }

            distanceClear -= distance;
        }

        void OnDisable()
        {
            DestroyCurrentTrail();
        }


    }
}
