using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float speed = 1f;
    

    void Start()
    {
        StartCoroutine(FollowPath());
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPostiion = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            float rotationDegrees = degreesToRotate(this.transform.forward, startPostiion, endPosition);
            
            while(travelPercent < 1f)
            {   
                if(travelPercent < 0.25f)
                {
                    float rotationAngle = 4 * rotationDegrees * Time.deltaTime * speed;
                    transform.Rotate(new Vector3(0, rotationAngle, 0));
                }
                
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPostiion, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    float degreesToRotate(Vector3 currentDir, Vector3 currentPosition, Vector3 endPosition)
    {
        Vector3 targetDir = endPosition - currentPosition;
        return Vector3.SignedAngle(currentDir, targetDir, Vector3.up);
    }
}
