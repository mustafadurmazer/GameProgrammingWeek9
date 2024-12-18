using UnityEngine;

public class DusmanPatlama : MonoBehaviour
{
    public Animator animator; // Animator bileşenini bağlayın
    public GameObject patlamaPrefab; // Patlama efektini atayın

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLaser")) // Oyuncu lazeriyle çarpışma kontrolü
        {
            animator.SetTrigger("Explode"); // Patlama tetikleyicisini çalıştır
            Instantiate(patlamaPrefab, transform.position, Quaternion.identity); // Patlama efektini oluştur
            Destroy(gameObject, 2f); // 2 saniye sonra düşmanı yok et
        }
    }
}

public class NesneYokEtme : MonoBehaviour
{
    public float yokEtmeGecikmesi = 3f; // Nesne yok edilmeden önceki gecikme süresi

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, yokEtmeGecikmesi); // Gecikmeli olarak nesneyi yok et
        }
    }
}

public class DusmanHizDurdurma : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLaser"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Hızı sıfırla
            }
        }
    }
}

public class AsteroidHareket : MonoBehaviour
{
    public float hareketHizi = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime); // Sürekli ileri hareket
    }
}

public class AsteroidPatlama : MonoBehaviour
{
    public GameObject patlamaPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLaser"))
        {
            Instantiate(patlamaPrefab, transform.position, Quaternion.identity); // Patlama efektini oluştur
            Destroy(gameObject); // Asteroid'i yok et
        }
    }
}

using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform spawnNoktasi;

    void Start()
    {
        StartCoroutine(SpawnRutini());
    }

    IEnumerator SpawnRutini()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // 3 saniye bekle
            Instantiate(asteroidPrefab, spawnNoktasi.position, Quaternion.identity); // Yeni asteroid oluştur
        }
    }
}

public class ThrusterHasar : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            animator.SetTrigger("Hasar"); // Hasar animasyonunu çalıştır
        }
    }
}


