#include <fstream>
#include <iostream>
#include <nlohmann/json.hpp>
#include <string>
#include <any>
#include "Loader.cpp"

using namespace std;
using json = nlohmann::json;

int main() {
    cout << "Hello World\n";

    std::ifstream json_file(".//mount//data.json");

    // while(true){

    // }

    // Check if the file was opened successfully
    if (!json_file.is_open()) {
        std::cerr << "Could not open the file!" << std::endl;
        return 1;
    }

    json jsonData;
    json_file >> jsonData;  // Deserialize the JSON data from the file

    json testcases = jsonData["data"];
    Loader loader = Loader();

    json allTestcases ;

    for (int i = 0; i < testcases.size(); i ++){
        json dataObj = testcases.at(i);
        json input = dataObj["input"];
        json res = loader.execute(input);
        dataObj["result"] = res;
        allTestcases.push_back(dataObj);
    }
    jsonData["data"] = allTestcases;


    std::cout << jsonData.dump();

    std::ofstream myFile("..//mount//res.json");
    myFile << jsonData.dump() ;
    myFile.close();

    // Close the file
    json_file.close();
    return 0;
}