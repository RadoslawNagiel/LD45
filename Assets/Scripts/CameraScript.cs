using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    /*
    private static Camera camera;
    private static Bounds playerBounds;

    public static void OnModuleAttached(GameObject module)
    {
        var startSize = playerBounds.size;
        playerBounds.Encapsulate(module.GetComponent<Renderer>().bounds);
        var endSize = playerBounds.size;

        Debug.Log((endSize.x * endSize.y) / (startSize.x * startSize.y) / 2f);
        camera.orthographicSize +=
            (endSize.x * endSize.y) / (startSize.x * startSize.y) / 2f;
    }

    private void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        playerBounds = new Bounds(transform.position, Vector3.zero);
        playerBounds.Encapsulate(player.GetComponent<Renderer>().bounds);
    }
    */
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y;
        transform.position = pos;
    }
}
