using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenUnitWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    
    void Update()
    {
        float mousePosUnits = (Input.mousePosition.x / Screen.width * screenUnitWidth);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosUnits, minX, maxX);
        transform.position = paddlePos;
    }
}
