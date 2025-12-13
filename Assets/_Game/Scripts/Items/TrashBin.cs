using UnityEngine;

public class TrashBin : MonoBehaviour, IInteractable
{
    // Biến để kiểm tra xem thùng rác này lục chưa
    private bool _isLooted = false;

    public void Interact()
    {
        if (_isLooted)
        {
            Debug.Log("Thùng này lục rồi, còn cái nịt thôi!");
            return;
        }

        // --- ĐOẠN MỚI ---
        // Random tiền từ 1 đến 10 đồng
        int randomMoney = Random.Range(1, 10);

        // Gọi thằng PlayerStats cộng tiền vào
        PlayerStats.Instance.AddMoney(randomMoney);

        Debug.Log($"Nhặt được {randomMoney} đồng!");
        // ----------------

        // Đổi màu thùng rác sang xám (báo hiệu đã lục xong)
        GetComponent<SpriteRenderer>().color = Color.gray;
        _isLooted = true;
    }
}