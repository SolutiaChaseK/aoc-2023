namespace day1;

using System;


class Program
{
    static void Main(string[] args)
    {
        //PartOne();
        Pt2();
    }

    static void Pt1() {
        string inputFilePath = "input.txt";

        try {
            // Check if the file exists                
            if (File.Exists(inputFilePath))
            {
                List<int> inputList = new List<int>();

                foreach(string line in File.ReadLines(inputFilePath)) {
                    //strip out letters
                    string cleanLine = "";
                    foreach (char c in line) {
                        if (Char.IsNumber(c)) {
                            cleanLine = cleanLine + c;
                        }
                    }

                    cleanLine = cleanLine.Substring(0,1) + cleanLine.Substring(cleanLine.Length -1);

                    
                    inputList.Add(int.Parse(cleanLine));
                }
                int sum = 0;
                foreach (int num in inputList) {
                    
                    sum= sum + num;
                }
                Console.WriteLine(sum);
                
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        } catch(Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }
    public class TextNumber
    {
        public int intNumber { get; set; }
        public string? txtNumber { get; set; }

    }

    public class NumberPosition {
        public int index { get; set; }
        public int number { get; set; }
    }

        

    static void Pt2() {
        string inputFilePath = "input.txt";
        

        List<TextNumber> textNumbers = new List<TextNumber>{new TextNumber { intNumber = 1, txtNumber = "one" },
                                                    new TextNumber{ intNumber = 2, txtNumber = "two" },
                                                    new TextNumber{ intNumber = 3, txtNumber = "three" },
                                                    new TextNumber{ intNumber = 4, txtNumber = "four" },
                                                    new TextNumber{ intNumber = 5, txtNumber = "five" },
                                                    new TextNumber{ intNumber = 6, txtNumber = "six" },
                                                    new TextNumber{ intNumber = 7, txtNumber = "seven" },
                                                    new TextNumber{ intNumber = 8, txtNumber = "eight" },
                                                    new TextNumber{ intNumber = 9, txtNumber = "nine" }};

        try {
            // Check if the file exists                
            if (File.Exists(inputFilePath))
            {
                List<int> inputList = new List<int>();

                foreach(string line in File.ReadLines(inputFilePath)) {
                    List<NumberPosition> numberPositions = new List<NumberPosition>();
                    //convert text numbers to numbers
                    foreach(TextNumber number in textNumbers) {
                        int index = -1;
                        
                        do {
                            index = line.IndexOf(number.txtNumber, index + 1);
                            if (index != -1) {
                                numberPositions.Add(new NumberPosition{index = index, number = number.intNumber});
                            }

                        } while (index != -1);
                    }
                    //sort list in order of index (backwards)
                    numberPositions = numberPositions.OrderByDescending(obj => obj.index).ToList();

                    //adding integer numbers to original line
                    string lineNumbersAdded = line;
                    foreach(NumberPosition pos in numberPositions) {
                        lineNumbersAdded = lineNumbersAdded.Substring(0,pos.index) + pos.number + lineNumbersAdded.Substring(pos.index);
                    }

                    //strip out letters
                    string cleanLine = "";
                    foreach (char c in lineNumbersAdded) {
                        if (Char.IsNumber(c)) {
                            cleanLine = cleanLine + c;
                        }
                    }
                    //cleanline is the line with just the first and last number included
                    cleanLine = cleanLine.Substring(0,1) + cleanLine.Substring(cleanLine.Length -1);
                    inputList.Add(int.Parse(cleanLine));
                }
                int sum = 0;
                foreach (int num in inputList) {
                    
                    sum= sum + num;
                }
                Console.WriteLine("The sum is: " + sum);
                
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        } catch(Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

    }


    
}
