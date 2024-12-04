using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootSeq : MonoBehaviour
{
    [SerializeField] Light screenLight;
    [SerializeField] RawImage fade;
    [SerializeField] RawImage white;

    void Start()
    {
        StartCoroutine(Boot());
    }

    IEnumerator Boot(){

        for(float i = 10; i >= 0; i--){

            fade.color = new Color(0, 0, 0, i/10f);
            screenLight.intensity = i/10f;
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(0.4f);
        for(int j = 0; j < 6; j++){
            for(float i = 10; i >= 0; i--){

                white.color = new Color(1, 1, 1, i/10f);
                yield return new WaitForSeconds(0.04f);
            }
            yield return new WaitForSeconds(0.8f);
            for(float i = 0; i <= 10; i++){

                white.color = new Color(1, 1, 1, i/10f);
                yield return new WaitForSeconds(0.04f);
            }
            yield return new WaitForSeconds(0.4f);
        }
        for(float i = 10; i >= 0; i--){

            white.color = new Color(1, 1, 1, i/10f);
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(0.5f);
        white.color = new Color(1, 1, 1, 1);
    }
}
