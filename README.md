# samba-cli

**samba-cli** is a command-line interface (CLI) application built with C# .NET 6.0 to simplify the management of Samba-based Active Directory (AD) 
domains. It acts as a wrapper over samba-tool, the built-in Samba-CLI, and provides advanced features for user management and permissions
management.

## Features

- Automatic Profile and Home Directory Generation: Samba-AD-Manager automates the process of generating user profiles and home directories
while ensuring correct permissions management. This saves time and eliminates manual configuration errors.

- Fix Broken User Permissions: With a single command, Samba-AD-Manager allows you to easily fix broken user permissions within the
Samba-based AD domain. This feature streamlines the process of resolving permission-related issues.

- Multiple Binaries and Class Library: The project consists of multiple binaries, each serving a specific functionality,
while linking with a class library that provides all the necessary functionalities. This modular structure enhances maintainability and extensibility.

- Unit-Tested Class Library: The class library, which forms the core of **samba-cli**, is thoroughly unit-tested to ensure
stability and reliability. However, please note that the commands runner component cannot be fully tested without interacting with the actual domain due to its nature.

## Requirements

- .NET 6.0 runtime or SDK installed on the system.

## Installation

1. Clone the **samba-cli** repository.
```
git clone https://github.com/m4ce-w1ndu/samba-cli.git
```

2. Build the solution using the .NET CLI.

```
dotnet build
```

## Usage

1. Navigate to the appropriate binary folder for the desired functionality. In the future, an installer will be provided as part of the project.


2. Run the binary with the desired command.

## Contributing

Contributions are welcome! If you'd like to contribute to **samba-cli**, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and ensure all unit tests pass.
4. Commit your changes and push them to your fork.
5. Submit a pull request with a detailed description of your changes.

Please note that we cannot accept contributions that directly modify the commands runner component due to the limitations of testing without interfering with the domain.

## License

samba-cli is released under the [MIT License](https://opensource.org/licenses/MIT). See the [LICENSE](LICENSE) file for more details.

## Contact

For questions, suggestions, or support, please contact the project maintainers at m4ce.w1ndu@icloud.com.
