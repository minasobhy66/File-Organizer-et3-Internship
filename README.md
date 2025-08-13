# 📂 File Organizer Console App

This console application, built in C#, helps you organize files in a specified directory by moving them into subfolders based on their file extensions.

---

## 🚀 Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download)
* A C# IDE like [Visual Studio](https://visualstudio.microsoft.com/vs/) or [VS Code](https://code.visualstudio.com/) with the C# extension.

### How to Run

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/yourusername/your-repo-name.git](https://github.com/yourusername/your-repo-name.git)
    cd your-repo-name
    ```
2.  **Build the solution** to restore the necessary dependencies. You can do this by running `dotnet build` from your terminal or by building the project within your IDE.
3.  **Run the application with the `dotnet run` command followed by the `organize` command and the path to the directory.**

    * **To organize a folder:**
        ```CLI
         organize <filepath>
        ```
    * **To simulate the organization (without moving any files):**
        ```CLI
         organize <filepath> --simulate
        ```

---

## ✨ Features

* **Organize by Extension:** Automatically creates subfolders (e.g., `Documents`, `Images`, `Videos`) and moves files into them based on their type.
* **Simulate:** The `--simulate` flag allows you to see what the application will do without making any permanent changes. This is useful for previewing the file organization.
* **Undo All:** A powerful feature that allows you to revert all file movements made during the current session, ensuring you can easily undo any accidental changes.

---

## 📄 Notes

* The **Undo** feature is limited to actions performed within the same session. Once the application is closed, the changes are permanent.
* The program has been tested on **Windows** with **.NET 8.0**. Compatibility with other operating systems or .NET versions may vary.
