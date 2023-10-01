# Crawler Project

This project, named "Crawler," is a simple web crawler application written in C# that extracts email addresses from a given URL. It utilizes the `System.Text.RegularExpressions` namespace for email extraction using regular expressions.

## Usage

To use this application, follow these steps:

1. Clone the repository or download the source code.
2. Build the project using an appropriate C# development environment such as Visual Studio or the .NET CLI.
3. Run the compiled application from the command line, providing a URL as a command-line argument.

## Prerequisites

- .NET SDK: Ensure you have the .NET SDK installed on your machine.

## Features

- Extracts email addresses from a specified URL.
- Handles command-line arguments for the URL.
- Uses regular expressions to find and extract email addresses from the webpage.

## How It Works

1. The program validates the provided command-line argument to ensure a single URL is provided.
2. It attempts to create a URI object from the provided URL and throws an exception if the URL is invalid.
3. Utilizing the `HttpClient` class, it sends an HTTP GET request to the specified URL and reads the response content.
4. The program then uses a regular expression to extract email addresses from the HTML content.
5. Email addresses are stored in a `HashSet` to eliminate duplicates.
6. If email addresses are found, they are displayed on the console.
