using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private bool movingTowardsA = true;

    void Update()
    {
        // Obtenez la position actuelle de l'ennemi
        Vector3 currentPosition = transform.position;

        if (movingTowardsA)
        {
            // Déplacez l'ennemi vers le point A en conservant la position Y
            currentPosition = Vector3.MoveTowards(currentPosition, new Vector3(pointA.position.x, currentPosition.y, currentPosition.z), speed * Time.deltaTime);

            // Changez la direction si l'ennemi atteint le point A
            if (Vector3.Distance(currentPosition, new Vector3(pointA.position.x, currentPosition.y, currentPosition.z)) < 0.1f)
            {
                movingTowardsA = false;
            }
        }
        else
        {
            // Déplacez l'ennemi vers le point B en conservant la position Y
            currentPosition = Vector3.MoveTowards(currentPosition, new Vector3(pointB.position.x, currentPosition.y, currentPosition.z), speed * Time.deltaTime);

            // Changez la direction si l'ennemi atteint le point B
            if (Vector3.Distance(currentPosition, new Vector3(pointB.position.x, currentPosition.y, currentPosition.z)) < 0.1f)
            {
                movingTowardsA = true;
            }
        }

        // Mettez à jour la position de l'ennemi
        transform.position = currentPosition;
    }
}
