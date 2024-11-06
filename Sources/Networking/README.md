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

#### Usage
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
in progress...