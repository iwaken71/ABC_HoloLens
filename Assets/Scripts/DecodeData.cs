using System.Collections.Generic;

[System.Serializable]
public class DecodeData{
	public string[] class_names;
	public List<int[]> face_points;
}



// 左上0 [左上のx座標,左上のy座標,右下のx座標,右下のy座標]
