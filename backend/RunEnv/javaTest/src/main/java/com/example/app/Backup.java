// /*----------------------------------------------------------------------------------------
//  * Copyright (c) Microsoft Corporation. All rights reserved.
//  * Licensed under the MIT License. See LICENSE in the project root for license information.
//  *---------------------------------------------------------------------------------------*/

//  package com.example.app;

//  import java.io.BufferedReader;
//  import java.io.FileReader;
//  import java.io.IOException;
//  import java.lang.reflect.*;
 
//  import org.json.JSONException;
//  import org.json.JSONObject;
//  import org.json.JSONArray;
//  import java.util.*;
//  import com.fasterxml.jackson.databind.ObjectMapper;
//  import com.fasterxml.jackson.core.type.TypeReference;
//  import java.io.File;
//  import com.fasterxml.jackson.core.*; 
//  public class App {
 
//      public static void foo(int n1, int n2){
//          System.out.println(n1 + n2);
//      }
 
//      public static int baz(Object[] args) throws IllegalAccessException, InvocationTargetException{
//          Class<?> c = Solution.class;
//          Method func = c.getDeclaredMethods()[0];
 
//          Solution oc = new Solution();
 
//          System.out.println("this is the func");
//          System.out.println(func.getName());
 
//          System.out.println("end of baz");
//          return (int ) func.invoke(oc, args);
//      }
//      public static void main(String[] args) throws NoSuchMethodException, SecurityException, JSONException, IOException, IllegalAccessException, InvocationTargetException {
 
//          FileReader fileReader = new FileReader(
//                  ".//mount//data.json");
//          BufferedReader bufferedReader = new BufferedReader(fileReader);
 
//          StringBuilder jsonContent = new StringBuilder();
//          String line;
//          while ((line = bufferedReader.readLine()) != null) {
//              jsonContent.append(line);
//          }
 
//          bufferedReader.close();
//          fileReader.close();
 
//          System.out.println(jsonContent);
 
//          System.out.println("ok");
 
//          JSONObject jo = new JSONObject(jsonContent.toString());
//          // System.out.println(jo);
//          System.out.println(jo.get("data"));
 
//          // Solution s = new Solution();
//          Class<?> c = Solution.class;
//          Method func = c.getDeclaredMethods()[0];
 
 
//         //  Object[] params = jo.getJSONArray("data").getJSONObject(0);
//         JSONObject mid = jo.getJSONArray("data").getJSONObject(0);
//         JSONArray input = mid.getJSONArray("input");
//         Loader load = new Loader();
//         load.execute(input);
//         // System.out.println(input);
//         // Object[] params = new Object[input.length()];
//         // for (int i = 0; i < input.length(); i++) {
//         //     if (input.get(0) instanceof JSONArray) {
//         //         System.out.println("hello world");
//         //         JSONArray testing = (JSONArray) input.get(0);
//         //             if (testing.get(0) instanceof Integer) {
//         //                 System.out.println("Hello again");
//         //                 int[] nums = new int[testing.length()];
//         //                 for (int j = 0; j < testing.length(); j++) {
//         //                     nums[j] = (int) testing.get(j);
//         //                 }
//         //                 params[i] = nums;
//         //             }
//         //     } else {
//         //         params[i] = (Object) input.get(i);
//         //     }

//         // }
//         //  var b = baz(params);
 
//         //  System.out.println(b);

//         // ObjectMapper mapper = new ObjectMapper();
//         // Map<String, Object> data = mapper.readValue(new File(".//mount//data.json"), new TypeReference<Map<String, Object>>() {});
//         // System.out.println(data.get("data"));
//      }
//  }