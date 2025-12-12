using UnityEngine;

// Script này chịu trách nhiệm di chuyển nhân vật theo hướng nhìn từ trên xuống (Top-down)
public class PlayerMovement : MonoBehaviour
{
    #region Configuration
    [Header("Movement Settings")]
    [Tooltip("Tốc độ di chuyển của nhân vật")]
    [SerializeField] private float _moveSpeed = 5f;
    #endregion

    #region Private Fields
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        // Lấy tham chiếu Rigidbody2D ngay khi game khởi động
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Xử lý Input ở Update để phản hồi nhanh nhất (mượt mà)
        HandleInput();
    }

    private void FixedUpdate()
    {
        // Xử lý Vật lý ở FixedUpdate để tránh lỗi xuyên tường/giật lag
        Move();
    }
    #endregion

    #region Main Logic
    private void HandleInput()
    {
        // Lấy tín hiệu từ bàn phím (WASD hoặc Mũi tên)
        // GetAxisRaw trả về -1, 0, hoặc 1 (giúp nhân vật dừng lại ngay lập tức khi thả phím)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Lưu vào biến Vector2 và Chuẩn hóa (Normalize)
        // Normalize giúp đi chéo không bị nhanh hơn đi thẳng
        _moveInput = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        // Di chuyển Rigidbody bằng cách thay đổi vận tốc (Velocity)
        // Công thức: Hướng * Tốc độ
        _rb.velocity = _moveInput * _moveSpeed;
    }
    #endregion
}