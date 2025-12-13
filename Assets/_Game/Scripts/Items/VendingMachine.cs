using UnityEngine;

public class VendingMachine : MonoBehaviour, IInteractable
{
    [Header("Settings")]
    [SerializeField] private string _itemName = "Bánh Mì";
    [SerializeField] private int _price = 5;       // Giá 5 đồng
    [SerializeField] private float _hungerRestore = 20f; // Hồi 20 đói

    public void Interact()
    {
        // 1. Kiểm tra xem người chơi có đủ tiền không
        if (PlayerStats.Instance.CurrentMoney >= _price)
        {
            // Đủ tiền -> Mua hàng
            BuyItem();
        }
        else
        {
            // Không đủ tiền -> Báo lỗi
            Debug.Log($"Không đủ tiền! Món {_itemName} giá tận ${_price} cơ.");
            // (Sau này sẽ làm sfx tiếng "Tít tít" báo lỗi ở đây)
        }
    }

    private void BuyItem()
    {
        // Trừ tiền (AddMoney số âm tức là trừ)
        PlayerStats.Instance.AddMoney(-_price);

        // Hồi đói (Ăn luôn tại chỗ)
        PlayerStats.Instance.EatFood(_hungerRestore);

        Debug.Log($"Đã mua {_itemName}. Ngon tuyệt! (-${_price})");
    }
}