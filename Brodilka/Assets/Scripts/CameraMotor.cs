using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;


    private void LateUpdate()
    {
        Vector2 direction = Vector2.zero;
        
        float directionX=lookAt.position.x-transform.position.x;
        if(directionX > boundX || directionX<-boundX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                direction.x = directionX - boundX;

            }
            else
            {
                direction.x = directionX+boundX;
            }
        }

        float directionY = lookAt.position.y - transform.position.y;
        if (directionX > boundY || directionX < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                direction.y = directionY - boundY;

            }
            else
            {
                direction.y = directionY + boundY;
            }
        }
        transform.position += new Vector3(direction.x, direction.y,0);
    }
}
