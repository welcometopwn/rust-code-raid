using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace CodeRaid;

public partial class Main : Form
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const string configFile = "settings.conf";
    private readonly IntPtr _hookId;
    private readonly List<string> _numbers; // load from json file later

    private readonly LowLevelKeyboardProc _proc;
    private int _currentIndex;
    private string _typedNumber = "";

    public Main()
    {
        InitializeComponent();
        current_line.KeyPress += CurrentLine_KeyPress!;
        current_line.KeyDown += CurrentLine_KeyDown!;
        _numbers = LoadNumbersFromJson("numbers.json");
        l_line_amount.Text = $@"/ {_numbers.Count}";

        if (File.Exists(configFile))
        {
            var settings = File.ReadAllText(configFile);
            var settingsDict = settings.Split('\n')
                .Select(part => part.Split('='))
                .ToDictionary(split => split[0], split => split[1]);

            if (settingsDict.ContainsKey("line") && int.TryParse(settingsDict["line"], out var lineNumber) && lineNumber >= 1 && lineNumber <= _numbers.Count)
                _currentIndex = lineNumber - 1;

            if (settingsDict.ContainsKey("opacity") && double.TryParse(settingsDict["opacity"], NumberStyles.Any, CultureInfo.InvariantCulture, out var opacity))
                this.Opacity = opacity;

        }

        DisplayCurrentNumber();
        KeyPreview = true;
        _proc = HookCallback;
        _hookId = SetHook(_proc);
        TopMost = true;
    }

    private void CurrentLine_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        if (int.TryParse(current_line.Text, out var line) && line >= 1 && line <= _numbers.Count)
        {
            _currentIndex = line - 1;
            DisplayCurrentNumber();
        }

        e.Handled = true;
        e.SuppressKeyPress = true;
    }

    // Importing necessary functions and structures from user32.dll
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private void Main_Load(object sender, EventArgs e)
    {
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Get a reference to the main form
        Main mainForm = Application.OpenForms.OfType<Main>().FirstOrDefault();
        double opacity = 1.0;
        if (mainForm != null)
        {
            // Get the opacity of the main form
            opacity = mainForm.Opacity;
        }

        // Save the current line number and opacity to the settings.conf file
        string settings = $"line={_currentIndex + 1}\nopacity={opacity.ToString(CultureInfo.InvariantCulture)}";
        File.WriteAllText(configFile, settings);

        UnhookWindowsHookEx(_hookId);
    }

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using var curProcess = Process.GetCurrentProcess();
        using var curModule = curProcess.MainModule;
        return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode < 0 || wParam != WM_KEYDOWN) return CallNextHookEx(_hookId, nCode, wParam, lParam);
        var vkCode = Marshal.ReadInt32(lParam);
        var keyPressed = (char)vkCode;

        // Check if the pressed key is a digit
        if (!char.IsDigit(keyPressed)) return CallNextHookEx(_hookId, nCode, wParam, lParam);
        if (_typedNumber.Length < _numbers[_currentIndex].Length)
            _typedNumber += keyPressed;
        else
            _typedNumber = keyPressed.ToString();

        // check if typed number matches
        if (_typedNumber == _numbers[_currentIndex])
        {
            // move to next
            _currentIndex = (_currentIndex + 1) % _numbers.Count;
            _typedNumber = "";
            DisplayCurrentNumber();
        }
        else if (!_numbers[_currentIndex].StartsWith(_typedNumber))
        {
            // reset if wrong
            _typedNumber = "";
            current_code.SelectionStart = 0;
            current_code.SelectionLength = current_code.Text.Length;
            current_code.SelectionColor = Color.Gray; // reset color to gray
        }
        else
        {
            // change color of digit if correct
            current_code.SelectionStart = 0;
            current_code.SelectionLength = _typedNumber.Length;
            current_code.SelectionColor = Color.Green;
        }

        return CallNextHookEx(_hookId, nCode, wParam, lParam);
    }

    private static List<string> LoadNumbersFromJson(string filePath)
    {
        var numbers = new List<string>();

        if (!File.Exists(filePath))
        {
            MessageBox.Show($"The file {filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return numbers;
        }

        var json = File.ReadAllText(filePath); // read JSON file
        dynamic data = JsonConvert.DeserializeObject(json);
        foreach (var number in data.numbers) numbers.Add((string)number);
        return numbers;
    }

    private void DisplayCurrentNumber()
    {
        current_code.Text = _numbers[_currentIndex];
        current_line.Text = $"{_currentIndex + 1}";
        current_code.SelectionStart = 0;
        current_code.SelectionLength = current_code.Text.Length;
        current_code.SelectionColor = Color.Gray;
    }

    private void ButtonPrevious_Click(object sender, EventArgs e)
    {
        _currentIndex = (_currentIndex - 1 + _numbers.Count) % _numbers.Count;
        DisplayCurrentNumber();
    }

    private void ButtonNext_Click(object sender, EventArgs e)
    {
        // move to the next number in the list
        _currentIndex = (_currentIndex + 1) % _numbers.Count;
        DisplayCurrentNumber();
    }

    private void CurrentLine_KeyPress(object sender, KeyPressEventArgs e)
    {
        // only digits!!!!
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        current_code.Location = new Point((ClientSize.Width - current_code.Width) / 2,
            (ClientSize.Height - current_code.Height) / 3);
    }

    private void aToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void UpdateNumbers(string filePath)
    {
        var numbers = LoadNumbersFromJson(filePath);
        _numbers.Clear();
        _numbers.AddRange(numbers);
        l_line_amount.Text = $@"/ {_numbers.Count}";
        _currentIndex = 0;
        DisplayCurrentNumber();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "numbers.json|*.json";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    var numbers = LoadNumbersFromJson(filePath);
                    if (numbers.Count == 0)
                    {
                        MessageBox.Show("The selected file does not contain any numbers or has an incorrect format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UpdateNumbers(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Looks like the .json file does not contain the correct data field.", $@"Error: {ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void opacityToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Opacity opacityForm = new Opacity();
        opacityForm.ShowDialog();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        About aboutForm = new About();
        aboutForm.ShowDialog();
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct KBDLLHOOKSTRUCT
    {
        public uint vkCode;
        public uint scanCode;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    // found on the internet
    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
}
