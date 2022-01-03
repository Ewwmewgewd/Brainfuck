namespace Brainfuck;

public class Brainfuck
{
    private int _pointer;
    private int _inputPointer;
    private string _code;
    private string _input;
    private string _output;
    private readonly int _tapeSize;
    private byte[] _tape;

    public void SetCode(string code) { _code = code; }
    public void SetInput(string input) { _input = input; }
    public string GetOutput() { return _output; }

    public Brainfuck(string code, string input = "", int tapeSize = 2000, bool autorun = true)
    {
        _pointer = 0;
        _inputPointer = 0;
        _code = code;
        _input = input;
        _output = string.Empty;
        _tapeSize = tapeSize;
        _tape = new byte[_tapeSize];

        if (autorun)
            Run();
    }

    public void Run()
    {
        int codeLen = _code.Length;

        if (codeLen == 0)
            return;

        for (int i = 0; i < codeLen; i++)
        {
            if ((_code[i] == '[') && (_tape[_pointer] == 0))
            {
                int skip = 0;
                int chr = i + 1;
                while ((skip > 0) || (_code[chr] != ']'))
                {
                    if (_code[chr] == '[')
                        skip++;
                    else if (_code[chr] == ']')
                        skip--;
                    chr++;
                }

                i = chr;
                continue;
            }
            else if ((_code[i] == ']') && (_tape[_pointer] != 0))
            {
                int skip = 0;
                int chr = i - 1;
                while ((skip > 0) || (_code[chr] != '['))
                {
                    if (_code[chr] == ']')
                        skip++;
                    else if (_code[chr] == '[')
                        skip--;
                    chr--;
                }

                i = chr;
                continue;
            }

            switch (_code[i])
            {
                case '>': if (_pointer >= _tapeSize - 1) _pointer = 0; else _pointer++; break;
                case '<': if (_pointer <= 0) _pointer = _tapeSize - 1; else _pointer--; break;
                case '+': _tape[_pointer]++; break;
                case '-': _tape[_pointer]--; break;
                case ',': if (_inputPointer < _input.Length) _tape[_pointer] = (byte)_input[_inputPointer++]; break;
                case '.': _output += (char)_tape[_pointer]; break;
                default: break;
            }
        }

        return;
    }

    public void Reset()
    {
        _pointer = 0;
        _code = string.Empty;
        _input = string.Empty;
        _output = string.Empty;
        _tape = new byte[_tapeSize];
    }
}
