using UnityEngine;

public class TrashBin : MonoBehaviour, IInteractable // Kế thừa từ Interface vừa tạo
{
    public void Interact()
    {
        // Logic khi bấm E vào thùng rác
        Debug.Log("Lục lọi thùng rác... Nhặt được 1 cái chai nhựa!");

        // (Tạm thời) Đổi màu để biết là đã tương tác
        GetComponent<SpriteRenderer>().color = Color.gray;

        // Sau này sẽ code thêm: +1 Chai nhựa vào túi đồ
    }
}