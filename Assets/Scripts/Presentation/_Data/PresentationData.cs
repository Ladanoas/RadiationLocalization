using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Presentation
{
	public class PresentationData : AbstactSceneController<PresentationData>
	{
		private const string ConfigFilePath = "PresentationData";

		public List<SlideData> Slides = new List<SlideData>();
		private List<SerializationSlideData> _slidesData = new List<SerializationSlideData>();

		protected override void OnAwake()
		{
			_slidesData = LoadData();
		}

		public SerializationSlideData GetSerializationSlideData(SlideId id)
		{
			SerializationSlideData slideData = _slidesData.FirstOrDefault( a => a.Id==id );
			if(slideData!=null)
			{
				return slideData;
			}
			else
			{
				Debug.LogException(new System.Exception("Потеряна информация для слайда = " + id.ToString()));
				return new SerializationSlideData();
			}
		}

		private static List<SerializationSlideData> LoadData()
		{
			TextAsset json = Resources.Load(ConfigFilePath) as TextAsset;
			if(json!=null)
			{
				return JsonConvert.DeserializeObject<List<SerializationSlideData>>(json.text);
			}
			else
			{
				Debug.LogException(new System.Exception("Потерян конфиг файл PresentationData.cfg"));
				return null;
			}
		}

	}
}
