using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform LeftLeft, LeftRight, RightLeft, RightRight, TopLeft, TopRight; // the positions we can move to
    [SerializeField] Transform PlayerLeft, PlayerRight, PlayerTop; // the transforms we are moving
    [SerializeField] Vector3 LeftTarget, RightTarget, TopTarget; // where we want to move
    [SerializeField] float moveSpeed; // the speed that the player can move at

    private void Start()
    {
        LeftTarget = LeftLeft.position;
        RightTarget = RightLeft.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // update the speed of our game
        UpdateSpeed();
        // move in the fixed update
        ProcessPosition();
    }

    private void Update()
    {
        ProcessInput();
    }

    void UpdateSpeed()
    {
        if (GlowController.instance.mood == GlowController.moods.low)
            moveSpeed = 10f;

        if (GlowController.instance.mood == GlowController.moods.mid)
            moveSpeed = 25f;

        if (GlowController.instance.mood == GlowController.moods.high)
            moveSpeed = 50f;
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft(false);

        if (Input.GetKeyDown(KeyCode.D))
            MoveLeft(true);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveRight(true);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight(false);

        if (Input.GetKeyDown(KeyCode.W))
            MoveUp(false);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp(true);
       
    }

    void MoveLeft(bool moveRight)
    {
        // if last move was right
        if (!moveRight)
        {
            LeftTarget = LeftLeft.position;
        } else if (moveRight)
        {
            LeftTarget = LeftRight.position;
        }
    }

    void MoveRight(bool moveRight)
    {
        // if last move was right
        if (!moveRight)
        {
            RightTarget = RightLeft.position;
        }
        else if (moveRight)
        {
            RightTarget = RightRight.position;
        }
    }

    void MoveUp(bool moveRight)
    {
        if (!moveRight)
        {
            TopTarget = TopLeft.position;
        } else if (moveRight)
        {
            TopTarget = TopRight.position;
        }
    }

    void ProcessPosition()
    {
        PlayerLeft.position = Vector3.Lerp(PlayerLeft.position, LeftTarget, moveSpeed * Time.fixedDeltaTime);
        PlayerRight.position = Vector3.Lerp(PlayerRight.position, RightTarget, moveSpeed * Time.fixedDeltaTime);
        PlayerTop.position = Vector3.Lerp(PlayerTop.position, TopTarget, moveSpeed * Time.fixedDeltaTime);
    }
}
