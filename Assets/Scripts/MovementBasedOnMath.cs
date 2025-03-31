using UnityEngine;

public class MovementBasedOnMath : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 startPos;
    public Vector3 endPos;
    public Transform targetTrans;
    public Vector3 moveDirection = Vector3.left;
    public float amplitude = 4f;
    public float frequency = 0.5f;

    public enum MovementMathType
    {
        TowardsTarget,
        // SpeedPlusDir,
        // Random,
        // Noise,
        // Sin,
        Circle
    }
    public MovementMathType currentMovementType = MovementMathType.TowardsTarget;

    void Start()
    {
        // Set the starting position
        startPos = new Vector3(8f, 0f, 0f);
        transform.position = startPos;

        endPos = new Vector3(0f, 0f, 0f);

        targetTrans = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 movePos = new Vector3();
        switch (currentMovementType)
        {
            case MovementMathType.TowardsTarget:
                Debug.Log("Move Towards Target");
                endPos = targetTrans.position;
                Vector3 direction = (endPos - transform.position);

                Debug.Log("Direction: " + direction);
                Debug.Log("Direction Magnitude: " + direction.magnitude);
                Debug.Log("Dir / magnitude: " + direction.normalized);

                direction.Normalize();
                transform.position += direction * (speed * Time.deltaTime);
                break;

            // case MovementMathType.SpeedPlusDir:
            //     Debug.Log("Speed Plus Dir");
            //     moveDirection.Normalize();
            //     transform.position += moveDirection * (speed * Time.deltaTime);
            //     break;

            // case MovementMathType.Random:
            //     Debug.Log("Random");
            //     movePos = transform.position;
            //     movePos += Vector3.right * (speed * Time.deltaTime);
            //     movePos.y += Random.Range(-0.1f, 0.1f);
            //     transform.position = movePos;
            //     break;

            // case MovementMathType.Noise:
            //     Debug.Log("Noise");
            //     movePos = transform.position;
            //     movePos += Vector3.right * (speed * Time.deltaTime);
            //     movePos.y = Mathf.PerlinNoise(movePos.x * frequency, 0) * amplitude;
            //     transform.position = movePos;
            //     break;

            // case MovementMathType.Sin:
            //     Debug.Log("Sin");
            //     movePos = transform.position;
            //     movePos += Vector3.right * (speed * Time.deltaTime);
            //     movePos.y = Mathf.Sin(movePos.x * frequency) * amplitude;
            //     transform.position = movePos;
            //     break;

            case MovementMathType.Circle:
                Debug.Log("Circle");
                float posOnUnitCircle = Time.timeSinceLevelLoad;
                movePos.x = Mathf.Cos(-posOnUnitCircle) * amplitude;
                movePos.y = Mathf.Sin(-posOnUnitCircle) * amplitude;
                transform.position = movePos;
                break;

            default:
                Debug.Log("You have not implemented this movement type yet");
                break;
        }

        if (transform.position.x > 9)
        {
            movePos.x = -9;
            transform.position = movePos;
        }
    }
}