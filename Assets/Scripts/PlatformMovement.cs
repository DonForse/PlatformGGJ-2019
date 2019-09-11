using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public bool triggeredByPlayer;

    public float MovementRight;
    public float MovementLeft;
    public float MovementUp;
    public float MovementDown;


    public float HorizontalSpeed;
    public float VerticalSpeed;

    public float delay;

    private float timerDelay = 0f;
    private bool isPlayerOn;
    private bool returnToOriginalPosition;

    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;
    bool isWaiting = false;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = this.transform.position;
    }

    private void Update()
    {
        if (isWaiting) {
            timerDelay += Time.deltaTime;
            if (timerDelay >= delay)
            {
                isWaiting = false;
                timerDelay = 0f;
            }
            return;
        }

        if (triggeredByPlayer) {
            if (!isPlayerOn)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                     new Vector3(originalPos.x,
                         originalPos.y,
                         originalPos.z),
                     Mathf.Max(HorizontalSpeed,VerticalSpeed) * Time.deltaTime);
                return;
            }
        }

        if (HorizontalSpeed != 0)
        {
            #region Right
            if (MovementRight > 0)
            {
                if (right)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(originalPos.x + MovementRight,
                            this.transform.position.y,
                            this.transform.position.z),
                        HorizontalSpeed * Time.deltaTime);
                    if (this.transform.position.x >= originalPos.x + MovementRight)
                    {
                        isWaiting = true;
                        right = false;
                    }
                }
                else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(originalPos.x,
                            this.transform.position.y,
                            this.transform.position.z),
                        HorizontalSpeed * Time.deltaTime);
                    if (this.transform.position.x <= originalPos.x)
                    {
                        isWaiting = true;
                        right = true;
                    }
                }
            }
            #endregion

            #region Left
            if (MovementLeft > 0)
            {
                if (left)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(originalPos.x - MovementLeft,
                            this.transform.position.y,
                            this.transform.position.z),
                        HorizontalSpeed * Time.deltaTime);
                    if (this.transform.position.x <= originalPos.x - MovementLeft)
                    {
                        isWaiting = true;
                        left = false;
                    }
                }
                else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(originalPos.x,
                            this.transform.position.y,
                            this.transform.position.z),
                        HorizontalSpeed * Time.deltaTime);
                    if (this.transform.position.x >= originalPos.x)
                    {
                        isWaiting = true;
                        left = true;
                    }
                }
            }
            #endregion
        }

        if (VerticalSpeed != 0)
        {
            #region Up
            if (MovementUp > 0)
            {
                if (up)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(this.transform.position.x,
                            originalPos.y + MovementUp,
                            this.transform.position.z),
                        VerticalSpeed * Time.deltaTime);

                    if (this.transform.position.y >= originalPos.y + MovementUp)
                    {
                        isWaiting = true;
                        up = false;
                    }
                }
                else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(this.transform.position.x,
                            originalPos.y,
                            this.transform.position.z),
                        VerticalSpeed * Time.deltaTime);
                    if (this.transform.position.y <= originalPos.y)
                    {
                        isWaiting = true;
                        up = true;
                    }
                }
            }
            #endregion
            #region Down
            if (MovementDown > 0)
            {
                if (down)
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(this.transform.position.x,
                            originalPos.y - MovementDown,
                            this.transform.position.z),
                        VerticalSpeed * Time.deltaTime);
                    if (this.transform.position.y <= originalPos.y - MovementDown)
                    {
                        isWaiting = true;
                        down = false;
                    }
                }
                else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                        new Vector3(this.transform.position.x,
                            originalPos.y,
                            this.transform.position.z),
                        VerticalSpeed * Time.deltaTime);
                    if (this.transform.position.y >= originalPos.y)
                    {
                        isWaiting = true;
                        down = true;
                    }
                }
            }
            #endregion
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
            isPlayerOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
            isPlayerOn = false;
    }
}