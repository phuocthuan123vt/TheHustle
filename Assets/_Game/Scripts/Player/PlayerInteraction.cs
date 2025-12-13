using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _interactRange = 1.5f; // Bán kính quét
    [SerializeField] private LayerMask _interactLayer;   // Chỉ quét những thứ thuộc lớp này

    private void Update()
    {
        // Nếu bấm nút E
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    private void CheckInteraction()
    {
        // Tạo 1 vòng tròn vô hình tại vị trí Player
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, _interactRange, _interactLayer);

        foreach (Collider2D obj in hitObjects)
        {
            // Kiểm tra xem vật đó có script chứa IInteractable không
            IInteractable interactable = obj.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
                return; // Chỉ tương tác với 1 cái gần nhất rồi thôi
            }
        }
    }

    // Vẽ cái vòng tròn ra màn hình Scene để dễ chỉnh (Debug)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactRange);
    }
}