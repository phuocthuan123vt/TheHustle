using UnityEngine;
using UnityEngine.UI;
using TMPro; // Nhớ dòng này để dùng TextMeshPro

public class PlayerStats : MonoBehaviour
{
    // Singleton: Giúp truy cập script này từ bất cứ đâu bằng lệnh PlayerStats.Instance
    public static PlayerStats Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private Slider _hungerSlider;

    [Header("Stats")]
    [SerializeField] private int _money = 0;
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _currentHunger;
    [SerializeField] private float _hungerDropRate = 1f; // Tụt 1 điểm mỗi giây

    public int CurrentMoney => _money;

    private void Awake()
    {
        // Setup Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Khởi tạo chỉ số ban đầu
        _currentHunger = _maxHunger;
        UpdateUI();
    }

    private void Update()
    {
        // Cơ chế tụt đói theo thời gian
        if (_currentHunger > 0)
        {
            _currentHunger -= _hungerDropRate * Time.deltaTime;
            UpdateUI();
        }
        else
        {
            // Hết đói thì chết hoặc trừ máu (Tính sau)
            // Debug.Log("Đói mốc mồm rồi!");
        }
    }

    // Hàm nhận tiền (Gọi từ thùng rác, công việc...)
    public void AddMoney(int amount)
    {
        _money += amount;
        UpdateUI();
    }

    // Hàm hồi sức (Gọi khi ăn uống)
    public void EatFood(float amount)
    {
        _currentHunger += amount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
        UpdateUI();
    }

    // Cập nhật giao diện
    private void UpdateUI()
    {
        // Cập nhật tiền
        if (_moneyText != null)
            _moneyText.text = "$ " + _money.ToString();

        // Cập nhật thanh Slider
        if (_hungerSlider != null)
        {
            _hungerSlider.maxValue = _maxHunger;
            _hungerSlider.value = _currentHunger;
        }
    }
}