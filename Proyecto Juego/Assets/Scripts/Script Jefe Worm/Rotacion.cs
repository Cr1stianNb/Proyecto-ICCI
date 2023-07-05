using UnityEngine;

public class Rotacion : MonoBehaviour
{

    [SerializeField] private float velocidadRot;
    private static  bool canRotation = true;

    private void Update()
    {
        if(canRotation)
        {
            transform.Rotate(0, 0 , velocidadRot * Time.deltaTime);
        }


    }

    public void stopRotation()
    {
        canRotation = false;
    }
}
