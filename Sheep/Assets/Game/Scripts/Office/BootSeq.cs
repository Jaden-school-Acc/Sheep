using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BootSeq : MonoBehaviour
{
    [SerializeField] Light screenLight, screenLight2;
    [SerializeField] RawImage fade;
    [SerializeField] RawImage white;

    [SerializeField] GameObject barHorz, barVert;

    void Start()
    {
        StartCoroutine(Boot());
    }

    void OnEnable(){

        StopAllCoroutines();
        StartCoroutine(Boot());
    }

    void OnDisable(){
        
        StopAllCoroutines();
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff(){

        screenLight.intensity = 0;
        barHorz.SetActive(true);
        yield return new WaitForSeconds(0.03f);
        barVert.SetActive(true);
        yield return new WaitForSeconds(0.01f);


        fade.color = new Color(0, 0, 0, 1);
        white.color = new Color(1, 1, 1, 1);
        screenLight2.intensity = 0f;
    }

    IEnumerator Boot(){

        barHorz.SetActive(false);
        barVert.SetActive(false);
        screenLight2.intensity = 0.09f;
        for(float i = 10; i >= 0; i--){

            fade.color = new Color(0, 0, 0, i/10f);
            screenLight.intensity = 1f-i/10f;
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
        yield return new WaitForSeconds(1f);
        white.color = new Color(1, 1, 1, 1);
    }
}
