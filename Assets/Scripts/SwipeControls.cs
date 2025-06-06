using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    #region Instance
    private static SwipeControls instance;
    public static SwipeControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeControls>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeControls", typeof(SwipeControls)).GetComponent<SwipeControls>();
                }
            }
            return instance;
        }
        set { instance = value; }
    }
    #endregion

    private float deadzone = 5f;

    public bool swipeleft, swiperight;
    private Vector2 swipedelta, starttouch;
    private float lasttap;
    private float sqrdeadzone;

    #region Public Properties
    public Vector2 Swipedelta => swipedelta;
    public bool Swipeleft => swipeleft;
    public bool Swiperight => swiperight;
    #endregion

    private void Start()
    {
        sqrdeadzone = deadzone * deadzone;
    }

    private void LateUpdate()
    {
        swipeleft = swiperight = false;

        HandleTouch();
        HandleKeyboard();
        HandleGamepad();
    }

    private void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                starttouch = touch.position;
                lasttap = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                starttouch = swipedelta = Vector2.zero;
            }

            swipedelta = Vector2.zero;

            if (starttouch != Vector2.zero)
                swipedelta = touch.position - starttouch;

            if (swipedelta.sqrMagnitude > sqrdeadzone)
            {
                DetectSwipe(swipedelta);
                starttouch = swipedelta = Vector2.zero;
            }
        }
    }

    private void HandleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            swipeleft = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            swiperight = true;
    }

    private void HandleGamepad()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < -0.5f)
            swipeleft = true;
        else if (horizontal > 0.5f)
            swiperight = true;
    }

    private void DetectSwipe(Vector2 delta)
    {
        float x = delta.x;
        float y = delta.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
                swipeleft = true;
            else
                swiperight = true;
        }
    }
}
