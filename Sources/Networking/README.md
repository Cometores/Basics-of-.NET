# Networking

[//]: # (__________________________________________________________)
## 1. Ping Utility
A simple command-line application that performs continuous ping tests to a specified host, 
providing real-time feedback and logging results for later analysis.

#### Features:
- Continuous Pinging: Sends ping requests at a specified interval.
- Customizable Timeout: Set a timeout for each ping request.
- Error Handling: Graceful handling of ping failures and exceptions.
- Logging: Records ping results to a log file for future reference.
- Statistics: Displays success rates, minimum, maximum, and average roundtrip times.

#### Usage:
1. Go to the project folder.<br/>
2. Run the application:
```bash
dotnet run <host> <timeout> <logFilePath>
```
- `host`: IP address or domain to ping.
- `timeout`: Timeout in milliseconds for each ping request (optional, default: 1000ms).
- `logFilePath`: Path to the log file (optional, default: ping_log.txt).




[//]: # (__________________________________________________________)
## 2. Port Scanner
Utility that scans devices in **local network** for open, closed, or error-prone 
ports within a given range. <br>
The program displays results in a clear, **tabular format**, 
allowing users to quickly identify active services on networked devices. 
Additionally, it includes an option to **identify devices** by MAC address, 
displaying manufacturer details to enhance device recognition.

#### Features:
- Device Selection: Scans local network for devices, displaying IP, MAC, and manufacturer.
- Port Scanning: Tests for open and closed ports over a specified range.
- Progress Visualization: Displays a progress bar during the scan for real-time feedback.
- Detailed Report: Outputs port status in ranges for easier readability.
- Manufacturer Lookup: Queries MAC address details to identify device manufacturers.

#### Usage:
1. Run the program, and select a device IP from your local network.
2. Specify the start and end ports to scan.
<p>The program will display real-time progress and present a summary report.</p>

#### Example:
```bash
IP Address       MAC Address            Manufacturer
192.168.1.10     00:1A:2B:3C:4D:5E      Netgear Inc.

Enter start port: 20
Enter end port: 100

Scanning 192.168.1.10 from port 20 to 100...

Port Range        Status
20-23             Open
24-50             Closed
51-80             Open
81-100            Closed
```

#### Dependencies:
- ShellProgressBar: NuGet package for enhanced console progress bar.


#### Future Improvements:
- Export results to JSON/CSV.
- Implement retry on failed requests.
- Enhance MAC address lookup for additional device information.