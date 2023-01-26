package com.example.myapplication;

import java.io.File;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.InputStreamReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import android.content.Context;

// Read&Write fILE IO from [Data-data-com.example.myapplication-files-database.txt]
public class fileHandler {

    Context context;
    private static final String FILE_NAME="database.txt";  // Define file name.
    public fileHandler(Context context) {
        this.context = context;
    } // Constructor

    public List<compareScore> readFile(){

        List<compareScore> input=new ArrayList<>();  // new a array to store data
        FileInputStream inputFile;
        BufferedReader reader;
        String filePath = context.getFilesDir()+"/"+FILE_NAME; //[Data-data-com.example.myapplication-files-database.txt]

        final File data = new File(filePath);
        try {
            if (data.exists()) { // If file exist then read the file
                inputFile = new FileInputStream(data);
                reader = new BufferedReader(new InputStreamReader(inputFile));
                String eachLine = reader.readLine();  // Read by each line

                while (eachLine != null) {
                    String[] index = eachLine.split("\t");
                    compareScore score = new compareScore(index[0],index[1],index[2]);
                    input.add(score);  // add 3 indexs value (name|score|date) to array
                    eachLine = reader.readLine();
                }
            }
        } catch (Exception e) {
            e.printStackTrace();  // Throw compilation error
        }
        return input;  //return list
    }


    public void writeFile(List<compareScore> data){   // Write to the same file path

        String filePath = context.getFilesDir()+"/"+FILE_NAME;
        System.out.println(filePath);
        File dataFile = new File(filePath);

        if(!dataFile.exists()){  // if file is not exist, create one
            try {
                dataFile.createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        try {
            FileWriter writeFile = new FileWriter(dataFile);  // write file
            for(compareScore score: data){
                writeFile.append(score.toString()+"\n");  // for every data compare, means new enter, then writes to file.
            }
            writeFile.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
