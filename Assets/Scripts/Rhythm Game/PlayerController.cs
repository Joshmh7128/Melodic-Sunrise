using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform LeftLeft, LeftRight, RightLeft, RightRight, TopLeft, TopRight; // the positions we can move to
    [SerializeField] Transform PlayerLeft, PlayerRight, PlayerTop; // the transforms we are moving
    [SerializeField] Vector3 LeftTarget, RightTarget, TopTarget; // where we want to move
    [SerializeField] float moveSpeed; // the speed that the player can move at
    bool LLR, LRR, LTR; // what was our last position?

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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            MoveLeft();

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            MoveUp();
       
    }

    void MoveLeft()
    {
        // if last move was right
        if (LLR)
        {
            LeftTarget = LeftLeft.position;
            LLR = false;
        } else if (!LLR)
        {
            LeftTarget = LeftRight.position;
            LLR = true;
        }
    }

    void MoveRight()
    {
        // if last move was right
        if (LRR)
        {
            RightTarget = RightLeft.position;
            LRR = false;
        }
        else if (!LRR)
        {
            RightTarget = RightRight.position;
            LRR = true;
        }
    }

    void MoveUp()
    {

    }

    void ProcessPosition()
    {
        PlayerLeft.position = Vector3.Lerp(PlayerLeft.position, LeftTarget, moveSpeed * Time.fixedDeltaTime);
        PlayerRight.position = Vector3.Lerp(PlayerRight.position, RightTarget, moveSpeed * Time.fixedDeltaTime);
    }
}
