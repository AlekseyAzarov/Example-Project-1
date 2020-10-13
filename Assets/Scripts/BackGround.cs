using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class BackGround : MonoBehaviour
{
    [SerializeField] private float speedOfLooping = 0.1f;

    private Vector2 offset;
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;

        transform.localScale = new Vector2(width, height);
    }

    private void Update()
    {
        BackGroundLooping();

        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 100);
    }

    private void BackGroundLooping()
    {
        offset.x += speedOfLooping * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
