using UnityEngine;

public static class GeneralExtensions
{
    public static void SetYPosition(this Transform transform, float y) =>
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

    public static void SetYLocalPosition(this Transform transform, float y) =>
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

    public static void SetXPosition(this Transform transform, float x) =>
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
}