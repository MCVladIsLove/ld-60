using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _cost1;
    [SerializeField] private int _cost2;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _level1Worker;
    [SerializeField] private GameObject _level2Worker;
    [SerializeField] private OilGiver _well1;
    [SerializeField] private OilGiver _well2;
    [SerializeField] private GameObject _shine;
    [SerializeField] private float _timeToCollect1;
    [SerializeField] private float _timeToCollect2;

    private int _level = 0;
    private float _timer;

    private void Awake()
    {
        _costText.text = $"-{_cost1}";
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_level == 1 && _timer > _timeToCollect1)
        {
            _well1.Collect();
            _well2.Collect();
            _timer = 0;
        }

        if (_level == 2 && _timer > _timeToCollect2)
        {
            _well1.Collect();
            _well2.Collect();
            _timer = 0;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_level == 2)
            return;

        if (_level == 0)
        {
            if (!OilManager.Instance.TryDecreaseOil(_cost1))
                return;

            _level1Worker.SetActive(true);
            _costText.text = $"-{_cost2}";
            _level++;
        }
        else if (_level == 1)
        {
            if (!OilManager.Instance.TryDecreaseOil(_cost2))
                return;

            _level2Worker.SetActive(true);
            _shine.GetComponent<Shine>().enabled = false;
            _shine.GetComponent<SpriteRenderer>().enabled = false;
            _costText.gameObject.SetActive(false);
            _level++;
        }
    }
}
