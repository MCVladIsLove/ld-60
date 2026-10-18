using UnityEngine;
using UnityEngine.EventSystems;

public class Shine : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private SpriteRenderer _overShine;

    private void Awake()
    {
        _overShine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _overShine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _overShine.enabled = false;
    }
}
