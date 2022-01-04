# Brainfuck
A simple brainfuck interpreter written in C#

## Usage
Just add Brainfuck.cs into your project folder.
```cs
using Brainfuck;
```
```cs
public static void Main()
{
  // Brainfuck code we want to interperet.
  // This little program prints "Hello World!".
  string code = 
  ">+++++++++[<++++++++>-]<.>+++++++[<++++>-]<+.+++++++..+++.>>>++++++++[<++++>-]" +
  "<.>>>++++++++++[<+++++++++>-]<---.<<<<.+++.------.--------.>>+.>++++++++++.";
  
  // Run the code.
  var bf = new Brainfuck(code);
  
  // Get the results.
  string output = bf.GetOuput();
}
```

## License
The code is released under the MIT License. See [LICENSE](/LICENSE).
