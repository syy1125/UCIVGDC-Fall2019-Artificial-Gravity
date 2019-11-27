using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIRevealer : MonoBehaviour
{

    // Use this for initialization
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public bool revealed;
    public Direction anchorDirection;
    public enum SpeedType
    {
        linear,
        multiplicative
    }
    public SpeedType speedType;
    public float speed;             //if linear, move x% of screen per second.  if multiplicative, multiply distance from target by speed every frame
    private float[] hiddenAnchors;
    private float[] revealedAnchors;
    /*
     *   --------[2,3]
     *   |         |
     *   |         |
     * [0,1]--------
     */
    private Vector2 moveVector;
    private RectTransform myTransform;
    public float snapTolerance = 0.05f;
    private bool moving;
    public bool revealOnLoad;
    public bool hideOnLoad;

    private bool debug = false;
    void Start()
    {


        /* use speedfactor of 100 for instant movement
         * This doesn't correlate to pixels or time or anything because I'm
         * just done with this script. 
         * 
         * Major resizing of the game window WILL break this 
         * */

        if (GetComponent<Image>() != null && !GetComponent<Image>().enabled)
        {
            //You can disable the Image component of any UI element with a UIRevealer
            //for easier viewing of UI underneath and it will re-enable on scene start
            GetComponent<Image>().enabled = true;
        }
        myTransform = GetComponent<RectTransform>();
        revealedAnchors = new float[4];
        hiddenAnchors = new float[4];
        revealedAnchors[0] = myTransform.anchorMin.x;  //saves current location for when the UI is revealed later
        revealedAnchors[1] = myTransform.anchorMin.y;
        revealedAnchors[2] = myTransform.anchorMax.x;
        revealedAnchors[3] = myTransform.anchorMax.y;

        switch (anchorDirection)
        {
            case (Direction.Up):
                hiddenAnchors[0] = revealedAnchors[0];
                hiddenAnchors[1] = revealedAnchors[1] + (1 - revealedAnchors[1]) + 0.1f;
                hiddenAnchors[2] = revealedAnchors[2];
                hiddenAnchors[3] = revealedAnchors[3] + (1 - revealedAnchors[1]) + 0.1f;
                moveVector = new Vector2(0, 1);
                break;
            case (Direction.Down):
                hiddenAnchors[0] = revealedAnchors[0];
                hiddenAnchors[1] = revealedAnchors[1] - (revealedAnchors[3] + 0.1f);
                hiddenAnchors[2] = revealedAnchors[2];
                hiddenAnchors[3] = revealedAnchors[3] - (revealedAnchors[3] + 0.1f);
                moveVector = new Vector2(0, -1);
                break;
            case (Direction.Right):
                hiddenAnchors[0] = revealedAnchors[0] + (1 - revealedAnchors[0]) + 0.1f;
                hiddenAnchors[1] = revealedAnchors[1];
                hiddenAnchors[2] = revealedAnchors[2] + (1 - revealedAnchors[0]) + 0.1f;
                hiddenAnchors[3] = revealedAnchors[3];
                moveVector = new Vector2(1, 0);
                break;
            case (Direction.Left):
                hiddenAnchors[0] = revealedAnchors[0] - (revealedAnchors[2] + 0.1f);
                hiddenAnchors[1] = revealedAnchors[1];
                hiddenAnchors[2] = revealedAnchors[2] - (revealedAnchors[2] + 0.1f);
                hiddenAnchors[3] = revealedAnchors[3];
                moveVector = new Vector2(-1, 0);
                break;
        }
        if (!revealed)
        {
            setRectTransform(hiddenAnchors);
        }


        moving = false;
        if (revealOnLoad)  //UI element spawns offscreen and begins revealing instantly
        {
            revealUI();
        }
        else if (hideOnLoad)  //UI element spawns onscreen and begins hiding instantly
        {
            hideUI();
        }
    }

    void Update()
    {


        if (revealed && moving)
        {
            moveToLocation(revealedAnchors, -moveVector);
        }
        else if (!revealed && moving)
        {
            moveToLocation(hiddenAnchors, moveVector);
        }
        if (Input.GetKeyDown("space") && debug) //For testing purposes only.  Manual activation of all uirevealers
        {
            if (revealed)
            {
                hideUI();
            }
            else
            {
                revealUI();
            }

        }
    }
    public void moveToLocation(float[] targetAnchors, Vector3 move)
    {
        //moves towards location, snaps to location once close enough
        float[] newAnchors = new float[4];
        newAnchors[0] = myTransform.anchorMin.x;
        newAnchors[1] = myTransform.anchorMin.y;
        newAnchors[2] = myTransform.anchorMax.x;
        newAnchors[3] = myTransform.anchorMax.y;
        switch (speedType)
        {
            case (SpeedType.linear):
                newAnchors[0] += move.x * speed * Time.deltaTime;
                newAnchors[1] += move.y * speed * Time.deltaTime;
                newAnchors[2] += move.x * speed * Time.deltaTime;
                newAnchors[3] += move.y * speed * Time.deltaTime;
                if (Vector2.Distance(new Vector2(newAnchors[0], newAnchors[1]), new Vector2(targetAnchors[0], targetAnchors[1])) < speed * Time.deltaTime)
                {
                    setRectTransform(targetAnchors);
                    moving = false;
                }
                else
                {
                    setRectTransform(newAnchors);
                }
                break;
            case (SpeedType.multiplicative):
                newAnchors[0] += Mathf.Abs(moveVector.x) * (targetAnchors[0] - newAnchors[0]) * speed * Time.deltaTime;
                newAnchors[1] += Mathf.Abs(moveVector.y) * (targetAnchors[1] - newAnchors[1]) * speed * Time.deltaTime;
                newAnchors[2] += Mathf.Abs(moveVector.x) * (targetAnchors[2] - newAnchors[2]) * speed * Time.deltaTime;
                newAnchors[3] += Mathf.Abs(moveVector.y) * (targetAnchors[3] - newAnchors[3]) * speed * Time.deltaTime;
                if (Vector2.Distance(new Vector2(newAnchors[0], newAnchors[1]), new Vector2(targetAnchors[0], targetAnchors[1])) < snapTolerance)
                {
                    setRectTransform(targetAnchors);
                    moving = false;
                }
                else
                {
                    setRectTransform(newAnchors);
                }
                break;
        }
    }
    public void revealUI()
    {

        revealed = true;
        moving = true;

    }
    public void hideUI()
    {

        revealed = false;
        moving = true;

    }
    public void hideImmediately()
    {
        setRectTransform(hiddenAnchors);
        revealed = false;
        moving = false;
    }

    private void setRectTransform(float[] anchors)
    {
        myTransform.anchorMin = new Vector2(anchors[0], anchors[1]);
        myTransform.anchorMax = new Vector2(anchors[2], anchors[3]);
    }



}