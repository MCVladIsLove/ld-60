using UnityEngine;

public static class GeneralExtensions
{
    public static void SetYPosition(this Transform transform, float y) =>
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
}