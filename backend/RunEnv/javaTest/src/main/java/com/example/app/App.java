/*----------------------------------------------------------------------------------------
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See LICENSE in the project root for license information.
 *---------------------------------------------------------------------------------------*/

 package com.example.app;

 import java.io.BufferedReader;
 import java.io.FileReader;
 import java.io.FileWriter;
 import java.io.IOException;
 import java.lang.reflect.*;
 
 import org.json.JSONException;
 import org.json.JSONObject;
 import org.json.JSONArray;
 import java.util.*;
 import com.fasterxml.jackson.databind.ObjectMapper;
 import com.fasterxml.jackson.core.type.TypeReference;
 import java.io.File;
 import com.fasterxml.jackson.core.*; 
 public class App {

    public App() {}
 
    public static void main(String[] args) throws NoSuchMethodException, SecurityException, JSONException, IOException, IllegalAccessException, InvocationTargetException {

        // Load data
        FileReader fileReader = new FileReader(
                ".//mount//data.json");
        BufferedReader bufferedReader = new BufferedReader(fileReader);
        StringBuilder jsonContent = new StringBuilder();
        String line;
        while ((line = bufferedReader.readLine()) != null) {
            jsonContent.append(line);
        }
        bufferedReader.close();
        fileReader.close();
        JSONObject jo = new JSONObject(jsonContent.toString());

        // Running each test case
        JSONArray testcases = jo.getJSONArray("data");
        Loader load = new Loader();
        for (int i = 0; i < testcases.length(); i++) {
            JSONObject dataObj = testcases.getJSONObject(i);
            JSONArray input = dataObj.getJSONArray("input");
            JSONArray res = load.execute(input);
            dataObj.put("result", res);
        }
        try (FileWriter file = new FileWriter(".//mount//res.json")) {
           file.write(jo.toString(2));
           file.flush(); 
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}