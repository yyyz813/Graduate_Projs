/*
   Convert  dp to pixel  |  pixel to dp
* */

package com.example.finalproject.balloonModule;
import android.content.Context;
import android.content.res.Resources;
import android.util.TypedValue;  // applyDimension

public class pixelDpConversion {

    /*https://stackoverflow.com/questions/4605527/converting-pixels-to-dp
      https://stackoverflow.com/questions/8309354/formula-px-to-dp-dp-to-px-android
    * */

    public static int DpPixel(Context context, float dp) {
        return (int) (dp * context.getResources().getDisplayMetrics().density);
    }

    public static int pixelDp(int px, Context context) {
        Resources r = context.getResources();
        return (int) TypedValue.applyDimension(  // can not return float.
                TypedValue.COMPLEX_UNIT_DIP, px,
                r.getDisplayMetrics());
    }
}