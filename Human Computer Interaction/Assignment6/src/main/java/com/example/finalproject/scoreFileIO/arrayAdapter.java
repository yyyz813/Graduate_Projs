package com.example.finalproject.scoreFileIO;
/*
   arrayAdapter from professor's website
* */

import com.example.finalproject.R;
import android.view.View;
import android.view.ViewGroup;
import android.view.LayoutInflater;
import android.content.Context;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import java.util.List;
//import java.util.HashMap;

// Android stableArrayAdapter Documentary
public class arrayAdapter extends ArrayAdapter<Score>
{
  //HashMap<String,Integer> MidMap = new HashMap<String,Integer>();
  List<Score> values;

  public arrayAdapter(Context context, int textViewResourceId,  // Constructor
                      List<Score> objects)
  {
    super(context, textViewResourceId, objects);
    values = objects;
  }

  @Override
  public View getView(int position, View cvtView, ViewGroup parent)
  {
    //View view = super.getView(position,convertView,parent)  //inheritance.
    int width = parent.getWidth();
    Context content = this.getContext();
    // Creating fragment Inflater
    LayoutInflater inflater = (LayoutInflater) content.getSystemService(content.LAYOUT_INFLATER_SERVICE);
    View rowView = inflater.inflate(R.layout.viewlayout, parent, false);

    // reSet default name
    TextView nameLayout = (TextView) rowView.findViewById(R.id.display_name);
    nameLayout.setText(values.get(position).getName());
    nameLayout.setWidth((int) (width * .40));


    // reSet default score
    TextView scoreLayout = (TextView) rowView.findViewById(R.id.display_score);
    scoreLayout.setText(values.get(position).getScore());
    scoreLayout.setWidth((int) (width * .30));

    // reSet default date
    TextView dateLayout = (TextView) rowView.findViewById(R.id.display_date);
    dateLayout.setText(values.get(position).getDate());
    dateLayout.setWidth((int) (width * .4));

    return rowView;
  }
}