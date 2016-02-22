using UnityEngine;
using System.Collections;

namespace Presentation
{
	public class SerializationSlideData
	{
		public SlideId Id;
		public string SlideTitle;
		public string SlideDescription;

		public SerializationSlideData()
		{
			Id = SlideId.none;
			SlideTitle = "";
			SlideDescription = "";
		}
	}
}
