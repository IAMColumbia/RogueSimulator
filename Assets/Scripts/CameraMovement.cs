using Unity.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float verticalScreenJump = 10;
    private float horizontalScreenJump = 18;
    private float verticalBoundingBuffer;
    private float horizontalBoundingBuffer;


    [SerializeField] private GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        verticalBoundingBuffer = verticalScreenJump / 2;
        horizontalBoundingBuffer = horizontalScreenJump / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position.y - verticalBoundingBuffer);
        //North
        if(player.transform.position.y - verticalBoundingBuffer > Camera.main.transform.position.y)
        {
            Debug.Log("Could Travel North");
            Camera.main.transform.Translate(0, verticalScreenJump, 0);
        }
        
        //South
        if(player.transform.position.y + verticalBoundingBuffer < Camera.main.transform.position.y)
        {
            Camera.main.transform.Translate(0, -verticalScreenJump, 0);
        }

        //West
        if(player.transform.position.x + horizontalBoundingBuffer < Camera.main.transform.position.x)
        {
            Camera.main.transform.Translate(-horizontalScreenJump, 0, 0);
        }

        //East
        if(player.transform.position.x - horizontalBoundingBuffer > Camera.main.transform.position.x)
        {
            Camera.main.transform.Translate(horizontalScreenJump, 0, 0);
        }
    }
}
