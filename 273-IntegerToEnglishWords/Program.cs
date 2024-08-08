using System.Text.RegularExpressions;

Solution solution = new();

int num = 1711070058;

Console.WriteLine(solution.NumberToWords(num));
Console.ReadKey();

public class Solution {
    public string NumberToWords(int num) {
        string number = num.ToString();
        Dictionary<char, string> singlesConversion = new() {
            {'0', "Zero"},
            {'1', "One"},
            {'2', "Two"},
            {'3', "Three"},
            {'4', "Four"},
            {'5', "Five"},
            {'6', "Six"},
            {'7', "Seven"},
            {'8', "Eight"},
            {'9', "Nine"}
        };
        Dictionary<char, string> charConversion = new() {
            {'0', ""},
            {'1', "One"},
            {'2', "Two"},
            {'3', "Three"},
            {'4', "Four"},
            {'5', "Five"},
            {'6', "Six"},
            {'7', "Seven"},
            {'8', "Eight"},
            {'9', "Nine"}
        };
        Dictionary<char, string>  teenConversion = new() {
            {'0', ""},
            {'1', "Eleven"},
            {'2', "Twelve"},
            {'3', "Thirteen"},
            {'4', "Fourteen"},
            {'5', "Fifteen"},
            {'6', "Sixteen"},
            {'7', "Seventeen"},
            {'8', "Eighteen"},
            {'9', "Nineteen"}
        };
        Dictionary<char, string> tensConversion = new() {
            {'0', ""},
            {'1', "Ten"},
            {'2', "Twenty"},
            {'3', "Thirty"},
            {'4', "Forty"},
            {'5', "Fifty"},
            {'6', "Sixty"},
            {'7', "Seventy"},
            {'8', "Eighty"},
            {'9', "Ninety"}
        };
        

        List<(int, char)> numbers = new();

        for (int i = 0; i < number.Length; i++) {
            numbers.Add((number.Length - i, number[i]));
        }

        string output = "";
        foreach (var item in numbers) {
            if (item.Item1 == 10) {
                output += $"{charConversion[item.Item2]} Billion ";
            }
            else if (item.Item1 == 9) {
                if (item.Item2 != '0') {
                    output += $"{charConversion[item.Item2]} Hundred ";
                }
            }
            else if (item.Item1 == 8) {
                if (item.Item2 == '1') {
                    if (number[number.Length-7] == '0') {
                        output += "Ten";
                        output += " Million ";
                    }
                    else {
                        output += $"{teenConversion[number[number.Length-7]]}";
                        output += " Million ";
                    }
                }
                else if (item.Item2 != '0') {
                    if (number[number.Length-7] == '0')
                    output += $"{tensConversion[item.Item2]}";
                    else {
                        output += $"{tensConversion[item.Item2]} ";
                    }
                }

            }
            else if (item.Item1 == 7) {
                if (number.Length > 7) {
                    if (number[number.Length-8] != '1') {
                        if (item.Item2 != '0') {
                            output += $"{charConversion[item.Item2]}";
                            output += " Million ";
                        }
                        else {
                            if (number[number.Length-8] == '0') {
                                try {
                                    if (number[number.Length-9] =='0') {

                                    }
                                    else {
                                        output += " Million ";
                                    }
                                }
                                catch {

                                }
                            }
                            else { 
                                output += " Million ";
                            }
                        }
                    }
                }
                else {
                    output += $"{charConversion[item.Item2]}";
                    output += " Million ";
                }
            }
            else if (item.Item1 == 6) {
                if (item.Item2 != '0') {
                    output += $"{charConversion[item.Item2]} Hundred ";
                }
            }
            else if (item.Item1 == 5) {
                if (item.Item2 == '1') {
                    if (number[number.Length-4] == '0') {
                        output += "Ten";
                        output += " Thousand ";
                    }
                    else {
                        output += $"{teenConversion[number[number.Length-4]]}";
                        output += " Thousand ";
                    }
                }
                else if (item.Item2 != '0') {
                    if (number[number.Length-4] == '0')
                    output += $"{tensConversion[item.Item2]}";
                    else {
                        output += $"{tensConversion[item.Item2]} ";
                    }
                }

            }
            else if (item.Item1 == 4) {
                if (number.Length > 4) {
                    if (number[number.Length-5] != '1') {
                        if (item.Item2 != '0') {
                            output += $"{charConversion[item.Item2]}";
                            output += " Thousand ";
                        }
                        else {
                            if (number[number.Length-5] == '0') {
                                try {
                                    if (number[number.Length-6] =='0') {

                                    }
                                    else {
                                        output += " Thousand ";
                                    }
                                }
                                catch {

                                }
                            }
                            else { 
                                output += " Thousand ";
                            }
                        }
                    }
                }
                else {
                    output += $"{charConversion[item.Item2]}";
                    output += " Thousand ";
                }
            }
            else if (item.Item1 == 3) {
                if (number[number.Length-2] == '0' && number[number.Length-1] == '0'){
                    if (item.Item2 != '0') {
                        output += $"{charConversion[item.Item2]} Hundred";
                    }
                }
                else if (item.Item2 != '0') {
                    output += $"{charConversion[item.Item2]} Hundred ";
                }
            }
            else if (item.Item1 == 2) {
                if (item.Item2 == '1') {
                    if (number[number.Length-1] == '0') {
                        output += "Ten";
                    }
                    else {
                        output += $"{teenConversion[number[number.Length-1]]}";
                    }
                }
                else if (item.Item2 != '0') {
                    if (number[number.Length-1] == '0')
                    output += $"{tensConversion[item.Item2]}";
                    else {
                        output += $"{tensConversion[item.Item2]} ";
                    }
                }

            }
            else if (item.Item1 == 1) {
              if (number.Length > 1) {
                if (number[number.Length-2] != '1') {
                    output += $"{charConversion[item.Item2]}";
                }
              }
              else {
                return singlesConversion[item.Item2];
              }
            }

        }
        string result = Regex.Replace(output, @" {2,}", " ");

        return result.Trim();
    }
}
/*


create a string of numbers, and assign a numerical value based on digit
determine which numbers are 0s and 1s

10 potential digits

Need to check if the number is 0
special case for 11-19
--check for 1 at position 2,5,8
special case for final number being 0
goes up to 2 billion



*/