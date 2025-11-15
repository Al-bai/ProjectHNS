using UnityEngine;
using UnityEngine.SceneManagement; // 1. WAJIB ditambahkan!

public class MainMenuManager : MonoBehaviour
{
    // 2. Buat fungsi PUBLIC agar bisa diakses dari Inspector
    public void StartGame()
    {
        // 3. Ganti "GameScene" dengan nama file scene Anda
        // Pastikan nama scene SAMA PERSIS (case-sensitive)
        SceneManager.LoadScene("SampleScene");
    }

    // (Opsional) Fungsi untuk keluar dari game
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        
        // Ini hanya berfungsi di build game, tidak di Unity Editor
        Application.Quit();

        // Untuk tes di Editor
        Debug.Log("Keluar dari Game!"); 
    }
}

