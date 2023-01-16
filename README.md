# Code-generator-and-json-parsing
Deserializing json data and creating random alphanumerical codes

## Getting Started --> Code-generator
```
     In this study; with "ACDEFGHKLMNPRTXYZ234579" characters, I created random 8 digits aplhanumerical codes. 
Initially, created 1000 codes and checked their suitability.

--> git clone https://github.com/SinanAtici97/Code-generator-and-json-parsing.git

File path must be as --> ...\Code Generator>


## Run
Write this codes below on terminal:
--> cd CodeGenerator 
--> dotnet run    
```
## Getting Started --> Parsing process

![MarketRecipe](https://user-images.githubusercontent.com/118997291/212669840-a5aed684-caa6-4e57-9e57-b347d3b715d2.png)

![image](https://user-images.githubusercontent.com/118997291/212670851-79fec09e-b6a9-4554-87ac-f068cbc8f582.png)

```
     In this study; I parsed JSON file in different ways and then was written to text file. 
Firstly, response data was automatically detected and deserialized. Then, texts deserialized were written to AutomaticallyParsed.txt file.

     Secondly; to descend the error, by using bounding box coordinates I wanted to parse manually. For this reason, I wrote longer code giving more accurate outputs.
And then, I wrote these outputs to text to ManuallyParsed.txt file.

     Finally, also I wrote the command outputs to ElaborateData.txt. (The data was completely correctly written to the command panel however, passing it to the text file as the same line I had a hard time.)
In this text file, you can reach more detailed information texts on the market recipe, such as coordinates and lines.

File path must be as --> ...\ParseJson> 


## Run
Write this codes below on terminal:
--> cd ParseJson  
--> dotnet run    
```
## Conclusion
```
     In this code, my algorithm is calling data from response.description sequentially. In addition, with OCR recorded response data somewhere randomly.
For these reasons, if the algorithm call line 11, line 12, and then again line 11; these are written like this "line11 line 12 line 11".  
To fix that it can revise the JSON file or write a dynamic algorithm.
```
## Outputs 

![DetailedData](https://user-images.githubusercontent.com/118997291/212669598-aa6904da-bed6-4c9b-a88b-f83487908e41.png)

![Automatically](https://user-images.githubusercontent.com/118997291/212669340-3b6416c6-6b75-4b5c-bf56-cd10621f3209.JPG)

![Manually](https://user-images.githubusercontent.com/118997291/212669514-e3ce5dd1-dc9a-4027-8b8a-77fb41f34511.png)


