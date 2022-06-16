using Assets.Common.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

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

        public async void Start()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            await 
                StartLoading(Enumerable.Range(0, 10).Select((e, i) => new LoadingActionModel($"Loading {i + 1}", () => Task.Delay(TimeSpan.FromSeconds(1)))).ToArray());
        }

        public async Task<LoadingInfoResult> StartLoading(params ILoadingAction[] loadingAction)
        {
            transform.parent.gameObject.SetActive(true);

            _loadingGameObject.sizeDelta = new Vector2(0, _loadingGameObject.sizeDelta.y);
            var increaseValuePerOneLoading = _loaderContainerTrnsform.sizeDelta.x / (float)loadingAction.Length;
            var listOfExceptions = new List<Exception>();

            foreach (var act in loadingAction)
            {
                try
                {
                    _loadingInfoTextGameObject.text = act.Title;
                    await act.StartLoading();
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

            transform.parent.gameObject.SetActive(false);

            var loadingInfoResult = new LoadingInfoResult(listOfExceptions);
            return loadingInfoResult;
        }
    }
}
