// IMPORT ***********************************************************************************************************
using System.Text.Json;
using ParseJson;
// Variables ***********************************************************************************************************
    var data = new List<Classes.Response>();
    var coords = new List<Classes.Vertex>();
    int Xmin, Xmax, Ymin, Ymax;
    int i=0;
    int state=0;
    int k=0;
    int m=0;
    int line = 0;
    using StreamWriter textfile = new("AutomaticallyParsed.txt");
    using StreamWriter file = new("ManuallyParsed.txt");
    using StreamWriter CommandLines = new("ElaborateData.txt");
//***********************************************************************************************************
using (StreamReader reader = new StreamReader("response.json"))
{
    string json = reader.ReadToEnd();
    data = JsonSerializer.Deserialize<List<Classes.Response>>(json); // deserialize response data
}
//***********************************************************************************************************
if (data != null && data.Count > 0)
{   
    int[] centerCoordinates_x = new int[data.Count]; // read center cordinates of x
    int[] centerCoordinates_y = new int[data.Count]; // read center cordinates of y

    foreach (var response in data) //loop for each response from json file
    {
        // get bounding box coordinates 
        Xmin = response.boundingPoly.vertices[0].x; //get minimum x coordinate of bounding box of text data units
        Xmax = response.boundingPoly.vertices[2].x; //get maximum x coordinate of bounding box of text data units
        Ymin = response.boundingPoly.vertices[0].y; //get minimum y coordinate of bounding box of text data units
        Ymax = response.boundingPoly.vertices[2].y; //get maximum y coordinate of bounding box of text data units
        int gy = (Ymax + Ymin) / 2; // find center of bounding box of text data
        int gx = (Xmax + Xmin) / 2; // find center of bounding box of text data

                centerCoordinates_x[i] =  gx; // even numbers x coordinate of center
                centerCoordinates_y[i] =  gy; // odd numbers y coordinate of center
                Console.WriteLine($"({i}.) Description's coordinates of center: x:{centerCoordinates_x[i]} y:{centerCoordinates_y[i]}");
                await CommandLines.WriteLineAsync($"({i}.) Description's coordinates of center: x:{centerCoordinates_x[i]} y:{centerCoordinates_y[i]}");
        if(i > 1) //find the distance between the center points of text units and determine the increasing values
        {
            int dif_x = centerCoordinates_x[i] - centerCoordinates_x[i-1]; // increasing value of x coordinate
            int dif_y = centerCoordinates_y[i] - centerCoordinates_y[i-1]; // increasing value of y coordinate
            Console.WriteLine($" increase= x:{dif_x} y:{dif_y}");
            await CommandLines.WriteLineAsync($" increase= x:{dif_x} y:{dif_y}");
            if(dif_x < 0 || dif_y >20) // if y incresed more than 20 it means that go next line ! , if x's increase value is negative, it means that go next line !
            {
                state=1;
                if(dif_y > 60 ) // if y increased more than 60,
                {
                    
                    if(dif_y > 60 && dif_x < -100) // if y increased more than 60, go 1 line
                    {
                        
                        line = line + 1;
                        
                    }
                    else //if displacement is so high, go 3 lines.
                    {
                        line = line + 3;
                    }
                }
                else
                {
                    state=1;
                    line = line + 1;
                }
            }
            else if(dif_y < -10 && dif_y > -30 ) // Negative displacement means that the line goes back.
            {
                state=1;
                line = line - 1;
            }
            else if(dif_y < -30 && dif_y > -60 )
            {
                state=1;
                line = line - 2;
            }
            else if(dif_y < -60 )
            {
                state=1;
                line = line - 3;
            }
            else{
            }
        }
//*************PAY ATTENTION: Inside the response.json file, some numbers are randomly recorded, thus I didn't create the text file perfectly.********************
//*************************** If the response.json file is revised, the algorithm will work perfectly.**************************************************** 
    if(i==0) // PLACEMENT THE TEXT TO LINES INSIDE THE TEXT FILE //
    {
        await textfile.WriteAsync($"{response.description} "); // Deserialized automatically with an easy algorithm, but I wanted to go the harder way.
    }
//****************!!!!!!!!!!!THE HARD WAY!!!!!!!!!!!*********************************************************************************
        if(i>0)
        {
            switch(line+1)
            {
                case int n when (n < 11): // when line lower than 11, fulfil the cases
                    switch(state) // find the next line pathes; if state==1 it means that go next line.
                    {
                        case 1:
                        await file.WriteAsync($"\n");
                        break;
                    }
                await file.WriteAsync($"{response.description} ");
                if(n==10) //if line equals 10 then wait 3 times in the 10th line and then go next line. ( because there are 3 words same line.)
                {
                    k++;
                    if(k==3)
                    {
                        await file.WriteAsync($"\n");
                    }
                }
                break;

                case 11:
                m++;
                if(m<4)
                {
                    await file.WriteAsync($"{response.description} ");
                }
                else if(m==4)
                {
                    await file.WriteAsync("08 *5,50 ");
                }
                break;

                case int n when (n > 11):
                    if(i==41)
                    {
                        await file.WriteAsync($"\n");
                    }
                    switch(state)
                    {
                        case 1:
                        if(n==14)
                        {
                            goto next; // if you are on the line of 14th, don't pass next line. So, bypass it.
                        }
                        await file.WriteAsync($"\n");
                        next:
                        break;
                    }
                await file.WriteAsync($"{response.description} ");
                break;
            }
            Console.WriteLine($" Line-{line+1} Text:  {response.description}");
            await CommandLines.WriteLineAsync($" Line-{line+1} Text:  {response.description}");
        }
        state=0; // reset state
        i++; // increment iteration
        
    }
    Console.WriteLine("There are {0} total text unit", data.Count); // count the text units
}