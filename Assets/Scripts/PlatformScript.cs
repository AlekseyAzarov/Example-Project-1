using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms = null;
    [SerializeField] private GameObject chest = null;

    private Bounds bounds;
    private static int numOfPlatforms;

    private void Start()
    {
        numOfPlatforms++;

        bounds = GetComponent<SpriteRenderer>().bounds;

        int chance = Random.Range(1, 21);

        if (numOfPlatforms < 250)
            CreateNewPlatform();

        if (chance >= 19 && chest != null)
            CreateChest();
    }

    private void CreateChest()
    {
        Vector2 posForChest = transform.position;

        posForChest.y = bounds.center.y + bounds.size.y;

        Instantiate(chest, posForChest, Quaternion.identity);
    }

    private void CreateNewPlatform()
    {
        Vector2 posForNextPlatform = transform.position;

        if (name.Contains("GrassHillLeft2 DownShadow"))
            posForNextPlatform.y = bounds.center.y + bounds.size.y;
        else if (name.Contains("GrassHillRight") && !name.Contains("2"))
            posForNextPlatform.y = bounds.center.y - bounds.size.y;
        else
            posForNextPlatform.x = bounds.center.x + bounds.size.x;

        Instantiate(platforms[Random.Range(0, platforms.Length)], posForNextPlatform, Quaternion.identity);
    }
}
