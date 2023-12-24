using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    
    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    

    void OnEnable()
    {
        RecalculatePath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void RecalculatePath()
    {
        path.Clear();

        path = pathfinder.GetNewPath();
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Vector3 startPostiion = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            float rotationDegrees = degreesToRotate(this.transform.forward, startPostiion, endPosition);

            while (travelPercent < 1f)
            {
                if (travelPercent < 0.25f)
                {
                    float rotationAngle = 4 * rotationDegrees * Time.deltaTime * speed;
                    transform.Rotate(new Vector3(0, rotationAngle, 0));
                }

                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPostiion, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    float degreesToRotate(Vector3 currentDir, Vector3 currentPosition, Vector3 endPosition)
    {
        Vector3 targetDir = endPosition - currentPosition;
        return Vector3.SignedAngle(currentDir, targetDir, Vector3.up);
    }
}
