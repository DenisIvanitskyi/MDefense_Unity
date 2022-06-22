using Assets.Common.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Common.UI.ProgressLoading
{
    public class ProgressLoadingController : MonoBehaviour, IProgressLoadingController
    {
        [SerializeField]
        private RectTransform _loadingGameObject;

        [SerializeField]
        private TextMeshProUGUI _loadingInfoTextGameObject;

        [SerializeField]
        private RectTransform _loaderContainerTrnsform;

        [SerializeField]
        private GameObject _gameObject;

        public async Task<LoadingInfoResult> StartLoading(params ILoadingAction[] loadingAction)
        {
            _gameObject.gameObject.SetActive(false);
            transform.parent.gameObject.SetActive(true);

            _loadingGameObject.sizeDelta = new Vector2(0, _loadingGameObject.sizeDelta.y);
            var increaseValuePerOneLoading = _loaderContainerTrnsform.sizeDelta.x / (float)loadingAction.Length;
            var listOfExceptions = new List<Exception>();

            foreach (var act in loadingAction)
            {
                try
                {
                    await act.StartLoading();
                    _loadingInfoTextGameObject.text = act.Title;
                }
                catch (Exception er)
                {
                    listOfExceptions.Add(er);
                }
                finally
                {
                    _loadingGameObject.sizeDelta = new Vector2(_loadingGameObject.sizeDelta.x + increaseValuePerOneLoading, _loadingGameObject.sizeDelta.y);
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(1));
            transform.parent.gameObject.SetActive(false);
            _gameObject.gameObject.SetActive(true);

            var loadingInfoResult = new LoadingInfoResult(listOfExceptions);
            return loadingInfoResult;
        }
    }
}
