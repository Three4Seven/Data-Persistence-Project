using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 1.0f;
    public float MaxMovement = 2f;
    private GameObject paddle;
    private float size;
    public GameObject Ball;
    
    // Start is called before the first frame update
    void Start()
    {
        Speed = GameManager.instance.PaddleSpeedSetting;
        if (GameManager.instance.PaddleSpeedSetting == 1) { Speed = 3f; }
        if (GameManager.instance.PaddleSpeedSetting == 3) { Speed = 1f; }
        size = GameManager.instance.PaddleSizeSetting;
        if (GameManager.instance.PaddleSizeSetting == 1) { size = 3; MaxMovement = 1.75f; }
        if (GameManager.instance.PaddleSizeSetting == 3) { size = 1; MaxMovement = 2.1f; }
        paddle = this.gameObject;
        paddle.transform.localScale = new Vector3(paddle.transform.localScale.x * size, paddle.transform.localScale.y, paddle.transform.localScale.z);
        Ball.transform.localScale = new Vector3(Ball.transform.localScale.x / size, Ball.transform.localScale.y, Ball.transform.localScale.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
