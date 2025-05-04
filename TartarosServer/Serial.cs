using System.Text.Json;

namespace TartarosServer;

public class Serial
{
	public string SerialPortName { get; set; } = "COM1";
	public int BaudRate { get; set; } = 9600;
	public int DataBits { get; set; } = 8;
	public int StopBits { get; set; } = 1;
	public int WriteTimeout { get; set; } = 500;
	public int ReadTimeout { get; set; } = 500;
}